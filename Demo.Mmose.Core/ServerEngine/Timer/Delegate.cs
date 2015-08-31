#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace

#endregion

namespace Demo.Mmose.Core.Timer
{
    #region zh-CHS ί�� | en Delegate
    /// <summary>
    /// ʱ��Ƭ��ί��
    /// </summary>
    public delegate void TimeSliceCallback();
    /// <summary>
    /// ���������ʱ��Ƭ��ί��
    /// </summary>
    /// <param name="oState"></param>
    public delegate void TimeSliceStateCallback( object oState );
    /// <summary>
    /// ����ָ�����ж����ʱ��Ƭ��ί��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tState"></param>
    public delegate void TimeSliceStateCallback<T>( T tState );
    #endregion
}
#endregion