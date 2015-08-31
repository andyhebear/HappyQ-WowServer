using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal struct CharLoginSQL
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldExtendData"></param>
        public CharLoginSQL( WorldExtendData worldExtendData, NetState netState, long iCharacterGuid )
        {
            m_WorldExtendData = worldExtendData;
            m_NetState = netState;
            m_iCharacterGuid = iCharacterGuid;
        }
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WorldExtendData m_WorldExtendData;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WorldExtendData WorldExtendData
        {
            get { return m_WorldExtendData; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private NetState m_NetState;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public NetState NetState
        {
            get { return m_NetState; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private long m_iCharacterGuid;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public long LoginCharGuid
        {
            get { return m_iCharacterGuid; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class WorldExtendData : IPacketEncoder
    {

    }
}
