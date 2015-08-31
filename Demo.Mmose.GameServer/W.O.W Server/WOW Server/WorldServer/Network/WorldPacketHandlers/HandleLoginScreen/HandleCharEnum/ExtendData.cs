using System;
using System.Collections.Generic;
using System.Text;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal struct CharEnumSQL
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldExtendData"></param>
        public CharEnumSQL( WorldExtendData worldExtendData, NetState netState )
        {
            m_WorldExtendData = worldExtendData;
            m_NetState = netState;
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
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class WorldExtendData : IPacketEncoder
    {

    }
}
