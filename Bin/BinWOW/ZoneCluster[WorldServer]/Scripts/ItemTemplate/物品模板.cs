using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Item;

namespace Demo.Wow.Script.ItemTemplate
{
    /// <summary>
    /// ���ĸ�ʽ
    /// </summary>
    public class ��Ʒģ������ : ħ��������Ʒ��Ϣ
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void ��ʼ����Ʒ��Ϣ()
        {
            // 1.��Ʒ�Ļ�����Ϣ:


            // Ψһ���:
            // (0x2������Ʒ���,00����,00����,00001��Ʒ˳���)
            // ����(00 = ����Ʒ , 01 = ���� , 02 = ���� , 04 = ���� , 05 = ���� , 06 = ��ҩ , 07 = ��ҵ��Ʒ(����)
            //      09 = �䷽ , 11 = ����ҩ�� , 12 = ������Ʒ , 13 = Կ�� , 14 = �������� , 15 = ����)
            // ���������
            Ψһ��� = 0x2040100001;

            // creature_template - class (mangos���ݿ���ֶ�����)
            ���� = 4;

            // SubClass
            // creature_template - subclass (mangos���ݿ���ֶ�����)
            ������ = 1;


            // unk0 = -1,(δ���õ�â�����ݿ��ֶ�,δ֪�ֶ�)


            // creature_template - name,name2,name3,name4 (mangos���ݿ���ֶ�����)
            ����[0] = "��Ʒģ������";
            ����[1] = "��Ʒģ������";
            ����[2] = "��Ʒģ������";
            ����[3] = "Overseer's Cloak";


            // creature_template - displayid (mangos���ݿ���ֶ�����)
            ģ�ͱ�� = 15120;


            // creature_template - Quality (mangos���ݿ���ֶ�����)
            // Ʒ�ʼ���ɫ((0 = ��,1 = ��,2 = ��,3 = ��,4 = ��,5 = ��,6 = ��)
            Ʒ�� = 2;


            // creature_template - Flags (mangos���ݿ���ֶ�����)
            // (0 = �� , 2 = ħ������ , 4 = ����,���� , 32 = ͼ�� , 64 = ��,���ͼ,�䷽�� , 128 = �ͽ���)
            // (512 = ��װֽ,���� , 1024 = ����,������ , 1088 =  ħ��,����,�����ֲ�ȵ� , 8192 = ����ǼǱ�)���ϲ�ȫ)
            ��� = 0;


            // creature_template - BuyCount (mangos���ݿ���ֶ�����)
            �������� = 1;


            // creature_template - BuyPrice (mangos���ݿ���ֶ�����)
            ��� = 3150;


            // creature_template - SellPrice (mangos���ݿ���ֶ�����)
            ���� = 630;


            // creature_template - InventoryType (mangos���ݿ���ֶ�����)
            // 1 = ͷ , 2 = ��,3 = �� , 4 = ���� , 5 = �ز� , 6 = ���� , 7 = �Ȳ� , 8 = �� , 9 = ���� , 10 = ���� , 11 = ��ָ , 12 = ��Ʒ , 13 = ���� 
            // 14 = ���� , 15 = Զ�� , 16 = ���� , 17 = ˫�� , 18 = ���� , 19 = ������� , 20 = ���� , 21 = ���� , 22 = ��ҩ , 23 = Ͷ�� , 24 = ����Զ��
            װ��λ�� = 16;



            // 2.��Ʒװ������:


            // creature_template - AllowableClass (mangos���ݿ���ֶ�����)
            // (0 = ������ , 1 = սʿ , 2 = ʥ��ʿ , 3 = ���� , 4 = ���� , 5 = ��ʦ , 6 = ���� , 7 = ���� , 8 = ��ʦ , 9 = ��ʿ , 10 = ���� , 11 = ��³��)
            ְҵ = 0;


            // creature_template - AllowableRace (mangos���ݿ���ֶ�����)
            // (1 = ���� , 2 = ���� , 3 = ���� , 4 = ��ҹ���� , 5 = ���� , 6 = ţͷ�� , 7 = ٪�� , 8 = ��ħ)
            ���� = 0;


            // creature_template - ItemLevel (mangos���ݿ���ֶ�����)
            ��Ʒ�ȼ� = 20;


            // creature_template - RequiredLevel (mangos���ݿ���ֶ�����)
            װ������ȼ� = 15;



            // creature_template - RequiredSkill (mangos���ݿ���ֶ�����)
            ���������� = 0;


            // creature_template - RequiredSkillRank (mangos���ݿ���ֶ�����)
            ��������ȼ� = 0;


            // creature_template - requiredspell (mangos���ݿ���ֶ�����)
            ���������� = 0;


            // creature_template - requiredhonorrank (mangos���ݿ���ֶ�����)
            ��������ȼ� = 0;


            // creature_template - RequiredCityRank (mangos���ݿ���ֶ�����)
            ��������ȼ� = 0;


            // creature_template - RequiredReputationFaction (mangos���ݿ���ֶ�����)
            ��Ӫ������ = 0;


            // creature_template - RequiredReputationRank (mangos���ݿ���ֶ�����)
            ��Ӫ��������ȼ� = 0;



            // 3.�����Լ�����:


            // creature_template - armor (mangos���ݿ���ֶ�����)
            ����ֵ = 0;


            // creature_template - holy_res (mangos���ݿ���ֶ�����)
            ��ʥ���� = 0;


            // creature_template - fire_res (mangos���ݿ���ֶ�����)
            ���濹�� = 0;


            // creature_template - nature_res (mangos���ݿ���ֶ�����)
            ��Ȼ���� = 0;


            // creature_template - frost_res (mangos���ݿ���ֶ�����)
            ��˪���� = 0;


            // creature_template - shadow_res (mangos���ݿ���ֶ�����)
            ��Ӱ���� = 0;


            // creature_template - arcane_res (mangos���ݿ���ֶ�����)
            �������� = 0;



            // 4.��������:


            // creature_template - stat_type1 (mangos���ݿ���ֶ�����)
            // creature_template - stat_value1 (mangos���ݿ���ֶ�����)
            // ��������(0 = ���� , 1 = ����ֵ , 2 = �� , 3 = ���� , 4 = ���� , 5 = ���� , 6 = ���� , 7 = ����)
            // ������ֵ(0-255)
            ��������[0] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[1] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[2] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[3] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[4] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[5] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[6] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[7] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[8] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );
            ��������[9] = new WowItemAddOnProperty( 0/*������������*/, 0/*������ֵ*/ );


            // 5.�˺�����:

            // creature_template - dmg_type1 (mangos���ݿ���ֶ�����)
            // creature_template - dmg_min1 (mangos���ݿ���ֶ�����)
            // creature_template - dmg_max1 (mangos���ݿ���ֶ�����) 
            // �˺�����(0 = ��ͨ�˺� , 1 = ��ʥ�˺� , 2 = �����˺� , 3 = ��Ȼ�˺� , 4 = ��˪�˺� , 5 = ��Ӱ�˺� , 6 = �����˺�) 

            ��ʥ��С�˺� = 0;
            ��ʥ����˺� = 0;

            ������С�˺� = 0;
            ��������˺� = 0;

            ��Ȼ��С�˺� = 0;
            ��Ȼ����˺� = 0;

            ��˪��С�˺� = 0;
            ��˪����˺� = 0;

            ��Ӱ��С�˺� = 0;
            ��Ӱ����˺� = 0;

            ������С�˺� = 0;
            ��������˺� = 0;




            // 6.�����Ͱ�������:

            // creature_template - maxcount (mangos���ݿ���ֶ�����)
            �ɳ���������� = 1;

            // creature_template - stackable (mangos���ݿ���ֶ�����)
            �ɶѵ����� = 0;

            // creature_template - ContainerSlots (mangos���ݿ���ֶ�����)
            �������� = 0;




            // 7.��ս��Զ������:

            // creature_template - ammo_type (mangos���ݿ���ֶ�����)
            // (0 = �� , 2 = ���� , 3 = �ӵ�)
            ��ҩ���� = 0;


            // creature_template - delay (mangos���ݿ���ֶ�����)
            ������� = 0;


            // creature_template - RangedModRange (mangos���ݿ���ֶ�����)
            // (0 = ��Զ������ , 3 = �����װ�� , 100 = Զ������)
            �������� = 0;




            // 8.��������(�ܶ�δ֪):

            // creature_template - entry (mangos���ݿ���ֶ�����)
            // (0 = �ް� , 1 = ʰȡ��� , 2 = װ����� , 3 = ʹ�ú�� , 4 = ������Ʒ)
            ������ = 0;


            // creature_template - description (mangos���ݿ���ֶ�����)
            ������Ϣ = "�����һ������";


            // creature_template - PageText (mangos���ݿ���ֶ�����)
            ���ֱ�� = 0;


            // creature_template - LanguageID (mangos���ݿ���ֶ�����)
            �������� = 0;


            // creature_template - PageMaterial (mangos���ݿ���ֶ�����)
            ҳ����� = 0;


            // creature_template - startquest (mangos���ݿ���ֶ�����)
            ������ = 0;


            // creature_template - Lockid (mangos���ݿ���ֶ�����)
            ���ı�� = 0;


            // creature_template - Material (mangos���ݿ���ֶ�����)
            // 
            �������� = 0;


            // creature_template - Sheath (mangos���ݿ���ֶ�����)
            // 
            ���λ�� = 0;


            // creature_template - Extra (mangos���ݿ���ֶ�����)
            ������Ʒ = 0;


            // creature_template - block (mangos���ݿ���ֶ�����)
            �� = 0;


            // creature_template - itemset (mangos���ݿ���ֶ�����)
            ��װ��� = 0;


            // creature_template - MaxDurability (mangos���ݿ���ֶ�����)
            ����;ö� = 0;


            // creature_template - Area (mangos���ݿ���ֶ�����)
            �޶��ص� = 0;


            // creature_template - BagFamily (mangos���ݿ���ֶ�����)
            �������� = 0;



            //ScriptName �ű����� (δ���õ�â�����ݿ��ֶ�) 
            //DisenchantID δ֪   (δ���õ�â�����ݿ��ֶ�) 



            // 9.װ������Ч��ħ��Ч��:

            //mangos���ݿ���ֶ�����,��������ο�װ���G��Ч��ħ��Ч������
            //spellid_1      (ħ��Ч�����)
            //spelltrigger_1 (��������, 0 = ʹ��Ч�� , 1 = װ��Ч�� , 2 = ����Ч��)
            //spellcharges_1 (ħ������,��ȷ��)
            //spellcooldown_1 (��ȴʱ��)
            //spellcategory_1 (ħ������,��ȷ��)
            //spellcategorycooldown_1 (ħ����ȴ����,��ȷ��)

            ����[0] = new WowItemSpell( 0/*ħ��Ч��*/, 0/*��������*/, 0/*ħ������*/, 0/*��ȴʱ��*/, 0/*ħ������*/, 0/*ħ����ȴ����*/ );
            ����[1] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            ����[2] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            ����[3] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );
            ����[4] = new WowItemSpell( 0, 0, 0, 0, 0, 0 );






            //mangos���ݿ�δ���õ�δ֪�ֶ�

            // 10.TBC����װ�������ֶ�:

            // unk_203
            // Map
            // TotemCategory
            // socketColor_1                     // ȡֵ��Χ��֪
            // socketContent_1                   // ȡֵ��Χ��֪
            // socketColor_2                     // ȡֵ��Χ��֪
            // socketContent_2                   // ȡֵ��Χ��֪
            // socketColor_3                     // ȡֵ��Χ��֪
            // socketContent_3                   // ȡֵ��Χ��֪
            // socketBonus                       // ȡֵ��Χ��֪
            // GemProperties
            // RequiredDisenchantSkill
            // ExtendedCost


            //mangos���ݿ�δ���õ���֪�ֶ�
        }
    }
}
