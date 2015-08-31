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
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Demo.Mmose.Core.Common.Component
{
    /// <summary>
    /// 
    /// </summary>
    public struct ComponentMessage
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        public ComponentMessage( long lComponentMessage )
        {
            m_Context = null;
            m_IsHashCode = false;
            m_ComponentMessage = lComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        public ComponentMessage( string strComponentMessage )
        {
            m_Context = null;

            if ( strComponentMessage == null )
                m_ComponentMessage = 0;
            else
                m_ComponentMessage = strComponentMessage.GetHashCode();

            m_IsHashCode = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        public ComponentMessage( long lComponentMessage, object context )
        {
            m_Context = context;
            m_IsHashCode = false;
            m_ComponentMessage = lComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        public ComponentMessage( string strComponentMessage, object context )
        {
            m_Context = context;

            if ( strComponentMessage == null )
                m_ComponentMessage = 0;
            else
                m_ComponentMessage = strComponentMessage.GetHashCode();

            m_IsHashCode = true;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ComponentMessage;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Value
        {
            get { return m_ComponentMessage; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private object m_Context;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public object Context
        {
            get { return m_Context; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( ComponentMessage ComponentMessageA, ComponentMessage ComponentMessageB )
        {
            return ComponentMessageA.m_ComponentMessage == ComponentMessageB.m_ComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( ComponentMessage ComponentMessageA, ComponentMessage ComponentMessageB )
        {
            return ComponentMessageA.m_ComponentMessage != ComponentMessageB.m_ComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator long( ComponentMessage componentMessage )
        {
            return componentMessage.m_ComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator ulong( ComponentMessage componentMessage )
        {
            return (ulong)componentMessage.m_ComponentMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        /// <returns></returns>
        public static implicit operator ComponentMessage( long lComponentMessage )
        {
            return new ComponentMessage( lComponentMessage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentMessage"></param>
        /// <returns></returns>
        public static implicit operator ComponentMessage( string strComponentMessage )
        {
            return new ComponentMessage( strComponentMessage );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_ComponentMessage );
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsHashCode;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_IsHashCode == true ? (int)m_ComponentMessage : m_ComponentMessage.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( xObject == null || !( xObject is ComponentMessage ) ) return false;

            return ( (ComponentMessage)xObject ).m_ComponentMessage == m_ComponentMessage;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherComponentMessage"></param>
        /// <returns></returns>
        public int CompareTo( ComponentMessage otherComponentMessage )
        {
            return m_ComponentMessage.CompareTo( otherComponentMessage.m_ComponentMessage );
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
            else if ( otherObject is ComponentMessage )
                return CompareTo( (ComponentMessage)otherObject );

            return -1;
        }
        #endregion
    }
}
#endregion