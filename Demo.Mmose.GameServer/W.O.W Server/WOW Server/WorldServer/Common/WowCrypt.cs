using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WowCrypt
    {
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        public const byte CRYPTED_SEND_LEN = 4;
        /// <summary>
        /// 
        /// </summary>
        public const byte CRYPTED_RECV_LEN = 6;
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_KeyData = null;
        /// <summary>
        /// 
        /// </summary>
        private byte m_Send_I = 0;
        /// <summary>
        /// 
        /// </summary>
        private byte m_Send_J = 0;
        /// <summary>
        /// 
        /// </summary>
        private byte m_Recv_I = 0;
        /// <summary>
        /// 
        /// </summary>
        private byte m_Recv_J = 0;
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bInitialized = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool Initialized
        {
            get { return m_bInitialized; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="size_t"></param>
        public void InitKey( byte[] byteData, int byteLen )
        {
            if ( m_bInitialized )
                return;

            m_KeyData = new byte[byteLen];

            Buffer.BlockCopy( byteData, 0, m_KeyData, 0, byteLen );

            m_bInitialized = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="size_t"></param>
        public void DecryptRecv( ref byte[] byteData, int byteLen )
        {
            if ( m_bInitialized == false || byteLen < CRYPTED_RECV_LEN )
                return;

            for ( int iIndex = 0; iIndex < CRYPTED_RECV_LEN; iIndex++ )
            {
                m_Recv_I %= (byte)m_KeyData.Length;

                byte byteTemp = (byte)( ( byteData[iIndex] - m_Recv_J ) ^ m_KeyData[m_Recv_I] );

                ++m_Recv_I;

                m_Recv_J = byteData[iIndex];

                byteData[iIndex] = byteTemp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="size_t"></param>
        public void EncryptSend( ref byte[] byteData, int byteLen )
        {
            if ( m_bInitialized == false || byteLen < CRYPTED_SEND_LEN )
                return;

            for ( int iIndex = 0; iIndex < CRYPTED_SEND_LEN; iIndex++ )
            {
                m_Send_I %= (byte)m_KeyData.Length;

                byte byteTemp = (byte)( ( byteData[iIndex] ^ m_KeyData[m_Send_I] ) + m_Send_J );

                ++m_Send_I;

                byteData[iIndex] = m_Send_J = byteTemp;
            }
        }
        #endregion
    }
}
