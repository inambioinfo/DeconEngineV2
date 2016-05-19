﻿#if !Disable_Obsolete
using System;

namespace Engine.DTAProcessing
{
    // class to store information that logs into the log file of DeconMSn
    [Obsolete("Only used by Decon2LS.UI", false)]
    internal class ProfileRecord
    {
        // scan number of MSn_scan
        public int mint_msn_scan_num;
        // parent scan
        public int mint_parent_scan_num;
        // ion injection value
        public double mdbl_agc_time;
        // tic
        public double mdbl_tic_val;

        // default constructor
        public ProfileRecord()
        {
            mint_msn_scan_num = 0;
            mint_parent_scan_num = 0;
            mdbl_agc_time = -1.0;
            mdbl_tic_val = -1.0;
        }
    }
}
#endif