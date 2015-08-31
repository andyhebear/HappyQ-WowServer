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
using System.Threading;
using Demo.Mmose.Core.Util;
#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 
    /// </summary>
    public struct Serial : IComparable, IComparable<Serial>
    {
        #region zh-CHS 类常量 | en Class Constants
        /// <summary>
        /// 
        /// </summary>
        public static readonly Serial MinusOne = new Serial( -1 );
        /// <summary>
        /// 
        /// </summary>
        public static readonly Serial Zero = new Serial( 0 );
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        public Serial( long lSerial )
        {
            m_Serial = lSerial;
        }
        #endregion

        #region zh-CHS 属性 | en Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_Serial;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long Value
        {
            get { return m_Serial; }
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial == serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial != serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial > serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial < serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator >=( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial >= serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator <=( Serial serialA, Serial serialB )
        {
            return serialA.m_Serial <= serialB.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static implicit operator long( Serial serial )
        {
            return serial.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator ulong( Serial serial )
        {
            return (ulong)serial.m_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static implicit operator Serial( long lSerial )
        {
            return new Serial( lSerial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSerial"></param>
        /// <returns></returns>
        public static explicit operator Serial( ulong ulSerial )
        {
            return new Serial( (long)ulSerial );
        }
        #endregion

        #region zh-CHS 方法覆盖 | en Method Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format( "0x{0:X8}", m_Serial );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return m_Serial.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xObject"></param>
        /// <returns></returns>
        public override bool Equals( object xObject )
        {
            if ( xObject == null || !( xObject is Serial ) ) return false;

            return ( (Serial)xObject ).m_Serial == m_Serial;
        }
        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherSerial"></param>
        /// <returns></returns>
        public int CompareTo( Serial otherSerial )
        {
            return m_Serial.CompareTo( otherSerial.m_Serial );
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
            else if ( otherObject is Serial )
                return CompareTo( (Serial)otherObject );

            return -1;
        }
        #endregion
    }

    /// <summary>
    /// 给出唯一的Serial
    /// </summary>
    [MultiThreadedSupport( "zh-CHS", "当前的类所有成员都可锁定,支持多线程操作" )]
    public class ExclusiveSerial
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Queue<long> m_ExclusiveSerial = new Queue<long>( 20 );
        /// <summary>
        /// 
        /// </summary>
        private SpinLock m_LockExclusiveSerial = new SpinLock();
        /// <summary>
        /// 
        /// </summary>
        private long m_ExclusiveSerialIndexId = 0;
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        public Serial GetExclusiveSerial()
        {
            Serial serial = Serial.Zero;

            m_LockExclusiveSerial.Enter();
            {
                if ( m_ExclusiveSerial.Count > 0 )
                    serial = m_ExclusiveSerial.Dequeue();
                else
                    serial = Interlocked.Increment( ref m_ExclusiveSerialIndexId );
            }
            m_LockExclusiveSerial.Exit();

            return serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public void ReleaseSerial( Serial serial )
        {
            m_LockExclusiveSerial.Enter();
            {
                m_ExclusiveSerial.Enqueue( serial );
            }
            m_LockExclusiveSerial.Exit();
        }
        #endregion
    }
}
#endregion