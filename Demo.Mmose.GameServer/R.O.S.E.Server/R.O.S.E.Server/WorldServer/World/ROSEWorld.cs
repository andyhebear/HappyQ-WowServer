using System;
using System.Text;
using System.Collections.Generic;

namespace Demo_R.O.S.E.WorldServer.WorldServer.World
{
    /// <summary>
    /// 
    /// </summary>
    internal class ROSEWorld
    {
        /// <summary>
        /// 
        /// </summary>
        private static DateTime m_LastUpdateTime = DateTime.Now;

        /// <summary>
        /// 游戏世界的时间
        /// </summary>
        private static long m_CurrentWorldTime = 0x4F;
        /// <summary>
        /// 
        /// </summary>
        internal static long CurrentWorldTime
        {
            get { return ROSEWorld.m_CurrentWorldTime; }
            set { ROSEWorld.m_CurrentWorldTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static bool UpdateWorldTime()
        {
            TimeSpan l_TimeSpan = DateTime.Now - m_LastUpdateTime;

            if ( l_TimeSpan.Ticks < ( 10 * TimeSpan.TicksPerSecond ) )
                return false;

            long l_TempWorldTime = ( l_TimeSpan.Ticks / ( 10 * TimeSpan.TicksPerSecond ) ) + m_CurrentWorldTime;
            if ( l_TempWorldTime > 0x9F )
                m_CurrentWorldTime = l_TempWorldTime - 0x9F;
            else
                m_CurrentWorldTime = l_TempWorldTime;

            m_LastUpdateTime = DateTime.Now;
            return true;
        }
    }
}