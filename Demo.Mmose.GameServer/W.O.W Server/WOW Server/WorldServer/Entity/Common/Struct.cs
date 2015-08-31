using System.Runtime.InteropServices;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Network;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.Entity.Common
{
    /// <summary>
    /// An 8-byte ID, which World of Warcraft uses to identify world entities.
    /// </summary>
    [StructLayout( LayoutKind.Explicit, Size = 8 )]
    public struct EntityId
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// A null EntityId.
        /// </summary>
        public static readonly EntityId Zero = new EntityId( 0, 0 );
        #endregion

        #region zh-CHS 共有成员变量 | en Public Member Variables
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public int Int32Low;
        [FieldOffset( 4 )]
        public int Int32High;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public long Long64;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset( 0 )]
        public uint UInt32Low;
        [FieldOffset( 4 )]
        public uint UInt32High;

        /// <summary>
        /// The full ID as an unsigned long.
        /// </summary>
        [FieldOffset( 0 )]
        public ulong ULong64;
        #endregion

        #region zh-CHS 构造和初始化和清理 | en Constructors and Initializers and Dispose
        /// <summary>
        /// Creates an EntityId from raw ID data.
        /// </summary>
        /// <param name="rawGuid">the raw ID data</param>
        public EntityId( byte[] rawGuid )
        {
            this.Long64 = this.Int32High = this.Int32Low = 0;
            this.UInt32Low = this.UInt32High = 0;

            this.ULong64 = rawGuid.ConvertToULong();
        }

        /// <summary>
        /// Creates an EntityId from the high and low parts of the full ID.
        /// </summary>
        /// <param name="guidLow">the low part of the ID (5th - 8th byte)</param>
        /// <param name="guidHigh">the high part of the ID (1st - 4th byte)</param>
        public EntityId( uint guidLow, uint guidHigh )
        {
            this.Long64 = this.Int32High = this.Int32Low = 0;
            this.ULong64 = 0;

            this.UInt32Low = guidLow;
            this.UInt32High = guidHigh;
        }

        /// <summary>
        /// Creates an EntityId from a single unsigned long.
        /// </summary>
        /// <param name="guid">the unsigned long representing the ID</param>
        public EntityId( ulong guid )
        {
            this.Long64 = this.Int32High = this.Int32Low = 0;
            this.UInt32Low = this.UInt32High = 0;

            this.ULong64 = guid;
        }

        /// <summary>
        /// Creates an EntityId from a single unsigned long.
        /// </summary>
        /// <param name="guid">the unsigned long representing the ID</param>
        public EntityId( Serial guid )
        {
            this.Int32High = this.Int32Low = 0;
            this.ULong64 = this.UInt32Low = this.UInt32High = 0;

            this.Long64 = guid.Value;
        }
        #endregion

        #region zh-CHS 共有属性 | en Public Properties
        /// <summary>
        /// The low part of the ID (5th - 8th byte)
        /// </summary>
        public uint Low
        {
            get { return this.UInt32Low; }
            set { this.UInt32High = value; }
        }

        /// <summary>
        /// The high part of the ID (1st - 4th byte)
        /// </summary>
        public uint High
        {
            get { return this.UInt32High; }
            set { this.UInt32High = value; }
        }

        /// <summary>
        /// The full ID as an unsigned long.
        /// </summary>
        public ulong Full
        {
            get { return this.ULong64; }
            set { this.ULong64 = value; }
        }

        /// <summary>
        /// Holds the raw ID.
        /// </summary>
        /// <summary>
        /// The full ID as an unsigned long.
        /// </summary>
        public byte[] ByteArray
        {
            get { return this.ULong64.ToArrayInByte(); }
            set { this.ULong64 = value.ConvertToULong(); }
        }

        /// <summary>
        /// The entity type represented by this ID.
        /// </summary>
        public EntityIdType Type
        {
            get { return (EntityIdType)this.UInt32High; }
        }
        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public int WritePacked( Packet packet )
        {
            byte byMask = 0;
            long byEndPosition = 0;
            long byStartPosition = packet.WriterStream.Position;
            byte[] byteArray = this.ByteArray;

            // 写入
            packet.WriterStream.Write( byMask );

            for ( int iIndex = 0; iIndex < byteArray.Length; iIndex++ )
            {
                byte byCheck = byteArray[iIndex];
                if ( byCheck != 0 )
                {
                    byMask |= (byte)( 1 << iIndex );
                    packet.WriterStream.Write( byCheck );
                }
            }

            byEndPosition = packet.WriterStream.Position;

            packet.WriterStream.Position = byStartPosition;
            packet.WriterStream.Write( byMask );
            packet.WriterStream.Position = byEndPosition;

            return (int)( byEndPosition - byStartPosition );
        }

        public override bool Equals( object value )
        {
            if ( value is EntityId )
                return this.ULong64 == ((EntityId)value).ULong64;

            return false;
        }

        /// <summary>
        /// Calculates a hash of the ID.
        /// </summary>
        /// <returns>a hash that uniquely represents this ID</returns>
        public override int GetHashCode()
        {
            return this.ULong64.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format( "Low:{0} - High:{1}", this.Low, this.High );
        }

        /// <summary>
        /// Converts an EntityId into its raw form.
        /// </summary>
        /// <param name="entityId">the input ID</param>
        /// <returns>the raw value of the ID</returns>
        public static implicit operator ulong( EntityId entityId )
        {
            return entityId.ULong64;
        }

        /// <summary>
        /// Converts an EntityId into its raw form.
        /// </summary>
        /// <param name="entityId">the input ID</param>
        /// <returns>the raw value of the ID</returns>
        public static implicit operator Serial( EntityId entityId )
        {
            return new Serial( entityId.Long64 );
        }

        /// <summary>
        /// Checks if two EntityIds matched.
        /// </summary>
        /// <param name="value1">the first EntityId to check.</param>
        /// <param name="value2">the second EntityId to check.</param>
        /// <returns></returns>
        public static bool operator ==( EntityId value1, EntityId value2 )
        {
            return value1.ULong64 == value2.ULong64;
        }

        /// <summary>
        /// Checks if an EntityId matched a raw GUID ulong value.
        /// </summary>
        /// <param name="value1">The EntityID to check.</param>
        /// <param name="value2">The ulong raw GUID to check.</param>
        /// <returns></returns>
        public static bool operator ==( EntityId value1, ulong value2 )
        {
            return value1.ULong64 == value2;
        }

        /// <summary>
        /// Checks if two EntityIds didn't match.
        /// </summary>
        /// <param name="value1">The first EntityId to check.</param>
        /// <param name="value2">The second EntityId to check.</param>
        /// <returns></returns>
        public static bool operator !=( EntityId value1, EntityId value2 )
        {
            return value1.ULong64 != value2.ULong64;
        }

        /// <summary>
        /// Checks if an EntityId didn't match a raw GUID ulong value.
        /// </summary>
        /// <param name="value1">The EntityID to check.</param>
        /// <param name="value2">The ulong raw GUID to check.</param>
        /// <returns></returns>
        public static bool operator !=( EntityId value1, ulong value2 )
        {
            return value1.ULong64 != value2;
        }
        #endregion

        #region zh-CHS 共有静态方法 | en Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetDynamicObjectId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.DynamicObject );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetCorpseId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.Corpse );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetGameObjectId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.GameObject );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetPlayerId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.Player );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetUnitId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.Unit );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowGuid"></param>
        /// <returns></returns>
        public static EntityId GetItemId( uint lowGuid )
        {
            return new EntityId( lowGuid, (uint)EntityIdType.Item );
        }
        #endregion
    }
}
