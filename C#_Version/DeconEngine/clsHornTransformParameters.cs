using System;
using System.Xml;

namespace DeconToolsV2.HornTransform
{
#if !Disable_Obsolete
    [Obsolete("Only used by OldDeconToolsParameters", false)]
    public enum enmExportFileType
    {
        TEXT = 0,
        SQLITE
    }
#endif

    public class clsHornTransformParameters : ICloneable
    {
#if !Disable_Obsolete
        private static string DEFAULT_ISOTOPE_FILE = "isotope.xml";
#endif

        private clsElementIsotopes _elementIsotopes;

        public clsHornTransformParameters()
        {
            MaxCharge = 10;
            NumPeaksForShoulder = 1;
            MaxMW = 10000;
            MaxFit = 0.25;
            CCMass = 1.00727638;
            DeleteIntensityThreshold = 10;
            MinIntensityForScore = 10;
            O16O18Media = false;
            MinS2N = 3;
            PeptideMinBackgroundRatio = 5;
            AveragineFormula = "C4.9384 H7.7583 N1.3577 O1.4773 S0.0417";
            TagFormula = "";
            O16O18Media = false;
            ThrashOrNot = true;
            CompleteFit = false;
            UseMercuryCaching = true;
            _elementIsotopes = new clsElementIsotopes();
            UseMZRange = true;
            MinMZ = 400;
            MaxMZ = 2000;
            MinScan = int.MinValue;
            MaxScan = int.MaxValue;
            UseScanRange = false;
            UseSavitzkyGolaySmooth = false;
            SGNumLeft = 2;
            SGNumRight = 2;
            SGOrder = 2;
            IsotopeFitType = enmIsotopeFitType.AREA;
            UseAbsolutePeptideIntensity = false;
            AbsolutePeptideIntensity = 0;
            NumZerosToFill = 3;
            ZeroFill = false;
            CheckAllPatternsAgainstCharge1 = false;
            NumScansToSumOver = 0;
            SumSpectra = false;
            ProcessMSMS = false;
            SumSpectraAcrossFrameRange = true;
            NumFramesToSumOver = 3;
            IsActualMonoMZUsed = false;
            LeftFitStringencyFactor = 1;
            RightFitStringencyFactor = 1;
            UseRAPIDDeconvolution = false;
            ReplaceRAPIDScoreWithHornFitScore = false;
#if !Disable_Obsolete
            ExportFileType = enmExportFileType.TEXT;
#endif
            NumPeaksUsedInAbundance = 1;
            DetectPeaksOnlyWithNoDeconvolution = false;
            ProcessMS = true;
            ScanBasedWorkflowType = "standard";
            SaturationThreshold = 90000;
        }

        public bool IsActualMonoMZUsed { get; set; }
        public double LeftFitStringencyFactor { get; set; }
        public double RightFitStringencyFactor { get; set; }
        public short SGNumLeft { get; set; }
        public short SGNumRight { get; set; }
        public short SGOrder { get; set; }
        public bool UseSavitzkyGolaySmooth { get; set; }
        public int MinScan { get; set; }
        public int MaxScan { get; set; }
        public bool UseMercuryCaching { get; set; }
        /// <summary>
        /// whether or not to use a range of scans
        /// </summary>
        public bool UseScanRange { get; set; }
        public bool SumSpectra { get; set; }
        public bool SumSpectraAcrossScanRange { get; set; }
        public int NumScansToSumOver { get; set; }
        public int NumFramesToSumOver { get; set; }
        public bool SumSpectraAcrossFrameRange { get; set; }
        public bool UseMZRange { get; set; }
        public double MinMZ { get; set; }
        public double MaxMZ { get; set; }
        public short MaxCharge { get; set; }
        public double MinS2N { get; set; }
        public double PeptideMinBackgroundRatio { get; set; }
        public short NumPeaksForShoulder { get; set; }
        public double MaxMW { get; set; }
        public double MaxFit { get; set; }
        public double CCMass { get; set; }
        public double DeleteIntensityThreshold { get; set; }
        public bool ZeroFill { get; set; }
        public short NumZerosToFill { get; set; }
        public double MinIntensityForScore { get; set; }
        public bool O16O18Media { get; set; }
        public string AveragineFormula { get; set; }
        public string TagFormula { get; set; }
        public bool ThrashOrNot { get; set; }
        public bool CompleteFit { get; set; }
        public bool ProcessMSMS { get; set; }
        public bool CheckAllPatternsAgainstCharge1 { get; set; }

        public clsElementIsotopes ElementIsotopeComposition
        {
            get
            {
                if (_elementIsotopes == null)
                    _elementIsotopes = new clsElementIsotopes();
                return _elementIsotopes;
            }
            set
            {
                _elementIsotopes = value;
            }
        }

        public enmIsotopeFitType IsotopeFitType { get; set; }
        public bool UseAbsolutePeptideIntensity { get; set; }
        public double AbsolutePeptideIntensity { get; set; }
        public bool UseRAPIDDeconvolution { get; set; }
        public bool ReplaceRAPIDScoreWithHornFitScore { get; set; }
        
#if !Disable_Obsolete
        [Obsolete("Only used by OldDeconToolsParameters", false)]
        public enmExportFileType ExportFileType { get; set; }
#endif
        /// <summary>
        /// when abundance for an IsosResult is reported... this is how many peaks are summed. Typically the most abundant peak's abundance is reported.
        /// </summary>
        public short NumPeaksUsedInAbundance { get; set; }
        public short NumScansToAdvance { get; set; }
        public bool DetectPeaksOnlyWithNoDeconvolution { get; set; }
        public bool ProcessMS { get; set; }
        public string ScanBasedWorkflowType { get; set; }
        public double SaturationThreshold { get; set; }

        public virtual object Clone()
        {
            var newParams = new clsHornTransformParameters();
            newParams.AveragineFormula = (string) AveragineFormula.Clone();
            newParams.CCMass = CCMass;
            newParams.CompleteFit = CompleteFit;
            newParams.DeleteIntensityThreshold = DeleteIntensityThreshold;
            newParams.ElementIsotopeComposition =
                (clsElementIsotopes) ElementIsotopeComposition.Clone();
            newParams.MaxCharge = MaxCharge;
            newParams.MaxFit = MaxFit;
            newParams.MaxMW = MaxMW;
            newParams.MinIntensityForScore = MinIntensityForScore;
            newParams.MinS2N = MinS2N;
            newParams.NumPeaksForShoulder = NumPeaksForShoulder;
            newParams.O16O18Media = O16O18Media;
            newParams.PeptideMinBackgroundRatio = PeptideMinBackgroundRatio;
            newParams.TagFormula = (string) TagFormula.Clone();
            newParams.ThrashOrNot = ThrashOrNot;
            newParams.IsotopeFitType = IsotopeFitType;
            newParams.UseMercuryCaching = UseMercuryCaching;

            newParams.UseMZRange = UseMZRange;
            newParams.MinMZ = MinMZ;
            newParams.MaxMZ = MaxMZ;
            newParams.UseMercuryCaching = UseMercuryCaching;
            newParams.MinScan = MinScan;
            newParams.MaxScan = MaxScan;
            newParams.UseScanRange = UseScanRange;
            newParams.CheckAllPatternsAgainstCharge1 = CheckAllPatternsAgainstCharge1;

            newParams.UseSavitzkyGolaySmooth = UseSavitzkyGolaySmooth;
            newParams.SGNumLeft = SGNumLeft;
            newParams.SGNumRight = SGNumRight;
            newParams.SGOrder = SGOrder;

            newParams.ZeroFill = ZeroFill;
            newParams.NumZerosToFill = NumZerosToFill;

            newParams.AbsolutePeptideIntensity = AbsolutePeptideIntensity;
            newParams.UseAbsolutePeptideIntensity = UseAbsolutePeptideIntensity;
            newParams.NumScansToSumOver = NumScansToSumOver;
            newParams.SumSpectra = SumSpectra;
            newParams.SumSpectraAcrossScanRange = SumSpectraAcrossScanRange;
            newParams.NumFramesToSumOver = NumFramesToSumOver;
            newParams.SumSpectraAcrossFrameRange = SumSpectraAcrossFrameRange;
            newParams.ProcessMSMS = ProcessMSMS;
            newParams.IsActualMonoMZUsed = IsActualMonoMZUsed;
            newParams.LeftFitStringencyFactor = LeftFitStringencyFactor;
            newParams.RightFitStringencyFactor = RightFitStringencyFactor;
            newParams.UseRAPIDDeconvolution = UseRAPIDDeconvolution;
            newParams.ReplaceRAPIDScoreWithHornFitScore = ReplaceRAPIDScoreWithHornFitScore;
#if !Disable_Obsolete
            newParams.ExportFileType = ExportFileType;
#endif
            newParams.NumPeaksUsedInAbundance = NumPeaksUsedInAbundance;
            newParams.NumScansToAdvance = NumScansToAdvance;
            newParams.DetectPeaksOnlyWithNoDeconvolution = DetectPeaksOnlyWithNoDeconvolution;
            newParams.ProcessMS = ProcessMS;
            newParams.ScanBasedWorkflowType = (string) ScanBasedWorkflowType.Clone();

            return newParams;
        }
        
#if !Disable_Obsolete
        [Obsolete("Only used by OldDeconToolsParameters", false)]
        public void SaveV1HornTransformParameters(XmlTextWriter xwriter)
        {
            xwriter.WriteWhitespace("\n\t");
            xwriter.WriteStartElement("HornTransformParameters");
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("TagFormula", TagFormula);
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("AveragineFormula", AveragineFormula);
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("DeleteIntensityThreshold", DeleteIntensityThreshold.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MaxFit", MaxFit.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MinIntensityForScore", MinIntensityForScore.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("MaxCharge", MaxCharge.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MaxMW", MaxMW.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("NumPeaksForShoulder", NumPeaksForShoulder.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("O16O18Media", O16O18Media.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("PeptideMinBackgroundRatio", PeptideMinBackgroundRatio.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("UseAbsolutePeptideIntensity", UseAbsolutePeptideIntensity.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("AbsolutePeptideIntensity", AbsolutePeptideIntensity.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("ThrashOrNot", ThrashOrNot.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("CheckAllPatternsAgainstCharge1", CheckAllPatternsAgainstCharge1.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("CompleteFit", CompleteFit.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("CCMass", CCMass.ToString());
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("IsotopeFitType", IsotopeFitType.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("UseMercuryCaching", UseMercuryCaching.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("SumSpectra", SumSpectra.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("SumSpectraAcrossScanRange", SumSpectraAcrossScanRange.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("NumberOfScansToSumOver", NumScansToSumOver.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("NumberOfScansToAdvance", NumScansToAdvance.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("SumSpectraAcrossFrameRange", SumSpectraAcrossFrameRange.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("NumberOfFramesToSumOver", NumFramesToSumOver.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("IsActualMonoMZUsed", IsActualMonoMZUsed.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("LeftFitStringencyFactor", LeftFitStringencyFactor.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("RightFitStringencyFactor", RightFitStringencyFactor.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("UseRAPIDDeconvolution", UseRAPIDDeconvolution.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ReplaceRAPIDScoreWithHornFitScore",
                ReplaceRAPIDScoreWithHornFitScore.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("NumPeaksUsedInAbundance", NumPeaksUsedInAbundance.ToString());

            xwriter.WriteWhitespace("\n\t");
            xwriter.WriteEndElement();
        }
#endif

#if !Disable_Obsolete
        [Obsolete("Only used by OldDeconToolsParameters", false)]
        public void SaveV1MiscellaneousParameters(XmlTextWriter xwriter)
        {
            xwriter.WriteWhitespace("\n\t");
            xwriter.WriteStartElement("Miscellaneous");
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("UseScanRange", Convert.ToString(UseScanRange));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MinScan", Convert.ToString(MinScan));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MaxScan", Convert.ToString(MaxScan));
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("UseMZRange", Convert.ToString(UseMZRange));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MinMZ", Convert.ToString(MinMZ));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("MaxMZ", Convert.ToString(MaxMZ));
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ApplySavitzkyGolay", Convert.ToString(UseSavitzkyGolaySmooth));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("SGNumLeft", Convert.ToString(SGNumLeft));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("SGNumRight", Convert.ToString(SGNumRight));
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("SGOrder", Convert.ToString(SGOrder));
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ZeroFillDiscontinousAreas", Convert.ToString(ZeroFill));
            xwriter.WriteWhitespace("\n\t\t");
            xwriter.WriteElementString("NumZerosToFill", Convert.ToString(NumZerosToFill));
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ProcessMSMS", ProcessMSMS.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ExportFileType", ExportFileType.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("DetectPeaksOnly_NoDeconvolution",
                DetectPeaksOnlyWithNoDeconvolution.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("Process_MS", ProcessMS.ToString());
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("ScanBasedWorkflowType", ScanBasedWorkflowType);
            xwriter.WriteWhitespace("\n\t\t");

            xwriter.WriteElementString("SaturationThreshold", SaturationThreshold.ToString());

            xwriter.WriteWhitespace("\n\t");
            xwriter.WriteEndElement();
        }
#endif

#if !Disable_Obsolete
        [Obsolete("Only used by OldDeconToolsParameters", false)]
        public void LoadV1HornTransformParameters(XmlReader rdr)
        {
            //Add code to handle empty nodes.
            //Read each node in the tree.
            while (rdr.Read())
            {
                switch (rdr.NodeType)
                {
                    case XmlNodeType.Element:
                        if (rdr.Name.Equals("TagFormula"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                TagFormula = "";
                                continue;
                            }

                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            TagFormula = rdr.Value;
                        }
                        else if (rdr.Name.Equals("UseMercuryCaching"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception("No information for caching of Mercury in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information for caching of Mercury in parameter file");
                            }
                            UseMercuryCaching = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SumSpectra"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception("No information for SumSpectra in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information for summing spectra in parameter file");
                            }
                            SumSpectra = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SumSpectraAcrossScanRange"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception("No information for SumSpectraAcrossScanRange in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information for summing across scan range in parameter file");
                            }
                            SumSpectraAcrossScanRange = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SumSpectraAcrossFrameRange")) //FIX this
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception("No information for SumSpectraAcrossFrameRange in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information for summing across frame range in parameter file");
                            }
                            SumSpectraAcrossFrameRange = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("CheckAllPatternsAgainstCharge1"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for CheckAllPatternsAgainstCharge1 in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information for caching of Mercury in parameter file");
                            }
                            CheckAllPatternsAgainstCharge1 = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("AveragineFormula"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception("No averagine formula provided in parameter file");
                            }
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No averagine formula provided in parameter file");
                            }
                            AveragineFormula = rdr.Value;
                        }
                        else if (rdr.Name.Equals("DeleteIntensityThreshold"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No DeleteIntensityThreshold was specified in parameter file");
                            }
                            DeleteIntensityThreshold = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MaxFit"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No MaxFit value was specified in parameter file");
                            }
                            MaxFit = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MinIntensityForScore"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No minimum intensity value was specified for score in parameter file");
                            }
                            MinIntensityForScore = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MaxCharge"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No maximum charge value was specified in parameter file");
                            }
                            MaxCharge = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MaxMW"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No maximum mass value was specified in parameter file");
                            }
                            MaxMW = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("NumPeaksForShoulder"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for number of peaks for shoulder in parameter file");
                            }
                            NumPeaksForShoulder = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("O16O18Media"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters was specified for O16/O18 media in parameter file");
                            }
                            O16O18Media = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("PeptideMinBackgroundRatio"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for min background ratio for peptide in parameter file");
                            }
                            PeptideMinBackgroundRatio = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("UseAbsolutePeptideIntensity"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for use of absoluted intensity threshold in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for use of absolute intensity threshold in parameter file");
                            }
                            UseAbsolutePeptideIntensity = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("AbsolutePeptideIntensity"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for absolute peptide threshold in parameter file");
                            }
                            AbsolutePeptideIntensity = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("NumberOfScansToSumOver"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for number of peaks for shoulder in parameter file");
                            }
                            NumScansToSumOver = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("NumberOfFramesToSumOver"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for number of frames to sum over in parameter file");
                            }
                            NumFramesToSumOver = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ThrashOrNot"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters was specified for thrashing in parameter file");
                            }
                            ThrashOrNot = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("CompleteFit"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters was specified for complete fit in parameter file");
                            }
                            CompleteFit = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("CCMass"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for charge carrier mass in parameter file");
                            }
                            CCMass = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("IsotopeFitType"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("Missing information for IsotopeFitType in parameter file");
                            }
                            if (rdr.Value.Equals(enmIsotopeFitType.AREA.ToString()))
                            {
                                IsotopeFitType = enmIsotopeFitType.AREA;
                            }
                            else if (rdr.Value.Equals(enmIsotopeFitType.PEAK.ToString()))
                            {
                                IsotopeFitType = enmIsotopeFitType.PEAK;
                            }
                            else if (rdr.Value.Equals(enmIsotopeFitType.CHISQ.ToString()))
                            {
                                IsotopeFitType = enmIsotopeFitType.CHISQ;
                            }
                        }
                        else if (rdr.Name.Equals("IsActualMonoMZUsed"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for parameter 'IsActualMonoMZUsed' in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for parameter 'IsActualMonoMZUsed' in parameter file");
                            }
                            IsActualMonoMZUsed = bool.Parse(rdr.Value);
                        }

                        else if (rdr.Name.Equals("LeftFitStringencyFactor"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for parameter 'LeftFitStringencyFactor' in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for parameter 'LeftFitStringencyFactor' in parameter file");
                            }
                            LeftFitStringencyFactor = double.Parse(rdr.Value);
                        }

                        else if (rdr.Name.Equals("RightFitStringencyFactor"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for parameter 'RightFitStringencyFactor' in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for parameter 'RightFitStringencyFactor' in parameter file");
                            }
                            RightFitStringencyFactor = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("UseRAPIDDeconvolution"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for parameter 'UseRAPIDDeconvolution' in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for parameter 'UseRAPIDDeconvolution' in parameter file");
                            }
                            UseRAPIDDeconvolution = bool.Parse(rdr.Value);
                        }

                        else if (rdr.Name.Equals("ReplaceRAPIDScoreWithHornFitScore"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                throw new Exception(
                                    "No information for parameter 'ReplaceRAPIDScoreWithHornFitScore' in parameter file");
                            }
                            rdr.Read();

                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }

                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information for parameter 'ReplaceRAPIDScoreWithHornFitScore' in parameter file");
                            }
                            ReplaceRAPIDScoreWithHornFitScore = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("NumPeaksUsedInAbundance"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for 'NumPeaksUsedInAbundance' in parameter file");
                            }
                            NumPeaksUsedInAbundance = short.Parse(rdr.Value);
                        }

                        else if (rdr.Name.Equals("NumberOfScansToAdvance"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for 'NumScansToAdvance' in parameter file");
                            }
                            NumScansToAdvance = (short) int.Parse(rdr.Value);
                        }

                        break;
                    case XmlNodeType.EndElement:
                        if (rdr.Name.Equals("HornTransformParameters"))
                            return;
                        break;
                    default:
                        break;
                }
            }
        }
#endif

#if !Disable_Obsolete
        [Obsolete("Only used by OldDeconToolsParameters", false)]
        public void LoadV1MiscellaneousParameters(XmlReader rdr)
        {
            //Read each node in the tree.
            while (rdr.Read())
            {
                switch (rdr.NodeType)
                {
                    case XmlNodeType.Element:
                        if (rdr.Name.Equals("UseScanRange"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for using scan range");
                            }
                            UseScanRange = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MinScan"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for min scan number.");
                            }
                            MinScan = int.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MaxScan"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for max scan number.");
                            }
                            MaxScan = int.Parse(rdr.Value);
                        }
                        if (rdr.Name.Equals("UseMZRange"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for using mz range");
                            }
                            UseMZRange = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MinMZ"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for min m/z.");
                            }
                            MinMZ = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("MaxMZ"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for max m/z.");
                            }
                            MaxMZ = double.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ApplySavitzkyGolay"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for using Savitzky Golay");
                            }
                            UseSavitzkyGolaySmooth = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SGNumLeft"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information specified for # of left points in Savitzky Golay smoothing.");
                            }
                            SGNumLeft = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SGNumRight"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No information specified for # of right points in Savitzky Golay smoothing.");
                            }
                            SGNumRight = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("SGOrder"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for order.");
                            }
                            SGOrder = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ZeroFillDiscontinousAreas"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for zero filling.");
                            }
                            ZeroFill = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("NumZerosToFill"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No information specified for zero filling.");
                            }
                            NumZerosToFill = short.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ProcessMSMS"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters was specified for ProcessMSMS in parameter file");
                            }
                            ProcessMSMS = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ExportFileType"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("Missing information for ExportFileType in parameter file");
                            }
                            if (rdr.Value.Equals(enmExportFileType.TEXT.ToString()))
                            {
                                ExportFileType = enmExportFileType.TEXT;
                            }
                            else if (rdr.Value.Equals(enmExportFileType.SQLITE.ToString()))
                            {
                                ExportFileType = enmExportFileType.SQLITE;
                            }
                            else
                            {
                                ExportFileType = enmExportFileType.TEXT;
                            }
                        }
                        else if (rdr.Name.Equals("Process_MS"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters was specified for ProcessMS in parameter file");
                            }
                            ProcessMS = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("DetectPeaksOnly_NoDeconvolution"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception(
                                    "No parameters was specified for 'DetectPeaksOnlyWithNoDeconvolution' in parameter file");
                            }
                            DetectPeaksOnlyWithNoDeconvolution = bool.Parse(rdr.Value);
                        }
                        else if (rdr.Name.Equals("ScanBasedWorkflowType"))
                        {
                            if (rdr.IsEmptyElement)
                            {
                                ScanBasedWorkflowType = "";
                                continue;
                            }

                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            ScanBasedWorkflowType = rdr.Value;
                        }
                        else if (rdr.Name.Equals("SaturationThreshold"))
                        {
                            rdr.Read();
                            while (rdr.NodeType == XmlNodeType.Whitespace ||
                                   rdr.NodeType == XmlNodeType.SignificantWhitespace)
                            {
                                rdr.Read();
                            }
                            if (rdr.NodeType != XmlNodeType.Text)
                            {
                                throw new Exception("No parameters were specified for 'SaturationThreshold'");
                            }
                            SaturationThreshold = double.Parse(rdr.Value);
                        }

                        break;
                    case XmlNodeType.EndElement:
                        if (rdr.Name.Equals("Miscellaneous"))
                            return;
                        break;
                    default:
                        break;
                }
            }
        }
#endif
    }
}