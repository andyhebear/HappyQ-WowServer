
namespace Demo.Wow.WorldServer.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public struct UpdateFieldId
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RawId"></param>
        public UpdateFieldId( int iRawId )
        {
            m_RawId = iRawId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( ObjectFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( UnitFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( PlayerFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( CorpseFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( ItemFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( ContainerFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( DynamicObjectFields value )
        {
            m_RawId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateFieldId( GameObjectFields value )
        {
            m_RawId = (int)value;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_RawId;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int RawId
        {
            get { return m_RawId; }
            set { m_RawId = value; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static explicit operator UpdateFieldId( int iRawId )
        {
            return new UpdateFieldId( iRawId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static implicit operator int( UpdateFieldId value )
        {
            return value.m_RawId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( ObjectFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( UnitFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( PlayerFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( CorpseFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( ItemFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( ContainerFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( DynamicObjectFields value )
        {
            return new UpdateFieldId( (int)value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static implicit operator UpdateFieldId( GameObjectFields value )
        {
            return new UpdateFieldId( (int)value );
        }
        #endregion
    }
}
