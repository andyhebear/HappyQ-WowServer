using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CorpseField
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityId m_Owner = EntityId.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityId Owner
        {
            get { return m_Owner; }
            set
            {
                m_Owner = value;
                SetEntityId( (int)CorpseFields.OWNER, m_Owner );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Facing = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float Facing
        {
            get { return m_Facing; }
            set
            {
                m_Facing = value;
                SetFloat( (int)CorpseFields.FACING, m_Facing );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PosX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PosX
        {
            get { return m_PosX; }
            set
            {
                m_PosX = value;
                SetFloat( (int)CorpseFields.POS_X, m_PosX );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PosY = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PosY
        {
            get { return m_PosY; }
            set
            {
                m_PosY = value;
                SetFloat( (int)CorpseFields.POS_Y, m_PosY );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_PosZ = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float PosZ
        {
            get { return m_PosZ; }
            set
            {
                m_PosZ = value;
                SetFloat( (int)CorpseFields.POS_Z, m_PosZ );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_DisplayId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint DisplayId
        {
            get { return m_DisplayId; }
            set
            {
                m_DisplayId = value;
                SetUInt32( (int)CorpseFields.DISPLAY_ID, m_DisplayId );
            }
        }

        #region zh-CHS CorpseFields.ITEM | en CorpseFields.ITEM

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ItemBase = 0;
        #endregion
        /// <summary>
        /// Array of 19 uints
        /// TODO: Set the equipment of the player
        /// </summary>
        public uint Item01
        {
            get { return m_ItemBase; }
            set
            {
                m_ItemBase = value;
                SetUInt32( (int)CorpseFields.ITEM, m_ItemBase );
            }
        }

        #endregion

        #region BYTES_1

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Bytes1 = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] Bytes1
        {
            get { return m_Bytes1; }
            set
            {
                m_Bytes1 = value;
                SetByteArray( (int)CorpseFields.BYTES_1, m_Bytes1 );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte Bytes1_0
        {
            get { return m_Bytes1[0]; }
            set
            {
                m_Bytes1[0] = value;
                SetByte( (int)CorpseFields.BYTES_1, 0, m_Bytes1[0] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RaceType Race
        {
            get { return (RaceType)m_Bytes1[1]; }
            set
            {
                m_Bytes1[1] = (byte)value;
                SetByte( (int)CorpseFields.BYTES_1, 1, m_Bytes1[1] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GenderType Gender
        {
            get { return (GenderType)m_Bytes1[2]; }
            set
            {
                m_Bytes1[2] = (byte)value;
                SetByte( (int)CorpseFields.BYTES_1, 2, m_Bytes1[2] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte Skin
        {
            get { return m_Bytes1[3]; }
            set
            {
                m_Bytes1[3] = value;
                SetByte( (int)CorpseFields.BYTES_1, 3, m_Bytes1[3] );
            }
        }

        #endregion

        #region BYTES_2

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Bytes2 = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public byte[] Bytes2
        {
            get { return m_Bytes2; }
            set
            {
                m_Bytes2 = value;
                SetByteArray( (int)CorpseFields.BYTES_2, m_Bytes2 );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte Face
        {
            get { return m_Bytes2[0]; }
            set
            {
                m_Bytes2[0] = value;
                SetByte( (int)CorpseFields.BYTES_2, 0, m_Bytes2[0] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte HairStyle
        {
            get { return m_Bytes2[1]; }
            set
            {
                m_Bytes2[1] = value;
                SetByte( (int)CorpseFields.BYTES_2, 1, m_Bytes2[1] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte HairColor
        {
            get { return m_Bytes2[2]; }
            set
            {
                m_Bytes2[2] = value;
                SetByte( (int)CorpseFields.BYTES_2, 2, m_Bytes2[2] );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte FacialHair
        {
            get { return m_Bytes2[3]; }
            set
            {
                m_Bytes2[3] = value;
                SetByte( (int)CorpseFields.BYTES_2, 3, m_Bytes2[3] );
            }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_GuildId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint GuildId
        {
            get { return m_GuildId; }
            set
            {
                m_GuildId = value;
                SetUInt32( (int)CorpseFields.GUILD, m_GuildId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CorpseFlags m_Flags = CorpseFlags.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CorpseFlags Flags
        {
            get { return m_Flags; }
            set
            {
                m_Flags = value;
                SetUInt32( (int)CorpseFields.FLAGS, (uint)m_Flags );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private CorpseDynamicFlags m_DynamicFlags = CorpseDynamicFlags.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public CorpseDynamicFlags DynamicFlags
        {
            get { return m_DynamicFlags; }
            set
            {
                m_DynamicFlags = value;
                SetUInt32( (int)CorpseFields.DYNAMIC_FLAGS, (uint)m_DynamicFlags );
            }
        }
    }
}
