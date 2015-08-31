using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.Script.ItemTemplate
{
    /// <summary>
    /// 
    /// </summary>
    public enum Wow����
    {
        ����Ʒ = 0,
        ���� = 1,
        ���� = 2,
        ���� = 4,
        ���� = 5,
        ��ҩ = 6,
        ��ҵ��Ʒ = 7,
        �䷽ = 9,
        ��ҩ�� = 11,
        ������� = 12,
        Կ�� = 13,
        ���� = 15,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowConsumable
    {
        /// <summary>
        /// 
        /// </summary>
        Food = 1,
        /// <summary>
        /// 
        /// </summary>
        Liquid = 2,
        /// <summary>
        /// usable in combat
        /// </summary>
        Potion = 3,
        /// <summary>
        /// usable in combat
        /// </summary>
        Scroll = 4,
        /// <summary>
        /// (usable in combat) 
        /// </summary>
        Bandage = 5,
        /// <summary>
        /// (usable in combat) 
        /// </summary>
        Healthstone = 6,
        /// <summary>
        /// (usable in combat)
        /// </summary>
        CombatEffect = 7,
    }

    /// <summary>
    /// Wow���͵�������Ʒʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow����������Ʒ
    {
        ȱʡ = 0,
        ʳ�� = 1,
        Һ�� = 2,
        ҩ�� = 3,
        ���� = 4,
        ���� = 5,
        /// <summary>
        /// ����������
        /// </summary>
        ����ʯ = 6,
        /// <summary>
        /// ����������
        /// </summary>
        ս��Ч�� = 7,
    }

    /// <summary>
    /// Wow���͵�������ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow����������
    {
        ���� = 0,
        ���� = 1,
        ��ҩ�� = 2,
        ��ħ���ϴ� = 3,
        ����ѧ���ϴ� = 4,
    }

    /// <summary>
    /// Wow���͵�������ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow����������
    {
        ���ָ� = 0,
        ˫�ָ� = 1,
        �� = 2,
        ǹ = 3,
        ���ִ� = 4,
        ˫�ִ� = 5,
        �������� = 6,
        ���ֽ� = 7,
        ˫�ֽ� = 8,
        ���� = 10,
        �������� = 11,
        ˫������ = 12,
        ȭ�� = 13,
        ��ͷ�������� = 14,
        ذ�� = 15,
        Ͷ������ = 16,
        ì = 17,
        �� = 18,
        ħ�� = 19,
        ��� = 20,
    }

    /// <summary>
    /// Wow���͵��ڿ���ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�����Ϳ���
    {
        /// <summary>
        /// ��ָ��
        /// </summary>
        ���� = 0,
        ���� = 1,
        Ƥ�� = 2,
        ���� = 3,
        ��� = 4,
        СԲ�� = 5,
        ���� = 6,
        ʥ�� = 7,
        ���� = 8,
        ͼ�� = 9,
    }

    /// <summary>
    /// Wow���͵��ڲ���ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�����Ͳ���
    {
        ȱʡ = 0,
    }

    /// <summary>
    /// Wow���͵��ڵ�ҩʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�����͵�ҩ
    {
        ���� = 1,
        ���� = 2,
        ǹ�� = 3,
        Ͷ������ = 4,
    }

    /// <summary>
    /// Wow���͵�����ҵ����ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow��������ҵ��Ʒ
    {
        ��ҵ������� = 0,
        ��� = 1,
        ��ҩը�� = 2,
        ���̵��� = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowRecipe
    {
        Book = 0,
        /// <summary>
        /// Leatherworking
        /// </summary>
        Pattern = 1,
        /// <summary>
        /// Tailoring
        /// </summary>
        Pattern2 = 2,
        /// <summary>
        /// Engineering
        /// </summary>
        Schematic = 3,
        /// <summary>
        /// Blacksmithing
        /// </summary>
        Plans = 4,
        /// <summary>
        /// Cooking
        /// </summary>
        Recipe = 5,
        /// <summary>
        /// Alchemy
        /// </summary>
        Recipe2 = 6,
        /// <summary>
        /// First Aid
        /// </summary>
        Manual = 7,
        /// <summary>
        /// Enchanting
        /// </summary>
        Formula = 8,
        /// <summary>
        /// Fishing
        /// </summary>
        Manual2 = 9,
    }

    /// <summary>
    /// Wow���͵����䷽ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�������䷽
    {
        �� = 0,
        ��Ƥ = 1,
        �÷� = 2,
        ����ѧ = 3,
        ���� = 4,
        ��� = 5,
        ������ = 6,
        ���� = 7,
        ��ħ = 8,
        ���� = 9,
    }

    /// <summary>
    /// Wow���͵��ڵ�ҩ��ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�����͵�ҩ��
    {
        /// <summary>
        /// ������
        /// </summary>
        ���� = 0,
        /// <summary>
        /// ������
        /// </summary>
        ����I = 1,
        /// <summary>
        /// ������
        /// </summary>
        ����II = 2,
        /// <summary>
        /// ǹ��
        /// </summary>
        ��ҩ�� = 3,
    }


    /// <summary>
    /// Wow���͵�������ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow�������������
    {
        ȱʡ = 0,
    }

    /// <summary>
    /// Wow���͵���Կ��ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow������Կ��
    {
        Կ�� = 0,
        ���� = 1,
    }

    /// <summary>
    /// Wow���͵�������ʱ Wow�����͵���ϸ����
    /// </summary>
    public enum Wow����������
    {
        ȱʡ = 0,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowƷ��
    {
        �Ұ� = 0,
        ��ɫ = 1,
        ��ɫ = 2,
        ��ɫ = 3,
        ��ɫ = 4,
        ��ɫ = 5,
        ��ɫ = 6,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wow���
    {
        ȱʡ = 0,
        ħ������ = 2,
        ���� = 4,
        ͼ�� = 32,
        ������ͼ�� = 64,
        ���� = 512,
        ����ǼǱ� = 8192,
        PvP������Ʒ = 32768,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow���λ��
    {
        ȱʡ = 0,
        ˫��֮���ں�������� = 1,
        ��֮���ں�������� = 2,
        ����֮���Ա� = 3,
        ��֮�ں�� = 4,
        ��ħ�� = 5,
        ȭ�׻�ѳ�ͷ�� = 7,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wowװ��λ��
    {
        /// <summary>
        /// ʳƷ��Ȫˮ�����ҡ����ݡ�Ƥë����ҩ�����ࡢ�㡢�͡�����Сʯͷ��ҩˮ�����ᡢ�����������������Ʒ 
        /// </summary>
        ���� = 0,
        ͷ = 1,
        �� = 2,
        �� = 3,
        ���� = 4,
        �� = 5,
        �� = 6,
        �� = 7,
        �� = 8,
        ���� = 9,
        ���� = 10,
        ��ָ = 11,
        ��Ʒ = 12,
        ���� = 13,
        ����֮�� = 14,
        �� = 15,
        �� = 16,
        ˫�� = 17,
        ���� = 18,
        ���� = 19,
        ���� = 20,
        ���� = 21,
        ���� = 22,
        �� = 23,
        ��ҩ = 24,
        δ֪ = 25,
        ǹ = 26,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow������
    {
        ���� = 0,
        ʰȡ�� = 1,
        װ���� = 2,
        ʹ�ð� = 3,
        ������� = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow��������
    {
        ������ = 1,
        ��ľ��Ʒ = 2,
        ҩˮ��Һ�Ƶ�Һ�� = 3,
        ��ָ����ը����û��ģ�͵Ķ��� = 4,
        ���������� = 5,
        ��ɫ��Ʒ = 6,
        ������Ʒ = 7,
        Ƥ����Ʒ = 8,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wowְҵ
    {
        սʿ = 1,
        ʥ��ʿ = 2,
        ���� = 4,
        ���� = 8,
        ��ʦ = 16,
        ������˾ = 64,
        ��ʦ = 128,
        ��ʿ = 256,
        ��³�� = 1024,
        ȫ��ְҵ = սʿ + ʥ��ʿ + ���� + ���� + ��ʦ + ������˾ + ��ʦ + ��ʿ + ��³��,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum Wow����
    {
        ���� = 1,
        ���� = 2,
        ���� = 4,
        ��ҹ���� = 8,
        ���� = 16,
        ţͷ = 32,
        ٪�� = 64,
        ��ħ = 128,
        Ѫ���� = 256,
        ������ = 512,
        ȫ������ = ���� + ���� + ���� + ��ҹ���� + ���� + ţͷ + ٪�� + ��ħ + Ѫ���� + ������,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowReputationRank
    {
        Hated = 0,
        Hostile = 1,
        Unfriendly = 2,
        Neutral = 3,
        Friendly = 4,
        Honored = 5,
        Reverted = 6,
        Exalted = 7,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow�����ȼ�
    {
        ȱʡ = 0,
        ��� = 0,
        �ж� = 1,
        ������ = 2,
        ���� = 3,
        ���� = 4,
        �� = 5,
        �羴 = 6,
        ��� = 7,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum Wow��ҩ����
    {
        ȱʡ = 0,
        �� = 2,
        �ӵ� = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum WowLanguageType
    {
        Orcish = 1,
        Darnassian = 2,
        Taurahe = 3,
        Dwarvish = 6,
        Common = 7,
        Demonic = 8,
        Titan = 9,
        Thelassian = 10,
        Draconic = 11,
        Kalimag = 12,
        Gnomish = 13,
        Troll = 14,
        Gutterspeak = 33,
    }

    public enum Wow��������
    {
        ȱʡ = 0,
        Orcish = 1,
        Darnassian = 2,
        Taurahe = 3,
        Dwarvish = 6,
        Common = 7,
        Demonic = 8,
        Titan = 9,
        Thelassian = 10,
        Draconic = 11,
        Kalimag = 12,
        Gnomish = 13,
        Troll = 14,
        Gutterspeak = 33,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wowҳ���������
    {
        ȱʡ = 0,
        ��Ƥ = 1,
        ʯͷ = 2,
        ����ʯ = 3,
        ���� = 4,
        ��ͭ = 5,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow��������
    {
        ȱʡ = 0,
        ���ͱ��� = 1,
        �ӵ����� = 2,
        �����Ƭ���� = 3,
        ҩ�ݱ��� = 6,
        /// <summary>
        /// ��������
        /// </summary>
        �Ի󱳰� = 7,
        ���̱��� = 8,
        Կ�ױ��� = 9,
        ��ʯ���� = 10,
        ��ʯ���� = 12,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Wow״̬����
    {
        ħ�� = 0,
        ���� = 1,
        ���� = 3,
        ���� = 4,
        ���� = 5,
        ���� = 6,
        ���� = 7,
    }
}
