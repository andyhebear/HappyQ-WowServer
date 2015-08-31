using System;
using System.Text;
using System.Collections.Generic;
using Demo.Mmose.Core.Entity.Suit.Treasure;
using Demo.Wow.Script.ItemTemplate;
using Demo.Wow.Script.GlobalConfig;
using Demo.Wow.WorldServer.Creature;


namespace Demo.Wow.Script.CreatureTemplate
{
    /// <summary>
    /// ���ĸ�ʽ
    /// </summary>
    public class ����Ա�: ħ������������Ϣ
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void ��ʼ��������Ϣ()
        {
            // Ψһ���
            // (0x1���������,00����,00����,00001����˳���)
            // (11 = ͼ�� , 10 = δָ�� , 09 = ��е , 08 = С���� , 07 = �������� , 06 = ���� , 05 = ���� , 04 = Ԫ������ , 03 = ��ħ , 02 = ���� , 01 = Ұ��) 
            // ������
            Ψһ��� = 0x1010000684;


            // creature_template - modelid (mangos���ݿ���ֶ�����)
            ģ�ͱ�� = 633;


            // creature_template - name (mangos���ݿ���ֶ�����)
            ���� = "����Ա�";


            // creature_template - subname (mangos���ݿ���ֶ�����)
            ���� = "����Ա�";


            // creature_template - minlevel (mangos���ݿ���ֶ�����)
            ��С�ȼ� = 37;


            // creature_template - maxlevel (mangos���ݿ���ֶ�����)
            ���ȼ� = 38;


            // creature_template - minhealth (mangos���ݿ���ֶ�����)
            ��С����ֵ = 1586;


            // creature_template - maxhealth (mangos���ݿ���ֶ�����)
            �������ֵ = 1651;


            // creature_template - minmana (mangos���ݿ���ֶ�����)
            ��Сħ��ֵ = 0;


            // creature_template - maxmana  (mangos���ݿ���ֶ�����)
            ���ħ��ֵ = 0;


            // creature_template - armor (mangos���ݿ���ֶ�����)
            ������ = 0;


            // creature_template - Faction (mangos���ݿ���ֶ�����)
            ��Ӫ = 16;


            // creature_template - Npcflag (mangos���ݿ���ֶ�����)
            // ȡֵ��Χ��mangos���ݿ�npc_option��
            NPC��� = 0;


            // creature_template - speed (mangos���ݿ���ֶ�����)
            �ٶ� = 1.3F;


            // creature_template - rank (mangos���ݿ���ֶ�����)
            // ���� 0 = ��ͨ , 1 = ��Ӣ , 2 = ϡ�о�Ӣ , 3 = ����BOSS , 4 = �ǳ�ϡ��
            �ײ� = 0;


            // creature_template - mindmg (mangos���ݿ���ֶ�����)
            ��С�˺� = 55;


            // creature_template - maxdmg (mangos���ݿ���ֶ�����)
            ����˺� = 80;


            // creature_template - attackpower (mangos���ݿ���ֶ�����)
            ������ = 100;


            // creature_template - baseattacktime (mangos���ݿ���ֶ�����)
            ������� = 1620;


            // creature_template - rangeattacktime (mangos���ݿ���ֶ�����)
            Զ�̹������ = 1782;


            //flags           (δ���õ�mangos���ݿ�,δ֪�ֶ�)       
            //dynamicflags    (δ���õ�mangos���ݿ�,δ֪�ֶ�)


            // creature_template - size (mangos���ݿ���ֶ�����)
            // ģ�͵Ĵ�С�ߴ�
            ��С = 1.15F;


            // creature_template - family (mangos���ݿ���ֶ�����)
            // (0=��,1=��,2=��,3=֩��,4=��,5=Ұ��,6=����,7=ʳ����,8=�з,9=����,11=Ѹ����,12=ƽԭ½����,15=������Ȯ)             
            // (16=�������,17=��ħ,19=ĩ������,20=Ы��,21=����,23=С��,24=����,25=����,26=èͷӥ,27=����,28=Զ�̿���)
            ���� = 2;


            // creature_template - bounding_radius (mangos���ݿ���ֶ�����)
            ������Χ = 2;


            // creature_template - trainer_type (mangos���ݿ���ֶ�����)
            // (0 = ��ͨ , 1 = �츳 , 2 = ��ҵ���� , 3 = ���� )
            ѵ��ʦ���� = 0;


            // creature_template - trainer_spell (mangos���ݿ���ֶ�����)
            ѵ��������� = 0;


            // creature_template - class (mangos���ݿ���ֶ�����)
            // (0 = ������ , 1 = սʿ , 2 = ʥ��ʿ , 3 = ���� , 4 = ���� , 5 = ��ʦ , 6 = ���� , 7 = ���� , 8 = ��ʦ , 9 = ��ʿ , 10 = ���� , 11 = ��³��)
            ְҵ = 0;


            // creature_template - race  (mangos���ݿ���ֶ�����)
            // (1 = ���� , 2 = ���� , 3 = ���� , 4 = ��ҹ���� , 5 = ���� , 6 = ţͷ�� , 7 = ٪�� , 8 = ��ħ)
            ���� = 0;


            // creature_template - minrangedmg (mangos���ݿ���ֶ�����)
            Զ����С�˺� = 52.7472F;


            // creature_template - maxrangedmg (mangos���ݿ���ֶ�����)
            Զ������˺� = 72.5274F;


            // creature_template - rangedattackpower (mangos���ݿ���ֶ�����)
            Զ�̹����� = 100;


            // creature_template - combat_reach (mangos���ݿ���ֶ�����)
            ս����Χ = 2.43F;


            // creature_template - type (mangos���ݿ���ֶ�����)
            // (11 = ͼ�� , 10 = δָ�� , 09 = ��е , 08 = С���� , 07 = �������� , 06 = ���� , 05 = ���� , 04 = Ԫ������ , 03 = ��ħ , 02 = ���� , 01 = Ұ��) 
            ���� = 1;


            // creature_template - civilian (mangos���ݿ���ֶ�����
            // (1-�� 0-����)
            �Ƿ�ƽ�� = false;


            // equipmodel1,equipmodel2,equipmodel3,info1,info2,info3,slot1,slot2,slot3 (mangos���ݿ���ֶ�����)
            װ����Ϣ[0] = new WowCreatureEquip( 0/*װ��ģ��*/, 0/*װ����Ϣ*/, 0/*װ��λ��*/ );
            װ����Ϣ[1] = new WowCreatureEquip( 0, 0, 0 );
            װ����Ϣ[2] = new WowCreatureEquip( 0, 0, 0 );



            // creature_template - resistance1 (mangos���ݿ���ֶ�����)
            ��ʥ���� = 0;

            // creature_template - resistance2 (mangos���ݿ���ֶ�����)
            ���濹�� = 0;

            // creature_template - resistance3 (mangos���ݿ���ֶ�����)
            ��Ȼ���� = 0;

            // creature_template - resistance4 (mangos���ݿ���ֶ�����)
            ��˪���� = 0;

            // creature_template - resistance5 (mangos���ݿ���ֶ�����)
            ��Ӱ���� = 0;

            // creature_template - resistance6 (mangos���ݿ���ֶ�����)
            �������� = 0;



            //spell1 ... spell4  (mangos���ݿ���ֶ�����)
            ������Ϣ[0] = new WowCreatureSpell( 0 ); ;
            ������Ϣ[1] = new WowCreatureSpell( 0 );
            ������Ϣ[2] = new WowCreatureSpell( 0 );
            ������Ϣ[3] = new WowCreatureSpell( 0 );



            // creature_template - MovementType (mangos���ݿ���ֶ����� 0=ԭ�ز��� 1=�����߶� 2=����creature_movement���·�����ƶ�)
            �ƶ���ʽ = 1;


            // creature_template - InhabitType (mangos���ݿ���ֶ�����)
            ��Ϣ��ʽ = 1;


            // creature_template - ??? (mangos���ݿ���ֶ�����)
            ����ģ�ͱ�� = 0;




            // ���ﱩ�ʲ���
            // �����û��Ƥë,��Ʒ,����,��ҵ��� = new OneTreasure[0]
            // �ο����ﱩ������˵��
            // ֧����Ʒ�Զ�����鱬��

            Ƥë���� = new OneTreasure[] 
            {


                new OneTreasure(
                new Loot[]{
                    new Loot( typeof(��Ʒģ������/*Ƥë����*/), 44.4f ) 
                    } , 100f ),
            };


            ��Ʒ���� = new OneTreasure[] 
            {
              //������Ʒ��1
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(��Ʒģ������/*��Ʒ1����*/), 44.4f ),
                    new Loot( typeof(��Ʒģ������/*��Ʒ2����*/), 44.4f ),
                    new Loot( typeof(��Ʒģ������/*��ƷN����*/), 44.4f ),
                } , 100f ),

              //������Ʒ��2
               new OneTreasure(
                new Loot[]{
                    new Loot( typeof(��Ʒģ������/*��Ʒ1����*/), 44.4f ),
                    new Loot( typeof(��Ʒģ������/*��Ʒ2����*/), 44.4f ), 
                    new Loot( typeof(��Ʒģ������/*��ƷN����*/), 44.4f ),
                } , 100f ),
            };


            ������Ʒ���� = new OneTreasure[]
            {
               new OneTreasure(
                new Loot[] {
                    new Loot( typeof(��Ʒģ������/*������Ʒ��*/), 44.4f )
                } , 100f ),
            };


            ��ҵ��� = new OneTreasure[] 
            {
               new OneTreasure(
                new Loot[] {
                    new GoldLoot( 100, 250, 99.9f )
                } , 100f ),
            };



            //----------���������������Ϣ----------

            // ������
            ����.Add( 0x1234 );
            ����.Add( 0x1235 );

            //----------���������������Ϣ----------



            //mangos���ݿ�δ���õ�δ֪�ֶ�
            //flags
            //dynamicflags
            //flag1



            //mangos���ݿ�δ���õ���֪�ֶ�
            //lootid
            //pickpocketloot
            //skinloot
            //mingold
            //maxgold
            //AIName
            //ScriptName
        }
    }
}