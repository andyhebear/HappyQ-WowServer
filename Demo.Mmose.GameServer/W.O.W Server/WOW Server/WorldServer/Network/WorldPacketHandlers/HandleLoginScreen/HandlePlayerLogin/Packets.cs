using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Ability.Skill;
using Demo.Wow.WorldServer.Ability.Spell;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Reputation;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    public class InstanceMode
    {
        public const byte MODE_NORMAL = 0;
        public const byte MODE_HEROIC = 1;
        public const byte MODE_EPIC = 2;
    }

    public class GuildEvent
    {
        public const byte GUILD_EVENT_PROMOTION = 0x0;
        public const byte GUILD_EVENT_DEMOTION = 0x1;
        public const byte GUILD_EVENT_MOTD = 0x2;
        public const byte GUILD_EVENT_JOINED = 0x3;
        public const byte GUILD_EVENT_LEFT = 0x4;
        public const byte GUILD_EVENT_REMOVED = 0x5;
        public const byte GUILD_EVENT_LEADER_IS = 0x6;
        public const byte GUILD_EVENT_LEADER_CHANGED = 0x7;
        public const byte GUILD_EVENT_DISBANDED = 0x8;
        public const byte GUILD_EVENT_TABARDCHANGE = 0x9;
        public const byte GUILD_EVENT_UNK1 = 0xA;
        public const byte GUILD_EVENT_UNK2 = 0xB;
        public const byte GUILD_EVENT_HASCOMEONLINE = 0xC;
        public const byte GUILD_EVENT_HASGONEOFFLINE = 0xD;
    }

    public class AccountData
    {
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Buffer;
        /// <summary>
        /// 
        /// </summary>
        public byte[] Buffer
        {
            get { return m_Buffer; }
            set { m_Buffer = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_Size;
        /// <summary>
        /// 
        /// </summary>
        public uint Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool m_bIsDirty;
        /// <summary>
        /// 
        /// </summary>
        public bool IsDirty
        {
            get { return m_bIsDirty; }
            set { m_bIsDirty = value; }
        }
    };

    #region zh-CHS Word_PlayerDungeonDifficulty 类 | en Word_PlayerDungeonDifficulty Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerDungeonDifficulty : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerDungeonDifficulty( uint byInstanceType )
            : base( (long)WordOpCode.CMSG_DUNGEON_DIFFICULTY, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.CMSG_DUNGEON_DIFFICULTY );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)byInstanceType );
            WriterStream.Write( (uint)0x01 );
            WriterStream.Write( (uint)0x00 );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerLoginVerifyWorld 类 | en Word_PlayerLoginVerifyWorld Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerLoginVerifyWorld : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerLoginVerifyWorld ( uint uiMapId, float fPositionX, float fPositionY, float fPositionZ, float fOrientation )
            : base( (long)WordOpCode.SMSG_LOGIN_VERIFY_WORLD, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_LOGIN_VERIFY_WORLD );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)uiMapId );
            WriterStream.Write( (float)fPositionX );
            WriterStream.Write( (float)fPositionY );
            WriterStream.Write( (float)fPositionZ );
            WriterStream.Write( (float)fOrientation );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerAccountDataMd5 类 | en Word_PlayerAccountDataMd5 Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerAccountDataMd5 : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerAccountDataMd5( AccountData[] accountData )
            : base( (long)WordOpCode.SMSG_ACCOUNT_DATA_MD5, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_ACCOUNT_DATA_MD5 );    // ID
            //////////////////////////////////////////////////////////////////////////

            for ( int i = 0; i < accountData.Length; i++ )
            {

                if ( accountData[i].Buffer == null )
                {
                    WriterStream.Write( (long)0 );
                    WriterStream.Write( (long)0 );
                }
                else
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] byResultArray = md5.ComputeHash( accountData[i].Buffer );

                    WriterStream.Write( byResultArray, 0, byResultArray.Length );
                }
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerVoiceSystemStatus 类 | en Word_PlayerVoiceSystemStatus Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerVoiceSystemStatus : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerVoiceSystemStatus( byte byCanUseVoiceChat )
            : base( (long)WordOpCode.SMSG_VOICE_SYSTEM_STATUS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_VOICE_SYSTEM_STATUS );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)2 );
            WriterStream.Write( (byte)byCanUseVoiceChat );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerBroadcastMsg 类 | en Word_PlayerBroadcastMsg Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerBroadcastMsg : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerBroadcastMsg(string strMsg)
            : base( (long)WordOpCode.SMSG_BROADCAST_MSG, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_BROADCAST_MSG );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)0 ); // 行数
            WriterStream.WriteUTF8Null( strMsg );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerGuildEvent 类 | en Word_PlayerGuildEvent Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerGuildEvent : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerGuildEvent( string strGuildInfo, string strGuildName, long lGuild )
            : base( (long)WordOpCode.SMSG_GUILD_EVENT, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_GUILD_EVENT );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)GuildEvent.GUILD_EVENT_MOTD );
            WriterStream.Write( (byte)1 );
            WriterStream.WriteBigUniNull( strGuildInfo );

            WriterStream.Write( (byte)GuildEvent.GUILD_EVENT_HASCOMEONLINE );
            WriterStream.Write( (byte)1 );
            WriterStream.WriteBigUniNull( strGuildName );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerSetRestStart 类 | en Word_PlayerSetRestStart Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerSetRestStart : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerSetRestStart()
            : base( (long)WordOpCode.SMSG_SET_REST_START, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_SET_REST_START );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)0 );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerBindPointUpdate 类 | en Word_PlayerBindPointUpdate Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerBindPointUpdate : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerBindPointUpdate( float fHomeBindX, float fHomeBindY, float fHomeBindZ, uint uiMapId, uint uiZoneId )
            : base( (long)WordOpCode.SMSG_BINDPOINTUPDATE, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_BINDPOINTUPDATE );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)fHomeBindX );
            WriterStream.Write( (uint)fHomeBindY );
            WriterStream.Write( (uint)fHomeBindZ );
            WriterStream.Write( (uint)uiMapId );
            WriterStream.Write( (uint)uiZoneId );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerTutorialFlags 类 | en Word_PlayerTutorialFlags Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerTutorialFlags : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerTutorialFlags( uint[] uiTutorialArray )
            : base( (long)WordOpCode.SMSG_TUTORIAL_FLAGS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_TUTORIAL_FLAGS );    // ID
            //////////////////////////////////////////////////////////////////////////

            for ( int iIndex = 0; iIndex < uiTutorialArray.Length; iIndex++ )
                WriterStream.Write( (uint)uiTutorialArray[iIndex] );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerInitialSpells 类 | en Word_PlayerInitialSpells Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerInitialSpells : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerInitialSpells( WowSpell[] wowSpellArray, WowSpellCooldown[] wowSpellCoolDownArray )
            : base( (long)WordOpCode.SMSG_INITIAL_SPELLS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_INITIAL_SPELLS );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)0 );
            WriterStream.Write( (ushort)wowSpellArray.Length );

            for ( int iIndex = 0; iIndex < wowSpellArray.Length; iIndex++ )
            {
                WriterStream.Write( (ushort)wowSpellArray[iIndex].Level );
                WriterStream.Write( (ushort)0 );
            }

            // SpellCooldown
            WriterStream.Write( (ushort)wowSpellCoolDownArray.Length );

            for ( int iIndex = 0; iIndex < wowSpellCoolDownArray.Length; iIndex++ )
            {
                WriterStream.Write( (ushort)wowSpellCoolDownArray[iIndex].Level );
                WriterStream.Write( (ushort)0 );
                WriterStream.Write( (ushort)0 );

                if ( wowSpellCoolDownArray[iIndex].Level != 0 )
                {
                    WriterStream.Write( (uint)0 );
                    WriterStream.Write( (uint)0 );
                }
                else
                {
                    WriterStream.Write( (uint)0 );
                    WriterStream.Write( (uint)0 );
                }
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerActionButtons 类 | en Word_PlayerActionButtons Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerActionButtons : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerActionButtons( WowActionBar[] wowActionBar )
            : base( (long)WordOpCode.SMSG_ACTION_BUTTONS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_ACTION_BUTTONS );    // ID
            //////////////////////////////////////////////////////////////////////////

            for ( int iIndex = 0; iIndex < 120; iIndex++ )
            {
                //WriterStream.Write( (ushort)wowActionBar[iIndex].Action );
                //WriterStream.Write( (byte)wowActionBar[iIndex].Type );
                //WriterStream.Write( (byte)wowActionBar[iIndex].Type );
                {
                    WriterStream.Write( (ushort)0 );
                    WriterStream.Write( (byte)0 );
                    WriterStream.Write( (byte)0 );
                }
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerInitializeFactions 类 | en Word_PlayerInitializeFactions Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerInitializeFactions : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerInitializeFactions( WowReputation[] wowReputation )
            : base( (long)WordOpCode.SMSG_INITIALIZE_FACTIONS, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_INITIALIZE_FACTIONS );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)0x80 ); // == 128 

            for ( int iIndex = 0; iIndex <  128; iIndex++ )
            {
                //WriterStream.Write( (byte)wowReputation[iIndex].Flag );
                //WriterStream.Write( (uint)wowReputation[iIndex].Reputation );
                {
                    WriterStream.Write( (byte)0 );
                    WriterStream.Write( (uint)0 );
                }
            }

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerInitWorldStates 类 | en Word_PlayerInitWorldStates Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerInitWorldStates : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerInitWorldStates( uint iMapId, uint iZoneId, uint iAreaId )
            : base( (long)WordOpCode.SMSG_INIT_WORLD_STATES, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_INIT_WORLD_STATES );    // ID
            //////////////////////////////////////////////////////////////////////////

            ushort usNumberOfFields = 0;

            switch ( iZoneId )
            {
                case 0:
                case 1:
                case 4:
                case 8:
                case 10:
                case 11:
                case 12:
                case 36:
                case 38:
                case 40:
                case 41:
                case 51:
                case 267:
                case 1519:
                case 1537:
                case 2257:
                case 2918:
                    usNumberOfFields = 6;
                    break;
                case 2597:
                    usNumberOfFields = 81;
                    break;
                case 3277:
                    usNumberOfFields = 14;
                    break;
                case 3358:
                    usNumberOfFields = 38;
                    break;
                case 3483:
                    usNumberOfFields = 22;
                    break;
                case 3519:
                    usNumberOfFields = 36;
                    break;
                case 3521:
                    usNumberOfFields = 35;
                    break;
                case 3698:
                case 3702:
                case 3968:
                    usNumberOfFields = 9;
                    break;
                case 3703:
                    usNumberOfFields = 9;
                    break;
                default:
                    usNumberOfFields = 10;
                    break;
            }

            WriterStream.Write( (uint)iMapId );  // mapid
            WriterStream.Write( (uint)iZoneId ); // zone id
            WriterStream.Write( (uint)iAreaId ); // area id, new 2.1.0
            WriterStream.Write( (uint)usNumberOfFields ); // count of uint64 blocks

            WriterStream.Write( (uint)0x8d8 ); // 1
            WriterStream.Write( (uint)0x0 );
            WriterStream.Write( (uint)0x8d7 ); // 2
            WriterStream.Write( (uint)0x0 );
            WriterStream.Write( (uint)0x8d6 ); // 3
            WriterStream.Write( (uint)0x0 );
            WriterStream.Write( (uint)0x8d5 ); // 4
            WriterStream.Write( (uint)0x0 );
            WriterStream.Write( (uint)0x8d4 ); // 5
            WriterStream.Write( (uint)0x0 );
            WriterStream.Write( (uint)0x8d3 ); // 6
            WriterStream.Write( (uint)0x0 );
            if ( iMapId == 530 ) // Outland
            {
                WriterStream.Write( (uint)0x9bf ); // 7
                WriterStream.Write( (uint)0x0 );
                WriterStream.Write( (uint)0x9bd ); // 8
                WriterStream.Write( (uint)0x0 );
                WriterStream.Write( (uint)0x9bb ); // 9
                WriterStream.Write( (uint)0x0 );
            }

            switch ( iZoneId )
            {
                case 1:
                case 11:
                case 12:
                case 38:
                case 40:
                case 51:
                case 1519:
                case 1537:
                case 2257:
                    break;
                case 2597:                                          // AV
                    WriterStream.Write( (uint)0x7ae );
                    WriterStream.Write( (uint)0x1 );           // 7

                    WriterStream.Write( (uint)0x532 );
                    WriterStream.Write( (uint)0x1 );           // 8

                    WriterStream.Write( (uint)0x531 );
                    WriterStream.Write( (uint)0x0 );           // 9

                    WriterStream.Write( (uint)0x52e );
                    WriterStream.Write( (uint)0x0 );           // 10

                    WriterStream.Write( (uint)0x571 );
                    WriterStream.Write( (uint)0x0 );           // 11

                    WriterStream.Write( (uint)0x570 );
                    WriterStream.Write( (uint)0x0 );           // 12

                    WriterStream.Write( (uint)0x567 );
                    WriterStream.Write( (uint)0x1 );           // 13

                    WriterStream.Write( (uint)0x566 );
                    WriterStream.Write( (uint)0x1 );           // 14

                    WriterStream.Write( (uint)0x550 );
                    WriterStream.Write( (uint)0x1 );           // 15

                    WriterStream.Write( (uint)0x544 );
                    WriterStream.Write( (uint)0x0 );           // 16

                    WriterStream.Write( (uint)0x536 );
                    WriterStream.Write( (uint)0x0 );           // 17

                    WriterStream.Write( (uint)0x535 );
                    WriterStream.Write( (uint)0x1 );           // 18

                    WriterStream.Write( (uint)0x518 );
                    WriterStream.Write( (uint)0x0 );           // 19

                    WriterStream.Write( (uint)0x517 );
                    WriterStream.Write( (uint)0x0 );           // 20

                    WriterStream.Write( (uint)0x574 );
                    WriterStream.Write( (uint)0x0 );           // 21

                    WriterStream.Write( (uint)0x573 );
                    WriterStream.Write( (uint)0x0 );           // 22

                    WriterStream.Write( (uint)0x572 );
                    WriterStream.Write( (uint)0x0 );           // 23

                    WriterStream.Write( (uint)0x56f );
                    WriterStream.Write( (uint)0x0 );           // 24

                    WriterStream.Write( (uint)0x56e );
                    WriterStream.Write( (uint)0x0 );           // 25

                    WriterStream.Write( (uint)0x56d );
                    WriterStream.Write( (uint)0x0 );           // 26

                    WriterStream.Write( (uint)0x56c );
                    WriterStream.Write( (uint)0x0 );           // 27

                    WriterStream.Write( (uint)0x56b );
                    WriterStream.Write( (uint)0x0 );           // 28

                    WriterStream.Write( (uint)0x56a );
                    WriterStream.Write( (uint)0x1 );           // 29

                    WriterStream.Write( (uint)0x569 );
                    WriterStream.Write( (uint)0x1 );           // 30

                    WriterStream.Write( (uint)0x568 );
                    WriterStream.Write( (uint)0x1 );           // 13

                    WriterStream.Write( (uint)0x565 );
                    WriterStream.Write( (uint)0x0 );           // 32

                    WriterStream.Write( (uint)0x564 );
                    WriterStream.Write( (uint)0x0 );           // 33

                    WriterStream.Write( (uint)0x563 );
                    WriterStream.Write( (uint)0x0 );           // 34

                    WriterStream.Write( (uint)0x562 );
                    WriterStream.Write( (uint)0x0 );           // 35

                    WriterStream.Write( (uint)0x561 );
                    WriterStream.Write( (uint)0x0 );           // 36

                    WriterStream.Write( (uint)0x560 );
                    WriterStream.Write( (uint)0x0 );           // 37

                    WriterStream.Write( (uint)0x55f );
                    WriterStream.Write( (uint)0x0 );           // 38

                    WriterStream.Write( (uint)0x55e );
                    WriterStream.Write( (uint)0x0 );           // 39

                    WriterStream.Write( (uint)0x55d );
                    WriterStream.Write( (uint)0x0 );           // 40

                    WriterStream.Write( (uint)0x3c6 );
                    WriterStream.Write( (uint)0x4 );           // 41

                    WriterStream.Write( (uint)0x3c4 );
                    WriterStream.Write( (uint)0x6 );           // 42

                    WriterStream.Write( (uint)0x3c2 );
                    WriterStream.Write( (uint)0x4 );           // 43

                    WriterStream.Write( (uint)0x516 );
                    WriterStream.Write( (uint)0x1 );           // 44

                    WriterStream.Write( (uint)0x515 );
                    WriterStream.Write( (uint)0x0 );           // 45

                    WriterStream.Write( (uint)0x3b6 );
                    WriterStream.Write( (uint)0x6 );           // 46

                    WriterStream.Write( (uint)0x55c );
                    WriterStream.Write( (uint)0x0 );           // 47

                    WriterStream.Write( (uint)0x55b );
                    WriterStream.Write( (uint)0x0 );           // 48

                    WriterStream.Write( (uint)0x55a );
                    WriterStream.Write( (uint)0x0 );           // 49

                    WriterStream.Write( (uint)0x559 );
                    WriterStream.Write( (uint)0x0 );           // 50

                    WriterStream.Write( (uint)0x558 );
                    WriterStream.Write( (uint)0x0 );           // 51

                    WriterStream.Write( (uint)0x557 );
                    WriterStream.Write( (uint)0x0 );           // 52

                    WriterStream.Write( (uint)0x556 );
                    WriterStream.Write( (uint)0x0 );           // 53

                    WriterStream.Write( (uint)0x555 );
                    WriterStream.Write( (uint)0x0 );           // 54

                    WriterStream.Write( (uint)0x554 );
                    WriterStream.Write( (uint)0x1 );           // 55

                    WriterStream.Write( (uint)0x553 );
                    WriterStream.Write( (uint)0x1 );           // 56

                    WriterStream.Write( (uint)0x552 );
                    WriterStream.Write( (uint)0x1 );           // 57

                    WriterStream.Write( (uint)0x551 );
                    WriterStream.Write( (uint)0x1 );           // 58

                    WriterStream.Write( (uint)0x54f );
                    WriterStream.Write( (uint)0x0 );           // 59

                    WriterStream.Write( (uint)0x54e );
                    WriterStream.Write( (uint)0x0 );           // 60

                    WriterStream.Write( (uint)0x54d );
                    WriterStream.Write( (uint)0x1 );           // 61

                    WriterStream.Write( (uint)0x54c );
                    WriterStream.Write( (uint)0x0 );           // 62

                    WriterStream.Write( (uint)0x54b );
                    WriterStream.Write( (uint)0x0 );           // 63

                    WriterStream.Write( (uint)0x545 );
                    WriterStream.Write( (uint)0x0 );           // 64

                    WriterStream.Write( (uint)0x543 );
                    WriterStream.Write( (uint)0x1 );           // 65

                    WriterStream.Write( (uint)0x542 );
                    WriterStream.Write( (uint)0x0 );           // 66

                    WriterStream.Write( (uint)0x540 );
                    WriterStream.Write( (uint)0x0 );           // 67

                    WriterStream.Write( (uint)0x53f );
                    WriterStream.Write( (uint)0x0 );           // 68

                    WriterStream.Write( (uint)0x53e );
                    WriterStream.Write( (uint)0x0 );           // 69

                    WriterStream.Write( (uint)0x53d );
                    WriterStream.Write( (uint)0x0 );           // 70

                    WriterStream.Write( (uint)0x53c );
                    WriterStream.Write( (uint)0x0 );           // 71

                    WriterStream.Write( (uint)0x53b );
                    WriterStream.Write( (uint)0x0 );           // 72

                    WriterStream.Write( (uint)0x53a );
                    WriterStream.Write( (uint)0x1 );           // 73

                    WriterStream.Write( (uint)0x539 );
                    WriterStream.Write( (uint)0x0 );           // 74

                    WriterStream.Write( (uint)0x538 );
                    WriterStream.Write( (uint)0x0 );           // 75

                    WriterStream.Write( (uint)0x537 );
                    WriterStream.Write( (uint)0x0 );           // 76

                    WriterStream.Write( (uint)0x534 );
                    WriterStream.Write( (uint)0x0 );           // 77

                    WriterStream.Write( (uint)0x533 ); 
                    WriterStream.Write( (uint)0x0 );           // 78

                    WriterStream.Write( (uint)0x530 );
                    WriterStream.Write( (uint)0x0 );           // 79

                    WriterStream.Write( (uint)0x52f );
                    WriterStream.Write( (uint)0x0 );           // 80

                    WriterStream.Write( (uint)0x52d );
                    WriterStream.Write( (uint)0x1 );           // 81
                    break;
                case 3277:                                          // WSG
                    WriterStream.Write( (uint)0x62d );
                    WriterStream.Write( (uint)0x0 );           // 7 1581 alliance flag captures

                    WriterStream.Write( (uint)0x62e );
                    WriterStream.Write( (uint)0x0 );           // 8 1582 horde flag captures

                    WriterStream.Write( (uint)0x609 );
                    WriterStream.Write( (uint)0x0 );           // 9 1545 unk, set to 1 on alliance flag pickup...

                    WriterStream.Write( (uint)0x60a );
                    WriterStream.Write( (uint)0x0 );           // 10 1546 unk, set to 1 on horde flag pickup, after drop it's -1

                    WriterStream.Write( (uint)0x60b );
                    WriterStream.Write( (uint)0x2 );           // 11 1547 unk

                    WriterStream.Write( (uint)0x641 );
                    WriterStream.Write( (uint)0x3 );           // 12 1601 unk (max flag captures?)

                    WriterStream.Write( (uint)0x922 );
                    WriterStream.Write( (uint)0x1 );           // 13 2338 horde (0 - hide, 1 - flag ok, 2 - flag picked up (flashing), 3 - flag picked up (not flashing)

                    WriterStream.Write( (uint)0x923 );
                    WriterStream.Write( (uint)0x1 );           // 14 2339 alliance (0 - hide, 1 - flag ok, 2 - flag picked up (flashing), 3 - flag picked up (not flashing)
                    break;
                case 3358:                                          // AB
                    WriterStream.Write( (uint)0x6e7 );
                    WriterStream.Write( (uint)0x0 );           // 7 1767 stables alliance

                    WriterStream.Write( (uint)0x6e8 );
                    WriterStream.Write( (uint)0x0 );           // 8 1768 stables horde

                    WriterStream.Write( (uint)0x6e9 );
                    WriterStream.Write( (uint)0x0 );           // 9 1769 unk, ST?

                    WriterStream.Write( (uint)0x6ea ); 
                    WriterStream.Write( (uint)0x0 );           // 10 1770 stables (show/hide)

                    WriterStream.Write( (uint)0x6ec );
                    WriterStream.Write( (uint)0x0 );           // 11 1772 farm (0 - horde controlled, 1 - alliance controlled)

                    WriterStream.Write( (uint)0x6ed );
                    WriterStream.Write( (uint)0x0 );           // 12 1773 farm (show/hide)

                    WriterStream.Write( (uint)0x6ee );
                    WriterStream.Write( (uint)0x0 );           // 13 1774 farm color

                    WriterStream.Write( (uint)0x6ef );
                    WriterStream.Write( (uint)0x0 );           // 14 1775 gold mine color, may be FM?

                    WriterStream.Write( (uint)0x6f0 );
                    WriterStream.Write( (uint)0x0 );           // 15 1776 alliance resources

                    WriterStream.Write( (uint)0x6f1 );
                    WriterStream.Write( (uint)0x0 );           // 16 1777 horde resources

                    WriterStream.Write( (uint)0x6f2 );
                    WriterStream.Write( (uint)0x0 );           // 17 1778 horde bases

                    WriterStream.Write( (uint)0x6f3 );
                    WriterStream.Write( (uint)0x0 );           // 18 1779 alliance bases

                    WriterStream.Write( (uint)0x6f4 );
                    WriterStream.Write( (uint)0x7d0 );         // 19 1780 max resources (2000)

                    WriterStream.Write( (uint)0x6f6 );
                    WriterStream.Write( (uint)0x0 );           // 20 1782 blacksmith color

                    WriterStream.Write( (uint)0x6f7 );
                    WriterStream.Write( (uint)0x0 );           // 21 1783 blacksmith (show/hide)

                    WriterStream.Write( (uint)0x6f8 );
                    WriterStream.Write( (uint)0x0 );           // 22 1784 unk, bs?

                    WriterStream.Write( (uint)0x6f9 );
                    WriterStream.Write( (uint)0x0 );           // 23 1785 unk, bs?

                    WriterStream.Write( (uint)0x6fb );
                    WriterStream.Write( (uint)0x0 );           // 24 1787 gold mine (0 - horde contr, 1 - alliance contr)

                    WriterStream.Write( (uint)0x6fc );
                    WriterStream.Write( (uint)0x0 );           // 25 1788 gold mine (0 - conflict, 1 - horde)

                    WriterStream.Write( (uint)0x6fd );
                    WriterStream.Write( (uint)0x0 );           // 26 1789 gold mine (1 - show/0 - hide)

                    WriterStream.Write( (uint)0x6fe );
                    WriterStream.Write( (uint)0x0 );           // 27 1790 gold mine color

                    WriterStream.Write( (uint)0x700 );
                    WriterStream.Write( (uint)0x0 );           // 28 1792 gold mine color, wtf?, may be LM?

                    WriterStream.Write( (uint)0x701 );
                    WriterStream.Write( (uint)0x0 );           // 29 1793 lumber mill color (0 - conflict, 1 - horde contr)

                    WriterStream.Write( (uint)0x702 );
                    WriterStream.Write( (uint)0x0 );           // 30 1794 lumber mill (show/hide)

                    WriterStream.Write( (uint)0x703 );
                    WriterStream.Write( (uint)0x0 );           // 31 1795 lumber mill color color

                    WriterStream.Write( (uint)0x732 );
                    WriterStream.Write( (uint)0x1 );           // 32 1842 stables (1 - uncontrolled)

                    WriterStream.Write( (uint)0x733 );
                    WriterStream.Write( (uint)0x1 );           // 33 1843 gold mine (1 - uncontrolled)

                    WriterStream.Write( (uint)0x734 );
                    WriterStream.Write( (uint)0x1 );           // 34 1844 lumber mill (1 - uncontrolled)

                    WriterStream.Write( (uint)0x735 );
                    WriterStream.Write( (uint)0x1 );           // 35 1845 farm (1 - uncontrolled)

                    WriterStream.Write( (uint)0x736 );
                    WriterStream.Write( (uint)0x1 );           // 36 1846 blacksmith (1 - uncontrolled)

                    WriterStream.Write( (uint)0x745 );
                    WriterStream.Write( (uint)0x2 );           // 37 1861 unk

                    WriterStream.Write( (uint)0x7a3 );
                    WriterStream.Write( (uint)0x708 );         // 38 1955 warning limit (1800)
                    break;
                case 3483:                                          // Hellfire Peninsula
                    WriterStream.Write( (uint)0x9ba );
                    WriterStream.Write( (uint)0x1 );           // 10

                    WriterStream.Write( (uint)0x9b9 );
                    WriterStream.Write( (uint)0x1 );           // 11

                    WriterStream.Write( (uint)0x9b5 );
                    WriterStream.Write( (uint)0x0 );           // 12

                    WriterStream.Write( (uint)0x9b4 );
                    WriterStream.Write( (uint)0x1 );           // 13

                    WriterStream.Write( (uint)0x9b3 );
                    WriterStream.Write( (uint)0x0 );           // 14

                    WriterStream.Write( (uint)0x9b2 );
                    WriterStream.Write( (uint)0x0 );           // 15

                    WriterStream.Write( (uint)0x9b1 );
                    WriterStream.Write( (uint)0x1 );           // 16

                    WriterStream.Write( (uint)0x9b0 );
                    WriterStream.Write( (uint)0x0 );           // 17

                    WriterStream.Write( (uint)0x9ae );
                    WriterStream.Write( (uint)0x0 );           // 18 horde pvp objectives captured

                    WriterStream.Write( (uint)0x9ac );
                    WriterStream.Write( (uint)0x0 );           // 19

                    WriterStream.Write( (uint)0x9a8 );
                    WriterStream.Write( (uint)0x0 );           // 20

                    WriterStream.Write( (uint)0x9a7 );
                    WriterStream.Write( (uint)0x0 );           // 21

                    WriterStream.Write( (uint)0x9a6 );
                    WriterStream.Write( (uint)0x1 );           // 22
                    break;
                case 3519:                                          // Terokkar Forest
                    WriterStream.Write( (uint)0xa41 );
                    WriterStream.Write( (uint)0x0 );           // 10

                    WriterStream.Write( (uint)0xa40 );
                    WriterStream.Write( (uint)0x14 );          // 11

                    WriterStream.Write( (uint)0xa3f );
                    WriterStream.Write( (uint)0x0 );           // 12

                    WriterStream.Write( (uint)0xa3e );
                    WriterStream.Write( (uint)0x0 );           // 13

                    WriterStream.Write( (uint)0xa3d );
                    WriterStream.Write( (uint)0x5 );           // 14

                    WriterStream.Write( (uint)0xa3c );
                    WriterStream.Write( (uint)0x0 );           // 15

                    WriterStream.Write( (uint)0xa87 );
                    WriterStream.Write( (uint)0x0 );           // 16

                    WriterStream.Write( (uint)0xa86 );
                    WriterStream.Write( (uint)0x0 );           // 17

                    WriterStream.Write( (uint)0xa85 );
                    WriterStream.Write( (uint)0x0 );           // 18

                    WriterStream.Write( (uint)0xa84 );
                    WriterStream.Write( (uint)0x0 );           // 19

                    WriterStream.Write( (uint)0xa83 );
                    WriterStream.Write( (uint)0x0 );           // 20

                    WriterStream.Write( (uint)0xa82 );
                    WriterStream.Write( (uint)0x0 );           // 21

                    WriterStream.Write( (uint)0xa81 );
                    WriterStream.Write( (uint)0x0 );           // 22

                    WriterStream.Write( (uint)0xa80 );
                    WriterStream.Write( (uint)0x0 );           // 23

                    WriterStream.Write( (uint)0xa7e );
                    WriterStream.Write( (uint)0x0 );           // 24

                    WriterStream.Write( (uint)0xa7d );
                    WriterStream.Write( (uint)0x0 );           // 25

                    WriterStream.Write( (uint)0xa7c );
                    WriterStream.Write( (uint)0x0 );           // 26

                    WriterStream.Write( (uint)0xa7b );
                    WriterStream.Write( (uint)0x0 );           // 27

                    WriterStream.Write( (uint)0xa7a );
                    WriterStream.Write( (uint)0x0 );           // 28

                    WriterStream.Write( (uint)0xa79 );
                    WriterStream.Write( (uint)0x0 );           // 29

                    WriterStream.Write( (uint)0x9d0 );
                    WriterStream.Write( (uint)0x5 );           // 30

                    WriterStream.Write( (uint)0x9ce );
                    WriterStream.Write( (uint)0x0 );           // 31

                    WriterStream.Write( (uint)0x9cd );
                    WriterStream.Write( (uint)0x0 );           // 32

                    WriterStream.Write( (uint)0x9cc );
                    WriterStream.Write( (uint)0x0 );           // 33

                    WriterStream.Write( (uint)0xa88 );
                    WriterStream.Write( (uint)0x0 );           // 34

                    WriterStream.Write( (uint)0xad0 );
                    WriterStream.Write( (uint)0x0 );           // 35

                    WriterStream.Write( (uint)0xacf );
                    WriterStream.Write( (uint)0x1 );           // 36
                    break;
                case 3521:                                          // Zangarmarsh
                    WriterStream.Write( (uint)0x9e1 );
                    WriterStream.Write( (uint)0x0 );           // 10

                    WriterStream.Write( (uint)0x9e0 );
                    WriterStream.Write( (uint)0x0 );           // 11

                    WriterStream.Write( (uint)0x9df );
                    WriterStream.Write( (uint)0x0 );           // 12

                    WriterStream.Write( (uint)0xa5d );
                    WriterStream.Write( (uint)0x1 );           // 13

                    WriterStream.Write( (uint)0xa5c );
                    WriterStream.Write( (uint)0x0 );           // 14

                    WriterStream.Write( (uint)0xa5b );
                    WriterStream.Write( (uint)0x1 );           // 15

                    WriterStream.Write( (uint)0xa5a );
                    WriterStream.Write( (uint)0x0 );           // 16

                    WriterStream.Write( (uint)0xa59 );
                    WriterStream.Write( (uint)0x1 );           // 17

                    WriterStream.Write( (uint)0xa58 );
                    WriterStream.Write( (uint)0x0 );           // 18

                    WriterStream.Write( (uint)0xa57 );
                    WriterStream.Write( (uint)0x0 );           // 19

                    WriterStream.Write( (uint)0xa56 );
                    WriterStream.Write( (uint)0x0 );           // 20

                    WriterStream.Write( (uint)0xa55 );
                    WriterStream.Write( (uint)0x1 );           // 21

                    WriterStream.Write( (uint)0xa54 );
                    WriterStream.Write( (uint)0x0 );           // 22

                    WriterStream.Write( (uint)0x9e7 );
                    WriterStream.Write( (uint)0x0 );           // 23

                    WriterStream.Write( (uint)0x9e6 );
                    WriterStream.Write( (uint)0x0 );           // 24

                    WriterStream.Write( (uint)0x9e5 );
                    WriterStream.Write( (uint)0x0 );           // 25

                    WriterStream.Write( (uint)0xa00 );
                    WriterStream.Write( (uint)0x0 );           // 26

                    WriterStream.Write( (uint)0x9ff );
                    WriterStream.Write( (uint)0x1 );           // 27

                    WriterStream.Write( (uint)0x9fe );
                    WriterStream.Write( (uint)0x0 );           // 28

                    WriterStream.Write( (uint)0x9fd );
                    WriterStream.Write( (uint)0x0 );           // 29

                    WriterStream.Write( (uint)0x9fc );
                    WriterStream.Write( (uint)0x1 );           // 30

                    WriterStream.Write( (uint)0x9fb );
                    WriterStream.Write( (uint)0x0 );           // 31

                    WriterStream.Write( (uint)0xa62 );
                    WriterStream.Write( (uint)0x0 );           // 32

                    WriterStream.Write( (uint)0xa61 );
                    WriterStream.Write( (uint)0x1 );           // 33

                    WriterStream.Write( (uint)0xa60 );
                    WriterStream.Write( (uint)0x1 );           // 34

                    WriterStream.Write( (uint)0xa5f );
                    WriterStream.Write( (uint)0x0 );           // 35
                    break;
                case 3698:                                          // Nagrand Arena
                    WriterStream.Write( (uint)0xa0f );
                    WriterStream.Write( (uint)0x0 );           // 7

                    WriterStream.Write( (uint)0xa10 );
                    WriterStream.Write( (uint)0x0 );           // 8

                    WriterStream.Write( (uint)0xa11 );
                    WriterStream.Write( (uint)0x0 );           // 9
                    break;
                case 3702:                                          // Blade's Edge Arena
                    WriterStream.Write( (uint)0x9f0 );
                    WriterStream.Write( (uint)0x0 );           // 7

                    WriterStream.Write( (uint)0x9f1 );
                    WriterStream.Write( (uint)0x0 );           // 8

                    WriterStream.Write( (uint)0x9f3 );
                    WriterStream.Write( (uint)0x0 );           // 9
                    break;
                case 3968:                                          // Ruins of Lordaeron
                    WriterStream.Write( (uint)0xbb8 );
                    WriterStream.Write( (uint)0x0 );           // 7

                    WriterStream.Write( (uint)0xbb9 );
                    WriterStream.Write( (uint)0x0 );           // 8

                    WriterStream.Write( (uint)0xbba );
                    WriterStream.Write( (uint)0x0 );           // 9
                    break;
                case 3703:                                          // Shattrath City
                    break;
                default:
                    WriterStream.Write( (uint)0x914 );
                    WriterStream.Write( (uint)0x0 );           // 7

                    WriterStream.Write( (uint)0x913 );
                    WriterStream.Write( (uint)0x0 );           // 8

                    WriterStream.Write( (uint)0x912 );
                    WriterStream.Write( (uint)0x0 );           // 9

                    WriterStream.Write( (uint)0x915 );
                    WriterStream.Write( (uint)0x0 );           // 10
                    break;
            }


            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerLoginSetTimeSpeed 类 | en Word_PlayerLoginSetTimeSpeed Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerLoginSetTimeSpeed : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerLoginSetTimeSpeed( DateTime dateTime )
            : base( (long)WordOpCode.SMSG_LOGIN_SETTIMESPEED, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_LOGIN_SETTIMESPEED );    // ID
            //////////////////////////////////////////////////////////////////////////

            uint xmitTime = (uint)( ( DateTime.Now.Year - 2000 ) << 24 | ( DateTime.Now.Month - 1 ) << 20 |
                ( DateTime.Now.Day - 1 ) << 14 | (byte)DateTime.Now.DayOfWeek << 11 |
                DateTime.Now.Hour << 6 | DateTime.Now.Minute );

            WriterStream.Write( (uint)xmitTime );
            WriterStream.Write( (float)0.01666667f );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerNewWorld 类 | en Word_PlayerNewWorld Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerNewWorld : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerNewWorld ()
            : base( (long)WordOpCode.SMSG_NEW_WORLD, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_NEW_WORLD );    // ID
            //////////////////////////////////////////////////////////////////////////

            //WriterStream.Write( (byte)ResponseCodes.RESPONSE_SUCCESS );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerTriggerCinematic 类 | en Word_PlayerTriggerCinematic Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerTriggerCinematic : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerTriggerCinematic( uint uiRaceCinematic )
            : base( (long)WordOpCode.SMSG_TRIGGER_CINEMATIC, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_TRIGGER_CINEMATIC );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (uint)uiRaceCinematic );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion

    #region zh-CHS Word_PlayerLoginFailedResponse 类 | en Word_PlayerLoginFailedResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_PlayerLoginFailedResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_PlayerLoginFailedResponse ( byte errorInfo )
            : base( (long)WordOpCode.SMSG_CHARACTER_LOGIN_FAILED, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );                  // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHARACTER_LOGIN_FAILED );    // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)errorInfo );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
