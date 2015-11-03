﻿
//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2010 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com
// Update Version: by Dogvane - mailto:dogvane@gmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using DogSE.Server.Core.Protocol;

namespace DogSE.Server.Core.Task
{
    /// <summary>
    /// 数据包的主处理者
    /// </summary>
    public class PacketHandler
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPacketID"></param>
        /// <param name="priority"></param>
        /// <param name="onPacketReceive"></param>
        internal PacketHandler(ushort iPacketID, PacketPriority priority, PacketReceiveCallback onPacketReceive)
        {
            m_PacketID = iPacketID;
            m_PacketPriority = priority;
            m_OnReceive = onPacketReceive;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPacketID"></param>
        /// <param name="priority"></param>
        /// <param name="taskType"></param>
        /// <param name="onPacketReceive"></param>
        internal PacketHandler(ushort iPacketID, PacketPriority priority, TaskType taskType,
            PacketReceiveCallback onPacketReceive)
        {
            m_PacketID = iPacketID;
            m_PacketPriority = priority;
            m_OnReceive = onPacketReceive;
            m_TaskType = taskType;
        }

        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的ID
        /// </summary>
        private readonly ushort m_PacketID;
        #endregion
        /// <summary>
        /// 数据包的ID
        /// </summary>
        public ushort PacketID
        {
            get { return m_PacketID; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的优先级
        /// </summary>
        private readonly PacketPriority m_PacketPriority = PacketPriority.Normal;
        #endregion
        /// <summary>
        /// 数据包的优先级
        /// </summary>
        public PacketPriority PacketPriority
        {
            get { return m_PacketPriority; }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables


        #region zh-CHS 私有成员变量 | en Private Member Variables

        /// <summary>
        /// 数据实际处理的回调
        /// </summary>
        private readonly PacketReceiveCallback m_OnReceive;

        #endregion

        /// <summary>
        /// 数据实际处理的回调
        /// </summary>
        public PacketReceiveCallback OnReceive
        {
            get { return m_OnReceive; }
        }


        #endregion

                #region zh-CHS 私有成员变量 | en Private Member Variables

        /// <summary>
        /// 数据包的优先级
        /// </summary>
        private readonly TaskType m_TaskType = TaskType.Main;

        /// <summary>
        /// 数据包的优先级
        /// </summary>
        public TaskType TaskType
        {
            get { return m_TaskType; }
        }

        #endregion
    }
}