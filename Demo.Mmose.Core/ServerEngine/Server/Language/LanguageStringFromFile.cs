#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
#endregion

namespace Demo.Mmose.Core.Server.Language
{
    /// <summary>
    /// 
    /// </summary>
    internal class LanguageStringFromFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        private delegate void SetStringEventHandler( LanguageString globalString, string strValue );

        /// <summary>
        /// 
        /// </summary>
        private class SetStringHandler
        {
            #region zh-CHS 公开方法 | en Public Method
            #region zh-CHS 私有成员变量 | en Private Member Variables
            /// <summary>
            /// 
            /// </summary>
            private Dictionary<string, SetStringEventHandler> m_Handlers = new Dictionary<string, SetStringEventHandler>();
            #endregion
            /// <summary>
            /// 
            /// </summary>
            /// <param name="strResourceName"></param>
            /// <param name="onPacketReceive"></param>
            public void Register( string strResourceName, SetStringEventHandler onPacketReceive )
            {
                m_Handlers.Add( strResourceName, onPacketReceive );
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="strResourceName"></param>
            /// <returns></returns>
            public SetStringEventHandler GetHandler( string strResourceName )
            {
                SetStringEventHandler strHandler = null;
                m_Handlers.TryGetValue( strResourceName, out strHandler );
                return strHandler;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="strResourceName"></param>
            public void RemoveHandler( string strResourceName )
            {
                m_Handlers.Remove( strResourceName );
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LoadLanguageFile( Assembly assembly, ref LanguageString globalString )
        {
            // 以下是读取XML文件内的语言信息
            const string LANGUAGE_VERSION = "0.0.1.0";

            if ( assembly == null )
                return;

            string lngFile = Path.ChangeExtension( assembly.Location, ".lng" );
            if ( lngFile == string.Empty )
                return;

            if ( File.Exists( lngFile ) == false )
                return;

            XDocument languageXML = null;
            try
            {
                languageXML = XDocument.Load( lngFile );
            }
            catch ( Exception )
            {
                Debug.WriteLine( "Language.SetLanguageString(...) - XDocument.Load(...) throw Exception!" );
                return;
            }

            XElement elementRoot = languageXML.Element( (XName)"Mmose.Language" );
            if ( elementRoot == null )
                return;

            XAttribute attributeVersion = elementRoot.Attribute( (XName)"Version" );
            if ( attributeVersion == null )
                return;

            if ( attributeVersion.Value != LANGUAGE_VERSION )
                return;

            XAttribute attributeLanguage = elementRoot.Attribute( (XName)"Language" );
            if ( attributeLanguage == null )
                return;

            // 设置语言信息
            globalString.CultureInfo = new CultureInfo( attributeLanguage.Value, false );


            var stringInfo = from languageInfo in elementRoot.Elements( (XName)"String" ) select languageInfo;
            if ( stringInfo == null )
                return;

            // 初始化处理函数的接口
            InitSetStringHandler();

            foreach ( XElement itemString in stringInfo )
            {
                XAttribute attributeName = itemString.Attribute( (XName)"Name" );
                if ( attributeName == null )
                    continue;

                XAttribute attributeValue = itemString.Attribute( (XName)"Value" );
                if ( attributeValue == null )
                    continue;

                SetStringEventHandler strHandler = s_SetStringHandler.GetHandler( attributeName.Value );
                if ( strHandler == null )
                    continue;

                strHandler( globalString, attributeValue.Value );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static SetStringHandler s_SetStringHandler = new SetStringHandler();
        /// <summary>
        /// 
        /// </summary>
        private static void InitSetStringHandler()
        {
            #region zh-CHS BaseWorld | en BaseWorld
            s_SetStringHandler.Register( "BaseWorldString001", SetStringBaseWorldString001 );
            s_SetStringHandler.Register( "BaseWorldString002", SetStringBaseWorldString001 );
            s_SetStringHandler.Register( "BaseWorldString003", SetStringBaseWorldString001 );
            #endregion

            #region zh-CHS OneServer | en OneServer
            s_SetStringHandler.Register( "OneServerString001", SetStringOneServerString001 );
            s_SetStringHandler.Register( "OneServerString002", SetStringOneServerString002 );
            s_SetStringHandler.Register( "OneServerString003", SetStringOneServerString003 );
            s_SetStringHandler.Register( "OneServerString004", SetStringOneServerString004 );
            s_SetStringHandler.Register( "OneServerString005", SetStringOneServerString005 );
            s_SetStringHandler.Register( "OneServerString006", SetStringOneServerString006 );
            s_SetStringHandler.Register( "OneServerString007", SetStringOneServerString007 );
            s_SetStringHandler.Register( "OneServerString008", SetStringOneServerString008 );
            s_SetStringHandler.Register( "OneServerString009", SetStringOneServerString009 );
            s_SetStringHandler.Register( "OneServerString010", SetStringOneServerString010 );
            s_SetStringHandler.Register( "OneServerString011", SetStringOneServerString011 );
            s_SetStringHandler.Register( "OneServerString012", SetStringOneServerString012 );
            s_SetStringHandler.Register( "OneServerString013", SetStringOneServerString013 );
            s_SetStringHandler.Register( "OneServerString014", SetStringOneServerString014 );
            s_SetStringHandler.Register( "OneServerString015", SetStringOneServerString015 );
            s_SetStringHandler.Register( "OneServerString016", SetStringOneServerString016 );
            s_SetStringHandler.Register( "OneServerString017", SetStringOneServerString017 );
            s_SetStringHandler.Register( "OneServerString018", SetStringOneServerString018 );
            s_SetStringHandler.Register( "OneServerString019", SetStringOneServerString019 );
            s_SetStringHandler.Register( "OneServerString020", SetStringOneServerString020 );
            s_SetStringHandler.Register( "OneServerString021", SetStringOneServerString021 );
            s_SetStringHandler.Register( "OneServerString022", SetStringOneServerString022 );
            s_SetStringHandler.Register( "OneServerString023", SetStringOneServerString023 );
            s_SetStringHandler.Register( "OneServerString024", SetStringOneServerString024 );
            s_SetStringHandler.Register( "OneServerString025", SetStringOneServerString025 );
            s_SetStringHandler.Register( "OneServerString026", SetStringOneServerString026 );
            s_SetStringHandler.Register( "OneServerString027", SetStringOneServerString027 );
            s_SetStringHandler.Register( "OneServerString028", SetStringOneServerString028 );
            s_SetStringHandler.Register( "OneServerString029", SetStringOneServerString029 );
            s_SetStringHandler.Register( "OneServerString030", SetStringOneServerString030 );
            s_SetStringHandler.Register( "OneServerString031", SetStringOneServerString031 );
            s_SetStringHandler.Register( "OneServerString032", SetStringOneServerString032 );
            s_SetStringHandler.Register( "OneServerString033", SetStringOneServerString033 );
            s_SetStringHandler.Register( "OneServerString034", SetStringOneServerString034 );
            #endregion

            #region zh-CHS Zone | en Zone
            s_SetStringHandler.Register( "ZoneString001", SetStringZoneString001 );
            s_SetStringHandler.Register( "ZoneString002", SetStringZoneString002 );
            s_SetStringHandler.Register( "ZoneString003", SetStringZoneString003 );
            s_SetStringHandler.Register( "ZoneString004", SetStringZoneString004 );
            s_SetStringHandler.Register( "ZoneString005", SetStringZoneString005 );
            #endregion

            #region zh-CHS ZoneCluster | en ZoneCluster
            s_SetStringHandler.Register( "ZoneClusterString001", SetStringZoneClusterString001 );
            s_SetStringHandler.Register( "ZoneClusterString002", SetStringZoneClusterString002 );
            s_SetStringHandler.Register( "ZoneClusterString003", SetStringZoneClusterString003 );
            s_SetStringHandler.Register( "ZoneClusterString004", SetStringZoneClusterString004 );
            #endregion

            #region zh-CHS Domain | en Domain
            s_SetStringHandler.Register( "DomainString001", SetStringDomainString001 );
            s_SetStringHandler.Register( "DomainString002", SetStringDomainString002 );
            s_SetStringHandler.Register( "DomainString003", SetStringDomainString003 );
            #endregion

            #region zh-CHS ScriptCompiler | en ScriptCompiler
            s_SetStringHandler.Register( "ScriptCompilerString001", SetStringScriptCompilerString001 );
            s_SetStringHandler.Register( "ScriptCompilerString002", SetStringScriptCompilerString002 );
            s_SetStringHandler.Register( "ScriptCompilerString003", SetStringScriptCompilerString003 );
            s_SetStringHandler.Register( "ScriptCompilerString004", SetStringScriptCompilerString004 );
            s_SetStringHandler.Register( "ScriptCompilerString005", SetStringScriptCompilerString005 );
            s_SetStringHandler.Register( "ScriptCompilerString006", SetStringScriptCompilerString006 );
            s_SetStringHandler.Register( "ScriptCompilerString007", SetStringScriptCompilerString007 );
            s_SetStringHandler.Register( "ScriptCompilerString008", SetStringScriptCompilerString008 );
            s_SetStringHandler.Register( "ScriptCompilerString009", SetStringScriptCompilerString009 );
            s_SetStringHandler.Register( "ScriptCompilerString010", SetStringScriptCompilerString010 );
            s_SetStringHandler.Register( "ScriptCompilerString011", SetStringScriptCompilerString011 );
            s_SetStringHandler.Register( "ScriptCompilerString012", SetStringScriptCompilerString012 );
            s_SetStringHandler.Register( "ScriptCompilerString013", SetStringScriptCompilerString013 );
            s_SetStringHandler.Register( "ScriptCompilerString014", SetStringScriptCompilerString014 );
            s_SetStringHandler.Register( "ScriptCompilerString015", SetStringScriptCompilerString015 );
            s_SetStringHandler.Register( "ScriptCompilerString016", SetStringScriptCompilerString016 );
            s_SetStringHandler.Register( "ScriptCompilerString017", SetStringScriptCompilerString017 );
            s_SetStringHandler.Register( "ScriptCompilerString018", SetStringScriptCompilerString018 );
            s_SetStringHandler.Register( "ScriptCompilerString019", SetStringScriptCompilerString019 );
            s_SetStringHandler.Register( "ScriptCompilerString020", SetStringScriptCompilerString020 );
            #endregion

            #region zh-CHS Listener | en Listener
            s_SetStringHandler.Register( "ListenerString001", SetStringListenerString001 );
            s_SetStringHandler.Register( "ListenerString002", SetStringListenerString002 );
            s_SetStringHandler.Register( "ListenerString003", SetStringListenerString003 );
            s_SetStringHandler.Register( "ListenerString004", SetStringListenerString004 );
            #endregion

            #region zh-CHS Connecter | en Connecter
            s_SetStringHandler.Register( "ConnecterString001", SetStringConnecterString001 );
            #endregion

            #region zh-CHS NetState | en NetState
            s_SetStringHandler.Register( "NetStateString001", SetStringNetStateString001 );
            s_SetStringHandler.Register( "NetStateString002", SetStringNetStateString002 );
            #endregion

            #region zh-CHS PacketReader | en PacketReader
            s_SetStringHandler.Register( "PacketReaderString001", SetStringPacketReaderString001 );
            s_SetStringHandler.Register( "PacketReaderString002", SetStringPacketReaderString002 );
            #endregion

            #region zh-CHS FileLogger | en FileLogger
            s_SetStringHandler.Register( "FileLoggerString001", SetStringFileLoggerString001 );
            #endregion

            #region zh-CHS MultiTextWriter | en MultiTextWriter
            s_SetStringHandler.Register( "MultiTextWriterString001", SetStringMultiTextWriterString001 );
            #endregion

            #region zh-CHS CallbackThreadPool | en CallbackThreadPool
            s_SetStringHandler.Register( "CallbackThreadPoolString001", SetStringCallbackThreadPoolString001 );
            #endregion

            #region zh-CHS TimerThread | en TimerThread
            s_SetStringHandler.Register( "TimerThreadString001", SetStringTimerThreadString001 );
            s_SetStringHandler.Register( "TimerThreadString002", SetStringTimerThreadString002 );
            s_SetStringHandler.Register( "TimerThreadString003", SetStringTimerThreadString003 );
            s_SetStringHandler.Register( "TimerThreadString004", SetStringTimerThreadString004 );
            s_SetStringHandler.Register( "TimerThreadString005", SetStringTimerThreadString005 );
            s_SetStringHandler.Register( "TimerThreadString006", SetStringTimerThreadString006 );
            s_SetStringHandler.Register( "TimerThreadString007", SetStringTimerThreadString007 );
            #endregion

            #region zh-CHS BaseItem | en BaseItem
            s_SetStringHandler.Register( "BaseItemString001", SetStringBaseItemString001 );
            s_SetStringHandler.Register( "BaseItemString002", SetStringBaseItemString002 );
            #endregion

            #region zh-CHS BaseCreature | en BaseCreature
            s_SetStringHandler.Register( "BaseCreatureString001", SetStringBaseCreatureString001 );
            s_SetStringHandler.Register( "BaseCreatureString002", SetStringBaseCreatureString002 );
            #endregion
        }

        #region zh-CHS BaseWorld | en BaseWorld
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseWorldString001( LanguageString globalString, string strValue )
        {
            globalString.BaseWorldString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseWorldString002( LanguageString globalString, string strValue )
        {
            globalString.BaseWorldString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseWorldString003( LanguageString globalString, string strValue )
        {
            globalString.BaseWorldString003 = strValue;
        }
        #endregion

        #region zh-CHS OneServer | en OneServer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString001( LanguageString globalString, string strValue )
        {
            globalString.OneServerString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString002( LanguageString globalString, string strValue )
        {
            globalString.OneServerString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString003( LanguageString globalString, string strValue )
        {
            globalString.OneServerString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString004( LanguageString globalString, string strValue )
        {
            globalString.OneServerString004 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString005( LanguageString globalString, string strValue )
        {
            globalString.OneServerString005 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString006( LanguageString globalString, string strValue )
        {
            globalString.OneServerString006 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString007( LanguageString globalString, string strValue )
        {
            globalString.OneServerString007 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString008( LanguageString globalString, string strValue )
        {
            globalString.OneServerString008 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString009( LanguageString globalString, string strValue )
        {
            globalString.OneServerString009 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString010( LanguageString globalString, string strValue )
        {
            globalString.OneServerString010 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString011( LanguageString globalString, string strValue )
        {
            globalString.OneServerString011 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString012( LanguageString globalString, string strValue )
        {
            globalString.OneServerString012 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString013( LanguageString globalString, string strValue )
        {
            globalString.OneServerString013 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString014( LanguageString globalString, string strValue )
        {
            globalString.OneServerString014 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString015( LanguageString globalString, string strValue )
        {
            globalString.OneServerString015 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString016( LanguageString globalString, string strValue )
        {
            globalString.OneServerString016 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString017( LanguageString globalString, string strValue )
        {
            globalString.OneServerString017 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString018( LanguageString globalString, string strValue )
        {
            globalString.OneServerString018 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString019( LanguageString globalString, string strValue )
        {
            globalString.OneServerString019 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString020( LanguageString globalString, string strValue )
        {
            globalString.OneServerString020 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString021( LanguageString globalString, string strValue )
        {
            globalString.OneServerString021 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString022( LanguageString globalString, string strValue )
        {
            globalString.OneServerString022 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString023( LanguageString globalString, string strValue )
        {
            globalString.OneServerString023 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString024( LanguageString globalString, string strValue )
        {
            globalString.OneServerString024 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString025( LanguageString globalString, string strValue )
        {
            globalString.OneServerString025 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString026( LanguageString globalString, string strValue )
        {
            globalString.OneServerString026 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString027( LanguageString globalString, string strValue )
        {
            globalString.OneServerString027 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString028( LanguageString globalString, string strValue )
        {
            globalString.OneServerString028 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString029( LanguageString globalString, string strValue )
        {
            globalString.OneServerString029 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString030( LanguageString globalString, string strValue )
        {
            globalString.OneServerString030 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString031( LanguageString globalString, string strValue )
        {
            globalString.OneServerString031 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString032( LanguageString globalString, string strValue )
        {
            globalString.OneServerString032 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString033( LanguageString globalString, string strValue )
        {
            globalString.OneServerString033 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringOneServerString034( LanguageString globalString, string strValue )
        {
            globalString.OneServerString034 = strValue;
        }
        #endregion

        #region zh-CHS Zone | en Zone
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneString001( LanguageString globalString, string strValue )
        {
            globalString.ZoneString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneString002( LanguageString globalString, string strValue )
        {
            globalString.ZoneString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneString003( LanguageString globalString, string strValue )
        {
            globalString.ZoneString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneString004( LanguageString globalString, string strValue )
        {
            globalString.ZoneString004 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneString005( LanguageString globalString, string strValue )
        {
            globalString.ZoneString005 = strValue;
        }
        #endregion

        #region zh-CHS ZoneCluster | en ZoneCluster
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneClusterString001( LanguageString globalString, string strValue )
        {
            globalString.ZoneClusterString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneClusterString002( LanguageString globalString, string strValue )
        {
            globalString.ZoneClusterString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneClusterString003( LanguageString globalString, string strValue )
        {
            globalString.ZoneClusterString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringZoneClusterString004( LanguageString globalString, string strValue )
        {
            globalString.ZoneClusterString004 = strValue;
        }
        #endregion

        #region zh-CHS Domain | en Domain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringDomainString001( LanguageString globalString, string strValue )
        {
            globalString.DomainString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringDomainString002( LanguageString globalString, string strValue )
        {
            globalString.DomainString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringDomainString003( LanguageString globalString, string strValue )
        {
            globalString.DomainString003 = strValue;
        }
        #endregion

        #region zh-CHS ScriptCompiler | en ScriptCompiler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString001( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString002( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString003( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString004( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString004 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString005( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString005 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString006( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString006 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString007( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString007 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString008( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString008 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString009( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString009 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString010( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString010 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString011( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString011 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString012( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString012 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString013( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString013 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString014( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString014 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString015( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString015 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString016( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString016 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString017( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString017 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString018( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString018 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString019( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString019 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringScriptCompilerString020( LanguageString globalString, string strValue )
        {
            globalString.ScriptCompilerString020 = strValue;
        }
        #endregion

        #region zh-CHS Listener | en Listener
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringListenerString001( LanguageString globalString, string strValue )
        {
            globalString.ListenerString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringListenerString002( LanguageString globalString, string strValue )
        {
            globalString.ListenerString002 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringListenerString003( LanguageString globalString, string strValue )
        {
            globalString.ListenerString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringListenerString004( LanguageString globalString, string strValue )
        {
            globalString.ListenerString004 = strValue;
        }
        #endregion

        #region zh-CHS Connecter | en Connecter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringConnecterString001( LanguageString globalString, string strValue )
        {
            globalString.ConnecterString001 = strValue;
        }
        #endregion

        #region zh-CHS NetState | en NetState
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringNetStateString001( LanguageString globalString, string strValue )
        {
            globalString.NetStateString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringNetStateString002( LanguageString globalString, string strValue )
        {
            globalString.NetStateString002 = strValue;
        }
        #endregion

        #region zh-CHS PacketReader | en PacketReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringPacketReaderString001( LanguageString globalString, string strValue )
        {
            globalString.PacketReaderString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringPacketReaderString002( LanguageString globalString, string strValue )
        {
            globalString.PacketReaderString002 = strValue;
        }
        #endregion

        #region zh-CHS FileLogger | en FileLogger
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringFileLoggerString001( LanguageString globalString, string strValue )
        {
            globalString.FileLoggerString001 = strValue;
        }
        #endregion

        #region zh-CHS MultiTextWriter | en MultiTextWriter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringMultiTextWriterString001( LanguageString globalString, string strValue )
        {
            globalString.MultiTextWriterString001 = strValue;
        }
        #endregion

        #region zh-CHS CallbackThreadPool | en CallbackThreadPool
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringCallbackThreadPoolString001( LanguageString globalString, string strValue )
        {
            globalString.IOCPThreadPoolString001 = strValue;
        }
        #endregion

        #region zh-CHS TimerThread | en TimerThread
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString001( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString002( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString002 = strValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString003( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString003 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString004( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString004 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString005( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString005 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString006( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString006 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringTimerThreadString007( LanguageString globalString, string strValue )
        {
            globalString.TimerThreadString007 = strValue;
        }
        #endregion

        #region zh-CHS BaseItem | en BaseItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseItemString001( LanguageString globalString, string strValue )
        {
            globalString.BaseItemString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseItemString002( LanguageString globalString, string strValue )
        {
            globalString.BaseItemString002 = strValue;
        }
        #endregion

        #region zh-CHS BaseCreature | en BaseCreature
        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseCreatureString001( LanguageString globalString, string strValue )
        {
            globalString.BaseCreatureString001 = strValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="globalString"></param>
        /// <param name="strValue"></param>
        private static void SetStringBaseCreatureString002( LanguageString globalString, string strValue )
        {
            globalString.BaseCreatureString002 = strValue;
        }
        #endregion
    }
}
#endregion