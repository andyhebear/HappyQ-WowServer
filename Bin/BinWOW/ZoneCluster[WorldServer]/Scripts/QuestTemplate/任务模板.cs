using System;
using System.Text;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Quest;

namespace Demo.Wow.Script.QuestTemplate
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
            // (0x4����������,00����,00����,00001����˳���)
            // ��δ����
            Ψһ��� = 0x40001166;

            //quest_template - ZoneId (mangos���ݿ���ֶ�����)
            //����������AreaTable.dbc�е�һ��ZoneId����
            ������ = 123;

            //quest_template - Title (mangos���ݿ���ֶ�����)
            ������� = "qwqwqw";

            //quest_template - Objectives (mangos���ݿ���ֶ�����)
            ����Ŀ�� = "qwqw";

            //quest_template - Details (mangos���ݿ���ֶ�����)
            ������� = "qwqqw";

            //quest_template - OfferRewardText (mangos���ݿ���ֶ�����)
            ���������Ϣ = "qwqwqw";

            //quest_template - RequestItemsText (mangos���ݿ���ֶ�����)
            ����δ�����Ϣ = "qwqwqw";

            //quest_template - EndText (mangos���ݿ���ֶ�����)
            ���������Ϣ = "qwwq";

            //quest_template - ObjectiveText (mangos���ݿ���ֶ�����)
            ����Ŀ�����[0] = " ";
            ����Ŀ�����[1] = " ";
            ����Ŀ�����[2] = " ";
            ����Ŀ�����[3] = " ";


            //quest_template - QuestSort��QuestSort.dbc���� (mangos���ݿ���ֶ�����)
            ���� = 364;

            //quest_template - Type��QuestInfo.dbc���� (mangos���ݿ���ֶ�����)
            ���� = 1;

            //quest_template - SpecialFlags (mangos���ݿ���ֶ�����)
            //SpecialFlags 0 = ��ͨ , 1 = ���� , 2 = ̽�� , 4 = ��̸ , 8 = ɱ�� , 16 = ��ʱ , 32 = �ظ� , 64 = ���� 
            ��� = 0;

            //quest_template - PrevQuestId (mangos���ݿ���ֶ�����)
            ǰ�������� = 1;

            //quest_template - NextQuestId (mangos���ݿ���ֶ�����)
            ��������� = 1;

            //quest_template - ExclusiveGroup (mangos���ݿ���ֶ�����)
            ��ͬ���񼯱�� = 1;

            //quest_template - NextQuestInChain (mangos���ݿ���ֶ�����)
            ������������ = 1;


            //quest_template - DetailsEmote ������ʱNPC���� (mangos���ݿ���ֶ�����)
            ��ʼ����[0] = new WowQuestEmote( 1212/*���鶯�����*/, 1000/*�ӳ�ʱ��*/);
            ��ʼ����[1] = new WowQuestEmote( 1212/*���鶯�����*/, 1000/*�ӳ�ʱ��*/);
            ��ʼ����[2] = new WowQuestEmote( 1212/*���鶯�����*/, 1000/*�ӳ�ʱ��*/);
            ��ʼ����[3] = new WowQuestEmote( 1212/*���鶯�����*/, 1000/*�ӳ�ʱ��*/);

            //quest_template - IncompleteEmote δ�������NPC���� (mangos���ݿ���ֶ�����)
            ������ = new WowQuestEmote( 1212, 1000 );

            //quest_template - CompleteEmote �������NPC���� (mangos���ݿ���ֶ�����)
            �������� = new WowQuestEmote( 1212, 1000 );

            //quest_template - MinLevel  (mangos���ݿ���ֶ�����)
            ��С�ȼ� = 10;

            //quest_template - QuestLevel  (mangos���ݿ���ֶ�����)
            ����ȼ� = 20;

            //quest_template - RequiredRaces  (mangos���ݿ���ֶ�����)
            ���� = (uint)Wow����.ȫ������;

            //quest_template - RequiredRepFaction (mangos���ݿ���ֶ�����)
            ��Ӫ��� = 123;

            //quest_template - RequiredRepValue (mangos���ݿ���ֶ�����)
            ��Ӫ���� = 123;

            //quest_template - LimitTime (��) (mangos���ݿ���ֶ�����)
            ���ʱ�� = TimeSpan.FromSeconds( 600 );

            //quest_template - srcItem (�����������Ʒ)(mangos���ݿ���ֶ�����)
            ������Ʒ = 12;

            //quest_template - srcItemCount (�����������Ʒ����)(mangos���ݿ���ֶ�����)
            ������Ʒ���� = 1;


            //quest_template - SrcSpell (���������ħ��)(mangos���ݿ���ֶ�����)
            ������ = 1;


            ����.Add( (uint)Wow����.����, 255/*����ֵ*/ );
            ����.Add( (uint)Wow����.��˪, 255 );

            //quest_template - ReqItemId,ReqItemCount(mangos���ݿ���ֶ�����)
            ������Ʒ[0] = new WowQuestItem( 111/*��Ʒ���*/, 1/*��Ʒ����*/ );
            ������Ʒ[1] = new WowQuestItem( 111, 1 );
            ������Ʒ[2] = new WowQuestItem( 111, 1 );
            ������Ʒ[3] = new WowQuestItem( 111, 1 );

            //quest_template - ReqSpellCast(���������Ҫʩ�ŵļ���)(mangos���ݿ���ֶ�����)
            // ������ֶ����� �������� ���ֶε����һ������

            //quest_template - ReqCreatureOrGOId,ReqCreatureOrGOCount(mangos���ݿ���ֶ�����)
            �������[0] = new WowQuestCreature( 112/*������*/, 2/*����*/, 222/*ħ����� ��Ϊ��ʾ��ɱ���������ʹ��ħ�������ڹ�������*/ );
            �������[1] = new WowQuestCreature( 112, 1212 );
            �������[2] = new WowQuestCreature( 112, 1212, 222 );
            �������[3] = new WowQuestCreature( 112, 1212 );


            //quest_template - (mangos���ݿ���ֶ�����)
            ��������[0] = new WowQuestGameObject( 1221/*��Ϸ������*/, 2/*����*/ );
            ��������[1] = new WowQuestGameObject( 1221, 22 );
            ��������[2] = new WowQuestGameObject( 1221, 22 );
            ��������[3] = new WowQuestGameObject( 1221, 22 );

            //quest_template - RewChoiceItemId,RewChoiceItemCount(mangos���ݿ���ֶ�����)
            ѡ������Ʒ[0] = new WowQuestItem( 122112/*��Ʒ���*/, 1212/*��Ʒ����*/ );
            ѡ������Ʒ[1] = new WowQuestItem( 122112, 1212 );
            ѡ������Ʒ[2] = new WowQuestItem( 122112, 1212 );
            ѡ������Ʒ[3] = new WowQuestItem( 122112, 1212 );
            ѡ������Ʒ[4] = new WowQuestItem( 122112, 1212 );
            ѡ������Ʒ[5] = new WowQuestItem( 122112, 1212 );
            ѡ������Ʒ[6] = new WowQuestItem( 122112, 1212 );


            //quest_template - ReqSourceId,ReqSourceRef(mangos���ݿ���ֶ�����)
            ������Ʒ[0] = new WowQuestItem( 122112/*���߱��*/, 1/*��������*/ );
            ������Ʒ[1] = new WowQuestItem( 122112, 1212 );
            ������Ʒ[2] = new WowQuestItem( 122112, 1212 );
            ������Ʒ[3] = new WowQuestItem( 122112, 1212 );


            //quest_template - RewRepFaction,RewRepValue(mangos���ݿ���ֶ�����)
            ��������[0] = new WowQuestFaction( 1212/*��Ӫ���*/, 122/*��Ӫ����ֵ*/ );
            ��������[1] = new WowQuestFaction( 1212, 122 );
            ��������[2] = new WowQuestFaction( 1212, 122 );
            ��������[3] = new WowQuestFaction( 1212, 122 );
            ��������[4] = new WowQuestFaction( 1212, 122 );

            //quest_template - RewOrReqMoney (ֵΪ��ʱΪ������������.ֵΪ��ʱΪ���������Ҫ���.)(mangos���ݿ���ֶ�����)
            ������Ǯ = 0;

            //quest_template - RewXP (mangos���ݿ���ֶ�����)
            �������� = 0;

            //quest_template - RewSpell (mangos���ݿ���ֶ�����)
            �������� = 212;


            //quest_template - Repeatable (mangos���ݿ���ֶ�����)
            �Ƿ��ظ����� = false;



            //δУ���ֶ�
            //PointMapId 
            //PointX 
            //PointY 
            //PointOpt 

            //������ʾ���ͼ��� = 1;
            //������ʾ������X = 1;
            //������ʾ������Y = 1;


            //����̽������.Add( 1221/*��Ҫ ̽����������*/ );
            //����̽������.Add( 121 );



            //mangos���ݿ�δ֪�ֶ�

            //SuggestedPlayers

            //ReqSourceId1
            //ReqSourceId2
            //ReqSourceId3
            //ReqSourceId4
            //ReqSourceCount1
            //ReqSourceCount2
            //ReqSourceCount3
            //ReqSourceCount4
            //ReqSourceRef1
            //ReqSourceRef2
            //ReqSourceRef3
            //ReqSourceRef4

            //OfferRewardEmote1
            //OfferRewardEmote2
            //OfferRewardEmote3
            //OfferRewardEmote4



            //mangos���ݿ���ȡ���ֶ�
            //quest_template - �� (mangos���ݿ���ֶ�����)
            //ְҵ = (uint)Wowְҵ.ȫ��ְҵ;
        }
    }
}
