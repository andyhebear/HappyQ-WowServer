using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Item;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Network
{
    //FOR 1.10.1
    //SMSG_CHAR_CREATE Error Codes:
    //0x00 Success
    //0x01 Failure
    //0x02 Canceled
    //0x03 Disconnect from server
    //0x04 Failed to connect
    //0x05 Connected
    //0x06 Wrong client version
    //0x07 Connecting to server
    //0x08 Negotiating security
    //0x09 Negotiating security complete
    //0x0A Negotiating security failed
    //0x0B Authenticating
    //0x0C Authentication successful
    //0x0D Authentication failed
    //0x0E Login unavailable - Please contact Tech Support
    //0x0F Server is not valid
    //0x10 System unavailable 
    //0x11 System error
    //0x12 Billing system error
    //0x13 Account billing has expired
    //0x14 Wrong client version
    //0x15 Unknown account
    //0x16 Incorrect password
    //0x17 Session expired
    //0x18 Server Shutting Down
    //0x19 Already logged in
    //0x1A Invalid login server
    //0x1B Position in Queue: 0
    //0x1C This account has been banned
    //0x1D This character is still logged on
    //0x1E Your Wow subscription has expired
    //0x1F This session has timed out
    //0x20 This account has been temporarily suspended
    //0x21 Access to this account blocked by parental controls 
    //0x22 Retrieving realmlist
    //0x23 Realmlist retrieved
    //0x24 Unable to connect to realmlist server
    //0x25 Invalid realmlist
    //0x26 The game server is currently down
    //0x27 Creating account
    //0x28 Account created
    //0x29 Account creation failed
    //0x2A Retrieving character list
    //0x2B Character list retrieved
    //0x2C Error retrieving character list
    //0x2D Creating character
    //0x2E Character created
    //0x2F Error creating character
    //0x30 Character creation failed
    //0x31 That name is unavailable
    //0x32 Creation of that race/class is disabled
    //0x33 You cannot have both horde and alliance character at pvp realm
    //0x33 All characters on a PVP realm must be on the same team
    //0x34 You already have maximum number of characters
    //0x35 You already have maximum number of characters
    //0x36 The server is currently queued
    //0x37 Only players who have characters on this realm..
    //0x38 Creation of that race requires an account that has been upgraded to the approciate expansion
    //0x39 Deleting character
    //0x3A Character deleted
    //0x3B Char deletion failed
    //0x3c Entering world of warcraft
    //0x3D Login successful
    //0x3E World server is down
    //0x3F A character with that name already exists
    //0x40 No instance server available
    //0x41 Login failed
    //0x42 Login for that race/class is disabled
    //0x43 Character not found
    //0x44 Enter a name for your character
    //0x45 Names must be atleast 2 characters long
    //0x46 Names must be no more then 12 characters
    //0x47 Names can only contain letters
    //0x48 Names must contain only one language
    //0x49 That name contains profanity
    //0x4A That name is unavailable
    //0x4B You cannot use an apostrophe
    //0x4C You can only have one apostrophe
    //0x4D You cannot use the same letter three times consecutively
    //0x4E You cannit use space as the first or last character of your name
    //0x4F <Blank>
    //0x50 Invalid character name
    //0x51 <Blank>
    //All further codes give the number in dec.

    /// <summary>
    /// 
    /// </summary>
    internal class WowCharEnumCharacterInfo
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ulong m_iCharacterGUID = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ulong CharacterGuid
        {
            get { return m_iCharacterGUID; }
            set { m_iCharacterGUID = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_GuildGuid = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint GuildGuid
        {
            get { return m_GuildGuid; }
            set { m_GuildGuid = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private string m_Name = string.Empty;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Level = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Race = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Race
        {
            get { return m_Race; }
            set { m_Race = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Class = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Class
        {
            get { return m_Class; }
            set { m_Class = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ZoneId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint ZoneId
        {
            get { return m_ZoneId; }
            set { m_ZoneId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_MapId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint MapId
        {
            get { return m_MapId; }
            set { m_MapId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionX
        {
            get { return m_PositionX; }
            set { m_PositionX = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionY = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionY
        {
            get { return m_PositionY; }
            set { m_PositionY = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PositionZ = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PositionZ
        {
            get { return m_PositionZ; }
            set { m_PositionZ = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Gender = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Gender
        {
            get { return m_Gender; }
            set { m_Gender = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Skin = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Skin
        {
            get { return m_Skin; }
            set { m_Skin = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Face = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Face
        {
            get { return m_Face; }
            set { m_Face = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_HairStyle = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HairStyle
        {
            get { return m_HairStyle; }
            set { m_HairStyle = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_HairColor = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint HairColor
        {
            get { return m_HairColor; }
            set { m_HairColor = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_FacialHair = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint FacialHair
        {
            get { return m_FacialHair; }
            set { m_FacialHair = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsHideHelm;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsHideHelm
        {
            get { return m_IsHideHelm; }
            set { m_IsHideHelm = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsHideCloak;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsHideCloak
        {
            get { return m_IsHideCloak; }
            set { m_IsHideCloak = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsGhost;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsGhost
        {
            get { return m_IsGhost; }
            set { m_IsGhost = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsNeedRename;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsNeedRename
        {
            get { return m_IsNeedRename; }
            set { m_IsNeedRename = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowCharEnumPetInfo m_PetInfo = new WowCharEnumPetInfo();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowCharEnumPetInfo PetInfo
        {
            get { return m_PetInfo; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private WowItemTemplate[] m_Equipment = new WowItemTemplate[EquipmentSlot.EquipmentSlotEnd];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WowItemTemplate[] Equipment
        {
            get { return m_Equipment; }
        }
        #endregion
    }

    internal class WowCharEnumPetInfo
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetModelId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetModelId
        {
            get { return m_PetModelId; }
            set { m_PetModelId = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetLevel;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetLevel
        {
            get { return m_PetLevel; }
            set { m_PetLevel = value; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_PetFamily;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint PetFamily
        {
            get { return m_PetFamily; }
            set { m_PetFamily = value; }
        }
    }

    #region zh-CHS Word_CharEnumResponse 类 | en Word_CharEnumResponse Class
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Word_CharEnumResponse : Packet
    {
        /// <summary>
        /// 
        /// </summary>
        public Word_CharEnumResponse( WowCharEnumCharacterInfo[] characterInfoArray )
            : base( (long)WordOpCode.SMSG_CHAR_ENUM, 0 )
        {
            WriterStream.Write( (ushort)0 /* 2 + ? */ );              // Size
            WriterStream.Write( (ushort)WordOpCode.SMSG_CHAR_ENUM );  // ID
            //////////////////////////////////////////////////////////////////////////

            WriterStream.Write( (byte)characterInfoArray.Length );

            if ( characterInfoArray.Length > 0 )
            {
                foreach ( WowCharEnumCharacterInfo wowCharacterInfo in characterInfoArray )
                {
                    WriterStream.Write( (ulong)wowCharacterInfo.CharacterGuid );
                    WriterStream.WriteUTF8Null( (string)wowCharacterInfo.Name );

                    WriterStream.Write( (byte)wowCharacterInfo.Race );
                    WriterStream.Write( (byte)wowCharacterInfo.Class );
                    WriterStream.Write( (byte)wowCharacterInfo.Gender );

                    WriterStream.Write( (byte)wowCharacterInfo.Skin );
                    WriterStream.Write( (byte)wowCharacterInfo.Face );
                    WriterStream.Write( (byte)wowCharacterInfo.HairStyle );
                    WriterStream.Write( (byte)wowCharacterInfo.HairColor );
                    WriterStream.Write( (byte)wowCharacterInfo.FacialHair );

                    WriterStream.Write( (byte)wowCharacterInfo.Level );

                    WriterStream.Write( (uint)wowCharacterInfo.ZoneId );
                    WriterStream.Write( (uint)wowCharacterInfo.MapId );

                    WriterStream.Write( (float)wowCharacterInfo.PositionX );
                    WriterStream.Write( (float)wowCharacterInfo.PositionY );
                    WriterStream.Write( (float)wowCharacterInfo.PositionZ );

                    WriterStream.Write( (uint)wowCharacterInfo.GuildGuid );

                    WriterStream.Write( (byte)0 );
                    // 0x01
                    // 0x02
                    // 0x04 - CHAR_LOGIN_LOCKED_FOR_TRANSFER
                    // 0x08
                    // 0x10
                    // 0x20
                    // 0x40

                    byte iFlags = 0;
                    if ( wowCharacterInfo.IsHideHelm == true )
                        iFlags |= 0x04;
                    if ( wowCharacterInfo.IsHideCloak == true )
                        iFlags |= 0x08;
                    if ( wowCharacterInfo.IsGhost == true )
                        iFlags |= 0x20;
                    if ( wowCharacterInfo.IsNeedRename == true )
                        iFlags |= 0x40;
                    WriterStream.Write( (byte)iFlags );

                    WriterStream.Write( (byte)0xA0 ); // unknown

                    WriterStream.Write( (byte)0 ); // unknown
                    // 0x01 - CHAR_LOGIN_LOCKED_BY_BILLING

                    WriterStream.Write( (byte)1 ); // unknown

                    if ( wowCharacterInfo.PetInfo!= null )
                    {
                        WriterStream.Write( (uint)wowCharacterInfo.PetInfo.PetModelId );
                        WriterStream.Write( (uint)wowCharacterInfo.PetInfo.PetLevel );
                        WriterStream.Write( (uint)wowCharacterInfo.PetInfo.PetFamily );
                    }
                    else
                    {
                        WriterStream.Write( (uint)0 );
                        WriterStream.Write( (uint)0 );
                        WriterStream.Write( (uint)0 );
                    }

                    for ( int iIndex = 0; iIndex < wowCharacterInfo.Equipment.Length; iIndex++ )
                    {
                        if ( wowCharacterInfo.Equipment[iIndex] != null )
                        {
                            WriterStream.Write( (uint)wowCharacterInfo.Equipment[iIndex].ModelID );
                            WriterStream.Write( (byte)wowCharacterInfo.Equipment[iIndex].InventoryType );
                        }
                        else
                        {
                            WriterStream.Write( (uint)0 );
                            WriterStream.Write( (byte)0 );
                        }
                    }

                    WriterStream.Write( (uint)0 ); // first bag display id
                    WriterStream.Write( (byte)0 ); // first bag inventory type
                }
            }

            //byte[] nnn = new byte[] { 
            //     0xD0, 0xF0, 0x4C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x61, 0x69, 0x68, 0x75, 0x61, 0x6E, 0x71, 0x69, 0x6E, 0x67, 0x00, 0x0A, 0x02, 0x01, 0x00, 0x03, 0x09, 0x05, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x12, 0x02, 0x00, 0x00, 0x66, 0xB6, 0x21, 0x46, 0x52, 0xAA, 0xC6, 0xC5, 0x43, 0x9C, 0x05, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB5, 0x8F, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB6, 0x8F, 0x00, 0x00, 0x07, 0xB9, 0x8F, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x09, 0x00, 0x00, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            //};

            //WriterStream.Write( nnn, 0, nnn.Length );

            //////////////////////////////////////////////////////////////////////////
            WriterStream.Seek( 0, SeekOrigin.Begin );
            WriterStream.Write( (ushort)ByteOrder.NetToHost( (ushort)( WriterStream.Length - 2/*Size本身的大小*/ ) ) );
        }
    }
    #endregion
}
