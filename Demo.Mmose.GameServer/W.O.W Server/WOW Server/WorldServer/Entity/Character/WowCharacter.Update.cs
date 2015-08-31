using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Wow.WorldServer.Entity.Fields;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Network;
using Demo.Wow.WorldServer.Entity;
using Demo.Mmose.Core.Entity;
using Demo.Wow.WorldServer.Item;
using Demo.Wow.WorldServer.Network;
using Demo.Wow.WorldServer.Entity.Common;
using Demo.Wow.WorldServer.Util;
using Demo.Mmose.Core.Common.Component;
using System.Threading;
using Demo.Mmose.Core.Util;
using Demo.Mmose.Core.Common.Collections;
using Demo.Wow.WorldServer.Server;

namespace Demo.Wow.WorldServer.Character
{
    public partial class WowCharacter : IWowUpdate
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static int BROAD_CAST_RANGE = 100;

        #region zh-CHS ISupportSlice接口实现 | en ISupportSlice Interface Implementation

        #region zh-CHS 私有方法 | en Private Methods
        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="bUpdatingSelf"></param>
        private void WriteUpdateMaskForValueUpdate( Packet packet )
        {
            UpdateMask updateMask = this.PlayerField.PrivateUpdateMask;

            updateMask.WriteToPacked( packet );

            for ( int iIndex = 0; iIndex <= this.PlayerField.PrivateUpdateMask.HighestUpdatedIndex; iIndex++ )
            {
                if ( updateMask.GetBit( iIndex ) == true )
                    packet.WriterStream.Write( (uint)this.PlayerField.UpdateValues[iIndex].UInt32 );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="updatingSelf"></param>
        private void WriteObjectValueUpdate( Packet packet, bool updatingSelf )
        {
            packet.WriterStream.Write( (byte)UpdateTypes.Values );

            EntityId entityId = new EntityId( this.Serial );
            entityId.WritePacked( packet );

            WriteUpdateMaskForValueUpdate( packet );
        }
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void ResetUpdateInfo()
        {
            //this.PlayerField.UpdateMask.Clear();
            m_QueuedForUpdate = false;

            //this.PlayerField.HighestUpdatedPublicIndex = 0;
            //this.PlayerField.LowestUpdatedPublicIndex = this.PlayerField.UpdateMask.BitCount;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public virtual void BroadcastValueUpdate()
        {
            if ( m_isInWorld == false )
                return;

            // 广播周围的数据
            if ( m_KnownCharacters.Count > 0 )
            {
                foreach ( WowCharacter character in m_KnownCharacters )
                {
                    if ( character.KnowsOf( this ) == true )
                    {
                        MemoryPacket updatePacket = new MemoryPacket();
                        WriteObjectValueUpdate( updatePacket, false );
                        character.AddUpdateData( updatePacket, 1 );
                    }
                }
            }

            // 添加自己的数据
            MemoryPacket selfPacket = new MemoryPacket();
            WriteObjectValueUpdate( selfPacket, true );
            AddUpdateData( selfPacket, 1 );

            ResetUpdateInfo();
        }

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="updatingSelf"></param>
        private void WriteMovementUpdate( Packet packet, bool updatingSelf )
        {
            // Should be 0x10 | 0x20 | 0x40 for 2.1.3
            UpdateFlag updateFlags = this.PlayerField.UpdateFlags;

            if ( updatingSelf == true )
            {
                updateFlags |= UpdateFlag.Self;
            }

            packet.WriterStream.Write( (byte)updateFlags );

            MovementFlags moveFlags = MovementFlags.None;

            if ( m_IsSpiritHealer == true )
            {
                moveFlags |= MovementFlags.Waterwalking;
            }

            #region Living

            packet.WriterStream.Write( (uint)moveFlags );
            // new in 2.3.0
            packet.WriterStream.Write( (byte)0 );
            packet.WriterStream.Write( (uint)Environment.TickCount );

            #endregion

            #region Position

            packet.WriterStream.Write( (float)base.X );
            packet.WriterStream.Write( (float)base.Y );
            packet.WriterStream.Write( (float)base.Z );
            packet.WriterStream.Write( (float)base.O );

            #endregion

            packet.WriterStream.Write( (int)0 );

            #region Speed Block

            packet.WriterStream.Write( (float)m_UnitMechanics.WalkSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.RunSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.SwimBackSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.SwimSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.WalkBackSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.FlightSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.FlightBackSpeed );
            packet.WriterStream.Write( (float)m_UnitMechanics.TurnSpeed );

            #endregion

            /*#region Spline

            if ((moveFlags & MovementFlags.SplineTaxi) == MovementFlags.SplineTaxi)
            {
                SplineFlags splineFlags = SplineFlags.None;
            }

            #endregion*/

            #region UpdateFlag.Flag_0x10

            packet.WriterStream.Write( (uint)0 );

            #endregion
        }
        #endregion

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="bUpdatingSelf"></param>
        private void WriteUpdateMaskForCreation( Packet packet )
        {
            UpdateMask updateMask = new UpdateMask( this.PlayerField.PrivateUpdateMask.Blocks );

            for ( int iIndex = 0; iIndex < this.PlayerField.UpdateValues.Length; iIndex++ )
            {
                if ( this.PlayerField.UpdateValues[iIndex].UInt32 != 0 )
                    updateMask.SetBit( iIndex );
            }

            updateMask.WriteToPacked( packet );

            for ( int iIndex = 0; iIndex <= updateMask.HighestUpdatedIndex; iIndex++ )
            {
                if ( updateMask.GetBit( iIndex ) == true )
                    packet.WriterStream.Write( (uint)this.PlayerField.UpdateValues[iIndex].UInt32 );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="updatingSelf"></param>
        public void ObjectCreationUpdate( Packet writer, bool updatingSelf )
        {
            writer.WriterStream.Write( (byte)this.PlayerField.GetCreationUpdateType( updatingSelf ) );
            EntityId entityId = new EntityId();
            entityId.WritePacked( writer );
            writer.WriterStream.Write( (byte)this.PlayerField.ObjectTypeId );

            WriteMovementUpdate( writer, updatingSelf );

            WriteUpdateMaskForCreation( writer );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Packet GetDestroyPacket()
        {
            EntityId entityId = new EntityId();
            return new DestroyPacket( entityId );
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool KnowsOf( WowCharacter character )
        {
            return m_KnownCharacters.Contains( character );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void SendDestroyToPlayer( BaseCharacter character )
        {
            character.NetState.Send( this.GetDestroyPacket() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Packet GetFieldUpdatePacket( UpdateFieldId updateFieldId, uint value )
        {
            UpdatePacket packet = new UpdatePacket();

            packet.WriterStream.Write( (byte)UpdateTypes.Values );

            EntityId entityId = new EntityId( this.Serial );
            entityId.WritePacked( packet );

            int iBlocks = ( updateFieldId.RawId >> 5 ) + 1;
            packet.WriterStream.Write( (int)iBlocks );

            packet.WriterStream.Fill( 0x00, ( iBlocks - 1 ) * 4 );
            packet.WriterStream.Write( (uint)( 1 << ( updateFieldId.RawId & 31 ) ) );

            packet.WriterStream.Write( (uint)value );

            packet.EndWrite( 1 );   // Update Count

            return packet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Packet GetFieldUpdatePacket( UpdateFieldId updateFieldId, EntityId value )
        {
            UpdatePacket packet = new UpdatePacket();

            packet.WriterStream.Write( (byte)UpdateTypes.Values );

            EntityId entityId = new EntityId( this.Serial );
            entityId.WritePacked( packet );

            int iBlocks = ( ( updateFieldId.RawId + 1 ) >> 5 ) + 1;
            packet.WriterStream.Write( (int)iBlocks );

            int iBlocksCheck = ( updateFieldId.RawId >> 5 ) + 1;
            if ( iBlocks > 1 && iBlocksCheck != iBlocks )
            {
                packet.WriterStream.Fill( 0x00, ( iBlocks - 2 ) * 4 );

                packet.WriterStream.Write( (uint)0x80000000 );
                packet.WriterStream.Write( (uint)0x00000001 );
            }
            else
            {
                packet.WriterStream.Fill( 0x00, ( iBlocks - 1 ) * 4 );

                uint uiValue = (uint)( 1 << ( updateFieldId.RawId & 31 ) );
                uiValue |= (uint)( uiValue << 1 );

                packet.WriterStream.Write( (uint)uiValue );
            }

            packet.WriterStream.Write( value );

            packet.EndWrite( 1 );   // Update Count

            return packet;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendUpdates()
        {
            ReaderWriterLockSlimEx.EnterWriteLock( m_LockUpdatePacket );
            {
                m_UpdatePacket.EndWrite( m_UpdateCount );

                m_UpdateCount = 0;

                base.NetState.Send( m_UpdatePacket );

                m_UpdatePacket = new UpdatePacket();
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockUpdatePacket );
        }

        #region zh-CHS 私有静态成员变量 | en Private Static Member Variables
        /// <summary>
        /// 
        /// </summary>
        private volatile uint m_UpdateCount;
        /// <summary>
        /// 
        /// </summary>
        private UpdatePacket m_UpdatePacket = new UpdatePacket();
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockUpdatePacket = new ReaderWriterLockSlim();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        public void AddUpdateData( Packet packet, uint uiUpdateCount )
        {
            ReaderWriterLockSlimEx.EnterWriteLock( m_LockUpdatePacket );
            {
                m_UpdatePacket.Write( packet );

                packet.Release();

                m_UpdateCount += uiUpdateCount;
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockUpdatePacket );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private SafeHashSet<WowCharacter> m_KnownCharacters = new SafeHashSet<WowCharacter>();
        /// <summary>
        /// 
        /// </summary>
        private SafeHashSet<WorldEntity> m_KnownEntity = new SafeHashSet<WorldEntity>();
        /// <summary>
        /// 
        /// </summary>
        private SafeHashSet<WowItem> m_NewItems = new SafeHashSet<WowItem>();
        /// <summary>
        /// 
        /// </summary>
        private SafeHashSet<WowItem> m_OwnedItemsRequiringUpdates = new SafeHashSet<WowItem>();
        /// <summary>
        /// 
        /// </summary>
        private DateTime m_PreUpdateTime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public virtual void OnUpdate( object sender, ProcessSliceEventArgs eventArgs )
        {
            if ( m_isInWorld == false )
                return;

            uint uiUpdateCount = 0;
            MemoryPacket memoryPacket = new MemoryPacket();

            // 把自己改变得值广播到附近
            this.BroadcastValueUpdate();

            // 开始更新道具

            // 开始更新 新的游戏道具
            if ( m_NewItems.Count > 0 )
            {
                WowItem[] newItemArray = m_NewItems.ToArrayAndClear();
                foreach ( var newItem in newItemArray )
                {
                    //item.OnInsert();
                    newItem.ObjectCreationUpdate( memoryPacket, true );
                    //obj.m_isInWorld = true;
                }

                uiUpdateCount += (uint)newItemArray.Length;
            }
            // 结束更新 新的游戏道具


            // 开始跟新 存在的游戏道具
            WowItem[] ownedItemArray = m_OwnedItemsRequiringUpdates.ToArrayAndClear();
            foreach ( var ownedItem in ownedItemArray )
                ownedItem.BroadcastValueUpdate();
            // 结束跟新 存在的游戏道具

            // 检测
            if ( ( eventArgs.UpdateTime - m_PreUpdateTime ) < ProcessServer.WowZoneCluster.World.UpdateWorldSpeed && uiUpdateCount > 0 )
            {
                // 仅仅更新道具,就发送数据 然后退出
                // 完成更新
                this.AddUpdateData( memoryPacket, uiUpdateCount );
                this.SendUpdates();

                return;
            }


            // 如果还需要更新人物等。。。
            HashSet<WorldEntity> newWorldEntity = new HashSet<WorldEntity>();

            // 获取附近的对象
            IEnumerable<WorldEntity> nearbyWorldEntity = this.GetAllEntitysInRange( WowCharacter.BROAD_CAST_RANGE );

            // 排除已存在的对象
            newWorldEntity.AddRange( nearbyWorldEntity );
            newWorldEntity.ExceptWith( m_KnownEntity );
            newWorldEntity.Remove( this );


            // 开始更新 新的游戏物体
            foreach ( WorldEntity entity in newWorldEntity )
            {
                WowCharacter wowCharacter = entity as WowCharacter;
                if ( wowCharacter != null )
                    m_KnownCharacters.Add( wowCharacter );

                IWowUpdate wowUpdate = entity.GetComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID );
                if ( wowUpdate != null )
                    wowUpdate.ObjectCreationUpdate( memoryPacket, false );
                //OnEncountered( obj );
            }

            uiUpdateCount += (uint)newWorldEntity.Count;
            // 结束更新 新的游戏物体


            // 获取已不再附近的对象
            HashSet<WorldEntity> outOfRangeWorldEntity = new HashSet<WorldEntity>();

            // 排除已不存在的对象
            outOfRangeWorldEntity.AddRange( m_KnownEntity );
            outOfRangeWorldEntity.ExceptWith( nearbyWorldEntity );

            foreach ( WorldEntity entity in outOfRangeWorldEntity )
            {
                WowCharacter wowCharacter = entity as WowCharacter;
                if ( wowCharacter != null )
                    m_KnownCharacters.Remove( wowCharacter );

                // m_outOfRange.Add(obj.EntityId);

                //OnOutOfRange( obj );
            }

            // 添加现在已存在附近的游戏物体
            m_KnownEntity.Clear();
            m_KnownEntity.AddRange( nearbyWorldEntity );

            // 完成更新
            if ( uiUpdateCount > 0 )
            {
                this.AddUpdateData( memoryPacket, uiUpdateCount );
                this.SendUpdates();
            }

            foreach ( var entity in outOfRangeWorldEntity )
            {
                // send the destroy packet
                IWowUpdate wowUpdate = entity.GetComponent<IWowUpdate>( WowUpdate.WOW_UPDATE_COMPONENT_ID );
                if ( wowUpdate != null )
                    wowUpdate.SendDestroyToPlayer( this );
            }

            m_PreUpdateTime = eventArgs.UpdateTime;
        }
    }
}
