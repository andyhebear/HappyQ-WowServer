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
    public struct ComponentId : IComparable, IComparable<ComponentId>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentId"></param>
        public ComponentId( long lComponentId )
        {
            m_ComponentId = lComponentId;
            m_IsHashCode = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentId"></param>
        public ComponentId( string strComponentId )
        {
            if ( strComponentId == null )
                m_ComponentId = 0;
            else
                m_ComponentId = strComponentId.GetHashCode();
            m_IsHashCode = true;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_ComponentId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Value
        {
            get { return m_ComponentId; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( ComponentId ComponentIdA, ComponentId ComponentIdB )
        {
            return ComponentIdA.m_ComponentId == ComponentIdB.m_ComponentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( ComponentId ComponentIdA, ComponentId ComponentIdB )
        {
            return ComponentIdA.m_ComponentId != ComponentIdB.m_ComponentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator long( ComponentId componentId )
        {
            return componentId.m_ComponentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator ulong( ComponentId componentId )
        {
            return (ulong)componentId.m_ComponentId;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentId"></param>
        /// <returns></returns>
        public static implicit operator ComponentId( long lComponentId )
        {
            return new ComponentId( lComponentId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iComponentId"></param>
        /// <returns></returns>
        public static implicit operator ComponentId( string strComponentId )
        {
            return new ComponentId( strComponentId );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_ComponentId );
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
            return m_IsHashCode == true ? (int)m_ComponentId : m_ComponentId.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( xObject == null || !( xObject is ComponentId ) ) return false;

            return ( (ComponentId)xObject ).m_ComponentId == m_ComponentId;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherComponentId"></param>
        /// <returns></returns>
        public int CompareTo( ComponentId otherComponentId )
        {
            return m_ComponentId.CompareTo( otherComponentId.m_ComponentId );
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
            else if ( otherObject is ComponentId )
                return CompareTo( (ComponentId)otherObject );

            return -1;
        }
        #endregion
    }
}
#endregion