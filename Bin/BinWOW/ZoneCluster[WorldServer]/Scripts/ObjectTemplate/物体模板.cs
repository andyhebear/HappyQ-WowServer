using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.WorldServer.Object;
using Demo.Wow.Script.ItemTemplate;

namespace Demo.Wow.Script.ObjectTemplate
{
    /// <summary>
    /// ���ĸ�ʽ
    /// </summary>
    public class ����ģ������ : ħ������������Ϣ
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void ��ʼ��������Ϣ()
        {
            // Ψһ���
            //(0x3��������,00����,00����,00001����˳���)
            //����(����)
            //����(��)
            Ψһ��� = 0x3060000001;


            // creature_template - type (mangos���ݿ���ֶ�����)
            // (0 = �� , 1 = ��ť , 2 = ���� , 3 = ���� , 5 = һ�� , 6 = ���� , 7 = ����)
            // (8 = ħ������ , 9 = ���� , 10 = ?  , 18 = �ٻ�ʯ , 22 = ������ , 23 = ����ʯ)
            ���� = 6;


            // creature_template - displayId (mangos���ݿ���ֶ�����)
            ģ�ͱ�� = 1166;


            // creature_template - name (mangos���ݿ���ֶ�����)
            ���� = "����ģ������";


            // creature_template - faction (mangos���ݿ���ֶ�����)
            ��Ӫ = 84;


            // creature_template - flags (mangos���ݿ���ֶ�����)
            ��� = 0;


            // creature_template - size (mangos���ݿ���ֶ�����)
            ��С = 1;


            // creature_template - sound0 (mangos���ݿ���ֶ�����)
            ����[0] = 0;
            ����[1] = 0;
            ����[2] = 0;
            ����[3] = 0;
            ����[4] = 0;
            ����[5] = 0;
            ����[6] = 0;
            ����[7] = 0;
            ����[8] = 0;
            ����[9] = 0;
            ����[10] = 0;
            ����[11] = 0;
            ����[12] = 0;
            ����[13] = 0;
            ����[14] = 0;
            ����[15] = 0;
            ����[16] = 0;
            ����[17] = 0;
            ����[18] = 0;
            ����[19] = 0;
            ����[20] = 0;
            ����[21] = 0;
            ����[22] = 0;
            ����[23] = 0;


            //----------��Ϸ���屬��----------
            // ���û��Ƥë,��Ʒ,����,��ҵ��� = new OneTreasure[0]

            ��Ʒ���� = new OneTreasure[] 
            {
              //������Ʒ��1
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(��Ʒģ������), 44.4f ),
                    new Loot( typeof(��Ʒģ������), 44.4f ),
                    new Loot( typeof(��Ʒģ������), 44.4f ),
                } , 100f ),

              //������Ʒ��2
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(��Ʒģ������), 44.4f ),
                    new Loot( typeof(��Ʒģ������), 44.4f ), 
                    new Loot( typeof(��Ʒģ������), 44.4f ),
                } , 100f ),  
            };

            ������Ʒ���� = new OneTreasure[]
            {
               new OneTreasure(
                new Loot[] {
                    new Loot( typeof(��Ʒģ������), 44.4f )
                } , 100f ),
            };

            ��ҵ��� = new OneTreasure[] 
            {

               new OneTreasure(
                new Loot[] {
                    new GoldLoot( 100, 250, 99.9f )
                } , 100f ),
            };



            //----------��Ϸ����������������Ϣ----------

            // ������
            ����.Add( 0x1234 );
            ����.Add( 0x1235 );

            //----------��Ϸ����������������Ϣ----------



        }
    }
}
