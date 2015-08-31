using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Demo.Mmose.Core.Timer;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Server;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class RealmPacketHandlers : BasePacketHandlers
    {
        #region zh-CHS Realm_RegisterRealmResult - 数据处理 | en Realm_RegisterRealmResult - OnPacketReceive
        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        /// <param name="packetReader"></param>
        internal static void Realm_HandleRegisterRealmResult( NetState netState, PacketReader packetReader )
        {
            RealmExtendData extendData = netState.GetComponent<RealmExtendData>( RealmExtendData.COMPONENT_ID );
            if ( extendData == null )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRegisterRealmResult(...) - extendData == null error!" );
                return;
            }

            if ( extendData.IsLoggedIn == true )
            {
                Debug.WriteLine( "Realm_PacketHandlers.Realm_HandleRegisterRealmResult(...) - extendData.IsLoggedIn == true error!" );
                return;
            }

            uint iRealmSerial = packetReader.ReadUInt32();

            extendData.RegisterRealmResult.Serial = new Serial( iRealmSerial );

            // 已经登陆
            extendData.IsLoggedIn = true;

            // 3分钟 向服务端发一次心跳信号
            TimeSlice.StartTimeSlice( TimerPriority.Lowest, TimeSpan.FromMinutes( 3 ), TimeSpan.FromMinutes( 3 ), new TimeSliceCallback( SendPing ) );

            LOGs.WriteLine( LogMessageType.MSG_INFO, "RealmServer：登陆RealmServer服务器成功 返回的标示ID({0})", extendData.RegisterRealmResult.Serial.ToString() );
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SendPing()
        {
            ProcessServer.RealmNetState.Send( new Realm_Ping() );
        }
        #endregion
    }
}
