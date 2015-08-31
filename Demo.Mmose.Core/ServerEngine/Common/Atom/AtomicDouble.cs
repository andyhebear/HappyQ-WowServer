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
using System.Threading;
#endregion

namespace Demo.Mmose.Core.Common.Atom
{
    /// <summary>
    /// 
    /// </summary>
    public class AtomicDouble : IComparable, IComparable<AtomicDouble>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public AtomicDouble( )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atomicDouble"></param>
        public AtomicDouble( double atomicDouble )
        {
            m_AtomicDouble = atomicDouble;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private double m_AtomicDouble = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public double Value
        {
            get { return Thread.VolatileRead( ref m_AtomicDouble ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public double Add( double dAddValue )
        {
            double oldAtomicDouble = 0;
            double newAtomicDouble = 0;
            do
            {
                oldAtomicDouble = m_AtomicDouble;

                newAtomicDouble = oldAtomicDouble + dAddValue;

            } while ( Interlocked.CompareExchange( ref m_AtomicDouble, newAtomicDouble, oldAtomicDouble ) != oldAtomicDouble );

            return newAtomicDouble;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public double Set( double dSetValue )
        {
            return Interlocked.Exchange( ref m_AtomicDouble, dSetValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        /// <param name="iCompare"></param>
        public double CompareExchange( double dSetValue, double dCompareValue )
        {
            return Interlocked.CompareExchange( ref m_AtomicDouble, dSetValue, dCompareValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) == Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) == atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) != Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) != atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) < Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) < atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) > Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) > atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) <= Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) <= atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicDouble atomicDoubleA, AtomicDouble atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) >= Thread.VolatileRead( ref atomicDoubleB.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicDouble atomicDoubleA, double atomicDoubleB )
        {
            return Thread.VolatileRead( ref atomicDoubleA.m_AtomicDouble ) >= atomicDoubleB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator double( AtomicDouble atomicDouble )
        {
            return Thread.VolatileRead( ref atomicDouble.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAtomicInt"></param>
        /// <returns></returns>
        public static implicit operator AtomicDouble( double dAtomicDouble )
        {
            return new AtomicDouble( dAtomicDouble );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_AtomicDouble.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            AtomicDouble atomicDouble = xObject as AtomicDouble;
            if ( atomicDouble == null )
                return false;

            return atomicDouble.m_AtomicDouble == m_AtomicDouble;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherAtomicInt"></param>
        /// <returns></returns>
        public int CompareTo( AtomicDouble otherAtomicDouble )
        {
            return m_AtomicDouble.CompareTo( otherAtomicDouble.m_AtomicDouble );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public int CompareTo( object otherObject )
        {
            AtomicDouble atomicDouble = otherObject as AtomicDouble;
            if ( atomicDouble == null )
                return 1;
            else
                return CompareTo( atomicDouble );
        }
        #endregion
    }
}
#endregion