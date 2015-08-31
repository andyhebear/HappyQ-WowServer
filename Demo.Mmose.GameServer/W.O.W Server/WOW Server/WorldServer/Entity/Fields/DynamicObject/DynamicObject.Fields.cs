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
    public partial class DynamicObjectField
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityId m_Caster = EntityId.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityId Caster
        {
            get { return m_Caster; }
            internal set
            {
                m_Caster = value;
                SetEntityId( (int)DynamicObjectFields.CASTER, m_Caster );
            }
        }

        #region DynamicObjectFields.BYTES

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private byte[] m_Bytes = new byte[4];
        #endregion
        /// <summary>
        /// 
        /// </summary>
        protected internal byte[] Bytes
        {
            get { return m_Bytes; }
            internal set
            {
                m_Bytes = value;
                SetByteArray( (int)DynamicObjectFields.BYTES, m_Bytes );
            }
        }

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_SpellId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint SpellId
        {
            get { return m_SpellId; }
            internal set
            {
                m_SpellId = value;
                SetUInt32( (int)DynamicObjectFields.SPELLID, m_SpellId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_Radius = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        protected internal float Radius
        {
            get { return m_Radius; }
            internal set
            {
                m_Radius = value;
                SetFloat( (int)DynamicObjectFields.RADIUS, m_Radius );
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
        protected internal float PosX
        {
            get { return m_PosX; }
            internal set
            {
                m_PosX = value;
                SetFloat( (int)DynamicObjectFields.POS_X, m_PosX );
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
        protected internal float PosY
        {
            get { return m_PosY; }
            internal set
            {
                m_PosY = value;
                SetFloat( (int)DynamicObjectFields.POS_Y, m_PosY );
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
        protected internal float PosZ
        {
            get { return m_PosZ; }
            internal set
            {
                m_PosZ = value;
                SetFloat( (int)DynamicObjectFields.POS_Z, m_PosZ );
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
        protected internal float Facing
        {
            get { return m_Facing; }
            internal set
            {
                m_Facing = value;
                SetFloat( (int)DynamicObjectFields.FACING, m_Facing );
            }
        }
    }
}
