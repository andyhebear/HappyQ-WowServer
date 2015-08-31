using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Demo_G.O.S.E.HardwareID.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckSerialNumber
    {
        /// <summary>
        /// 
        /// </summary>
        private static string s_PasswordFileName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static bool s_OpenFileInfoFinish = false;
        /// <summary>
        /// 
        /// </summary>
        private static string s_NameInfo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string s_CompanyInfo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string s_CustomInfo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string s_PasswordInfo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private static string s_SmartKeyInfo = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static bool s_OpenFileFinish = false;
        /// <summary>
        /// 
        /// </summary>
        private static XmlReader s_PasswordXmlReader = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPasswordFile"></param>
        public static void Init( string strPasswordFile )
        {
            s_PasswordFileName = strPasswordFile;

            StringBuilder strBufferVarValue = new StringBuilder( 100 );
            Kernel32.GetEnvironmentVariable( "WLRegGetStatus", strBufferVarValue, 100 );

            int iTrialStatus = 0;
            try
            {
                iTrialStatus = System.Convert.ToInt32( strBufferVarValue.ToString() );
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            switch ( iTrialStatus )
            {
                case 0:
                    //"Trial";
                    Process.GetCurrentProcess().Kill();

                    break;

                case 1:
                    //"Registered";
                    break;

                case 2:
                    //"License key INVALID";
                    Process.GetCurrentProcess().Kill();

                    break;

                case 3:
                    //"Wrong Hardware ID for current machine";
                    Process.GetCurrentProcess().Kill();

                    break;

                case 4:
                    //"No more Hardware ID changes allowed";
                    Process.GetCurrentProcess().Kill();

                    break;

                case 5:
                    //"License key expired";
                    Process.GetCurrentProcess().Kill();

                    break;
            }

            Thread thread = new Thread( CheckSerialNumber.OpenFileThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void OpenFileThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
                xmlSettings.IgnoreWhitespace = true;
                xmlSettings.IgnoreComments = true;

                s_PasswordXmlReader = XmlReader.Create( s_PasswordFileName, xmlSettings );

                s_OpenFileFinish = true;
            }
            finally
            {
            }

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            Thread thread = new Thread( CheckSerialNumber.ReadFileInfoThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ReadFileInfoThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            try
            {
                s_OpenFileInfoFinish = LoadVariables();

                s_PasswordXmlReader.Close();
            }
            finally
            {
            }

            if ( s_OpenFileInfoFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            Thread thread = new Thread( CheckSerialNumber.CheckHardwareIDInfoThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool LoadVariables()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            while ( s_PasswordXmlReader.Read() == true )
            {
                switch ( s_PasswordXmlReader.NodeType )
                {
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Element:

                        ////////////////////////////////////////////////////////////////////////////
                        //// <Settings>
                        if ( CaseInsensitiveComparer.Default.Compare( s_PasswordXmlReader.Name, "Name" ) == 0 )
                        {
                            string strNameInfo = s_PasswordXmlReader.ReadString();

                            s_NameInfo = strNameInfo;
                        }
                        else if ( CaseInsensitiveComparer.Default.Compare( s_PasswordXmlReader.Name, "Company" ) == 0 )
                        {
                            string strCompanyInfo = s_PasswordXmlReader.ReadString();

                            s_CompanyInfo = strCompanyInfo;
                        }
                        else if ( CaseInsensitiveComparer.Default.Compare( s_PasswordXmlReader.Name, "Custom" ) == 0 )
                        {
                            string strCustomInfo = s_PasswordXmlReader.ReadString();

                            s_CustomInfo = strCustomInfo;
                        }
                        else if ( CaseInsensitiveComparer.Default.Compare( s_PasswordXmlReader.Name, "Password" ) == 0 )
                        {
                            string strPasswordInfo = s_PasswordXmlReader.ReadString();

                            s_PasswordInfo = strPasswordInfo;
                        }
                        else if ( CaseInsensitiveComparer.Default.Compare( s_PasswordXmlReader.Name, "SmartKey" ) == 0 )
                        {
                            string strSmartKeyInfo = s_PasswordXmlReader.ReadString();

                            s_SmartKeyInfo = strSmartKeyInfo;
                        }

                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                }
            }

            if ( s_NameInfo == string.Empty ||
                s_CompanyInfo == string.Empty ||
                s_CustomInfo == string.Empty ||
                s_PasswordInfo == string.Empty ||
                s_SmartKeyInfo == string.Empty )
            {
                Process.GetCurrentProcess().Kill();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CheckHardwareIDInfoThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( s_OpenFileInfoFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            StringBuilder strHardwareID = new StringBuilder( 100 );
            Kernel32.GetEnvironmentVariable( "WLHardwareGetID", strHardwareID, 100 );
            Kernel32.GetEnvironmentVariable( "WLHardwareCheckID", strHardwareID, 100 );

            int iStatus = 0;
            try
            {
                iStatus = System.Convert.ToInt32( strHardwareID.ToString() );
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( iStatus != 1 )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            Thread thread = new Thread( CheckSerialNumber.CheckPasswordInfoThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CheckPasswordInfoThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( s_OpenFileInfoFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            StringBuilder strPasswordInfo = new StringBuilder( 500 );
            strPasswordInfo.Append( s_NameInfo );
            strPasswordInfo.Append( "," );
            strPasswordInfo.Append( s_PasswordInfo );

            //Kernel32.GetEnvironmentVariable( "WLPasswordCheck", strPasswordInfo, 500 );

            //int iStatus = 0;
            //try
            //{
            //    iStatus = System.Convert.ToInt32( strPasswordInfo.ToString() );
            //}
            //catch
            //{
            //    Process.GetCurrentProcess().Kill();
            //    return;
            //}

            //if ( iStatus != 1 )
            //{
            //    Process.GetCurrentProcess().Kill();
            //    return;
            //}

            Thread thread = new Thread( CheckSerialNumber.CheckSmartKeyInfoThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CheckSmartKeyInfoThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( s_OpenFileInfoFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            StringBuilder strSmartKeyInfo = new StringBuilder( 500 );
            strSmartKeyInfo.Append( s_NameInfo );
            strSmartKeyInfo.Append( "," );
            strSmartKeyInfo.Append( s_CompanyInfo );
            strSmartKeyInfo.Append( "," );
            strSmartKeyInfo.Append( s_CustomInfo );
            strSmartKeyInfo.Append( "," );
            strSmartKeyInfo.Append( s_SmartKeyInfo );

            Kernel32.GetEnvironmentVariable( "WLRegSmartKeyCheck", strSmartKeyInfo, 500 );

            int iStatus = 0;
            try
            {
                iStatus = System.Convert.ToInt32( strSmartKeyInfo.ToString() );
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( iStatus != 1 )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            Thread thread = new Thread( CheckSerialNumber.CheckIPAddressThreadStart );
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static string s_RemoteIPAddress = "7Jq0+X97MX6Ybe8QH44whg==";
        /// <summary>
        /// 
        /// </summary>
        private static string s_Base64KEY = "FwGQWRRgKCI=";
        /// <summary>
        /// 
        /// </summary>
        private static string s_Base64IV = "kXwL7X2+fgM=";
        /// <summary>
        /// 
        /// </summary>
        private static void CheckIPAddressThreadStart()
        {
            Random randomTime = new Random();
            Thread.Sleep( randomTime.Next( 60 * 5 ) * 1000 );

            if ( s_OpenFileFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if ( s_OpenFileInfoFinish == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            string strRemoteIPAddress = StringCrypto.DecryptString( s_Base64KEY, s_Base64IV, s_RemoteIPAddress );

            IPAddress[] remoteIPAddressArray = Dns.GetHostAddresses( strRemoteIPAddress );
            if ( remoteIPAddressArray == null )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            IPAddress[] machineIPAddressArray = Dns.GetHostAddresses( Environment.MachineName );
            if ( machineIPAddressArray == null )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            bool isFind = false;
            foreach ( IPAddress machineIPAddress in machineIPAddressArray )
            {
                foreach ( IPAddress remoteIPAddress in remoteIPAddressArray )
                {
                    if ( machineIPAddress.ToString() == remoteIPAddress.ToString() )
                    {
                        isFind = true;
                        break;
                    }
                }

                if ( isFind == true )
                    break;
            }

            if ( isFind == false )
            {
                Process.GetCurrentProcess().Kill();
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strString"></param>
        internal static void CryptoStringToFile( string strString )
        {
            string strReturn = StringCrypto.EncryptString( s_Base64KEY, s_Base64IV, strString );

            StreamWriter StreamWriter = File.CreateText( "CryptoString.txt" );
            StreamWriter.WriteLine( strReturn );

            StreamWriter.Close();
        }
    }

    /// <summary>
    /// Class: Kernel32
    /// Description: Wrapper for Kernel32 Dll
    /// </summary>
    class Kernel32
    {
        [DllImport( "Kernel32.dll", EntryPoint = "GetEnvironmentVariable", CallingConvention = CallingConvention.StdCall )]
        public static extern int GetEnvironmentVariable( string lpName, StringBuilder lpBuffer, int nSize );
    }
}

