﻿#region zh-CHS 2006 - 2008 DemoSoft 团队 | en 2006 - 2008 DemoSoft Team

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
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Network
{
    /// <summary>
    /// 管理全部数据包的调用者
    /// </summary>
    [MultiThreadedNoSupport( "zh-CHS", "当前的类所有成员没有锁定(管理仅在主世界服务开始的时候创建的数据包处理调用者),不支持多线程操作" )]
    public class BasePacketHandlers
    {
        #region zh-CHS 公开方法 | en Public Method
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<long, PacketHandler> m_Handlers = new Dictionary<long, PacketHandler>();
        #endregion
        /// <summary>
        /// 注册数据包的处理调用者
        /// </summary>
        /// <param name="iPacketID"></param>
        /// <param name="iLength"></param>
        /// <param name="bInGame"></param>
        /// <param name="onPacketReceive"></param>
        [MultiThreadedWarning( "zh-CHS", "此处没有锁定用于内部调用的(无锁),请在主世界服务开始的时候注册全部的数据包调用,不支持多线程操作:警告!" )]
        public void Register( long iPacketID, long iLength, bool bInGame, PacketReceiveCallback onPacketReceive )
        {
            m_Handlers.Add( iPacketID, new PacketHandler( iPacketID, iLength, bInGame, onPacketReceive ) );
        }

        /// <summary>
        /// 获取数据包的处理调用者
        /// </summary>
        /// <param name="iPacketID"></param>
        /// <returns></returns>
        [MultiThreadedWarning( "zh-CHS", "此处没有锁定用于内部调用的(无锁),请在主世界服务开始的时候注册全部的数据包调用,不支持多线程操作:警告!" )]
        public PacketHandler GetHandler( long iPacketID )
        {
            PacketHandler packetHandler = null;
            m_Handlers.TryGetValue( iPacketID, out packetHandler );
            return packetHandler;
        }

        /// <summary>
        /// 移去数据包的处理调用者
        /// </summary>
        /// <param name="iPacketID"></param>
        [MultiThreadedWarning( "zh-CHS", "此处没有锁定用于内部调用的(无锁),请在主世界服务开始的时候注册全部的数据包调用,不支持多线程操作:警告!" )]
        public void RemoveHandler( long iPacketID )
        {
            m_Handlers.Remove( iPacketID );
        }
        #endregion
    }
}
#endregion

