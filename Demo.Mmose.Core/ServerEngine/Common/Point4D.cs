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

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Point4D : IPoint4D, IComparable, IComparable<Point4D>
    {
        #region zh-CHS 类常量 | en Class Constants
        /// <summary>
        /// 
        /// </summary>
        public static readonly Point4D Zero = new Point4D( 0, 0, 0, 0 );
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point4D( float x, float y, float z, float orientation )
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
            m_O = orientation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        public Point4D( IPoint4D point4D )
            : this( point4D.X, point4D.Y, point4D.Z, point4D.O )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3D"></param>
        public Point4D( IPoint3D point3D, float orientation )
            : this( point3D.X, point3D.Y, point3D.Z, orientation )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point2D"></param>
        /// <param name="z"></param>
        public Point4D( IPoint2D point2D, float z, float orientation )
            : this( point2D.X, point2D.Y, z, orientation )
        {
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_X;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Y;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Z;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_O;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float O
        {
            get { return m_O; }
            set { m_O = value; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Point4D Parse( string value )
        {
            int iStart = value.IndexOf( '(' );
            int iEnd = value.IndexOf( ',', iStart + 1 );

            string strParam1 = value.Substring( iStart + 1, iEnd - ( iStart + 1 ) ).Trim();

            iStart = iEnd;
            iEnd = value.IndexOf( ',', iStart + 1 );

            string strParam2 = value.Substring( iStart + 1, iEnd - ( iStart + 1 ) ).Trim();

            iStart = iEnd;
            iEnd = value.IndexOf( ',', iStart + 1 );

            string strParam3 = value.Substring( iStart + 1, iEnd - ( iStart + 1 ) ).Trim();

            iStart = iEnd;
            iEnd = value.IndexOf( ')', iStart + 1 );

            string strParam4 = value.Substring( iStart + 1, iEnd - ( iStart + 1 ) ).Trim();

            return new Point4D( Convert.ToSingle( strParam1 ), Convert.ToSingle( strParam2 ), Convert.ToSingle( strParam3 ), Convert.ToSingle( strParam4 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( Point4D xCompare, Point4D yCompare )
        {
            return xCompare.m_X == yCompare.m_X && xCompare.m_Y == yCompare.m_Y && xCompare.m_Z == yCompare.m_Z && xCompare.m_O == yCompare.O;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( Point4D xCompare, IPoint4D yCompare )
        {
            if ( object.ReferenceEquals( yCompare, null ) )
                return false;

            return xCompare.m_X == yCompare.X && xCompare.m_Y == yCompare.Y && xCompare.m_Z == yCompare.Z && xCompare.m_O == yCompare.O;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( Point4D xCompare, Point4D yCompare )
        {
            return xCompare.m_X != yCompare.m_X || xCompare.m_Y != yCompare.m_Y || xCompare.m_Z != yCompare.m_Z || xCompare.m_O != yCompare.O;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( Point4D xCompare, IPoint4D yCompare )
        {
            if ( object.ReferenceEquals( yCompare, null ) )
                return false;

            return xCompare.m_X != yCompare.X || xCompare.m_Y != yCompare.Y || xCompare.m_Z != yCompare.Z || xCompare.m_O != yCompare.O;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator Point2D( Point4D point4D )
        {
            return new Point2D( point4D );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator Point3D( Point4D point4D )
        {
            return new Point3D( point4D );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( xObject == null )
                return false;

            IPoint4D point4D = xObject as IPoint4D;
            if ( point4D == null )
                return false;

            return m_X == point4D.X && m_Y == point4D.Y && m_Z == point4D.Z && m_O == point4D.O; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)m_X ^ (int)m_Y ^ (int)m_Z ^ (int)m_O;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "({0}, {1}, {2}, {3} )", m_X, m_Y, m_Z, m_O );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( Point4D other )
        {
            int iCompare = ( m_X.CompareTo( other.m_X ) );

            if ( iCompare == 0 )
            {
                iCompare = ( m_Y.CompareTo( other.m_Y ) );

                if ( iCompare == 0 )
                {
                    iCompare = ( m_Z.CompareTo( other.m_Z ) );

                    if ( iCompare == 0 )
                        iCompare = ( m_O.CompareTo( other.m_O ) );
                }
            }

            return iCompare;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( object other )
        {
            if ( other == null )
                return 1;

            if ( other is Point4D == false )
                return 1;

            return CompareTo( (Point4D)other );
        }
        #endregion
    }
}
#endregion