#region zh-CHS °æÈ¨ËùÓÐ (C) 2006 - 2006 DemoSoft Corporation. ±£ÁôËùÓÐÈ¨Àû | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
// Program.cs : interface for the Program class.
//
// This file is a part of the Demo Toolkit for .NET.
// 2006-2006 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions 
// outlined in the accompanying license agreement.
//
// mailto:caihuanqing@hotmail.com

#region zh-CHS °üº¬Ãû×Ö¿Õ¼ä | en Include namespace
using System.IO;
using Demo_G.O.S.E.ServerEngine.Network;
using System;
using Demo_G.O.S.E.ServerEngine.Common;
using Demo_R.O.S.E.Mobile;
#endregion

namespace Demo_R.O.S.E.WorldServer.Network
{
    #region zh-CHS Unknown0x0702Ack Àà | en Unknown0x702Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0702Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0702Ack(string strMessage)
            : base( 0x702, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.WriteAsciiNull( strMessage );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
        }
    }
    #endregion

    #region zh-CHS Unknown0x070CAck Àà | en Unknown0x070CAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x070CAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x070CAck() : base( 0x70C, 15 /*6 + 9*/ )
        {
            WriterStream.Write( (ushort)15 /*6 + 9*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (sbyte)0x0 );
            WriterStream.Write( (uint)0x87654321 );
            WriterStream.Write( (uint)0x00000000 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x0721Ack Àà | en Unknown0x721Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0721Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0721Ack()
            : base( 0x721, 12 /*6 + 6*/ )
        {
            WriterStream.Write( (ushort)12 /*6 + 6*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)0x0022 );
            WriterStream.Write( (ushort)0x0002 );
            WriterStream.Write( (ushort)0x0000 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x0730Ack Àà | en Unknown0x730Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0730Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0730Ack()
            : base( 0x730, 12 /*6 + 6*/ )
        {
            WriterStream.Write( (ushort)12 /*6 + 6*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)0x0005 );
            WriterStream.Write( (uint)0x40B3A24D );
        }
    }
    #endregion

    #region zh-CHS Unknown0x0753Ack Àà | en Unknown0x753Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0753Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0753Ack( ROSEMobile character )
            : base( 0x753, 52 /*6 + 46*/ )
        {
            WriterStream.Write( (ushort)52 /*6 + 46*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );			// USER ID
            WriterStream.Write( (ushort)character.m_iCurrentHP );		    // CURRENT HP
            WriterStream.Write( (ushort)character.m_iCurrentMP );		    // CURRENT MP
            WriterStream.Write( (uint)character.m_iExperience );            // CURRENT EXP
            WriterStream.Write( (uint)0x00000000 );			                // LVL EXP (UNSUSED)

            //[economy] 
            WriterStream.Write( (ushort)0x0063 );  // World Rate

            WriterStream.Write( (byte)0x70 );
            WriterStream.Write( (byte)0x69 );
            WriterStream.Write( (byte)0x68 );
            WriterStream.Write( (byte)0x67 );

            WriterStream.Write( (ushort)0x0062 );  // Town rate

            WriterStream.Write( (byte)0x61 ); // misc rate
            WriterStream.Write( (byte)0x32 ); // 1
            WriterStream.Write( (byte)0x32 ); // 2
            WriterStream.Write( (byte)0x32 ); // 3
            WriterStream.Write( (byte)0x32 ); // 4
            WriterStream.Write( (byte)0x32 ); // 5
            WriterStream.Write( (byte)0x32 ); // 6
            WriterStream.Write( (byte)0x32 ); // 7
            WriterStream.Write( (byte)0x32 ); // 8
            WriterStream.Write( (byte)0x32 ); // 9
            WriterStream.Write( (byte)0x32 ); // 10
            WriterStream.Write( (byte)0x32 ); // 11

            if (character.m_posMapData.pvp == true)
                WriterStream.Write( (ushort)0x0001 ); // player vs player map
            else
                WriterStream.Write( (ushort)0x0000 ); // non player vs player map

            WriterStream.Write( (ushort)0x0000 ); // ?

            // This 3 are to the world time (night/day...)
            WriterStream.Write( (byte)character.m_iCurrentWorldTime );
            WriterStream.Write( (byte)0xDE );
            WriterStream.Write( (ushort)0x0008 ); // this change something in the mapicon (time)

            if ( character.m_posMapData.pvp == true )
            {
                WriterStream.Write( (ushort)0x0000 ); // red icon (map)
                WriterStream.Write( (ushort)0x0005 ); // red icon (map)
            }
            else
            {
                WriterStream.Write( (ushort)0x0002 ); // white icon (map)
                WriterStream.Write( (ushort)0x0000 ); // white icon (map)
            }
      }
    }
    #endregion

    #region zh-CHS Unknown0x0762Ack Àà | en Unknown0x762Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0762Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0762Ack( ROSEMobile character )
            : base( 0x762, 9 /*6 + 3*/ )
        {
            WriterStream.Write( (ushort)9 /*6 + 3*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );       // USER ID
            WriterStream.Write( (sbyte)0x01 );			                 // SOMETHING TO DO WITH WEIGHT
        }
    }
    #endregion

    #region zh-CHS Unknown0x0782Ack Àà | en Unknown0x782Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0782Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0782Ack( ROSEMobile character )
            : base( 0x782, 9 /*6 + 3*/ )
        {
            WriterStream.Write( (ushort)9 /*6 + 3*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (sbyte)character.m_iSense );
        }
    }
    #endregion

    #region zh-CHS Unknown0x0798Ack Àà | en Unknown0x0798Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x0798Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x0798Ack()
            : base( 0x798, 20 /*6 + 14*/ )
        {
            WriterStream.Write( (ushort)20 /*6 + 14*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            //WriterStream.Write( (ushort)0x00 );
            //WriterStream.Write( (ushort)0x00 );
            //WriterStream.Write( (ushort)0x00 );
            //WriterStream.Write( (float)0x00 );
            //WriterStream.Write( (float)0x00 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x079FAck Àà | en Unknown0x079FAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x079FAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x079FAck()
            : base( 0x79F, 12 /*6 + 6*/ )
        {
            WriterStream.Write( (ushort)12 /*6 + 6*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            //WriterStream.Write( (ushort)0x00 );
            //WriterStream.Write( (ushort)0x00 );
            //WriterStream.Write( (ushort)0x00 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x07D5Ack Àà | en Unknown0x721Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x07D5Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x07D5Ack( ROSEMobile character )
            : base( 0x7D5, 26 /*6 + 20*/ )
        {
            WriterStream.Write( (ushort)26 /*6 + 20*/ );    // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (uint)character.m_iCharacterGuid );
            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (ushort)character.m_iMaxHP );
            WriterStream.Write( (ushort)character.m_iCurrentHP );
            WriterStream.Write( (uint)0x01000000 );
            WriterStream.Write( (uint)0x0000000F );
            WriterStream.Write( (ushort)0x1388 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x07DEAck Àà | en Unknown0x07DEAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x07DEAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x07DEAck() : base( 0x07DE, 37 /*6 + 31*/ )
        {
            WriterStream.Write( (ushort)37 /*6 + 31*/ );    // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (uint)0x000C1003 );
            WriterStream.Write( (uint)0xFFFF0000 );
            WriterStream.Write( (uint)0x00000000 );
            WriterStream.Write( (uint)0x9B000038 );
            WriterStream.Write( (uint)0x7272656A );
            WriterStream.Write( (uint)0x3C3C3479 );
            WriterStream.Write( (uint)0x534D5547 );
            WriterStream.Write( (ushort)0x3E3E );
            WriterStream.Write( (sbyte)0x00 );
        }
    }
    #endregion

    #region zh-CHS Unknown0x07DFAck Àà | en Unknown0x07DFAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x07DFAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x07DFAck()
            : base( 0x7DF, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0xF1 );
            WriterStream.WriteAsciiNull( "H.Q.Cai Rose Online Private Server!" );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
        }
    }
    #endregion

    #region zh-CHS UserInformationAck Àà | en UserInformationAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class UserInformationAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal UserInformationAck( ROSEMobile character )
            : base( 0x715, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)character.m_iSex );				                // GENDER 1=FEMALE 0=MALE
            WriterStream.Write( (ushort)character.m_posMapID );                         // MAP
            WriterStream.Write( (float)( character.X* 100 ) );                       // X POS
            WriterStream.Write( (float)( character.Y * 100 ) );                       // Y POS
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (uint)character.m_iFace );			                    // FACE TYPE
            WriterStream.Write( (uint)character.m_iHairStyle );		                    // HAIR TYPE

            WriterStream.Write( (ushort)character.m_Items[2].m_iItemID );	            // CAP
            WriterStream.Write( (ushort)character.m_Items[2].BuildItemRefine() );	    // CAP REFINE
            WriterStream.Write( (ushort)character.m_Items[3].m_iItemID );	            // BODY
            WriterStream.Write( (ushort)character.m_Items[3].BuildItemRefine() );	    // BODY REFINE
            WriterStream.Write( (ushort)character.m_Items[5].m_iItemID );	            // GLOVES
            WriterStream.Write( (ushort)character.m_Items[5].BuildItemRefine() );	    // GLOVES REFINE
            WriterStream.Write( (ushort)character.m_Items[6].m_iItemID );	            // BOOTS
            WriterStream.Write( (ushort)character.m_Items[6].BuildItemRefine() );	    // BOOTS REFINE
            WriterStream.Write( (ushort)character.m_Items[1].m_iItemID );	            // FACE
            WriterStream.Write( (ushort)character.m_Items[1].BuildItemRefine() );	    // FACE REFINE
            WriterStream.Write( (ushort)character.m_Items[4].m_iItemID );	            // BACK
            WriterStream.Write( (ushort)character.m_Items[4].BuildItemRefine() );	    // BACK REFINE 
            WriterStream.Write( (ushort)character.m_Items[7].m_iItemID );	            // WEAPON
            WriterStream.Write( (ushort)character.m_Items[7].BuildItemRefine() );	    // WEAPON REFINE 
            WriterStream.Write( (ushort)character.m_Items[8].m_iItemID );	            // SUBWEAPON
            WriterStream.Write( (ushort)character.m_Items[8].BuildItemRefine() );	    // SUBWEAPON REFINE

            WriterStream.Write( (byte)0x0 );
            WriterStream.Write( (ushort)0x140F );
            WriterStream.Write( (ushort)character.m_iClassID );                         //JOB
            WriterStream.Write( (byte)0x0 );
            WriterStream.Write( (ushort)0x0 );
            WriterStream.Write( (ushort)character.m_iStrength );				        // STR
            WriterStream.Write( (ushort)character.m_iDexterity );				        // DEX
            WriterStream.Write( (ushort)character.m_iIntellect );				        // INT
            WriterStream.Write( (ushort)character.m_iConvergence );				        // CON
            WriterStream.Write( (ushort)character.m_iCharm );				            // CHA
            WriterStream.Write( (ushort)character.m_iSense );				            // SEN
            WriterStream.Write( (ushort)character.m_iCurrentHP );                       // HP
            WriterStream.Write( (ushort)character.m_iCurrentMP );                       // MP
            WriterStream.Write( (ushort)character.m_iExperience );                      // EXP
            WriterStream.Write( (ushort)0x0);
            WriterStream.Write( (ushort)character.m_iLevel );                           // LEVEL
            WriterStream.Write( (ushort)character.m_iStatusPoint );                     // STAT POINTS 
            WriterStream.Write( (ushort)character.m_iSkillPoint );                      // SKILL POINTS 
            WriterStream.Write( (ushort)0x6464 );

            for ( int iIndex = 0; iIndex < 37; iIndex++ )
                WriterStream.Write( (byte)0x0 );                                       // UNKNOWN

            WriterStream.Write( (ushort)character.m_iStamina );                         // STAMINA

            for ( int iIndex = 0; iIndex < 326; iIndex++ )
                WriterStream.Write( (byte)0x0 );                                       // UNKNOWN

            for ( int iIndex = 0; iIndex < 60; iIndex++ )
                WriterStream.Write( (ushort)0 );    // CLASS SKILLS
                //WriterStream.Write( (ushort)character.m_iClassSkills[iIndex].m_iClassSkillID + character.m_iClassSkills[iIndex].m_iLevel - 1 );    // CLASS SKILLS

            for ( int iIndex = 0; iIndex < 260; iIndex++ )
                WriterStream.Write( (ushort)0x0 );                                      // UNKNOWN

            for ( int iIndex = 0; iIndex < 42; iIndex++ )
                WriterStream.Write( (ushort)character.m_iBasicSkills[iIndex] );         // BASIC SKILLS

            for ( int iIndex = 0; iIndex < 48; iIndex++ )
                WriterStream.Write( (ushort)character.m_iQuickBar[iIndex] );            // QUICKBAR

            WriterStream.Write( (uint)character.m_iCharacterGuid );                     // CHARACTER GUID

            for ( int iIndex = 0; iIndex < 80; iIndex++ )
                WriterStream.Write( (byte)0x0 );                                       // UNKNOWN

            WriterStream.WriteAsciiNull( character.m_strCharacter );                    // CHARACTER NAME


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
      }
    }
    #endregion

    #region zh-CHS UserInventoryDataAck Àà | en UserInventoryDataAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class UserInventoryDataAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal UserInventoryDataAck( ROSEMobile character )
            : base( 0x716, 1126/*6 + 1120*/ )
        {
            WriterStream.Write( (ushort)1126/*6 + 1120*/ );    // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////

            // low Zulies
            WriterStream.Write( (uint)0x00 );
            // High Zulies
            WriterStream.Write( (uint)0x00 );

            for ( int iIndex = 0; iIndex < 140; iIndex++ )
            {
                WriterStream.Write( (uint)character.m_Items[iIndex].BuildItemHead() );
                WriterStream.Write( (uint)character.m_Items[iIndex].BuildItemData() );
            }
        }
    }
    #endregion

    #region zh-CHS UserQuestDataAck Àà | en UserQuestDataAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class UserQuestDataAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal UserQuestDataAck( ROSEMobile character )
            : base( 0x71B, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );          // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );        // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );                 // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            for ( int iIndex = 0; iIndex < 0x32; iIndex++ )
                WriterStream.Write( (byte)0x0 );

            int l_iActiveQuestCount = 0;
            //for ( int iIndex = 0; iIndex < thisclient->MyQuest.size( ); iIndex++ )
            //{
                //if ( myquest->active )
                //{
                    //    WriterStream.Write( (ushort)0x0 );  // # Quest ID

                    //    WriterStream.Write( (uint)0x0 );    // Time
                    //    WriterStream.Write( (uint)0x0 );

                    //    for ( int iIndex2 = 0; iIndex2 < 0x14; iIndex2++ )
                    //        WriterStream.Write( (byte)0x0 );

                    //    for ( int iIndex3 = 0; iIndex3 < 5; iIndex3++ )
                    //    {
                    //        //if ( myquest->thisquest->CItem[j] != 0 && myquest->items[j] != 0 )
                    //        //{
                    //        //    CItem item;
                    //        //    item.itemnum = myquest->thisquest->CItem[j];
                    //        //    item.itemtype = 13;
                    //        //    item.count = 1;
                    //        //    WriterStream.Write( (uint)BuildItemHead( item ) );
                    //        //    WriterStream.Write( (uint)myquest->items[j] );
                    //        //}
                    //        //else
                    //        {
                    //            WriterStream.Write( (uint)0x00000000 );
                    //            WriterStream.Write( (uint)0x00000000 );
                    //        }


                    //    }

                    //    WriterStream.Write( (uint)0x00000000 );
                    //    WriterStream.Write( (uint)0x00000000 );
                    //    l_iActiveQuestCount++;
                //}

            //    if ( l_iActiveQuestCount >= 10 )
            //        break;
            //}

            for ( int iIndex = l_iActiveQuestCount; iIndex < 10; iIndex++ )
                for ( int iIndex2 = 0; iIndex2 < 0x4E; iIndex2++ )
                    WriterStream.Write( (byte)0x00 );

            // Made Quest?
            for ( int iIndex = 0; iIndex < 84; iIndex++ )
                WriterStream.Write( (byte)0x00 );

            // Whish list Credits to Caali
            for ( int iIndex = 0; iIndex < 30; iIndex++ )
            {
                WriterStream.Write( (uint)0x00000000 );     //Item Head
                WriterStream.Write( (uint)0x00000000 );     //Item Data
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
        }
    }
    #endregion


    #region zh-CHS SpawnMonsterAck Àà | en SpawnMonsterAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnMonsterAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public int BuildBuffs( ROSEMobile character )
        {
            byte buff1 = 0;
            byte buff2 = 0;
            byte buff3 = 0;
            byte buff4 = 0;

            // Build Debuffs and Buffs

            // Up
            if ( character.Attack_up != 0xff )      //A_ATTACK:
                buff2 += character.ATTACK_UP;
            if ( character.Defense_up != 0xff )     //A_DEFENSE:
                buff2 += character.DEFENSE_UP;
            if ( character.Accury_up != 0xff )      //A_ACCUR:
                buff3 += character.HITRATE_UP;
            if ( character.Dash_up != 0xff )        //A_DASH:   
                buff1 += character.DASH_UP;
            if ( character.Haste_up != 0xff )       //A_HASTE:
                buff2 += character.HASTE_UP;
            if ( character.HP_up != 0xff )          //A_HP:
                buff1 += character.HP_UP;
            if ( character.MP_up != 0xff )          //A_MP:
                buff1 += character.MP_UP;
            if ( character.Critical_up != 0xff )    //A_CRITICAL:
                buff1 += character.CRITICAL_UP;
            if ( character.Dodge_up != 0xff )       //A_DODGE:
                buff1 += character.DODGE_UP;

            // Down
            if ( character.Attack_down != 0xff )    // A_ATTACK:
                buff2 += character.ATTACK_DOWN;
            if ( character.Defense_down != 0xff )   //A_DEFENSE:
                buff2 += character.DEFENSE_DOWN;
            if ( character.Accury_down != 0xff )    //A_ACCUR:
                buff3 += character.HITRATE_DOWN;
            if ( character.Dash_down != 0xff )      //A_DASH:   
                buff1 += character.DASH_DOWN;
            if ( character.Haste_down != 0xff )     //A_HASTE:
                buff2 += character.HASTE_DOWN;
            if ( character.HP_down != 0xff )        //A_HP:
                buff1 += 0;
            if ( character.MP_down != 0xff )        //A_MP:
                buff1 += 0;
            if ( character.Critical_down != 0xff )  //A_CRITICAL:
                buff1 += character.CRITICAL_DOWN;
            if ( character.owner != 0 )
                buff3 += character.SUMMON;

            return ( buff1 * 0x01 ) + ( buff2 * 0x100 ) + ( buff3 * 0x10000 ) + ( buff4 * 0x1000000 );
        }

        /// <summary>
        /// 
        /// </summary>
        public SpawnMonsterAck( ROSEMobile character )
            : base( 0x792, 45 /*6 + 39*/ )
        {
            WriterStream.Write( (ushort)45 /*6 + 39*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (float)character.X * 100 );
            WriterStream.Write( (float)character.Y * 100 );
            WriterStream.Write( (float)character.m_DestinePoint3D.X * 100 );
            WriterStream.Write( (float)character.m_DestinePoint3D.Y * 100 );

            if ( character.Hits <= 0 )
            {
                WriterStream.Write( (ushort)0x0003 );
                WriterStream.Write( (ushort)0x0000 );
            }
            else if ( character.targetid != 0 )
            {
                WriterStream.Write( (ushort)0x0002 );
                WriterStream.Write( (ushort)character.targetid );
            }
            else if ( character.X != character.m_DestinePoint3D.X || character.Y != character.m_DestinePoint3D.Y )
            {
                WriterStream.Write( (ushort)0x0001 );
                WriterStream.Write( (ushort)0x0000 );
            }
            else
            {
                WriterStream.Write( (ushort)0x0000 );
                WriterStream.Write( (ushort)0x0000 );
            }

            WriterStream.Write( (sbyte)0x00 );
            WriterStream.Write( (uint)character.Hits );

            if ( character.owner == 0 && character.m_posMapData.pvp )
                WriterStream.Write( (uint)0x00000064 ); // Hostil µÐ¶Ô
            else
                WriterStream.Write( (uint)0x00000000 ); // Friendly ÅóÓÑ

            WriterStream.Write( (uint)BuildBuffs( character ) );

            WriterStream.Write( (ushort)character.montype );
            WriterStream.Write( (ushort)0x0000 );

            if ( character.owner != 0 )
            {
                WriterStream.Write( (ushort)character.owner );
                WriterStream.Write( (ushort)0x0000 ); //id del skill (si es summon de skill)
            }
        }
    }
    #endregion

    #region zh-CHS SpawnNPCAck Àà | en SpawnNPCAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnNPCAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public SpawnNPCAck( ROSEMobile character )
            : base( 0x791, 51 /*6 + 45*/ )
        {
            WriterStream.Write( (ushort)51 /*6 + 45*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (float)character.X * 100 );
            WriterStream.Write( (float)character.Y * 100 );
            WriterStream.Write( (float)character.X * 100 );
            WriterStream.Write( (float)character.Y * 100 );
            WriterStream.Write( (sbyte)0x00 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x03E8 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0001 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)character.npctype );

            if ( character.dialogid != 0)
                WriterStream.Write( (ushort)character.dialogid );
            else
                WriterStream.Write( (ushort)character.npctype - 900 );

            WriterStream.Write( (float)character.Direction );

            WriterStream.Write( (ushort)0x0000 );
        }
    }
    #endregion




    #region zh-CHS MoveCharAck Àà | en MoveCharAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class MoveCharAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public MoveCharAck( ROSEMobile character )
            : base( 0x079A, 22 /*6 + 16*/)
        {
            WriterStream.Write( (ushort)22 /*6 + 16*/ );    // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)character.m_iClientID );    // USER ID
            WriterStream.Write( (ushort)character.targetid );		// TARGET
            WriterStream.Write( (ushort)character.mspeed );	        // MSPEED
            WriterStream.Write( (float)( character.X * 100 ) );	    // POSITION X
            WriterStream.Write( (float)( character.Y * 100 ) );	    // POSITION Y
            WriterStream.Write( (ushort)0x0000 );		            // POSITION Z (NOT USED)
        }
    }
    #endregion

    #region zh-CHS ExitAck Àà | en ExitAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ExitAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ExitAck( ushort iSeconds )
            : base( 0x707, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////
            

            WriterStream.Write( (ushort)iSeconds );
        }
    }
    #endregion

    #region zh-CHS SpawnDropAck Àà | en SpawnDropAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnDropAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public SpawnDropAck()
            : base( 0x7A6, 0 )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            //WriterStream.Write( (float)0x0 );
            //WriterStream.Write( (float)0x0 );

            // -- ZULY --
            WriterStream.Write( (uint)0xCCCCCCDF );
            //WriterStream.Write( (uint)0x00000000 );
            //WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x5F90 );

            // -- ITEM --
            //WriterStream.Write( (uint)0x00000000 );
            //WriterStream.Write( (uint)0x00000000 );
            //WriterStream.Write( (ushort)0x0000 );
            //WriterStream.Write( (uint)0x00000000 );
        }
    }
    #endregion

    #region zh-CHS ClearObjectAck Àà | en ClearObjectAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClearObjectAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ClearObjectAck()
            : base( 0x794, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            //WriterStream.Write( (ushort)0x0 );
        }
    }
    #endregion

    #region zh-CHS ClearUserAck Àà | en ClearUserAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClearUserAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ClearUserAck()
            : base( 0x794, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            //WriterStream.Write( (ushort)0x0 );
        }
    }
    #endregion




    #region zh-CHS CSReadyAck Àà | en CSReadyAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class CSReadyAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CSReadyAck()
            : base( 0x0, 0 )
        {
        }
    }
    #endregion

    #region zh-CHS CSCharSelectAck Àà | en CSCharSelectAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class CSCharSelectAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CSCharSelectAck()
            : base( 0x0, 0 )
        {
        }
    }
    #endregion

    #region zh-CHS CharSelectAck Àà | en CharSelectAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class CharSelectAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CharSelectAck()
            : base( 0x505, 10 /*6 + 4*/  )
        {
            WriterStream.Write( (ushort)10 /*6 + 4*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (uint)0x0 );
        }
    }
    #endregion

    #region zh-CHS PingAck Àà | en PingAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class PingAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public PingAck( ushort iPing )
            : base( 0x0700, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)10 /*6 + 2*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)iPing );
        }
    }
    #endregion

    #region zh-CHS UserDiedAck Àà | en UserDiedAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserDiedAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public UserDiedAck( ROSEMobile character )
            : base( 0x07A8, 58 /*6 + 52 */)
        {
            WriterStream.Write( (ushort)58 /*6 + 52*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (ushort)character.m_posMapID );
            WriterStream.Write( (float)character.X * 100 );
            WriterStream.Write( (float)character.Y * 100 );

            if ( character.m_stance == 0x04 )
                WriterStream.Write( (ushort)0x0201 );
            else
                WriterStream.Write( (ushort)0x0001 );

            for ( int iIndex = 0; iIndex < 15; iIndex++ )
            {
                // Clean Buffs	   
            }
        }
    }
    #endregion

    #region zh-CHS WeightAck Àà | en UserDiedAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class WeightAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public WeightAck( ROSEMobile character, long iWeight )
            : base( 0x0762, 9 /*6 + 3 */)
        {
            WriterStream.Write( (ushort)9 /*6 + 3*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (byte)iWeight );
        }
    }
    #endregion

    #region zh-CHS StopCharAck Àà | en StopCharAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class StopCharAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public StopCharAck( ROSEMobile character )
            : base( 0x0770, 18 /*6 + 12*/ )
        {
            WriterStream.Write( (ushort)18 /*6 + 12*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)character.m_iClientID );    // USER ID
            WriterStream.Write( (float)( character.X * 100 ) );	    // POSITION X
            WriterStream.Write( (float)( character.Y * 100 ) );	    // POSITION Y
            WriterStream.Write( (ushort)0x0000 );		            // POSITION Z (NOT USED)
        }
    }
    #endregion

    #region zh-CHS DoEmoteAck Àà | en DoEmoteAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class DoEmoteAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public DoEmoteAck( ushort iUshort1, ushort iUshort2, ROSEMobile character )
            : base( 0x781, 12 /*6 + 6*/ )
        {
            WriterStream.Write( (ushort)12 /*6 + 6*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)iUshort1 );
            WriterStream.Write( (ushort)iUshort2 );
            WriterStream.Write( (ushort)character.m_iClientID );
        }
    }
    #endregion

    #region zh-CHS ChangeStanceAck Àà | en ChangeStanceAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChangeStanceAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ChangeStanceAck( ROSEMobile character )
            : base( 0x782, 9 /*6 + 3*/ )
        {
            WriterStream.Write( (ushort)9 /*6 + 3*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.Write( (byte)character.m_stance );
            WriterStream.Write( (ushort)character.mspeed );
        }
    }
    #endregion

    #region zh-CHS NormalChatAck Àà | en NormalChatAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class NormalChatAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public NormalChatAck( ROSEMobile character, string strMessage )
            : base( 0x783, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (ushort)character.m_iClientID );
            WriterStream.WriteAsciiNull( strMessage ); 
        }
    }
    #endregion

    #region zh-CHS WhisperAck Àà | en WhisperAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class WhisperAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public WhisperAck( ROSEMobile character, string strMessage )
            : base( 0x0784, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.WriteAsciiNull( character.m_strCharacter );
            WriterStream.WriteAsciiNull( strMessage );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
        }
    }
    #endregion

    #region zh-CHS ShoutAck Àà | en ShoutAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ShoutAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ShoutAck( ROSEMobile character, string strMessage )
            : base( 0x0785, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.WriteAsciiNull( character.m_strCharacter );
            WriterStream.WriteAsciiNull( strMessage );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );     // ×Ö¶Î´óÐ¡
        }
    }
    #endregion

    #region zh-CHS StartAttackAck Àà | en StartAttackAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class StartAttackAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public StartAttackAck()
            : base( 0x0, 6 + 36 )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
        }
    }
    #endregion

    #region zh-CHS NPCBuyAck Àà | en NPCBuyAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class NPCBuyAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public NPCBuyAck()
            : base( 0x717, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS DoDropAck Àà | en DoDropAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class DoDropAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public DoDropAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS ChangeEquipAck Àà | en ChangeEquipAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChangeEquipAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ChangeEquipAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS PickDropAck Àà | en PickDropAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class PickDropAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public PickDropAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS GateAck Àà | en GateAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class GateAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public GateAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS AddStatsAck Àà | en AddStatsAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class AddStatsAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public AddStatsAck()
            : base( 0x7A9, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS MoveSkillAck Àà | en MoveSkillAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class MoveSkillAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public MoveSkillAck()
            : base( 0x7AA, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS StartSkillAck Àà | en StartSkillAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class StartSkillAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public StartSkillAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS TradeActionAck Àà | en TradeActionAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class TradeActionAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public TradeActionAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS TradeAddAck Àà | en TradeAddAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class TradeAddAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public TradeAddAck()
            : base( 0x7C1, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS ChangeCartAck Àà | en ChangeCartAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChangeCartAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ChangeCartAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS PartyAck Àà | en PartyAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class PartyAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public PartyAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS PartyOptAck Àà | en PartyOptAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class PartyOptAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public PartyOptAck()
            : base( 0x7D7, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS GameGuardAck Àà | en GameGuardAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameGuardAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public GameGuardAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
        }
    }
    #endregion

    #region zh-CHS EquipArrowsAck Àà | en EquipArrowsAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class EquipArrowsAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public EquipArrowsAck()
            : base( 0x7AB, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS CraftAck Àà | en CraftAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class CraftAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CraftAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS AfterCraftAck Àà | en AfterCraftAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class AfterCraftAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public AfterCraftAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS ConsumeAck Àà | en ConsumeAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ConsumeAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ConsumeAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS DrillAck Àà | en DrillAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class DrillAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public DrillAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS RepairAck Àà | en RepairAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class RepairAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public RepairAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS ShopAck Àà | en ShopAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class ShopAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public ShopAck()
            : base( 0x0, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS CloseShopAck Àà | en CloseShopAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class CloseShopAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CloseShopAck()
            : base( 0x7C3, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS IncreaseSkillLvlAck Àà | en IncreaseSkillLvlAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class IncreaseSkillLvlAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public IncreaseSkillLvlAck()
            : base( 0x07B1, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS BuffAck Àà | en BuffAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class BuffAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public BuffAck()
            : base( 0x7B2, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS QuestAck Àà | en QuestAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class QuestAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public QuestAck( long iAction, long iQuestPart, long iQuestId )
            : base( 0x730, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (byte)iAction );
            WriterStream.Write( (byte)iQuestPart );
            WriterStream.Write( (uint)iQuestId );
        }
    }
    #endregion

    #region zh-CHS OpenStorageAck Àà | en OpenStorageAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class OpenStorageAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenStorageAck()
            : base( 0x730, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS StorageItemAck Àà | en StorageItemAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageItemAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public StorageItemAck()
            : base( 0x730, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion

    #region zh-CHS StorageZulyAck Àà | en StorageZulyAck Class
    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageZulyAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public StorageZulyAck()
            : base( 0x730, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

        }
    }
    #endregion
}
#endregion