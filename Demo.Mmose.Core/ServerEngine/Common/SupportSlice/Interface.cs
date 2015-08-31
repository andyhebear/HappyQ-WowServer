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

namespace Demo.Mmose.Core.Common.SupportSlice
{
    #region zh-CHS 接口 | en Interface
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdateSlice<T> where T : ISupportSlice
    {
        /// <summary>
        /// 
        /// </summary>
        void UpdateSlice( T supportSliceT );
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISupportSlice
    {
        /// <summary>
        /// 如果只想支持单线程操作调用，请调用InLockProcessSlice(...) 如果返回为真，则可以继续调用OnProcessSlice(..)，结束的时候请调用OutLockProcessSlice(...)
        /// 如果是多线程操作则可以直接调用
        /// </summary>
        void OnProcessSlice( DateTime updateDelta );

        /// <summary>
        /// 进入OnProcessSlice(..)的单线程内的回调锁
        /// </summary>
        /// <returns></returns>
        bool InLockProcessSlice();

        /// <summary>
        /// 离开OnProcessSlice(..)的单线程内的回调锁
        /// </summary>
        /// <returns></returns>
        void OutLockProcessSlice();
    }
    #endregion
}
#endregion