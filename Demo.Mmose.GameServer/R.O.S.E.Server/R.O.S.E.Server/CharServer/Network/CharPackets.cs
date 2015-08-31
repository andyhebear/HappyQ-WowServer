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
using System.Net;
using System.Collections.Generic;
using Demo_G.O.S.E.ServerEngine.Network;
using Demo_R.O.S.E.CharServer.Common;
#endregion

namespace Demo_R.O.S.E.CharServer.Network
{
    #region zh-CHS WorldAction Ack Àà | en WSCharSelect Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class WorldActionAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public WorldActionAck()
            : base( 0x71C, 7/*6 + 1*/ )
        {
            WriterStream.Write( (ushort)7 /*6 + 1*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô

            WriterStream.Write( (byte)0x00 );
        }
    }
    #endregion

    #region zh-CHS DoIdentify Ack Àà | en DoIdentify Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class DoIdentifyAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal DoIdentifyAck() : base( 0x070C, 15 /*6 + 9*/ )
        {
            WriterStream.Write( (ushort)15 /*6 + 9*/ );     // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (sbyte)0x0 );
            WriterStream.Write( (uint)0x87654321 );
            WriterStream.Write( (uint)0x0 );
        }
    }
    #endregion

    #region zh-CHS GetCharacters Ack Àà | en GetCharacters Ack Class

    #region zh-CHS PacketCharacterÀà | en PacketCharacter Class
    /// <summary>
    /// 
    /// </summary>
    internal class PacketCharacter
    {
        #region zh-CHS PacketItemÀà | en PacketItem Class
        /// <summary>
        /// 
        /// </summary>
        internal class PacketItem
        {
            /// <summary>
            /// 
            /// </summary>
            internal uint m_CharacterGuid;
            /// <summary>
            /// 
            /// </summary>
            internal uint m_ItemID;
            /// <summary>
            /// 
            /// </summary>
            internal uint m_ItemType;
            /// <summary>
            /// 
            /// </summary>
            internal uint m_Refine;
            /// <summary>
            /// 
            /// </summary>
            internal uint m_Durability;
            /// <summary>
            /// 
            /// </summary>
            internal uint m_Lifespan;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        internal string m_CharacterName;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_CharacterGuid;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_Level;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_Face;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_HairStyle;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_ClassID;
        /// <summary>
        /// 
        /// </summary>
        internal int m_Sex;
        /// <summary>
        /// 
        /// </summary>
        internal uint m_DeleteTime;
        /// <summary>
        /// 
        /// </summary>
        internal PacketItem[] m_Item = new PacketItem[0];
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    internal sealed class GetCharactersAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal GetCharactersAck( PacketCharacter[] characterArray ) : base( 0x0712, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡(Ö»°üÀ¨ÈËÎïµÄÊýÁ¿£¬ÏêÏ¸Êý¾Ý²»ËµÃ÷)
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (sbyte)characterArray.Length );

            for ( int iIndex = 0; iIndex < characterArray.Length; iIndex++ )
            {
                WriterStream.WriteAsciiNull( characterArray[iIndex].m_CharacterName );  // Character Name
                WriterStream.Write( (sbyte)characterArray[iIndex].m_Sex );              // SEX
                WriterStream.Write( (ushort)characterArray[iIndex].m_Level );           // LEVEL
                WriterStream.Write( (ushort)characterArray[iIndex].m_ClassID );         // CLASS ID
                WriterStream.Write( (uint)characterArray[iIndex].m_DeleteTime );        // DELETE TIME
                WriterStream.Write( (sbyte)0x00 );                                      // IS PLATINUM?  00-NO;01-YES;02-YES BUT USER IS NOT
                WriterStream.Write( (uint)characterArray[iIndex].m_Face );              // FACE
                WriterStream.Write( (uint)characterArray[iIndex].m_HairStyle );         // HAIR
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[2].m_ItemID );// CAP
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[2].m_Refine );// CAP REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[3].m_ItemID );// BODY
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[3].m_Refine );// BODY REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[5].m_ItemID );// GLOVES
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[5].m_Refine );// GLOVES REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[6].m_ItemID );// BOOTS
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[6].m_Refine );// BOOTS REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[1].m_ItemID );// FACE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[1].m_Refine );// FACE REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[4].m_ItemID );// BACK
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[4].m_Refine );// BACK REFINE 
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[7].m_ItemID );// WEAPON
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[7].m_Refine );// WEAPON REFINE
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[8].m_ItemID );// SUBWEAPON
                WriterStream.Write( (ushort)characterArray[iIndex].m_Item[8].m_Refine );// SUBWEAPON REFINE
            }


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS RequestWorld Ack Àà | en RequestWorld Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class RequestWorldAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal RequestWorldAck( IPEndPoint ipEndPoint, long iAccountsGuid )
            : base( 0x711, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)ipEndPoint.Port );
            WriterStream.Write( (uint)iAccountsGuid );
            WriterStream.Write( (uint)0x87654321 );
            WriterStream.WriteAsciiNull( ipEndPoint.Address.ToString() );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS CreateCharacter Ack Àà | en CreateCharacter Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class CreateCharacterAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal CreateCharacterAck()
            : base( 0x0713, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)0x00 );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum CCLReason
    {
        /// <summary>
        /// 
        /// </summary>
        BadCharacterName = 0x01,
        /// <summary>
        /// 
        /// </summary>
        BadAccountName = 0x02,
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class CreateCharacterRej : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCharacterRej( CCLReason cclReason )
            : base( 0x0713, 8 /*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            if ( cclReason == CCLReason.BadAccountName )
                WriterStream.Write( (ushort)4 );    // ÏàÍ¬µÄÕÊºÅÃûÒÑ¾­´æÔÚ
            else if ( cclReason == CCLReason.BadCharacterName )
                WriterStream.Write( (ushort)2 );    // ÓÎÏ·Ãû×ÖÒÑ¾­´æÔÚ»òÒÑ¹ýÂËµÄÎÄ¼þÃû
            else
                WriterStream.Write( (ushort)0 );
        }
    }
    #endregion

    #region zh-CHS DeleteCharacter Ack Àà | en DeleteCharacter Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class DeleteCharacterAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal DeleteCharacterAck( string strCharacterName, uint iDeleteTime )
            : base( 0x0714, 0 /*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (uint)iDeleteTime );
            WriterStream.WriteAsciiNull( strCharacterName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
   #endregion

    #region zh-CHS ClanChat Ack Àà | en ClanManager Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class ClanChatAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal ClanChatAck( string strName, string strText )
            : base( 0x787, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.WriteAsciiNull( strName );
            WriterStream.WriteAsciiNull( strText ); //


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS MessengerChat Ack Àà | en ClanManager Ack Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class MessengerChatAck : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal MessengerChatAck( long charid, string strName, string strMessage )
            : base( 0x7E2, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (ushort)charid );
            WriterStream.Write( (ushort)0x0000 );

            long beginPosition = WriterStream.Position;

            WriterStream.WriteAsciiNull( strName );

            long endPosition = WriterStream.Position;

            long nameSize = endPosition - beginPosition;

            for ( int iIndex = 0; iIndex < 31 - nameSize; iIndex++ )
                WriterStream.Write( (byte)0x00 );

            WriterStream.WriteAsciiNull( strMessage ); //


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS Clan0x7E0 Ack Àà | en ClanManagerAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x33_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x33_Ack( Clan clan, long iClanRank )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x33 );               // 0x33 you have invited to clan
            WriterStream.Write( (ushort)0x09CF );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (ushort)clan.Back );      // Clan Background
            WriterStream.Write( (ushort)clan.Logo );      // Clan logo
            WriterStream.Write( (byte)clan.Grade );       // Clan grade
            WriterStream.Write( (byte)iClanRank );          // Clan rank (0 = red rokie / 6 = master)
            WriterStream.Write( (byte)clan.CP );          // Clan Points
            WriterStream.Write( (uint)0x00000000 );
            WriterStream.Write( (uint)0x00000000 );         // Clan found
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (uint)0x00000000 );
            WriterStream.Write( (ushort)0x0000 );

            for ( int iIndex = 34; iIndex < 156; iIndex++ )
                WriterStream.Write( (byte)0x00 );

            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.WriteAsciiNull( clan.ClanName );
            WriterStream.WriteAsciiNull( clan.Slogan );
            WriterStream.WriteAsciiNull( clan.News );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x0B_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x0B_Ack( string strCharName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x0B );   // invite action
            WriterStream.WriteAsciiNull( strCharName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x81_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x81_Ack( string strKickName, string strCharName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x81 );   // xxx have kicket to yyyy
            WriterStream.WriteAsciiNull( strKickName );
            WriterStream.WriteAsciiNull( strCharName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x83_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x83_Ack( string strCharName, long iRank )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x83 ); // up/down rank
            WriterStream.WriteAsciiNull( strCharName );
            WriterStream.Write( (uint)iRank );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x75_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x75_Ack( long iRank, long iServerGuid, long iLevel, long iJob, string strCharName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x75 );   // up rank
            WriterStream.Write( (byte)iRank );  //  
            WriterStream.Write( (byte)iServerGuid );   // channel 
            WriterStream.Write( (short)0x0000 );    // 
            WriterStream.Write( (short)0x0000 );    // 
            WriterStream.Write( (short)iLevel );    // 
            WriterStream.Write( (short)iJob );  // 
            WriterStream.WriteAsciiNull( strCharName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x34_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x34_Ack( string strNews )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x34 );// Change news
            WriterStream.WriteAsciiNull( strNews );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x82_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x82_Ack( string strName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x82 ); // Leave Clan
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x72_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x72_Ack( ClanMember[] clanMembers )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            if ( clanMembers == null && clanMembers.Length == 0 )
            {
                WriterStream.Write( (byte)0x0F );
                WriterStream.Write( (uint)0x00000001 );
            }
            else
            {
                WriterStream.Write( (byte)0x72 );   // Send clan members

                foreach ( ClanMember clanMember in clanMembers )
                {
                    WriterStream.Write( (byte)clanMember.ClanRank );  //clan rank
                    WriterStream.Write( (byte)clanMember.ServerGuid ); //channel (0xff = offline) //channel (0x01 = channel 1)
                    WriterStream.Write( (ushort)0x0000 );
                    WriterStream.Write( (ushort)0x0000 );
                    WriterStream.Write( (ushort)clanMember.Level );
                    WriterStream.Write( (ushort)clanMember.ClassId );
                    WriterStream.WriteAsciiNull( clanMember.CharacterName );
                }
            }


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x51_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x51_Ack()
            : base( 0x7E0, 8/*6 + 2*/ )
        {
            WriterStream.Write( (ushort)8 /*6 + 2*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x51 ); //
            WriterStream.Write( (byte)0x00 ); //
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x61_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x61_Ack( string strName, string strNameAccepted )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x61 ); //
            WriterStream.WriteAsciiNull( strName );
            WriterStream.WriteAsciiNull( strNameAccepted );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x84_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x84_Ack( long iLevel, long iClassId, string strName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x84 ); //
            WriterStream.Write( (ushort)iLevel );
            WriterStream.Write( (ushort)iClassId );
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x0D_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x0D_Ack( string strName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x0D ); //
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x30_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x30_Ack( long iClientId, long iClanRank, Clan clan )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x30 ); //
            WriterStream.Write( (ushort)iClientId ); //
            WriterStream.Write( (ushort)0x0100 ); //
            WriterStream.Write( (ushort)clan.Back ); // clan background
            WriterStream.Write( (ushort)clan.Logo ); // clanlogo            
            WriterStream.Write( (byte)0x01 ); //clan grade
            WriterStream.Write( (byte)iClanRank ); // clan rank

            for ( int iIndex = 0; iIndex < 146; iIndex++ )
                WriterStream.Write( (byte)0x00 ); // clan skills

            WriterStream.WriteAsciiNull( clan.ClanName );
            WriterStream.Write( (byte)0x00 ); //
            WriterStream.Write( (ushort)0x0000 ); //
            WriterStream.Write( (ushort)0x0000 ); //
            WriterStream.Write( (ushort)0x0000 ); //
            WriterStream.Write( (ushort)0x0000 ); //
            WriterStream.WriteAsciiNull( clan.Slogan ); // clan slogan


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion

    #region zh-CHS Friend0x7E1 Ack Àà | en ClanManagerAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x01_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x01_Ack( string strName )
            : base( 0x7E1, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x01 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x02_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x02_Ack( long iCharGuid, string strName )
            : base( 0x7E1, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x02 );
            WriterStream.Write( (ushort)iCharGuid );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x03_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x03_Ack( string strName )
            : base( 0x7E1, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x03 );
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x04_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x04_Ack( string strName )
            : base( 0x7E1, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x04 );
            WriterStream.WriteAsciiNull( strName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x06_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x06_Ack( Friend[] friendListArray )
            : base( 0x7E1, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////
            

            WriterStream.Write( (byte)0x06 );
            WriterStream.Write( (byte)friendListArray.Length );

            foreach ( Friend friendList in friendListArray )
            {
                WriterStream.Write( (ushort)friendList.FriendGuid );
                WriterStream.Write( (ushort)0x0000 );

                if ( friendList.IsOnline == true )    // is Online ??
                    WriterStream.Write( (byte)0x07 );           // Online
                else
                    WriterStream.Write( (byte)0x08 );           // Offline

                WriterStream.WriteAsciiNull( friendList.FriendName );
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Friend0x7E1_Action0x08_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Friend0x7E1_Action0x08_Ack( long iCharGuid, long iStatus )
            : base( 0x7E1, 12/*6 + 6*/ )
        {
            WriterStream.Write( (ushort)12 /*6 + 6*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x08 );
            WriterStream.Write( (ushort)iCharGuid );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (byte)iStatus );
        }
    }
    #endregion

    #region zh-CHS Unknown0x07E5 Ack Àà | en ClanManagerAck Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Unknown0x07E5_Action0x01Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Unknown0x07E5_Action0x01Ack()
            : base( 0x7E5, 9/*6 + 3*/ )
        {
            WriterStream.Write( (ushort)9 /*6 + 3*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x01 );
            WriterStream.Write( (ushort)0x0000 );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class Clan0x7E0_Action0x73_Ack : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        internal Clan0x7E0_Action0x73_Ack( long iServerGuid, long iLevel, long iClassId, string strCharName )
            : base( 0x7E0, 0/*6 + ?*/ )
        {
            WriterStream.Write( (ushort)0 /*6 + ?*/ );      // ×Ö¶Î´óÐ¡
            WriterStream.Write( (ushort)base.PacketID );    // ×Ö¶Î±àºÅ
            WriterStream.Write( (ushort)0x00 );             // ×Ö¶Î±£Áô
            //////////////////////////////////////////////////////////////////////////


            WriterStream.Write( (byte)0x73 );
            WriterStream.Write( (byte)0x00 );
            WriterStream.Write( (byte)iServerGuid );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)0x0000 );
            WriterStream.Write( (ushort)iLevel );
            WriterStream.Write( (ushort)iClassId );
            WriterStream.WriteAsciiNull( strCharName );


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)WriterStream.Length );
        }
    }
    #endregion
}
#endregion