using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Common;

namespace Demo.Wow.Script.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class InitGraveyardInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlayerCreateInfoManager"></param>
        public static void InitWowGraveyardInfo( WowGraveyardInfoHandler graveyardInfoManager )
        {
            List<GraveyardInfo> graveyardInfoList = new List<GraveyardInfo>();

            GraveyardInfoSetting.GraveyardInfoUpdate( graveyardInfoList );


            foreach ( GraveyardInfo graveyardInfo in graveyardInfoList )
            {
                if ( graveyardInfo == null )
                    continue;

                if ( graveyardInfo.Faction == GraveyardFaction.Alliance )
                    graveyardInfoManager.AddGraveyardInfo( graveyardInfo.GhostMap, graveyardInfo.GhostZone, GraveyardFaction.Alliance, graveyardInfo );
                else if ( graveyardInfo.Faction == GraveyardFaction.Horde )
                    graveyardInfoManager.AddGraveyardInfo( graveyardInfo.GhostMap, graveyardInfo.GhostZone, GraveyardFaction.Horde, graveyardInfo );
                else if ( graveyardInfo.Faction == GraveyardFaction.All )
                {
                    graveyardInfoManager.AddGraveyardInfo( graveyardInfo.GhostMap, graveyardInfo.GhostZone, GraveyardFaction.Alliance, graveyardInfo );
                    graveyardInfoManager.AddGraveyardInfo( graveyardInfo.GhostMap, graveyardInfo.GhostZone, GraveyardFaction.Horde, graveyardInfo );
                }
            }
        }
    }
}
