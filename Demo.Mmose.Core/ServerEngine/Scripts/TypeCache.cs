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
using System.Reflection;
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 缓冲类型声明的类
    /// </summary>
    public class TypeCache
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 全部的类型声明
        /// </summary>
        private Type[] m_Types = Type.EmptyTypes;
        /// <summary>
        /// 类型声明的名称
        /// </summary>
        private TypeTable m_Names = new TypeTable();
        /// <summary>
        /// 类型声明的完全限定名, 包括类型声明的命名空间
        /// </summary>
        private TypeTable m_FullNames = new TypeTable();
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 获取一个程序集的全部类型申明
        /// </summary>
        public TypeCache( Assembly assembly )
        {
            if ( assembly == null )
                throw new Exception( "TypeCache.TypeCache(...) - assembly == null error!" );

            m_Types = assembly.GetTypes();

            Type typeofTypeAliasAttribute = typeof( TypeAliasAttribute );

            foreach ( Type type in m_Types )
            {
                m_Names.Add( type.Name, type );
                m_FullNames.Add( type.FullName, type );

                if ( type.IsDefined( typeofTypeAliasAttribute, false ) )
                {
                    object[] objectAttribute = type.GetCustomAttributes( typeofTypeAliasAttribute, false );

                    if ( objectAttribute != null && objectAttribute.Length > 0 )
                    {
                        TypeAliasAttribute typeAliasAttribute = objectAttribute[0] as TypeAliasAttribute;

                        if ( typeAliasAttribute != null )
                        {
                            for ( int iIndex = 0; iIndex < typeAliasAttribute.Aliases.Length; iIndex++ )
                                m_FullNames.Add( typeAliasAttribute.Aliases[iIndex], type );
                        }
                    }
                }
            }
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public Type[] Types
        {
            get { return m_Types; }
        }
        #endregion

        #region zh-CHS 内部属性 | en Internal Properties
        /// <summary>
        /// 
        /// </summary>
        internal TypeTable Names
        {
            get { return m_Names; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal TypeTable FullNames
        {
            get { return m_FullNames; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public Type GetTypeByName( string strName, bool ignoreCase )
        {
            return m_Names.Get( strName, ignoreCase );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFullName"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public Type GetTypeByFullName( string strFullName, bool ignoreCase )
        {
            return m_FullNames.Get( strFullName, ignoreCase );
        }
        #endregion
    }
}
#endregion

