using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Script.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class 职业_法师
    {
        /// <summary>
        /// 
        /// </summary>
        public static void 出生设置( 魔兽世界人物创建信息 wowPlayer )
        {
            switch ( wowPlayer.种族 )
            {
                case (uint)Wow种族.德莱尼:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                case (uint)Wow种族.巨魔:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                case (uint)Wow种族.人类:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                case (uint)Wow种族.亡灵:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                case (uint)Wow种族.血精灵:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                case (uint)Wow种族.侏儒:
                    {

                        wowPlayer.人物快捷按钮.Add( 0x0/*快捷按钮编号*/, 1 /*法术编号或物品编号或宏定义编号*/, 0/*技能类型 0 = 法术 64 = 宏定义 128 = 物品*/, 0/*杂类 始终为零*/ );
                        wowPlayer.人物携带法术.Add( 0x1234/*法术编号*/ );
                        wowPlayer.人物携带技能.Add( 0x1234/*技能编号*/ );

                    }
                    break;
                default:
                    {
                        // 错误信息
                    }
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void 等级上升设置( 魔兽世界等级上升信息[] wowPlayer )
        {
            switch ( wowPlayer[0].种族 )
            {
                case (uint)Wow种族.德莱尼:
                    {
                        #region zh-CHS 种族 德莱尼 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                case (uint)Wow种族.巨魔:
                    {
                        #region zh-CHS 种族 巨魔 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                case (uint)Wow种族.人类:
                    {
                        #region zh-CHS 种族 人类 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                case (uint)Wow种族.亡灵:
                    {
                        #region zh-CHS 种族 亡灵 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                case (uint)Wow种族.血精灵:
                    {
                        #region zh-CHS 种族 血精灵 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                case (uint)Wow种族.侏儒:
                    {
                        #region zh-CHS 种族 侏儒 等级上升信息 | en
                        //1级;
                        wowPlayer[0].生命值 = 0;
                        wowPlayer[0].法力值 = 0;
                        wowPlayer[0].力量 = 0;
                        wowPlayer[0].敏捷 = 0;
                        wowPlayer[0].耐力 = 0;
                        wowPlayer[0].智力 = 0;
                        wowPlayer[0].精神 = 0;

                        //2级;
                        wowPlayer[1].生命值 = 0;
                        wowPlayer[1].法力值 = 0;
                        wowPlayer[1].力量 = 0;
                        wowPlayer[1].敏捷 = 0;
                        wowPlayer[1].耐力 = 0;
                        wowPlayer[1].智力 = 0;
                        wowPlayer[1].精神 = 0;

                        //3级;
                        wowPlayer[2].生命值 = 0;
                        wowPlayer[2].法力值 = 0;
                        wowPlayer[2].力量 = 0;
                        wowPlayer[2].敏捷 = 0;
                        wowPlayer[2].耐力 = 0;
                        wowPlayer[2].智力 = 0;
                        wowPlayer[2].精神 = 0;

                        //4级;
                        wowPlayer[3].生命值 = 0;
                        wowPlayer[3].法力值 = 0;
                        wowPlayer[3].力量 = 0;
                        wowPlayer[3].敏捷 = 0;
                        wowPlayer[3].耐力 = 0;
                        wowPlayer[3].智力 = 0;
                        wowPlayer[3].精神 = 0;

                        //5级;
                        wowPlayer[4].生命值 = 0;
                        wowPlayer[4].法力值 = 0;
                        wowPlayer[4].力量 = 0;
                        wowPlayer[4].敏捷 = 0;
                        wowPlayer[4].耐力 = 0;
                        wowPlayer[4].智力 = 0;
                        wowPlayer[4].精神 = 0;

                        //6级;
                        wowPlayer[5].生命值 = 0;
                        wowPlayer[5].法力值 = 0;
                        wowPlayer[5].力量 = 0;
                        wowPlayer[5].敏捷 = 0;
                        wowPlayer[5].耐力 = 0;
                        wowPlayer[5].智力 = 0;
                        wowPlayer[5].精神 = 0;

                        //7级;
                        wowPlayer[6].生命值 = 0;
                        wowPlayer[6].法力值 = 0;
                        wowPlayer[6].力量 = 0;
                        wowPlayer[6].敏捷 = 0;
                        wowPlayer[6].耐力 = 0;
                        wowPlayer[6].智力 = 0;
                        wowPlayer[6].精神 = 0;

                        //8级;
                        wowPlayer[7].生命值 = 0;
                        wowPlayer[7].法力值 = 0;
                        wowPlayer[7].力量 = 0;
                        wowPlayer[7].敏捷 = 0;
                        wowPlayer[7].耐力 = 0;
                        wowPlayer[7].智力 = 0;
                        wowPlayer[7].精神 = 0;

                        //9级;
                        wowPlayer[8].生命值 = 0;
                        wowPlayer[8].法力值 = 0;
                        wowPlayer[8].力量 = 0;
                        wowPlayer[8].敏捷 = 0;
                        wowPlayer[8].耐力 = 0;
                        wowPlayer[8].智力 = 0;
                        wowPlayer[8].精神 = 0;

                        //10级;
                        wowPlayer[9].生命值 = 0;
                        wowPlayer[9].法力值 = 0;
                        wowPlayer[9].力量 = 0;
                        wowPlayer[9].敏捷 = 0;
                        wowPlayer[9].耐力 = 0;
                        wowPlayer[9].智力 = 0;
                        wowPlayer[9].精神 = 0;

                        //11级;
                        wowPlayer[10].生命值 = 0;
                        wowPlayer[10].法力值 = 0;
                        wowPlayer[10].力量 = 0;
                        wowPlayer[10].敏捷 = 0;
                        wowPlayer[10].耐力 = 0;
                        wowPlayer[10].智力 = 0;
                        wowPlayer[10].精神 = 0;

                        //12级;
                        wowPlayer[11].生命值 = 0;
                        wowPlayer[11].法力值 = 0;
                        wowPlayer[11].力量 = 0;
                        wowPlayer[11].敏捷 = 0;
                        wowPlayer[11].耐力 = 0;
                        wowPlayer[11].智力 = 0;
                        wowPlayer[11].精神 = 0;

                        //13级;
                        wowPlayer[12].生命值 = 0;
                        wowPlayer[12].法力值 = 0;
                        wowPlayer[12].力量 = 0;
                        wowPlayer[12].敏捷 = 0;
                        wowPlayer[12].耐力 = 0;
                        wowPlayer[12].智力 = 0;
                        wowPlayer[12].精神 = 0;

                        //14级;
                        wowPlayer[13].生命值 = 0;
                        wowPlayer[13].法力值 = 0;
                        wowPlayer[13].力量 = 0;
                        wowPlayer[13].敏捷 = 0;
                        wowPlayer[13].耐力 = 0;
                        wowPlayer[13].智力 = 0;
                        wowPlayer[13].精神 = 0;

                        //15级;
                        wowPlayer[14].生命值 = 0;
                        wowPlayer[14].法力值 = 0;
                        wowPlayer[14].力量 = 0;
                        wowPlayer[14].敏捷 = 0;
                        wowPlayer[14].耐力 = 0;
                        wowPlayer[14].智力 = 0;
                        wowPlayer[14].精神 = 0;

                        //16级;
                        wowPlayer[15].生命值 = 0;
                        wowPlayer[15].法力值 = 0;
                        wowPlayer[15].力量 = 0;
                        wowPlayer[15].敏捷 = 0;
                        wowPlayer[15].耐力 = 0;
                        wowPlayer[15].智力 = 0;
                        wowPlayer[15].精神 = 0;

                        //17级;
                        wowPlayer[16].生命值 = 0;
                        wowPlayer[16].法力值 = 0;
                        wowPlayer[16].力量 = 0;
                        wowPlayer[16].敏捷 = 0;
                        wowPlayer[16].耐力 = 0;
                        wowPlayer[16].智力 = 0;
                        wowPlayer[16].精神 = 0;

                        //18级;
                        wowPlayer[17].生命值 = 0;
                        wowPlayer[17].法力值 = 0;
                        wowPlayer[17].力量 = 0;
                        wowPlayer[17].敏捷 = 0;
                        wowPlayer[17].耐力 = 0;
                        wowPlayer[17].智力 = 0;
                        wowPlayer[17].精神 = 0;

                        //19级;
                        wowPlayer[18].生命值 = 0;
                        wowPlayer[18].法力值 = 0;
                        wowPlayer[18].力量 = 0;
                        wowPlayer[18].敏捷 = 0;
                        wowPlayer[18].耐力 = 0;
                        wowPlayer[18].智力 = 0;
                        wowPlayer[18].精神 = 0;

                        //20级;
                        wowPlayer[19].生命值 = 0;
                        wowPlayer[19].法力值 = 0;
                        wowPlayer[19].力量 = 0;
                        wowPlayer[19].敏捷 = 0;
                        wowPlayer[19].耐力 = 0;
                        wowPlayer[19].智力 = 0;
                        wowPlayer[19].精神 = 0;


                        //21级;
                        wowPlayer[20].生命值 = 0;
                        wowPlayer[20].法力值 = 0;
                        wowPlayer[20].力量 = 0;
                        wowPlayer[20].敏捷 = 0;
                        wowPlayer[20].耐力 = 0;
                        wowPlayer[20].智力 = 0;
                        wowPlayer[20].精神 = 0;

                        //22级;
                        wowPlayer[21].生命值 = 0;
                        wowPlayer[21].法力值 = 0;
                        wowPlayer[21].力量 = 0;
                        wowPlayer[21].敏捷 = 0;
                        wowPlayer[21].耐力 = 0;
                        wowPlayer[21].智力 = 0;
                        wowPlayer[21].精神 = 0;

                        //23级;
                        wowPlayer[22].生命值 = 0;
                        wowPlayer[22].法力值 = 0;
                        wowPlayer[22].力量 = 0;
                        wowPlayer[22].敏捷 = 0;
                        wowPlayer[22].耐力 = 0;
                        wowPlayer[22].智力 = 0;
                        wowPlayer[22].精神 = 0;

                        //24级;
                        wowPlayer[23].生命值 = 0;
                        wowPlayer[23].法力值 = 0;
                        wowPlayer[23].力量 = 0;
                        wowPlayer[23].敏捷 = 0;
                        wowPlayer[23].耐力 = 0;
                        wowPlayer[23].智力 = 0;
                        wowPlayer[23].精神 = 0;

                        //25级;
                        wowPlayer[24].生命值 = 0;
                        wowPlayer[24].法力值 = 0;
                        wowPlayer[24].力量 = 0;
                        wowPlayer[24].敏捷 = 0;
                        wowPlayer[24].耐力 = 0;
                        wowPlayer[24].智力 = 0;
                        wowPlayer[24].精神 = 0;

                        //26级;
                        wowPlayer[25].生命值 = 0;
                        wowPlayer[25].法力值 = 0;
                        wowPlayer[25].力量 = 0;
                        wowPlayer[25].敏捷 = 0;
                        wowPlayer[25].耐力 = 0;
                        wowPlayer[25].智力 = 0;
                        wowPlayer[25].精神 = 0;

                        //27级;
                        wowPlayer[26].生命值 = 0;
                        wowPlayer[26].法力值 = 0;
                        wowPlayer[26].力量 = 0;
                        wowPlayer[26].敏捷 = 0;
                        wowPlayer[26].耐力 = 0;
                        wowPlayer[26].智力 = 0;
                        wowPlayer[26].精神 = 0;

                        //28级;
                        wowPlayer[27].生命值 = 0;
                        wowPlayer[27].法力值 = 0;
                        wowPlayer[27].力量 = 0;
                        wowPlayer[27].敏捷 = 0;
                        wowPlayer[27].耐力 = 0;
                        wowPlayer[27].智力 = 0;
                        wowPlayer[27].精神 = 0;

                        //29级;
                        wowPlayer[28].生命值 = 0;
                        wowPlayer[28].法力值 = 0;
                        wowPlayer[28].力量 = 0;
                        wowPlayer[28].敏捷 = 0;
                        wowPlayer[28].耐力 = 0;
                        wowPlayer[28].智力 = 0;
                        wowPlayer[28].精神 = 0;

                        //30级;
                        wowPlayer[29].生命值 = 0;
                        wowPlayer[29].法力值 = 0;
                        wowPlayer[29].力量 = 0;
                        wowPlayer[29].敏捷 = 0;
                        wowPlayer[29].耐力 = 0;
                        wowPlayer[29].智力 = 0;
                        wowPlayer[29].精神 = 0;

                        //31级;
                        wowPlayer[30].生命值 = 0;
                        wowPlayer[30].法力值 = 0;
                        wowPlayer[30].力量 = 0;
                        wowPlayer[30].敏捷 = 0;
                        wowPlayer[30].耐力 = 0;
                        wowPlayer[30].智力 = 0;
                        wowPlayer[30].精神 = 0;

                        //32级;
                        wowPlayer[31].生命值 = 0;
                        wowPlayer[31].法力值 = 0;
                        wowPlayer[31].力量 = 0;
                        wowPlayer[31].敏捷 = 0;
                        wowPlayer[31].耐力 = 0;
                        wowPlayer[31].智力 = 0;
                        wowPlayer[31].精神 = 0;

                        //33级;
                        wowPlayer[32].生命值 = 0;
                        wowPlayer[32].法力值 = 0;
                        wowPlayer[32].力量 = 0;
                        wowPlayer[32].敏捷 = 0;
                        wowPlayer[32].耐力 = 0;
                        wowPlayer[32].智力 = 0;
                        wowPlayer[32].精神 = 0;

                        //34级;
                        wowPlayer[33].生命值 = 0;
                        wowPlayer[33].法力值 = 0;
                        wowPlayer[33].力量 = 0;
                        wowPlayer[33].敏捷 = 0;
                        wowPlayer[33].耐力 = 0;
                        wowPlayer[33].智力 = 0;
                        wowPlayer[33].精神 = 0;

                        //35级;
                        wowPlayer[34].生命值 = 0;
                        wowPlayer[34].法力值 = 0;
                        wowPlayer[34].力量 = 0;
                        wowPlayer[34].敏捷 = 0;
                        wowPlayer[34].耐力 = 0;
                        wowPlayer[34].智力 = 0;
                        wowPlayer[34].精神 = 0;

                        //36级;
                        wowPlayer[35].生命值 = 0;
                        wowPlayer[35].法力值 = 0;
                        wowPlayer[35].力量 = 0;
                        wowPlayer[35].敏捷 = 0;
                        wowPlayer[35].耐力 = 0;
                        wowPlayer[35].智力 = 0;
                        wowPlayer[35].精神 = 0;

                        //37级;
                        wowPlayer[36].生命值 = 0;
                        wowPlayer[36].法力值 = 0;
                        wowPlayer[36].力量 = 0;
                        wowPlayer[36].敏捷 = 0;
                        wowPlayer[36].耐力 = 0;
                        wowPlayer[36].智力 = 0;
                        wowPlayer[36].精神 = 0;

                        //38级;
                        wowPlayer[37].生命值 = 0;
                        wowPlayer[37].法力值 = 0;
                        wowPlayer[37].力量 = 0;
                        wowPlayer[37].敏捷 = 0;
                        wowPlayer[37].耐力 = 0;
                        wowPlayer[37].智力 = 0;
                        wowPlayer[37].精神 = 0;

                        //39级;
                        wowPlayer[38].生命值 = 0;
                        wowPlayer[38].法力值 = 0;
                        wowPlayer[38].力量 = 0;
                        wowPlayer[38].敏捷 = 0;
                        wowPlayer[38].耐力 = 0;
                        wowPlayer[38].智力 = 0;
                        wowPlayer[38].精神 = 0;

                        //40级;
                        wowPlayer[39].生命值 = 0;
                        wowPlayer[39].法力值 = 0;
                        wowPlayer[39].力量 = 0;
                        wowPlayer[39].敏捷 = 0;
                        wowPlayer[39].耐力 = 0;
                        wowPlayer[39].智力 = 0;
                        wowPlayer[39].精神 = 0;

                        //41级;
                        wowPlayer[40].生命值 = 0;
                        wowPlayer[40].法力值 = 0;
                        wowPlayer[40].力量 = 0;
                        wowPlayer[40].敏捷 = 0;
                        wowPlayer[40].耐力 = 0;
                        wowPlayer[40].智力 = 0;
                        wowPlayer[40].精神 = 0;

                        //42级;
                        wowPlayer[41].生命值 = 0;
                        wowPlayer[41].法力值 = 0;
                        wowPlayer[41].力量 = 0;
                        wowPlayer[41].敏捷 = 0;
                        wowPlayer[41].耐力 = 0;
                        wowPlayer[41].智力 = 0;
                        wowPlayer[41].精神 = 0;

                        //43级;
                        wowPlayer[42].生命值 = 0;
                        wowPlayer[42].法力值 = 0;
                        wowPlayer[42].力量 = 0;
                        wowPlayer[42].敏捷 = 0;
                        wowPlayer[42].耐力 = 0;
                        wowPlayer[42].智力 = 0;
                        wowPlayer[42].精神 = 0;

                        //44级;
                        wowPlayer[43].生命值 = 0;
                        wowPlayer[43].法力值 = 0;
                        wowPlayer[43].力量 = 0;
                        wowPlayer[43].敏捷 = 0;
                        wowPlayer[43].耐力 = 0;
                        wowPlayer[43].智力 = 0;
                        wowPlayer[43].精神 = 0;

                        //45级;
                        wowPlayer[44].生命值 = 0;
                        wowPlayer[44].法力值 = 0;
                        wowPlayer[44].力量 = 0;
                        wowPlayer[44].敏捷 = 0;
                        wowPlayer[44].耐力 = 0;
                        wowPlayer[44].智力 = 0;
                        wowPlayer[44].精神 = 0;

                        //46级;
                        wowPlayer[45].生命值 = 0;
                        wowPlayer[45].法力值 = 0;
                        wowPlayer[45].力量 = 0;
                        wowPlayer[45].敏捷 = 0;
                        wowPlayer[45].耐力 = 0;
                        wowPlayer[45].智力 = 0;
                        wowPlayer[45].精神 = 0;

                        //47级;
                        wowPlayer[46].生命值 = 0;
                        wowPlayer[46].法力值 = 0;
                        wowPlayer[46].力量 = 0;
                        wowPlayer[46].敏捷 = 0;
                        wowPlayer[46].耐力 = 0;
                        wowPlayer[46].智力 = 0;
                        wowPlayer[46].精神 = 0;

                        //48级;
                        wowPlayer[47].生命值 = 0;
                        wowPlayer[47].法力值 = 0;
                        wowPlayer[47].力量 = 0;
                        wowPlayer[47].敏捷 = 0;
                        wowPlayer[47].耐力 = 0;
                        wowPlayer[47].智力 = 0;
                        wowPlayer[47].精神 = 0;

                        //49级;
                        wowPlayer[48].生命值 = 0;
                        wowPlayer[48].法力值 = 0;
                        wowPlayer[48].力量 = 0;
                        wowPlayer[48].敏捷 = 0;
                        wowPlayer[48].耐力 = 0;
                        wowPlayer[48].智力 = 0;
                        wowPlayer[48].精神 = 0;

                        //50级;
                        wowPlayer[49].生命值 = 0;
                        wowPlayer[49].法力值 = 0;
                        wowPlayer[49].力量 = 0;
                        wowPlayer[49].敏捷 = 0;
                        wowPlayer[49].耐力 = 0;
                        wowPlayer[49].智力 = 0;
                        wowPlayer[49].精神 = 0;

                        //51级;
                        wowPlayer[50].生命值 = 0;
                        wowPlayer[50].法力值 = 0;
                        wowPlayer[50].力量 = 0;
                        wowPlayer[50].敏捷 = 0;
                        wowPlayer[50].耐力 = 0;
                        wowPlayer[50].智力 = 0;
                        wowPlayer[50].精神 = 0;

                        //52级;
                        wowPlayer[51].生命值 = 0;
                        wowPlayer[51].法力值 = 0;
                        wowPlayer[51].力量 = 0;
                        wowPlayer[51].敏捷 = 0;
                        wowPlayer[51].耐力 = 0;
                        wowPlayer[51].智力 = 0;
                        wowPlayer[51].精神 = 0;

                        //53级;
                        wowPlayer[52].生命值 = 0;
                        wowPlayer[52].法力值 = 0;
                        wowPlayer[52].力量 = 0;
                        wowPlayer[52].敏捷 = 0;
                        wowPlayer[52].耐力 = 0;
                        wowPlayer[52].智力 = 0;
                        wowPlayer[52].精神 = 0;

                        //54级;
                        wowPlayer[53].生命值 = 0;
                        wowPlayer[53].法力值 = 0;
                        wowPlayer[53].力量 = 0;
                        wowPlayer[53].敏捷 = 0;
                        wowPlayer[53].耐力 = 0;
                        wowPlayer[53].智力 = 0;
                        wowPlayer[53].精神 = 0;

                        //55级;
                        wowPlayer[54].生命值 = 0;
                        wowPlayer[54].法力值 = 0;
                        wowPlayer[54].力量 = 0;
                        wowPlayer[54].敏捷 = 0;
                        wowPlayer[54].耐力 = 0;
                        wowPlayer[54].智力 = 0;
                        wowPlayer[54].精神 = 0;

                        //56级;
                        wowPlayer[55].生命值 = 0;
                        wowPlayer[55].法力值 = 0;
                        wowPlayer[55].力量 = 0;
                        wowPlayer[55].敏捷 = 0;
                        wowPlayer[55].耐力 = 0;
                        wowPlayer[55].智力 = 0;
                        wowPlayer[55].精神 = 0;

                        //57级;
                        wowPlayer[56].生命值 = 0;
                        wowPlayer[56].法力值 = 0;
                        wowPlayer[56].力量 = 0;
                        wowPlayer[56].敏捷 = 0;
                        wowPlayer[56].耐力 = 0;
                        wowPlayer[56].智力 = 0;
                        wowPlayer[56].精神 = 0;

                        //58级;
                        wowPlayer[57].生命值 = 0;
                        wowPlayer[57].法力值 = 0;
                        wowPlayer[57].力量 = 0;
                        wowPlayer[57].敏捷 = 0;
                        wowPlayer[57].耐力 = 0;
                        wowPlayer[57].智力 = 0;
                        wowPlayer[57].精神 = 0;

                        //59级;
                        wowPlayer[58].生命值 = 0;
                        wowPlayer[58].法力值 = 0;
                        wowPlayer[58].力量 = 0;
                        wowPlayer[58].敏捷 = 0;
                        wowPlayer[58].耐力 = 0;
                        wowPlayer[58].智力 = 0;
                        wowPlayer[58].精神 = 0;

                        //60级;
                        wowPlayer[59].生命值 = 0;
                        wowPlayer[59].法力值 = 0;
                        wowPlayer[59].力量 = 0;
                        wowPlayer[59].敏捷 = 0;
                        wowPlayer[59].耐力 = 0;
                        wowPlayer[59].智力 = 0;
                        wowPlayer[59].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //62级;
                        wowPlayer[61].生命值 = 0;
                        wowPlayer[61].法力值 = 0;
                        wowPlayer[61].力量 = 0;
                        wowPlayer[61].敏捷 = 0;
                        wowPlayer[61].耐力 = 0;
                        wowPlayer[61].智力 = 0;
                        wowPlayer[61].精神 = 0;

                        //63级;
                        wowPlayer[62].生命值 = 0;
                        wowPlayer[62].法力值 = 0;
                        wowPlayer[62].力量 = 0;
                        wowPlayer[62].敏捷 = 0;
                        wowPlayer[62].耐力 = 0;
                        wowPlayer[62].智力 = 0;
                        wowPlayer[62].精神 = 0;

                        //64级;
                        wowPlayer[63].生命值 = 0;
                        wowPlayer[63].法力值 = 0;
                        wowPlayer[63].力量 = 0;
                        wowPlayer[63].敏捷 = 0;
                        wowPlayer[63].耐力 = 0;
                        wowPlayer[63].智力 = 0;
                        wowPlayer[63].精神 = 0;

                        //65级;
                        wowPlayer[64].生命值 = 0;
                        wowPlayer[64].法力值 = 0;
                        wowPlayer[64].力量 = 0;
                        wowPlayer[64].敏捷 = 0;
                        wowPlayer[64].耐力 = 0;
                        wowPlayer[64].智力 = 0;
                        wowPlayer[64].精神 = 0;

                        //66级;
                        wowPlayer[65].生命值 = 0;
                        wowPlayer[65].法力值 = 0;
                        wowPlayer[65].力量 = 0;
                        wowPlayer[65].敏捷 = 0;
                        wowPlayer[65].耐力 = 0;
                        wowPlayer[65].智力 = 0;
                        wowPlayer[65].精神 = 0;

                        //67级;
                        wowPlayer[66].生命值 = 0;
                        wowPlayer[66].法力值 = 0;
                        wowPlayer[66].力量 = 0;
                        wowPlayer[66].敏捷 = 0;
                        wowPlayer[66].耐力 = 0;
                        wowPlayer[66].智力 = 0;
                        wowPlayer[66].精神 = 0;

                        //68级;
                        wowPlayer[67].生命值 = 0;
                        wowPlayer[67].法力值 = 0;
                        wowPlayer[67].力量 = 0;
                        wowPlayer[67].敏捷 = 0;
                        wowPlayer[67].耐力 = 0;
                        wowPlayer[67].智力 = 0;
                        wowPlayer[67].精神 = 0;

                        //69级;
                        wowPlayer[68].生命值 = 0;
                        wowPlayer[68].法力值 = 0;
                        wowPlayer[68].力量 = 0;
                        wowPlayer[68].敏捷 = 0;
                        wowPlayer[68].耐力 = 0;
                        wowPlayer[68].智力 = 0;
                        wowPlayer[68].精神 = 0;

                        //70级;
                        wowPlayer[69].生命值 = 0;
                        wowPlayer[69].法力值 = 0;
                        wowPlayer[69].力量 = 0;
                        wowPlayer[69].敏捷 = 0;
                        wowPlayer[69].耐力 = 0;
                        wowPlayer[69].智力 = 0;
                        wowPlayer[69].精神 = 0;

                        //61级;
                        wowPlayer[60].生命值 = 0;
                        wowPlayer[60].法力值 = 0;
                        wowPlayer[60].力量 = 0;
                        wowPlayer[60].敏捷 = 0;
                        wowPlayer[60].耐力 = 0;
                        wowPlayer[60].智力 = 0;
                        wowPlayer[60].精神 = 0;

                        //72级;
                        wowPlayer[71].生命值 = 0;
                        wowPlayer[71].法力值 = 0;
                        wowPlayer[71].力量 = 0;
                        wowPlayer[71].敏捷 = 0;
                        wowPlayer[71].耐力 = 0;
                        wowPlayer[71].智力 = 0;
                        wowPlayer[71].精神 = 0;

                        //73级;
                        wowPlayer[72].生命值 = 0;
                        wowPlayer[72].法力值 = 0;
                        wowPlayer[72].力量 = 0;
                        wowPlayer[72].敏捷 = 0;
                        wowPlayer[72].耐力 = 0;
                        wowPlayer[72].智力 = 0;
                        wowPlayer[72].精神 = 0;

                        //74级;
                        wowPlayer[73].生命值 = 0;
                        wowPlayer[73].法力值 = 0;
                        wowPlayer[73].力量 = 0;
                        wowPlayer[73].敏捷 = 0;
                        wowPlayer[73].耐力 = 0;
                        wowPlayer[73].智力 = 0;
                        wowPlayer[73].精神 = 0;

                        //75级;
                        wowPlayer[74].生命值 = 0;
                        wowPlayer[74].法力值 = 0;
                        wowPlayer[74].力量 = 0;
                        wowPlayer[74].敏捷 = 0;
                        wowPlayer[74].耐力 = 0;
                        wowPlayer[74].智力 = 0;
                        wowPlayer[74].精神 = 0;

                        //76级;
                        wowPlayer[75].生命值 = 0;
                        wowPlayer[75].法力值 = 0;
                        wowPlayer[75].力量 = 0;
                        wowPlayer[75].敏捷 = 0;
                        wowPlayer[75].耐力 = 0;
                        wowPlayer[75].智力 = 0;
                        wowPlayer[75].精神 = 0;

                        //77级;
                        wowPlayer[76].生命值 = 0;
                        wowPlayer[76].法力值 = 0;
                        wowPlayer[76].力量 = 0;
                        wowPlayer[76].敏捷 = 0;
                        wowPlayer[76].耐力 = 0;
                        wowPlayer[76].智力 = 0;
                        wowPlayer[76].精神 = 0;

                        //78级;
                        wowPlayer[77].生命值 = 0;
                        wowPlayer[77].法力值 = 0;
                        wowPlayer[77].力量 = 0;
                        wowPlayer[77].敏捷 = 0;
                        wowPlayer[77].耐力 = 0;
                        wowPlayer[77].智力 = 0;
                        wowPlayer[77].精神 = 0;

                        //79级;
                        wowPlayer[78].生命值 = 0;
                        wowPlayer[78].法力值 = 0;
                        wowPlayer[78].力量 = 0;
                        wowPlayer[78].敏捷 = 0;
                        wowPlayer[78].耐力 = 0;
                        wowPlayer[78].智力 = 0;
                        wowPlayer[78].精神 = 0;

                        //80级;
                        wowPlayer[79].生命值 = 0;
                        wowPlayer[79].法力值 = 0;
                        wowPlayer[79].力量 = 0;
                        wowPlayer[79].敏捷 = 0;
                        wowPlayer[79].耐力 = 0;
                        wowPlayer[79].智力 = 0;
                        wowPlayer[79].精神 = 0;
                        #endregion
                    }
                    break;
                default:
                    {
                        // 错误信息
                    }
                    break;
            }
        }
    }
}
