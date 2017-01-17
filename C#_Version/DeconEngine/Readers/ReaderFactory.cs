using System;
using DeconToolsV2.Readers;

namespace Engine.Readers
{
    internal class ReaderFactory
    {
#if Enable_Obsolete
        [Obsolete("Only used by DeconTools for ICR2LSRun and IMFRun; BrukerV2 exists, but has no use path", false)]
        public static RawData GetMSDataReader(FileType file_type)
        {
            return GetRawData(file_type);
        }

        [Obsolete("Only used by DeconTools for ICR2LSRun and IMFRun; BrukerV2 exists, but has no use path", false)]
        public static RawData GetMSDataReader(FileType file_type, string file_name)
        {
            return GetRawData(file_type, file_name);
        }

        [Obsolete("Only used by DeconTools for ICR2LSRun and IMFRun; BrukerV2 exists, but has no use path", false)]
        public static void GetMSDataReader(out RawData raw_data, FileType file_type)
        {
            GetRawData(out raw_data, file_type);
        }
#endif

        public static RawData GetRawData(FileType file_type, string file_name)
        {
            switch (file_type)
            {
#if Enable_Obsolete
                case FileType.BRUKER:
                    BrukerRawData bruker_raw_data;
                    bruker_raw_data = new BrukerRawData();
                    bruker_raw_data.Load(file_name);
                    return bruker_raw_data;
                    break;
                case FileType.BRUKER_ASCII:
                    BrukerAsciiRawData bruker_baf_raw_data;
                    bruker_baf_raw_data = new BrukerAsciiRawData();
                    bruker_baf_raw_data.Load(file_name);
                    return bruker_baf_raw_data;
                    break;
                case FileType.ASCII:
                    AsciiRawData ascii_raw_data;
                    ascii_raw_data = new AsciiRawData();
                    ascii_raw_data.Load(file_name);
                    return ascii_raw_data;
                    break;
                case FileType.AGILENT_TOF:
#if ANALYST_INSTALLED
                    AgilentRawData agilent_raw_data;
                    agilent_raw_data = new AgilentRawData();
                    agilent_raw_data.Load(file_name);
                    return agilent_raw_data;
#endif
                    break;
                case FileType.SUNEXTREL:
                    SunExtrelRawData sun_extrel_raw_data;
                    sun_extrel_raw_data = new SunExtrelRawData();
                    sun_extrel_raw_data.Load(file_name);
                    return sun_extrel_raw_data;
                    break;
                case FileType.ICR2LSRAWDATA:
                    Icr2lsRawData icr2ls_raw_data;
                    icr2ls_raw_data = new Icr2lsRawData();
                    icr2ls_raw_data.Load(file_name);
                    return icr2ls_raw_data;
                    break;
#endif
                case FileType.FINNIGAN:
#if XCALIBUR_INSTALLED
                    FinniganRawData finnigan_raw_data;
                    finnigan_raw_data = new FinniganRawData();
                    finnigan_raw_data.Load(file_name);
                    return finnigan_raw_data;
#endif
                    //break;
#if Enable_Obsolete
                case FileType.MICROMASSRAWDATA:
#if MASSLYNX_4_INSTALLED
                    MicromassRawData micro_raw_data;
                    micro_raw_data = new MicromassRawData();
                    micro_raw_data.Load(file_name);
                    return micro_raw_data;
#endif
                    break;
#endif
                case FileType.MZXMLRAWDATA:
                    MZXmlRawData mzxml_raw_data;
                    mzxml_raw_data = new MZXmlRawData();
                    mzxml_raw_data.Load(file_name);
                    return mzxml_raw_data;
                    //break;
#if Enable_Obsolete
                case FileType.PNNL_IMS:
                    IMSRawData ims_raw_data;
                    ims_raw_data = new IMSRawData();
                    ims_raw_data.Load(file_name);
                    return ims_raw_data;
                    break;
#endif
                //case FileType.PNNL_UIMF:
                //  UIMFRawData uimf_raw_data;
                //  uimf_raw_data = new UIMFRawData();
                //  uimf_raw_data.Load(file_name);
                //  return uimf_raw_data;
                //    break;
                /*case FileType.YAFMS:
                    YafmsRawData yafms_raw_data;
                    yafms_raw_data = new YafmsRawData();
                    yafms_raw_data.Load(file_name);
                    return yafms_raw_data;
                    break; */
                default:
                    break;
            }
            return null;
        }

#if Enable_Obsolete
        [Obsolete("Only used by DeconTools for ICR2LSRun and IMFRun; BrukerV2 exists, but has no use path", false)]
        public static void GetRawData(out RawData raw_data, FileType file_type)
        {
            raw_data = null;
            switch (file_type)
            {
                case FileType.BRUKER:
                    raw_data = new BrukerRawData();
                    return;
                    break;
                case FileType.AGILENT_TOF:
#if ANALYST_INSTALLED
                    raw_data = new AgilentRawData();
                    return;
#endif
                    break;
                case FileType.FINNIGAN:
#if XCALIBUR_INSTALLED
                    raw_data = new FinniganRawData();
                    return;
#endif
                    //break;
                case FileType.SUNEXTREL:
                    raw_data = new SunExtrelRawData();
                    return;
                    break;
                case FileType.ICR2LSRAWDATA:
                    raw_data = new Icr2lsRawData();
                    return;
                    break;
                case FileType.MICROMASSRAWDATA:
#if MASSLYNX_4_INSTALLED
                    raw_data = new MicromassRawData();
#endif
                    return;
                    break;
                case FileType.MZXMLRAWDATA:
                    raw_data = new MZXmlRawData();
                    return;
                    //break;
                case FileType.PNNL_IMS:
                    raw_data = new IMSRawData();
                    return;
                    break;
                /*case FileType.PNNL_UIMF:
                    raw_data = new UIMFRawData();
                    return;
                    break; */
                /*case FileType.YAFMS:
                    raw_data = new YafmsRawData();
                    return;
                    break; */
                case FileType.BRUKER_ASCII:
                    raw_data = new BrukerAsciiRawData();
                    return;
                    break;
                case FileType.ASCII:
                    raw_data = new AsciiRawData();
                    return;
                    break;
                default:
                    break;
            }
            return;
        }

        [Obsolete("Only used by DeconTools for ICR2LSRun and IMFRun; BrukerV2 exists, but has no use path", false)]
        public static RawData GetRawData(FileType file_type)
        {
            switch (file_type)
            {
                case FileType.BRUKER:
                    BrukerRawData bruker_raw_data;
                    bruker_raw_data = new BrukerRawData();
                    return bruker_raw_data;
                    break;
                case FileType.AGILENT_TOF:
#if ANALYST_INSTALLED
                    AgilentRawData agilent_raw_data;
                    agilent_raw_data= new AgilentRawData();
                    return agilent_raw_data;
#endif
                    break;
                case FileType.FINNIGAN:
#if XCALIBUR_INSTALLED
                    FinniganRawData finnigan_raw_data;
                    finnigan_raw_data = new FinniganRawData();
                    return finnigan_raw_data;
#endif
                    //break;
                case FileType.SUNEXTREL:
                    SunExtrelRawData sun_extrel_raw_data;
                    sun_extrel_raw_data = new SunExtrelRawData();
                    return sun_extrel_raw_data;
                    break;
                case FileType.ICR2LSRAWDATA:
                    Icr2lsRawData icr2ls_raw_data;
                    icr2ls_raw_data = new Icr2lsRawData();
                    return icr2ls_raw_data;
                    break;
                case FileType.MICROMASSRAWDATA:
#if MASSLYNX_4_INSTALLED
                    MicromassRawData micro_raw_data;
                    micro_raw_data = new MicromassRawData();
                    return micro_raw_data;
#endif
                    break;
                case FileType.MZXMLRAWDATA:
                    MZXmlRawData mzxml_raw_data;
                    mzxml_raw_data = new MZXmlRawData();
                    return mzxml_raw_data;
                    //break;
                case FileType.PNNL_IMS:
                    IMSRawData ims_raw_data;
                    ims_raw_data = new IMSRawData();
                    return ims_raw_data;
                    break;
                /*case FileType.PNNL_UIMF:
                    UIMFRawData uimf_raw_data;
                    uimf_raw_data = new UIMFRawData();
                    return uimf_raw_data;
                    break; */
                /*case FileType.YAFMS:
                    YafmsRawData yafms_raw_data;
                    yafms_raw_data = new YafmsRawData();
                    return yafms_raw_data;
                    break; */
                case FileType.BRUKER_ASCII:
                    BrukerAsciiRawData bruker_baf_raw_data;
                    bruker_baf_raw_data = new BrukerAsciiRawData();
                    return bruker_baf_raw_data;
                    break;
                case FileType.ASCII:
                    AsciiRawData ascii_raw_data;
                    ascii_raw_data = new AsciiRawData();
                    return ascii_raw_data;
                    break;
                default:
                    break;
            }
            return null;
        }
#endif
    }
}
