using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Common;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Component;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessReceiveData
    {
        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_PacketBuffer = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] PacketBuffer
        {
            get { return m_PacketBuffer; }
            set { m_PacketBuffer = value; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// ��Ҫ���ܵ�ʣ�����ݴ�С
        /// </summary>
        private uint m_Remaining = ProcessNet.WORLD_HEAD_SIZE;
        #endregion
        /// <summary>
        /// ��Ҫ���ܵ�ʣ�����ݴ�С
        /// </summary>
        public uint Remaining
        {
            get { return m_Remaining; }
            set { m_Remaining = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CommonData
    {
        /// <summary>
        /// 
        /// </summary>
        private long m_AccountsGuid;
        /// <summary>
        /// 
        /// </summary>
        public long AccountsGuid
        {
            get { return m_AccountsGuid; }
            set { m_AccountsGuid = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string m_AccountName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccountName
        {
            get { return m_AccountName; }
            set { m_AccountName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_IsTBC = true;
        /// <summary>
        /// 
        /// </summary>
        public bool IsTBC
        {
            get { return m_IsTBC; }
            set { m_IsTBC = value; }
        }
    }


    #region zh-CHS WorldExtendData �� | en WorldExtendData Class
    /// <summary>
    /// WorldExtend Server �ͻ������ӹ����洢������
    /// </summary>
    internal sealed partial class WorldExtendData : Component, IPacketEncoder
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static ComponentId COMPONENT_ID = "WorldExtendData";

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CommonData m_CommonData = new CommonData();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CommonData CommonData
        {
            get { return m_CommonData; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ProcessReceiveData m_ProcessReceiveData = new ProcessReceiveData();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ProcessReceiveData ProcessReceiveData
        {
            get { return m_ProcessReceiveData; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsLoggedIn = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsLoggedIn
        {
            get { return m_bIsLoggedIn; }
            set { m_bIsLoggedIn = value; }
        }

        #region zh-CHS �ӿ�ʵ�� | en Interface Implementation

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCrypt m_WowCrypt = new WowCrypt();
        #endregion
        /// <summary>
        /// �ӽ��ܵ�����
        /// </summary>
        public WowCrypt WowCrypt
        {
            get { return m_WowCrypt; }
        }

        #region zh-CHS ˽�г�Ա���� | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        //private uint m_iServerSeed = (uint)RandomBuilder.Random( int.MaxValue ) % 0xFFFFFFF0 + 10;
        private uint m_iServerSeed = 0x0C622DA7;
        #endregion
        /// <summary>
        /// ��������������
        /// </summary>
        public uint ServerSeed
        {
            get { return m_iServerSeed; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netStateFrom"></param>
        /// <param name="byteBuffer"></param>
        /// <param name="iLength"></param>
        public void DecodeIncomingPacket( NetState netStateFrom, ref byte[] byteBuffer, ref long iLength )
        {
            WowCrypt.DecryptRecv( ref byteBuffer, (int)iLength ); // ֻ���� ���ݰ���ͷ 6���ֽ�
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netStateTo"></param>
        /// <param name="byteBuffer"></param>
        /// <param name="iLength"></param>
        public void EncodeOutgoingPacket( NetState netStateTo, ref byte[] byteBuffer, ref long iLength )
        {
            WowCrypt.EncryptSend( ref byteBuffer, (int)iLength ); // ֻ���� ���ݰ���ͷ 4���ֽ�
        }

        #endregion
    }
    #endregion
}
