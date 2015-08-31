using System;
using System.Text;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.Common;
using System.Threading;

namespace Demo_R.O.S.E.WorldServer.WorldCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class RoseSerial
    {
        /// <summary>
        /// 
        /// </summary>
        private static long[] s_ClientIdList = new long[0x10000];	// Clients List
        /// <summary>
        /// 
        /// </summary>
        private static object s_LockClientIdList = new object();

        /// <summary>
        /// This function gets a new clientID for a npc, monster or mob
        /// </summary>
        public static Serial GetNewClientID()
        {
            Serial l_Serial = Serial.Zero;

            Monitor.Enter( s_LockClientIdList );
            {
                int iIndex = 0;
                foreach ( long clientId in s_ClientIdList )
                {
                    if ( clientId != 0 && DateTime.Now.Ticks - clientId > 10 )
                    {
                        s_ClientIdList[iIndex] = 0;
                        l_Serial = new Serial( iIndex );
                        break;
                    }

                    ++iIndex;
                }
            }
            Monitor.Exit( s_LockClientIdList );

            return l_Serial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial"></param>
        public static void ClearClientID( Serial serial )
        {
            Monitor.Enter( s_LockClientIdList );
            {
                s_ClientIdList[serial.Value] = DateTime.Now.Ticks;
            }
            Monitor.Exit( s_LockClientIdList );
        }
    }
}
