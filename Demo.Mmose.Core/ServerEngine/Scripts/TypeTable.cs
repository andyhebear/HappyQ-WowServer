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
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 类型声明的集合类
    /// </summary>
    internal class TypeTable
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 大小写敏感
        /// </summary>
        private Dictionary<string, Type> m_Sensitive;
        /// <summary>
        /// 大小写不敏感
        /// </summary>
        private Dictionary<string, Type> m_Insensitive;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化类型声明的集合
        /// </summary>
        public TypeTable()
        {
            m_Sensitive = new Dictionary<string, Type>();
            m_Insensitive = new Dictionary<string, Type>( StringComparer.OrdinalIgnoreCase );
        }
        #endregion

        #region zh-CHS 方法 | en Method
        /// <summary>
        /// 添加类型声明
        /// </summary>
        public void Add( string key, Type type )
        {
            m_Sensitive[key] = type;
            m_Insensitive[key] = type;
        }

        /// <summary>
        /// 给出类型声明
        /// </summary>
        public Type Get( string key, bool ignoreCase )
        {
            Type type = null;

            if ( ignoreCase == true )
                m_Insensitive.TryGetValue( key, out type );
            else
                m_Sensitive.TryGetValue( key, out type );

            return type;
        }
        #endregion
    }
}
#endregion

