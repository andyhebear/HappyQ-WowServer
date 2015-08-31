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
    public static class GraveyardInfoSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public static void GraveyardInfoUpdate( List<GraveyardInfo> graveyardInfoList )
        {
            // English To zhCHS Interface
            List<墓地信息> localGraveyardInfoList = new List<墓地信息>();

            墓地信息设置.设置墓地信息( localGraveyardInfoList );

            foreach ( 墓地信息 graveyardInfo in localGraveyardInfoList )
                graveyardInfoList.Add( graveyardInfo.GraveyardInfo );
        }
    }
}
