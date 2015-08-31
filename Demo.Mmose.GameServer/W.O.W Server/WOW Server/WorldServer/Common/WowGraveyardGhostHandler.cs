using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Collections;

namespace Demo.Wow.WorldServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WowGraveyardInfoHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private SafeDictionary<uint, SafeDictionary<uint, SafeDictionary<uint, GraveyardInfo>>> m_GraveyardInfo = new SafeDictionary<uint,SafeDictionary<uint,SafeDictionary<uint,GraveyardInfo>>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <param name="playerLevelStats"></param>
        public void AddGraveyardInfo( uint iMapId, uint iZoneId, uint iFaction, GraveyardInfo graveyardInfo )
        {
            SafeDictionary<uint, SafeDictionary<uint, GraveyardInfo>> mapGraveyardInfo = m_GraveyardInfo.GetValue( iMapId );
            if ( mapGraveyardInfo == null )
                mapGraveyardInfo = new SafeDictionary<uint, SafeDictionary<uint, GraveyardInfo>>();

            SafeDictionary<uint, GraveyardInfo> zoneGraveyardInfo = mapGraveyardInfo.GetValue( iZoneId );
            if ( zoneGraveyardInfo == null )
                zoneGraveyardInfo = new SafeDictionary<uint, GraveyardInfo>();

            zoneGraveyardInfo.Add( iFaction, graveyardInfo );

            mapGraveyardInfo.Add( iZoneId, zoneGraveyardInfo );

            m_GraveyardInfo.Add( iMapId, mapGraveyardInfo );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRace"></param>
        /// <param name="iClass"></param>
        /// <returns></returns>
        public GraveyardInfo GetGraveyardInfo( uint iMapId, uint iZoneId, uint iFaction )
        {
            SafeDictionary<uint, SafeDictionary<uint, GraveyardInfo>> mapGraveyardInfo = m_GraveyardInfo.GetValue( iMapId );
            if ( mapGraveyardInfo == null )
                return null;

            SafeDictionary<uint, GraveyardInfo> zoneGraveyardInfo = mapGraveyardInfo.GetValue( iZoneId );
            if ( zoneGraveyardInfo == null )
                return null;

            GraveyardInfo graveyardInfo = zoneGraveyardInfo.GetValue( iFaction );
            if ( graveyardInfo == null )
                return null;

            return graveyardInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GraveyardInfo[] ToArray()
        {
            List<GraveyardInfo> graveyardInfoList = new List<GraveyardInfo>();

            foreach ( SafeDictionary<uint, SafeDictionary<uint, GraveyardInfo>> mapGraveyardInfo in m_GraveyardInfo.ToArrayValues() )
            {
                foreach ( SafeDictionary<uint, GraveyardInfo> zoneGraveyardInfo in mapGraveyardInfo.ToArrayValues() )
                {
                    foreach ( GraveyardInfo graveyardInfo in zoneGraveyardInfo.ToArrayValues() )
                    {
                        if ( graveyardInfo == null )
                            continue;
                        else
                            graveyardInfoList.Add( graveyardInfo );
                    }
                }
            }

            return graveyardInfoList.ToArray();
        }
    }
}
