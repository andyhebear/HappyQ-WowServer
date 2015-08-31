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

namespace Demo.Mmose.Core.AIEngine.Trigger
{
    /// <summary>
    /// 
    /// </summary>
    public struct TriggerType : IComparable, IComparable<TriggerType>
    {
        #region zh-CHS 类常量 | en Class Constants
        /// <summary>
        /// 
        /// </summary>
        public static readonly TriggerType InvalidType = new TriggerType( -1 );
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEventType"></param>
        public TriggerType( long iTriggerType )
        {
            m_TriggerType = iTriggerType;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_TriggerType;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Value
        {
            get { return m_TriggerType; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType == TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType != TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType > TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType < TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType >= TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( TriggerType TriggerTypeA, TriggerType TriggerTypeB )
        {
            return TriggerTypeA.m_TriggerType <= TriggerTypeB.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEventType"></param>
        /// <returns></returns>
        public static implicit operator long( TriggerType triggerType )
        {
            return triggerType.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEventType"></param>
        /// <returns></returns>
        public static explicit operator ulong( TriggerType triggerType )
        {
            return (ulong)triggerType.m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEventType"></param>
        /// <returns></returns>
        public static implicit operator TriggerType( long lTriggerType )
        {
            return new TriggerType( lTriggerType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEventType"></param>
        /// <returns></returns>
        public static explicit operator TriggerType( ulong ulTriggerType )
        {
            return new TriggerType( (long)ulTriggerType );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_TriggerType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)m_TriggerType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( xObject == null || !( xObject is TriggerType ) ) return false;

            return ( (TriggerType)xObject ).m_TriggerType == m_TriggerType;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherEventType"></param>
        /// <returns></returns>
        public int CompareTo( TriggerType otherTriggerType )
        {
            return m_TriggerType.CompareTo( otherTriggerType.m_TriggerType );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public int CompareTo( object otherObject )
        {
            if ( otherObject == null )
                return 1;
            else if ( otherObject is TriggerType )
                return CompareTo( (TriggerType)otherObject );

            return -1;
        }
        #endregion
    }
}
#endregion