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
#endregion

namespace Demo.Mmose.Core.Network
{
    #region zh-CHS 事件数据的类 | en EventArgs
    /// <summary>
    /// 数据包处理事件数据
    /// </summary>
    public class NetStateEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public NetStateEventArgs( NetState netState )
        {
            m_NetState = netState;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private NetState m_NetState = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
        }

        #endregion
    }

    /// <summary>
    /// 创建NetState时的回调
    /// </summary>
    public class NetStateInitEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public NetStateInitEventArgs( NetState netStateInit )
        {
            m_NetStateInit = netStateInit;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private NetState m_NetStateInit = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public NetState NetStateInit
        {
            get { return m_NetStateInit; }
        }

        #endregion
    }

    /// <summary>
    /// NetState连接的回调
    /// </summary>
    public class NetStateConnectEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public NetStateConnectEventArgs( NetState netStateConnect )
        {
            m_NetStateConnect = netStateConnect;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private NetState m_NetStateConnect = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public NetState NetStateConnect
        {
            get { return m_NetStateConnect; }
        }

        #endregion
    }

    /// <summary>
    /// NetState断开的回调
    /// </summary>
    public class NetStateDisconnectEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public NetStateDisconnectEventArgs( NetState netStateDisconnect )
        {
            m_NetStateDisconnect = netStateDisconnect;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private NetState m_NetStateDisconnect = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public NetState NetStateDisconnect
        {
            get { return m_NetStateDisconnect; }
        }

        #endregion
    }

    /// <summary>
    /// 数据包处理事件数据
    /// </summary>
    public class PacketLengthInfoEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public PacketLengthInfoEventArgs( byte[] byteBuffer, long bufferSize, long iHeadIndex )
        {
            m_BufferSize = bufferSize;
            m_Buffer = byteBuffer;
            m_HeadIndex = iHeadIndex;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private long m_HeadIndex = 0;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public long HeadIndex
        {
            get { return m_HeadIndex; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 字节的数组(缓冲区数据)
        /// </summary>
        private byte[] m_Buffer = null;
        #endregion
        /// <summary>
        /// 缓冲区数据
        /// </summary>
        public byte[] Buffer
        {
            get { return m_Buffer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        private long m_BufferSize = 0;
        #endregion
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        public long BufferSize
        {
            get { return m_BufferSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_PacketLength = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long PacketLength
        {
            get { return m_PacketLength; }
            set { m_PacketLength = value; }
        }

        #endregion
    }

    /// <summary>
    /// 数据包处理事件数据
    /// </summary>
    public class PacketIdInfoEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public PacketIdInfoEventArgs( byte[] byteBuffer, long bufferSize, long iHeadIndex )
        {
            m_BufferSize = bufferSize;
            m_Buffer = byteBuffer;
            m_HeadIndex = iHeadIndex;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private long m_HeadIndex = 0;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public long HeadIndex
        {
            get { return m_HeadIndex; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 字节的数组(缓冲区数据)
        /// </summary>
        private byte[] m_Buffer = null;
        #endregion
        /// <summary>
        /// 缓冲区数据
        /// </summary>
        public byte[] Buffer
        {
            get { return m_Buffer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        private long m_BufferSize = 0;
        #endregion
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        public long BufferSize
        {
            get { return m_BufferSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_PacketId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long PacketId
        {
            get { return m_PacketId; }
            set { m_PacketId = value; }
        }
        #endregion
    }

    /// <summary>
    /// 数据包处理事件数据
    /// </summary>
    public class PacketHeadInfoEventArgs<PacketHeadT> : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public PacketHeadInfoEventArgs( byte[] byteBuffer, long bufferSize, long iHeadIndex )
        {
            m_BufferSize = bufferSize;
            m_Buffer = byteBuffer;
            m_HeadIndex = iHeadIndex;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private long m_HeadIndex = 0;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public long HeadIndex
        {
            get { return m_HeadIndex; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 字节的数组(缓冲区数据)
        /// </summary>
        private byte[] m_Buffer = null;
        #endregion
        /// <summary>
        /// 缓冲区数据
        /// </summary>
        public byte[] Buffer
        {
            get { return m_Buffer; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        private long m_BufferSize = 0;
        #endregion
        /// <summary>
        /// 环绕缓冲区数据内实际数据的大小
        /// </summary>
        public long BufferSize
        {
            get { return m_BufferSize; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private PacketHeadT m_PacketHead = default( PacketHeadT );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public PacketHeadT PacketHead
        {
            get { return m_PacketHead; }
            set { m_PacketHead = value; }
        }
        #endregion
    }

    /// <summary>
    /// 数据包处理事件数据
    /// </summary>
    public class NetStateSendPacketEventArgs : EventArgs
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="baseWorld"></param>
        /// <param name="strText"></param>
        /// <param name="state"></param>
        public NetStateSendPacketEventArgs( NetState sendNetState, Packet sendPack )
        {
            m_SendNetState = sendNetState;
            m_SendPacket = sendPack;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private NetState m_SendNetState = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public NetState SendNetState
        {
            get { return m_SendNetState; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 数据包的位置
        /// </summary>
        private Packet m_SendPacket = null;
        #endregion
        /// <summary>
        /// 缓冲区数据中有效的数据包的开始位置
        /// </summary>
        public Packet SendPacket
        {
            get { return m_SendPacket; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否取消发送
        /// </summary>
        private bool m_IsCancelSend = false;
        #endregion
        /// <summary>
        /// 是否取消发送
        /// </summary>
        public bool IsCancelSend
        {
            get { return m_IsCancelSend; }
            set { m_IsCancelSend = value; }
        }
        #endregion
    }
    #endregion

    #region zh-CHS 委托 | en Delegate
    /// <summary>
    /// NetState处理数据的委托
    /// </summary>
    /// <param name="netState"></param>
    public delegate void ProcessReceiveEventHandler( NetState netState );
    /// <summary>
    /// 处理数据包的回调
    /// </summary>
    /// <param name="netState"></param>
    /// <param name="packetReader"></param>
    public delegate void PacketReceiveCallback( NetState netState, PacketReader packetReader );
    /// <summary>
    /// 包长度的回调
    /// </summary>
    /// <param name="netState"></param>
    public delegate long PacketLengthEventHandler( PacketLengthInfoEventArgs eventArgs );
    /// <summary>
    /// 包ID的回调
    /// </summary>
    /// <param name="netState"></param>
    public delegate long PacketIDEventHandler( PacketIdInfoEventArgs eventArgs );
    #endregion
}
#endregion
