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
using System.Collections;
using System.Collections.Generic;
#endregion

namespace Demo.Mmose.Core.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class NullEnumerable<T> : IEnumerable<T>
    {
        #region zh-CHS 私有的类 | en Private Class
        /// <summary>
        /// 
        /// </summary>
        private class NullEnumerator<V> : IEnumerator<V>
        {
            #region zh-CHS 接口实现 | en Interface Implementation
            /// <summary>
            /// 
            /// </summary>
            public void Reset()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            public V Current
            {
                get { return default( V ); }
            }

            /// <summary>
            /// 
            /// </summary>
            object IEnumerator.Current
            {
                get { return null; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                return false;
            }

            /// <summary>
            /// 
            /// </summary>
            public void Dispose()
            {
            }
            #endregion
        }
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal NullEnumerable()
        {
        }
        #endregion

        #region zh-CHS 共有静态属性 | en Public Static Properties

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static NullEnumerable<T> s_UniqueInstance = new NullEnumerable<T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static NullEnumerable<T> SingletonInstance
        {
            get { return s_UniqueInstance; }
        }

        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static readonly NullEnumerator<T> s_Enumerator = new NullEnumerator<T>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return s_Enumerator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return s_Enumerator;
        }
        #endregion
    }

    /// <summary>
    /// default
    /// </summary>
    public class NullEnumerable : NullEnumerable<object>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        internal NullEnumerable() : base()
        {
        }
        #endregion
    }
}
#endregion

