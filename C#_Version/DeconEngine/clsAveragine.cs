using System;
using System.Text;
#if !Disable_Obsolete
//using Engine.TheoreticalProfile;
#endif

namespace DeconToolsV2.HornTransform
{
    public class clsAveragine
    {
        private const string DefaultProteinAveragineFormula = "C4.9384 H7.7583 N1.3577 O1.4773 S0.0417";
        //private const string DefaultRNAAveragineFormula = "C3.9 H4.9 N1.5 O2.4 P0.4";
        //private const string DefaultDNAAveragineFormula = "C3.8 H4.7 N1.5 O2.8 P0.4";

#if !Disable_Obsolete
        //[Obsolete("Class Averagine has been collapsed into this class", true)]
        //private readonly Averagine _averagine;
        //[Obsolete("Class Averagine has been collapsed into this class", true)]
        //private clsElementIsotopes _elementIsotopes;
#endif

        private readonly MolecularFormula _averagineFormula = new MolecularFormula();
        private readonly MolecularFormula _tagFormula = new MolecularFormula();

        private clsElementIsotopes _elementIsotopeAbundance = new clsElementIsotopes();
        private int _hydrogenElementIndex;
        private double _tagMass;

        /// <summary>
        ///     If a chemical labelling tag is applied to the molecular formula, it needs to be necessarily added to the molecular
        ///     formula (after substraction by its mass).
        /// </summary>
        private bool _useTag;

        public clsAveragine()
        {
            _useTag = false;
            _tagMass = 0;
#if !Disable_Obsolete
            //_averagine = new Averagine();
            //_elementIsotopes = new clsElementIsotopes();
            //_averagine.SetElementalIsotopeComposition(_elementIsotopes);
#endif
        }

        public clsAveragine(clsAveragine a)
        {
            _useTag = a._useTag;
            _tagMass = a._tagMass;
            _averagineFormula = new MolecularFormula(a._averagineFormula);
            _tagFormula = a._tagFormula;
        }
        
#if !Disable_Obsolete
        //[Obsolete("Not used outside of Decon2LS.UI (maybe)", true)]
        //public clsElementIsotopes ElementIsotopeComposition
        //{
        //    get { return _elementIsotopes; }
        //    set
        //    {
        //        _elementIsotopes = value;
        //        _averagine.SetElementalIsotopeComposition(_elementIsotopes);
        //    }
        //}
#endif

        public double MonoMass
        {
            get { return 0; }
        }

        public double AverageMass
        {
            get { return 0; }
        }

        public string AveragineFormula
        {
            get { return _averagineFormula.Formula; }
            set { _averagineFormula.SetMolecularFormula(value, _elementIsotopeAbundance); }
        }

        public string TagFormula
        {
            get { return _tagFormula.Formula; }
            set
            {
                _useTag = false;
                _tagMass = 0;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    _useTag = true;
                    _tagFormula.SetMolecularFormula(value, _elementIsotopeAbundance);
                    _tagMass = _tagFormula.AverageMass;
                }
            }
        }

        public MolecularFormula GetAverageFormulaForMass(double mw)
        {
            // still need to add tag mass.
            if (_useTag && mw > _tagMass)
            {
                mw -= _tagMass;
            }

            var empiricalFormula = new MolecularFormula();
            var numElements = _averagineFormula.NumElements;
            //var totalElementCount = _averagineFormula.TotalAtomCount;
            empiricalFormula.ElementalComposition.Clear();

            double averageMass = 0;
            double monoMass = 0;
            var hydrogenIndex = -1;
            double totalAtomCount = 0;

            for (var elementNum = 0; elementNum < numElements; elementNum++)
            {
                var elementCount = new AtomicCount(_averagineFormula.ElementalComposition[elementNum]);
                var numAtoms = (int) (mw / _averagineFormula.MonoisotopicMass * elementCount.NumCopies + 0.5);
                if (
                    string.Compare(_elementIsotopeAbundance.ElementalIsotopesList[elementCount.Index].Symbol, "H",
                        StringComparison.InvariantCulture) == 0)
                {
                    // Hydrogen is used as the remainder mass, so we skip it in the formula calculation by assigning it to 0
                    // for now and later below assigning the remainder to it.
                    hydrogenIndex = elementNum;
                    numAtoms = 0;
                }
                else
                {
                    var elementAvgMass = _elementIsotopeAbundance.ElementalIsotopesList[elementCount.Index].AverageMass;
                    var elementMonoMass =
                        _elementIsotopeAbundance.ElementalIsotopesList[elementCount.Index].Isotopes[0].Mass;
                    averageMass += elementAvgMass * numAtoms;
                    monoMass += elementMonoMass * numAtoms;
                }
                totalAtomCount += numAtoms;
                elementCount.NumCopies = numAtoms;
                empiricalFormula.ElementalComposition.Add(elementCount);
            }

            // if tag mass is enabled, add it to the formula.
            if (_useTag)
            {
                var numElementsTag = _tagFormula.NumElements;
                //var totalElementCountTag = _tagFormula.TotalAtomCount;
                for (var elementNum = 0; elementNum < numElementsTag; elementNum++)
                {
                    var elementCount = _tagFormula.ElementalComposition[elementNum];
                    var numAtoms = (int) elementCount.NumCopies;
                    var elementAvgMass = _elementIsotopeAbundance.ElementalIsotopesList[elementCount.Index].AverageMass;
                    var elementMonoMass =
                        _elementIsotopeAbundance.ElementalIsotopesList[elementCount.Index].Isotopes[0].Mass;
                    averageMass += elementAvgMass * numAtoms;
                    monoMass += elementMonoMass * numAtoms;
                    totalAtomCount += numAtoms;
                    elementCount.NumCopies = numAtoms;
                    // now go through each elementCount. If already added, then just add to its count.
                    // otherwise, create new.
                    var elementNumAlreadyPushed = -1;
                    for (var elementNumPushed = 0;
                        elementNumPushed < empiricalFormula.ElementalComposition.Count;
                        elementNumPushed++)
                    {
                        if (empiricalFormula.ElementalComposition[elementNumPushed].Index == elementCount.Index)
                        {
                            elementNumAlreadyPushed = elementNumPushed;
                            break;
                        }
                    }
                    if (elementNumAlreadyPushed == -1)
                        empiricalFormula.ElementalComposition.Add(elementCount);
                    else
                        empiricalFormula.ElementalComposition[elementNumAlreadyPushed].NumCopies +=
                            elementCount.NumCopies;
                }
            }

            // now whatever's left over in mass, is assigned to hydrogen because it is not expected to cause
            // much of a distortion in the isotope profile.
            var remainderMass = mw - averageMass;
            if (_useTag)
                remainderMass += _tagMass;
            var numHydrogens =
                (int)
                    (remainderMass / _elementIsotopeAbundance.ElementalIsotopesList[_hydrogenElementIndex].AverageMass +
                     0.5);

            averageMass += numHydrogens *
                           _elementIsotopeAbundance.ElementalIsotopesList[_hydrogenElementIndex].AverageMass;
            monoMass += numHydrogens *
                        _elementIsotopeAbundance.ElementalIsotopesList[_hydrogenElementIndex].Isotopes[0].Mass;
            totalAtomCount += numHydrogens;

            if (numHydrogens > 0)
            {
                if (hydrogenIndex != -1)
                {
                    empiricalFormula.ElementalComposition[hydrogenIndex].NumCopies += numHydrogens;
                }
                else
                {
                    empiricalFormula.ElementalComposition.Add(new AtomicCount(_hydrogenElementIndex, numHydrogens));
                }
            }
            empiricalFormula.MonoisotopicMass = monoMass;
            empiricalFormula.AverageMass = averageMass;
            empiricalFormula.TotalAtomCount = totalAtomCount;
            return empiricalFormula;
        }

        public string GenerateAveragineFormula(double averageMass, string averagineFormula, string tagFormula)
        {
#if !Disable_Obsolete
            //_averagine.AveragineFormula = averagineFormula;
            //_averagine.TagFormula = tagFormula;
            //var empiricalFormula = _averagine.GetAverageFormulaForMass(averageMass);
#endif
            AveragineFormula = averagineFormula;
            TagFormula = tagFormula;
            var empiricalFormula = GetAverageFormulaForMass(averageMass);
            // Convert to String.
            //string empiricalFormulaStr = "";
            var formulaBuilder = new StringBuilder();
            var numElements = empiricalFormula.ElementalComposition.Count;
            for (var elementNum = 0; elementNum < numElements; elementNum++)
            {
                var atomicCount = empiricalFormula.ElementalComposition[elementNum];
                //empiricalFormulaStr = string.Concat(empiricalFormulaStr, atomicInfo.ElementalIsotopesList[atomicCount.Index].Symbol, System.Convert.ToString(Convert.ToInt32(atomicCount.NumCopies)));
#if !Disable_Obsolete
                //formulaBuilder.Append(_elementIsotopes.ElementalIsotopesList[atomicCount.Index].Symbol);
#endif
                formulaBuilder.Append(_elementIsotopeAbundance.ElementalIsotopesList[atomicCount.Index].Symbol);
                formulaBuilder.Append(Convert.ToInt32(atomicCount.NumCopies));
            }
            //return empiricalFormulaStr;
            return formulaBuilder.ToString();
        }

        public void SetElementalIsotopeComposition(clsElementIsotopes elementIsotopes)
        {
            _elementIsotopeAbundance = elementIsotopes;
            _hydrogenElementIndex = _elementIsotopeAbundance.GetElementIndex("H");
            if (!_averagineFormula.IsAssigned())
            {
                AveragineFormula = DefaultProteinAveragineFormula;
            }
        }
    }
}