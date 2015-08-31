using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Network
{
    internal class Ping
    {
        /// <summary>
        /// 
        /// </summary>
        private uint m_Latency = 0;
        /// <summary>
        /// 
        /// </summary>
        public uint Latency
        {
            get { return m_Latency; }
            set { m_Latency = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed partial class WorldExtendData : IPacketEncoder
    {
        private Ping m_Ping = new Ping();
        internal Ping Ping
        {
            get { return m_Ping; }
        }
    }
}
