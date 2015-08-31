using System;
using System.Collections.Generic;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Entity.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseField
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        public BaseField()
        {
            m_UpdateValues = new UpdateValue[this.ObjectUpdateFieldCount];

            m_PrivateUpdateMask = new UpdateMask( this.ObjectUpdateFieldCount );
            m_PublicUpdateMask = new UpdateMask( this.ObjectUpdateFieldCount );

            this.Type = ObjectTypes.Object;
            this.ScaleX = 1.0f;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private UpdateValue[] m_UpdateValues;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UpdateValue[] UpdateValues
        {
            get { return m_UpdateValues; }
        }

        #region zh-CHS PrivateUpdateMask属性 | en PrivateUpdateMask Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile UpdateMask m_PrivateUpdateMask = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UpdateMask PrivateUpdateMask
        {
            get { return m_PrivateUpdateMask; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal UpdateMask ResumePrivateUpdateMask()
        {
            UpdateMask privateUpdateMask = new UpdateMask( this.ObjectUpdateFieldCount );
            UpdateMask returnUpdateMask = m_PrivateUpdateMask;

            // 快速交换，避免多线程问题
            m_PrivateUpdateMask = privateUpdateMask;

            return returnUpdateMask;
        }
        #endregion

        #endregion

        #region zh-CHS PublicUpdateMask属性 | en PublicUpdateMask Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile UpdateMask m_PublicUpdateMask = null;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UpdateMask PublicUpdateMask
        {
            get { return m_PublicUpdateMask; }
        }

        #region zh-CHS 内部方法 | en Internal Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal UpdateMask ResumePublicUpdateMask()
        {
            UpdateMask publicUpdateMask = new UpdateMask( this.ObjectUpdateFieldCount );
            UpdateMask returnUpdateMask = m_PublicUpdateMask;

            // 快速交换，避免多线程问题
            m_PublicUpdateMask = publicUpdateMask;

            return returnUpdateMask;
        }
        #endregion

        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public abstract UpdateFlag UpdateFlags { get; }

        /// <summary>
        /// The type of this object (player, corpse, item, etc)
        /// </summary>
        public abstract ObjectTypeId ObjectTypeId { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract UpdateFieldCollection UpdateFieldInfos { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatingSelf"></param>
        /// <returns></returns>
        public abstract UpdateTypes GetCreationUpdateType( bool updatingSelf );

        /// <summary>
        /// 
        /// </summary>
        public static readonly UpdateFieldId s_ObjectFieldCount = Demo.Wow.WorldServer.Util.Utility.GetMaxEnumValue<ObjectFields>() + 1;

        /// <summary>
        /// 
        /// </summary>
        public virtual UpdateFieldId ObjectUpdateFieldCount
        {
            get { return s_ObjectFieldCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ObjectTypeCustom CustomType
        {
            get { return ObjectTypeCustom.Object; }
        }

        #region zh-CHS 共有方法 | en Public Methods

        #region Get

        protected float GetFloat( int iField )
        {
            return m_UpdateValues[iField].Float;
        }

        protected short GetInt16Low( int iField )
        {
            return m_UpdateValues[iField].Int16Low;
        }

        protected short GetInt16High( int iField )
        {
            return m_UpdateValues[iField].Int16High;
        }

        protected ushort GetUInt16Low( int iField )
        {
            return m_UpdateValues[iField].UInt16Low;
        }

        protected ushort GetUInt16High( int iField )
        {
            return m_UpdateValues[iField].UInt16High;
        }

        protected int GetInt32( int iField )
        {
            return m_UpdateValues[iField].Int32;
        }

        protected uint GetUInt32( int iField )
        {
            return m_UpdateValues[iField].UInt32;
        }

        protected ulong GetUInt64( int iField )
        {
            uint uiLow = m_UpdateValues[iField].UInt32;
            uint uiHigh = m_UpdateValues[iField + 1].UInt32;

            return (ulong)( uiLow | ( uiHigh << 32 ) );
        }

        protected EntityId GetEntityId( int iField )
        {
            return new EntityId( m_UpdateValues[iField].UInt32, m_UpdateValues[iField + 1].UInt32 );
        }

        protected byte[] GetByteArray( int iField )
        {
            return m_UpdateValues[iField].ByteArray;
        }

        protected byte GetByte( int iField, int iIndex )
        {
            return m_UpdateValues[iField].GetByte( iIndex );
        }

        #endregion

        #region Set

        protected void SetFloat( int iField, float fValue )
        {
            if ( m_UpdateValues[iField].Float == fValue )
                return;

            m_UpdateValues[iField].Float = fValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetInt16Low( int iField, short sValue )
        {
            if ( m_UpdateValues[iField].Int16Low == sValue )
                return;

            m_UpdateValues[iField].Int16Low = sValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetInt16High( int iField, short sValue )
        {
            if ( m_UpdateValues[iField].Int16High == sValue )
                return;

            m_UpdateValues[iField].Int16High = sValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetUInt16Low( int iField, ushort usValue )
        {
            if ( m_UpdateValues[iField].UInt16Low == usValue )
                return;

            m_UpdateValues[iField].UInt16Low = usValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetUInt16High( int iField, ushort usValue )
        {
            if ( m_UpdateValues[iField].UInt16High == usValue )
                return;

            m_UpdateValues[iField].UInt16High = usValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetInt32( int iField, int iValue )
        {
            if ( m_UpdateValues[iField].Int32 == iValue )
                return;

            m_UpdateValues[iField].Int32 = iValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetUInt32( int iField, uint uiValue )
        {
            if ( m_UpdateValues[iField].UInt32 == uiValue )
                return;

            m_UpdateValues[iField].UInt32 = uiValue;

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        protected void SetULong64( int iField, ulong ulValue )
        {
            SetUInt32( iField, (uint)( ulValue & 0xFFFFFFFF ) );
            SetUInt32( iField + 1, (uint)( ulValue >> 32 ) );
        }

        protected void SetEntityId( int iField, EntityId entityId )
        {
            SetUInt32( iField, entityId.Low );
            SetUInt32( iField + 1, entityId.High );
        }

        protected void SetByteArray( int iField, byte[] byteValue )
        {
            SetUInt32( iField, byteValue.ConvertToUInt() );
        }

        /// <summary>
        /// Sets a specified byte of an updatefield to the specified value
        /// </summary>
        /// <param name="field">The field to set</param>
        /// <param name="value">The value to set</param>
        /// <param name="index">The index of the byte in the 4-byte field. (Ranges from 0-3)</param>
        protected void SetByte( int iField, int iIndex, byte byValue )
        {
            if ( m_UpdateValues[iField].GetByte( iIndex ) == byValue )
                return;

            m_UpdateValues[iField].SetByte( iIndex, byValue );

            m_PrivateUpdateMask.SetBit( iField );
            if ( VisibilityManager.IsPublicField( iField ) == true )
                m_PublicUpdateMask.SetBit( iField );

            OnRequestUpdate();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.GetType().Name + " (ID: " + EntityId + ")";
        }

        #endregion

        #region zh-CHS 共有事件 | en Public Event
        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void OnRequestUpdate()
        {
            RequestUpdateEventHandler tempEvent = EventRequestUpdate;
            if ( tempEvent != null )
                tempEvent();
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public event RequestUpdateEventHandler EventRequestUpdate;
        #endregion
    }
}
