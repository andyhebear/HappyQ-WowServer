using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;
using Demo.Stock.X.Common;
using System.Threading;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Demo.Stock.X.U50.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class U50GlobalSetting
    {
        #region zh-CHS 共有静态属性 | en Public Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static string s_PolicyFilePath = "Demo.Stock.Config\\u50policy.config";
        #endregion
        public static string PolicyFilePath
        {
            get { return s_PolicyFilePath; }
            set { s_PolicyFilePath = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static bool s_IsAutoLoadPolicySetting = true;
        #endregion
        public static bool IsAutoLoadPolicySetting
        {
            get { return s_IsAutoLoadPolicySetting; }
            set { s_IsAutoLoadPolicySetting = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static string s_TaskFilePath = "Demo.Stock.Config\\u50task.config";
        #endregion
        public static string TaskFilePath
        {
            get { return s_TaskFilePath; }
            set { s_TaskFilePath = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static bool s_IsAutoLoadTaskSetting = true;
        #endregion
        public static bool IsAutoLoadTaskSetting
        {
            get { return s_IsAutoLoadTaskSetting; }
            set { s_IsAutoLoadTaskSetting = value; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static U50PolicyInfo[] s_PolicyInfos = new U50PolicyInfo[0];
        #endregion
        public static U50PolicyInfo[] PolicyInfos
        {
            get { return s_PolicyInfos; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static U50TaskInfo[] s_TaskInfos = new U50TaskInfo[0];
        #endregion
        public static U50TaskInfo[] TaskInfos
        {
            get { return s_TaskInfos; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static bool s_IsLoadPolicyGlobalSetting = false;
        #endregion
        public static bool IsLoadPolicyGlobalSetting
        {
            get { return s_IsLoadPolicyGlobalSetting; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        private static bool s_IsLoadTaskGlobalSetting = false;
        #endregion
        public static bool IsLoadTaskGlobalSetting
        {
            get { return s_IsLoadTaskGlobalSetting; }
        }

        #endregion

        public static void LoadGlobalRegistry()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.U50" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        public static void SaveGlobalRegistry()
        {
            RegistryKey rkey = Registry.CurrentUser;
            RegistryKey rkey1 = rkey.OpenSubKey( "Software", true );
            RegistryKey rkey2 = rkey1.CreateSubKey( "DemoSoft" );
            RegistryKey rkey3 = rkey2.CreateSubKey( "Demo.Stock.U50" );
            RegistryKey rkey4 = rkey3.CreateSubKey( "GlobalSetting" );

            rkey4.Close();
            rkey3.Close();
            rkey2.Close();
            rkey1.Close();
        }

        public static event EventHandler LoadingPolicySetting;
        public static event EventHandler LoadedPolicySetting;
        public static bool LoadPolicyGlobalSetting()
        {
            U50PolicyInfo[] policyInfos = LoadPolicySetting( U50GlobalSetting.PolicyFilePath );
            if ( policyInfos == null )
                return false;

            if ( LoadingPolicySetting != null )
                LoadingPolicySetting( null, EventArgs.Empty );

            U50GlobalSetting.s_PolicyInfos = policyInfos;

            PolicyManager.Instance.FromConfigPolicyInfo( U50GlobalSetting.s_PolicyInfos );

            s_IsLoadPolicyGlobalSetting = true;

            if ( LoadedPolicySetting != null )
                LoadedPolicySetting( null, EventArgs.Empty );

            return true;
        }

        public static U50PolicyInfo[] LoadPolicySetting( string strConfigFile )
        {
            if ( File.Exists( strConfigFile ) == false )
            {
                if ( U50GlobalSetting.PolicyFilePath == strConfigFile ) // 创建一个新的文件
                    SavePolicySetting( U50GlobalSetting.PolicyFilePath, U50GlobalSetting.PolicyInfos );
                else
                    return null;
            }

            XDocument documentConfig = XDocument.Load( strConfigFile );
            if ( documentConfig == null )
                return null;

            XElement elementRoot = documentConfig.Element( (XName)"Demo.Stock" );
            if ( elementRoot == null )
                return null;

            XAttribute attributeVer = elementRoot.Attribute( (XName)"Ver" );
            if ( attributeVer == null )
                return null;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            IEnumerable<XElement> elementU50Policys = elementRoot.Elements( (XName)"U50Policy" );
            if ( elementU50Policys == null )
                return null;

            List<U50PolicyInfo> policyInfoList = new List<U50PolicyInfo>();
            foreach ( var u50Policy in elementU50Policys )
            {
                XAttribute attributeName = u50Policy.Attribute( (XName)"Name" );
                if ( attributeName == null )
                    continue;

                XAttribute attributeGuid = u50Policy.Attribute( (XName)"Guid" );
                if ( attributeGuid == null )
                    continue;

                U50PolicyInfo policyInfo = new U50PolicyInfo { Name = attributeName.Value, Guid = attributeGuid.Value };

                // U50Policy -> Policy
                XElement elementPolicy = u50Policy.Element( (XName)"Policy" );
                if ( elementPolicy == null )
                    continue;

                // U50Policy -> Policy -> DateTime
                XElement elementDateTime = elementPolicy.Element( (XName)"DateTime" );
                if ( elementDateTime == null )
                    continue;
                {
                    XAttribute attributeIsDateNow = elementDateTime.Attribute( (XName)"IsDateNow" );
                    if ( attributeIsDateNow == null )
                        continue;
                    else
                        policyInfo.Policy.IsDateNow = bool.Parse( attributeIsDateNow.Value );

                    XAttribute attributeKN = elementDateTime.Attribute( (XName)"KN" );
                    if ( attributeKN == null )
                        continue;
                    else
                        policyInfo.Policy.KN = uint.Parse( attributeKN.Value );

                    XAttribute attributeDate = elementDateTime.Attribute( (XName)"Date" );
                    if ( attributeDate == null )
                        continue;
                    else
                        policyInfo.Policy.DateSelect = DateTime.Parse( attributeDate.Value );
                }

                // U50Policy -> Policy -> ExOption
                XElement elementExOption = elementPolicy.Element( (XName)"ExOption" );
                if ( elementExOption == null )
                    continue;
                {
                    XAttribute attributePriority = elementExOption.Attribute( (XName)"Priority" );
                    if ( attributePriority == null )
                        continue;
                    else
                        policyInfo.Policy.Priority = (U50PriorityType)int.Parse( attributePriority.Value );

                    XAttribute attributeOutput = elementExOption.Attribute( (XName)"Output" );
                    if ( attributeOutput == null )
                        continue;
                    else
                        policyInfo.Policy.Output = (U50OutputType)int.Parse( attributeOutput.Value );

                    // U50Policy -> Policy -> ExOption -> Date
                    XElement elementDate = elementExOption.Element( (XName)"Date" );
                    if ( elementDate == null )
                        continue;
                    {
                        XAttribute attributeDateAllow = elementDate.Attribute( (XName)"Allow" );
                        if ( attributeDateAllow == null )
                            continue;
                        else
                            policyInfo.Policy.IsAllowDate = bool.Parse( attributeDateAllow.Value );

                        XAttribute attributeDateStep = elementDate.Attribute( (XName)"Step" );
                        if ( attributeDateStep == null )
                            continue;
                        else
                            policyInfo.Policy.DateStep = uint.Parse( attributeDateStep.Value );

                        XAttribute attributeDateEnd = elementDate.Attribute( (XName)"End" );
                        if ( attributeDateEnd == null )
                            continue;
                        else
                            policyInfo.Policy.DateEnd = DateTime.Parse( attributeDateEnd.Value );
                    }

                    // U50Policy -> Policy -> ExOption -> KN
                    XElement elementKN = elementExOption.Element( (XName)"KN" );
                    if ( elementKN == null )
                        continue;
                    {
                        XAttribute attributeKNAllow = elementKN.Attribute( (XName)"Allow" );
                        if ( attributeKNAllow == null )
                            continue;
                        else
                            policyInfo.Policy.IsAllowKN = bool.Parse( attributeKNAllow.Value );

                        XAttribute attributeKNStep = elementKN.Attribute( (XName)"Step" );
                        if ( attributeKNStep == null )
                            continue;
                        else
                            policyInfo.Policy.KNStep = uint.Parse( attributeKNStep.Value );

                        XAttribute attributeKNEnd = elementKN.Attribute( (XName)"End" );
                        if ( attributeKNEnd == null )
                            continue;
                        else
                            policyInfo.Policy.KNEnd = uint.Parse( attributeKNEnd.Value );
                    }
                }

                // U50Policy -> Filtrate
                XElement elementFiltrate = u50Policy.Element( (XName)"Filtrate" );
                if ( elementFiltrate == null )
                    continue;
                {
                    // U50Policy -> Filtrate -> PDU
                    XElement elementPDU = elementFiltrate.Element( (XName)"PDU" );
                    if ( elementPDU == null )
                        continue;
                    {
                        XAttribute attributePDUEnabled = elementPDU.Attribute( (XName)"Enabled" );
                        if ( attributePDUEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Enabled = bool.Parse( attributePDUEnabled.Value );

                        XAttribute attributePDUSelect = elementPDU.Attribute( (XName)"Select" );
                        if ( attributePDUSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Select = (U50SelectType)int.Parse( attributePDUSelect.Value );

                        XAttribute attributePDUBig = elementPDU.Attribute( (XName)"Big" );
                        if ( attributePDUBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Big = float.Parse( attributePDUBig.Value );

                        XAttribute attributePDUBig2 = elementPDU.Attribute( (XName)"Big2" );
                        if ( attributePDUBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Big2 = float.Parse( attributePDUBig2.Value );

                        XAttribute attributePDUSmall = elementPDU.Attribute( (XName)"Small" );
                        if ( attributePDUSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Small = float.Parse( attributePDUSmall.Value );

                        XAttribute attributePDUSmall2 = elementPDU.Attribute( (XName)"Small2" );
                        if ( attributePDUSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.PDU.Small2 = float.Parse( attributePDUSmall2.Value );
                    }

                    // U50Policy -> Filtrate -> PCU
                    XElement elementPCU = elementFiltrate.Element( (XName)"PCU" );
                    if ( elementPCU == null )
                        continue;
                    {
                        XAttribute attributePCUEnabled = elementPCU.Attribute( (XName)"Enabled" );
                        if ( attributePCUEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Enabled = bool.Parse( attributePCUEnabled.Value );

                        XAttribute attributePCUSelect = elementPCU.Attribute( (XName)"Select" );
                        if ( attributePCUSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Select = (U50SelectType)int.Parse( attributePCUSelect.Value );

                        XAttribute attributePCUBig = elementPCU.Attribute( (XName)"Big" );
                        if ( attributePCUBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Big = float.Parse( attributePCUBig.Value );

                        XAttribute attributePCUBig2 = elementPCU.Attribute( (XName)"Big2" );
                        if ( attributePCUBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Big2 = float.Parse( attributePCUBig2.Value );

                        XAttribute attributePCUSmall = elementPCU.Attribute( (XName)"Small" );
                        if ( attributePCUSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Small = float.Parse( attributePCUSmall.Value );

                        XAttribute attributePCUSmall2 = elementPCU.Attribute( (XName)"Small2" );
                        if ( attributePCUSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.PCU.Small2 = float.Parse( attributePCUSmall2.Value );
                    }

                    // U50Policy -> Filtrate -> TDU
                    XElement elementTDU = elementFiltrate.Element( (XName)"TDU" );
                    if ( elementTDU == null )
                        continue;
                    {
                        XAttribute attributeTDUEnabled = elementTDU.Attribute( (XName)"Enabled" );
                        if ( attributeTDUEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Enabled = bool.Parse( attributeTDUEnabled.Value );

                        XAttribute attributeTDUSelect = elementTDU.Attribute( (XName)"Select" );
                        if ( attributeTDUSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Select = (U50SelectType)int.Parse( attributeTDUSelect.Value );

                        XAttribute attributeTDUBig = elementTDU.Attribute( (XName)"Big" );
                        if ( attributeTDUBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Big = float.Parse( attributeTDUBig.Value );

                        XAttribute attributeTDUBig2 = elementTDU.Attribute( (XName)"Big2" );
                        if ( attributeTDUBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Big2 = float.Parse( attributeTDUBig2.Value );

                        XAttribute attributeTDUSmall = elementTDU.Attribute( (XName)"Small" );
                        if ( attributeTDUSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Small = float.Parse( attributeTDUSmall.Value );

                        XAttribute attributeTDUSmall2 = elementTDU.Attribute( (XName)"Small2" );
                        if ( attributeTDUSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TDU.Small2 = float.Parse( attributeTDUSmall2.Value );
                    }

                    // U50Policy -> Filtrate -> TCD
                    XElement elementTCD = elementFiltrate.Element( (XName)"TCD" );
                    if ( elementTCD == null )
                        continue;
                    {
                        XAttribute attributeTCDEnabled = elementTCD.Attribute( (XName)"Enabled" );
                        if ( attributeTCDEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Enabled = bool.Parse( attributeTCDEnabled.Value );

                        XAttribute attributeTCDSelect = elementTCD.Attribute( (XName)"Select" );
                        if ( attributeTCDSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Select = (U50SelectType)int.Parse( attributeTCDSelect.Value );

                        XAttribute attributeTCDBig = elementTCD.Attribute( (XName)"Big" );
                        if ( attributeTCDBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Big = float.Parse( attributeTCDBig.Value );

                        XAttribute attributeTCDBig2 = elementTCD.Attribute( (XName)"Big2" );
                        if ( attributeTCDBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Big2 = float.Parse( attributeTCDBig2.Value );

                        XAttribute attributeTCDSmall = elementTCD.Attribute( (XName)"Small" );
                        if ( attributeTCDSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Small = float.Parse( attributeTCDSmall.Value );

                        XAttribute attributeTCDSmall2 = elementTCD.Attribute( (XName)"Small2" );
                        if ( attributeTCDSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TCD.Small2 = float.Parse( attributeTCDSmall2.Value );
                    }

                    // U50Policy -> Filtrate -> TBU
                    XElement elementTBU = elementFiltrate.Element( (XName)"TBU" );
                    if ( elementTBU == null )
                        continue;
                    {
                        XAttribute attributeTCUEnabled = elementTBU.Attribute( (XName)"Enabled" );
                        if ( attributeTCUEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Enabled = bool.Parse( attributeTCUEnabled.Value );

                        XAttribute attributeTCUSelect = elementTBU.Attribute( (XName)"Select" );
                        if ( attributeTCUSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Select = (U50SelectType)int.Parse( attributeTCUSelect.Value );

                        XAttribute attributeTCUBig = elementTBU.Attribute( (XName)"Big" );
                        if ( attributeTCUBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Big = float.Parse( attributeTCUBig.Value );

                        XAttribute attributeTCUBig2 = elementTBU.Attribute( (XName)"Big2" );
                        if ( attributeTCUBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Big2 = float.Parse( attributeTCUBig2.Value );

                        XAttribute attributeTCUSmall = elementTBU.Attribute( (XName)"Small" );
                        if ( attributeTCUSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Small = float.Parse( attributeTCUSmall.Value );

                        XAttribute attributeTCUSmall2 = elementTBU.Attribute( (XName)"Small2" );
                        if ( attributeTCUSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.TBU.Small2 = float.Parse( attributeTCUSmall2.Value );
                    }

                    // U50Policy -> Filtrate -> Vac-UC
                    XElement elementVacUC = elementFiltrate.Element( (XName)"Vac-UC" );
                    if ( elementVacUC == null )
                        continue;
                    {
                        XAttribute attributeVacUCEnabled = elementVacUC.Attribute( (XName)"Enabled" );
                        if ( attributeVacUCEnabled == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Enabled = bool.Parse( attributeVacUCEnabled.Value );

                        XAttribute attributeVacUCSelect = elementVacUC.Attribute( (XName)"Select" );
                        if ( attributeVacUCSelect == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Select = (U50SelectType)int.Parse( attributeVacUCSelect.Value );

                        XAttribute attributeVacUCBig = elementVacUC.Attribute( (XName)"Big" );
                        if ( attributeVacUCBig == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Big = float.Parse( attributeVacUCBig.Value );

                        XAttribute attributeVacUCBig2 = elementVacUC.Attribute( (XName)"Big2" );
                        if ( attributeVacUCBig2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Big2 = float.Parse( attributeVacUCBig2.Value );

                        XAttribute attributeVacUCSmall = elementVacUC.Attribute( (XName)"Small" );
                        if ( attributeVacUCSmall == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Small = float.Parse( attributeVacUCSmall.Value );

                        XAttribute attributeVacUCSmall2 = elementVacUC.Attribute( (XName)"Small2" );
                        if ( attributeVacUCSmall2 == null )
                            continue;
                        else
                            policyInfo.Filtrate.VacUC.Small2 = float.Parse( attributeVacUCSmall2.Value );
                    }
                }

                // U50Policy -> Extend
                XElement elementExtend = u50Policy.Element( (XName)"Extend" );
                if ( elementExtend == null )
                    continue;
                {
                    // U50Policy -> Extend -> Info01
                    XElement elementInfo01 = elementExtend.Element( (XName)"Info01" );
                    if ( elementInfo01 == null )
                        continue;
                    {
                        XAttribute attributeInfo01Enabled = elementInfo01.Attribute( (XName)"Enabled" );
                        if ( attributeInfo01Enabled == null )
                            continue;
                        else
                            policyInfo.Extend.Info01.Enabled = bool.Parse( attributeInfo01Enabled.Value );

                        XAttribute attributeInfo01Select = elementInfo01.Attribute( (XName)"Select" );
                        if ( attributeInfo01Select == null )
                            continue;
                        else
                            policyInfo.Extend.Info01.Select = (U50ExtendInfo01Type)int.Parse( attributeInfo01Select.Value );

                        XAttribute attributeInfo01Big = elementInfo01.Attribute( (XName)"HighNumber" );
                        if ( attributeInfo01Big == null )
                            continue;
                        else
                            policyInfo.Extend.Info01.HighNumber = int.Parse( attributeInfo01Big.Value );
                    }

                    // U50Policy -> Extend -> Info02
                    XElement elementInfo02 = elementExtend.Element( (XName)"Info02" );
                    if ( elementInfo02 == null )
                        continue;
                    {
                        XAttribute attributeInfo02Enabled = elementInfo02.Attribute( (XName)"Enabled" );
                        if ( attributeInfo02Enabled == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Enabled = bool.Parse( attributeInfo02Enabled.Value );

                        XAttribute attributeInfo02Select = elementInfo02.Attribute( (XName)"Select" );
                        if ( attributeInfo02Select == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Select = (U50SelectType)int.Parse( attributeInfo02Select.Value );

                        XAttribute attributeInfo02Big = elementInfo02.Attribute( (XName)"Big" );
                        if ( attributeInfo02Big == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Big = long.Parse( attributeInfo02Big.Value );

                        XAttribute attributeInfo02Big2 = elementInfo02.Attribute( (XName)"Big2" );
                        if ( attributeInfo02Big2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Big2 = long.Parse( attributeInfo02Big2.Value );

                        XAttribute attributeInfo02Small = elementInfo02.Attribute( (XName)"Small" );
                        if ( attributeInfo02Small == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Small = long.Parse( attributeInfo02Small.Value );

                        XAttribute attributeInfo02Small2 = elementInfo02.Attribute( (XName)"Small2" );
                        if ( attributeInfo02Small2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info02.Small2 = long.Parse( attributeInfo02Small2.Value );
                    }

                    // U50Policy -> Extend -> Info03
                    XElement elementInfo03 = elementExtend.Element( (XName)"Info03" );
                    if ( elementInfo03 == null )
                        continue;
                    {
                        XAttribute attributeInfo03Enabled = elementInfo03.Attribute( (XName)"Enabled" );
                        if ( attributeInfo03Enabled == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Enabled = bool.Parse( attributeInfo03Enabled.Value );

                        XAttribute attributeInfo03Select = elementInfo03.Attribute( (XName)"Select" );
                        if ( attributeInfo03Select == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Select = (U50SelectType)int.Parse( attributeInfo03Select.Value );

                        XAttribute attributeInfo03Big = elementInfo03.Attribute( (XName)"Big" );
                        if ( attributeInfo03Big == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Big = int.Parse( attributeInfo03Big.Value );

                        XAttribute attributeInfo03Big2 = elementInfo03.Attribute( (XName)"Big2" );
                        if ( attributeInfo03Big2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Big2 = int.Parse( attributeInfo03Big2.Value );

                        XAttribute attributeInfo03Small = elementInfo03.Attribute( (XName)"Small" );
                        if ( attributeInfo03Small == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Small = int.Parse( attributeInfo03Small.Value );

                        XAttribute attributeInfo03Small2 = elementInfo03.Attribute( (XName)"Small2" );
                        if ( attributeInfo03Small2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info03.Small2 = int.Parse( attributeInfo03Small2.Value );
                    }

                    // U50Policy -> Extend -> Info04
                    XElement elementInfo04 = elementExtend.Element( (XName)"Info04" );
                    if ( elementInfo04 == null )
                        continue;
                    {
                        XAttribute attributeInfo04Enabled = elementInfo04.Attribute( (XName)"Enabled" );
                        if ( attributeInfo04Enabled == null )
                            continue;
                        else
                            policyInfo.Extend.Info04.Enabled = bool.Parse( attributeInfo04Enabled.Value );

                        XAttribute attributeInfo04Select = elementInfo04.Attribute( (XName)"Select" );
                        if ( attributeInfo04Select == null )
                            continue;
                        else
                            policyInfo.Extend.Info04.Select = (U50ExtendInfo04Type)int.Parse( attributeInfo04Select.Value );
                    }

                    // U50Policy -> Extend -> Info05
                    XElement elementInfo05 = elementExtend.Element( (XName)"Info05" );
                    if ( elementInfo05 == null )
                        continue;
                    {
                        XAttribute attributeInfo05Enabled = elementInfo05.Attribute( (XName)"Enabled" );
                        if ( attributeInfo05Enabled == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Enabled = bool.Parse( attributeInfo05Enabled.Value );

                        XAttribute attributeInfo05Select = elementInfo05.Attribute( (XName)"Select" );
                        if ( attributeInfo05Select == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Select = (U50SelectType)int.Parse( attributeInfo05Select.Value );

                        XAttribute attributeInfo05Big = elementInfo05.Attribute( (XName)"Big" );
                        if ( attributeInfo05Big == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Big = int.Parse( attributeInfo05Big.Value );

                        XAttribute attributeInfo05Big2 = elementInfo05.Attribute( (XName)"Big2" );
                        if ( attributeInfo05Big2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Big2 = int.Parse( attributeInfo05Big2.Value );

                        XAttribute attributeInfo05Small = elementInfo05.Attribute( (XName)"Small" );
                        if ( attributeInfo05Small == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Small = int.Parse( attributeInfo05Small.Value );

                        XAttribute attributeInfo05Small2 = elementInfo05.Attribute( (XName)"Small2" );
                        if ( attributeInfo05Small2 == null )
                            continue;
                        else
                            policyInfo.Extend.Info05.Small2 = int.Parse( attributeInfo05Small2.Value );
                    }
                }

                policyInfoList.Add( policyInfo );
            }

            return policyInfoList.ToArray();
        }

        public static void SavePolicySetting( string strConfigFile, U50PolicyInfo[] policyInfos )
        {
            if ( policyInfos == null )
                return;

            if ( File.Exists( strConfigFile ) == true )
                File.Delete( strConfigFile );

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < policyInfos.Length; iIndex++ )
            {
                U50PolicyInfo policyInfo = policyInfos[iIndex];

                XElement elementU50Policy = new XElement( "U50Policy", new XAttribute( "Name", policyInfo.Name ) );
                elementU50Policy.Add( new XAttribute( "Guid", policyInfo.Guid ) );
                {
                    XElement elementPolicy = new XElement( "Policy" );
                    {
                        XElement elementDateTime = new XElement( "DateTime" );
                        {
                            elementDateTime.Add( new XAttribute( "IsDateNow", policyInfo.Policy.IsDateNow ) );
                            elementDateTime.Add( new XAttribute( "KN", policyInfo.Policy.KN ) );
                            elementDateTime.Add( new XAttribute( "Date", policyInfo.Policy.DateSelect.ToShortDateString() ) );
                        }
                        elementPolicy.Add( elementDateTime );

                        XElement elementExOption = new XElement( "ExOption" );
                        {
                            elementExOption.Add( new XAttribute( "Priority", ( (int)policyInfo.Policy.Priority ).ToString() ) );
                            elementExOption.Add( new XAttribute( "Output", ( (int)policyInfo.Policy.Output ).ToString() ) );

                            XElement elementDate = new XElement( "Date" );
                            {
                                elementDate.Add( new XAttribute( "Allow", policyInfo.Policy.IsAllowDate.ToString() ) );
                                elementDate.Add( new XAttribute( "Step", policyInfo.Policy.DateStep.ToString() ) );
                                elementDate.Add( new XAttribute( "End", policyInfo.Policy.DateEnd.ToString() ) );
                            }
                            elementExOption.Add( elementDate );

                            XElement elementKN = new XElement( "KN" );
                            {
                                elementKN.Add( new XAttribute( "Allow", policyInfo.Policy.IsAllowKN.ToString() ) );
                                elementKN.Add( new XAttribute( "Step", policyInfo.Policy.KNStep.ToString() ) );
                                elementKN.Add( new XAttribute( "End", policyInfo.Policy.KNEnd.ToString() ) );
                            }
                            elementExOption.Add( elementKN );
                        }
                        elementPolicy.Add( elementExOption );
                    }
                    elementU50Policy.Add( elementPolicy );

                    XElement elementFiltrate = new XElement( "Filtrate" );
                    {
                        XElement elementPDU = new XElement( "PDU" );
                        {
                            elementPDU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.PDU.Enabled.ToString() ) );
                            elementPDU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.PDU.Select ).ToString() ) );
                            elementPDU.Add( new XAttribute( "Big", policyInfo.Filtrate.PDU.Big.ToString() ) );
                            elementPDU.Add( new XAttribute( "Big2", policyInfo.Filtrate.PDU.Big2.ToString() ) );
                            elementPDU.Add( new XAttribute( "Small", policyInfo.Filtrate.PDU.Small.ToString() ) );
                            elementPDU.Add( new XAttribute( "Small2", policyInfo.Filtrate.PDU.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementPDU );

                        XElement elementPCU = new XElement( "PCU" );
                        {
                            elementPCU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.PCU.Enabled.ToString() ) );
                            elementPCU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.PCU.Select ).ToString() ) );
                            elementPCU.Add( new XAttribute( "Big", policyInfo.Filtrate.PCU.Big.ToString() ) );
                            elementPCU.Add( new XAttribute( "Big2", policyInfo.Filtrate.PCU.Big2.ToString() ) );
                            elementPCU.Add( new XAttribute( "Small", policyInfo.Filtrate.PCU.Small.ToString() ) );
                            elementPCU.Add( new XAttribute( "Small2", policyInfo.Filtrate.PCU.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementPCU );

                        XElement elementTDU = new XElement( "TDU" );
                        {
                            elementTDU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TDU.Enabled.ToString() ) );
                            elementTDU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TDU.Select ).ToString() ) );
                            elementTDU.Add( new XAttribute( "Big", policyInfo.Filtrate.TDU.Big.ToString() ) );
                            elementTDU.Add( new XAttribute( "Big2", policyInfo.Filtrate.TDU.Big2.ToString() ) );
                            elementTDU.Add( new XAttribute( "Small", policyInfo.Filtrate.TDU.Small.ToString() ) );
                            elementTDU.Add( new XAttribute( "Small2", policyInfo.Filtrate.TDU.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementTDU );

                        XElement elementTCD = new XElement( "TCD" );
                        {
                            elementTCD.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TCD.Enabled.ToString() ) );
                            elementTCD.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TCD.Select ).ToString() ) );
                            elementTCD.Add( new XAttribute( "Big", policyInfo.Filtrate.TCD.Big.ToString() ) );
                            elementTCD.Add( new XAttribute( "Big2", policyInfo.Filtrate.TCD.Big2.ToString() ) );
                            elementTCD.Add( new XAttribute( "Small", policyInfo.Filtrate.TCD.Small.ToString() ) );
                            elementTCD.Add( new XAttribute( "Small2", policyInfo.Filtrate.TCD.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementTCD );

                        XElement elementTBU = new XElement( "TBU" );
                        {
                            elementTBU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TBU.Enabled.ToString() ) );
                            elementTBU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TBU.Select ).ToString() ) );
                            elementTBU.Add( new XAttribute( "Big", policyInfo.Filtrate.TBU.Big.ToString() ) );
                            elementTBU.Add( new XAttribute( "Big2", policyInfo.Filtrate.TBU.Big2.ToString() ) );
                            elementTBU.Add( new XAttribute( "Small", policyInfo.Filtrate.TBU.Small.ToString() ) );
                            elementTBU.Add( new XAttribute( "Small2", policyInfo.Filtrate.TBU.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementTBU );

                        XElement elementVacUC = new XElement( "Vac-UC" );
                        {
                            elementVacUC.Add( new XAttribute( "Enabled", policyInfo.Filtrate.VacUC.Enabled.ToString() ) );
                            elementVacUC.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.VacUC.Select ).ToString() ) );
                            elementVacUC.Add( new XAttribute( "Big", policyInfo.Filtrate.VacUC.Big.ToString() ) );
                            elementVacUC.Add( new XAttribute( "Big2", policyInfo.Filtrate.VacUC.Big2.ToString() ) );
                            elementVacUC.Add( new XAttribute( "Small", policyInfo.Filtrate.VacUC.Small.ToString() ) );
                            elementVacUC.Add( new XAttribute( "Small2", policyInfo.Filtrate.VacUC.Small2.ToString() ) );
                        }
                        elementFiltrate.Add( elementVacUC );
                    }
                    elementU50Policy.Add( elementFiltrate );

                    XElement elementExtend = new XElement( "Extend" );
                    {
                        XElement elementInfo01 = new XElement( "Info01" );
                        {
                            elementInfo01.Add( new XAttribute( "Enabled", policyInfo.Extend.Info01.Enabled.ToString() ) );
                            elementInfo01.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info01.Select ).ToString() ) );
                            elementInfo01.Add( new XAttribute( "HighNumber", policyInfo.Extend.Info01.HighNumber.ToString() ) );
                        }
                        elementExtend.Add( elementInfo01 );

                        XElement elementInfo02 = new XElement( "Info02" );
                        {
                            elementInfo02.Add( new XAttribute( "Enabled", policyInfo.Extend.Info02.Enabled.ToString() ) );
                            elementInfo02.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info02.Select ).ToString() ) );
                            elementInfo02.Add( new XAttribute( "Big", policyInfo.Extend.Info02.Big.ToString() ) );
                            elementInfo02.Add( new XAttribute( "Big2", policyInfo.Extend.Info02.Big2.ToString() ) );
                            elementInfo02.Add( new XAttribute( "Small", policyInfo.Extend.Info02.Small.ToString() ) );
                            elementInfo02.Add( new XAttribute( "Small2", policyInfo.Extend.Info02.Small2.ToString() ) );
                        }
                        elementExtend.Add( elementInfo02 );

                        XElement elementInfo03 = new XElement( "Info03" );
                        {
                            elementInfo03.Add( new XAttribute( "Enabled", policyInfo.Extend.Info03.Enabled.ToString() ) );
                            elementInfo03.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info03.Select ).ToString() ) );
                            elementInfo03.Add( new XAttribute( "Big", policyInfo.Extend.Info03.Big.ToString() ) );
                            elementInfo03.Add( new XAttribute( "Big2", policyInfo.Extend.Info03.Big2.ToString() ) );
                            elementInfo03.Add( new XAttribute( "Small", policyInfo.Extend.Info03.Small.ToString() ) );
                            elementInfo03.Add( new XAttribute( "Small2", policyInfo.Extend.Info03.Small2.ToString() ) );
                        }
                        elementExtend.Add( elementInfo03 );

                        XElement elementInfo04 = new XElement( "Info04" );
                        {
                            elementInfo04.Add( new XAttribute( "Enabled", policyInfo.Extend.Info04.Enabled.ToString() ) );
                            elementInfo04.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info04.Select ).ToString() ) );
                        }
                        elementExtend.Add( elementInfo04 );

                        XElement elementInfo05 = new XElement( "Info05" );
                        {
                            elementInfo05.Add( new XAttribute( "Enabled", policyInfo.Extend.Info05.Enabled.ToString() ) );
                            elementInfo05.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info05.Select ).ToString() ) );
                            elementInfo05.Add( new XAttribute( "Big", policyInfo.Extend.Info05.Big.ToString() ) );
                            elementInfo05.Add( new XAttribute( "Big2", policyInfo.Extend.Info05.Big2.ToString() ) );
                            elementInfo05.Add( new XAttribute( "Small", policyInfo.Extend.Info05.Small.ToString() ) );
                            elementInfo05.Add( new XAttribute( "Small2", policyInfo.Extend.Info05.Small2.ToString() ) );
                        }
                        elementExtend.Add( elementInfo05 );
                    }
                    elementU50Policy.Add( elementExtend );
                }
                elementRoot.Add( elementU50Policy );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strConfigFile );
        }



        public static event EventHandler LoadingTaskSetting;
        public static event EventHandler LoadedTaskSetting;
        public static bool LoadTaskGlobalSetting()
        {
            U50TaskInfo[] taskInfos = LoadTaskSetting( U50GlobalSetting.TaskFilePath );
            if ( taskInfos == null )
                return false;

            if ( LoadingTaskSetting != null )
                LoadingTaskSetting( null, EventArgs.Empty );

            U50GlobalSetting.s_TaskInfos = taskInfos;

            TaskManager.Instance.FromConfigTaskInfo( U50GlobalSetting.s_TaskInfos );

            s_IsLoadTaskGlobalSetting = true;

            if ( LoadedTaskSetting != null )
                LoadedTaskSetting( null, EventArgs.Empty );

            return true;
        }

        public static U50TaskInfo[] LoadTaskSetting( string strTaskFile )
        {
            if ( File.Exists( strTaskFile ) == false )
            {
                if ( U50GlobalSetting.TaskFilePath == strTaskFile )
                    SaveTaskSetting( U50GlobalSetting.TaskFilePath, U50GlobalSetting.TaskInfos );
                else
                    return null;
            }

            XDocument documentConfig = XDocument.Load( strTaskFile );
            if ( documentConfig == null )
                return null;

            XElement elementRoot = documentConfig.Element( (XName)"Demo.Stock" );
            if ( elementRoot == null )
                return null;

            XAttribute attributeVer = elementRoot.Attribute( (XName)"Ver" );
            if ( attributeVer == null )
                return null;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            IEnumerable<XElement> elementU50Tasks = elementRoot.Elements( (XName)"U50Task" );
            if ( elementU50Tasks == null )
                return null;

            List<U50TaskInfo> policyInfoList = new List<U50TaskInfo>();
            foreach ( var elementU50Task in elementU50Tasks )
            {
                XAttribute attributeName = elementU50Task.Attribute( (XName)"Name" );
                if ( attributeName == null )
                    continue;

                XAttribute attributeGuid = elementU50Task.Attribute( (XName)"Guid" );
                if ( attributeGuid == null )
                    continue;

                U50TaskInfo taskInfo = new U50TaskInfo();
                taskInfo.Name = attributeName.Value;
                taskInfo.Guid = attributeGuid.Value;

                // U50Task -> General
                XElement elementGeneral = elementU50Task.Element( (XName)"General" );
                if ( elementGeneral == null )
                    continue;
                {
                    XAttribute attributeAutoScan = elementGeneral.Attribute( (XName)"SaneType" );
                    if ( attributeAutoScan == null )
                        continue;
                    else
                        taskInfo.General.SaneType = (U50TaskSaneType)int.Parse( attributeAutoScan.Value );
                }

                // U50Task -> Request
                XElement elementRequest = elementU50Task.Element( (XName)"Request" );
                if ( elementRequest == null )
                    continue;
                {
                    XAttribute attributeSelectType = elementRequest.Attribute( (XName)"SelectType" );
                    if ( attributeSelectType == null )
                        continue;
                    else
                        taskInfo.Request.Select = (U50TaskSelectType)int.Parse( attributeSelectType.Value );

                    XAttribute attributePlate = elementRequest.Attribute( (XName)"Plate" );
                    if ( attributePlate == null )
                        continue;
                    else
                        taskInfo.Request.Plate = attributePlate.Value;

                    XAttribute attributeVariety = elementRequest.Attribute( (XName)"Variety" );
                    if ( attributeVariety == null )
                        continue;
                    else
                        taskInfo.Request.Variety = attributeVariety.Value;

                    // U50Task -> Request -> StockInfo
                    IEnumerable<XElement> elementStockInfo = elementRequest.Elements( (XName)"StockInfo" );
                    if ( elementStockInfo != null )
                    {
                        List<U50StockInfo> stockInfoList = new List<U50StockInfo>();

                        foreach ( var item in elementStockInfo )
                        {
                            U50StockInfo stockInfo = new U50StockInfo();

                            XAttribute attributePlateSub = item.Attribute( (XName)"Plate" );
                            if ( attributePlateSub == null )
                                continue;
                            else
                                stockInfo.Plate = attributePlateSub.Value;

                            XAttribute attributeVarietySub = item.Attribute( (XName)"Variety" );
                            if ( attributeVarietySub == null )
                                continue;
                            else
                                stockInfo.Variety = attributeVarietySub.Value;

                            XAttribute attributeNameSub = item.Attribute( (XName)"Name" );
                            if ( attributeNameSub == null )
                                continue;
                            else
                                stockInfo.Name = attributeNameSub.Value;

                            XAttribute attributeSymbolSub = item.Attribute( (XName)"Symbol" );
                            if ( attributeSymbolSub == null )
                                continue;
                            else
                                stockInfo.Symbol = attributeSymbolSub.Value;

                            stockInfoList.Add( stockInfo );
                        }

                        taskInfo.Request.StockInfo = stockInfoList.ToArray();
                    }
                }

                // U50Task -> Policy
                XElement elementPolicy = elementU50Task.Element( (XName)"Policy" );
                if ( elementPolicy == null )
                    continue;
                {
                    XAttribute attributeScanType = elementPolicy.Attribute( (XName)"ScanType" );
                    if ( attributeScanType == null )
                        continue;
                    else
                        taskInfo.Policy.ScanType = (U50ScanType)int.Parse( attributeScanType.Value );

                    // U50Task -> Policy -> PolicyGuid
                    IEnumerable<XElement> elementPolicyGuid = elementPolicy.Elements( (XName)"PolicyGuid" );
                    if ( elementRequest != null )
                    {
                        List<string> stockPolicyList = new List<string>();

                        foreach ( var item in elementPolicyGuid )
                        {
                            XAttribute attributeNameSub = item.Attribute( (XName)"Guid" );
                            if ( attributeNameSub == null )
                                continue;
                            else
                                stockPolicyList.Add( attributeNameSub.Value );
                        }

                        taskInfo.Policy.PolicyGuid = stockPolicyList.ToArray();
                    }
                }

                // U50Task -> Result
                XElement elementResult = elementU50Task.Element( (XName)"Result" );
                if ( elementResult == null )
                    continue;
                {
                    // U50Task -> Request -> LastReportGuid
                    XAttribute attributeLastReportGuid = elementResult.Attribute( (XName)"LastReportGuid" );
                    if ( attributeLastReportGuid == null )
                        continue;
                    else
                        taskInfo.Result.LastReportGuid = attributeLastReportGuid.Value;
                }

                policyInfoList.Add( taskInfo );
            }

            return policyInfoList.ToArray();
        }

        public static void SaveTaskSetting( string strTaskFile, U50TaskInfo[] taskInfos )
        {
            if ( taskInfos == null )
                return;

            if ( File.Exists( strTaskFile ) == true )
                File.Delete( strTaskFile );

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < taskInfos.Length; iIndex++ )
            {
                U50TaskInfo taskInfo = taskInfos[iIndex];

                XElement elementU50Task = new XElement( "U50Task", new XAttribute( "Name", taskInfo.Name ) );
                elementU50Task.Add( new XAttribute( "Guid", taskInfo.Guid ) );
                {
                    XElement elementGeneral = new XElement( "General" );
                    {
                        elementGeneral.Add( new XAttribute( "SaneType", ( (int)taskInfo.General.SaneType ).ToString() ) );
                    }
                    elementU50Task.Add( elementGeneral );

                    XElement elementRequest = new XElement( "Request" );
                    {
                        elementRequest.Add( new XAttribute( "SelectType", ( (int)taskInfo.Request.Select ).ToString() ) );
                        elementRequest.Add( new XAttribute( "Plate", taskInfo.Request.Plate ) );
                        elementRequest.Add( new XAttribute( "Variety", taskInfo.Request.Variety ) );

                        for ( int iIndex2 = 0; iIndex2 < taskInfo.Request.StockInfo.Length; iIndex2++ )
                        {
                            U50StockInfo stockInfo = taskInfo.Request.StockInfo[iIndex2];

                            XElement elementStockInfo = new XElement( "StockInfo" );
                            {
                                elementStockInfo.Add( new XAttribute( "Plate", stockInfo.Plate ) );
                                elementStockInfo.Add( new XAttribute( "Variety", stockInfo.Variety ) );
                                elementStockInfo.Add( new XAttribute( "Name", stockInfo.Name ) );
                                elementStockInfo.Add( new XAttribute( "Symbol", stockInfo.Symbol ) );
                            }
                            elementRequest.Add( elementStockInfo );
                        }
                    }
                    elementU50Task.Add( elementRequest );

                    XElement elementPolicy = new XElement( "Policy" );
                    {
                        elementPolicy.Add( new XAttribute( "ScanType", ( (int)taskInfo.Policy.ScanType ).ToString() ) );

                        for ( int iIndex2 = 0; iIndex2 < taskInfo.Policy.PolicyGuid.Length; iIndex2++ )
                        {
                            string strPolicyGuid = taskInfo.Policy.PolicyGuid[iIndex2];

                            XElement elementPolicyGuid = new XElement( "PolicyGuid" );
                            {
                                elementPolicyGuid.Add( new XAttribute( "Guid", strPolicyGuid ) );
                            }
                            elementPolicy.Add( elementPolicyGuid );
                        }
                    }
                    elementU50Task.Add( elementPolicy );

                    XElement elementResult = new XElement( "Result" );
                    {
                        elementResult.Add( new XAttribute( "LastReportGuid", taskInfo.Result.LastReportGuid ) );
                    }
                    elementU50Task.Add( elementResult );
                }
                elementRoot.Add( elementU50Task );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strTaskFile );
        }


        private static void First_Thread( object state )
        {
            ThreadReportInfo taskInfo = state as ThreadReportInfo;
            if ( taskInfo == null )
                return;

            if ( taskInfo.TaskInfo == null )
                return;

            if ( taskInfo.ScanNowReport == null )
                return;

            U50ReportInfo reportInfo = ScanTask( taskInfo.TaskInfo );
            taskInfo.ScanNowReport.ReportInfo = reportInfo;

            taskInfo.ScanNowReport.IsOK = true;
        }

        public class ThreadReportInfo
        {
            public U50TaskInfo TaskInfo = null;
            public U50Form.ScanNowReport ScanNowReport = null;
        }

        public static void ScanTaskThread( U50TaskInfo taskInfo )
        {
            ThreadReportInfo threadReportInfo = new ThreadReportInfo();
            threadReportInfo.TaskInfo = taskInfo;
            threadReportInfo.ScanNowReport = new U50Form.ScanNowReport();
            threadReportInfo.ScanNowReport.Name = taskInfo.Name;

            MainForm.Instance.U50Form.AddToList( threadReportInfo.ScanNowReport );

            ThreadPool.QueueUserWorkItem( new WaitCallback( First_Thread ), threadReportInfo );
        }

        public static U50ReportInfo ScanTask( U50TaskInfo taskInfo )
        {
            U50ReportInfo reportInfo = new U50ReportInfo();
            reportInfo.Guid = Guid.NewGuid().ToString();
            reportInfo.ScanTime = DateTime.Now;
            reportInfo.StaticTaskInfo = taskInfo;

            List<U50PolicyInfo> policyInfoList = new List<U50PolicyInfo>();
            foreach ( var policyGuid in taskInfo.Policy.PolicyGuid )
            {
                U50PolicyInfo policyInfo = PolicyManager.Instance.GetPolicyInfoByGuid( policyGuid );
                if ( policyInfo == null )
                    continue;
                else
                    policyInfoList.Add( policyInfo );
            }
            reportInfo.StaticReportInfo = policyInfoList.ToArray();

            //MessageBox.Show("reportInfo.StaticReportInf = " + policyInfoList.Count.ToString() );

            List<Demo.Stock.X.Common.StockInfo> stockInfoList = new List<Demo.Stock.X.Common.StockInfo>();
            foreach ( var stockInfo in taskInfo.Request.StockInfo )
            {
                StockManager stockManager = GlobalStockManager.GetStockManagerByPlateAndVariety(stockInfo.Plate, stockInfo.Variety);
                if ( stockManager == null )
                    continue;

                Demo.Stock.X.Common.StockInfo stockInfox = stockManager.GetStockDataByStockCode( GlobalSetting.GetStockCode( stockInfo.Name, stockInfo.Symbol ) );
                if ( stockInfox == null )
                    continue;
                else
                    stockInfoList.Add( stockInfox );
            }

            //MessageBox.Show("stockInfoList = " + stockInfoList.Count.ToString() );

            List<U50Report> reportList = new List<U50Report>();
            foreach ( var stockInfoxx in stockInfoList )
            {
                foreach ( var policyInfoxx in policyInfoList )
                {

                    if ( policyInfoxx.Policy.Priority == U50PriorityType.BaseDate )
                    {
                        if ( policyInfoxx.Policy.IsAllowDate )
                        {

                            //MessageBox.Show( "policyInfoxx.Policy.IsAllowDate" );

                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( ; iStart > policyInfoxx.Policy.DateEnd; iStart -= TimeSpan.FromDays( policyInfoxx.Policy.DateStep ) )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                //MessageBox.Show( "stockDataArray = " + stockDataArray.Length.ToString() );
                                //MessageBox.Show( "iStart = " + iStart.ToString() );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;
                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }

                        if ( policyInfoxx.Policy.IsAllowKN )
                        {
                            //MessageBox.Show( "policyInfoxx.Policy.IsAllowKN" );

                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( int iKn = (int)policyInfoxx.Policy.KN; iKn < policyInfoxx.Policy.KNEnd; iKn += (int)policyInfoxx.Policy.KNStep )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;
                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }

                        if ( policyInfoxx.Policy.IsAllowDate == false && policyInfoxx.Policy.IsAllowKN == false )
                        {
                            //MessageBox.Show( "policyInfoxx.Policy.IsAllowDate&IsAllowKN false" );

                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;

                            StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                            U50Report report = new U50Report();
                            report.Name = stockInfoxx.StockName;
                            report.Symbol = stockInfoxx.StockSymbol;
                            report.Guid = policyInfoxx.Guid;

                            report.ReportSubInfo.S_Date = iStart;

                            report.ScanTime = DateTime.Now;

                            bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                            if ( isOK == false )
                                continue;

                            report.ScanSpan = DateTime.Now - report.ScanTime;

                            reportList.Add( report );
                        }
                    }
                    else if ( policyInfoxx.Policy.Priority == U50PriorityType.BaseKN )
                    {
                        if ( policyInfoxx.Policy.IsAllowKN )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( int iKn = (int)policyInfoxx.Policy.KN; iKn < policyInfoxx.Policy.KNEnd; iKn += (int)policyInfoxx.Policy.KNStep )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;

                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }

                        if ( policyInfoxx.Policy.IsAllowDate )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( ; iStart > policyInfoxx.Policy.DateEnd; iStart -= TimeSpan.FromDays( policyInfoxx.Policy.DateStep ) )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;
                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }

                        if ( policyInfoxx.Policy.IsAllowDate == false && policyInfoxx.Policy.IsAllowKN == false )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;

                            StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                            U50Report report = new U50Report();
                            report.Name = stockInfoxx.StockName;
                            report.Symbol = stockInfoxx.StockSymbol;
                            report.Guid = policyInfoxx.Guid;

                            report.ReportSubInfo.S_Date = iStart;

                            report.ScanTime = DateTime.Now;

                            bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                            if ( isOK == false )
                                continue;

                            report.ScanSpan = DateTime.Now - report.ScanTime;

                            reportList.Add( report );
                        }
                    }
                    else
                    {
                        if ( policyInfoxx.Policy.IsAllowKN )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( int iKn = (int)policyInfoxx.Policy.KN; iKn < policyInfoxx.Policy.KNEnd; iKn += (int)policyInfoxx.Policy.KNStep )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;
                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }

                        if ( policyInfoxx.Policy.IsAllowDate )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;
                            for ( ; iStart > policyInfoxx.Policy.DateEnd; iStart -= TimeSpan.FromDays( policyInfoxx.Policy.DateStep ) )
                            {
                                StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                                U50Report report = new U50Report();
                                report.Name = stockInfoxx.StockName;
                                report.Symbol = stockInfoxx.StockSymbol;
                                report.Guid = policyInfoxx.Guid;

                                report.ReportSubInfo.S_Date = iStart;

                                report.ScanTime = DateTime.Now;

                                bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                                if ( isOK == false )
                                    continue;
                                else
                                {
                                    report.ScanSpan = DateTime.Now - report.ScanTime;
                                    reportList.Add( report );

                                    if ( policyInfoxx.Policy.Output == U50OutputType.One )
                                        break;
                                }
                            }
                        }


                        if ( policyInfoxx.Policy.IsAllowDate == false && policyInfoxx.Policy.IsAllowKN == false )
                        {
                            DateTime iStart = DateTime.Now;
                            if ( policyInfoxx.Policy.IsDateNow != true )
                                iStart = policyInfoxx.Policy.DateSelect;

                            StockData[] stockDataArray = stockInfoxx.GetStockDataRangeByKn( iStart, (int)policyInfoxx.Policy.KN );

                            U50Report report = new U50Report();
                            report.Name = stockInfoxx.StockName;
                            report.Symbol = stockInfoxx.StockSymbol;
                            report.Guid = policyInfoxx.Guid;

                            report.ReportSubInfo.S_Date = iStart;

                            report.ScanTime = DateTime.Now;

                            bool isOK = IsPassGeneral( stockDataArray, stockInfoxx, policyInfoxx.Filtrate, policyInfoxx.Extend, ref report.ReportSubInfo );
                            if ( isOK == false )
                                continue;

                            report.ScanSpan = DateTime.Now - report.ScanTime;

                            reportList.Add( report );
                        }
                    }

                }
            }

            reportInfo.ReportArray = reportList.ToArray();
            reportInfo.ScanSpan = DateTime.Now - reportInfo.ScanTime;

            return reportInfo;
        }

        private static int GetStockInfoHighReturnKN( StockData[] StockInfo )
        {
            int iHigh = 0;
            float iHighV = 0F;

            for ( int iIndex = 0; iIndex < StockInfo.Length; iIndex++ )
            {
                StockData stockInfo = StockInfo[iIndex];

                if ( stockInfo.HighestPrice >= iHighV )
                {
                    iHighV = stockInfo.HighestPrice;
                    iHigh = iIndex;
                }
            }

            return iHigh + 1;
        }

        private static int GetStockInfoLowReturnKN( StockData[] StockInfo )
        {
            int iLow = 0;
            float iLowV = float.MaxValue;

            for ( int iIndex = 0; iIndex < StockInfo.Length; iIndex++ )
            {
                StockData stockInfo = StockInfo[iIndex];

                if ( stockInfo.MinimumPrice < iLowV )
                {
                    iLowV = stockInfo.MinimumPrice;
                    iLow = iIndex;
                }
            }

            return iLow + 1;
        }

        private static int GetStockInfoLow2ReturnKN( StockData[] StockInfo, int iIndexEnd )
        {
            int iLow = 0;
            float iLowV = float.MaxValue;

            for ( int iIndex = 0; iIndex < iIndexEnd; iIndex++ )
            {
                StockData stockInfo = StockInfo[iIndex];

                if ( stockInfo.MinimumPrice < iLowV )
                {
                    iLowV = stockInfo.MinimumPrice;
                    iLow = iIndex;
                }
            }

            return iLow + 1;
        }

        public static bool IsPassGeneral( StockData[] stockDataArray, Demo.Stock.X.Common.StockInfo stockInfo, U50Filtrate filtrateInfo, U50Extend extendInfo, ref U50ReportSub reportSub )
        {
            if ( stockDataArray == null )
                return false;

            if ( stockDataArray.Length < 3 )
                return false;

            // IsPassGeneral
            int iSKn = 1;

            int iH1Kn = GetStockInfoHighReturnKN( stockDataArray );
            if ( iH1Kn <= iSKn ) // iH1Kn > iSKn
                return false;

            int iL1Kn = GetStockInfoLowReturnKN( stockDataArray );
            if ( iL1Kn < iH1Kn ) // iL1Kn >= iH1Kn
                return false;

            int iL2Kn = GetStockInfoLow2ReturnKN( stockDataArray, iH1Kn - 1 );
            if ( iL2Kn < iSKn ) // iL2Kn >= iSKn
                return false;

            if ( iL2Kn >= iH1Kn ) // iL2Kn < iH1Kn
                return false;

            StockData stockDataS = stockDataArray[0];
            StockData stockDataH1 = stockDataArray[iH1Kn - 1];
            StockData stockDataL1 = stockDataArray[iL1Kn - 1];
            StockData stockDataL2 = stockDataArray[iL2Kn - 1];

            if ( stockDataL1.MinimumPrice >= stockDataL2.MinimumPrice )
                return false;

            if ( stockDataL1.MinimumPrice >= stockDataH1.HighestPrice )
                return false;

            if ( stockDataL1.MinimumPrice >= stockDataS.HighestPrice )
                return false;

            if ( stockDataL2.MinimumPrice >= stockDataH1.HighestPrice )
                return false;

            if ( stockDataL2.MinimumPrice >= stockDataS.HighestPrice )
                return false;

            if ( stockDataS.HighestPrice >= stockDataH1.HighestPrice )
            {
                float fRatio = ( stockDataS.HighestPrice - stockDataH1.HighestPrice ) / ( stockDataS.HighestPrice - stockDataL2.MinimumPrice );

                if ( fRatio >= 0.5 )
                    return false;
            }

            // IsPassFiltrate
            float fP_Up = stockDataH1.HighestPrice - stockDataL1.MinimumPrice; // 主升浪价格幅度
            float fP_Down = stockDataH1.HighestPrice - stockDataL2.MinimumPrice; // 下跌浪价格幅度
            float fP_Con = stockDataS.HighestPrice - stockDataL2.MinimumPrice; // 盘整浪价格幅度

            int iKn_Up = iL1Kn - iH1Kn + 1; // 主升浪K线总数
            int iKn_Down = iH1Kn - iL2Kn + 1; // 下跌浪的K线总数
            int iKn_Con = iL2Kn - iSKn + 1; // 盘整浪的K线总数
            int iKn_Conf = iH1Kn - iSKn + 1; // 整理区间的K线数量
            int iKn_U50 = iL1Kn; // U50形态的总K线数

            float fVa_Up = 0F; // 主升浪平均成交量
            for ( int i = 0; i < iKn_Up; i++ )
            {
                StockData stockData = stockDataArray[( iH1Kn - 1 ) + i];
                fVa_Up += stockData.TradingVolume;
            }
            fVa_Up = fVa_Up / iKn_Up;

            float fVa_Down = 0F; // 下跌浪平均成交量
            for ( int i = 0; i < iKn_Down; i++ )
            {
                StockData stockData = stockDataArray[( iL2Kn - 1 ) + i];
                fVa_Down += stockData.TradingVolume;
            }
            fVa_Down = fVa_Down / iKn_Down;

            float fVa_Con = 0F; // 盘整浪的平均成交量
            for ( int i = 0; i < iKn_Con; i++ )
            {
                StockData stockData = stockDataArray[( iSKn - 1 ) + i];
                fVa_Con += stockData.TradingVolume;
            }
            fVa_Con = fVa_Con / iKn_Con;

            float fVa_Conf = 0F; // 整理区间平均成交量
            for ( int i = 0; i < iKn_Conf; i++ )
            {
                StockData stockData = stockDataArray[( iSKn - 1 ) + i];
                fVa_Conf += stockData.TradingVolume;
            }
            fVa_Conf = fVa_Conf / iKn_Conf;

            float fVa_U50 = 0F; // U50形态平均成交量
            for ( int i = 0; i < iKn_U50; i++ )
            {
                StockData stockData = stockDataArray[( iSKn - 1 ) + i];
                fVa_U50 += stockData.TradingVolume;
            }
            fVa_U50 = fVa_U50 / iKn_U50;


            // 下面是价格比
            float fRatioPDU = ( fP_Down / fP_Up ) * 100;
            if ( filtrateInfo.PDU.Enabled == true )
            {
                if ( filtrateInfo.PDU.Select == U50SelectType.Big )
                {
                    if ( fRatioPDU <= filtrateInfo.PDU.Big )
                        return false;
                }
                else if ( filtrateInfo.PDU.Select == U50SelectType.Small )
                {

                    if ( fRatioPDU >= filtrateInfo.PDU.Small )
                        return false;
                }
                else if ( filtrateInfo.PDU.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioPDU <= filtrateInfo.PDU.Big2 || fRatioPDU >= filtrateInfo.PDU.Small2 )
                        return false;
                }
            }

            float fRatioPCU = ( fP_Con / fP_Down ) * 100;
            if ( filtrateInfo.PCU.Enabled == true )
            {
                if ( filtrateInfo.PCU.Select == U50SelectType.Big )
                {
                    if ( fRatioPCU <= filtrateInfo.PCU.Big )
                        return false;
                }
                else if ( filtrateInfo.PCU.Select == U50SelectType.Small )
                {
                    if ( fRatioPCU >= filtrateInfo.PCU.Small )
                        return false;
                }
                else if ( filtrateInfo.PCU.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioPCU <= filtrateInfo.PCU.Big2 || fRatioPCU >= filtrateInfo.PCU.Small2 )
                        return false;
                }
            }

            // 下面是K线比
            float fRatioTDU = ( (float)iKn_Down / (float)iKn_Up ) * 100;
            if ( filtrateInfo.TDU.Enabled == true )
            {
                if ( filtrateInfo.TDU.Select == U50SelectType.Big )
                {
                    if ( fRatioTDU <= filtrateInfo.TDU.Big )
                        return false;
                }
                else if ( filtrateInfo.TDU.Select == U50SelectType.Small )
                {
                    if ( fRatioTDU >= filtrateInfo.TDU.Small )
                        return false;
                }
                else if ( filtrateInfo.TDU.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioTDU <= filtrateInfo.TDU.Big2 || fRatioTDU >= filtrateInfo.TDU.Small2 )
                        return false;
                }
            }

            float fRatioTCD = ( (float)iKn_Con / (float)iKn_Down ) * 100;
            if ( filtrateInfo.TCD.Enabled == true )
            {
                if ( filtrateInfo.TCD.Select == U50SelectType.Big )
                {
                    if ( fRatioTCD <= filtrateInfo.TCD.Big )
                        return false;
                }
                else if ( filtrateInfo.TCD.Select == U50SelectType.Small )
                {
                    if ( fRatioTCD >= filtrateInfo.TCD.Small )
                        return false;
                }
                else if ( filtrateInfo.TCD.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioTCD <= filtrateInfo.TCD.Big2 || fRatioTCD >= filtrateInfo.TCD.Small2 )
                        return false;
                }
            }

            float fRatioTBU = ( (float)iKn_Conf / (float)iKn_Up ) * 100;
            if ( filtrateInfo.TBU.Enabled == true )
            {
                if ( filtrateInfo.TBU.Select == U50SelectType.Big )
                {
                    if ( fRatioTBU <= filtrateInfo.TBU.Big )
                        return false;
                }
                else if ( filtrateInfo.TBU.Select == U50SelectType.Small )
                {
                    if ( fRatioTBU >= filtrateInfo.TBU.Small )
                        return false;
                }
                else if ( filtrateInfo.TBU.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioTBU <= filtrateInfo.TBU.Big2 || fRatioTBU >= filtrateInfo.TBU.Small2 )
                        return false;
                }
            }

            // 下面是成交量比
            float fRatioVac_UC = ( fVa_Up / fVa_Con ) * 100;
            if ( filtrateInfo.VacUC.Enabled == true )
            {
                if ( filtrateInfo.VacUC.Select == U50SelectType.Big )
                {
                    if ( fRatioVac_UC <= filtrateInfo.VacUC.Big )
                        return false;
                }
                else if ( filtrateInfo.VacUC.Select == U50SelectType.Small )
                {
                    if ( fRatioVac_UC >= filtrateInfo.VacUC.Small )
                        return false;
                }
                else if ( filtrateInfo.VacUC.Select == U50SelectType.BigAndSmall )
                {
                    if ( fRatioVac_UC <= filtrateInfo.VacUC.Big2 || fRatioVac_UC >= filtrateInfo.VacUC.Small2 )
                        return false;
                }
            }

            // IsPassExtend
            // H1的价格数据
            if ( extendInfo.Info01.Enabled == true )
            {
                if ( extendInfo.Info01.Select == U50ExtendInfo01Type.High )
                {
                    StockData[] stockDataArray2 = stockInfo.GetStockDataRangeByTime( stockDataL1.TradingDate );
                    foreach ( StockData stockData in stockDataArray2 )
                    {
                        if ( stockDataH1.HighestPrice <= stockData.HighestPrice )
                            return false;
                    }
                }
                else if ( extendInfo.Info01.Select == U50ExtendInfo01Type.HighNumber )
                {
                    StockData[] stockDataArray2 = stockInfo.GetStockDataRangeByKn( stockDataL1.TradingDate, extendInfo.Info01.HighNumber );
                    foreach ( StockData stockData in stockDataArray2 )
                    {
                        if ( stockDataH1.HighestPrice <= stockData.HighestPrice )
                            return false;
                    }
                }
            }

            // U50形态的平均成交量
            if ( extendInfo.Info02.Enabled == true )
            {
                if ( extendInfo.Info02.Select == U50SelectType.Big )
                {
                    if ( fVa_U50 <= extendInfo.Info02.Big )
                        return false;
                }
                else if ( extendInfo.Info02.Select == U50SelectType.Small )
                {
                    if ( fVa_U50 >= extendInfo.Info02.Small )
                        return false;
                }
                else if ( extendInfo.Info02.Select == U50SelectType.BigAndSmall )
                {
                    if ( fVa_U50 <= extendInfo.Info02.Big2 || fVa_U50 >= extendInfo.Info02.Small2 )
                        return false;
                }
            }

            // 当日成交量与U50形态平均成交量比值
            if ( extendInfo.Info03.Enabled == true )
            {
                float fVsc = ( stockDataH1.TradingVolume / fVa_U50 ) * 100;

                if ( extendInfo.Info03.Select == U50SelectType.Big )
                {
                    if ( fVsc <= extendInfo.Info03.Big )
                        return false;
                }
                else if ( extendInfo.Info03.Select == U50SelectType.Small )
                {
                    if ( fVsc >= extendInfo.Info03.Small )
                        return false;
                }
                else if ( extendInfo.Info03.Select == U50SelectType.BigAndSmall )
                {
                    if ( fVsc <= extendInfo.Info03.Big2 || fVsc >= extendInfo.Info03.Small2 )
                        return false;
                }
            }

            // PS≧PH1？
            if ( extendInfo.Info04.Enabled == true )
            {
                if ( extendInfo.Info04.Select == U50ExtendInfo04Type.No )
                {
                    if ( stockDataS.HighestPrice > stockDataH1.HighestPrice ) // PS <= PH1
                        return false;
                }
                else if ( extendInfo.Info04.Select == U50ExtendInfo04Type.Yes )
                {
                    if ( stockDataS.HighestPrice < stockDataH1.HighestPrice ) // PS >= PH1
                        return false;
                }
            }

            // S点所属K线的收盘价
            if ( extendInfo.Info05.Enabled == true )
            {
                if ( extendInfo.Info05.Select == U50SelectType.Big )
                {
                    if ( stockDataS.ClosePrice <= extendInfo.Info05.Big )
                        return false;
                }
                else if ( extendInfo.Info05.Select == U50SelectType.Small )
                {
                    if ( stockDataS.ClosePrice >= extendInfo.Info05.Small )
                        return false;
                }
                else if ( extendInfo.Info05.Select == U50SelectType.BigAndSmall )
                {
                    if ( stockDataS.ClosePrice <= extendInfo.Info05.Big2 || stockDataS.ClosePrice >= extendInfo.Info05.Small2 )
                        return false;
                }
            }


            reportSub.Q_U50 = 0;
            reportSub.KLineNumber = iKn_U50;
            reportSub.Va_U50 = fVa_U50;
            reportSub.Vsc = stockDataS.TradingVolume;
            reportSub.Close = stockDataS.ClosePrice;

            Debug.WriteLine( " " );
            Debug.WriteLine( " " );
            Debug.WriteLine( " " );
            Debug.WriteLine( " --- --- --- --- ---" );

            Debug.WriteLine( "StockSymbol: --- " + " stockInfo.StockSymbol = " + stockInfo.StockSymbol );
            Debug.WriteLine( "H1TradingDateTime: --- " + " stockDataH1.TradingDateTime = " + stockDataH1.TradingDateTime.ToString() );
            Debug.WriteLine( "L1TradingDateTime: --- " + " stockDataL1.TradingDateTime = " + stockDataL1.TradingDateTime.ToString() );
            Debug.WriteLine( "L2TradingDateTime: --- " + " stockDataL2.TradingDateTime = " + stockDataL2.TradingDateTime.ToString() );
            Debug.WriteLine( "fP_Down: --- " + " stockDataH1.HighestPrice = " + stockDataH1.HighestPrice.ToString() + " stockDataL2.MinimumPrice = " + stockDataL2.MinimumPrice.ToString() );
            Debug.WriteLine( "fP_Up: --- " + " stockDataH1.HighestPrice = " + stockDataH1.HighestPrice.ToString() + " stockDataL1.MinimumPrice = " + stockDataL1.MinimumPrice.ToString() );
            Debug.WriteLine( "fRatioPDU: --- " + " fP_Down = " + fP_Down.ToString() + " fP_Up = " + fP_Up.ToString() + " fRatioPDU = " + fRatioPDU.ToString() );
            Debug.WriteLine( "PDU.Small: --- " + "Select = " + filtrateInfo.PDU.Select.ToString() + " filtrateInfo.PDU.Small = " + filtrateInfo.PDU.Small.ToString() );
            Debug.WriteLine( "stockDataS.Close: --- " + "reportSub.Close = " + reportSub.Close.ToString() );
            Debug.WriteLine( "Kn_U50: --- " + "reportSub.KLineNumber= " + reportSub.KLineNumber.ToString() );

            Debug.WriteLine( " --- --- --- --- ---" );

            return true;
        }

        public static U50ReportInfo[] LoadReports( string strTaskGuid )
        {
            U50ReportInfo[] reportInfos = new U50ReportInfo[0];

            if ( File.Exists( strTaskGuid ) == false )
                SaveReport( U50GlobalSetting.TaskFilePath, reportInfos );

            XDocument documentConfig = XDocument.Load( strTaskGuid );
            if ( documentConfig == null )
                return null;

            XElement elementRoot = documentConfig.Element( (XName)"Demo.Stock" );
            if ( elementRoot == null )
                return null;

            XAttribute attributeVer = elementRoot.Attribute( (XName)"Ver" );
            if ( attributeVer == null )
                return null;

            //////////////////////////////////////////////////////////////////////////
            // <Settings>
            IEnumerable<XElement> elementU50Reports = elementRoot.Elements( (XName)"U50Report" );
            if ( elementU50Reports == null )
                return null;

            List<U50ReportInfo> reportInfoList = new List<U50ReportInfo>();
            foreach ( var elementU50Task in elementU50Reports )
            {
                XAttribute attributeGuid = elementU50Task.Attribute( (XName)"Guid" );
                if ( attributeGuid == null )
                    continue;

                XAttribute attributeScanTime = elementU50Task.Attribute( (XName)"ScanTime" );
                if ( attributeScanTime == null )
                    continue;

                XAttribute attributeScanSpan = elementU50Task.Attribute( (XName)"ScanSpan" );
                if ( attributeScanSpan == null )
                    continue;

                U50ReportInfo reportInfo = new U50ReportInfo();
                reportInfo.Guid = attributeGuid.Value;
                reportInfo.ScanTime = DateTime.Parse( attributeScanTime.Value );
                reportInfo.ScanSpan = TimeSpan.Parse( attributeScanSpan.Value );

                XElement elementTask = elementU50Task.Element( (XName)"Task" );
                if ( elementTask == null )
                    continue;
                {
                    XAttribute attributeName = elementU50Task.Attribute( (XName)"Name" );
                    if ( attributeName == null )
                        continue;

                    XAttribute attributeGuid1 = elementU50Task.Attribute( (XName)"Guid" );
                    if ( attributeGuid1 == null )
                        continue;

                    U50TaskInfo taskInfo = new U50TaskInfo();
                    taskInfo.Name = attributeName.Value;
                    taskInfo.Guid = attributeGuid1.Value;

                    // U50Task -> General
                    XElement elementGeneral = elementU50Task.Element( (XName)"General" );
                    if ( elementGeneral == null )
                        continue;
                    {
                        XAttribute attributeAutoScan = elementGeneral.Attribute( (XName)"SaneType" );
                        if ( attributeAutoScan == null )
                            continue;
                        else
                            taskInfo.General.SaneType = (U50TaskSaneType)int.Parse( attributeAutoScan.Value );
                    }

                    // U50Task -> Request
                    XElement elementRequest = elementU50Task.Element( (XName)"Request" );
                    if ( elementRequest == null )
                        continue;
                    {
                        XAttribute attributeSelectType = elementRequest.Attribute( (XName)"SelectType" );
                        if ( attributeSelectType == null )
                            continue;
                        else
                            taskInfo.Request.Select = (U50TaskSelectType)int.Parse( attributeSelectType.Value );

                        XAttribute attributePlate = elementRequest.Attribute( (XName)"Plate" );
                        if ( attributePlate == null )
                            continue;
                        else
                            taskInfo.Request.Plate = attributePlate.Value;

                        XAttribute attributeVariety = elementRequest.Attribute( (XName)"Variety" );
                        if ( attributeVariety == null )
                            continue;
                        else
                            taskInfo.Request.Variety = attributeVariety.Value;

                        // U50Task -> Request -> StockInfo
                        IEnumerable<XElement> elementStockInfo = elementRequest.Elements( (XName)"StockInfo" );
                        if ( elementStockInfo == null )
                            continue;
                        {
                            List<U50StockInfo> stockInfoList = new List<U50StockInfo>();

                            foreach ( var item in elementStockInfo )
                            {
                                U50StockInfo stockInfo = new U50StockInfo();

                                XAttribute attributePlateSub = item.Attribute( (XName)"Plate" );
                                if ( attributePlateSub == null )
                                    continue;
                                else
                                    stockInfo.Variety = attributeVariety.Value;

                                XAttribute attributeVarietySub = item.Attribute( (XName)"Variety" );
                                if ( attributeVarietySub == null )
                                    continue;
                                else
                                    stockInfo.Variety = attributeVariety.Value;

                                XAttribute attributeNameSub = item.Attribute( (XName)"Name" );
                                if ( attributeNameSub == null )
                                    continue;
                                else
                                    stockInfo.Name = attributeVariety.Value;

                                XAttribute attributeSymbolSub = item.Attribute( (XName)"Symbol" );
                                if ( attributeSymbolSub == null )
                                    continue;
                                else
                                    stockInfo.Symbol = attributeVariety.Value;

                                stockInfoList.Add( stockInfo );
                            }

                            taskInfo.Request.StockInfo = stockInfoList.ToArray();
                        }
                    }

                    // U50Task -> Policy
                    XElement elementPolicy = elementU50Task.Element( (XName)"Policy" );
                    if ( elementPolicy == null )
                        continue;
                    {
                        XAttribute attributeScanType = elementPolicy.Attribute( (XName)"ScanType" );
                        if ( attributeScanType == null )
                            continue;
                        else
                            taskInfo.Policy.ScanType = (U50ScanType)int.Parse( attributeScanType.Value );

                        // U50Task -> Policy -> PolicyGuid
                        IEnumerable<XElement> elementPolicyGuid = elementPolicy.Elements( (XName)"PolicyGuid" );
                        if ( elementRequest == null )
                            continue;
                        {
                            List<string> stockPolicyList = new List<string>();

                            foreach ( var item in elementPolicyGuid )
                            {
                                XAttribute attributeNameSub = item.Attribute( (XName)"Guid" );
                                if ( attributeNameSub == null )
                                    continue;
                                else
                                    stockPolicyList.Add( attributeNameSub.Value );
                            }

                            taskInfo.Policy.PolicyGuid = stockPolicyList.ToArray();
                        }
                    }

                    // U50Task -> Result
                    XElement elementResult = elementU50Task.Element( (XName)"Result" );
                    if ( elementResult == null )
                        continue;
                    {
                        // U50Task -> Request -> LastReportGuid
                        XAttribute attributeStockInfo = elementResult.Attribute( (XName)"LastReportGuid" );
                        if ( attributeStockInfo == null )
                            continue;
                        else
                            taskInfo.Result.LastReportGuid = attributeStockInfo.Value;
                    }

                    reportInfo.StaticTaskInfo = taskInfo;
                }

                IEnumerable<XElement> elementPolicyInfo = elementU50Task.Elements( (XName)"PolicyInfo" );
                if ( elementPolicyInfo == null )
                    continue;
                {
                    List<U50PolicyInfo> rolicyInfo = new List<U50PolicyInfo>();
                    foreach ( var item in elementPolicyInfo )
                    {
                        XAttribute attributeName = item.Attribute( (XName)"Name" );
                        if ( attributeName == null )
                            continue;

                        XAttribute attributeGuid11 = item.Attribute( (XName)"Guid" );
                        if ( attributeGuid11 == null )
                            continue;

                        U50PolicyInfo policyInfo = new U50PolicyInfo { Name = attributeName.Value, Guid = attributeGuid11.Value };

                        // U50Policy -> Policy
                        XElement elementPolicy = item.Element( (XName)"Policy" );
                        if ( elementPolicy == null )
                            continue;

                        // U50Policy -> Policy -> DateTime
                        XElement elementDateTime = elementPolicy.Element( (XName)"DateTime" );
                        if ( elementDateTime == null )
                            continue;
                        {
                            XAttribute attributeIsDateNow = elementDateTime.Attribute( (XName)"IsDateNow" );
                            if ( attributeIsDateNow == null )
                                continue;
                            else
                                policyInfo.Policy.IsDateNow = bool.Parse( attributeIsDateNow.Value );

                            XAttribute attributeKN = elementDateTime.Attribute( (XName)"KN" );
                            if ( attributeKN == null )
                                continue;
                            else
                                policyInfo.Policy.KN = uint.Parse( attributeKN.Value );

                            XAttribute attributeDate = elementDateTime.Attribute( (XName)"Date" );
                            if ( attributeDate == null )
                                continue;
                            else
                                policyInfo.Policy.DateSelect = DateTime.Parse( attributeDate.Value );
                        }

                        // U50Policy -> Policy -> ExOption
                        XElement elementExOption = elementPolicy.Element( (XName)"ExOption" );
                        if ( elementExOption == null )
                            continue;
                        {
                            XAttribute attributePriority = elementExOption.Attribute( (XName)"Priority" );
                            if ( attributePriority == null )
                                continue;
                            else
                                policyInfo.Policy.Priority = (U50PriorityType)int.Parse( attributePriority.Value );

                            XAttribute attributeOutput = elementExOption.Attribute( (XName)"Output" );
                            if ( attributeOutput == null )
                                continue;
                            else
                                policyInfo.Policy.Output = (U50OutputType)int.Parse( attributeOutput.Value );

                            // U50Policy -> Policy -> ExOption -> Date
                            XElement elementDate = elementExOption.Element( (XName)"Date" );
                            if ( elementDate == null )
                                continue;
                            {
                                XAttribute attributeDateAllow = elementDate.Attribute( (XName)"Allow" );
                                if ( attributeDateAllow == null )
                                    continue;
                                else
                                    policyInfo.Policy.IsAllowDate = bool.Parse( attributeDateAllow.Value );

                                XAttribute attributeDateStep = elementDate.Attribute( (XName)"Step" );
                                if ( attributeDateStep == null )
                                    continue;
                                else
                                    policyInfo.Policy.DateStep = uint.Parse( attributeDateStep.Value );

                                XAttribute attributeDateEnd = elementDate.Attribute( (XName)"End" );
                                if ( attributeDateEnd == null )
                                    continue;
                                else
                                    policyInfo.Policy.DateEnd = DateTime.Parse( attributeDateEnd.Value );
                            }

                            // U50Policy -> Policy -> ExOption -> KN
                            XElement elementKN = elementExOption.Element( (XName)"KN" );
                            if ( elementKN == null )
                                continue;
                            {
                                XAttribute attributeKNAllow = elementKN.Attribute( (XName)"Allow" );
                                if ( attributeKNAllow == null )
                                    continue;
                                else
                                    policyInfo.Policy.IsAllowKN = bool.Parse( attributeKNAllow.Value );

                                XAttribute attributeKNStep = elementKN.Attribute( (XName)"Step" );
                                if ( attributeKNStep == null )
                                    continue;
                                else
                                    policyInfo.Policy.KNStep = uint.Parse( attributeKNStep.Value );

                                XAttribute attributeKNEnd = elementKN.Attribute( (XName)"End" );
                                if ( attributeKNEnd == null )
                                    continue;
                                else
                                    policyInfo.Policy.KNEnd = uint.Parse( attributeKNEnd.Value );
                            }
                        }

                        // U50Policy -> Filtrate
                        XElement elementFiltrate = item.Element( (XName)"Filtrate" );
                        if ( elementFiltrate == null )
                            continue;
                        {
                            // U50Policy -> Filtrate -> PDU
                            XElement elementPDU = elementFiltrate.Element( (XName)"PDU" );
                            if ( elementPDU == null )
                                continue;
                            {
                                XAttribute attributePDUEnabled = elementPDU.Attribute( (XName)"Enabled" );
                                if ( attributePDUEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PDU.Enabled = bool.Parse( attributePDUEnabled.Value );

                                XAttribute attributePDUSelect = elementPDU.Attribute( (XName)"Select" );
                                if ( attributePDUSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PDU.Select = (U50SelectType)int.Parse( attributePDUSelect.Value );

                                XAttribute attributePDUBig = elementPDU.Attribute( (XName)"Big" );
                                if ( attributePDUBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PDU.Big = float.Parse( attributePDUBig.Value );

                                XAttribute attributePDUSmall = elementPDU.Attribute( (XName)"Small" );
                                if ( attributePDUSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PDU.Small = float.Parse( attributePDUSmall.Value );
                            }

                            // U50Policy -> Filtrate -> PCU
                            XElement elementPCU = elementFiltrate.Element( (XName)"PCU" );
                            if ( elementPCU == null )
                                continue;
                            {
                                XAttribute attributePCUEnabled = elementPCU.Attribute( (XName)"Enabled" );
                                if ( attributePCUEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PCU.Enabled = bool.Parse( attributePCUEnabled.Value );

                                XAttribute attributePCUSelect = elementPCU.Attribute( (XName)"Select" );
                                if ( attributePCUSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PCU.Select = (U50SelectType)int.Parse( attributePCUSelect.Value );

                                XAttribute attributePCUBig = elementPCU.Attribute( (XName)"Big" );
                                if ( attributePCUBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PCU.Big = float.Parse( attributePCUBig.Value );

                                XAttribute attributePCUSmall = elementPCU.Attribute( (XName)"Small" );
                                if ( attributePCUSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.PCU.Small = float.Parse( attributePCUSmall.Value );
                            }

                            // U50Policy -> Filtrate -> TDU
                            XElement elementTDU = elementFiltrate.Element( (XName)"TDU" );
                            if ( elementTDU == null )
                                continue;
                            {
                                XAttribute attributeTDUEnabled = elementTDU.Attribute( (XName)"Enabled" );
                                if ( attributeTDUEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TDU.Enabled = bool.Parse( attributeTDUEnabled.Value );

                                XAttribute attributeTDUSelect = elementTDU.Attribute( (XName)"Select" );
                                if ( attributeTDUSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TDU.Select = (U50SelectType)int.Parse( attributeTDUSelect.Value );

                                XAttribute attributeTDUBig = elementTDU.Attribute( (XName)"Big" );
                                if ( attributeTDUBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TDU.Big = float.Parse( attributeTDUBig.Value );

                                XAttribute attributeTDUSmall = elementTDU.Attribute( (XName)"Small" );
                                if ( attributeTDUSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TDU.Small = float.Parse( attributeTDUSmall.Value );
                            }

                            // U50Policy -> Filtrate -> TCD
                            XElement elementTCD = elementFiltrate.Element( (XName)"TCD" );
                            if ( elementTCD == null )
                                continue;
                            {
                                XAttribute attributeTCDEnabled = elementTCD.Attribute( (XName)"Enabled" );
                                if ( attributeTCDEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TCD.Enabled = bool.Parse( attributeTCDEnabled.Value );

                                XAttribute attributeTCDSelect = elementTCD.Attribute( (XName)"Select" );
                                if ( attributeTCDSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TCD.Select = (U50SelectType)int.Parse( attributeTCDSelect.Value );

                                XAttribute attributeTCDBig = elementTCD.Attribute( (XName)"Big" );
                                if ( attributeTCDBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TCD.Big = float.Parse( attributeTCDBig.Value );

                                XAttribute attributeTCDSmall = elementTCD.Attribute( (XName)"Small" );
                                if ( attributeTCDSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TCD.Small = float.Parse( attributeTCDSmall.Value );
                            }

                            // U50Policy -> Filtrate -> TBU
                            XElement elementTBU = elementFiltrate.Element( (XName)"TBU" );
                            if ( elementTBU == null )
                                continue;
                            {
                                XAttribute attributeTCUEnabled = elementTBU.Attribute( (XName)"Enabled" );
                                if ( attributeTCUEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TBU.Enabled = bool.Parse( attributeTCUEnabled.Value );

                                XAttribute attributeTCUSelect = elementTBU.Attribute( (XName)"Select" );
                                if ( attributeTCUSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TBU.Select = (U50SelectType)int.Parse( attributeTCUSelect.Value );

                                XAttribute attributeTCUBig = elementTBU.Attribute( (XName)"Big" );
                                if ( attributeTCUBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TBU.Big = float.Parse( attributeTCUBig.Value );

                                XAttribute attributeTCUSmall = elementTBU.Attribute( (XName)"Small" );
                                if ( attributeTCUSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.TBU.Small = float.Parse( attributeTCUSmall.Value );
                            }

                            // U50Policy -> Filtrate -> Vac-UC
                            XElement elementVacUC = elementFiltrate.Element( (XName)"Vac-UC" );
                            if ( elementVacUC == null )
                                continue;
                            {
                                XAttribute attributeVacUCEnabled = elementVacUC.Attribute( (XName)"Enabled" );
                                if ( attributeVacUCEnabled == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.VacUC.Enabled = bool.Parse( attributeVacUCEnabled.Value );

                                XAttribute attributeVacUCSelect = elementVacUC.Attribute( (XName)"Select" );
                                if ( attributeVacUCSelect == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.VacUC.Select = (U50SelectType)int.Parse( attributeVacUCSelect.Value );

                                XAttribute attributeVacUCBig = elementVacUC.Attribute( (XName)"Big" );
                                if ( attributeVacUCBig == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.VacUC.Big = float.Parse( attributeVacUCBig.Value );

                                XAttribute attributeVacUCSmall = elementVacUC.Attribute( (XName)"Small" );
                                if ( attributeVacUCSmall == null )
                                    continue;
                                else
                                    policyInfo.Filtrate.VacUC.Small = float.Parse( attributeVacUCSmall.Value );
                            }
                        }

                        // U50Policy -> Extend
                        XElement elementExtend = item.Element( (XName)"Extend" );
                        if ( elementExtend == null )
                            continue;
                        {
                            // U50Policy -> Extend -> Info01
                            XElement elementInfo01 = elementExtend.Element( (XName)"Info01" );
                            if ( elementInfo01 == null )
                                continue;
                            {
                                XAttribute attributeInfo01Enabled = elementInfo01.Attribute( (XName)"Enabled" );
                                if ( attributeInfo01Enabled == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info01.Enabled = bool.Parse( attributeInfo01Enabled.Value );

                                XAttribute attributeInfo01Select = elementInfo01.Attribute( (XName)"Select" );
                                if ( attributeInfo01Select == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info01.Select = (U50ExtendInfo01Type)int.Parse( attributeInfo01Select.Value );

                                XAttribute attributeInfo01Big = elementInfo01.Attribute( (XName)"HighNumber" );
                                if ( attributeInfo01Big == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info01.HighNumber = int.Parse( attributeInfo01Big.Value );
                            }

                            // U50Policy -> Extend -> Info02
                            XElement elementInfo02 = elementExtend.Element( (XName)"Info02" );
                            if ( elementInfo02 == null )
                                continue;
                            {
                                XAttribute attributeInfo02Enabled = elementInfo02.Attribute( (XName)"Enabled" );
                                if ( attributeInfo02Enabled == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info02.Enabled = bool.Parse( attributeInfo02Enabled.Value );

                                XAttribute attributeInfo02Select = elementInfo02.Attribute( (XName)"Select" );
                                if ( attributeInfo02Select == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info02.Select = (U50SelectType)int.Parse( attributeInfo02Select.Value );

                                XAttribute attributeInfo02Big = elementInfo02.Attribute( (XName)"Big" );
                                if ( attributeInfo02Big == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info02.Big = long.Parse( attributeInfo02Big.Value );

                                XAttribute attributeInfo02Small = elementInfo02.Attribute( (XName)"Small" );
                                if ( attributeInfo02Small == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info02.Small = long.Parse( attributeInfo02Small.Value );
                            }

                            // U50Policy -> Extend -> Info03
                            XElement elementInfo03 = elementExtend.Element( (XName)"Info03" );
                            if ( elementInfo03 == null )
                                continue;
                            {
                                XAttribute attributeInfo03Enabled = elementInfo03.Attribute( (XName)"Enabled" );
                                if ( attributeInfo03Enabled == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info03.Enabled = bool.Parse( attributeInfo03Enabled.Value );

                                XAttribute attributeInfo03Select = elementInfo03.Attribute( (XName)"Select" );
                                if ( attributeInfo03Select == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info03.Select = (U50SelectType)int.Parse( attributeInfo03Select.Value );

                                XAttribute attributeInfo03Big = elementInfo03.Attribute( (XName)"Big" );
                                if ( attributeInfo03Big == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info03.Big = int.Parse( attributeInfo03Big.Value );

                                XAttribute attributeInfo03Small = elementInfo03.Attribute( (XName)"Small" );
                                if ( attributeInfo03Small == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info03.Small = int.Parse( attributeInfo03Small.Value );
                            }

                            // U50Policy -> Extend -> Info04
                            XElement elementInfo04 = elementExtend.Element( (XName)"Info04" );
                            if ( elementInfo04 == null )
                                continue;
                            {
                                XAttribute attributeInfo04Enabled = elementInfo04.Attribute( (XName)"Enabled" );
                                if ( attributeInfo04Enabled == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info04.Enabled = bool.Parse( attributeInfo04Enabled.Value );

                                XAttribute attributeInfo04Select = elementInfo04.Attribute( (XName)"Select" );
                                if ( attributeInfo04Select == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info04.Select = (U50ExtendInfo04Type)int.Parse( attributeInfo04Select.Value );
                            }

                            // U50Policy -> Extend -> Info05
                            XElement elementInfo05 = elementExtend.Element( (XName)"Info05" );
                            if ( elementInfo05 == null )
                                continue;
                            {
                                XAttribute attributeInfo05Enabled = elementInfo05.Attribute( (XName)"Enabled" );
                                if ( attributeInfo05Enabled == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info05.Enabled = bool.Parse( attributeInfo05Enabled.Value );

                                XAttribute attributeInfo05Select = elementInfo05.Attribute( (XName)"Select" );
                                if ( attributeInfo05Select == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info05.Select = (U50SelectType)int.Parse( attributeInfo05Select.Value );

                                XAttribute attributeInfo05Big = elementInfo05.Attribute( (XName)"Big" );
                                if ( attributeInfo05Big == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info05.Big = int.Parse( attributeInfo05Big.Value );

                                XAttribute attributeInfo05Small = elementInfo05.Attribute( (XName)"Small" );
                                if ( attributeInfo05Small == null )
                                    continue;
                                else
                                    policyInfo.Extend.Info05.Small = int.Parse( attributeInfo05Small.Value );
                            }
                        }

                        rolicyInfo.Add( policyInfo );
                    }

                    reportInfo.StaticReportInfo = rolicyInfo.ToArray();
                }

                IEnumerable<XElement> elementReportInfo = elementU50Task.Elements( (XName)"ReportInfo" );
                if ( elementReportInfo == null )
                    continue;
                {
                    List<U50Report> reportList = new List<U50Report>();
                    foreach ( var item in elementReportInfo )
                    {
                        U50Report report = new U50Report();

                        XAttribute attributeName = item.Attribute( (XName)"Name" );
                        if ( attributeName == null )
                            continue;
                        else
                            report.Name = attributeName.Value;

                        XAttribute attributeSymbol = item.Attribute( (XName)"Symbol" );
                        if ( attributeSymbol == null )
                            continue;
                        else
                            report.Symbol = attributeSymbol.Value;

                        //XAttribute attributeS_Date = item.Attribute( (XName)"S_Date" );
                        //if ( attributeS_Date == null )
                        //    continue;
                        //else
                        //    report.S_Date = DateTime.Parse( attributeS_Date.Value );

                        //XAttribute attributeVa_U50 = item.Attribute( (XName)"Va_U50" );
                        //if ( attributeVa_U50 == null )
                        //    continue;
                        //else
                        //    report.Va_U50 = int.Parse( attributeVa_U50.Value );

                        //XAttribute attributeVsc = item.Attribute( (XName)"Vsc" );
                        //if ( attributeVsc == null )
                        //    continue;
                        //else
                        //    report.Vsc = int.Parse( attributeVsc.Value );

                        //XAttribute attributeClose = item.Attribute( (XName)"Close" );
                        //if ( attributeClose == null )
                        //    continue;
                        //else
                        //    report.Close = int.Parse( attributeClose.Value );

                        //XAttribute attributeScanner = item.Attribute( (XName)"Scanner" );
                        //if ( attributeScanner == null )
                        //    continue;
                        //else
                        //    report.Scanner = attributeScanner.Value;

                        //XAttribute attributeQ_U50 = item.Attribute( (XName)"Q_U50" );
                        //if ( attributeQ_U50 == null )
                        //    continue;
                        //else
                        //    report.Q_U50 = int.Parse( attributeQ_U50.Value );

                        //XAttribute attributeKLineNumber = item.Attribute( (XName)"KLineNumber" );
                        //if ( attributeKLineNumber == null )
                        //    continue;
                        //else
                        //    report.KLineNumber = int.Parse( attributeKLineNumber.Value );

                        XAttribute attributeScanTime1 = item.Attribute( (XName)"ScanTime" );
                        if ( attributeScanTime1 == null )
                            continue;
                        else
                            report.ScanTime = DateTime.Parse( attributeScanTime1.Value );

                        XAttribute attributeScanSpan1 = item.Attribute( (XName)"ScanSpan" );
                        if ( attributeScanSpan1 == null )
                            continue;
                        else
                            report.ScanSpan = TimeSpan.Parse( attributeScanSpan1.Value );

                        reportList.Add( report );
                    }

                    reportInfo.ReportArray = reportList.ToArray();
                }

                reportInfoList.Add( reportInfo );
            }

            return reportInfos;
        }

        public static void SaveReport( string strTaskGuid, U50ReportInfo[] reportInfos )
        {
            if ( reportInfos == null )
                return;

            if ( File.Exists( strTaskGuid ) == true )
                File.Delete( strTaskGuid );

            XElement elementRoot = new XElement( "Demo.Stock", new XAttribute( "Ver", "0.0.1.0" ) );

            for ( int iIndex = 0; iIndex < reportInfos.Length; iIndex++ )
            {
                U50ReportInfo reportInfo = reportInfos[iIndex];

                XElement elementU50Report = new XElement( "U50Report", new XAttribute( "Guid", reportInfo.Guid ) );
                elementU50Report.Add( new XAttribute( "ScanTime", reportInfo.ScanTime.ToString() ) );
                elementU50Report.Add( new XAttribute( "ScanSpan", reportInfo.ScanSpan.ToString() ) );
                {
                    XElement elementTask = new XElement( "Task" );
                    {
                        elementU50Report.Add( new XAttribute( "Guid", reportInfo.StaticTaskInfo.Guid ) );
                        {
                            XElement elementGeneral = new XElement( "General" );
                            {
                                elementGeneral.Add( new XAttribute( "SaneType", ( (int)reportInfo.StaticTaskInfo.General.SaneType ).ToString() ) );
                            }
                            elementU50Report.Add( elementGeneral );

                            XElement elementRequest = new XElement( "Request" );
                            {
                                elementRequest.Add( new XAttribute( "SelectType", ( (int)reportInfo.StaticTaskInfo.Request.Select ).ToString() ) );
                                elementRequest.Add( new XAttribute( "Plate", reportInfo.StaticTaskInfo.Request.Plate ) );
                                elementRequest.Add( new XAttribute( "Variety", reportInfo.StaticTaskInfo.Request.Variety ) );

                                for ( int iIndex2 = 0; iIndex2 < reportInfo.StaticTaskInfo.Request.StockInfo.Length; iIndex2++ )
                                {
                                    U50StockInfo stockInfo = reportInfo.StaticTaskInfo.Request.StockInfo[iIndex2];

                                    XElement elementStockInfo = new XElement( "StockInfo" );
                                    {
                                        elementStockInfo.Add( new XAttribute( "Plate", stockInfo.Plate ) );
                                        elementStockInfo.Add( new XAttribute( "Variety", stockInfo.Variety ) );
                                        elementStockInfo.Add( new XAttribute( "Name", stockInfo.Name ) );
                                        elementStockInfo.Add( new XAttribute( "Symbol", stockInfo.Symbol ) );
                                    }
                                    elementRequest.Add( elementStockInfo );
                                }
                            }
                            elementU50Report.Add( elementRequest );

                            XElement elementPolicy = new XElement( "Policy" );
                            {
                                elementPolicy.Add( new XAttribute( "ScanType", ( (int)reportInfo.StaticTaskInfo.Policy.ScanType ).ToString() ) );

                                for ( int iIndex2 = 0; iIndex2 < reportInfo.StaticTaskInfo.Policy.PolicyGuid.Length; iIndex2++ )
                                {
                                    string strPolicyGuid = reportInfo.StaticTaskInfo.Policy.PolicyGuid[iIndex2];

                                    XElement elementPolicyGuid = new XElement( "PolicyGuid" );
                                    {
                                        elementPolicyGuid.Add( new XAttribute( "Guid", strPolicyGuid ) );
                                    }
                                    elementPolicy.Add( elementPolicyGuid );
                                }
                            }
                            elementU50Report.Add( elementPolicy );

                            XElement elementScanResult = new XElement( "ScanResult" );
                            {
                                elementScanResult.Add( new XAttribute( "LastReportGuid", reportInfo.StaticTaskInfo.Result.LastReportGuid ) );
                            }
                            elementU50Report.Add( elementScanResult );
                        }
                    }
                    elementU50Report.Add( elementTask );

                    XElement elementPolicyInfo = new XElement( "PolicyInfo" );
                    {
                        for ( int iIndex2 = 0; iIndex2 < reportInfo.StaticReportInfo.Length; iIndex2++ )
                        {
                            U50PolicyInfo policyInfo = reportInfo.StaticReportInfo[iIndex2];

                            XElement elementU50Policy = new XElement( "U50Policy", new XAttribute( "Name", policyInfo.Name ) );
                            elementU50Policy.Add( new XAttribute( "Guid", policyInfo.Guid ) );
                            {
                                XElement elementPolicy = new XElement( "Policy" );
                                {
                                    XElement elementDateTime = new XElement( "DateTime" );
                                    {
                                        elementDateTime.Add( new XAttribute( "IsDateNow", policyInfo.Policy.IsDateNow ) );
                                        elementDateTime.Add( new XAttribute( "KN", policyInfo.Policy.KN ) );
                                        elementDateTime.Add( new XAttribute( "Date", policyInfo.Policy.DateSelect.ToShortDateString() ) );
                                    }
                                    elementPolicy.Add( elementDateTime );

                                    XElement elementExOption = new XElement( "ExOption" );
                                    {
                                        elementExOption.Add( new XAttribute( "Priority", ( (int)policyInfo.Policy.Priority ).ToString() ) );
                                        elementExOption.Add( new XAttribute( "Output", ( (int)policyInfo.Policy.Output ).ToString() ) );

                                        XElement elementDate = new XElement( "Date" );
                                        {
                                            elementDate.Add( new XAttribute( "Allow", policyInfo.Policy.IsAllowDate.ToString() ) );
                                            elementDate.Add( new XAttribute( "Step", policyInfo.Policy.DateStep.ToString() ) );
                                            elementDate.Add( new XAttribute( "End", policyInfo.Policy.DateEnd.ToString() ) );
                                        }
                                        elementExOption.Add( elementDate );

                                        XElement elementKN = new XElement( "KN" );
                                        {
                                            elementKN.Add( new XAttribute( "Allow", policyInfo.Policy.IsAllowKN.ToString() ) );
                                            elementKN.Add( new XAttribute( "Step", policyInfo.Policy.KNStep.ToString() ) );
                                            elementKN.Add( new XAttribute( "End", policyInfo.Policy.KNEnd.ToString() ) );
                                        }
                                        elementExOption.Add( elementKN );
                                    }
                                    elementPolicy.Add( elementExOption );
                                }
                                elementU50Policy.Add( elementPolicy );

                                XElement elementFiltrate = new XElement( "Filtrate" );
                                {
                                    XElement elementPDU = new XElement( "PDU" );
                                    {
                                        elementPDU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.PDU.Enabled.ToString() ) );
                                        elementPDU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.PDU.Select ).ToString() ) );
                                        elementPDU.Add( new XAttribute( "Big", policyInfo.Filtrate.PDU.Big.ToString() ) );
                                        elementPDU.Add( new XAttribute( "Small", policyInfo.Filtrate.PDU.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementPDU );

                                    XElement elementPCU = new XElement( "PCU" );
                                    {
                                        elementPCU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.PCU.Enabled.ToString() ) );
                                        elementPCU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.PCU.Select ).ToString() ) );
                                        elementPCU.Add( new XAttribute( "Big", policyInfo.Filtrate.PCU.Big.ToString() ) );
                                        elementPCU.Add( new XAttribute( "Small", policyInfo.Filtrate.PCU.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementPCU );

                                    XElement elementTDU = new XElement( "TDU" );
                                    {
                                        elementTDU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TDU.Enabled.ToString() ) );
                                        elementTDU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TDU.Select ).ToString() ) );
                                        elementTDU.Add( new XAttribute( "Big", policyInfo.Filtrate.TDU.Big.ToString() ) );
                                        elementTDU.Add( new XAttribute( "Small", policyInfo.Filtrate.TDU.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementTDU );

                                    XElement elementTCD = new XElement( "TCD" );
                                    {
                                        elementTCD.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TCD.Enabled.ToString() ) );
                                        elementTCD.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TCD.Select ).ToString() ) );
                                        elementTCD.Add( new XAttribute( "Big", policyInfo.Filtrate.TCD.Big.ToString() ) );
                                        elementTCD.Add( new XAttribute( "Small", policyInfo.Filtrate.TCD.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementTCD );

                                    XElement elementTBU = new XElement( "TBU" );
                                    {
                                        elementTBU.Add( new XAttribute( "Enabled", policyInfo.Filtrate.TBU.Enabled.ToString() ) );
                                        elementTBU.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.TBU.Select ).ToString() ) );
                                        elementTBU.Add( new XAttribute( "Big", policyInfo.Filtrate.TBU.Big.ToString() ) );
                                        elementTBU.Add( new XAttribute( "Small", policyInfo.Filtrate.TBU.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementTBU );

                                    XElement elementVacUC = new XElement( "Vac-UC" );
                                    {
                                        elementVacUC.Add( new XAttribute( "Enabled", policyInfo.Filtrate.VacUC.Enabled.ToString() ) );
                                        elementVacUC.Add( new XAttribute( "Select", ( (int)policyInfo.Filtrate.VacUC.Select ).ToString() ) );
                                        elementVacUC.Add( new XAttribute( "Big", policyInfo.Filtrate.VacUC.Big.ToString() ) );
                                        elementVacUC.Add( new XAttribute( "Small", policyInfo.Filtrate.VacUC.Small.ToString() ) );
                                    }
                                    elementFiltrate.Add( elementVacUC );
                                }
                                elementU50Policy.Add( elementFiltrate );

                                XElement elementExtend = new XElement( "Extend" );
                                {
                                    XElement elementInfo01 = new XElement( "Info01" );
                                    {
                                        elementInfo01.Add( new XAttribute( "Enabled", policyInfo.Extend.Info01.Enabled.ToString() ) );
                                        elementInfo01.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info01.Select ).ToString() ) );
                                        elementInfo01.Add( new XAttribute( "HighNumber", policyInfo.Extend.Info01.HighNumber.ToString() ) );
                                    }
                                    elementExtend.Add( elementInfo01 );

                                    XElement elementInfo02 = new XElement( "Info02" );
                                    {
                                        elementInfo02.Add( new XAttribute( "Enabled", policyInfo.Extend.Info02.Enabled.ToString() ) );
                                        elementInfo02.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info02.Select ).ToString() ) );
                                        elementInfo02.Add( new XAttribute( "Big", policyInfo.Extend.Info02.Big.ToString() ) );
                                        elementInfo02.Add( new XAttribute( "Small", policyInfo.Extend.Info02.Small.ToString() ) );
                                    }
                                    elementExtend.Add( elementInfo02 );

                                    XElement elementInfo03 = new XElement( "Info03" );
                                    {
                                        elementInfo03.Add( new XAttribute( "Enabled", policyInfo.Extend.Info03.Enabled.ToString() ) );
                                        elementInfo03.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info03.Select ).ToString() ) );
                                        elementInfo03.Add( new XAttribute( "Big", policyInfo.Extend.Info03.Big.ToString() ) );
                                        elementInfo03.Add( new XAttribute( "Small", policyInfo.Extend.Info03.Small.ToString() ) );
                                    }
                                    elementExtend.Add( elementInfo03 );

                                    XElement elementInfo04 = new XElement( "Info04" );
                                    {
                                        elementInfo04.Add( new XAttribute( "Enabled", policyInfo.Extend.Info04.Enabled.ToString() ) );
                                        elementInfo04.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info04.Select ).ToString() ) );
                                    }
                                    elementExtend.Add( elementInfo04 );

                                    XElement elementInfo05 = new XElement( "Info05" );
                                    {
                                        elementInfo05.Add( new XAttribute( "Enabled", policyInfo.Extend.Info05.Enabled.ToString() ) );
                                        elementInfo05.Add( new XAttribute( "Select", ( (int)policyInfo.Extend.Info05.Select ).ToString() ) );
                                        elementInfo05.Add( new XAttribute( "Big", policyInfo.Extend.Info05.Big.ToString() ) );
                                        elementInfo05.Add( new XAttribute( "Small", policyInfo.Extend.Info05.Small.ToString() ) );
                                    }
                                    elementExtend.Add( elementInfo05 );
                                }
                                elementU50Policy.Add( elementExtend );
                            }
                            elementPolicyInfo.Add( elementU50Policy );
                        }
                    }
                    elementU50Report.Add( elementPolicyInfo );

                    XElement elementReportInfo = new XElement( "ReportInfo" );
                    {
                        for ( int iIndex3 = 0; iIndex3 < reportInfo.ReportArray.Length; iIndex3++ )
                        {
                            U50Report report = reportInfo.ReportArray[iIndex3];

                            XElement elementPolicy = new XElement( "Report" );
                            {
                                elementPolicy.Add( new XAttribute( "Name", report.Name ) );
                                elementPolicy.Add( new XAttribute( "Symbol", report.Symbol ) );
                                //elementPolicy.Add( new XAttribute( "S_Date", report.S_Date.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "Va_U50", report.Va_U50.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "Vsc", report.Vsc.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "Close", report.Close.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "Scanner", report.Scanner.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "Q_U50", report.Q_U50.ToString() ) );
                                //elementPolicy.Add( new XAttribute( "KLineNumber", report.KLineNumber.ToString() ) );
                                elementPolicy.Add( new XAttribute( "ScanTime", report.ScanTime.ToString() ) );
                                elementPolicy.Add( new XAttribute( "ScanSpan", report.ScanSpan.ToString() ) );
                            }
                            elementPolicyInfo.Add( elementPolicy );
                        }
                    }
                    elementU50Report.Add( elementU50Report );
                }
                elementRoot.Add( elementU50Report );
            }

            XDocument documentConfig = new XDocument( new XDeclaration( "1.0", "utf - 8", "yes" ), elementRoot );
            documentConfig.Save( strTaskGuid );
        }
    }
}
