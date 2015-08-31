using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Network;

namespace Demo.Wow.WorldServer.Network
{
    /// <summary>
    /// 
    /// </summary>
    internal class WaitQueueLogins
    {
        /// <summary>
        /// 
        /// </summary>
        private static Queue<NetState> m_WaitQueue = new Queue<NetState>();
        /// <summary>
        /// 
        /// </summary>
        private static object m_LockWaitQueue = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netState"></param>
        public static void Enqueue( NetState netState )
        {
            // 告诉玩家现在处在的位置
            netState.Send( new Word_AuthResponsePending( (uint)( m_WaitQueue.Count + 1 ) ) );

            Monitor.Enter( m_LockWaitQueue );
            {
                m_WaitQueue.Enqueue( netState );
            }
            Monitor.Exit( m_LockWaitQueue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static NetState Dequeue()
        {
            NetState netState = null;

            Monitor.Enter( m_LockWaitQueue );
            {
                netState = m_WaitQueue.Dequeue();
            }
            Monitor.Exit( m_LockWaitQueue );

            return netState;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public static void Update()
        {
            NetState[] netStateArray = null;

            Monitor.Enter( m_LockWaitQueue );
            {
                if ( m_WaitQueue.Count > 0 )
                    netStateArray = m_WaitQueue.ToArray();
            }
            Monitor.Exit( m_LockWaitQueue );

            if (netStateArray == null)
                return;

            uint iIndex = 1;
            foreach ( NetState netState in netStateArray )
            {
                netState.Send( new Word_AuthResponsePending( iIndex ) );
                ++iIndex;
            }
        }
    }
}
