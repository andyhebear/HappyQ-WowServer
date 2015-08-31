#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

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

#region zh-CHS �������ֿռ� | en Include namespace

#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// ���������󷵻صĽ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Result<T>
    {
        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// ��ʼ�� �ɹ��������غ���
        /// </summary>
        /// <param name="resultT">�ɹ��������غ������</param>
        private Result( T resultT )
        {
            m_isSuccess = true;
            m_ResultT = default( T );
            m_ErrorInfo = string.Empty;
        }

        /// <summary>
        /// ��ʼ�� ʧ�ܲ������غ���
        /// </summary>
        /// <param name="strErrorInfo">ʧ�ܲ������غ���ϸ����</param>
        private Result( string strErrorInfo )
        {
            m_isSuccess = false;
            m_ResultT = default( T );
            m_ErrorInfo = strErrorInfo;
        }
        #endregion

        #region zh-CHS �������� | en Public Properties
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����ɹ������󷵻صĽ��
        /// </summary>
        private T m_ResultT;
        #endregion
        /// <summary>
        /// �����ɹ������󷵻صĽ��
        /// </summary>
        public T Return
        {
            get { return m_ResultT; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ���غ����Ƿ��Ѿ��ɹ�����
        /// </summary>
        private bool m_isSuccess;
        #endregion
        /// <summary>
        /// ���غ����Ƿ��Ѿ��ɹ�����
        /// </summary>
        public bool Success
        {
            get { return m_isSuccess; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// �����������ʧ��,�˰�����ϸ�Ĵ�����Ϣ
        /// </summary>
        private string m_ErrorInfo;
        #endregion
        /// <summary>
        /// �����������ʧ��,�˰�����ϸ�Ĵ�����Ϣ
        /// </summary>
        public string ErrorInfo
        {
            get { return m_ErrorInfo; }
        }
        #endregion

        #region zh-CHS ���о�̬���� | en Public Static Methods
        /// <summary>
        /// ʵ�����ɹ�����
        /// </summary>
        /// <param name="resultT">�ɹ��������غ������</param>
        public static Result<T> Instance( T resultT )
        {
            return new Result<T>( resultT );
        }

        /// <summary>
        /// ʵ����ʧ�ܲ���
        /// </summary>
        /// <param name="strErrorInfo">ʧ�ܲ������غ���ϸ����</param>
        public static Result<T> Instance( string strErrorInfo )
        {
            return new Result<T>( strErrorInfo );
        }

        /// <summary>
        /// ʵ����ʧ�ܲ���
        /// </summary>
        /// <param name="strAboveErrorInfo">��һ��ʧ�ܲ���������</param>
        /// <param name="strErrorInfo">ʧ�ܲ������غ���ϸ����</param>
        public static Result<T> Instance( string strAboveErrorInfo, string strErrorInfo )
        {
            return new Result<T>( strAboveErrorInfo + "\n" + strErrorInfo );
        }
        #endregion
    }
}
#endregion