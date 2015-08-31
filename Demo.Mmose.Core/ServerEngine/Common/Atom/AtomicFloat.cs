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

namespace Demo.Mmose.Core.ServerEngine.Common.Atom
{
    /// <summary>
    /// 
    /// </summary>
    public class AtomicFloat : IComparable, IComparable<AtomicFloat>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public AtomicFloat( )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atomicFloat"></param>
        public AtomicFloat( float atomicFloat )
        {
            m_AtomicFloat = atomicFloat;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_AtomicFloat = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Value
        {
            get { return Thread.VolatileRead( ref m_AtomicFloat ); }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public float Add( float fAddValue )
        {
            float oldAtomicFloat = 0;
            float newAtomicFloat = 0;
            do
            {
                oldAtomicFloat = m_AtomicFloat;

                newAtomicFloat = oldAtomicFloat + fAddValue;

            } while ( Interlocked.CompareExchange( ref m_AtomicFloat, newAtomicFloat, oldAtomicFloat ) != oldAtomicFloat );

            return newAtomicFloat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAdd"></param>
        public float Set( float fSetValue )
        {
            return Interlocked.Exchange( ref m_AtomicFloat, fSetValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValue"></param>
        /// <param name="iCompare"></param>
        public float CompareExchange( float fSetValue, float fCompareValue )
        {
            return Interlocked.CompareExchange( ref m_AtomicFloat, fSetValue, fCompareValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) == Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) == atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) != Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) != atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) < Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) < atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) > Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) > atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) <= Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) <= atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicFloat atomicFloatA, AtomicFloat atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) >= Thread.VolatileRead( ref atomicFloatB.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( AtomicFloat atomicFloatA, float atomicFloatB )
        {
            return Thread.VolatileRead( ref atomicFloatA.m_AtomicFloat ) >= atomicFloatB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator float( AtomicFloat atomicFloat )
        {
            return Thread.VolatileRead( ref atomicFloat.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAtomicInt"></param>
        /// <returns></returns>
        public static implicit operator AtomicFloat( float fAtomicFloat )
        {
            return new AtomicFloat( fAtomicFloat );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_AtomicFloat.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            AtomicFloat atomicFloat = xObject as AtomicFloat;
            if ( atomicFloat == null )
                return false;

            return atomicFloat.m_AtomicFloat == m_AtomicFloat;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherAtomicInt"></param>
        /// <returns></returns>
        public int CompareTo( AtomicFloat otherAtomicFloat )
        {
            return m_AtomicFloat.CompareTo( otherAtomicFloat.m_AtomicFloat );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public int CompareTo( object otherObject )
        {
            AtomicFloat atomicFloat = otherObject as AtomicFloat;
            if ( atomicFloat == null )
                return 1;
            else
                return CompareTo( atomicFloat );
        }
        #endregion
    }
}
#endregion