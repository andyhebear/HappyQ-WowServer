using System;
using Demo.Mmose.Core.Network;

namespace Demo.Wow.WorldServer.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMask
    {
        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valuesCount"></param>
        private void SetNewBitCount( int valuesCount )
        {
            m_BitCount = valuesCount;
            m_Blocks = ( valuesCount >> 5 ) + 1;

            if ( m_UpdateMask == null )
                m_UpdateMask = new uint[m_Blocks];
            else
                Array.Resize( ref m_UpdateMask, m_Blocks );
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valuesCount"></param>
        public UpdateMask( int valuesCount )
        {
            this.SetNewBitCount( valuesCount );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mask"></param>
        public UpdateMask( uint[] maskValues )
        {
            m_Blocks = maskValues.Length;
            m_UpdateMask = maskValues;
            m_BitCount = m_Blocks * 32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valuesCount"></param>
        public UpdateMask( UpdateFieldId valuesCount )
            : this( valuesCount.RawId )
        {
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_BitCount = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int BitCount
        {
            get { return m_BitCount; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_Blocks = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int BlockCount
        {
            get { return m_Blocks; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint[] m_UpdateMask;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint[] Blocks
        {
            get { return m_UpdateMask; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_LowestUpdatedIndex = int.MaxValue;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int LowestUpdatedIndex
        {
            get { return m_LowestUpdatedIndex; }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private int m_HighestUpdatedIndex = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public int HighestUpdatedIndex
        {
            get { return m_HighestUpdatedIndex; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void SetBit( int iIndex )
        {
            m_UpdateMask[iIndex >> 5] |= (uint)( 1 << ( iIndex & 31 ) );

            if ( iIndex > m_HighestUpdatedIndex )
                m_HighestUpdatedIndex = iIndex;

            if ( iIndex < m_LowestUpdatedIndex )
                m_LowestUpdatedIndex = iIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void UnsetBit( int iIndex )
        {
            m_UpdateMask[iIndex >> 5] &= ~(uint)( 1 << ( iIndex & 31 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetBit( int iIndex )
        {
            return ( m_UpdateMask[iIndex >> 5] & (uint)( 1 << ( iIndex & 31 ) ) ) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetAll()
        {
            for ( int iIndex = 0; iIndex < m_Blocks; iIndex++ )
                m_UpdateMask[iIndex] = uint.MaxValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            m_HighestUpdatedIndex = 0;
            m_LowestUpdatedIndex = int.MaxValue;

            m_UpdateMask = new uint[m_Blocks];
        }

        /// <summary>
        /// Writes only the required blocks to the packet
        /// </summary>
        /// <param name="packet">The packet to write to</param>
        /// <param name="highestValue">The highest updated value in the mask</param>
        public void WriteToPacked( Packet packet )
        {
            int iBlockCount = ( m_HighestUpdatedIndex >> 5 ) + 1;

            packet.WriterStream.Write( (byte)iBlockCount );

            for ( int iIndex = 0; iIndex < iBlockCount; iIndex++ )
                packet.WriterStream.Write( (uint)m_UpdateMask[iIndex] );
        }
        #endregion
    }
}
