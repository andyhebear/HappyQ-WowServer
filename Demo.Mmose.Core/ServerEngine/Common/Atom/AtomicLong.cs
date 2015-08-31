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
    public class AtomicLong : IComparable, IComparable<AtomicLong>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public AtomicLong( )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atomicLong"></param>
        public AtomicLong( long atomicLong )
        {
            m_AtomicLong = atomicLong;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_AtomicLong = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Value
        {
            get { return Thread.VolatileRead( ref m_AtomicLong ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public long Add( long lAddValue )
        {
            return Interlocked.Add( ref m_AtomicLong, lAddValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public long Set( long lSetValue )
        {
            return Interlocked.Exchange( ref m_AtomicLong, lSetValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        /// <param name="iCompare"></param>
        public long CompareExchange( long lSetValue, long lCompareValue )
        {
            return Interlocked.CompareExchange( ref m_AtomicLong, lSetValue, lCompareValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) == Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) == atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) != Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) != atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) < Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) < atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) > Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) > atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) <= Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) <= atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicLong atomicLongA, AtomicLong atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) >= Thread.VolatileRead( ref atomicLongB.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicLong atomicLongA, long atomicLongB )
        {
            return Thread.VolatileRead( ref atomicLongA.m_AtomicLong ) >= atomicLongB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static AtomicLong operator ++( AtomicLong atomicLong )
        {
            Interlocked.Increment( ref atomicLong.m_AtomicLong );
            return atomicLong;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static AtomicLong operator --( AtomicLong atomicLong )
        {
            Interlocked.Decrement( ref atomicLong.m_AtomicLong );
            return atomicLong;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator long( AtomicLong atomicLong )
        {
            return Thread.VolatileRead( ref atomicLong.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAtomicInt"></param>
        /// <returns></returns>
        public static implicit operator AtomicLong( long lAtomicLong )
        {
            return new AtomicLong( lAtomicLong );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_AtomicLong.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            AtomicLong atomicLong = xObject as AtomicLong;
            if ( atomicLong == null )
                return false;

            return atomicLong.m_AtomicLong == m_AtomicLong;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherAtomicInt"></param>
        /// <returns></returns>
        public int CompareTo( AtomicLong otherAtomicLong )
        {
            return m_AtomicLong.CompareTo( otherAtomicLong.m_AtomicLong );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public int CompareTo( object otherObject )
        {
            AtomicLong atomicLong = otherObject as AtomicLong;
            if ( atomicLong == null )
                return 1;
            else
                return CompareTo( atomicLong );
        }
        #endregion
    }
}
#endregion