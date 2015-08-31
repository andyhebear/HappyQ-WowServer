using System;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Util;

namespace Demo.Wow.WorldServer.Entity.Common
{
    /// <summary>
    /// Similar to an UpdateMask, it filters out the bits only needed for the player
    /// </summary>
    public static class VisibilityManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_PlayerFieldCount = Utility.GetMaxEnumValue<PlayerFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        private static uint[] m_PlayerVisibility = new uint[( s_PlayerFieldCount.RawId / 32 ) + 1];

        /// <summary>
        /// 
        /// </summary>
        public const int HIGHEST_PUBLIC_FIELD = 615;

        static VisibilityManager()
        {
            SetPublicField( 0, 2 ); // GUID
            SetPublicField( 2, 1 ); // TYPE
            SetPublicField( 3, 1 ); // ENTRY
            SetPublicField( 4, 1 ); // SCALE_X

            SetPublicField( 6, 2 ); // _CHARM
            SetPublicField( 8, 2 ); // _SUMMON
            SetPublicField( 10, 2 ); // _CHARMEDBY
            SetPublicField( 12, 2 ); // _SUMMONEDBY
            SetPublicField( 14, 2 ); // _CREATEDBY
            SetPublicField( 16, 2 ); // _TARGET
            SetPublicField( 18, 2 ); // _PERSUADED
            SetPublicField( 20, 2 ); // _CHANNEL_OBJECT
            SetPublicField( 23, 1 ); // _POWER1
            SetPublicField( 24, 1 ); // _POWER2
            SetPublicField( 25, 1 ); // _POWER3
            SetPublicField( 26, 1 ); // _POWER4
            SetPublicField( 27, 1 ); // _POWER5
            SetPublicField( 29, 1 ); // _MAXPOWER1
            SetPublicField( 30, 1 ); // _MAXPOWER2
            SetPublicField( 31, 1 ); // _MAXPOWER3
            SetPublicField( 32, 1 ); // _MAXPOWER4
            SetPublicField( 33, 1 ); // _MAXPOWER5
            SetPublicField( 34, 1 ); // _LEVEL
            SetPublicField( 35, 1 ); // _FACTIONTEMPLATE
            SetPublicField( 36, 1 ); // _BYTES_0
            SetPublicField( 37, 3 ); // UNIT_VIRTUAL_ITEM_SLOT_DISPLAY
            SetPublicField( 40, 6 ); // UNIT_VIRTUAL_ITEM_INFO
            SetPublicField( 46, 1 ); // _FLAGS
            SetPublicField( 47, 1 ); // _FLAGS_2
            SetPublicField( 48, 56 ); // _AURA
            SetPublicField( 104, 7 ); // _AURAFLAGS
            SetPublicField( 111, 14 ); // _AURALEVELS
            SetPublicField( 125, 14 ); // _AURAAPPLICATIONS
            SetPublicField( 139, 1 ); // _AURASTATE
            SetPublicField( 140, 2 ); // _BASEATTACKTIME
            SetPublicField( 143, 1 ); // _BOUNDINGRADIUS
            SetPublicField( 144, 1 ); // _COMBATREACH
            SetPublicField( 145, 1 ); // _DISPLAYID
            SetPublicField( 146, 1 ); // _NATIVEDISPLAYID
            SetPublicField( 147, 1 ); // _MOUNTDISPLAYID
            SetPublicField( 152, 1 ); // _BYTES_1
            SetPublicField( 153, 1 ); // _PETNUMBER
            SetPublicField( 154, 1 ); // _PET_NAME_TIMESTAMP
            SetPublicField( 158, 1 ); // UNIT_CHANNEL_SPELL
            SetPublicField( 159, 1 ); // UNIT_MOD_CAST_SPEED
            SetPublicField( 160, 1 ); // UNIT_CREATED_BY_SPELL
            SetPublicField( 161, 1 ); // UNIT_NPC_FLAGS
            SetPublicField( 162, 1 ); // UNIT_NPC_EMOTESTATE
            SetPublicField( 202, 1 ); // _BYTES_2

            SetPublicField( 226, 2 ); // DUEL_ARBITER
            SetPublicField( 228, 1 ); // FLAGS
            SetPublicField( 229, 1 ); // GUILDID
            SetPublicField( 230, 1 ); // GUILDRANK
            SetPublicField( 231, 1 ); // BYTES
            SetPublicField( 232, 1 ); // BYTES_2
            SetPublicField( 233, 1 ); // BYTES_3
            SetPublicField( 234, 1 ); // DUEL_TEAM
            SetPublicField( 235, 1 ); // GUILD_TIMESTAMP
            SetPublicField( 311, 2 ); // VISIBLE_ITEM_1_CREATOR
            SetPublicField( 313, 12 ); // VISIBLE_ITEM_1_0
            SetPublicField( 325, 1 ); // VISIBLE_ITEM_1_PROPERTIES
            SetPublicField( 326, 1 ); // VISIBLE_ITEM_1_PAD
            SetPublicField( 327, 2 ); // VISIBLE_ITEM_2_CREATOR
            SetPublicField( 329, 12 ); // VISIBLE_ITEM_2_0
            SetPublicField( 341, 1 ); // VISIBLE_ITEM_2_PROPERTIES
            SetPublicField( 342, 1 ); // VISIBLE_ITEM_2_PAD
            SetPublicField( 343, 2 ); // VISIBLE_ITEM_3_CREATOR
            SetPublicField( 345, 12 ); // VISIBLE_ITEM_3_0
            SetPublicField( 357, 1 ); // VISIBLE_ITEM_3_PROPERTIES
            SetPublicField( 358, 1 ); // VISIBLE_ITEM_3_PAD
            SetPublicField( 359, 2 ); // VISIBLE_ITEM_4_CREATOR
            SetPublicField( 361, 12 ); // VISIBLE_ITEM_4_0
            SetPublicField( 373, 1 ); // VISIBLE_ITEM_4_PROPERTIES
            SetPublicField( 374, 1 ); // VISIBLE_ITEM_4_PAD
            SetPublicField( 375, 2 ); // VISIBLE_ITEM_5_CREATOR
            SetPublicField( 377, 12 ); // VISIBLE_ITEM_5_0
            SetPublicField( 389, 1 ); // VISIBLE_ITEM_5_PROPERTIES
            SetPublicField( 390, 1 ); // VISIBLE_ITEM_5_PAD
            SetPublicField( 391, 2 ); // VISIBLE_ITEM_6_CREATOR
            SetPublicField( 393, 12 ); // VISIBLE_ITEM_6_0
            SetPublicField( 405, 1 ); // VISIBLE_ITEM_6_PROPERTIES
            SetPublicField( 406, 1 ); // VISIBLE_ITEM_6_PAD
            SetPublicField( 407, 2 ); // VISIBLE_ITEM_7_CREATOR
            SetPublicField( 409, 12 ); // VISIBLE_ITEM_7_0
            SetPublicField( 421, 1 ); // VISIBLE_ITEM_7_PROPERTIES
            SetPublicField( 422, 1 ); // VISIBLE_ITEM_7_PAD
            SetPublicField( 423, 2 ); // VISIBLE_ITEM_8_CREATOR
            SetPublicField( 425, 12 ); // VISIBLE_ITEM_8_0
            SetPublicField( 437, 1 ); // VISIBLE_ITEM_8_PROPERTIES
            SetPublicField( 438, 1 ); // VISIBLE_ITEM_8_PAD
            SetPublicField( 439, 2 ); // VISIBLE_ITEM_9_CREATOR
            SetPublicField( 441, 12 ); // VISIBLE_ITEM_9_0
            SetPublicField( 453, 1 ); // VISIBLE_ITEM_9_PROPERTIES
            SetPublicField( 454, 1 ); // VISIBLE_ITEM_9_PAD
            SetPublicField( 455, 2 ); // VISIBLE_ITEM_10_CREATOR
            SetPublicField( 457, 12 ); // VISIBLE_ITEM_10_0
            SetPublicField( 469, 1 ); // VISIBLE_ITEM_10_PROPERTIES
            SetPublicField( 470, 1 ); // VISIBLE_ITEM_10_PAD
            SetPublicField( 471, 2 ); // VISIBLE_ITEM_11_CREATOR
            SetPublicField( 473, 12 ); // VISIBLE_ITEM_11_0
            SetPublicField( 485, 1 ); // VISIBLE_ITEM_11_PROPERTIES
            SetPublicField( 486, 1 ); // VISIBLE_ITEM_11_PAD
            SetPublicField( 487, 2 ); // VISIBLE_ITEM_12_CREATOR
            SetPublicField( 489, 12 ); // VISIBLE_ITEM_12_0
            SetPublicField( 501, 1 ); // VISIBLE_ITEM_12_PROPERTIES
            SetPublicField( 502, 1 ); // VISIBLE_ITEM_12_PAD
            SetPublicField( 503, 2 ); // VISIBLE_ITEM_13_CREATOR
            SetPublicField( 505, 12 ); // VISIBLE_ITEM_13_0
            SetPublicField( 517, 1 ); // VISIBLE_ITEM_13_PROPERTIES
            SetPublicField( 518, 1 ); // VISIBLE_ITEM_13_PAD
            SetPublicField( 519, 2 ); // VISIBLE_ITEM_14_CREATOR
            SetPublicField( 521, 12 ); // VISIBLE_ITEM_14_0
            SetPublicField( 533, 1 ); // VISIBLE_ITEM_14_PROPERTIES
            SetPublicField( 534, 1 ); // VISIBLE_ITEM_14_PAD
            SetPublicField( 535, 2 ); // VISIBLE_ITEM_15_CREATOR
            SetPublicField( 537, 12 ); // VISIBLE_ITEM_15_0
            SetPublicField( 549, 1 ); // VISIBLE_ITEM_15_PROPERTIES
            SetPublicField( 550, 1 ); // VISIBLE_ITEM_15_PAD
            SetPublicField( 551, 2 ); // VISIBLE_ITEM_16_CREATOR
            SetPublicField( 553, 12 ); // VISIBLE_ITEM_16_0
            SetPublicField( 565, 1 ); // VISIBLE_ITEM_16_PROPERTIES
            SetPublicField( 566, 1 ); // VISIBLE_ITEM_16_PAD
            SetPublicField( 567, 2 ); // VISIBLE_ITEM_17_CREATOR
            SetPublicField( 569, 12 ); // VISIBLE_ITEM_17_0
            SetPublicField( 581, 1 ); // VISIBLE_ITEM_17_PROPERTIES
            SetPublicField( 582, 1 ); // VISIBLE_ITEM_17_PAD
            SetPublicField( 583, 2 ); // VISIBLE_ITEM_18_CREATOR
            SetPublicField( 585, 12 ); // VISIBLE_ITEM_18_0
            SetPublicField( 597, 1 ); // VISIBLE_ITEM_18_PROPERTIES
            SetPublicField( 598, 1 ); // VISIBLE_ITEM_18_PAD
            SetPublicField( 599, 2 ); // VISIBLE_ITEM_19_CREATOR
            SetPublicField( 601, 12 ); // VISIBLE_ITEM_19_0
            SetPublicField( 613, 1 ); // VISIBLE_ITEM_19_PROPERTIES
            SetPublicField( 614, 1 ); // VISIBLE_ITEM_19_PAD
            SetPublicField( 615, 1 ); // CHOSEN_TITLE
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool IsPublicField( int iIndex )
        {
            return ( m_PlayerVisibility[iIndex >> 5] & ( 1 << ( iIndex & 31 ) ) ) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public static void SetPublicField( uint iIndex )
        {
            m_PlayerVisibility[iIndex >> 5] |= (uint)( 1 << ( (int)iIndex & 31 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        private static void SetPublicField( uint uiIndex, int iSize )
        {
            for ( uint iIndex = uiIndex; iIndex < ( uiIndex + iSize ); iIndex++ )
                SetPublicField( iIndex );
        }

        /// <summary>
        /// Modifies the specified UpdateMask to filter out all the bits not needed for other players
        /// </summary>
        /// <param name="mask">The UpdateMask to filter</param>
        public static void ModifyUpdateMask( ref UpdateMask updateMask )
        {
            for ( int iIndex = 0; iIndex < updateMask.BlockCount; iIndex++ )
                updateMask.Blocks[iIndex] &= m_PlayerVisibility[iIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="lowestValue"></param>
        /// <param name="highestValue"></param>
        public static void ModifyUpdateMask( UpdateMask updateMask, int iLowestValue, int iHighestValue )
        {
            int iBlockCount = ( iHighestValue + 31 ) >> 5;
            int iStartingBlock = ( iLowestValue ) >> 5;

            for ( int iIndex = iStartingBlock; iIndex < iBlockCount; iIndex++ )
                updateMask.Blocks[iIndex] &= m_PlayerVisibility[iIndex];
        }
    }
}
