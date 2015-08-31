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

#endregion

namespace Demo.Mmose.Core.Network
{
    #region zh-CHS 枚举 | en Enum
    /// <summary>
    /// 登陆返回的错误
    /// </summary>
    public enum LoginReason : byte
    {
        /// <summary>
        /// 帐号有效
        /// </summary>
        Finish = 0x00,
        /// <summary>
        /// 普通的错误
        /// </summary>
        GeneralError = 0x01,
        /// <summary>
        /// 错误的名字
        /// </summary>
        NameError = 0x02,
        /// <summary>
        /// 错误的密码
        /// </summary>
        PasswordError = 0x03,
        /// <summary>
        /// 帐号已在使用
        /// </summary>
        InUse = 0x04,
        /// <summary>
        /// 帐号已禁止
        /// </summary>
        Blocked = 0x05,
        /// <summary>
        /// 帐号已到期
        /// </summary>
        TopUpAccount = 0x06,
        /// <summary>
        /// 连接服务器错误
        /// </summary>
        ServerError = 0x07,
        /// <summary>
        /// 服务器容量已满
        /// </summary>
        ServerCapacityFull = 0x08,
        /// <summary>
        /// 帐号检测无效
        /// </summary>
        AccountInvalid = 0x09,
        /// <summary>
        /// 登陆失败
        /// </summary>
        LoginFailed = 0x0A,
        /// <summary>
        /// IP容量已满
        /// </summary>
        IPCapacityFull = 0x0B,
        /// <summary>
        /// 空闲
        /// </summary>
        Idle = 0xFE,
        /// <summary>
        /// 错误的命令
        /// </summary>
        BadCommand = 0xFF
    }

    /// <summary>
    /// Provides the fields that represent reference points in streams for seeking.
    /// </summary>
    public enum SeekOrigin
    {
        /// <summary>
        /// Specifies the beginning of a stream.
        /// </summary>
        Begin = 0,
        /// <summary>
        /// Specifies the current position within a stream.
        /// </summary>
        Current = 1,
        /// <summary>
        /// Specifies the end of a stream.
        /// </summary>
        End = 2,
    }

    /// <summary>
    /// 指定 NetState 的发送优先级。
    /// </summary>
    public enum SendPriority
    {
        /// <summary>
        /// 可以将 NetState 安排在具有任何其他优先级的线程之后。
        /// </summary>
        Lowest = 0,
        /// <summary>
        /// 可以将 NetState 安排在具有 Normal 优先级的线程之后，在具有 Lowest 优先级的线程之前。
        /// </summary>
        BelowNormal = 1,
        /// <summary>
        /// 可以将 NetState 安排在具有 AboveNormal 优先级的线程之后，在具有 BelowNormal 优先级的线程之前。默认情况下，线程具有 Normal 优先级。
        /// </summary>
        Normal = 2,
        /// <summary>
        /// 可以将 NetState 安排在具有 Highest 优先级的线程之后，在具有 Normal 优先级的线程之前。
        /// </summary>
        AboveNormal = 3,
        /// <summary>
        /// 可以将 NetState 安排在具有任何其他优先级的线程之前。
        /// </summary>
        Highest = 4,
    }
    #endregion
}
#endregion

