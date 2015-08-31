using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Script.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class 墓地信息设置
    {
        /// <summary>
        /// 
        /// </summary>
        public static void 设置墓地信息( List<墓地信息> graveyardInfoList )
        {
            #region zh-CHS 联盟 | en Alliance

            #region zh-CHS 地图编号 0 | en

            #region zh-CHS 地域编号 0 | en Zone

            墓地信息 graveyardInfo = new 墓地信息();
            graveyardInfo.阵营 = GraveyardFaction.Alliance; // 联盟编号
            graveyardInfo.地图 = 0;
            graveyardInfo.地域 = 0;
            graveyardInfo.墓地编号 = 0;

            graveyardInfoList.Add( graveyardInfo );

            #endregion

            #endregion

            #endregion

            #region zh-CHS 部落 | en Horde

            #region zh-CHS 地图编号 0 | en

            #region zh-CHS 地域编号 1 | en Zone
            graveyardInfo = new 墓地信息();
            graveyardInfo.阵营 = GraveyardFaction.Horde; // 部落编号
            graveyardInfo.地图 = 0;
            graveyardInfo.地域 = 0;
            graveyardInfo.墓地编号 = 0;

            graveyardInfoList.Add( graveyardInfo );
            #endregion

            #endregion

            #endregion

            #region zh-CHS 全部阵营 | en All

            #region zh-CHS 地图编号 0 | en

            #region zh-CHS 地域编号 2 | en Zone
            graveyardInfo = new 墓地信息();
            graveyardInfo.阵营 = GraveyardFaction.All; // 全部阵营编号
            graveyardInfo.地图 = 0;
            graveyardInfo.地域 = 0;
            graveyardInfo.墓地编号 = 0;

            graveyardInfoList.Add( graveyardInfo );
            #endregion

            #endregion

            #endregion
        }
    }
}
