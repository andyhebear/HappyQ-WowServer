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
using System.Diagnostics;
using System.Reflection;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Server;
#endregion

namespace Demo.Mmose.Core.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public class ScriptAssemblyInfo : IScriptVersionInfo
    {
        #region zh-CHS ScriptAssembly属性 | en ScriptAssembly Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Assembly[] m_ScriptAssembly = new Assembly[0];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Assembly[] ScriptAssembly
        {
            get { return m_ScriptAssembly; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteHashCode"></param>
        internal void AddScriptAssembly( Assembly scriptAssembly )
        {
            // 创建新的Assembly数组,添加数据,交换数组数据,不需要锁定,没有引用时自动会回收数据
            Assembly[] tempAssemblyArray = new Assembly[m_ScriptAssembly.Length + 1];

            for ( int iIndex = 0; iIndex < m_ScriptAssembly.Length; ++iIndex )
                tempAssemblyArray[iIndex] = m_ScriptAssembly[iIndex];

            tempAssemblyArray[m_ScriptAssembly.Length] = scriptAssembly;
            m_TypeCache[scriptAssembly] = new TypeCache( scriptAssembly );

            m_ScriptAssembly = tempAssemblyArray;
        }
        #endregion

        #endregion

        #region zh-CHS HashCode方法 | en HashCode Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<Assembly, byte[]> m_ScriptAssemblyInfos = new Dictionary<Assembly, byte[]>();
        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteHashCode"></param>
        internal void AddHashCode( Assembly assembly, byte[] byteHashCode )
        {
            if ( assembly == null || byteHashCode == null )
                throw new Exception( "ScriptAssemblyInfo.GetScriptFiles(...) - assembly == null || byteHashCode == null error!" );

            m_ScriptAssemblyInfos[assembly] = byteHashCode;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 给出编译的程序集合的唯一的Hash代码
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public byte[] GetHashCode( Assembly assembly )
        {
            if ( assembly == null )
                throw new Exception( "ScriptAssemblyInfo.GetHashCode(...) - assembly == null error!" );

            byte[] byteHashCode = null;

            if ( m_ScriptAssemblyInfos.TryGetValue( assembly, out byteHashCode ) == true )
                return byteHashCode;
            else
                return new byte[0];
        }
        #endregion

        #endregion

        #region zh-CHS ScriptFiles方法 | en ScriptFiles Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<Assembly, string[]> m_ScriptFiles = new Dictionary<Assembly, string[]>();
        #endregion

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteHashCode"></param>
        internal void AddScriptFiles( Assembly assembly, string[] scriptFiles )
        {
            if ( assembly == null || scriptFiles == null )
                throw new Exception( "ScriptAssemblyInfo.GetScriptFiles(...) - assembly == null || scriptFiles == null error!" );

            m_ScriptFiles[assembly] = scriptFiles;
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 给出所编译的程序集合的所有文件
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string[] GetScriptFiles( Assembly assembly )
        {
            if ( assembly == null )
                throw new Exception( "ScriptAssemblyInfo.GetScriptFiles(...) - assembly == null error!" );

            string[] scriptFiles = null;

            if ( m_ScriptFiles.TryGetValue( assembly, out scriptFiles ) == true )
                return scriptFiles;
            else
                return null;
        }
        #endregion

        #endregion

        #region zh-CHS TypeCache方法 | en TypeCache Methods

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<Assembly, TypeCache> m_TypeCache = new Dictionary<Assembly, TypeCache>();
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 给出所编译的程序集合的所有文件
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public TypeCache GetTypeCache( Assembly assembly )
        {
            if ( assembly == null )
                throw new Exception( "ScriptAssemblyInfo.GetTypeCache(...) - assembly == null error!" );

            TypeCache typeCache = null;

            if ( m_TypeCache.TryGetValue( assembly, out typeCache ) == true )
                return typeCache;
            else
                return null;
        }
        #endregion

        #endregion

        #region zh-CHS 接口实现 | en Interface Implementation

        #region zh-CHS ScriptName属性 | en ScriptName Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_ScriptName = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string ScriptName
        {
            get { return m_ScriptName; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteHashCode"></param>
        internal void SetScriptName( string scriptName )
        {
            if ( scriptName == null )
                throw new Exception( "ScriptAssemblyInfo.SetScriptName(...) - scriptName == null error!" );

            m_ScriptName = scriptName;
        }
        #endregion

        #endregion

        #region zh-CHS Version属性 | en Version Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private VersionInfo m_VersionInfo = new VersionInfo( 0, 0, 0, 0 );
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public VersionInfo Version
        {
            get { return m_VersionInfo; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteHashCode"></param>
        internal void SetVersion( VersionInfo versionInfo )
        {
            if ( versionInfo == null )
                throw new Exception( "ScriptAssemblyInfo.SetVersion(...) - versionInfo == null error!" );

            m_VersionInfo = versionInfo;
        }
        #endregion

        #endregion

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private static TypeCache s_AssemblyTypeCache = null;
        #endregion
        /// <summary>
        /// 给出全部限定名的类型申明,忽略大小写
        /// </summary>
        public Type FindTypeByFullName( string strFullName )
        {
            return FindTypeByFullName( strFullName, true );
        }

        /// <summary>
        /// 给出全部限定名的类型申明,是否忽略大小写
        /// </summary>
        public Type FindTypeByFullName( string strFullName, bool bIgnoreCase )
        {
            Type type = null;

            for ( int iIndex = 0; type == null && iIndex < m_ScriptAssembly.Length; ++iIndex )
            {
                TypeCache typeCache = GetTypeCache( m_ScriptAssembly[iIndex] );
                if ( typeCache == null )
                    continue;

                type = typeCache.GetTypeByFullName( strFullName, bIgnoreCase );
                if ( type != null )
                    break;
            }

            if ( type == null )
            {
                if ( s_AssemblyTypeCache == null )
                    s_AssemblyTypeCache = new TypeCache( OneServer.Assembly );

                type = s_AssemblyTypeCache.GetTypeByFullName( strFullName, bIgnoreCase );
            }

            return type;
        }

        /// <summary>
        /// 给出类型申明,忽略大小写
        /// </summary>
        public Type FindTypeByName( string strName )
        {
            return FindTypeByName( strName, true );
        }

        /// <summary>
        /// 给出类型申明,是否忽略大小写
        /// </summary>
        public Type FindTypeByName( string strName, bool bIgnoreCase )
        {
            Type type = null;

            for ( int iIndex = 0; type == null && iIndex < m_ScriptAssembly.Length; ++iIndex )
            {
                TypeCache typeCache = GetTypeCache( m_ScriptAssembly[iIndex] );
                if ( typeCache == null )
                    continue;

                type = typeCache.GetTypeByName( strName, bIgnoreCase );
                if ( type != null )
                    break;
            }

            if ( type == null )
            {
                if ( s_AssemblyTypeCache == null )
                    s_AssemblyTypeCache = new TypeCache( OneServer.Assembly );

                type = s_AssemblyTypeCache.GetTypeByName( strName, bIgnoreCase );
            }

            return type;
        }
        #endregion
    }
}
#endregion
