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

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Net;
using DogSE.Common;
using DogSE.Library.Log;
using DogSE.Library.Time;
using DogSE.Server.Net;

#endregion

namespace DogSE.Server.Core.Net
{
    /// <summary>
    /// 网络的主状态,每个连接都会产生新的NetState
    /// </summary>
    public sealed partial class NetState
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 有实例产生时调用
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <param name="world"></param>
        public NetState(ClientSession<NetState> clientSocket, WorldBase world)
            :this()
        {
            if (clientSocket == null)
                throw new ArgumentNullException("clientSocket", "NetState.NetState(...) - clientSocket == null error!");

            m_Socket = clientSocket;

            IPAddress ipAddress;
            IPAddress.TryParse(clientSocket.RemoteOnlyIP, out ipAddress);

            if (ipAddress == null)
                m_NetAddress = new IPEndPoint(IPAddress.None, clientSocket.RemotePort);
            else
                m_NetAddress = new IPEndPoint(ipAddress, clientSocket.RemotePort);
            World = world;

            ReceiveBuffer = new ReceiveQueue();
        }

        /// <summary>
        /// 无效实例产生时调用
        /// </summary>
        public NetState()
        {
            m_Socket = null;
            m_IPToString = "0.0.0.0";
            m_NextCheckActivity = DateTime.MaxValue;

            m_NetAddress = new IPEndPoint(IPAddress.None, 0);
        }
        #endregion

        /// <summary>
        /// 网络对象连接到的网络世界
        /// </summary>
        public WorldBase World { get; set; }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Serial m_Serial = Serial.MinusOne;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Serial Serial
        {
            get { return m_Serial; }
            set
            {
                m_Serial = value;
                m_Socket.Id = (int)value;
            }
        }

        /// <summary>
        /// 客户开始连接的时间
        /// </summary>
        public DateTime ConnectedOn
        {
            get { return m_Socket.ConnectTime; }
        }

        /// <summary>
        /// 客户总共连接的时间
        /// </summary>
        public TimeSpan ConnectedFor
        {
            get { return (OneServer.NowTime - m_Socket.ConnectTime); }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 客户的地址
        /// </summary>
        private IPEndPoint m_NetAddress;
        #endregion
        /// <summary>
        /// 客户的地址
        /// </summary>
        public IPEndPoint NetAddress
        {
            get { return m_NetAddress; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables

        /// <summary>
        /// 客户是否在运行
        /// </summary>
        private bool m_Running;

        #endregion
        /// <summary>
        /// 客户是否在运行, 如果没有表示已经断开了连接
        /// </summary>
        public bool Running
        {
            get { return m_Running; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 网络句柄
        /// </summary>
        private ClientSession<NetState> m_Socket;
        #endregion
        /// <summary>
        /// 客户端连接的句柄
        /// </summary>
        public ClientSession<NetState> NetSocket
        {
            get { return m_Socket; }
        }

        /// <summary>
        /// 接收到的环形缓冲区
        /// </summary>
        public ReceiveQueue ReceiveBuffer { get; set; }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 是否检查网络活动
        /// </summary>
        private bool m_bCheckAlive = true;
        #endregion
        /// <summary>
        /// 是否检查网络活动
        /// </summary>
        public bool IsCheckActivity
        {
            get { return m_bCheckAlive; }
            set { m_bCheckAlive = value; }
        }

        /// <summary>
        /// 是否验证过账户
        /// </summary>
        public bool IsVerifyLogin { get; set; }

        /// <summary>
        /// 业务逻辑id（通常是和连接绑定的账户/玩家 id，这个需要由业务逻辑层来进行修改）
        /// </summary>
        public int BizId { get; set; }

        #region zh-CHS 内部方法 | en Internal Method
        /// <summary>
        /// 开始运行客户端的处理
        /// </summary>
        internal void Start()
        {
            // 断开处理在设置NetState时候检测
            m_Running = true;
            m_Disposed = false;

            JoinWorld();

            // 设置NetState(需位于Start(...)函数之后)，检查是否已断开与已收到新数据。
            m_Socket.Data = this;
        }

        /// <summary>
        /// 进入World集合,在Start中调用
        /// </summary>
        internal void JoinWorld()
        {
            // 获取唯一的序号
            //m_Serial = m_World.NetStateManager.ExclusiveSerial.NextExclusiveSerial();
        }

        /// <summary>
        /// 退出World集合,在BaseWorld中调用
        /// </summary>
        internal void ExitWorld()
        {
            // 置空
            m_Serial = Serial.MinusOne;
            m_Running = false;
            m_Socket.Data = null;
            Player = null;
            World = null;
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 检查是否在线的时间段
        /// </summary>
        private DateTime m_NextCheckActivity = OneServer.NowTime;
        #endregion
        /// <summary>
        /// 检查用户是否在线,根据用户传输数据包的时间来判定
        /// </summary>
        /// <returns></returns>
        internal bool CheckAlive()
        {
            if (Running == false)
                return false;

            if (m_bCheckAlive == false || OneServer.NowTime < m_NextCheckActivity)
                return true;

            Dispose();

            return false;
        }
        #endregion

        #region zh-CHS 共有方法 | en public Method


        /// <summary>
        /// 发送数据(在多线程中主要实现了顺序的发送)
        /// </summary>
        /// <param name="packet">需要发送的数据包</param>
        public void Send(Packet packet)
        {
            if (Running == false)
                return;

            if (IsBatchNow)
                m_Socket.SendPackage(packet.WriterStream.GetBuffer(), false);
            else
                m_Socket.SendPackage(packet.WriterStream.GetBuffer());
            packet.Release();
        }

        /// <summary>
        /// 根据输出流来写数据
        /// </summary>
        /// <param name="writer"></param>
        public void Send(PacketWriter writer)
        {
            if (Running == false)
                return;

            if (IsBatchNow)
                m_Socket.SendPackage(writer.GetBuffer(), false);
            else
                m_Socket.SendPackage(writer.GetBuffer());
        }

        /// <summary>
        /// 是否处于批量发送中
        /// </summary>
        public bool IsBatchNow { get; private set; }

        /// <summary>
        /// 开始进行批量发送
        /// </summary>
        public void BeginBatch()
        {
            IsBatchNow = true;
        }

        /// <summary>
        /// 结束批量发送
        /// </summary>
        public void EndBatch()
        {
            IsBatchNow = false;
            m_Socket.PeekSend();
        }


        #region zh-CHS 私有常量 | en Private Constants

        /// <summary>
        /// 
        /// </summary>
        private const int DISCONNECT_SECOND = 5;

        #endregion
        /// <summary>
        /// 清理当前的网络数据,并断开连接(Flush == true 则默认5秒以后断开)
        /// </summary>
        public void Dispose()
        {
            //  TODO：这里是以前的代码，方法名存在歧义，没有资源回收的入口代码，目前组件模式的数据没有销毁
            Dispose(true);
        }


        #region zh-CHS 私有成员变量 | en Private Member Variables

        /// <summary>
        /// 是否已经处理过断开
        /// </summary>
        private bool m_Disposed = true;

        #endregion

        #region zh-CHS 私有 InsideDispose 方法 | en Private InsideDispose Methods
        /// <summary>
        /// 断开连接
        /// </summary>
        private void InsideDispose()
        {
            m_Socket.Close();
            m_Socket = null;
        }

        #endregion
        /// <summary>
        /// 清理当前的网络数据,并断开连接
        /// </summary>
        /// <param name="bFlush"></param>
        /// <param name="waitSeconds"></param>
        public void Dispose(bool bFlush, long waitSeconds = DISCONNECT_SECOND)
        {
            // 防止多线程时多次调用Dispose(...)有问题
            if (m_Disposed == false)
                return;

            if (bFlush)
            {
                //  延迟关闭，预留时间用于发送数据
                //TimeSlice.StartTimeSlice(TimeSpan.FromSeconds(waitSeconds), InsideDispose);
            }
            else
                InsideDispose();
        }

        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 当前实例的IP地址字符串
        /// </summary>
        private string m_IPToString = string.Empty;
        #endregion
        /// <summary>
        /// 当前实例的IP地址字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_IPToString;
        }
        #endregion

        #region zh-CHS 私有的事件处理函数 | en Private Event Handlers
        /// <summary>
        /// 
        /// </summary>
        internal void OnReceive()
        {
            if (Running == false)
                return;

            m_NextCheckActivity = OneServer.NowTime;
        }

        /// <summary>
        /// 调用ClientSocketHandler.CloseSocket(...)的时候会产生此调用
        /// </summary>
        internal void OnDisconnect()
        {
            // 默认是有效地，只检测有没有已经断开，如果已经断开，则不继续处理
            if (m_Running == false)
                return;

            m_Socket.Close();

        }
        #endregion

        private static NetState empty;

        /// <summary>
        /// NetState 的空对象，用来做默认填充物使用的
        /// </summary>
        public static NetState Empty
        
        {
            get
            {
                if (empty == null)
                    empty = new NetState();

                return empty;
            }
        }

        /// <summary>
        /// 错误数量
        /// </summary>
        public int ErrorCount { get; set; }
    }
}

