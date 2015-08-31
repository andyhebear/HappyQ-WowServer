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
using System.Reflection;
using System.Diagnostics;
using Demo_G.O.S.E.Data;
using Demo_R.O.S.E.Mobile;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Database;
using Demo_R.O.S.E.Database.Model;
using Demo_R.O.S.E.CharServer.Common;
using Demo_G.O.S.E.ServerEngine.BuildScripts;
#endregion

namespace Demo_R.O.S.E.CharServer.Network
{
    class CharPacketHandlers
    {
        #region zh-CHS CharacterServer CharServerConnectToWorld - 数据处理 | en CharacterServer CharServerConnectToWorld - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharServerConnectToWorld( NetState netState, PacketReader packetReader )
        {
            // 错误 不可能有创建
            if ( netState.ExtendData is WorldServerExtendData == true )
            {
                Debug.WriteLine( "CharPacketHandlers.CharServerConnectToWorld(...) - netState.ExtendData is WorldServerExtendData == true error!" );
                return;
            }
            else
                netState.ExtendData = null;

            // 不检查网络是否活动
            netState.IsCheckActivity = false;

            if ( packetReader.Size < 10/*6 + 4 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharServerConnectToWorld(...) - packetReader.Size < 10 error!" );
                return;
            }

            long l_iWorldGUID = packetReader.ReadUInt32();
            long l_iWorldPort = packetReader.ReadUInt32();
            string l_strCharPassword = packetReader.ReadStringSafe();

            if ( l_strCharPassword == Program.ConfigInfo.CharPassword )
            {
                WorldServerExtendData l_ExtendData = new WorldServerExtendData();

                l_ExtendData.IsLoggedIn = true;

                l_ExtendData.WorldGUID = l_iWorldGUID;
                l_ExtendData.WorldHost = netState.NetAddress.ToString();
                l_ExtendData.WorldPort = l_iWorldPort;
                l_ExtendData.NetState = netState;

                netState.ExtendData = l_ExtendData;

                Program.AddWorldServerList( l_ExtendData );

                l_ExtendData.ConnectToWorldServer( l_ExtendData.WorldHost, l_ExtendData.WorldPort );
            }
        }
        #endregion

        #region zh-CHS CharacterServer LoginServerConnected - 数据处理 | en CharacterServer LoginConnected - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerConnected( NetState netState, PacketReader packetReader )
        {
            // 错误 不可能有创建
            if ( netState.ExtendData is LoginServerExtendData == true )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginConnected(...) - netState.ExtendData is LoginServerExtendData == true error!" );
                return;
            }
            else
                netState.ExtendData = null;

            if ( packetReader.Size < 6/*6 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginConnected(...) - packetReader.Size < 6 error!" );
                return;
            }

            // 不检查网络是否活动
            netState.IsCheckActivity = false;

            string l_strCharPassword = packetReader.ReadStringSafe();

            if ( l_strCharPassword == Program.ConfigInfo.CharPassword )
            {
                LoginServerExtendData l_ExtendData = new LoginServerExtendData();

                l_ExtendData.IsLoggedIn = true;

                netState.ExtendData = l_ExtendData;
            }
        }
        #endregion

        #region zh-CHS CharacterServer LoginServerAction - 数据处理 | en CharacterServer LoginDSClient - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void LoginServerAction( NetState netState, PacketReader packetReader )
        {
            LoginServerExtendData l_ExtendData = netState.ExtendData as LoginServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            byte l_Action = packetReader.ReadByte();

            switch ( l_Action )
            {
                case 1:
                    long l_iAccountGuid = packetReader.ReadUInt32();

                    LoginServer_Action01( netState, l_iAccountGuid );

                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="iAccountGuid"></param>
        internal static void LoginServer_Action01( NetState netState, long iAccountGuid )
        {
            NetState l_NetState = ProcessNet.GetClientByAccountGuid( iAccountGuid );
            if ( l_NetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_NetState == null error!" );
                return;
            }

            CharServerExtendData l_CharExtendData = l_NetState.ExtendData as CharServerExtendData;
            if ( l_CharExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_CharExtendData == null error!" );
                return;
            }

            if ( l_CharExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_CharExtendData.IsLoggedIn == false error!" );
                return;
            }

            NetState l_WorldNetState = ProcessNet.GetClientByWorldServerGuid( l_CharExtendData.ServerGuid );
            if ( l_WorldNetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_WorldNetState == null error!" );
                return;
            }

            WorldServerExtendData l_WorldExtendData = l_WorldNetState.ExtendData as WorldServerExtendData;
            if ( l_WorldExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_WorldExtendData == null error!" );
                return;
            }

            if ( l_WorldExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_WorldExtendData.IsLoggedIn == false error!" );
                return;
            }

            l_WorldExtendData.SendToWorldServer_0x502_Action01( iAccountGuid );
        }
        #endregion

        #region zh-CHS CharacterServer WorldServerAction - 数据处理 | en CharacterServer WSCharSelect - OnPacketReceive
        /// <summary>
        /// 选择新的人物
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void WorldServerAction( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 10/*6 + 4*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - packetReader.Size < 10 error!" );
                return;
            }


            uint iAccountGuid = packetReader.ReadUInt32();

            NetState l_NetState = ProcessNet.GetClientByAccountGuid( iAccountGuid );
            if ( l_NetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_NetState == null error!" );
                return;
            }

            CharServerExtendData l_CharExtendData = l_NetState.ExtendData as CharServerExtendData;
            if ( l_CharExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_CharExtendData == null error!" );
                return;
            }

            if ( l_CharExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_CharExtendData.IsLoggedIn == false error!" );
                return;
            }

            l_NetState.Send( new WorldActionAck() );

            NetState l_WorldNetState = ProcessNet.GetClientByWorldServerGuid( l_CharExtendData.ServerGuid );
            if ( l_WorldNetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_WorldNetState == null error!" );
                return;
            }

            WorldServerExtendData l_WorldExtendData = l_WorldNetState.ExtendData as WorldServerExtendData;
            if ( l_WorldExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_WorldExtendData == null error!" );
                return;
            }

            if ( l_WorldExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.WorldAction(...) - l_WorldExtendData.IsLoggedIn == false error!" );
                return;
            }

            l_WorldExtendData.SendToWorldServer_0x505( iAccountGuid );
        }
        #endregion

        #region zh-CHS CharacterServer DoIdentify - 数据处理 | en CharacterServer DoIdentify - OnPacketReceive
        /// <summary>
        /// Do player identification
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerDoIdentify( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 42/*( 6 + 4 + 32)*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - packetReader.Size < 42 error!" );
                return;
            }

            int l_iAccountGuid = packetReader.ReadInt32();
            string l_strPassword = packetReader.ReadString( 32 );

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryAccounts = new Query( l_Session, "Select Accounts instances where {AccountsGuid}=@AccountGuid" );
                    l_QueryAccounts.Parameters.Add( "@AccountGuid", l_iAccountGuid );
                    QueryResult l_AccountsResult = l_QueryAccounts.Execute();

                    if ( l_AccountsResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_AccountsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_AccountsResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_AccountsResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_AccountsResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_Accounts == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Password != l_strPassword )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    //if ( l_Accounts.Locked == true )
                    //{
                    //    l_bIsReturn = true;
                    //    break;
                    //}
                    //else
                    //    l_Accounts.Locked = true; // 用户已成功登陆 锁定帐户

                    l_ExtendData.AccountGuid = l_Accounts.AccountsGuid;
                    l_ExtendData.ServerGuid = l_Accounts.LastServerGuid;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            l_ExtendData.IsLoggedIn = true;
            Program.AddCharServerList( l_ExtendData );

            netState.Send( new DoIdentifyAck() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        internal static void DisconnectNetState( NetState netState )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            // 该先通知世界服务器人物已经断开
            // 。。。。。。

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryAccounts = new Query( l_Session, "Select Accounts instances where {AccountsGuid}=@AccountGuid" );
                    l_QueryAccounts.Parameters.Add( "@AccountGuid", l_ExtendData.AccountGuid );
                    QueryResult l_AccountsResult = l_QueryAccounts.Execute();

                    if ( l_AccountsResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_AccountsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_AccountsResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_AccountsResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_AccountsResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDoIdentify(...) - l_Accounts == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Locked )
                        l_Accounts.Locked = false; // 用户已成功断开 取消锁定的帐户

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            l_ExtendData.IsLoggedIn = false;
        }
        #endregion

        #region zh-CHS CharacterServer GetCharacters - 数据处理 | en CharacterServer GetCharacters - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        private static PacketCharacter[] s_CharacterArray = new PacketCharacter[0];
        /// <summary>
        /// Get this clients character list
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerGetCharacters( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            bool l_bIsReturn = false;
            PacketCharacter[] l_CharacterArray = s_CharacterArray;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {AccountGuid}=@AccountGuid" );
                    l_QueryCharacters.Parameters.Add( "@AccountGuid", l_ExtendData.AccountGuid );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count <= 0 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_CharactersResult.Count <= 0 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    // 如果大于5, 则检测看有效的是否超过5个，其余者为删除的人物
                    if ( l_CharactersResult.Count > 5 )
                    {
                        int l_iCharactersCount = 0;
                        for ( int iIndex = 0; iIndex < l_CharactersResult.Count; iIndex++ )
                        {
                            Characters l_Characters = l_CharactersResult[iIndex] as Characters;
                            if ( l_Characters == null )
                            {
                                Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_Characters == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            if ( l_Characters.DeleteTime != null && l_Characters.DeleteTime < DateTime.Now )
                                l_Characters.IsDelete = true;

                            if ( l_Characters.IsDelete == false )
                                ++l_iCharactersCount;
                        }

                        if ( l_bIsReturn == true )
                            break;

                        if ( l_iCharactersCount > 5 )
                        {
                            Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_iCharactersCount > 5 error!" );

                            l_bIsReturn = true;
                            break;
                        }
                    }

                    l_CharacterArray = new PacketCharacter[l_CharactersResult.Count];
                    for ( int iIndex = 0; iIndex < l_CharacterArray.Length; iIndex++ )
                    {
                        Characters l_Characters = l_CharactersResult[iIndex] as Characters;
                        if ( l_Characters == null )
                        {
                            Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_Characters == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_Characters.IsDelete == true )
                            continue;

                        l_CharacterArray[iIndex] = new PacketCharacter();
                        l_CharacterArray[iIndex].m_CharacterName = l_Characters.CharacterName;
                        l_CharacterArray[iIndex].m_CharacterGuid = (uint)l_Characters.CharacterGuid;
                        l_CharacterArray[iIndex].m_Level = (uint)l_Characters.Level;
                        l_CharacterArray[iIndex].m_Face = (uint)l_Characters.Face;
                        l_CharacterArray[iIndex].m_HairStyle = (uint)l_Characters.HairStyle;
                        l_CharacterArray[iIndex].m_ClassID = (uint)l_Characters.ClassID;
                        l_CharacterArray[iIndex].m_Sex = l_Characters.Sex;
                        l_CharacterArray[iIndex].m_DeleteTime = l_Characters.DeleteTime == DateTime.MaxValue ? 0 : GetTime( l_Characters.DeleteTime ) - GetTime();
                        l_CharacterArray[iIndex].m_Item = new PacketCharacter.PacketItem[10]; // 10 表示的是身上的物件数

                        for ( int iIndexItem = 0; iIndexItem < l_CharacterArray[iIndex].m_Item.Length; iIndexItem++ )
                            l_CharacterArray[iIndex].m_Item[iIndexItem] = new PacketCharacter.PacketItem();

                        Query l_QueryItems = new Query( l_Session, "Select Items instances where {CharacterGuid}=@CharacterGuid and {SlotNumber}<10" );
                        l_QueryItems.Parameters.Add( "@CharacterGuid", l_Characters.CharacterGuid );
                        QueryResult l_ItemsResult = l_QueryItems.Execute();

                        if ( l_ItemsResult == null )
                        {
                            Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_ItemsResult == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_ItemsResult.Count > 10 )
                        {
                            Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_ItemsResult.Count > 10 error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        for ( int iIndex2 = 0; iIndex2 < l_ItemsResult.Count; iIndex2++ )
                        {
                            Items l_Items = l_ItemsResult[iIndex2] as Items;
                            if ( l_Items == null )
                            {
                                Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_Items == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            if ( l_Items.SlotNumber > 10 )
                            {
                                Debug.WriteLine( "CharPacketHandlers.CharacterServerGetCharacters(...) - l_Items.SlotNumber > 10 error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_CharacterGuid = (uint)l_Items.CharacterGuid;
                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_ItemID = (uint)l_Items.ItemID;
                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_ItemType = (uint)l_Items.ItemType;
                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_Refine = (uint)l_Items.Refine;
                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_Durability = (uint)l_Items.Durability;
                            l_CharacterArray[iIndex].m_Item[l_Items.SlotNumber].m_Lifespan = (uint)l_Items.Lifespan;
                        }
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                l_CharacterArray = s_CharacterArray;

            netState.Send( new GetCharactersAck( l_CharacterArray ) );
        }

        /// <summary>
        /// Returns the current time/date
        /// </summary>
        /// <returns></returns>
        private static uint GetTime()
        {
            DateTime l_NowDateTime = DateTime.Now;
            uint uCurTime = 0;
            uCurTime += (uint)( l_NowDateTime.Second * 1 );
            uCurTime += (uint)( l_NowDateTime.Minute * 60 );
            uCurTime += (uint)( l_NowDateTime.Hour * 3600 );
            uCurTime += (uint)( l_NowDateTime.Day * 86400 );
            uCurTime += (uint)( ( l_NowDateTime.Year - 2000 ) * 86400 * 366 );
            return uCurTime;
        }

        /// <summary>
        /// Returns the this time/date
        /// </summary>
        /// <returns></returns>
        private static uint GetTime( DateTime dateTime )
        {
            uint uCurTime = 0;
            uCurTime += (uint)( dateTime.Second * 1 );
            uCurTime += (uint)( dateTime.Minute * 60 );
            uCurTime += (uint)( dateTime.Hour * 3600 );
            uCurTime += (uint)( dateTime.Day * 86400 );
            uCurTime += (uint)( ( dateTime.Year - 2000 ) * 86400 * 366 );
            return uCurTime;
        }
        #endregion

        #region zh-CHS CharacterServer CreateChar - 数据处理 | en CharacterServer CreateChar - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerCreateCharacter( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_ExtendData == null error!" );

                CreateCharacter_ReplyRej( netState, CCLReason.BadAccountName );
                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                CreateCharacter_ReplyRej( netState, CCLReason.BadAccountName );
                return;
            }

            if ( packetReader.Size < 13/*6 + 7 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - packetReader.Size < 13 error!" );

                CreateCharacter_ReplyRej( netState, CCLReason.BadAccountName );
                return;
            }

            // 给出需要创建的人物信息
            sbyte l_iSex = (sbyte)( packetReader.ReadSByte() % 2 );
            sbyte l_iUnknown = packetReader.ReadSByte();
            sbyte l_iHairStyle = packetReader.ReadSByte();
            sbyte l_iFace = packetReader.ReadSByte();
            sbyte l_iUnknown2 = packetReader.ReadSByte();
            ushort l_iUnknown3 = packetReader.ReadUInt16();
            string l_strNewCharacterName = packetReader.ReadStringSafe();

            if ( l_strNewCharacterName == string.Empty )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_strNewCharacterName == string.Empty error!" );

                CreateCharacter_ReplyRej( netState, CCLReason.BadCharacterName );
                return;
            }

            if ( l_strNewCharacterName.Length > 64 )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_strNewCharacterName.Length > 64 error!" );

                CreateCharacter_ReplyRej( netState, CCLReason.BadCharacterName );
                return;
            }

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {AccountGuid}=@AccountGuid" );
                    l_QueryCharacters.Parameters.Add( "@AccountGuid", l_ExtendData.AccountGuid );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    // 如果大于3, 则检测看有效的是否超过3个，其余者为删除的人物
                    // 最多只能创建3个人物,其实可以5个的
                    if ( l_CharactersResult.Count > 3 )
                    {
                        int l_iCharactersCount = 0;
                        for ( int iIndex = 0; iIndex < l_CharactersResult.Count; iIndex++ )
                        {
                            Characters l_Characters = l_CharactersResult[iIndex] as Characters;
                            if ( l_Characters == null )
                            {
                                Debug.WriteLine( "CharPacketHandlers.CharacterServerCreateCharacter(...) - l_Characters == null error!" );

                                l_bIsReturn = true;
                                break;
                            }

                            if ( l_Characters.IsDelete == false )
                                ++l_iCharactersCount;
                        }

                        if ( l_bIsReturn == true )
                            break;

                        if ( l_iCharactersCount >= 3 )
                        {
                            l_bIsReturn = true;
                            break;
                        }
                    }

                    // 检查相同的人物名是否已经存在
                    Query l_QueryCharactersCheck = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharactersCheck.Parameters.Add( "@CharacterName", l_strNewCharacterName );
                    QueryResult l_CharactersCheckResult = l_QueryCharactersCheck.Execute();

                    if ( l_CharactersCheckResult != null && l_CharactersCheckResult.Count != 0 )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    // 检查相同的帐号名是否已经存在
                    Query l_QueryAccountsCheck = new Query( l_Session, "Select Accounts instances where {AccountsName}=@CharacterName" );
                    l_QueryAccountsCheck.Parameters.Add( "@CharacterName", l_strNewCharacterName );
                    QueryResult l_AccountsCheckResult = l_QueryAccountsCheck.Execute();

                    if ( l_AccountsCheckResult != null && l_AccountsCheckResult.Count != 0 )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    InitCharacter initCharacter = new InitCharacter();
                    initCharacter.m_Sex = l_iSex;
                    initCharacter.m_Face = l_iFace;
                    initCharacter.m_HairStyle = l_iHairStyle;
                    initCharacter.m_CharacterName = l_strNewCharacterName;


                    //////////////////////////////////////////////////////////////////////////
                    // 开始在编译后的程序集合内获取CreateCharacter

                    Type l_Type = ScriptCompiler.FindTypeByFullName( "Demo_R.O.S.E.Scripts.CharacterBirth" );
                    if ( l_Type == null )
                        CreateCharacter( ref initCharacter );
                    else
                    {
                        MethodInfo l_MethodInfo = l_Type.GetMethod( "CreateCharacter", BindingFlags.Static | BindingFlags.Public );
                        if ( l_MethodInfo == null )
                            CreateCharacter( ref initCharacter );
                        else
                        {
                            object[] objectArgs = new object[] { initCharacter };
                            l_MethodInfo.Invoke( null, objectArgs );
                        }
                    }

                    Characters newCharacter = (Characters)l_Session.CreateObject( typeof( Characters ) );

                    newCharacter.Sex = l_iSex;
                    newCharacter.Face = l_iFace;
                    newCharacter.HairStyle = l_iHairStyle;
                    newCharacter.CharacterName = l_strNewCharacterName;

                    newCharacter.CharacterGuid = newCharacter.ID;
                    newCharacter.AccountGuid = l_ExtendData.AccountGuid;

                    newCharacter.Zuly = initCharacter.Zuly;
                    newCharacter.Level = initCharacter.Level;
                    newCharacter.CurrentHP = initCharacter.CurrentHP;
                    newCharacter.CurrentMP = initCharacter.CurrentMP;
                    newCharacter.Strength = initCharacter.Strength;
                    newCharacter.Convergence = initCharacter.Convergence;
                    newCharacter.Dexterity = initCharacter.Dexterity;
                    newCharacter.Intellect = initCharacter.Intellect;
                    newCharacter.Charm = initCharacter.Charm;
                    newCharacter.Sense = initCharacter.Sense;
                    newCharacter.PositionX = initCharacter.PositionX;
                    newCharacter.PositionY = initCharacter.PositionY;
                    newCharacter.Experience = initCharacter.Experience;
                    newCharacter.SkillPoint = initCharacter.SkillPoint;
                    newCharacter.ClassID = initCharacter.ClassID;
                    newCharacter.CurrentMap = initCharacter.CurrentMap;
                    newCharacter.Stamina = initCharacter.Stamina;
                    newCharacter.QuickBar = initCharacter.QuickBar;
                    newCharacter.BasicSkills = initCharacter.BasicSkills;
                    newCharacter.ClassSkills = initCharacter.ClassSkills;
                    newCharacter.ClassSkillsLevel = initCharacter.ClassSkillsLevel;
                    newCharacter.Realm = initCharacter.Realm;
                    newCharacter.ClanGuid = -1;
                    newCharacter.ClanRank = 0;
                    newCharacter.TotalTime = 0;
                    newCharacter.LevelTime = 0;
                    newCharacter.IsOnline = false;
                    newCharacter.DeleteTime = DateTime.MaxValue;
                    newCharacter.IsDelete = false;


                    for ( int iIndex = 0; iIndex < initCharacter.ItemList.Count; iIndex++ )
                    {
                        Items newItem = (Items)l_Session.CreateObject( typeof( Items ) );
                        newItem.ItemGuid = newItem.ID;
                        newItem.CharacterGuid = newCharacter.CharacterGuid;

                        newItem.ItemID = initCharacter.ItemList[iIndex].ItemID;
                        newItem.ItemType = initCharacter.ItemList[iIndex].ItemType;
                        newItem.Refine = initCharacter.ItemList[iIndex].Refine;
                        newItem.Durability = initCharacter.ItemList[iIndex].Durability;
                        newItem.Lifespan = initCharacter.ItemList[iIndex].Lifespan;
                        newItem.SlotNumber = initCharacter.ItemList[iIndex].SlotNumber;
                        newItem.Count = initCharacter.ItemList[iIndex].Count;
                        newItem.Stats = initCharacter.ItemList[iIndex].Stats;
                        newItem.Socketed = initCharacter.ItemList[iIndex].Socketed;
                        newItem.Appraised = initCharacter.ItemList[iIndex].Appraised;
                        newItem.GemID = initCharacter.ItemList[iIndex].GemID;

                        newItem.IsDelete = false;
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                CreateCharacter_ReplyRej( netState, CCLReason.BadCharacterName );
            else
                CreateCharacter_ReplyAck( netState );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        private static void CreateCharacter_ReplyAck( NetState netState )
        {
            netState.Send( new CreateCharacterAck() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="cclReason"></param>
        private static void CreateCharacter_ReplyRej( NetState netState, CCLReason cclReason )
        {
            netState.Send( new CreateCharacterRej( cclReason ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCharacter"></param>
        private static void CreateCharacter( ref InitCharacter newCharacter )
        {
            newCharacter.Level = 1;

            newCharacter.CurrentHP = 50;
            newCharacter.CurrentMP = 18;

            newCharacter.Charm = 10;
            newCharacter.Sense = 10;
            newCharacter.Strength = 15;
            newCharacter.Dexterity = 15;
            newCharacter.Intellect = 15;
            newCharacter.Convergence = 15;
            newCharacter.Stamina = 5000;

            newCharacter.CurrentMap = 22;
            newCharacter.PositionX = 5098;
            newCharacter.PositionY = 5321;

            newCharacter.QuickBar           = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            newCharacter.BasicSkills        = "11,12,13,14,15,16,17,18,19,20,21,22,25,5000,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            newCharacter.ClassSkills        = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            newCharacter.ClassSkillsLevel   = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";

            newCharacter.Zuly = 1000;


            InitCharacterItem l_Item = new InitCharacterItem();

            l_Item.ItemID = 29;
            l_Item.ItemType = 3;
            l_Item.Refine = 0;
            l_Item.Durability = 40;
            l_Item.Lifespan = 100;
            l_Item.SlotNumber = 3;
            l_Item.Count = 1;
            l_Item.Stats = 0;
            l_Item.Socketed = false;
            l_Item.Appraised = false;
            l_Item.GemID = 0;

            newCharacter.ItemList.Add( l_Item );


            InitCharacterItem l_Item2 = new InitCharacterItem();

            l_Item2.ItemID = 29;
            l_Item2.ItemType = 5;
            l_Item2.Refine = 0;
            l_Item2.Durability = 40;
            l_Item2.Lifespan = 100;
            l_Item2.SlotNumber = 6;
            l_Item2.Count = 1;
            l_Item2.Stats = 0;
            l_Item2.Socketed = false;
            l_Item2.Appraised = false;
            l_Item2.GemID = 0;

            newCharacter.ItemList.Add( l_Item2 );


            InitCharacterItem l_Item3 = new InitCharacterItem();

            l_Item3.ItemID = 1;
            l_Item3.ItemType = 8;
            l_Item3.Refine = 0;
            l_Item3.Durability = 40;
            l_Item3.Lifespan = 100;
            l_Item3.SlotNumber = 7;
            l_Item3.Count = 1;
            l_Item3.Stats = 0;
            l_Item3.Socketed = false;
            l_Item3.Appraised = false;
            l_Item3.GemID = 0;

            newCharacter.ItemList.Add( l_Item3 );

            if ( newCharacter.Sex == 0 )
            {
                InitCharacterItem l_Item4 = new InitCharacterItem();

                l_Item4.ItemID = 222;
                l_Item4.ItemType = 2;
                l_Item4.Refine = 0;
                l_Item4.Durability = 40;
                l_Item4.Lifespan = 100;
                l_Item4.SlotNumber = 12;
                l_Item4.Count = 1;
                l_Item4.Stats = 0;
                l_Item4.Socketed = false;
                l_Item4.Appraised = false;
                l_Item4.GemID = 0;

                newCharacter.ItemList.Add( l_Item4 );
            }
            else
            {
                InitCharacterItem l_Item4 = new InitCharacterItem();

                l_Item4.ItemID = 221;
                l_Item4.ItemType = 2;
                l_Item4.Refine = 0;
                l_Item4.Durability = 40;
                l_Item4.Lifespan = 100;
                l_Item4.SlotNumber = 12;
                l_Item4.Count = 1;
                l_Item4.Stats = 0;
                l_Item4.Socketed = false;
                l_Item4.Appraised = false;
                l_Item4.GemID = 0;

                newCharacter.ItemList.Add( l_Item4 );
            }
        }
        #endregion

        #region zh-CHS CharacterServer DeleteCharacter - 数据处理 | en CharacterServer DeleteCharacter - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerDeleteCharacter( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 8/*6 + 2 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - packetReader.Size < 8 error!" );

                return;
            }

            byte l_iUnknown = packetReader.ReadByte();
            byte l_iAction = packetReader.ReadByte();
            string l_strCharacterName = packetReader.ReadStringSafe();

            uint l_iDeleteTime = 0;
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", l_strCharacterName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerDeleteCharacter(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    switch ( l_iAction )
                    {
                        case 0x00: // Resurect
                            l_Characters.IsDelete = false;
                            l_Characters.DeleteTime = DateTime.MaxValue;

                            l_iDeleteTime = 0;

                            break;
                        case 0x01: // Delete
                            l_Characters.IsDelete = false;
                            l_Characters.DeleteTime = DateTime.Now + TimeSpan.FromDays( 7.0 );

                            l_iDeleteTime = GetTime( l_Characters.DeleteTime ) - GetTime();

                            break;
                        default:
                            break;
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            netState.Send( new DeleteCharacterAck( l_strCharacterName, l_iDeleteTime ) );
        }
        #endregion

        #region zh-CHS CharacterServer RequestWorld - 数据处理 | en CharacterServer RequestWorld - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerRequestWorld( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 9/*6 + 3 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - packetReader.Size < 9 error!" );

                return;
            }

            ushort l_iUnknown = packetReader.ReadUInt16();
            byte l_iUnknown2 = packetReader.ReadByte();
            string l_strCharacterName = packetReader.ReadStringSafe();

            bool l_bIsReturn = false;
            IPEndPoint l_IPEndPoint = null;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    //////////////////////////////////////////////////////////////////////////
                    // 设置帐号最后选择的人物

                    Query l_UpdateAccounts = new Query( l_Session, "Select Accounts instances where {AccountsGuid}=@AccountGuid" );
                    l_UpdateAccounts.Parameters.Add( "@AccountGuid", l_ExtendData.AccountGuid );
                    QueryResult l_UpdateResult = l_UpdateAccounts.Execute();

                    if ( l_UpdateResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_UpdateResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_UpdateResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_UpdateResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_UpdateResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_Accounts == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Accounts.LastCharacter = l_strCharacterName;


                    //////////////////////////////////////////////////////////////////////////
                    // 获取服务的IP地址

                    Query l_QueryChannels = new Query( l_Session, "Select Channels instances where {ServerGuid}=@ServerGuid" );
                    l_QueryChannels.Parameters.Add( "@ServerGuid", l_ExtendData.ServerGuid );
                    QueryResult l_ChannelsResult = l_QueryChannels.Execute();

                    if ( l_ChannelsResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_QueryResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ChannelsResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_QueryResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Channels l_Channels = l_ChannelsResult[0] as Channels;
                    if ( l_Channels == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_Channels == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_IPEndPoint = new IPEndPoint( IPAddress.Parse( l_Channels.Host ), l_Channels.Port );

                    
                    //////////////////////////////////////////////////////////////////////////
                    // 给出人物的数据

                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", l_Accounts.LastCharacter );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ExtendData.CharacterGuid = l_Characters.CharacterGuid;
                    l_ExtendData.CharacterName = l_Characters.CharacterName;
                    l_ExtendData.ClanGuid = l_Characters.ClanGuid;
                    l_ExtendData.ClanRank = l_Characters.ClanRank;
                    l_ExtendData.Level = l_Characters.Level;
                    l_ExtendData.ClassId = l_Characters.ClassID;


                    //////////////////////////////////////////////////////////////////////////
                    // 获取好友列表

                    Query l_QueryListFriend = new Query( l_Session, "Select ListFriend instances where {CharacterGuid}=@CharacterGuid" );
                    l_QueryListFriend.Parameters.Add( "@CharacterGuid", l_Characters.CharacterGuid );
                    QueryResult l_ListFriendResult = l_QueryListFriend.Execute();

                    if ( l_ListFriendResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_ListFriendResult == null error!" );

                        break;
                    }

                    if ( l_ListFriendResult.Count <= 0 )
                        break;

                    NetState[] netStateArrayFriend = Program.BaseWorld.NetStateToArray();

                    for ( int iIndex = 0; iIndex < l_ListFriendResult.Count; iIndex++ )
                    {
                        ListFriend l_ListFriend = l_ListFriendResult[iIndex] as ListFriend;
                        if ( l_ListFriend == null )
                        {
                            Debug.WriteLine( "CharPacketHandlers.CharacterServerRequestWorld(...) - l_ListFriend == null error!" );

                            break;
                        }

                        Friend l_FriendList = new Friend();
                        l_FriendList.FriendGuid = l_ListFriend.FriendGuid;
                        l_FriendList.FriendName = l_ListFriend.FriendName;

                        foreach ( NetState netStateFriend in netStateArrayFriend )
                        {
                            CharServerExtendData l_ExtendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
                            if ( l_ExtendDataFriend == null )
                                continue;

                            if ( l_ExtendDataFriend.IsLoggedIn == false )
                                continue;

                            if ( l_FriendList.FriendGuid == l_ExtendDataFriend.CharacterGuid )
                                l_FriendList.IsOnline = true;
                        }

                        l_ExtendData.AddFriendList( l_FriendList );
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            netState.Send( new RequestWorldAck( l_IPEndPoint, l_ExtendData.AccountGuid ) );

            // ???
            l_ExtendData.Logout = false;

            // 告诉我的好友 我已经上线了
            Friend[] friendArray = l_ExtendData.FriendListToArray();
            if ( friendArray != null )
            {
                foreach ( Friend friend in friendArray )
                {
                    NetState netStateItem = ProcessNet.GetClientByCharGuid( friend.FriendGuid );
                    if ( netStateItem != null )
                        netStateItem.Send( new Friend0x7E1_Action0x08_Ack( (int)l_ExtendData.CharacterGuid, 0x07 ) );// 0x07 online, 0x08 offline
                }

                // 我的好友列表
                netState.Send( new Friend0x7E1_Action0x06_Ack( friendArray ) );
            }


            // 我的部落信息
            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == l_ExtendData.ClanGuid )
                    {
                        netState.Send( new Clan0x7E0_Action0x33_Ack( clan, l_ExtendData.ClanRank ) );
                        break;
                    }
                }
            }

            // 告诉我的部落 我已经上线了
            NetState[] netStateArrayClan = ProcessNet.GetClientsByClanGuid( l_ExtendData.ClanGuid );
            if ( netStateArrayClan != null )
            {
                foreach ( NetState netStateClan in netStateArrayClan )
                    netStateClan.Send( new Clan0x7E0_Action0x73_Ack( l_ExtendData.ServerGuid, l_ExtendData.Level, l_ExtendData.ClassId, l_ExtendData.CharacterName ) );
            }
        }
        #endregion

        #region zh-CHS CharacterServer ClanChat - 数据处理 | en CharacterServer ClanChat - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerClanChat( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanChat(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanChat(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 6/*6 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanChat(...) - packetReader.Size < 6 error!" );

                return;
            }

            string l_strText = packetReader.ReadStringSafe();

            // 告诉我的部落 我说的话
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( l_ExtendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateClan in netStateArray )
                    netStateClan.Send( new ClanChatAck( l_ExtendData.CharacterName, l_strText ) );
            }
        }
        #endregion

        #region zh-CHS CharacterServer ClanManager - 数据处理 | en CharacterServer ClanManager - OnPacketReceive
        /// <summary>
        /// Clan manager for all the clan functions
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerClanManager( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanManager(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanManager(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 7/*6 + 1*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerClanManager(...) - packetReader.Size < 7 error!" );

                return;
            }

            byte l_iAction = packetReader.ReadByte();

            switch ( l_iAction )
            {
                case 0x01:
                    
                    break;
                case 0x02: // invite clan 邀请加入部落

                    byte byteInvite = packetReader.ReadByte();
                    string strInviteName = packetReader.ReadStringSafe();

                    ClanManagerAction_02( netState, l_ExtendData, strInviteName );

                    break;
                case 0x03: // Kick from clan 踢掉某人在部落

                    byte byteKick = packetReader.ReadByte();
                    string strKickName = packetReader.ReadStringSafe();

                    ClanManagerAction_03( netState, l_ExtendData, strKickName );

                    break;
                case 0x04: // Up Rank 

                    byte byteUpRank = packetReader.ReadByte();
                    string strNameUpRank = packetReader.ReadStringSafe();

                    ClanManagerAction_04( netState, l_ExtendData, strNameUpRank );

                    break;
                case 0x05: // Down Rank

                    byte byteDownRank = packetReader.ReadByte();
                    string strNameDownRank = packetReader.ReadStringSafe();

                    ClanManagerAction_05( netState, l_ExtendData, strNameDownRank );

                    break;
                case 0x06: // Change news

                    byte byteNews = packetReader.ReadByte();
                    string strNews = packetReader.ReadStringSafe();

                    ClanManagerAction_06( netState, l_ExtendData, strNews );

                    break;
                case 0x07: // Leave Clan

                    ClanManagerAction_07( netState, l_ExtendData );

                    break;
                case 0x08: // Send Clan Members

                    ClanManagerAction_08( netState, l_ExtendData );

                    break;
                case 0x09: // Give Master

                    byte byteGiveMaster = packetReader.ReadByte();
                    string strNameGiveMaster = packetReader.ReadStringSafe();

                    ClanManagerAction_09( netState, l_ExtendData, strNameGiveMaster );

                    break;
                case 0x0A: // disorganize clan 解散部落

                    ClanManagerAction_0A( netState, l_ExtendData );

                    break;
                case 0x0C: // invitation accepted 同意加入部落

                    byte byteAccepted = packetReader.ReadByte();
                    string strNameAccepted = packetReader.ReadStringSafe();

                    ClanManagerAction_0C( netState, l_ExtendData, strNameAccepted );

                    break;
                case 0x0D: // invitation no accepted

                    byte byteNoAccepted = packetReader.ReadByte();
                    string strNameNoAccepted = packetReader.ReadStringSafe();

                    ClanManagerAction_0D( netState, l_ExtendData, strNameNoAccepted );

                    break;
                case 0x0F: // Update Clan window with Level and Job

                    byte iClanRank = packetReader.ReadByte();
                    ushort iLevel = packetReader.ReadUInt16();
                    ushort iClassId = packetReader.ReadUInt16();

                    ClanManagerAction_0F( netState, l_ExtendData, iLevel, iClassId );

                    break;
                case 0xFA: // message from worldserver to load the new clan information

                    byte iByte = packetReader.ReadByte();
                    ushort iClanGuid = packetReader.ReadUInt16(); // clanid
                    ushort iCharGuid = packetReader.ReadUInt16();  // charid
                    ushort iClientID = packetReader.ReadUInt16(); // clientid

                    ClanManagerAction_FA( netState, l_ExtendData, iClanGuid, iCharGuid, iClientID );

                    break;
                default:

                    packetReader.Trace( netState );
                    break;
            }
        }

        /// <summary>
        /// invite clan 邀请加入部落
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_02( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            NetState netStateInvite = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateInvite == null )
                return;

            netStateInvite.Send( new Clan0x7E0_Action0x0B_Ack( extendData.CharacterName ) );
        }

        /// <summary>
        /// Kick from clan 踢掉某人在部落
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_03( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            // 从数据库把人物从部落里面去除
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", strCharName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_03(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_03(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_03(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Characters.ClanGuid = 0;
                    l_Characters.ClanRank = 1;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            // 删除部落里的人物
            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == extendData.ClanGuid )
                    {
                        ClanMember[] clanMemberArray = clan.ClanMemberListToArray();
                        if ( clanMemberArray != null )
                        {
                            foreach ( ClanMember clanMember in clanMemberArray )
                            {
                                if ( clanMember.CharacterName == strCharName )
                                {
                                    clan.RemoveClanMemberList( clanMember );
                                    break;
                                }
                            }
                        }
                        
                        break;
                    }
                    else continue;
                }
            }
            
            // 告诉部落里的人 某人已经踢掉
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateKick in netStateArray )
                    netStateKick.Send( new Clan0x7E0_Action0x81_Ack( strCharName, extendData.CharacterName ) );
            }

            // 把人物从部落里面去除
            NetState l_NetStateKick = ProcessNet.GetClientByCharName( strCharName );
            if ( l_NetStateKick == null )
                return;

            CharServerExtendData l_ExtendDataKick = l_NetStateKick.ExtendData as CharServerExtendData;
            if ( l_ExtendDataKick == null )
                return;

            if ( l_ExtendDataKick.IsLoggedIn == false )
                return;

            l_ExtendDataKick.ClanGuid = 0;
            l_ExtendDataKick.ClanRank = 1;

            // 告诉世界服务器
            NetState l_NetStateWorldServer = ProcessNet.GetClientByWorldServerGuid( l_ExtendDataKick.ServerGuid );
            if ( l_NetStateWorldServer == null )
                return;

            WorldServerExtendData l_WorldServerExtendData = l_NetStateKick.ExtendData as WorldServerExtendData;
            if ( l_WorldServerExtendData == null )
                return;

            if ( l_WorldServerExtendData.IsLoggedIn == false )
                return;

            l_WorldServerExtendData.SendToWorldServer_0x7E1_Action0xFB( strCharName );
        }

        /// <summary>
        /// Up Rank 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_04( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            long iLevel = 0;
            long iClassId = 0;
            long iClanRank = 0;

            // 数据库里面更新人物的部落等级
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", strCharName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_04(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_04(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_04(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Characters.ClanRank < 5 )
                        ++l_Characters.ClanRank;

                    iLevel = l_Characters.Level;
                    iClassId = l_Characters.ClassID;
                    iClanRank = l_Characters.ClanRank;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            long iServerGuid = 0xFF;

            // 更新人物的部落等级(如果人物在线的话)
            NetState netStateUpRank = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateUpRank != null )
            {
                CharServerExtendData extendDataUpRank = netStateUpRank.ExtendData as CharServerExtendData;
                if ( extendDataUpRank != null )
                {
                    if ( extendDataUpRank.IsLoggedIn )
                    {
                        if ( extendDataUpRank.ClanRank < 5 )
                            ++extendDataUpRank.ClanRank;

                        iLevel = extendDataUpRank.Level;
                        iClassId = extendDataUpRank.ClassId;
                        iClanRank = extendDataUpRank.ClanRank;
                        iServerGuid = extendDataUpRank.ServerGuid;

                        netStateUpRank.Send( new Clan0x7E0_Action0x83_Ack( strCharName, iClanRank ) );
                    }
                }
            }

            // 通知部落的人
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                    netStateItem.Send( new Clan0x7E0_Action0x75_Ack( iClanRank, iServerGuid, iLevel, iClassId, strCharName ) );
            }

            if ( iServerGuid == 0xFF ) // 人物不在线
                return;

            // 通知世界服务器
            NetState netStateWorldServer = ProcessNet.GetClientByWorldServerGuid( iServerGuid );
            if ( netStateWorldServer == null )
                return;

            WorldServerExtendData worldServerExtendData = netStateWorldServer.ExtendData as WorldServerExtendData;
            if ( worldServerExtendData == null )
                return;

            if ( worldServerExtendData.IsLoggedIn == false )
                return;

            worldServerExtendData.SendToWorldServer_0x7E1_Action0xFC( iClanRank, strCharName );
        }

        /// <summary>
        /// Down Rank
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_05( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            long iLevel = 0;
            long iClassId = 0;
            long iClanRank = 0;

            // 数据库里面更新人物的部落等级
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", strCharName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_05(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_05(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_05(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Characters.ClanRank > 0 )
                        --l_Characters.ClanRank;

                    iLevel = l_Characters.Level;
                    iClassId = l_Characters.ClassID;
                    iClanRank = l_Characters.ClanRank;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            long iServerGuid = 0xFF;

            // 更新人物的部落等级(如果人物在线的话)
            NetState netStateDownRank = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateDownRank != null )
            {
                CharServerExtendData extendDataDownRank = netStateDownRank.ExtendData as CharServerExtendData;
                if ( extendDataDownRank != null )
                {
                    if ( extendDataDownRank.IsLoggedIn )
                    {
                        if ( extendDataDownRank.ClanRank > 0 )
                            --extendDataDownRank.ClanRank;

                        iLevel = extendDataDownRank.Level;
                        iClassId = extendDataDownRank.ClassId;
                        iClanRank = extendDataDownRank.ClanRank;
                        iServerGuid = extendDataDownRank.ServerGuid;

                        netStateDownRank.Send( new Clan0x7E0_Action0x83_Ack( strCharName, iClanRank ) );
                    }
                }
            }

            // 通知部落的人
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                    netStateItem.Send( new Clan0x7E0_Action0x75_Ack( iClanRank, iServerGuid, iLevel, iClassId, strCharName ) );
            }

            if ( iServerGuid == 0xFF ) // 人物不在线
                return;

            // 通知世界服务器
            NetState netStateWorldServer = ProcessNet.GetClientByWorldServerGuid( iServerGuid );
            if ( netStateWorldServer == null )
                return;

            WorldServerExtendData worldServerExtend = netStateWorldServer.ExtendData as WorldServerExtendData;
            if ( worldServerExtend == null )
                return;

            if ( worldServerExtend.IsLoggedIn == false )
                return;

            worldServerExtend.SendToWorldServer_0x7E1_Action0xFC( iClanRank, strCharName );
        }

        /// <summary>
        /// Change news
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strNews"></param>
        internal static void ClanManagerAction_06( NetState netState, CharServerExtendData extendData, string strNews )
        {
            if ( extendData.ClanRank < 5 )
                return;
            
            // 改变数据库新闻
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryListClan = new Query( l_Session, "Select ListClan instances where {ClanGuid}=@ClanGuid" );
                    l_QueryListClan.Parameters.Add( "@ClanGuid", extendData.ClanGuid );
                    QueryResult l_ListClanResult = l_QueryListClan.Execute();

                    if ( l_ListClanResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_06(...) - l_ListClanResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ListClanResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_06(...) - l_ListClanResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    ListClan l_ListClan = l_ListClanResult[0] as ListClan;
                    if ( l_ListClan == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_06(...) - l_ListClan == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ListClan.News = strNews;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            // 通知部落的人新闻改变
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                    netStateItem.Send( new Clan0x7E0_Action0x34_Ack( strNews ) );
            }
        }

        /// <summary>
        /// Leave Clan
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        internal static void ClanManagerAction_07( NetState netState, CharServerExtendData extendData )
        {
            if ( extendData.ClanRank >= 6 )
                return;

            long iClanGuid = extendData.ClanGuid;

            // 数据库设置
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", extendData.CharacterName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_07(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_07(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_07(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Characters.ClanGuid = 0;
                    l_Characters.ClanRank = 1;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;
            else
            {
                extendData.ClanGuid = 0;
                extendData.ClanRank = 1;
            }

            // 从部落删除
            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == extendData.ClanGuid )
                    {
                        ClanMember[] clanMemberArray = clan.ClanMemberListToArray();
                        if ( clanMemberArray != null )
                        {
                            foreach ( ClanMember clanMember in clanMemberArray )
                            {
                                if ( clanMember.CharacterName == extendData.CharacterName )
                                {
                                    clan.RemoveClanMemberList( clanMember );
                                    break;
                                }
                            }
                        }

                        break;
                    }
                    else continue;
                }
            }

            // 通知部落的人
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( iClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                    netStateItem.Send( new Clan0x7E0_Action0x82_Ack( extendData.CharacterName ) );
            }

            // 通知世界服务器
            NetState netStateWorldServer = ProcessNet.GetClientByWorldServerGuid( extendData.ServerGuid );
            if ( netStateWorldServer == null )
                return;

            WorldServerExtendData worldServerExtendData = netStateWorldServer.ExtendData as WorldServerExtendData;
            if ( worldServerExtendData == null )
                return;

            if ( worldServerExtendData.IsLoggedIn == false )
                return;

            worldServerExtendData.SendToWorldServer_0x7E1_Action0xFB( extendData.CharacterName );
        }

        /// <summary>
        /// Send Clan Members
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        internal static void ClanManagerAction_08( NetState netState, CharServerExtendData extendData )
        {
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray == null )
                return;

            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray == null )
                return;

            foreach ( Clan clan in clanArray )
            {
                if ( clan.ClanGuid == extendData.ClanGuid )
                {
                    ClanMember[] clanMemberArray = clan.ClanMemberListToArray();
                    if ( clanMemberArray == null )
                        break;

                    foreach ( ClanMember ClanMember in clanMemberArray )
                    {
                        foreach ( NetState netStateItem in netStateArray )
                        {
                            CharServerExtendData extendDataClanMember = netStateItem.ExtendData as CharServerExtendData;
                            if ( extendDataClanMember == null )
                                continue;

                            if ( extendDataClanMember.IsLoggedIn == false )
                                continue;

                            if ( extendDataClanMember.CharacterName == ClanMember.CharacterName )
                            {
                                ClanMember.Level = extendDataClanMember.Level;
                                ClanMember.ClassId = extendDataClanMember.ClassId;

                                // channel (0xff = offline)
                                ClanMember.ServerGuid = extendDataClanMember.ServerGuid <= 0 ? 0xFF : extendDataClanMember.ServerGuid;
                            }
                        }
                    }

                    netState.Send( new Clan0x7E0_Action0x72_Ack( clan.ClanMemberList.ToArray() ) );
                }
                else continue;
            }
        }

        /// <summary>
        /// Give Master
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_09( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            long iLevel = 0;
            long iClassId = 0;
            long iClanRank = 6;

            // 设置数据库
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", strCharName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_09(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_09(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_09(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Characters.ClanRank = (int)iClanRank;
                    iLevel = l_Characters.Level;
                    iClassId = l_Characters.ClassID;

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            long iServerGuid = 0xFF;

            NetState netStateGiveMaster = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateGiveMaster != null )
            {
                CharServerExtendData extendDataGiveMaster = netStateGiveMaster.ExtendData as CharServerExtendData;
                if ( extendDataGiveMaster != null )
                {
                    if ( extendDataGiveMaster.IsLoggedIn )
                    {
                        extendDataGiveMaster.ClanRank = iClanRank;
                        iLevel = extendDataGiveMaster.Level;
                        iClassId = extendDataGiveMaster.ClassId;
                        iServerGuid = extendDataGiveMaster.ServerGuid;

                        netStateGiveMaster.Send( new Clan0x7E0_Action0x83_Ack( strCharName, extendDataGiveMaster.ClanRank ) );
                    }
                }
            }

            //通知部落的人
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netState_GiveMaster in netStateArray )
                    netState_GiveMaster.Send( new Clan0x7E0_Action0x75_Ack( iClanRank, iServerGuid, iLevel, iClassId, strCharName ) );
            }

            if ( iServerGuid == 0xFF ) // 是否在线
                return;

            // 通知世界服务器
            NetState netStateWorldServer = ProcessNet.GetClientByWorldServerGuid( iServerGuid );
            if ( netStateWorldServer == null )
                return;

            WorldServerExtendData worldServerExtendData = netStateWorldServer.ExtendData as WorldServerExtendData;
            if ( worldServerExtendData == null )
                return;

            if ( worldServerExtendData.IsLoggedIn == false )
                return;

            // update world information
            worldServerExtendData.SendToWorldServer_0x7E1_Action0xFC( iClanRank, strCharName );
        }

        /// <summary>
        /// disorganize clan 解散部落
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        internal static void ClanManagerAction_0A( NetState netState, CharServerExtendData extendData )
        {
            if ( extendData.ClanRank < 6 )
                return;

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {ClanGuid}=@ClanGuid" );
                    l_QueryCharacters.Parameters.Add( "@ClanGuid", extendData.ClanGuid );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0A(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0A(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Characters.CharacterName != extendData.CharacterName )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    l_Characters.ClanGuid = 0;
                    l_Characters.ClanRank = 1;

                    Query l_QueryListClan = new Query( l_Session, "Select ListClan instances where {ClanGuid}=@ClanGuid" );
                    l_QueryListClan.Parameters.Add( "@ClanGuid", extendData.ClanGuid );
                    QueryResult l_ListClanResult = l_QueryListClan.Execute();

                    if ( l_ListClanResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0A(...) - l_ListClanResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ListClanResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0A(...) - l_ListClanResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    ListClan l_ListClan = l_ListClanResult[0] as ListClan;
                    if ( l_ListClan == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0A(...) - l_ListClan == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_ListClan.Remove();

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;
            else
            {
                extendData.ClanGuid = 0;
                extendData.ClanRank = 1;
            }

            bool l_nReturn = false;

            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == extendData.ClanGuid )
                    {
                        if ( clan.ClanMemberList.Count > 1 )
                            l_nReturn = true;
                        else Program.RemoveClanList( clan );

                        break;
                    }
                    else continue;
                }
            }

            if ( l_nReturn )
                return;

            netState.Send( new Clan0x7E0_Action0x51_Ack() );


            //NetState netStateWorldServer = ProcessNet.GetClientByWorldGuid( iServerGuid );
            //if ( netStateWorldServer == null )
            //    return;

            //WorldServerExtendData worldServerExtendData = netStateWorldServer.ExtendData as WorldServerExtendData;
            //if ( worldServerExtendData == null )
            //    return;

            //if ( worldServerExtendData.IsLoggedIn == false )
            //    return;

            //worldServerExtendData.xxx( iClanRank, strCharName );            // update world information
        }

        /// <summary>
        /// invitation accepted 同意加入部落
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_0C( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            NetState netStateAccepted = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateAccepted == null )
                return;

            CharServerExtendData extendDataAccepted = netStateAccepted.ExtendData as CharServerExtendData;
            if ( extendDataAccepted == null )
                return;

            if ( extendDataAccepted.IsLoggedIn == false )
                return;

            long iOldClanGuid = extendData.ClanGuid;

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryCharacters = new Query( l_Session, "Select Characters instances where {CharacterName}=@CharacterName" );
                    l_QueryCharacters.Parameters.Add( "@CharacterName", extendData.CharacterName );
                    QueryResult l_CharactersResult = l_QueryCharacters.Execute();

                    if ( l_CharactersResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0C(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_CharactersResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0C(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Characters l_Characters = l_CharactersResult[0] as Characters;
                    if ( l_Characters == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_0C(...) - l_Characters == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Characters.ClanRank = 1;
                    l_Characters.ClanGuid = (int)extendDataAccepted.ClanGuid;
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;
            else
            {
                extendData.ClanRank = 1;
                extendData.ClanGuid = extendDataAccepted.ClanGuid;
            }

            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == iOldClanGuid )
                    {
                        ClanMember[] clanMemberArray = clan.ClanMemberListToArray();
                        if ( clanMemberArray != null )
                        {
                            foreach ( ClanMember clanMember in clanMemberArray )
                            {
                                if ( clanMember.CharacterName == extendData.CharacterName )
                                {
                                    clan.RemoveClanMemberList(clanMember);
                                    break;
                                }
                            }
                        }
                    }

                    if ( clan.ClanGuid == extendData.ClanGuid )
                    {
                        ClanMember l_ClanMember = new ClanMember();

                        l_ClanMember.ClanRank = 1;
                        l_ClanMember.ClanGuid = extendDataAccepted.ClanGuid;
                        l_ClanMember.CharacterName = extendDataAccepted.CharacterName;

                        clan.AddClanMemberList( l_ClanMember );
                    }
                }
            }

            // 通知新的部落的人
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                {
                    netStateItem.Send( new Clan0x7E0_Action0x61_Ack( extendData.CharacterName, extendDataAccepted.CharacterName ) ); // xxx have invited to xxx
                    netStateItem.Send( new Clan0x7E0_Action0x84_Ack( extendData.Level, extendData.ClassId, extendData.CharacterName ) );
                }
            }

            // 通知世界服务器
            NetState netStateWorldServer = ProcessNet.GetClientByWorldServerGuid( extendData.ServerGuid );
            if ( netStateWorldServer == null )
                return;

            WorldServerExtendData worldServerExtendData = netStateWorldServer.ExtendData as WorldServerExtendData;
            if ( worldServerExtendData == null )
                return;

            if ( worldServerExtendData.IsLoggedIn == false )
                return;

            worldServerExtendData.SendToWorldServer_0x7E1_Action0xFA( extendData.CharacterGuid, extendData.ClanGuid );

            // 通知世界服务器
            NetState netStateWorldServer2 = ProcessNet.GetClientByWorldServerGuid( extendData.ServerGuid );
            if ( netStateWorldServer2 == null )
                return;

            // 相同就不需要再次通知了
            if ( netStateWorldServer == netStateWorldServer2 )
                return;

            WorldServerExtendData worldServerExtendData2 = netStateWorldServer2.ExtendData as WorldServerExtendData;
            if ( worldServerExtendData2 == null )
                return;

            if ( worldServerExtendData2.IsLoggedIn == false )
                return;

            worldServerExtendData2.SendToWorldServer_0x7E1_Action0xFA( extendData.CharacterGuid, extendData.ClanGuid );
        }

        /// <summary>
        /// invitation no accepted
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void ClanManagerAction_0D( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            if ( strCharName == extendData.CharacterName )
                return;

            NetState netStateNoAccepted = ProcessNet.GetClientByCharName( strCharName );
            if ( netStateNoAccepted == null )
                return;

            CharServerExtendData extendDataNoAccepted = netStateNoAccepted.ExtendData as CharServerExtendData;
            if ( extendDataNoAccepted == null )
                return;

            if ( extendDataNoAccepted.IsLoggedIn == false )
                return;

            netStateNoAccepted.Send( new Clan0x7E0_Action0x0D_Ack( extendData.CharacterName ) );
        }

        /// <summary>
        /// Update Clan window with Level and Job
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="iLevel"></param>
        /// <param name="iClassId"></param>
        internal static void ClanManagerAction_0F( NetState netState, CharServerExtendData extendData, int iLevel, int iClassId )
        {
            NetState[] netStateArray = ProcessNet.GetClientsByClanGuid( extendData.ClanGuid );
            if ( netStateArray != null )
            {
                foreach ( NetState netStateItem in netStateArray )
                    netStateItem.Send( new Clan0x7E0_Action0x84_Ack( iLevel, iClassId, extendData.CharacterName ) );
            }
        }

        /// <summary>
        /// message from worldserver to load the new clan information 创建部落
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="iClanGuid"></param>
        /// <param name="iCharGuid"></param>
        /// <param name="iClientID"></param>
        internal static void ClanManagerAction_FA( NetState netState, CharServerExtendData extendData, int iClanGuid, int iCharGuid, int iClientID )
        {
            Clan l_Clan = new Clan();

            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryListClan = new Query( l_Session, "Select ListClan instances where {ClanGuid}=@ClanGuid" );
                    l_QueryListClan.Parameters.Add( "@ClanGuid", iClanGuid );
                    QueryResult l_ListClanResult = l_QueryListClan.Execute();

                    if ( l_ListClanResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_FA(...) - l_ListClanResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_ListClanResult.Count != 1 )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_FA(...) - l_CharactersResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    ListClan l_ListClan = l_ListClanResult[0] as ListClan;
                    if ( l_ListClan == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.ClanManagerAction_FA(...) - l_ListClan == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    l_Clan.ClanGuid = l_ListClan.ClanGuid;
                    l_Clan.ClanName = l_ListClan.ClanName;
                    l_Clan.Logo = l_ListClan.Logo;
                    l_Clan.Back = l_ListClan.Back;
                    l_Clan.Grade = l_ListClan.Grade;
                    l_Clan.CP = l_ListClan.CP;
                    l_Clan.Slogan = l_ListClan.Slogan;
                    l_Clan.News = l_ListClan.News;

                    Program.AddClanList( l_Clan );

                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            NetState netStateWorldMessage = ProcessNet.GetClientByCharGuid( iCharGuid );
            if ( netStateWorldMessage == null )
                return;

            CharServerExtendData extendDataWorldMessage = netStateWorldMessage.ExtendData as CharServerExtendData;
            if ( extendDataWorldMessage == null )
                return;

            if ( extendDataWorldMessage.IsLoggedIn == false )
                return;

            extendDataWorldMessage.ClanRank = 6;
            extendDataWorldMessage.ClanGuid = l_Clan.ClanGuid;

            ClanMember clanMember = new ClanMember();

            clanMember.ClanGuid = extendDataWorldMessage.ClanGuid;
            clanMember.ClanRank = extendDataWorldMessage.ClanRank;
            clanMember.CharacterName = extendDataWorldMessage.CharacterName;

            l_Clan.AddClanMemberList( clanMember );

            netStateWorldMessage.Send( new Clan0x7E0_Action0x30_Ack( iClientID, extendDataWorldMessage.ClanRank, l_Clan ) );
        }
        #endregion

        #region zh-CHS CharacterServer MessengerManager - 数据处理 | en CharacterServer MessengerManager - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerMessengerManager( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerManager(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerManager(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 7/*6 + 1*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerManager(...) - packetReader.Size < 7 error!" );

                return;
            }

            byte l_iAction = packetReader.ReadByte();

            switch ( l_iAction )
            {
                case 0x01://wanna be my friend?

                    byte byte1 = packetReader.ReadByte();
                    string strName1 = packetReader.ReadStringSafe();

                    MessengerManagerAction_01( netState, l_ExtendData, strName1 );

                    break;
                case 0x02: // yes i want

                    byte byte2 = packetReader.ReadByte();
                    ushort ushort2 = packetReader.ReadUInt16();
                    string strName2 = packetReader.ReadStringSafe();

                    MessengerManagerAction_02( netState, l_ExtendData, strName2 );

                    break;
                case 0x03: // no, i dont want

                    byte byte3 = packetReader.ReadByte();
                    ushort ushort3 = packetReader.ReadUInt16();
                    string strName3 = packetReader.ReadStringSafe();

                    MessengerManagerAction_03( netState, l_ExtendData, strName3 );

                    break;
                case 0x05: // freakin later

                    byte iByte = packetReader.ReadByte();
                    int iCharGuid = packetReader.ReadUInt16();

                    MessengerManagerAction_05( netState, l_ExtendData, iCharGuid );

                    break;
                case 0xFA: // messenger logout    

                    byte iByte2 = packetReader.ReadByte();
                    int iCharGuid2 = packetReader.ReadUInt16();

                    MessengerManagerAction_FA( netState, l_ExtendData, iCharGuid2 );

                    break;
                default:

                    packetReader.Trace( netState );

                    break;
            }
        }

        /// <summary>
        /// wanna be my friend?
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void MessengerManagerAction_01( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            NetState netStateFriend = ProcessNet.GetClientByCharName( strCharName );

            bool l_bIsReturn = false;
            do
            {
                if ( netStateFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                CharServerExtendData extendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
                if ( extendDataFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                if ( extendDataFriend.IsLoggedIn == false )
                {
                    l_bIsReturn = true;
                    break;
                }
            } while ( false );

            if ( l_bIsReturn == true )
                netState.Send( new Friend0x7E1_Action0x04_Ack( strCharName ) ); // This charname doesnt exist
            else
                netStateFriend.Send( new Friend0x7E1_Action0x01_Ack( extendData.CharacterName ) ); // Send friend invitation  (check this one)
        }

        /// <summary>
        /// yes i want
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void MessengerManagerAction_02( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            NetState netStateFriend = ProcessNet.GetClientByCharName( strCharName );
            CharServerExtendData extendDataFriend = null;

            bool l_bIsReturn = false;
            do
            {
                if ( netStateFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                extendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
                if ( extendDataFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                if ( extendDataFriend.IsLoggedIn == false )
                {
                    l_bIsReturn = true;
                    break;
                }
            } while ( false );

            if ( l_bIsReturn == true )
            {
                netState.Send( new Friend0x7E1_Action0x04_Ack( strCharName ) ); //not founded
                return;
            }
            else
            {
                netStateFriend.Send( new Friend0x7E1_Action0x02_Ack( extendData.CharacterGuid, extendData.CharacterName ) );
                netState.Send( new Friend0x7E1_Action0x02_Ack( extendDataFriend.CharacterGuid, extendDataFriend.CharacterName ) );
            }

            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryListFriend = new Query( l_Session, "Select ListFriend instances where {CharacterGuid}=@CharacterGuid" );
                    l_QueryListFriend.Parameters.Add( "@CharacterGuid", extendData.CharacterGuid );
                    QueryResult l_ListFriendResult = l_QueryListFriend.Execute();

                    bool l_bFindFriend = false;
                    if ( l_ListFriendResult != null )
                    {
                        foreach ( ListFriend listFriend in l_ListFriendResult )
                        {
                            ListFriend l_ListFriend = listFriend as ListFriend;
                            if ( l_ListFriend != null )
                            {
                                if ( l_ListFriend.FriendGuid == extendDataFriend.CharacterGuid )
                                {
                                    l_bFindFriend = true;
                                    break;
                                }
                            }
                        }
                    }

                    if ( l_bFindFriend == false )
                    {
                        ListFriend l_ListFriend = (ListFriend)l_Session.CreateObject( typeof( ListFriend ) );

                        l_ListFriend.CharacterGuid = extendData.CharacterGuid;

                        l_ListFriend.FriendGuid = extendDataFriend.CharacterGuid;
                        l_ListFriend.FriendName = extendDataFriend.CharacterName;

                        Friend l_Friend = new Friend();

                        l_Friend.IsOnline = true;
                        l_Friend.FriendGuid = extendDataFriend.CharacterGuid;
                        l_Friend.FriendName = extendDataFriend.CharacterName;

                        extendData.AddFriendList( l_Friend );
                    }

                    Query l_QueryListFriend2 = new Query( l_Session, "Select ListFriend instances where {CharacterGuid}=@CharacterGuid" );
                    l_QueryListFriend2.Parameters.Add( "@CharacterGuid", extendDataFriend.CharacterGuid );
                    QueryResult l_ListFriend2Result = l_QueryListFriend2.Execute();

                    bool l_bFindFriend2 = false;
                    if ( l_ListFriend2Result != null )
                    {
                        foreach ( ListFriend listFriend in l_ListFriend2Result )
                        {
                            ListFriend l_ListFriend = listFriend as ListFriend;
                            if ( l_ListFriend != null )
                            {
                                if ( l_ListFriend.FriendGuid == extendData.CharacterGuid )
                                {
                                    l_bFindFriend2 = true;
                                    break;
                                }
                            }
                        }
                    }

                    if ( l_bFindFriend2 == false )
                    {
                        ListFriend l_ListFriend = (ListFriend)l_Session.CreateObject( typeof( ListFriend ) );

                        l_ListFriend.CharacterGuid = extendDataFriend.CharacterGuid;

                        l_ListFriend.FriendGuid = extendData.CharacterGuid;
                        l_ListFriend.FriendName = extendData.CharacterName;

                        Friend l_Friend = new Friend();

                        l_Friend.IsOnline = true;
                        l_Friend.FriendGuid = extendData.CharacterGuid;
                        l_Friend.FriendName = extendData.CharacterName;

                        extendDataFriend.AddFriendList( l_Friend );
                    }
                } while ( false );
            }
            l_Session.Commit();
        }

        /// <summary>
        /// no, i dont want
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="strCharName"></param>
        internal static void MessengerManagerAction_03( NetState netState, CharServerExtendData extendData, string strCharName )
        {
            NetState netStateFriend = ProcessNet.GetClientByCharName( strCharName );

            bool l_bIsReturn = false;
            do
            {
                if ( netStateFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                CharServerExtendData extendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
                if ( extendDataFriend == null )
                {
                    l_bIsReturn = true;
                    break;
                }

                if ( extendDataFriend.IsLoggedIn == false )
                {
                    l_bIsReturn = true;
                    break;
                }
            } while ( false );

            if ( l_bIsReturn == true )
                netState.Send( new Friend0x7E1_Action0x04_Ack( strCharName ) );
            else
                netStateFriend.Send( new Friend0x7E1_Action0x03_Ack( extendData.CharacterName ) );
        }

        /// <summary>
        /// freakin later
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="iCharGuid"></param>
        internal static void MessengerManagerAction_05( NetState netState, CharServerExtendData extendData, int iCharGuid )
        {
            bool l_bIsReturn = false;
            Session l_Session = new Session( BaseDatabase.Domain );
            l_Session.BeginTransaction();
            {
                do
                {
                    Query l_QueryListFriend = new Query( l_Session, "Select ListFriend instances where {CharacterGuid}=@CharacterGuid" );
                    l_QueryListFriend.Parameters.Add( "@CharacterGuid", extendData.CharacterGuid );
                    QueryResult l_ListFriendResult = l_QueryListFriend.Execute();

                    if ( l_ListFriendResult == null )
                    {
                        Debug.WriteLine( "CharPacketHandlers.MessengerManagerAction_05(...) - l_CharactersResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    foreach ( ListFriend listFriend in l_ListFriendResult )
                    {
                        ListFriend l_ListFriend = listFriend as ListFriend;
                        if ( l_ListFriend == null )
                        {
                            Debug.WriteLine( "CharPacketHandlers.MessengerManagerAction_05(...) - l_Characters == null error!" );

                            l_bIsReturn = true;
                            break;
                        }

                        if ( l_ListFriend.FriendGuid == iCharGuid )
                        {
                            Friend[] FriendArray = extendData.FriendListToArray();
                            if ( FriendArray != null )
                            {
                                foreach ( Friend friend in FriendArray )
                                {
                                    if ( friend.FriendGuid == iCharGuid )
                                    {
                                        extendData.RemoveFriendList( friend );
                                        break;
                                    }
                                }
                            }

                            l_ListFriend.Remove();
                            break;
                        }
                    }
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;
            
            NetState netStateFriend = ProcessNet.GetClientByCharGuid( iCharGuid );
            if ( netStateFriend == null )
                return;

            CharServerExtendData extendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
            if ( extendDataFriend == null )
                return;

            if ( extendDataFriend.IsLoggedIn == false )
                return;

            netStateFriend.Send( new Friend0x7E1_Action0x08_Ack( extendData.CharacterGuid, 0x08 ) );
        }

        /// <summary>
        /// messenger logout 登陆出去
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="extendData"></param>
        /// <param name="iCharGuid"></param>
        internal static void MessengerManagerAction_FA( NetState netState, CharServerExtendData extendData, int iCharGuid )
        {
            NetState netStateFriend = ProcessNet.GetClientByCharGuid( iCharGuid );
            if ( netStateFriend == null )
                return;

            CharServerExtendData extendDataFriend = netStateFriend.ExtendData as CharServerExtendData;
            if ( extendDataFriend == null )
                return;

            if ( extendDataFriend.IsLoggedIn == false )
                return;

            extendDataFriend.Logout = true;

            // 告诉好友我不在线了
            Friend[] friendArray = extendDataFriend.FriendListToArray();
            if ( friendArray != null )
            {
                foreach ( Friend friend in friendArray )
                {
                    NetState netStateItem = ProcessNet.GetClientByCharGuid( friend.FriendGuid );
                    if ( netStateItem != null )
                        netStateItem.Send( new Friend0x7E1_Action0x08_Ack( extendData.CharacterGuid, 0x08 ) );
                }
            }

            // 告诉部落我不在线了
            Clan[] clanArray = Program.ClanListToArray();
            if ( clanArray != null )
            {
                foreach ( Clan clan in clanArray )
                {
                    if ( clan.ClanGuid == extendDataFriend.ClanGuid )
                    {
                        ClanMember[] clanMemberArray = clan.ClanMemberListToArray();
                        if ( clanMemberArray != null )
                        {
                            foreach ( ClanMember clanMember in clanMemberArray )
                            {
                                NetState netStateItem = ProcessNet.GetClientByCharName( clanMember.CharacterName );
                                if ( netStateItem != null )
                                    netStateItem.Send( new Clan0x7E0_Action0x73_Ack( 0xFF, extendData.Level, extendData.ClassId, extendData.CharacterName ) ); // Change player status in clan ((channel) = online/ 0xff = offline)
                            }
                        }

                        break;
                    }
                    else continue;
                }
            }
        }
        #endregion

        #region zh-CHS CharacterServer MessengerChat - 数据处理 | en CharacterServer MessengerChat - OnPacketReceive
        /// <summary>
        /// Messenger Chat
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerMessengerChat( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerChat(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerChat(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 8/*6 + 2 + ? + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerMessengerChat(...) - packetReader.Size < 8 error!" );

                return;
            }

            ushort iCharGuid = packetReader.ReadUInt16();
            ushort ushort1 = packetReader.ReadUInt16();
            string strCharName = packetReader.ReadStringSafe( 31 );
            string strMessage = packetReader.ReadStringSafe();

            NetState netStateChat = ProcessNet.GetClientByCharGuid( iCharGuid );
            if ( netStateChat == null )
                return;

            netStateChat.Send( new MessengerChatAck( l_ExtendData.CharacterGuid, l_ExtendData.CharacterName, strMessage ) );
        }
        #endregion

        #region zh-CHS CharacterServer ChatRooms - 数据处理 | en CharacterServer ChatRooms - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerChatRooms( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerChatRooms(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerChatRooms(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 6/*6 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerChatRooms(...) - packetReader.Size < 6 error!" );

                return;
            }
        }
        #endregion

        #region zh-CHS CharacterServer Unknown0x07E5 - 数据处理 | en CharacterServer Unknown0x07E5 - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerUnknown0x07E5( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUnknown0x07E5(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUnknown0x07E5(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 7/*6 + 1*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUnknown0x07E5(...) - packetReader.Size < 7 error!" );

                return;
            }

            byte l_iAction = packetReader.ReadByte();

            switch ( l_iAction )
            {
                case 0x03:

                    netState.Send( new Unknown0x07E5_Action0x01Ack() );
                    break;
                default:

                    break;
            }
        }
        #endregion

        #region zh-CHS CharacterServer UpdateLevel - 数据处理 | en CharacterServer UpdateLevel - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharacterServerUpdateLevel( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUpdateLevel(...) - l_ExtendData == null error!" );

                return;
            }

            if ( l_ExtendData.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUpdateLevel(...) - l_ExtendData.m_bIsLoggedIn == false error!" );

                return;
            }

            if ( packetReader.Size < 10/*6 + 4*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.CharacterServerUpdateLevel(...) - packetReader.Size < 10 error!" );

                return;
            }

            ushort iCharGuid = packetReader.ReadUInt16();
            ushort iLevel = packetReader.ReadUInt16();

            NetState netStateLevel = ProcessNet.GetClientByCharGuid( iCharGuid );

            if ( netStateLevel == null )
                return;

            CharServerExtendData extendDataLevel = netStateLevel.ExtendData as CharServerExtendData;
            if ( extendDataLevel == null )
                return;

            extendDataLevel.Level = iLevel;
        }
        #endregion
    }
}
#endregion