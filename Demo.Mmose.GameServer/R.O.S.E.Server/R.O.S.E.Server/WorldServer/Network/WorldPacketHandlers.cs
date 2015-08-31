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
using System.Diagnostics;
using Demo_G.O.S.E.Data;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.Database;
using Demo_R.O.S.E.Database.Model;
using System;
using Demo_G.O.S.E.ServerEngine.Common;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.GameCommand;
using Demo_R.O.S.E.Mobile;
using System.Threading;
using Demo_R.O.S.E.WorldServer.WorldCommon;
using Demo_G.O.S.E.ServerEngine.Map;
#endregion

namespace Demo_R.O.S.E.WorldServer.Network
{
    class WorldPacketHandlers
    {
        #region zh-CHS WorldServer CharServerConnected - 数据处理 | en WorldServer CharConnected - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharServerConnected( NetState netState, PacketReader packetReader )
        {
            // 错误 不可能有创建
            if ( netState.ExtendData is CharServerExtendData == true )
                return;
            else
                netState.ExtendData = null;

            if ( packetReader.Size < 6/*( 6 + 0 )*/ )
                return;

            // 不检查网络是否活动
            netState.IsCheckActivity = false;

            string l_strWorldPassword = packetReader.ReadStringSafe();

            if ( l_strWorldPassword == Program.ConfigInfo.WorldPassword )
            {
                CharServerExtendData l_ExtendData = new CharServerExtendData();

                l_ExtendData.IsLoggedIn = true;

                netState.ExtendData = l_ExtendData;
            }
        }
        #endregion

        #region zh-CHS WorldServer CSCharSelect - 数据处理 | en WorldServer CSCharSelect - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharServerAction( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
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
                case 1: // Disconnect Character

                    uint l_iAccountGuid = packetReader.ReadUInt32();

                    CharServer_Action01( netState, l_iAccountGuid );

                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// // Disconnect Character 人物
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="iAccountGuid"></param>
        internal static void CharServer_Action01( NetState netState, long iAccountGuid )
        {
            NetState l_NetState = ProcessNet.GetClientByAccountGuid( iAccountGuid );
            if ( l_NetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_NetState == null error!" );
                return;
            }

            WorldServerExtendData l_CharExtendData = l_NetState.ExtendData as WorldServerExtendData;
            if ( l_CharExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_CharExtendData == null error!" );
                return;
            }

            if ( l_CharExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_CharExtendData.IsLoggedIn == false error!" );
                return;
            }

            l_NetState.Send ( new ExitAck(0) );
        }
        #endregion

        #region zh-CHS WorldServer CharSelect - 数据处理 | en WorldServer CharSelect - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void CharServerDisconnectUser( NetState netState, PacketReader packetReader )
        {
            CharServerExtendData l_ExtendData = netState.ExtendData as CharServerExtendData;
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

            uint iAccountGuid = packetReader.ReadUInt32();

            NetState l_NetState = ProcessNet.GetClientByAccountGuid( iAccountGuid );
            if ( l_NetState == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction_01(...) - l_NetState == null error!" );
                return;
            }

            if ( l_NetState.Running )
                l_NetState.Dispose( true );
        }
        #endregion

        #region zh-CHS WorldServer Ping - 数据处理 | en WorldServer Ping - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void WorldServerPing( NetState netState, PacketReader packetReader )
        {
            netState.Send( new PingAck(0) );
        }
        #endregion

        #region zh-CHS WorldServer Exit - 数据处理 | en WorldServer Exit - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void WorldServerExit( NetState netState, PacketReader packetReader )
        {
            netState.Send( new ExitAck( 3 ) );
            netState.Dispose( true, 3 );
        }
        #endregion

        #region zh-CHS WorldServer DoIdentify - 数据处理 | en WorldServer DoIdentify - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void WorldServerDoIdentify( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NONE, " WorldServerDoIdentify(...)" );

            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == true )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 42/*( 6 + 4 + 32)*/ )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - packetReader.Size < 42 error!" );
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
                        Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_AccountsResult == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_AccountsResult.Count != 1 )
                    {
                        Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_AccountsResult.Count != 1 error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    Accounts l_Accounts = l_AccountsResult[0] as Accounts;
                    if ( l_Accounts == null )
                    {
                        Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_Accounts == null error!" );

                        l_bIsReturn = true;
                        break;
                    }

                    if ( l_Accounts.Password != l_strPassword )
                    {
                        l_bIsReturn = true;
                        break;
                    }

                    l_ExtendData.ROSEMobile.AccountGuid = l_Accounts.AccountsGuid;
                    l_ExtendData.ROSEMobile.CharacterName = l_Accounts.LastCharacter;
                    l_ExtendData.ROSEMobile.AccessLevel = l_Accounts.GMLevel == 300 ? AccessLevel.GameMaster : AccessLevel.Player;
                    l_ExtendData.ROSEMobile.StorageZuly = l_Accounts.StorageZuly;
                    l_ExtendData.ROSEMobile.Player = true;
                } while ( false );
            }
            l_Session.Commit();

            if ( l_bIsReturn == true )
                return;

            if ( l_ExtendData.LoadData() == false )
                return;

            if ( l_ExtendData.GetStats() == false )
                return;

            l_ExtendData.ROSEMobile.IsLoggedIn = true;

            netState.Send( new Unknown0x070CAck() );
            netState.Send( new UserInformationAck( l_ExtendData.ROSEMobile ) );
            netState.Send( new UserInventoryDataAck( l_ExtendData.ROSEMobile ) );
            netState.Send( new UserQuestDataAck( l_ExtendData.ROSEMobile ) );
            netState.Send( new Unknown0x07DEAck() );
            netState.Send( new Unknown0x07DFAck() );
        }
        #endregion

        #region zh-CHS WorldServer DoID - 数据处理 | en WorldServer DoID - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void WorldServerDoID( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NONE, " WorldServerDoID(...)" );

            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            l_ExtendData.ROSEMobile.m_iClientID = RoseSerial.GetNewClientID();

            if ( l_ExtendData.ROSEMobile.m_iClientID == 0 )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData.ROSEMobile.m_iClientID == 0 error!" );
                return;
            }

            l_ExtendData.ROSEMobile.InGame = true;

            netState.Send( new Unknown0x07D5Ack( l_ExtendData.ROSEMobile ) );
            netState.Send( new Unknown0x0721Ack() );
            netState.Send( new Unknown0x0730Ack() );
            netState.Send( new Unknown0x0753Ack( l_ExtendData.ROSEMobile ) );
            netState.Send( new Unknown0x0762Ack( l_ExtendData.ROSEMobile ) );
            netState.Send( new Unknown0x0782Ack( l_ExtendData.ROSEMobile ) );
            netState.Send( new Unknown0x0702Ack( Program.ConfigInfo.WelcomeMessage ) );

            l_ExtendData.CleanPlayerVector();
            l_ExtendData.RestartPlayerVal();
        }
        #endregion

        #region zh-CHS WorldServer MoveChar - 数据处理 | en WorldServer MoveChar - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerMoveChar( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NONE, " WorldServerMoveChar(...)" );

            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerMoveChar(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerMoveChar(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 18/*( 6 + 2 + 4 + 4 + 2)*/ )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerMoveChar(...) - packetReader.Size < 22 error!" );
                return;
            }

            Debug.WriteLine( string.Format( "packetReader.Size {0}", packetReader.Size ) );
            
            l_ExtendData.ROSEMobile.targetid = packetReader.ReadUInt16();
            l_ExtendData.ROSEMobile.X = (long)packetReader.ReadFloat() / 100;
            l_ExtendData.ROSEMobile.Y = (long)packetReader.ReadFloat() / 100;
            ushort Z = packetReader.ReadUInt16();

            netState.Send( new MoveCharAck( l_ExtendData.ROSEMobile ) );

            Debug.WriteLine( string.Format( "WorldServerMoveChar {0}, {1}, {2}", l_ExtendData.ROSEMobile.targetid, l_ExtendData.ROSEMobile.X, l_ExtendData.ROSEMobile.Y ) );

            IPooledEnumerable pooledEnumerable = netState.Mobile.Map.GetClientsInRange( netState.Mobile.Location );
            if ( pooledEnumerable == null )
                return;

            foreach ( object client in pooledEnumerable )
            {
                NetState l_NetState  = client as NetState;
                if ( l_NetState == null )
                    break;

                l_NetState.Send( new MoveCharAck( l_ExtendData.ROSEMobile ) );
            }
        }
        #endregion

        #region zh-CHS WorldServer StopChar - 数据处理 | en WorldServer StopChar - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerStopChar( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NONE, " WorldServerStopChar(...)" );

            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerStopChar(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerStopChar(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 16/*( 6 + 4 + 4 + 2)*/ )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerStopChar(...) - packetReader.Size < 16 error!" );
                return;
            }

            l_ExtendData.ROSEMobile.X = (long)packetReader.ReadFloat() / 100;
            l_ExtendData.ROSEMobile.Y = (long)packetReader.ReadFloat() / 100;
            ushort Z = packetReader.ReadUInt16();

            netState.Send( new StopCharAck( l_ExtendData.ROSEMobile ) );

            Debug.WriteLine( string.Format( "WorldServerStopChar {0}, {1}, {2}", l_ExtendData.ROSEMobile.targetid, l_ExtendData.ROSEMobile.X, l_ExtendData.ROSEMobile.Y ) );

            IPooledEnumerable pooledEnumerable = netState.Mobile.Map.GetClientsInRange( netState.Mobile.Location );
            if ( pooledEnumerable == null )
                return;

            foreach ( object client in pooledEnumerable )
            {
                NetState l_NetState = client as NetState;
                if ( l_NetState == null )
                    break;

                l_NetState.Send( new StopCharAck( l_ExtendData.ROSEMobile ) );
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="npcMobile"></param>
        public static void pakSpawnNPC( NetState netState, ROSEMobile npcMobile )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="monsterMobile"></param>
        public static void pakSpawnMonster( NetState netState, ROSEMobile monsterMobile )
        {
        }

        #region zh-CHS WorldServer NormalChat - 数据处理 | en WorldServer NormalChat - OnPacketReceive
        public static void WorldServerNormalChat( NetState netState, PacketReader packetReader )
        {
            LOGs.WriteLine( LogMessageType.MSG_NONE, " WorldServerNormalChat(...)" );

            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerNormalChat(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerNormalChat(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 7/*( 6 + ?)*/ )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerStopChar(...) - packetReader.Size < 7 error!" );
                return;
            }

            string l_strNormalChat = packetReader.ReadStringSafe();

            LOGs.WriteLine( LogMessageType.MSG_NONE, l_strNormalChat );

            BaseGameCommand l_GameCommand = GameCommands.GetGameCommand( l_strNormalChat );
            if ( l_GameCommand != null )
                l_GameCommand.OnEventGameCommand( netState );
            else
            {
                netState.Send( new NormalChatAck( l_ExtendData.ROSEMobile, l_strNormalChat ) );
            }
        }
        #endregion

        #region zh-CHS WorldServer UserDied - 数据处理 | en WorldServer UserDied - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerUserDied( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            byte iRespawn = packetReader.ReadByte();
            //1 - Current / 2 - save point

            netState.Send( new UserDiedAck( l_ExtendData.ROSEMobile ) );
        }
        #endregion

        #region zh-CHS WorldServer Weight - 数据处理 | en WorldServer UserDied - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerWeight( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            byte iWeight = packetReader.ReadByte();

            if ( iWeight > 110 )
            {
            }
            else
            {
            }

            if ( iWeight >  100 )
            {
            }
            else
            {
            }

            netState.Send( new WeightAck( l_ExtendData.ROSEMobile, iWeight ) );
        }
        #endregion

        #region zh-CHS WorldServer DoEmote - 数据处理 | en WorldServer DoEmote - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerDoEmote( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            ushort iUshort1 = packetReader.ReadUInt16();
            ushort iUshort2 = packetReader.ReadUInt16();

            netState.Send( new DoEmoteAck( iUshort1, iUshort2, l_ExtendData.ROSEMobile ) );
        }
        #endregion

        #region zh-CHS WorldServer ChangeStance - 数据处理 | en WorldServer ChangeStance - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerChangeStance( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            byte iStanceNum = packetReader.ReadByte();

            if ( iStanceNum == 0 )
            {
            }
            else if ( iStanceNum == 1 )
            {
            }
            else if ( iStanceNum == 2 )
            {
            }
            else
            {
            }

            netState.Send( new ChangeStanceAck( l_ExtendData.ROSEMobile ) );
        }
        #endregion


        #region zh-CHS WorldServer Whisper - 数据处理 | en WorldServer Whisper - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerWhisper( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            string msgto = packetReader.ReadStringSafe( 16 );
            string msg = packetReader.ReadStringSafe();

            NetState l_NetState =  ProcessNet.GetClientByCharName( msgto );
            if ( l_NetState != null )
            {
                WorldServerExtendData extendData = l_NetState.ExtendData as WorldServerExtendData;
                if ( extendData != null )
                {
                    l_NetState.Send( new WhisperAck( extendData.ROSEMobile, msg ) );

                    return;
                }
            }

            netState.Send( new WhisperAck( l_ExtendData.ROSEMobile, msg ) );
        }
        #endregion

        #region zh-CHS WorldServer Shout - 数据处理 | en WorldServer Shout - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerShout( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == false )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - l_ExtendData.m_bIsLoggedIn == false error!" );
                return;
            }

            if ( packetReader.Size < 7/*6 + 1 + ?*/ )
            {
                Debug.WriteLine( "CharPacketHandlers.LoginAction(...) - packetReader.Size < 7 error!" );
                return;
            }

            string msg = packetReader.ReadStringSafe();

            //SendToMap( &pak, thisclient->PlayerPosition->Map );

            netState.Send( new ShoutAck( l_ExtendData.ROSEMobile, msg ) );
        }
        #endregion

        #region zh-CHS WorldServer StartAttack - 数据处理 | en WorldServer StartAttack - OnPacketReceive
        public static void WorldServerStartAttack( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new StartAttackAck() );
        }
        #endregion

        #region zh-CHS WorldServer NPCBuy - 数据处理 | en WorldServer NPCBuy - OnPacketReceive
        public static void WorldServerNPCBuy( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new NPCBuyAck() );
        }
        #endregion

        #region zh-CHS WorldServer DoDrop - 数据处理 | en WorldServer DoDrop - OnPacketReceive
        public static void WorldServerDoDrop( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new DoDropAck() );
        }
        #endregion

        #region zh-CHS WorldServer ChangeEquip - 数据处理 | en WorldServer ChangeEquip - OnPacketReceive
        public static void WorldServerChangeEquip( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new ChangeEquipAck() );
        }
        #endregion

        #region zh-CHS WorldServer PickDrop - 数据处理 | en WorldServer PickDrop - OnPacketReceive
        public static void WorldServerPickDrop( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new PickDropAck() );
        }
        #endregion

        #region zh-CHS WorldServer Gate - 数据处理 | en WorldServer Gate - OnPacketReceive
        public static void WorldServerGate( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new GateAck() );
        }
        #endregion

        #region zh-CHS WorldServer AddStats - 数据处理 | en WorldServer AddStats - OnPacketReceive
        public static void WorldServerAddStats( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new AddStatsAck() );
        }
        #endregion

        #region zh-CHS WorldServer MoveSkill - 数据处理 | en WorldServer MoveSkill - OnPacketReceive
        public static void WorldServerMoveSkill( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new MoveSkillAck() );
        }
        #endregion

        #region zh-CHS WorldServer StartSkill - 数据处理 | en WorldServer StartSkill - OnPacketReceive
        public static void WorldServerStartSkill( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new StartSkillAck() );
        }
        #endregion

        #region zh-CHS WorldServer TradeAction - 数据处理 | en WorldServer TradeAction - OnPacketReceive
        public static void WorldServerTradeAction( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new TradeActionAck() );
        }
        #endregion

        #region zh-CHS WorldServer TradeAdd - 数据处理 | en WorldServer TradeAdd - OnPacketReceive
        public static void WorldServerTradeAdd( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new TradeAddAck() );
        }
        #endregion

        #region zh-CHS WorldServer ChangeCart - 数据处理 | en WorldServer ChangeCart - OnPacketReceive
        public static void WorldServerChangeCart( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new ChangeCartAck() );
        }
        #endregion

        #region zh-CHS WorldServer Party - 数据处理 | en WorldServer Party - OnPacketReceive
        public static void WorldServerParty( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new PartyAck() );
        }
        #endregion

        #region zh-CHS WorldServer PartyOpt - 数据处理 | en WorldServer PartyOpt - OnPacketReceive
        public static void WorldServerPartyOpt( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new PartyOptAck() );
        }
        #endregion

        #region zh-CHS WorldServer GameGuard - 数据处理 | en WorldServer GameGuard - OnPacketReceive
        public static void WorldServerGameGuard( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new GameGuardAck() );
        }
        #endregion

        #region zh-CHS WorldServer EquipArrows - 数据处理 | en WorldServer EquipArrows - OnPacketReceive
        public static void WorldServerEquipArrows( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new EquipArrowsAck() );
        }
        #endregion

        #region zh-CHS WorldServer Craft - 数据处理 | en WorldServer Craft - OnPacketReceive
        public static void WorldServerCraft( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new CraftAck() );
        }
        #endregion

        #region zh-CHS WorldServer AfterCraft - 数据处理 | en WorldServer AfterCraft - OnPacketReceive
        public static void WorldServerAfterCraft( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new AfterCraftAck() );
        }
        #endregion

        #region zh-CHS WorldServer Consume - 数据处理 | en WorldServer Consume - OnPacketReceive
        public static void WorldServerConsume( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new ConsumeAck() );
        }
        #endregion

        #region zh-CHS WorldServer Drill - 数据处理 | en WorldServer Drill - OnPacketReceive
        public static void WorldServerDrill( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new DrillAck() );
        }
        #endregion

        #region zh-CHS WorldServer Repair - 数据处理 | en WorldServer Repair - OnPacketReceive
        public static void WorldServerRepair( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new RepairAck() );
        }
        #endregion

        #region zh-CHS WorldServer Shop - 数据处理 | en WorldServer Shop - OnPacketReceive
        public static void WorldServerShop( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new ShopAck() );
        }
        #endregion

        #region zh-CHS WorldServer CloseShop - 数据处理 | en WorldServer CloseShop - OnPacketReceive
        public static void WorldServerCloseShop( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new CloseShopAck() );
        }
        #endregion

        #region zh-CHS WorldServer IncreaseSkillLvl - 数据处理 | en WorldServer IncreaseSkillLvl - OnPacketReceive
        public static void WorldServerIncreaseSkillLvl( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new IncreaseSkillLvlAck() );
        }
        #endregion

        #region zh-CHS WorldServer Buff - 数据处理 | en WorldServer Buff - OnPacketReceive
        public static void WorldServerBuff( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new BuffAck() );
        }
        #endregion

        #region zh-CHS WorldServer Quest - 数据处理 | en WorldServer Quest - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void WorldServerQuest( NetState netState, PacketReader packetReader )
        {
            WorldServerExtendData l_ExtendData = netState.ExtendData as WorldServerExtendData;
            if ( l_ExtendData == null )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData == null error!" );
                return;
            }

            if ( l_ExtendData.ROSEMobile.IsLoggedIn == true )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - l_ExtendData.m_bIsLoggedIn == true error!" );
                return;
            }

            if ( packetReader.Size < 42/*( 6 + 4 + 32)*/ )
            {
                Debug.WriteLine( "WorldPacketHandlers.WorldServerDoIdentify(...) - packetReader.Size < 42 error!" );
                return;
            }

            byte iAction = packetReader.ReadByte();
            byte iQuestPart = packetReader.ReadByte();
            uint iQuestId = packetReader.ReadUInt32();

            bool bQuestFlag = false;

            switch ( iAction)
            {
                case 0x02:

                    bQuestFlag = l_ExtendData.RemoveQuest( iQuestId );

                    iAction = 0x03;

                    break;
                case 0x03:

                    bQuestFlag = l_ExtendData.AddQuest( iQuestId );

                    iAction = 0x05;

                    break;
                default:

                    break;
            }

            if ( bQuestFlag )
                netState.Send( new QuestAck( iAction, iQuestPart, iQuestId ) );
        }
        #endregion

        #region zh-CHS WorldServer OpenStorage - 数据处理 | en WorldServer OpenStorage - OnPacketReceive
        public static void WorldServerOpenStorage( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new OpenStorageAck() );
        }
        #endregion

        #region zh-CHS WorldServer StorageItem - 数据处理 | en WorldServer StorageItem - OnPacketReceive
        public static void WorldServerStorageItem( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new StorageItemAck() );
        }
        #endregion

        #region zh-CHS WorldServer StorageZuly - 数据处理 | en WorldServer StorageZuly - OnPacketReceive
        public static void WorldServerStorageZuly( NetState netState, PacketReader packetReader )
        {
            //netState.Send( new StorageZulyAck() );
        }
        #endregion

        #region zh-CHS WorldServer Unknown0x079F - 数据处理 | en WorldServer Unknown0x079F - OnPacketReceive
        public static void WorldServerUnknown0x079F( NetState netState, PacketReader packetReader )
        {
        }
        #endregion
    }
}
#endregion