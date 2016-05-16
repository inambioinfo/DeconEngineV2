using System;
using System.Collections.Generic;
using Engine.Utilities;

namespace Engine.TheoreticalProfile
{
#if !Disable_Obsolete
    [Obsolete("Usages removed", true)]
    internal class MolecularFormulaError : System.Exception
    {
        public string mstr_location;
        public string mstr_message;

        public MolecularFormulaError(string error_message, string location) : base(error_message + " " + location)
        {
            mstr_message = error_message;
            mstr_location = location;
        }
    }
#endif

    internal class AtomicCount
    {
        /// <summary>
        ///     index of this element in list of elements used.
        /// </summary>
        public int Index;

        /// <summary>
        ///     Number of copies of the above element in compound. we have set this to be a double to allow for normalized values.
        /// </summary>
        public double NumCopies;

        public AtomicCount()
        {
        }

        public AtomicCount(AtomicCount ac)
        {
            Index = ac.Index;
            NumCopies = ac.NumCopies;
        }
    }

    internal class MolecularFormula
    {
        public double AverageMass;
        public List<AtomicCount> ElementalComposition = new List<AtomicCount>();
        public double MonoisotopicMass;

        public double TotalAtomCount;

        public MolecularFormula()
        {
            TotalAtomCount = 0;
            MonoisotopicMass = 0;
            AverageMass = 0;
            Formula = "";
        }

        public MolecularFormula(string formula, AtomicInformation atomicInformation)
        {
            SetMolecularFormula(formula, atomicInformation);
        }

        public MolecularFormula(MolecularFormula formula)
        {
            Formula = formula.Formula;
            TotalAtomCount = formula.TotalAtomCount;
            MonoisotopicMass = formula.MonoisotopicMass;
            ElementalComposition.Clear();
            ElementalComposition.AddRange(formula.ElementalComposition);
        }

        public string Formula { get; private set; }

        public int NumElements
        {
            get { return ElementalComposition.Count; }
        }

        public override string ToString()
        {
            var data = " monomw =" + MonoisotopicMass + " averagemw=" + AverageMass + "\n";
            for (var elementNum = 0; elementNum < ElementalComposition.Count; elementNum++)
            {
                data += ElementalComposition[elementNum].Index + " Num Atoms = " +
                        ElementalComposition[elementNum].NumCopies + "\n";
            }
            return data;
        }

        public bool IsAssigned()
        {
            return NumElements != 0;
        }

        public void Clear()
        {
            TotalAtomCount = 0;
            MonoisotopicMass = 0;
            AverageMass = 0;
            Formula = "";
            ElementalComposition.Clear();
        }

        public void SetMolecularFormula(string molFormula, AtomicInformation atomicInformation)
        {
            Formula = molFormula;
            var formula = molFormula;
            TotalAtomCount = 0;

            ElementalComposition.Clear();
            var formulaLength = formula.Length;
            var index = 0;
            //var numAtoms = atomicInformation.GetNumElements();
            MonoisotopicMass = 0;

            while (index < formulaLength)
            {
                while (index < formulaLength && (formula[index] == ' ' || formula[index] == '\t'))
                {
                    index++;
                }

                var startIndex = index;
                var stopIndex = startIndex;
                var symbolChar = formula[stopIndex];
                if (!(symbolChar >= 'A' && symbolChar <= 'Z') && !(symbolChar >= 'a' && symbolChar <= 'z'))
                {
                    var errorStr = "Molecular Formula specified was incorrect at position: " + (stopIndex + 1) +
                                   ". Should have element symbol there";
                    throw new System.Exception(errorStr);
                }

                while ((symbolChar >= 'A' && symbolChar <= 'Z') || (symbolChar >= 'a' && symbolChar <= 'z'))
                {
                    stopIndex++;
                    if (stopIndex == formulaLength)
                        break;
                    symbolChar = formula[stopIndex];
                }

                var atomicSymbol = formula.Substring(startIndex, stopIndex - startIndex);
                index = stopIndex;
                while (index < formulaLength && (formula[index] == ' ' || formula[index] == '\t'))
                {
                    index++;
                }
                double count = 0;
                if (index == formulaLength)
                {
                    // assume that the last symbol had a 1.
                    count = 1;
                }
                startIndex = index;
                stopIndex = startIndex;
                symbolChar = formula[stopIndex];
                var decimalFound = false;
                while ((symbolChar >= '0' && symbolChar <= '9') || symbolChar == '.')
                {
                    if (symbolChar == '.')
                    {
                        if (decimalFound)
                        {
                            // theres an error. two decimals.
                            var errorStr = "Molecular Formula specified was incorrect at position: " +
                                           (stopIndex + 1) + ". Two decimal points present";
                            throw new System.Exception(errorStr);
                        }
                        decimalFound = true;
                    }
                    stopIndex++;
                    if (stopIndex == formulaLength)
                        break;
                    symbolChar = formula[stopIndex];
                }
                if (startIndex == stopIndex)
                {
                    count = 1;
                }
                else
                {
                    count = Helpers.atof(formula.Substring(index));
                }
                // now we should have a symbol and a count. Lets get the atomicity of the atom.
                var elementIndex = atomicInformation.GetElementIndex(atomicSymbol);
                if (elementIndex == -1)
                {
                    // theres an error. two decimals.
                    var errorStr =
                        "Molecular Formula specified was incorrect. Symbol in formula was not recognize from elements provided: ";
                    errorStr += atomicSymbol;
                    throw new System.Exception(errorStr);
                }
                var currentAtom = new AtomicCount();
                currentAtom.Index = elementIndex;
                currentAtom.NumCopies = count;
                ElementalComposition.Add(currentAtom);
                index = stopIndex;
                TotalAtomCount += count;
                MonoisotopicMass += atomicInformation.ElementalIsotopesList[elementIndex].IsotopeMasses[0] * count;
                AverageMass += atomicInformation.ElementalIsotopesList[elementIndex].AverageMass * count;
            }
        }

        public void AddAtomicCount(AtomicCount cnt, double monoMass, double avgMass)
        {
            var numElements = ElementalComposition.Count;
            for (var elemNum = 0; elemNum < numElements; elemNum++)
            {
                if (ElementalComposition[elemNum].Index == cnt.Index)
                {
                    ElementalComposition[elemNum].NumCopies += cnt.NumCopies;
                    MonoisotopicMass += monoMass;
                    AverageMass += avgMass;
                    TotalAtomCount += cnt.NumCopies;
                    return;
                }
            }
            ElementalComposition.Add(cnt);
            MonoisotopicMass += monoMass;
            AverageMass += avgMass;
            TotalAtomCount += cnt.NumCopies;
        }
    }
}