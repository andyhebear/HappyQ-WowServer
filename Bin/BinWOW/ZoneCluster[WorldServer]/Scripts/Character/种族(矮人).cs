using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// 先调用“种族”函数 后调用“职业”的函数
    /// </summary>
    public class 种族_矮人
    {
        /// <summary>
        /// 
        /// </summary>
        public static void 出生设置( 魔兽世界人物创建信息 wowPlayer )
        {
            //新建角色种族出生地坐标
            //playercreateinfo - map (mangos数据库的字段名称)
            //0 = 东部王国 , 1 = 卡利姆多 , 530 = 资料片扩充地图 (DBC下MAP.DBC文件中的第1列(取值范围),第2列字段(地图名称)
            wowPlayer.地图 = 0;

            //playercreateinfo - zone (mangos数据库的字段名称)
            //具体取值范围以及数值所代表的含意在客户端DBC下WMOAreaTable.dbc中
            wowPlayer.地域 = 1;

            //
            wowPlayer.男性模型 = 53;
            wowPlayer.女性模型 = 54;

            //playercreateinfo - position_x (mangos数据库的字段名称)
            wowPlayer.坐标点X = 6240.32F;

            //playercreateinfo - position_y (mangos数据库的字段名称)
            wowPlayer.坐标点Y = 331.033F;

            //playercreateinfo - position_z (mangos数据库的字段名称)
            wowPlayer.坐标点Z = 382.758F;



            //新建角色种族物品信息

            //playercreateinfo_item - itemid 物品唯一序号(mangos数据库的字段名称)
            //playercreateinfo_item - amount 物品数量(mangos数据库的字段名称)
            wowPlayer.人物携带物品.Add( 0x2040100001, 1 );
            wowPlayer.人物携带物品.Add( 0x2040100002, 2 );
            wowPlayer.人物携带物品.Add( 0x2040100003, 3 );
        }

        /// <summary>
        /// 
        /// </summary>
        public static void 等级上升设置( 魔兽世界等级上升信息[] wowPlayer )
        {
        }
    }
}
