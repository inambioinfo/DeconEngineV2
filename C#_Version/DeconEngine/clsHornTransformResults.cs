using System;
using Engine.HornTransform;

namespace DeconToolsV2.HornTransform
{
    public class clsHornTransformResults
    {
        /// <summary>
        ///     intensity of feature (as a double)
        /// </summary>
        public double Abundance;

        /// <summary>
        ///     average mw for the feature.
        /// </summary>
        public double AverageMw;

        /// <summary>
        ///     charge state
        /// </summary>
        public short ChargeState;

        /// <summary>
        ///     difference between observed m/z and m/z from theoretical distribution of composition from Averagine
        /// </summary>
        public double DeltaMz;

        /// <summary>
        ///     fit value.
        /// </summary>
        public double Fit;

        /// <summary>
        ///     Number of data points used to compute the fit value
        /// </summary>
        public int FitCountBasis;

        /// <summary>
        ///     full width at half maximum of the peak.
        /// </summary>
        public double FwHm;

        /// <summary>
        ///     array of indices of peak tops
        /// </summary>
        public int[] IsotopePeakIndices;

        /// <summary>
        ///     intensity of monoisotopic peak observed.
        /// </summary>
        public int MonoIntensity;

        /// <summary>
        ///     monoisotopic mw of feature.
        /// </summary>
        public double MonoMw;

        /// <summary>
        ///     intensity of the third isotopic peak observed. Used by other software for processing of O16/O18  data.
        /// </summary>
        public int MonoPlus2Intensity;

        /// <summary>
        ///     mw at the most intense isotope.
        /// </summary>
        public double MostIntenseMw;

        /// <summary>
        ///     m/z value of most abundant peak in the feature.
        /// </summary>
        public double Mz;

        /// <summary>
        ///     need multiple isotopes to determine charge
        /// </summary>
        public bool NeedMultipleIsotopes;

        /// <summary>
        ///     number of isotope peaks
        /// </summary>
        public int NumIsotopesObserved;

        /// <summary>
        ///     peak index of the peak.
        /// </summary>
        public int PeakIndex;

        /// <summary>
        ///     scan number of peak
        /// </summary>
        public int ScanNum;

        /// <summary>
        ///     signal to noise for the most intense isotopic peak.
        /// </summary>
        public double SignalToNoise;

        public clsHornTransformResults()
        {
        }

        internal clsHornTransformResults(IsotopeFitRecord fitRecord)
        {
            PeakIndex = fitRecord.PeakIndex;
            ScanNum = fitRecord.ScanNum;
            ChargeState = fitRecord.ChargeState;
            //AbundanceInt = fitRecord.AbundanceInt;
            Abundance = fitRecord.Abundance;
            Mz = fitRecord.Mz;
            Fit = fitRecord.Fit;
            FitCountBasis = fitRecord.FitCountBasis;
            AverageMw = fitRecord.AverageMw;
            MonoMw = fitRecord.MonoMw;
            MostIntenseMw = fitRecord.MostIntenseMw;
            FwHm = fitRecord.FWHM;
            SignalToNoise = fitRecord.SignalToNoise;
            MonoIntensity = fitRecord.MonoIntensity;
            MonoPlus2Intensity = fitRecord.MonoPlus2Intensity;
            DeltaMz = fitRecord.DeltaMz;
            NumIsotopesObserved = fitRecord.NumIsotopesObserved;
            IsotopePeakIndices = new int[NumIsotopesObserved];
            for (var i = 0; i < NumIsotopesObserved; i++)
            {
                IsotopePeakIndices[i] = fitRecord.IsotopePeakIndices[i];
            }
        }

        public virtual object Clone()
        {
            var result = new clsHornTransformResults();
            result.PeakIndex = PeakIndex;
            result.ScanNum = ScanNum;
            result.ChargeState = ChargeState;
            //result.AbundanceInt = this.AbundanceInt;
            result.Abundance = Abundance;
            result.Mz = Mz;
            result.Fit = Fit;
            result.FitCountBasis = FitCountBasis;
            result.AverageMw = AverageMw;
            result.MonoMw = MonoMw;
            result.MostIntenseMw = MostIntenseMw;
            result.FwHm = FwHm;
            result.SignalToNoise = SignalToNoise;
            result.MonoIntensity = MonoIntensity;
            result.MonoPlus2Intensity = MonoPlus2Intensity;
            result.DeltaMz = DeltaMz;
            result.NumIsotopesObserved = NumIsotopesObserved;
            result.IsotopePeakIndices = new int[NumIsotopesObserved];
            for (var i = 0; i < NumIsotopesObserved; i++)
            {
                result.IsotopePeakIndices[i] = IsotopePeakIndices[i];
            }
            return result;
        }

#if !Disable_Obsolete
        /// <summary>
        ///     intensity of feature; maximum value that can be represented is 2147483648
        /// </summary>
        [Obsolete("Use Abundance (double); sometimes intensity can be greater than 2147483648", false)]
        public int AbundanceInt
        {
            get
            {
                if (Abundance > int.MaxValue)
                    return int.MaxValue;
                return Convert.ToInt32(Abundance);
            }
            set { Abundance = value; }
        }

        /// <summary>
        ///     peak index of the peak.
        /// </summary>
        [Obsolete("Use PeakIndex", false)]
        public int mint_peak_index
        {
            get { return PeakIndex; }
            set { PeakIndex = value; }
        }

        /// <summary>
        ///     scan number of peak
        /// </summary>
        [Obsolete("Use ScanNum", false)]
        public int mint_scan_num
        {
            get { return ScanNum; }
            set { ScanNum = value; }
        }

        /// <summary>
        ///     charge state
        /// </summary>
        [Obsolete("Use ChargeState", false)]
        public short mshort_cs
        {
            get { return ChargeState; }
            set { ChargeState = value; }
        }

        /// <summary>
        ///     intensity of feature; maximum value that can be represented is 2147483648
        /// </summary>
        [Obsolete("Use Abundance (double); sometimes intensity can be greater than 2147483648", false)]
        public int mint_abundance
        {
            get { return AbundanceInt; }
            set { AbundanceInt = value; }
        }

        /// <summary>
        ///     intensity of feature (as a double)
        /// </summary>
        [Obsolete("Use Abundance", false)]
        public double mdbl_abundance
        {
            get { return Abundance; }
            set { Abundance = value; }
        }

        /// <summary>
        ///     m/z value of most abundant peak in the feature.
        /// </summary>
        [Obsolete("Use Mz", false)]
        public double mdbl_mz
        {
            get { return Mz; }
            set { Mz = value; }
        }

        /// <summary>
        ///     fit value.
        /// </summary>
        [Obsolete("Use Fit", false)]
        public double mdbl_fit
        {
            get { return Fit; }
            set { Fit = value; }
        }

        /// <summary>
        ///     Number of data points used to compute the fit value
        /// </summary>
        [Obsolete("Use FitCountBasis", false)]
        public int mint_fit_count_basis
        {
            get { return FitCountBasis; }
            set { FitCountBasis = value; }
        }

        /// <summary>
        ///     average mw for the feature.
        /// </summary>
        [Obsolete("Use AverageMw", false)]
        public double mdbl_average_mw
        {
            get { return AverageMw; }
            set { AverageMw = value; }
        }

        /// <summary>
        ///     monoisotopic mw of feature.
        /// </summary>
        [Obsolete("Use MonoMw", false)]
        public double mdbl_mono_mw
        {
            get { return MonoMw; }
            set { MonoMw = value; }
        }

        /// <summary>
        ///     mw at the most intense isotope.
        /// </summary>
        [Obsolete("Use MostIntenseMw", false)]
        public double mdbl_most_intense_mw
        {
            get { return MostIntenseMw; }
            set { MostIntenseMw = value; }
        }

        /// <summary>
        ///     full width at half maximum of the peak.
        /// </summary>
        [Obsolete("Use FwHm", false)]
        public double mdbl_fwhm
        {
            get { return FwHm; }
            set { FwHm = value; }
        }

        /// <summary>
        ///     signal to noise for the most intense isotopic peak.
        /// </summary>
        [Obsolete("Use SignalToNoise", false)]
        public double mdbl_sn
        {
            get { return SignalToNoise; }
            set { SignalToNoise = value; }
        }

        /// <summary>
        ///     intensity of monoisotopic peak observed.
        /// </summary>
        [Obsolete("Use MonoIntensity", false)]
        public int mint_mono_intensity
        {
            get { return MonoIntensity; }
            set { MonoIntensity = value; }
        }

        /// <summary>
        ///     intensity of the third isotopic peak observed. Used by other software for processing of O16/O18  data.
        /// </summary>
        [Obsolete("Use MonoPlus2Intensity", false)]
        public int mint_iplus2_intensity
        {
            get { return MonoPlus2Intensity; }
            set { MonoPlus2Intensity = value; }
        }

        /// <summary>
        ///     difference between observed m/z and m/z from theoretical distribution of composition from Averagine
        /// </summary>
        [Obsolete("Use DeltaMz", false)]
        public double mdbl_delta_mz
        {
            get { return DeltaMz; }
            set { DeltaMz = value; }
        }

        /// <summary>
        ///     need multiple isotopes to determine charge
        /// </summary>
        [Obsolete("Use NeedMultipleIsotopes", false)]
        public bool mbln_need_multiple_isotopes
        {
            get { return NeedMultipleIsotopes; }
            set { NeedMultipleIsotopes = value; }
        }

        /// <summary>
        ///     number of isotope peaks
        /// </summary>
        [Obsolete("Use NumIsotopesObserved", false)]
        public int mint_num_isotopes_observed
        {
            get { return NumIsotopesObserved; }
            set { NumIsotopesObserved = value; }
        }

        /// <summary>
        ///     array of indices of peak tops
        /// </summary>
        [Obsolete("Use IsotopePeakIndices", false)]
        public int[] marr_isotope_peak_indices
        {
            get { return IsotopePeakIndices; }
            set { IsotopePeakIndices = value; }
        }
#endif
    }
}