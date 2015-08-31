using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Demo_G.O.S.E.Data;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_W.O.W.SQL.Transform.Common;

namespace Demo_W.O.W.SQL.Transform
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main( string[] args )
        {
            //Console.WriteLine( "请输入数据库的连接方式：" );
            //Console.WriteLine( "譬如：mssql2005(将连接mssql数据库)" );
            //string strSQLConnection = Console.ReadLine();

            //Console.WriteLine( "请输入数据库的用户名：" );
            //Console.WriteLine( "譬如：root(登陆数据库的用户名称)" );
            //string strSQLUser = Console.ReadLine();

            //Console.WriteLine( "请输入数据库的密码：" );
            //Console.WriteLine( "譬如：root(登陆数据库的用户密码)" );
            //string strSQLPassword = Console.ReadLine();

            //Console.WriteLine( "请输入数据库的主机地址：" );
            //Console.WriteLine( "譬如：127.0.0.1(存在数据服务的主机地址)" );
            //string strSQLHost = Console.ReadLine();

            //Console.WriteLine( "请输入数据库内的数据名：" );
            //Console.WriteLine( "譬如：WorldOfWarcraft(数据服务器的服务的数据库名)" );
            //string strSQLDatabase = Console.ReadLine();

            LoadVariables();

            Database_Ver1a_To_Ver1b();
        }

        #region zh-CHS 读取Config参数 方法 | en LoadVariables Method
        /// <summary>
        /// 读取参数
        /// </summary>
        private static void LoadVariables()
        {
            //////////////////////////////////////////////////////////////////////////
            // 获取配置的信息

            XmlReaderSettings l_xmlSettings = new XmlReaderSettings();
            l_xmlSettings.ConformanceLevel = ConformanceLevel.Fragment;
            l_xmlSettings.IgnoreWhitespace = true;
            l_xmlSettings.IgnoreComments = true;

            if ( File.Exists( "W.O.W.SQL.Transform.config" ) == false )
                throw new Exception( "配置文件(W.O.W.SQL.Transform.config)没找到！" );

            XmlReader l_xmlReader = XmlReader.Create( "W.O.W.SQL.Transform.config", l_xmlSettings );

            while ( l_xmlReader.Read() == true )
            {
                switch ( l_xmlReader.NodeType )
                {
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Element:

                        //////////////////////////////////////////////////////////////////////////
                        // <G.O.S.E.Zone>
                        if ( Insensitive.Equals( l_xmlReader.Name, "SQLTransform" ) == true )
                        {
                            if ( l_xmlReader.HasAttributes == true )
                            {
                                while ( l_xmlReader.MoveToNextAttribute() == true )
                                {
                                    if ( Insensitive.Equals( l_xmlReader.Name, "Author" ) == true )
                                    {
                                        string l_strAuthor = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strAuthor, "H.Q.Cai" ) == false )
                                            throw new Exception( "W.O.W.SQL.Transform.config File - XML - Author != H.Q.Cai" );
                                    }
                                    else if ( Insensitive.Equals( l_xmlReader.Name, "Version" ) == true )
                                    {
                                        string l_strVersion = l_xmlReader.Value;

                                        if ( Insensitive.Equals( l_strVersion, "0.1" ) == false )
                                            throw new Exception( "W.O.W.SQL.Transform.config File - XML - Version != 0.1" );
                                    }
                                }

                                l_xmlReader.MoveToElement();
                            }
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // <NewSQLSetting>
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLUser" ) == true )
                        {
                            string l_strSQLUser = l_xmlReader.ReadString();

                            ConfigInfo.NewSQLUser = l_strSQLUser;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLPassword" ) == true )
                        {
                            string l_strSQLPassword = l_xmlReader.ReadString();

                            ConfigInfo.NewSQLPassword = l_strSQLPassword;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLHost" ) == true )
                        {
                            string l_strSQLHost = l_xmlReader.ReadString();

                            ConfigInfo.NewSQLHost = l_strSQLHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLPort" ) == true )
                        {
                            string l_strSQLPort = l_xmlReader.ReadString();

                            int iSQLPort = 0;
                            int.TryParse( l_strSQLPort, out iSQLPort );

                            ConfigInfo.NewSQLPort = iSQLPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLDatabase" ) == true )
                        {
                            string l_strSQLDatabase = l_xmlReader.ReadString();

                            ConfigInfo.NewSQLDatabase = l_strSQLDatabase;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "NewSQLConnection" ) == true )
                        {
                            string l_strSQLConnection = l_xmlReader.ReadString();

                            ConfigInfo.NewSQLConnection = l_strSQLConnection;
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // <OldSQLSetting>
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLUser" ) == true )
                        {
                            string l_strSQLUser = l_xmlReader.ReadString();

                            ConfigInfo.OldSQLUser = l_strSQLUser;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLPassword" ) == true )
                        {
                            string l_strSQLPassword = l_xmlReader.ReadString();

                            ConfigInfo.OldSQLPassword = l_strSQLPassword;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLHost" ) == true )
                        {
                            string l_strSQLHost = l_xmlReader.ReadString();

                            ConfigInfo.OldSQLHost = l_strSQLHost;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLPort" ) == true )
                        {
                            string l_strSQLPort = l_xmlReader.ReadString();

                            int iSQLPort = 0;
                            int.TryParse( l_strSQLPort, out iSQLPort );

                            ConfigInfo.OldSQLPort = iSQLPort;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLDatabase" ) == true )
                        {
                            string l_strSQLDatabase = l_xmlReader.ReadString();

                            ConfigInfo.OldSQLDatabase = l_strSQLDatabase;
                        }
                        else if ( Insensitive.Equals( l_xmlReader.Name, "OldSQLConnection" ) == true )
                        {
                            string l_strSQLConnection = l_xmlReader.ReadString();

                            ConfigInfo.OldSQLConnection = l_strSQLConnection;
                        }

                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                }
            }

            l_xmlReader.Close();
        }
        #endregion

        #region zh-CHS Database_Ver1a_To_Ver1b 方法 | en Database_Ver1a_To_Ver1b Method
        /// <summary>
        /// 
        /// </summary>
        private static void Database_Ver1a_To_Ver1b()
        {
            Demo_W.O.W.DatabaseVer1a.BaseDatabase.ConnectionURL = ConfigInfo.OldSQLConnection
                + "://"
                + ConfigInfo.OldSQLUser
                + ":"
                + ConfigInfo.OldSQLPassword
                + "@"
                + ConfigInfo.OldSQLHost
                //+ ( s_ConfigInfo.m_strSQLPort == 0 ? string.Empty : ":" + s_ConfigInfo.m_strSQLPort ) // 数据库引擎暂时不支持
                + "/"
                + ConfigInfo.OldSQLDatabase;

            Demo_W.O.W.DatabaseVer1b.BaseDatabase.ConnectionURL = ConfigInfo.NewSQLConnection
                + "://"
                + ConfigInfo.NewSQLUser
                + ":"
                + ConfigInfo.NewSQLPassword
                + "@"
                + ConfigInfo.NewSQLHost
                //+ ( s_ConfigInfo.m_strSQLPort == 0 ? string.Empty : ":" + s_ConfigInfo.m_strSQLPort ) // 数据库引擎暂时不支持
                + "/"
                + ConfigInfo.NewSQLDatabase;

            //////////////////////////////////////////////////////////////////////////
            // 开始连接数据库

            Console.WriteLine( Demo_W.O.W.DatabaseVer1a.BaseDatabase.ConnectionURL );
            //Console.WriteLine( Demo_W.O.W.DatabaseVer1b.BaseDatabase.ConnectionURL );

            //Demo_W.O.W.DatabaseVer1b.BaseDatabase.BuildRecreate();

            Demo_W.O.W.DatabaseVer1a.BaseDatabase.BuildDefault();


            bool l_bIsReturn = false;

            Session l_SessionVer1a = new Session( Demo_W.O.W.DatabaseVer1a.BaseDatabase.Domain );
            //Session l_SessionVer1b = new Session( Demo_W.O.W.DatabaseVer1b.BaseDatabase.Domain );

            l_SessionVer1a.BeginTransaction();
            //l_SessionVer1b.BeginTransaction();
            {
                do
                {
                    Query l_QueryAccountsVer1a = new Query( l_SessionVer1a, "Select Accounts instances" );
                    QueryResult l_AccountsResultVer1a = l_QueryAccountsVer1a.Execute();

                    //Query l_QueryAccountsVer1b = new Query( l_SessionVer1b, "Select Accounts instances" );
                    //QueryResult l_AccountsResultVer1b = l_QueryAccountsVer1b.Execute();


                } while ( false );
            }
            l_SessionVer1a.Commit();
            //l_SessionVer1b.Commit();

            if ( l_bIsReturn == true )
                return;

            Console.WriteLine( "完成数据库的转换工作，按任意键退出！" );
            Console.ReadKey();
        }
        #endregion
    }
}
