using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.WorldServer.Object;
using Demo.Wow.Script.ItemTemplate;

namespace Demo.Wow.Script.ObjectTemplate
{
    /// <summary>
    /// 中文格式
    /// </summary>
    public class 物体模板名字 : 魔兽世界物体信息
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void 初始化物体信息()
        {
            // 唯一序号
            //(0x3代表物体,00大类,00子类,00001物体顺序号)
            //大类(类型)
            //子类(无)
            唯一序号 = 0x3060000001;


            // creature_template - type (mangos数据库的字段名称)
            // (0 = 门 , 1 = 按钮 , 2 = 任务 , 3 = 箱子 , 5 = 一般 , 6 = 陷阱 , 7 = 椅子)
            // (8 = 魔法中心 , 9 = 文字 , 10 = ?  , 18 = 召唤石 , 22 = 传送门 , 23 = 集合石)
            类型 = 6;


            // creature_template - displayId (mangos数据库的字段名称)
            模型编号 = 1166;


            // creature_template - name (mangos数据库的字段名称)
            名字 = "物体模板名字";


            // creature_template - faction (mangos数据库的字段名称)
            阵营 = 84;


            // creature_template - flags (mangos数据库的字段名称)
            标记 = 0;


            // creature_template - size (mangos数据库的字段名称)
            大小 = 1;


            // creature_template - sound0 (mangos数据库的字段名称)
            声音[0] = 0;
            声音[1] = 0;
            声音[2] = 0;
            声音[3] = 0;
            声音[4] = 0;
            声音[5] = 0;
            声音[6] = 0;
            声音[7] = 0;
            声音[8] = 0;
            声音[9] = 0;
            声音[10] = 0;
            声音[11] = 0;
            声音[12] = 0;
            声音[13] = 0;
            声音[14] = 0;
            声音[15] = 0;
            声音[16] = 0;
            声音[17] = 0;
            声音[18] = 0;
            声音[19] = 0;
            声音[20] = 0;
            声音[21] = 0;
            声音[22] = 0;
            声音[23] = 0;


            //----------游戏物体爆率----------
            // 如果没有皮毛,物品,任务,金币掉落 = new OneTreasure[0]

            物品掉落 = new OneTreasure[] 
            {
              //掉落物品组1
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(物品模板名字), 44.4f ),
                    new Loot( typeof(物品模板名字), 44.4f ),
                    new Loot( typeof(物品模板名字), 44.4f ),
                } , 100f ),

              //掉落物品组2
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(物品模板名字), 44.4f ),
                    new Loot( typeof(物品模板名字), 44.4f ), 
                    new Loot( typeof(物品模板名字), 44.4f ),
                } , 100f ),  
            };

            任务物品掉落 = new OneTreasure[]
            {
               new OneTreasure(
                new Loot[] {
                    new Loot( typeof(物品模板名字), 44.4f )
                } , 100f ),
            };

            金币掉落 = new OneTreasure[] 
            {

               new OneTreasure(
                new Loot[] {
                    new GoldLoot( 100, 250, 99.9f )
                } , 100f ),
            };



            //----------游戏物体包含的任务的信息----------

            // 任务编号
            任务.Add( 0x1234 );
            任务.Add( 0x1235 );

            //----------游戏物体包含的任务的信息----------



        }
    }
}
