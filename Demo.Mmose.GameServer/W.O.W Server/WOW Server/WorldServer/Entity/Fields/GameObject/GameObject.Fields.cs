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
    public partial class GameObjectField
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private EntityId m_CreatedBy = EntityId.Zero;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public EntityId CreatedBy
        {
            get { return m_CreatedBy; }
            internal set
            {
                m_CreatedBy = value;
                SetEntityId( (int)GameObjectFields.CREATED_BY, m_CreatedBy );
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
            internal set
            {
                m_DisplayId = value;
                SetUInt32( (int)GameObjectFields.DISPLAYID, m_DisplayId );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectFlags m_Flags = GameObjectFlags.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectFlags Flags
        {
            get { return m_Flags; }
            internal set
            {
                m_Flags = value;
                SetUInt32( (int)GameObjectFields.FLAGS, (uint)m_Flags );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_RotationA = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float RotationA
        {
            get { return m_RotationA; }
            internal set
            {
                m_RotationA = value;
                SetFloat( (int)GameObjectFields.ROTATION, m_RotationA );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_RotationB = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float RotationB
        {
            get { return m_RotationB; }
            internal set
            {
                m_RotationB = value;
                SetFloat( (int)GameObjectFields.ROTATION_2, m_RotationB );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_RotationC = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float RotationC
        {
            get { return m_RotationC; }
            internal set
            {
                m_RotationC = value;
                SetFloat( (int)GameObjectFields.ROTATION_3, m_RotationC );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private float m_RotationD = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public float RotationD
        {
            get { return m_RotationD; }
            internal set
            {
                m_RotationD = value;
                SetFloat( (int)GameObjectFields.ROTATION_4, m_RotationD );
            }
        }

        #region zh-CHS GameObjectFields.STATE | en GameObjectFields.STATE

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private bool m_IsState = false;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public bool IsState
        {
            get { return m_IsState; }
            internal set
            {
                m_IsState = value;
                SetUInt32( (int)GameObjectFields.STATE, (uint)( m_IsState == true ? 1 : 0 ) );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectState m_State = GameObjectState.Diabled;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectState State
        {
            get { return m_State; }
            internal set
            {
                m_State = value;
                SetUInt32( (int)GameObjectFields.STATE, (uint)m_State );
            }
        }

        #endregion

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
            internal set
            {
                m_PosX = value;
                SetFloat( (int)GameObjectFields.POS_X, m_PosX );
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
            internal set
            {
                m_PosY = value;
                SetFloat( (int)GameObjectFields.POS_Y, m_PosY );
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
            internal set
            {
                m_PosZ = value;
                SetFloat( (int)GameObjectFields.POS_Z, m_PosZ );
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
            internal set
            {
                m_Facing = value;
                SetFloat( (int)GameObjectFields.FACING, m_Facing );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectDynamicFlags m_DynamicFlags = GameObjectDynamicFlags.Deactivated;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectDynamicFlags DynamicFlags
        {
            get { return m_DynamicFlags; }
            internal set
            {
                m_DynamicFlags = value;
                SetUInt32( (int)GameObjectFields.DYN_FLAGS, (uint)m_DynamicFlags );
            }
        }

        #region zh-CHS GameObjectFields.FACTION | en GameObjectFields.FACTION

        ///// <summary>
        ///// 
        ///// </summary>
        //private Faction m_Faction;
        ///// <summary>
        ///// 
        ///// </summary>
        //public override Faction Faction
        //{
        //    get { return m_Faction; }
        //    internal set
        //    {
        //        m_Faction = value;
        //        //SetUInt32( (int)GameObjectFields.FACTION, (uint)value.Template.Id );
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public override FactionId FactionId
        //{
        //    get { return m_Faction.Id; }
        //    internal set
        //    {
        //        Faction fac = FactionMgr.Get( value );
        //        if ( fac != null )
        //            Faction = fac;

        //        // what to do if faction doesn't exist?
        //    }
        //}

        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private GameObjectType m_GOType = GameObjectType.None;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public GameObjectType GOType
        {
            get { return m_GOType; }
            internal set
            {
                m_GOType = value;
                SetUInt32( (int)GameObjectFields.TYPE_ID, (uint)m_GOType );
            }
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
            internal set
            {
                m_Level = value;
                SetUInt32( (int)GameObjectFields.LEVEL, m_Level );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_ArtKit = 0;
        #endregion
        /// <summary>
        /// No idea
        /// </summary>
        public uint ArtKit
        {
            get { return m_ArtKit; }
            internal set
            {
                m_ArtKit = value;
                SetUInt32( (int)GameObjectFields.ARTKIT, m_ArtKit );
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_AnimationProgress = 0;
        #endregion
        /// <summary>
        /// Seems to be 0 or 100 mostly
        /// </summary>
        public uint AnimationProgress
        {
            get { return m_AnimationProgress; }
            internal set
            {
                m_AnimationProgress = value;
                SetUInt32( (int)GameObjectFields.ANIMPROGRESS, m_AnimationProgress ); 
            }
        }
    }
}
