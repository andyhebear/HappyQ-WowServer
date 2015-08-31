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
    #region zh-CHS 类 - 自定义属性 | en Class - Attribute
    /// <summary>
    /// 类并不支持在多线程中调用并处理
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true )]
    public class MultiThreadedNoSupportAttribute : Attribute
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 类并不支持在多线程中调用并处理
        /// </summary>
        public MultiThreadedNoSupportAttribute( string strLanguage, string strInfo )
        {
            m_strLanguage = strLanguage;
            m_strInfo = strInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 不支持多线程的详细信息
        /// </summary>
        private string m_strLanguage;
        #endregion
        /// <summary>
        /// Info信息的语言
        /// </summary>
        public string Language
        {
            get { return m_strLanguage; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 不支持多线程的详细信息
        /// </summary>
        private string m_strInfo;
        #endregion
        /// <summary>
        /// 不支持多线程的详细信息
        /// </summary>
        public string Info
        {
            get { return m_strInfo; }
        }
        #endregion
    }

    /// <summary>
    /// 类支持在多线程中调用并处理
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true )]
    public class MultiThreadedSupportAttribute : Attribute
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 类支持在多线程中调用并处理
        /// </summary>
        public MultiThreadedSupportAttribute( string strLanguage, string strInfo )
        {
            m_strLanguage = strLanguage;
            m_strInfo = strInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 不支持多线程的详细信息
        /// </summary>
        private string m_strLanguage;
        #endregion
        /// <summary>
        /// Info信息的语言
        /// </summary>
        public string Language
        {
            get { return m_strLanguage; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 支持多线程的详细信息
        /// </summary>
        private string m_strInfo;
        #endregion
        /// <summary>
        /// 支持多线程的详细信息
        /// </summary>
        public string Info
        {
            get { return m_strInfo; }
        }
        #endregion
    }

    /// <summary>
    /// 在多线程中调用并处理时需要注意，可能需要锁定再调用
    /// </summary>
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Event, AllowMultiple = true )]
    public class MultiThreadedWarningAttribute : Attribute
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 在多线程中调用并处理时需要注意，可能需要锁定再调用
        /// </summary>
        public MultiThreadedWarningAttribute( string strLanguage, string strInfo )
        {
            m_strLanguage = strLanguage;
            m_strInfo = strInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 不支持多线程的详细信息
        /// </summary>
        private string m_strLanguage;
        #endregion
        /// <summary>
        /// Info信息的语言
        /// </summary>
        public string Language
        {
            get { return m_strLanguage; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 多线程的警告信息
        /// </summary>
        private string m_strInfo;
        #endregion
        /// <summary>
        /// 多线程的警告信息
        /// </summary>
        public string Info
        {
            get { return m_strInfo; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage( AttributeTargets.Property )]
    public class CommandPropertyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_ReadLevel;
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel ReadLevel
        {
            get { return m_ReadLevel; }
        }

        /// <summary>
        /// 
        /// </summary>
        private AccessLevel m_WriteLevel;
        /// <summary>
        /// 
        /// </summary>
        public AccessLevel WriteLevel
        {
            get { return m_WriteLevel; }
        }

        public CommandPropertyAttribute( AccessLevel level )
            : this( level, level )
        {
        }

        public CommandPropertyAttribute( AccessLevel readLevel, AccessLevel writeLevel )
        {
            m_ReadLevel = readLevel;
            m_WriteLevel = writeLevel;
        }
    }
    #endregion
}
#endregion

