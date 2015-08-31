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
using System.Diagnostics;
using Demo.Mmose.Core.Common;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 区域大小
    /// </summary>
    internal class RegionRect : IComparable
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Region m_Region;
        /// <summary>
        /// 
        /// </summary>
        private Rectangle3D m_Rect;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="rectangle3D"></param>
        public RegionRect( Region region, Rectangle3D rectangle3D )
        {
            m_Region = region;
            m_Rect = rectangle3D;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        /// <summary>
        /// 
        /// </summary>
        public Region Region
        {
            get { return m_Region; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Rectangle3D Rect
        {
            get { return m_Rect; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public bool Contains( Point3D point3D )
        {
            return m_Rect.Contains( point3D );
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public int CompareTo( object xObject )
        {
            if ( xObject == null )
                return -1;

            RegionRect regRect = xObject as RegionRect;
            if ( regRect == null )
            {
                Debug.WriteLine( "RegionRect.CompareTo(...) - regRect == null error:xObject is not a RegionRect!" );
                return -1;
            }

            return ( (IComparable)m_Region ).CompareTo( regRect.m_Region );
        }
        #endregion
    }
}
#endregion

