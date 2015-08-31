using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Collections;
using Demo.Wow.WorldServer.Common;
using Demo.Wow.WorldServer.Server;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class WorldPacketHandlers : BasePacketHandlers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        public static void World_HandleAuthSession( NetState netState, PacketReader packetReader )
        {
            WorldExtendData extendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_AuthSession(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "World_PacketHandlers.World_AuthSession(...) - extendData.IsLoggedIn == true error!" );
                return;
            }

            extendData.AuthSession = AuthSession.ReadWorldAuthSession( packetReader );

            Serial serial = PendingLogins.ExclusiveSerial.GetExclusiveSerial();
            PendingLogins.AddAuthenticate( serial, netState ); // 等待登陆

            // 通知 Realm Server 有新的客户端需要验证
            ProcessServer.RealmNetState.Send( new Realm_RequestSession( serial, extendData.AuthSession.AccountName ) );
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void InternalCallbackAuthenticate( NetState netState, PacketReader packetReader )
        {
            WorldExtendData worldExtendData = netState.GetComponent<WorldExtendData>( WorldExtendData.COMPONENT_ID );
            if ( worldExtendData == null )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleAuthSession(...) - worldExtendData == null error!" );

                netState.Send( new Word_AuthResponseError( ResponseCodes.AUTH_FAILED ) );
                return;
            }

            if ( worldExtendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "World_PacketHandlers.World_HandleAuthSession(...) - worldExtendData.IsLoggedIn == true error!" );

                netState.Send( new Word_AuthResponseError( ResponseCodes.AUTH_FAILED ) );
                return;
            }

            bool isNoError = packetReader.ReadBoolean();
            if ( isNoError == false )
            {
                netState.Send( new Word_AuthResponseError( ResponseCodes.AUTH_FAILED ) );
                return;
            }

            // 读取数据
            uint iAccountsGuid = packetReader.ReadUInt32();
            AccessLevel iAccessLevel = (AccessLevel)packetReader.ReadInt32();
            bool bIsTBC = packetReader.ReadBoolean();

            byte[] byteSessionKey = new byte[40];
            packetReader.ReadBuffer( ref byteSessionKey, 0, 40 );


            // 开始鉴别
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] byteAccountName = worldExtendData.AuthSession.AccountName.ToArrayInByte( Encoding.ASCII );
            byte[] byteT = ( (uint)0 ).ToArrayInByte();
            byte[] byteClientSeed = ( (uint)worldExtendData.AuthSession.ClientSeed ).ToArrayInByte();
            byte[] byteSeed = ( (uint)worldExtendData.ServerSeed ).ToArrayInByte();

            byte[] tempData0 = byteAccountName.Coalition( byteT );
            byte[] tempData1 = tempData0.Coalition( byteClientSeed );
            byte[] tempData2 = tempData1.Coalition( byteSeed );
            byte[] tempData3 = tempData2.Coalition( byteSessionKey );
            byte[] byteResult = sha1.ComputeHash( tempData3 );

            // 是否成功
            bool bIsOK = Algorithms.EqualCollections( byteResult, worldExtendData.AuthSession.Digest );
            if ( bIsOK == false )
            {
                netState.Send( new Word_AuthResponseError( (uint)ResponseCodes.AUTH_UNKNOWN_ACCOUNT ) );
                return;
            }

            // 初始化 加解密的Key
            worldExtendData.WowCrypt.InitKey( byteSessionKey, 40 );

            worldExtendData.CommonData.AccountsGuid = iAccountsGuid;
            worldExtendData.CommonData.AccountName = worldExtendData.AuthSession.AccountName;
            worldExtendData.CommonData.IsTBC = bIsTBC;

            //WowPlayerInfo wowPlayerInfo = new WowPlayerInfo();

            //wowPlayerInfo.AccessLevel = iAccessLevel;
            //wowPlayerInfo.AccountName = worldExtendData.AuthSession.AccountName;
            //wowPlayerInfo.Serial = iAccountsGuid;
            //wowPlayerInfo.ClientBuild = worldExtendData.AuthSession.ClientBuild;
            //wowPlayerInfo.LastPing = DateTime.Now;
            //wowPlayerInfo.IsTBC = bIsTBC;
            //wowPlayerInfo.NetState = netState;

            //Program.BaseWorld.CharacterManager.AddCharacter( wowPlayerInfo.Serial, wowPlayerInfo );

            if ( ProcessServer.WowZoneCluster.World.CharacterManager.Count < 600 || iAccessLevel == AccessLevel.GameMaster )
            {
                worldExtendData.IsLoggedIn = true;

                netState.Send( new Word_AuthResponse( bIsTBC ) );

                if ( worldExtendData.AuthSession.AddonInfo != null )
                    netState.Send( worldExtendData.AuthSession.AddonInfo );
            }
            else
            {
                // 等待玩家的减少
                WaitQueueLogins.Enqueue( netState );
            }
        }
    }
}
