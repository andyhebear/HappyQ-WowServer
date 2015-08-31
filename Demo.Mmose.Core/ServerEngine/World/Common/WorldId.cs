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
using System.Net;
#endregion

namespace Demo.Mmose.Core.World
{
    /// <summary>
    /// 
    /// </summary>
    public class WorldId : IComparable, IComparable<WorldId>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        public WorldId( string strID )
        {
            m_strID = strID;
            m_HashCode = m_strID.ToLower().GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        public WorldId( string strID, string strAddress, int iPort )
        {
            m_strID = strID;
            m_HashCode = m_strID.ToLower().GetHashCode();

            IPAddress netAddress = null;
            bool isOK = IPAddress.TryParse( strAddress, out netAddress );
            if ( isOK )
                m_NetAddress = new IPEndPoint( netAddress, iPort );
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_strID = string.Empty;
        #endregion
        /// <summary>
        /// World唯一的ID
        /// </summary>
        public string ID
        {
            get { return m_strID; }
            set
            {
                m_strID = value;
                m_HashCode = m_strID.ToLower().GetHashCode();
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// WorldID的地址和监听的端口
        /// </summary>
        private IPEndPoint m_NetAddress = new IPEndPoint( IPAddress.None, 0 );
        #endregion
        /// <summary>
        /// WorldID的地址和监听的端口
        /// </summary>
        public IPEndPoint NetAddress
        {
            get { return m_NetAddress; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strAddress"></param>
        /// <param name="iPort"></param>
        public void SetAddress( string strAddress, int iPort )
        {
            IPAddress netAddress = null;
            bool isOK = IPAddress.TryParse( strAddress, out netAddress );
            if ( isOK )
                m_NetAddress = new IPEndPoint( netAddress, iPort );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Override Methods
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_HashCode = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_HashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_strID;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int CompareTo( object obj )
        {
            if ( obj == null )
                return 1;

            string strCompare = obj as string;
            if ( strCompare != null )
                return m_strID.ToLower().CompareTo( strCompare.ToLower() );

            WorldId idCompare = obj as WorldId;
            if ( idCompare != null )
                return CompareTo( idCompare );

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( WorldId other )
        {
            return m_strID.ToLower().CompareTo( other.m_strID.ToLower() );
        }
        #endregion
    }
}
#endregion