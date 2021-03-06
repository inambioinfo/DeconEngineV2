using System;
using System.IO;

namespace Engine.Results
{
    /// <summary>
    /// Lcms peak
    /// </summary>
    /// <remarks>Used by Decon2LS.UI (maybe) and by PeakImporter (from peak.dat files); also used by DeconMSn</remarks>
    public class LcmsPeak
    {
        /// <summary>
        ///     intensity of the peak.
        /// </summary>
        public double Intensity;

        /// <summary>
        ///     mz of the peak.
        /// </summary>
        public double Mz;

        /// <summary>
        ///     scan number for scan where peak occurred
        /// </summary>
        public int ScanNum;

        public LcmsPeak()
        {
            ScanNum = 0;
        }

        public LcmsPeak(LcmsPeak a)
        {
            ScanNum = a.ScanNum;
            Mz = a.Mz;
            Intensity = a.Intensity;
        }

        public LcmsPeak(int scan, float mz, float inten)
        {
            ScanNum = scan;
            Mz = mz;
            Intensity = inten;
        }

        public LcmsPeak(int scan, double mz, double inten)
        {
            ScanNum = scan;
            Mz = mz;
            Intensity = inten;
        }

        public virtual void WriteToBinaryStream(BinaryWriter stream)
        {
            stream.Write(ScanNum);
            stream.Write(Mz);
            stream.Write(Intensity);
        }

        public static LcmsPeak ReadFromBinaryStream(BinaryReader stream)
        {
            var peak = new LcmsPeak
            {
                ScanNum = stream.ReadInt32(),
                Mz = stream.ReadDouble(),
                Intensity = stream.ReadDouble()
            };
            return peak;
        }
    }
}