using System;
using System.Text;
using System.Collections.Generic;

namespace Demo.Wow.WorldServer.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class InventorySlot
    {
        /// <summary>
        /// 
        /// </summary>
        public const int MAX_INVENTORY_SLOT = 118;
        /// <summary>
        /// 
        /// </summary>
        public const int MAX_BUYBACK_SLOT = 12;
    }

    /// <summary>
    /// 
    /// </summary>
    public class EquipmentSlot
    {
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotStart = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotHead = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotNeck = 1;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotShoulders = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotBody = 3;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotChest = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotWaist = 5;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotLegs = 6;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotFeet = 7;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotWrists = 8;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotHands = 9;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotFinger1 = 10;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotFinger2 = 11;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotTrinket1 = 12;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotTrinket2 = 13;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotBack = 14;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotMainhand = 15;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotOffhand = 16;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotRanged = 17;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotTabard = 18;
        /// <summary>
        /// 
        /// </summary>
        public const int EquipmentSlotEnd = 19;
    }

    /// <summary>
    /// 
    /// </summary>
    public class InventorySlotBag
    {
        /// <summary>
        /// 人物身上的(背包)
        /// </summary>
        public const int InventorySlotEquipmentBag = 18;


        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBagStart = 19;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBag1 = 19;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBag2 = 20;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBag3 = 21;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBag4 = 22;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBagEnd = 23;

        /// <summary>
        /// 人物主要的背包
        /// </summary>
        public const int InventorySlotMainBag = 23;
    }

    /// <summary>
    /// 
    /// </summary>
    public class BagSlotItem
    {
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItemStart = 23;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem1 = 23;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem2 = 24;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem3 = 25;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem4 = 26;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem5 = 27;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem6 = 28;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem7 = 29;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem8 = 30;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem9 = 31;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem10 = 32;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem11 = 33;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem12 = 34;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem13 = 35;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem14 = 36;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem15 = 37;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItem16 = 38;
        /// <summary>
        /// 
        /// </summary>
        public const int BagSlotItemEnd = 39;
    }

    /// <summary>
    /// 
    /// </summary>
    public class BankSlotItem
    {
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItemStart = 39;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem1 = 39;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem2 = 40;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem3 = 41;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem4 = 42;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem5 = 43;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem6 = 44;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem7 = 45;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem8 = 46;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem9 = 47;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem10 = 48;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem11 = 49;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem12 = 50;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem13 = 51;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem14 = 52;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem15 = 53;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem16 = 54;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem17 = 55;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem18 = 56;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem19 = 57;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem20 = 58;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem21 = 59;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem22 = 60;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem23 = 61;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem24 = 62;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem25 = 63;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem26 = 64;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem27 = 65;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItem28 = 66;
        /// <summary>
        /// 
        /// </summary>
        public const int BankSlotItemEnd = 67;
    }

    /// <summary>
    /// 
    /// </summary>
    public class InventorySlotBank
    {
        /// <summary>
        /// BankSlotItem
        /// </summary>
        public const int InventorySlotDefaultBank = 66;

        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBankStart = 67;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank1 = 67;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank2 = 68;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank3 = 69;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank4 = 70;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank5 = 71;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank6 = 72;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBank7 = 73;
        /// <summary>
        /// 
        /// </summary>
        public const int InventorySlotBankEnd = 74;
    }

    /// <summary>
    /// 
    /// </summary>
    public class InventoryKeyRing
    {
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRingBag = 86;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRingStart = 86;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing1 = 86;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing2 = 87;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing3 = 88;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing4 = 89;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing5 = 90;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing6 = 91;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing7 = 92;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing8 = 93;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing9 = 94;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing10 = 95;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing11 = 96;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing12 = 97;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing13 = 98;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing14 = 99;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing15 = 100;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing16 = 101;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing17 = 102;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing18 = 103;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing19 = 104;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing20 = 105;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing21 = 106;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing22 = 107;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing23 = 108;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing24 = 109;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing25 = 110;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing26 = 111;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing27 = 112;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing28 = 113;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing29 = 114;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing30 = 115;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing31 = 116;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRing32 = 117;
        /// <summary>
        /// 
        /// </summary>
        public const int InventoryKeyRingEnd = 118;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SpecialItemType
    {
        None = 0,
        BowAmmo = 1,
        GunAmmo = 2,
        SoulShard = 3,
        Herbalism = 6,
        Enchantment = 7,
        KeyRing = 9,
    }

    /// <summary>
    /// 1 (SHIFT+1)
    /// </summary>
    public class ActionBar1
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button0 = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int Button1 = 1;
        /// <summary>
        /// 
        /// </summary>
        public const int Button2 = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int Button3 = 3;
        /// <summary>
        /// 
        /// </summary>
        public const int Button4 = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int Button5 = 5;
        /// <summary>
        /// 
        /// </summary>
        public const int Button6 = 6;
        /// <summary>
        /// 
        /// </summary>
        public const int Button7 = 7;
        /// <summary>
        /// 
        /// </summary>
        public const int Button8 = 8;
        /// <summary>
        /// 
        /// </summary>
        public const int Button9 = 9;
        /// <summary>
        /// 
        /// </summary>
        public const int Button10 = 10;
        /// <summary>
        /// 
        /// </summary>
        public const int Button11 = 11;
    }

    /// <summary>
    /// 2 (SHIFT+2)
    /// </summary>
    public class ActionBar2
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button12 = 12;
        /// <summary>
        /// 
        /// </summary>
        public const int Button13 = 13;
        /// <summary>
        /// 
        /// </summary>
        public const int Button14 = 14;
        /// <summary>
        /// 
        /// </summary>
        public const int Button15 = 15;
        /// <summary>
        /// 
        /// </summary>
        public const int Button16 = 16;
        /// <summary>
        /// 
        /// </summary>
        public const int Button17 = 17;
        /// <summary>
        /// 
        /// </summary>
        public const int Button18 = 18;
        /// <summary>
        /// 
        /// </summary>
        public const int Button19 = 19;
        /// <summary>
        /// 
        /// </summary>
        public const int Button20 = 20;
        /// <summary>
        /// 
        /// </summary>
        public const int Button21 = 21;
        /// <summary>
        /// 
        /// </summary>
        public const int Button22 = 22;
        /// <summary>
        /// 
        /// </summary>
        public const int Button23 = 23;
    }

    /// <summary>
    /// 3 (SHIFT+3) == Right Side Bar
    /// </summary>
    public class ActionBar3
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button24 = 24;
        /// <summary>
        /// 
        /// </summary>
        public const int Button25 = 25;
        /// <summary>
        /// 
        /// </summary>
        public const int Button26 = 26;
        /// <summary>
        /// 
        /// </summary>
        public const int Button27 = 27;
        /// <summary>
        /// 
        /// </summary>
        public const int Button28 = 28;
        /// <summary>
        /// 
        /// </summary>
        public const int Button29 = 29;
        /// <summary>
        /// 
        /// </summary>
        public const int Button30 = 30;
        /// <summary>
        /// 
        /// </summary>
        public const int Button31 = 31;
        /// <summary>
        /// 
        /// </summary>
        public const int Button32 = 32;
        /// <summary>
        /// 
        /// </summary>
        public const int Button33 = 33;
        /// <summary>
        /// 
        /// </summary>
        public const int Button34 = 34;
        /// <summary>
        /// 
        /// </summary>
        public const int Button35 = 35;
    }

    /// <summary>
    /// 4 (SHIFT+4) == Right Side Bar2
    /// </summary>
    public class ActionBar4
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button36 = 36;
        /// <summary>
        /// 
        /// </summary>
        public const int Button37 = 37;
        /// <summary>
        /// 
        /// </summary>
        public const int Button38 = 38;
        /// <summary>
        /// 
        /// </summary>
        public const int Button39 = 39;
        /// <summary>
        /// 
        /// </summary>
        public const int Button40 = 40;
        /// <summary>
        /// 
        /// </summary>
        public const int Button41 = 41;
        /// <summary>
        /// 
        /// </summary>
        public const int Button42 = 42;
        /// <summary>
        /// 
        /// </summary>
        public const int Button43 = 43;
        /// <summary>
        /// 
        /// </summary>
        public const int Button44 = 44;
        /// <summary>
        /// 
        /// </summary>
        public const int Button45 = 45;
        /// <summary>
        /// 
        /// </summary>
        public const int Button46 = 46;
        /// <summary>
        /// 
        /// </summary>
        public const int Button47 = 47;
    }

    /// <summary>
    /// 5 (SHIFT+5) == Bottom Right Bar
    /// </summary>
    public class ActionBar5
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button48 = 48;
        /// <summary>
        /// 
        /// </summary>
        public const int Button49 = 49;
        /// <summary>
        /// 
        /// </summary>
        public const int Button50 = 50;
        /// <summary>
        /// 
        /// </summary>
        public const int Button51 = 51;
        /// <summary>
        /// 
        /// </summary>
        public const int Button52 = 52;
        /// <summary>
        /// 
        /// </summary>
        public const int Button53 = 53;
        /// <summary>
        /// 
        /// </summary>
        public const int Button54 = 54;
        /// <summary>
        /// 
        /// </summary>
        public const int Button55 = 55;
        /// <summary>
        /// 
        /// </summary>
        public const int Button56 = 56;
        /// <summary>
        /// 
        /// </summary>
        public const int Button57 = 57;
        /// <summary>
        /// 
        /// </summary>
        public const int Button58 = 58;
        /// <summary>
        /// 
        /// </summary>
        public const int Button59 = 59;
    }

    /// <summary>
    /// 6 (SHIFT+6) == Bottom Left Bar
    /// </summary>
    public class ActionBar6
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button60 = 60;
        /// <summary>
        /// 
        /// </summary>
        public const int Button61 = 61;
        /// <summary>
        /// 
        /// </summary>
        public const int Button62 = 62;
        /// <summary>
        /// 
        /// </summary>
        public const int Button63 = 63;
        /// <summary>
        /// 
        /// </summary>
        public const int Button64 = 64;
        /// <summary>
        /// 
        /// </summary>
        public const int Button65 = 65;
        /// <summary>
        /// 
        /// </summary>
        public const int Button66 = 66;
        /// <summary>
        /// 
        /// </summary>
        public const int Button67 = 67;
        /// <summary>
        /// 
        /// </summary>
        public const int Button68 = 68;
        /// <summary>
        /// 
        /// </summary>
        public const int Button69 = 69;
        /// <summary>
        /// 
        /// </summary>
        public const int Button70 = 70;
        /// <summary>
        /// 
        /// </summary>
        public const int Button71 = 71;
    }

    /// <summary>
    /// 1 SpecialA
    /// </summary>
    public class ActionBarA
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button72 = 72;
        /// <summary>
        /// 
        /// </summary>
        public const int Button73 = 73;
        /// <summary>
        /// 
        /// </summary>
        public const int Button74 = 74;
        /// <summary>
        /// 
        /// </summary>
        public const int Button75 = 75;
        /// <summary>
        /// 
        /// </summary>
        public const int Button76 = 76;
        /// <summary>
        /// 
        /// </summary>
        public const int Button77 = 77;
        /// <summary>
        /// 
        /// </summary>
        public const int Button78 = 78;
        /// <summary>
        /// 
        /// </summary>
        public const int Button79 = 79;
        /// <summary>
        /// 
        /// </summary>
        public const int Button80 = 80;
        /// <summary>
        /// 
        /// </summary>
        public const int Button81 = 81;
        /// <summary>
        /// 
        /// </summary>
        public const int Button82 = 82;
        /// <summary>
        /// 
        /// </summary>
        public const int Button83 = 83;
    }

    /// <summary>
    /// 1 SpecialB
    /// </summary>
    public class ActionBarB
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button84 = 84;
        /// <summary>
        /// 
        /// </summary>
        public const int Button85 = 85;
        /// <summary>
        /// 
        /// </summary>
        public const int Button86 = 86;
        /// <summary>
        /// 
        /// </summary>
        public const int Button87 = 87;
        /// <summary>
        /// 
        /// </summary>
        public const int Button88 = 88;
        /// <summary>
        /// 
        /// </summary>
        public const int Button89 = 89;
        /// <summary>
        /// 
        /// </summary>
        public const int Button90 = 90;
        /// <summary>
        /// 
        /// </summary>
        public const int Button91 = 91;
        /// <summary>
        /// 
        /// </summary>
        public const int Button92 = 92;
        /// <summary>
        /// 
        /// </summary>
        public const int Button93 = 93;
        /// <summary>
        /// 
        /// </summary>
        public const int Button94 = 94;
        /// <summary>
        /// 
        /// </summary>
        public const int Button95 = 95;
    }

    /// <summary>
    /// 1 SpecialC
    /// </summary>
    public class ActionBarC
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button96 = 96;
        /// <summary>
        /// 
        /// </summary>
        public const int Button97 = 97;
        /// <summary>
        /// 
        /// </summary>
        public const int Button98 = 98;
        /// <summary>
        /// 
        /// </summary>
        public const int Button99 = 99;
        /// <summary>
        /// 
        /// </summary>
        public const int Button100 = 100;
        /// <summary>
        /// 
        /// </summary>
        public const int Button101 = 101;
        /// <summary>
        /// 
        /// </summary>
        public const int Button102 = 102;
        /// <summary>
        /// 
        /// </summary>
        public const int Button103 = 103;
        /// <summary>
        /// 
        /// </summary>
        public const int Button104 = 104;
        /// <summary>
        /// 
        /// </summary>
        public const int Button105 = 105;
        /// <summary>
        /// 
        /// </summary>
        public const int Button106 = 106;
        /// <summary>
        /// 
        /// </summary>
        public const int Button107 = 107;
    }

    /// <summary>
    /// 1 SpecialD
    /// </summary>
    public class ActionBarD
    {
        /// <summary>
        /// 
        /// </summary>
        public const int Button108 = 108;
        /// <summary>
        /// 
        /// </summary>
        public const int Button109 = 109;
        /// <summary>
        /// 
        /// </summary>
        public const int Button110 = 110;
        /// <summary>
        /// 
        /// </summary>
        public const int Button111 = 111;
        /// <summary>
        /// 
        /// </summary>
        public const int Button112 = 112;
        /// <summary>
        /// 
        /// </summary>
        public const int Button113 = 113;
        /// <summary>
        /// 
        /// </summary>
        public const int Button114 = 114;
        /// <summary>
        /// 
        /// </summary>
        public const int Button115 = 115;
        /// <summary>
        /// 
        /// </summary>
        public const int Button116 = 116;
        /// <summary>
        /// 
        /// </summary>
        public const int Button117 = 117;
        /// <summary>
        /// 
        /// </summary>
        public const int Button118 = 118;
        /// <summary>
        /// 
        /// </summary>
        public const int Button119 = 119;
    }
}
