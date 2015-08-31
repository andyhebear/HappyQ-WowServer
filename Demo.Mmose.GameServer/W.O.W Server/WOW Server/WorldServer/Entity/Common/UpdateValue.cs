using System;
using System.Runtime.InteropServices;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout( LayoutKind.Explicit, Size = 4 )]
    public struct UpdateValue
    {
        #region zh-CHS 共有成员变量 | en Public Member Variables
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public float Float;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public short Int16Low;
        [FieldOffset( 2 )]
        public short Int16High;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public int Int32;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public ushort UInt16Low;
        [FieldOffset( 2 )]
        public ushort UInt16High;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public uint UInt32;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public byte Byte0;
        [FieldOffset( 1 )]
        public byte Byte1;
        [FieldOffset( 2 )]
        public byte Byte2;
        [FieldOffset( 3 )]
        public byte Byte3;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateValue( float value )
        {
            this.Int32 = this.Int16High = this.Int16Low = 0;
            this.UInt32 = this.UInt16High = this.UInt16Low = 0;
            this.Byte0 = this.Byte1 = this.Byte2 = this.Byte3 = 0;

            this.Float = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateValue( int value )
        {
            this.Float = 0;
            this.Int16High = this.Int16Low = 0;
            this.UInt32 = this.UInt16High = this.UInt16Low = 0;
            this.Byte0 = this.Byte1 = this.Byte2 = this.Byte3 = 0;

            this.Int32 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateValue( uint value )
        {
            this.Float = 0;
            this.Int32 = this.Int16High = this.Int16Low = 0;
            this.UInt16High = this.UInt16Low = 0;
            this.Byte0 = this.Byte1 = this.Byte2 = this.Byte3 = 0;

            this.UInt32 = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public UpdateValue( byte[] value )
        {
            this.Float = 0;
            this.Int32 = this.Int16High = this.Int16Low = 0;
            this.UInt16High = this.UInt16Low = 0;
            this.Byte0 = this.Byte1 = this.Byte2 = this.Byte3 = 0;
            
            this.UInt32 = value.ConvertToUInt();
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// 
        /// </summary>
        public byte[] ByteArray
        {
            get { return this.UInt32.ToArrayInByte(); }
            set { this.UInt32 = value.ConvertToUInt(); }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte GetByte( int iIndex )
        {
            return (byte)( this.UInt32 >> ( iIndex * 8 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void SetByte( int iIndex, byte value )
        {
            // clear the old value
            this.UInt32 &= ~(uint)( 0xFF << ( iIndex * 8 ) );

            // add the new value
            this.UInt32 |= (uint)( value << ( iIndex * 8 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals( object value )
        {
            if ( value is UpdateValue )
                return this.UInt32 == ((UpdateValue)value).UInt32;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.UInt32.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 == valueB.UInt32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 != valueB.UInt32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator >( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 > valueB.UInt32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 < valueB.UInt32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator >=( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 >= valueB.UInt32;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <=( UpdateValue valueA, UpdateValue valueB )
        {
            return valueA.UInt32 <= valueB.UInt32;
        }
        #endregion
    }
}
