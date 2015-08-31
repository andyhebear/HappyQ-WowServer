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
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Entity.Suit.Taxi
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTaxiNode : IPoint3D, IComparable, IComparable<BaseTaxiNode>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxiNodeId"></param>
        /// <param name="mapId"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <param name="zCoord"></param>
        public BaseTaxiNode( long taxiNodeId, long mapId, float xCoord, float yCoord, float zCoord )
        {
            m_TaxiNodeId = taxiNodeId;
            m_MapId = mapId;
            m_xCoord = xCoord;
            m_yCoord = yCoord;
            m_zCoord = zCoord;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_TaxiNodeId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long TaxiNodeId
        {
            get { return m_TaxiNodeId; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_MapId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long MapId
        {
            get { return m_MapId; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_xCoord;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_xCoord; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_yCoord;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_yCoord; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_zCoord;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_zCoord; }
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( BaseTaxiNode other )
        {
            if ( other == null )
                return 1;

            return m_TaxiNodeId.CompareTo( other.TaxiNodeId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( object xObject )
        {
            return CompareTo( xObject as BaseTaxiNode );
        }
        #endregion
    }
}
#endregion