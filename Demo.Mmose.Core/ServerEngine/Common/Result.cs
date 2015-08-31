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

#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// 函数操作后返回的结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Result<T>
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 初始化 成功操作返回后结果
        /// </summary>
        /// <param name="resultT">成功操作返回后的内容</param>
        private Result( T resultT )
        {
            m_isSuccess = true;
            m_ResultT = default( T );
            m_ErrorInfo = string.Empty;
        }

        /// <summary>
        /// 初始化 失败操作返回后结果
        /// </summary>
        /// <param name="strErrorInfo">失败操作返回后详细内容</param>
        private Result( string strErrorInfo )
        {
            m_isSuccess = false;
            m_ResultT = default( T );
            m_ErrorInfo = strErrorInfo;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 函数成功操作后返回的结果
        /// </summary>
        private T m_ResultT;
        #endregion
        /// <summary>
        /// 函数成功操作后返回的结果
        /// </summary>
        public T Return
        {
            get { return m_ResultT; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 返回函数是否已经成功操作
        /// </summary>
        private bool m_isSuccess;
        #endregion
        /// <summary>
        /// 返回函数是否已经成功操作
        /// </summary>
        public bool Success
        {
            get { return m_isSuccess; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 如果函数操作失败,此包含详细的错误信息
        /// </summary>
        private string m_ErrorInfo;
        #endregion
        /// <summary>
        /// 如果函数操作失败,此包含详细的错误信息
        /// </summary>
        public string ErrorInfo
        {
            get { return m_ErrorInfo; }
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 实例化成功操作
        /// </summary>
        /// <param name="resultT">成功操作返回后的内容</param>
        public static Result<T> Instance( T resultT )
        {
            return new Result<T>( resultT );
        }

        /// <summary>
        /// 实例化失败操作
        /// </summary>
        /// <param name="strErrorInfo">失败操作返回后详细内容</param>
        public static Result<T> Instance( string strErrorInfo )
        {
            return new Result<T>( strErrorInfo );
        }

        /// <summary>
        /// 实例化失败操作
        /// </summary>
        /// <param name="strAboveErrorInfo">上一个失败操作的内容</param>
        /// <param name="strErrorInfo">失败操作返回后详细内容</param>
        public static Result<T> Instance( string strAboveErrorInfo, string strErrorInfo )
        {
            return new Result<T>( strAboveErrorInfo + "\n" + strErrorInfo );
        }
        #endregion
    }
}
#endregion