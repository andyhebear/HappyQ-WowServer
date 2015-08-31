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
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Demo.Mmose.Core.Common
{
    /// <summary>
    /// ͨ��DES�ԳƼ����㷨,��ɶ��ַ����ļ��ܺͽ��ܲ����� 
    /// </summary>
    public class StringCrypto
    {
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// DES�ԳƼ����㷨
        /// </summary>
        private SymmetricAlgorithm m_DESCrypto = new DESCryptoServiceProvider();
        /// <summary>
        /// ��Կ
        /// </summary>
        private byte[] m_Base64IV = new byte[0];
        /// <summary>
        /// ��ʼ������
        /// </summary>
        private byte[] m_Base64KEY = new byte[0];
        #endregion

        #region zh-CHS ����ͳ�ʼ�������� | en Constructors and Initializers and Dispose
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="strBase64KEY">��Կ�� Base64 �ַ���</param>
        /// <param name="strBase64IV">��ʼ�������� Base64 �ַ���</param>
        public StringCrypto( string strBase64KEY, string strBase64IV )
        {
            m_Base64KEY = Convert.FromBase64String( strBase64KEY );
            m_Base64IV = Convert.FromBase64String( strBase64IV );
        }
        #endregion

        #region zh-CHS ���з��� | en Public Methods
        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="strValue">���ܵ��ַ���</param>
        /// <returns>���� Base64 �ַ���</returns>
        public string Encrypt( string strValue )
        {
            byte[] utf8Buffer = Encoding.UTF8.GetBytes( strValue );

            ICryptoTransform cryptoTransform = m_DESCrypto.CreateEncryptor( m_Base64KEY, m_Base64IV );

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Write );
            cryptoStream.Write( utf8Buffer, 0, utf8Buffer.Length );
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Convert.ToBase64String( memoryStream.ToArray() );
        }

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="strValue">Base64 �ַ���</param>
        /// <returns>���� ���ܵ��ַ���</returns>
        public string Decrypt( string strValue )
        {
            byte[] base64Buffer = Convert.FromBase64String( strValue );

            ICryptoTransform cryptoTransform = m_DESCrypto.CreateDecryptor( m_Base64KEY, m_Base64IV );

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Write );
            cryptoStream.Write( base64Buffer, 0, base64Buffer.Length );
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Encoding.UTF8.GetString( memoryStream.ToArray() );
        }
        #endregion

        #region zh-CHS ���о�̬���� | en Public Static Methods
        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="strBase64KEY">��Կ�� Base64 �ַ���</param>
        /// <param name="strBase64IV">��ʼ�������� Base64 �ַ���</param>
        /// <param name="strValue">���ܵ��ַ���</param>
        /// <returns>���� Base64 �ַ���</returns>
        public static string EncryptString( string strBase64KEY, string strBase64IV, string strValue )
        {
            SymmetricAlgorithm desCrypto = new DESCryptoServiceProvider();
            ICryptoTransform cryptoTransform = desCrypto.CreateEncryptor( Convert.FromBase64String( strBase64KEY ), Convert.FromBase64String( strBase64IV ) );

            byte[] utf8Buffer = Encoding.UTF8.GetBytes( strValue );

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Write );
            cryptoStream.Write( utf8Buffer, 0, utf8Buffer.Length );
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Convert.ToBase64String( memoryStream.ToArray() );
        }

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="strBase64KEY">��Կ�� Base64 �ַ���</param>
        /// <param name="strBase64IV">��ʼ�������� Base64 �ַ���</param>
        /// <param name="strValue">Base64 �ַ���</param>
        /// <returns>���� ���ܵ��ַ���</returns>
        public static string DecryptString( string strBase64KEY, string strBase64IV, string strValue )
        {
            SymmetricAlgorithm desCrypto = new DESCryptoServiceProvider();
            ICryptoTransform cryptoTransform = desCrypto.CreateDecryptor( Convert.FromBase64String( strBase64KEY ), Convert.FromBase64String( strBase64IV ) );

            byte[] base64Buffer = Convert.FromBase64String( strValue );

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Write );
            cryptoStream.Write( base64Buffer, 0, base64Buffer.Length );
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return Encoding.UTF8.GetString( memoryStream.ToArray() );
        }
        #endregion
    }
}
#endregion
