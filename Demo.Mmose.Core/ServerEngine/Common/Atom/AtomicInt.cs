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
    public class AtomicInt : IComparable, IComparable<AtomicInt>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public AtomicInt( )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atomicInt"></param>
        public AtomicInt( int atomicInt )
        {
            m_AtomicInt = atomicInt;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_AtomicInt = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int Value
        {
            get { return Thread.VolatileRead( ref m_AtomicInt ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public int Add( int iAddValue )
        {
            return Interlocked.Add( ref m_AtomicInt, iAddValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public int Set( int iSetValue )
        {
            return Interlocked.Exchange( ref m_AtomicInt, iSetValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        /// <param name="iCompare"></param>
        public int CompareExchange( int iSetValue, int iCompareValue )
        {
            return Interlocked.CompareExchange( ref m_AtomicInt, iSetValue, iCompareValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) == Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) == atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) != Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) != atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) < Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) < atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) > Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) > atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) <= Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) <= atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicInt atomicIntA, AtomicInt atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) >= Thread.VolatileRead( ref atomicIntB.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicInt atomicIntA, int atomicIntB )
        {
            return Thread.VolatileRead( ref atomicIntA.m_AtomicInt ) >= atomicIntB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static AtomicInt operator ++( AtomicInt atomicInt )
        {
            Interlocked.Increment( ref atomicInt.m_AtomicInt );
            return atomicInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static AtomicInt operator --( AtomicInt atomicInt )
        {
            Interlocked.Decrement( ref atomicInt.m_AtomicInt );
            return atomicInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator int( AtomicInt atomicInt )
        {
            return Thread.VolatileRead( ref atomicInt.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAtomicInt"></param>
        /// <returns></returns>
        public static implicit operator AtomicInt( int iAtomicInt )
        {
            return new AtomicInt( iAtomicInt );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_AtomicInt.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            AtomicInt atomicInt = xObject as AtomicInt;
            if ( atomicInt == null )
                return false;

            return atomicInt.m_AtomicInt == m_AtomicInt;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherAtomicInt"></param>
        /// <returns></returns>
        public int CompareTo( AtomicInt otherAtomicInt )
        {
            return m_AtomicInt.CompareTo( otherAtomicInt.m_AtomicInt );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public int CompareTo( object otherObject )
        {
            AtomicInt atomicInt = otherObject as AtomicInt;
            if ( atomicInt == null )
                return 1;
            else
                return CompareTo( atomicInt );
        }
        #endregion
    }
}
#endregion