using System;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Entity.Common;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BaseField
    {
        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityId m_EntityId = EntityId.Zero;
        #endregion
        /// <summary>
        ///  The entity ID of the object
        /// </summary>
        public EntityId EntityId
        {
            get { return m_EntityId; }
            internal set
            {
                m_EntityId = value;
                SetEntityId( (int)ObjectFields.GUID, m_EntityId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private ObjectTypes m_ObjectTypes = ObjectTypes.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public ObjectTypes Type
        {
            get { return m_ObjectTypes; }
            internal set
            {
                m_ObjectTypes = value;
                SetUInt32( (int)ObjectFields.TYPE, (uint)m_ObjectTypes );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_EntryId = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint EntryId
        {
            get { return m_EntryId; }
            internal set
            {
                m_EntryId = value;
                SetUInt32( (int)ObjectFields.ENTRY, m_EntryId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_ScaleX = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float ScaleX
        {
            get { return m_ScaleX; }
            set
            {
                m_ScaleX = value;
                SetFloat( (int)ObjectFields.SCALE_X, m_ScaleX );

                //if ( this is UnitField )
                //    ( (UnitField)this ).UpdateBoundingRadius();
            }
        }
        #endregion
    }
}
