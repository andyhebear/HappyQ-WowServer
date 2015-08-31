#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Net;
using Demo_G.O.S.E.Data;
using System.Diagnostics;
using Demo_G.O.S.E.ServerEngine.Util;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Database;
using Demo_R.O.S.E.Database.Model;
using Demo_R.O.S.E.LoginServer.Common;
using Demo_G.O.S.E.ServerEngine.Common;
using System.Threading;
#endregion

namespace Demo_R.O.S.E.LoginServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class LoginPacketHandlers
    {
        #region zh-CHS LoginServer ConnectToChar - 数据处理 | en LoginServer ConnectToChar - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerConnectFromCharServer( NetState netState, PacketReader packetReader )
        {
            // 错误 不可能有创建
            if ( netState.ExtendData is CharServerExtendData == true )
                return;
            else
                netState.ExtendData = null;

            if ( packetReader.Size < 14/*6 + 8 + ?*/ )
                return;

            // 不检查网络是否活动
            netState.IsCheckActivity = false;

            long l_iCharGUID = packetReader.ReadUInt32();
            long l_iCharPort = packetReader.ReadUInt32();
            string l_strLoginPassword = packetReader.ReadStringSafe();

            if ( l_strLoginPassword == Program.ConfigInfo.LoginPassword )
            {
                CharServerExtendData l_ExtendData = new CharServerExtendData();

                l_ExtendData.IsLoggedIn = true;
                l_ExtendData.CharGUID = l_iCharGUID;
                l_ExtendData.CharHost = netState.NetAddress.ToString();
                l_ExtendData.CharPort = l_iCharPort;

                netState.ExtendData = l_ExtendData;

                Program.CharServerList.Add(l_ExtendData);

                l_ExtendData.ConnectToCharServer( l_ExtendData.CharHost, l_ExtendData.CharPort );
            }
        }
        #endregion

        #region zh-CHS LoginServer EncryptionRequest - 数据处理 | en LoginServer EncryptionRequest - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerEncryptionRequest( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "LoginPacketHandlers.LoginServerEncryptionRequest(...){0}", Thread.CurrentThread.Name );

            netState.Send( new EncryptionRequestAck() );
        }
        #endregion

        #region zh-CHS LoginServer AccountLogin - 数据处理 | en LoginServer AccountLogin - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerAccountLogin( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "LoginPacketHandlers.LoginServerAccountLogin(...){0}", Thread.CurrentThread.Name );

            LoginServerExtendData l_ExtendData = netState.ExtendData as LoginServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - l_ExtendData == null error!" );
                
                AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - l_ExtendData.IsLoggedIn == true error!" );

                AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );
                return;
            }

            if ( packetReader.Size < 38/*6 + 32*/ )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - packetReader.Size < 38 error!" );
                
                AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );
                return;
            }

            string l_strPassword = packetReader.ReadString( 32 );
            string l_strUsername = packetReader.ReadStringSafe();

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryAccounts = new Query( l_Session, "Select Accounts instances where {AccountsName}=@Username" );
                    l_QueryAccounts.Parameters.Add( "@Username", l_strUsername );
                    QueryResult l_AccountsResult = l_QueryAccounts.Execute();

                    if ( l_AccountsResult == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - l_AccountsResult == null error!" );
                        
                        AccountLogin_ReplyRej( netState, LoginReason.NameError );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_AccountsResult.Count != 1 )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - l_AccountsResult.Count != 1 error!" );

                        AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_AccountsResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerAccountLogin(...) - l_Accounts == null error!" );

                        AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Banned == true || l_Accounts.GMLevel < 0 )
                    {
                        AccountLogin_ReplyRej( netState, LoginReason.Blocked );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Locked == true )
                    {
                        AccountLogin_ReplyRej( netState, LoginReason.InUse );

                        for ( int iIndex = 0; iIndex < Program.CharServerList.Count; iIndex++ )
                            Program.CharServerList[iIndex].SendToCharServer( (int)l_Accounts.AccountsGuid );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Password != l_strPassword )
                    {
                        AccountLogin_ReplyRej( netState, LoginReason.PasswordError );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ExtendData.AccountsGuid = l_Accounts.AccountsGuid;
                    l_ExtendData.IsLoggedIn = true;
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            AccountLoginEventArgs l_EventArgs = new AccountLoginEventArgs( netState, l_strUsername, l_strPassword );
            EventSink.InvokeAccountLogin( l_EventArgs );

            if ( l_EventArgs.Accepted )
                AccountLogin_ReplyAck( netState );
            else
                AccountLogin_ReplyRej( netState, l_EventArgs.RejectReason );
        }

        #region zh-CHS 成员变量 | en Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static ServerInfo[] s_ServerInfoArray = new ServerInfo[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void AccountLogin_ReplyAck( NetState netState )
        {
            bool l_bIsReturn = false;
            ServerInfo[] l_ServerInfoArray = s_ServerInfoArray;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryChannels = new Query( l_Session, "Select Channels instances where {OwnerGuid}=0" );
                    QueryResult l_ChannelsResult = l_QueryChannels.Execute();

                    if ( l_ChannelsResult == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.AccountLogin_ReplyAck(...) - l_ChannelsResult == null error!" );

                        AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ChannelsResult.Count <= 0 )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.AccountLogin_ReplyAck(...) - l_ChannelsResult.Count <= 0 error!" );

                        AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ServerInfoArray = new ServerInfo[l_ChannelsResult.Count];
                    for ( int iIndex = 0; iIndex < l_ServerInfoArray.Length; iIndex++ )
                    {
                        Channels l_Channels = l_ChannelsResult[iIndex] as Channels;
                        if ( l_Channels == null )
                        {
                            Debug.WriteLine( "LoginServerPacketHandlers.AccountLogin_ReplyAck(...) - l_Channels == null error!" );

                            AccountLogin_ReplyRej( netState, LoginReason.LoginFailed );

                            l_bIsReturn = true;
                            break;
                        }

                        l_ServerInfoArray[iIndex] = new ServerInfo( l_Channels.ServerName, l_Channels.ServerGuid, l_Channels.Status, TimeZone.CurrentTimeZone, new IPEndPoint( IPAddress.Parse( l_Channels.Host ), l_Channels.Port ) );
                    }

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            //ServerListEventArgs l_EventArgs = new ServerListEventArgs( netState, netState.Account );
            //EventSink.InvokeServerList( l_EventArgs );

            //if ( l_EventArgs.Rejected == true )
            //{
            //    netState.Account = null;
            //    netState.Send( new AccountLoginRej( LoginReason.LoginFailed ) );
            //    netState.Dispose();
            //}
            //else
            {
                //ServerInfo[] info = e.Servers.ToArray();
                //netState.ServerInfo = l_ServerInfo;

                netState.Send( new AccountLoginAck( l_ServerInfoArray ) );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="alrReason"></param>
        internal static void AccountLogin_ReplyRej( NetState netState, LoginReason alrReason )
        {
            netState.Send( new AccountLoginRej( alrReason ) );
        }
        #endregion

        #region zh-CHS LoginServer GetServerNameList - 数据处理 | en LoginServer GetServerNameList - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerGetServerNameList( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "LoginPacketHandlers.LoginServerGetServerNameList(...){0}", Thread.CurrentThread.Name );
            
            LoginServerExtendData l_ExtendData = netState.ExtendData as LoginServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_ExtendData.IsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 10/*6 + 4*/ )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - packetReader.Size < 10 error!" );
                return;
            }

            int l_iChannelGuid = packetReader.ReadInt32();

            bool l_bIsReturn = false;
            ServerInfo[] l_ServerInfoArray = new ServerInfo[0];
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryChannels = new Query( l_Session, "Select Channels instances where {OwnerGuid}=@ChannelGuid" );
                    l_QueryChannels.Parameters.Add( "@ChannelGuid", l_iChannelGuid );
                    QueryResult l_ChannelsResult = l_QueryChannels.Execute();

                    if ( l_ChannelsResult == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_ChannelsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ChannelsResult.Count <= 0 )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_ChannelsResult.Count <= 0 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ServerInfoArray = new ServerInfo[l_ChannelsResult.Count];
                    for ( int iIndex = 0; iIndex < l_ChannelsResult.Count; iIndex++ )
                    {
                        Channels l_Channels = l_ChannelsResult[iIndex] as Channels;
                        if ( l_Channels == null )
                        {
                            Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_Channels == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        long iFullPercent = ( ( ( 100 * l_Channels.Connected ) / l_Channels.MaxConnected == 0 ? 1 : l_Channels.MaxConnected ) / 5 ) & 0xFF;
                        l_ServerInfoArray[iIndex] = new ServerInfo( l_Channels.ServerName, l_Channels.ServerGuid, iFullPercent, TimeZone.CurrentTimeZone, new IPEndPoint( IPAddress.Parse( l_Channels.Host ), l_Channels.Port ) );
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            netState.Send( new GetServerNameListAck( l_ServerInfoArray, l_iChannelGuid ) );
        }
        #endregion

        #region zh-CHS LoginServer GetServerIPList - 数据处理 | en LoginServer GetServerIPList - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerGetServerIP( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NOTICE, "LoginPacketHandlers.LoginServerGetServerIP(...){0}", Thread.CurrentThread.Name );
            
            LoginServerExtendData l_ExtendData = netState.ExtendData as LoginServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIP(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIP(...) - l_ExtendData.IsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 11 /*6 + 5*/)
            {
                Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIP(...) - packetReader.Size < 11 error!" );
                return;
            }

            int l_iServerGuid = packetReader.ReadInt32();
            int l_iChannelGuid = packetReader.ReadByte();


            bool l_bIsReturn = false;
            ServerInfo l_ServerInfo = null;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryAccounts = new Query( l_Session, "Select Accounts instances where {AccountsGuid}=@AccountGuid" );
                    l_QueryAccounts.Parameters.Add( "@AccountGuid", l_ExtendData.AccountsGuid );
                    QueryResult l_AccountsResult = l_QueryAccounts.Execute();

                    if ( l_AccountsResult == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIP(...) - l_AccountsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_AccountsResult.Count != 1 )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIPList(...) - l_AccountsResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_AccountsResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerNameList(...) - l_Accounts == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Accounts.LastLoginDate = DateTime.Now;
                    l_Accounts.LastServerGuid = l_iChannelGuid;
                    l_Accounts.LastIP = netState.NetAddress.ToString();


                    //////////////////////////////////////////////////////////////////////////
                    

                    Query l_QueryChannels = new Query( l_Session, "Select Channels instances where {ServerGuid}=@ServerGuid" );
                    l_QueryChannels.Parameters.Add( "@ServerGuid", l_iServerGuid );
                    QueryResult l_ChannelsResult = l_QueryChannels.Execute();

                    if ( l_ChannelsResult == null )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIP(...) - l_ChannelsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ChannelsResult.Count != 1 )
                    {
                        Debug.WriteLine( "LoginServerPacketHandlers.LoginServerGetServerIPList(...) - l_ChannelsResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Channels l_Channels = l_ChannelsResult[0] as Channels;
                    if ( l_Channels == null )
                    {
                        Debug.WriteLine( "PacketHandlers.LoginServerGetServerNameList(...) - l_Channels == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ServerInfo = new ServerInfo( l_Channels.ServerName, l_Channels.ServerGuid, l_Channels.Status, TimeZone.CurrentTimeZone, new IPEndPoint( IPAddress.Parse( l_Channels.Host ), l_Channels.Port ) );
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            if ( l_ServerInfo != null )
                netState.Send( new GetServerIPAck( l_ServerInfo, (int)l_ExtendData.AccountsGuid ) );
        }
        #endregion
    }
}
#endregion