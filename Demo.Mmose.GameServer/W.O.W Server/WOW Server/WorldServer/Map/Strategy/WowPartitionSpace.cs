using System;
using System.Collections.Generic;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Timer;
using System.Threading;
using Demo.Mmose.Core.Common;
using System.Diagnostics;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Util;

namespace Demo.Wow.WorldServer.WorldServer.Map.Strategy
{
    /// <summary>
    /// 
    /// </summary>
    public class WowPartitionSpace : IPartitionSpace
    {
        #region zh-CHS 共有常量 | en Public Constants
        /// <summary>
        /// 
        /// </summary>
        public const int MAX_NUMBER_OF_GRIDS = 64;

        /// <summary>
        /// 
        /// </summary>
        public const float SIZE_OF_GRIDS = 533.33333f;

        /// <summary>
        /// 
        /// </summary>
        public const int CENTER_GRID_ID = ( MAX_NUMBER_OF_GRIDS / 2 ); // 32

        /// <summary>
        /// 
        /// </summary>
        public const float CENTER_GRID_OFFSET = ( SIZE_OF_GRIDS / 2 ); // 266.66666f

        /// <summary>
        /// 
        /// </summary>
        public const int MAX_NUMBER_OF_CELLS = 8;

        /// <summary>
        /// 
        /// </summary>
        public const float SIZE_OF_GRID_CELL = ( SIZE_OF_GRIDS / MAX_NUMBER_OF_CELLS ); // 66.666666f

        /// <summary>
        /// 
        /// </summary>
        const int CENTER_GRID_CELL_ID = 256;

        /// <summary>
        /// 
        /// </summary>
        const float CENTER_GRID_CELL_OFFSET = ( SIZE_OF_GRID_CELL / 2 ); // 33.333333f

        /// <summary>
        /// 
        /// </summary>
        const int TOTAL_NUMBER_OF_CELLS_PER_MAP = ( MAX_NUMBER_OF_GRIDS * MAX_NUMBER_OF_CELLS ); // 512

        /// <summary>
        /// 
        /// </summary>
        const int MAP_RESOLUTION = 256;

        /// <summary>
        /// 
        /// </summary>
        const float MAP_SIZE = ( SIZE_OF_GRIDS * MAX_NUMBER_OF_GRIDS ); // 34134.0f

        /// <summary>
        /// 
        /// </summary>
        const float MAP_HALFSIZE = ( MAP_SIZE / 2 ); // 17067.0f

        /// <summary>
        /// 
        /// </summary>
        public const int MIN_GRID_DELAY = 60 * 1000;
        #endregion

        #region zh-CHS IPartitionSpace接口实现 | en Interface Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void InitMap( object sender, MapEventArgs eventArgs )
        {
            eventArgs.Map.MapRectangle = new Rectangle3D( -17067.0f, -17067.0f, -17067.0f, 17067.0f, 17067.0f, 17067.0f );

            m_CheckDeactivateSlice = TimeSlice.StartTimeSlice( m_CheckDeactivateTimeSpan, m_CheckDeactivateTimeSpan, new TimeSliceCallback( this.CheckDeactivateSpaceNode ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void ProcessPartitionSpace( object sender, PartitionSpaceEventArgs eventArgs )
        {
            eventArgs.PartitionSpace = new MapSpaceNode[MAX_NUMBER_OF_GRIDS, MAX_NUMBER_OF_GRIDS, 0];

            for ( int iIndexX = 0; iIndexX < MAX_NUMBER_OF_GRIDS; iIndexX++ )
            {
                for ( int iIndexY = 0; iIndexY < MAX_NUMBER_OF_GRIDS; iIndexY++ )
                {
                    Point3D startPoint3D = new Point3D();
                    startPoint3D.X = eventArgs.Map.MapRectangle.Start.X + ( iIndexX * SIZE_OF_GRIDS );
                    startPoint3D.Y = eventArgs.Map.MapRectangle.Start.Y + ( iIndexY * SIZE_OF_GRIDS );
                    startPoint3D.Z = eventArgs.Map.MapRectangle.Start.Z;

                    Point3D endPoint3D = new Point3D();
                    endPoint3D.X = startPoint3D.X + SIZE_OF_GRIDS;
                    endPoint3D.Y = startPoint3D.Y + SIZE_OF_GRIDS;
                    endPoint3D.Z = eventArgs.Map.MapRectangle.End.Z;

                    eventArgs.PartitionSpace[iIndexX, iIndexY, 0] = new MapSpaceNode( new Rectangle3D( startPoint3D, endPoint3D ) );
                }
            }
        }

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iGridCellPointX"></param>
        /// <param name="iGridCellPointY"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private MapSpaceNode GetSubSpaceNode( int iPointXOfGridCell, int iPointYOfGridCell, BaseMap map )
        {
            Debug.Assert( map != null, "PartitionSpaceStrategy.GetSubSpaceNode(...) - map == null error!" );

            if ( iPointXOfGridCell < 0 || iPointYOfGridCell < 0 )
                return null;

            int iGridPointX = (int)( iPointXOfGridCell / MAX_NUMBER_OF_CELLS );
            int iGridPointY = (int)( iPointYOfGridCell / MAX_NUMBER_OF_CELLS );

            if ( iGridPointX >= MAX_NUMBER_OF_GRIDS || iGridPointY >= MAX_NUMBER_OF_GRIDS )
                return null;

            int iCellPointX = (int)( iPointXOfGridCell % MAX_NUMBER_OF_CELLS );
            int iCellPointY = (int)( iPointYOfGridCell % MAX_NUMBER_OF_CELLS );

            return map.SpaceNodes[iGridPointX, iGridPointY, 0].SpaceNodes[iCellPointX, iCellPointY, 0];
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void GetSpaceNod( object sender, GetSpaceNodeEventArgs eventArgs )
        {
            Point3D point3D = eventArgs.Map.Bound( eventArgs.X, eventArgs.Y, eventArgs.Z );
            Point3D startPoint3D = eventArgs.Map.MapRectangle.Start;

            // 获取区域点
            float fGridOffsetX = eventArgs.Map.MapRectangle.Width - ( point3D.X - startPoint3D.X );
            int iGridCellPointX = (int)( fGridOffsetX / SIZE_OF_GRID_CELL );

            float fGridOffsetY = eventArgs.Map.MapRectangle.Height - ( point3D.Y - startPoint3D.Y );
            int iGridCellPointY = (int)( fGridOffsetY / SIZE_OF_GRID_CELL );

            // 返回需要的区域点
            eventArgs.SpaceNode = this.GetSubSpaceNode( iGridCellPointX, iGridCellPointY, eventArgs.Map );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void GetSpaceNodesInRange( object sender, GetGetSpaceNodesInRangeEventArgs eventArgs )
        {
            List<MapSpaceNode> mapSpaceNodeList = new List<MapSpaceNode>();

            Point3D point3D = eventArgs.Map.Bound( eventArgs.X, eventArgs.Y, eventArgs.Z );
            Point3D startPoint3D = eventArgs.Map.MapRectangle.Start;

            // 获取区域点
            float fGridOffsetX = eventArgs.Map.MapRectangle.Width - ( point3D.X - startPoint3D.X );
            int iGridCellPointX = (int)( fGridOffsetX / SIZE_OF_GRID_CELL );

            float fGridOffsetY = eventArgs.Map.MapRectangle.Height - ( point3D.Y - startPoint3D.Y );
            int iGridCellPointY = (int)( fGridOffsetY / SIZE_OF_GRID_CELL );

            // 计算有多少Cell在Range内的数量
            int iCellCount = (int)( eventArgs.Range / SIZE_OF_GRID_CELL );

            // 再加上额外的计算得到正偏移的数量
            int iPlusCountX = iCellCount + ( ( eventArgs.Range % SIZE_OF_GRID_CELL ) > ( SIZE_OF_GRID_CELL - ( fGridOffsetX % SIZE_OF_GRID_CELL ) ) ? 1 : 0 );
            int iPlusCountY = iCellCount + ( ( eventArgs.Range % SIZE_OF_GRID_CELL ) > ( SIZE_OF_GRID_CELL - ( fGridOffsetY % SIZE_OF_GRID_CELL ) ) ? 1 : 0 );

            // 获取正偏移的Cell空间节点(MapSpaceNode)
            for ( int iPlusOffsetX = 0; iPlusOffsetX < iPlusCountX; iPlusOffsetX++ )
            {
                for ( int iPlusOffsetY = 0; iPlusOffsetY < iPlusCountY; iPlusOffsetY++ )
                {
                    MapSpaceNode getSubSpaceNode = GetSubSpaceNode( iGridCellPointX + iPlusOffsetX, iGridCellPointY + iPlusOffsetY, eventArgs.Map );
                    if ( getSubSpaceNode == null )
                        continue;
                    else
                        mapSpaceNodeList.Add( getSubSpaceNode );
                }
            }

            // 再加上额外的计算得到负偏移的数量
            int iMinusX = iCellCount + ( ( eventArgs.Range % SIZE_OF_GRID_CELL ) > ( fGridOffsetX % SIZE_OF_GRID_CELL ) ? 1 : 0 );
            int iMinusY = iCellCount + ( ( eventArgs.Range % SIZE_OF_GRID_CELL ) > ( fGridOffsetY % SIZE_OF_GRID_CELL ) ? 1 : 0 );

            // 获取负偏移的Cell空间节点(MapSpaceNode)
            for ( int iMinusOffsetX = 0; iMinusOffsetX < iPlusCountX; iMinusOffsetX++ )
            {
                for ( int iMinusOffsetY = 0; iMinusOffsetY < iPlusCountY; iMinusOffsetY++ )
                {
                    MapSpaceNode getSubSpaceNode = GetSubSpaceNode( iGridCellPointX - iMinusOffsetX, iGridCellPointY - iMinusOffsetY, eventArgs.Map );
                    if ( getSubSpaceNode == null )
                        continue;
                    else
                        mapSpaceNodeList.Add( getSubSpaceNode );
                }
            }

            eventArgs.SpaceNodes = mapSpaceNodeList.ToArray();
        }

        #endregion

        #region zh-CHS IPartitionSpaceNode接口实现 | en Interface Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void InitSpaceNode( object sender, SpaceNodeEventArgs eventArgs )
        {
            // None
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void ProcessPartitionSpaceNode( object sender, PartitionSpaceNodeEventArgs eventArgs )
        {
            if ( eventArgs.PartitionSpaceNode.LayerIndex != 0 )
                return;

            eventArgs.PartitionSpace = new MapSpaceNode[MAX_NUMBER_OF_CELLS, MAX_NUMBER_OF_CELLS, 0];

            for ( int iIndexX = 0; iIndexX < MAX_NUMBER_OF_CELLS; iIndexX++ )
            {
                for ( int iIndexY = 0; iIndexY < MAX_NUMBER_OF_CELLS; iIndexY++ )
                {
                    Point3D startPoint3D = new Point3D();
                    startPoint3D.X = eventArgs.PartitionSpaceNode.SpaceNodeRectangle.Start.X + ( iIndexX * SIZE_OF_GRID_CELL );
                    startPoint3D.Y = eventArgs.PartitionSpaceNode.SpaceNodeRectangle.Start.Y + ( iIndexY * SIZE_OF_GRID_CELL );
                    startPoint3D.Z = eventArgs.PartitionSpaceNode.SpaceNodeRectangle.Start.Z;

                    Point3D endPoint3D = new Point3D();
                    endPoint3D.X = startPoint3D.X + SIZE_OF_GRID_CELL;
                    endPoint3D.Y = startPoint3D.Y + SIZE_OF_GRID_CELL;
                    endPoint3D.Z = eventArgs.PartitionSpaceNode.SpaceNodeRectangle.End.Z;

                    eventArgs.PartitionSpace[iIndexX, iIndexY, 0] = new MapSpaceNode( new Rectangle3D( startPoint3D, endPoint3D ) );
                }
            }
        }

        #region zh-CHS 私有成员变量 | en Private Member Variables
        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int DICTIONARY_CAPACITY_SIZE = 1024;
        #endregion
        /// <summary>
        /// 在激活状态
        /// </summary>
        private Dictionary<MapSpaceNode, MapSpaceNode> m_ActivateSpaceNodes = new Dictionary<MapSpaceNode, MapSpaceNode>( DICTIONARY_CAPACITY_SIZE );
        /// <summary>
        /// 在激活状态
        /// </summary>
        private Dictionary<MapSpaceNode, MapSpaceNode> m_DeactivateSpaceNodes = new Dictionary<MapSpaceNode, MapSpaceNode>( DICTIONARY_CAPACITY_SIZE );
        /// <summary>
        /// 在静止状态
        /// </summary>
        private Dictionary<MapSpaceNode, MapSpaceNode> m_DeadSpaceNodes = new Dictionary<MapSpaceNode, MapSpaceNode>( DICTIONARY_CAPACITY_SIZE );
        /// <summary>
        /// 
        /// </summary>
        private ReaderWriterLockSlim m_LockAllSpaceNodes = new ReaderWriterLockSlim();
        #endregion

        #region zh-CHS 私有方法 | en Private Methods

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void ActivateSpaceNodeNow( MapSpaceNode mapSpaceNode )
        {
            BaseCreature[] creatureArray = mapSpaceNode.ToArrayInCreatures();
            foreach ( BaseCreature creature in creatureArray )
                creature.OnSpaceNodeActivate();

            BaseItem[] itemArray = mapSpaceNode.ToArrayInItems();
            foreach ( BaseItem item in itemArray )
                item.OnSpaceNodeActivate();

            WorldEntity[] entityArray = mapSpaceNode.ToArrayInEntitys();
            foreach ( WorldEntity gameEntity in entityArray )
                gameEntity.OnSpaceNodeActivate();
        }
        #endregion
        /// <summary>
        /// 激活自身的节点
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void ActivateSelfSpaceNode( MapSpaceNode mapSpaceNode )
        {
            MapSpaceNode outValue = null;

            if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                m_DeactivateSpaceNodes.Remove( mapSpaceNode );
                m_ActivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );
            }
            else if ( m_DeadSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                m_DeadSpaceNodes.Remove( mapSpaceNode );
                m_ActivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.ActivateSpaceNodeNow( mapSpaceNode );
            }
            else if ( m_ActivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == false )
            {
                m_ActivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.ActivateSpaceNodeNow( mapSpaceNode );
            }
        }

        /// <summary>
        /// 激活邻边的节点
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void ActivateNearSpaceNode( MapSpaceNode mapSpaceNode )
        {
            MapSpaceNode outValue = null;

            if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                // 如果已经在不活动的状态就跳过
            }
            else if ( m_DeadSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                m_DeadSpaceNodes.Remove( mapSpaceNode );
                m_DeactivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.ActivateSpaceNodeNow( mapSpaceNode );
            }
            else if ( m_ActivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == false )
            {
                m_DeactivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.ActivateSpaceNodeNow( mapSpaceNode );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void ActivateSpaceNode( object sender, ActivateSpaceNodeEventArgs eventArgs )
        {
            MapSpaceNode mapSpaceNode = eventArgs.SpaceNode;

            Debug.Assert( mapSpaceNode != null, "PartitionSpaceStrategy.ActivateSpaceNode(...) - mapSpaceNode == null error!" );

            MapSpaceNode parentMapSpaceNode = mapSpaceNode.Parent;

            Debug.Assert( parentMapSpaceNode != null, "PartitionSpaceStrategy.ActivateSpaceNode(...) - parentMapSpaceNode == null error!" );

            ReaderWriterLockSlimEx.EnterWriteLock( m_LockAllSpaceNodes );
            {
                // 激活自己
                this.ActivateSelfSpaceNode( mapSpaceNode );

                int iGridCellPointX = parentMapSpaceNode.RankIndex.Rank0Index * MAX_NUMBER_OF_CELLS;
                int iGridCellPointY = parentMapSpaceNode.RankIndex.Rank1Index * MAX_NUMBER_OF_CELLS;

                // ActivateSpaceNode1
                MapSpaceNode subSpaceNode1 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                if ( subSpaceNode1 != null )
                    this.ActivateNearSpaceNode( subSpaceNode1 );

                // ActivateSpaceNode2
                MapSpaceNode subSpaceNode2 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                if ( subSpaceNode2 != null )
                    this.ActivateNearSpaceNode( subSpaceNode2 );

                // ActivateSpaceNode3
                MapSpaceNode subSpaceNode3 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                if ( subSpaceNode3 != null )
                    this.ActivateNearSpaceNode( subSpaceNode3 );

                // ActivateSpaceNode4
                MapSpaceNode subSpaceNode4 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index, mapSpaceNode.Owner );
                if ( subSpaceNode4 != null )
                    this.ActivateNearSpaceNode( subSpaceNode4 );

                // ActivateSpaceNode5 == SelfSpaceNode

                // ActivateSpaceNode6
                MapSpaceNode subSpaceNode6 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index, mapSpaceNode.Owner );
                if ( subSpaceNode6 != null )
                    this.ActivateNearSpaceNode( subSpaceNode6 );

                // ActivateSpaceNode7
                MapSpaceNode subSpaceNode7 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                if ( subSpaceNode7 != null )
                    this.ActivateNearSpaceNode( subSpaceNode7 );

                // ActivateSpaceNode8
                MapSpaceNode subSpaceNode8 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                if ( subSpaceNode8 != null )
                    this.ActivateNearSpaceNode( subSpaceNode8 );

                // ActivateSpaceNode9
                MapSpaceNode subSpaceNode9 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                if ( subSpaceNode9 != null )
                    this.ActivateNearSpaceNode( subSpaceNode9 );
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockAllSpaceNodes );
        }

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 地图节点已不活动，但现在还不是静止物体行为的时候，需要检查邻边的节点
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void DeactivateSelfSpaceNode( MapSpaceNode mapSpaceNode )
        {
            MapSpaceNode outValue = null;

            if ( m_ActivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                m_ActivateSpaceNodes.Remove( mapSpaceNode );
                m_DeactivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );
            }
            else if ( m_DeadSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                // 如果已经在静止的状态就跳过
            }
            else if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == false )
                m_DeactivateSpaceNodes.Add( mapSpaceNode, mapSpaceNode );
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void DeactivateSpaceNode( object sender, DeactivateSpaceNodeEventArgs eventArgs )
        {
            MapSpaceNode mapSpaceNode = eventArgs.SpaceNode;

            Debug.Assert( mapSpaceNode != null, "PartitionSpaceStrategy.DeactivateSpaceNode(...) - mapSpaceNode == null error!" );

            ReaderWriterLockSlimEx.EnterWriteLock( m_LockAllSpaceNodes );
            {
                this.DeactivateSelfSpaceNode( mapSpaceNode );
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockAllSpaceNodes );
        }


        #region zh-CHS 私有常量 | en Private Constants
        /// <summary>
        /// 
        /// </summary>
        private readonly static int LIST_CAPACITY_SIZE = 1024;
        #endregion

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 地图空间的时间片
        /// </summary>
        private TimeSlice m_CheckDeactivateSlice = null;
        /// <summary>
        /// 检查地图空间的时间间隔
        /// </summary>
        private TimeSpan m_CheckDeactivateTimeSpan = TimeSpan.FromMinutes( 3.5 );
        #endregion

        #region zh-CHS 私有方法 | en Private Methods

        #region zh-CHS 私有方法 | en Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        /// <returns></returns>
        private bool IsDeadOrDeactivate( MapSpaceNode mapSpaceNode )
        {
            MapSpaceNode outValue = null;

            if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
                return true;

            if ( m_DeadSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void DeactivateSpaceNodeNow( MapSpaceNode mapSpaceNode )
        {
            BaseCreature[] creatureArray = mapSpaceNode.ToArrayInCreatures();
            foreach ( BaseCreature creature in creatureArray )
                creature.OnSpaceNodeDeactivate();

            BaseItem[] itemArray = mapSpaceNode.ToArrayInItems();
            foreach ( BaseItem item in itemArray )
                item.OnSpaceNodeDeactivate();

            WorldEntity[] entityArray = mapSpaceNode.ToArrayInEntitys();
            foreach ( WorldEntity gameEntity in entityArray )
                gameEntity.OnSpaceNodeDeactivate();
        }

        /// <summary>
        /// 开始静止物体行为
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        private void DeadSelfSpaceNode( MapSpaceNode mapSpaceNode )
        {
            MapSpaceNode outValue = null;

            if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                m_DeactivateSpaceNodes.Remove( mapSpaceNode );
                m_DeadSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.DeactivateSpaceNodeNow( mapSpaceNode );
            }
            else if ( m_ActivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == true )
            {
                // 如果是在激活状态就跳过不用静止物体
            }
            else if ( m_DeadSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == false )
            {
                m_DeadSpaceNodes.Add( mapSpaceNode, mapSpaceNode );

                this.DeactivateSpaceNodeNow( mapSpaceNode );
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapSpaceNode"></param>
        public void CheckToDeadSpaceNode( MapSpaceNode mapSpaceNode )
        {
            Debug.Assert( mapSpaceNode != null, "PartitionSpaceStrategy.DeactivateSpaceNode(...) - mapSpaceNode == null error!" );

            MapSpaceNode parentMapSpaceNode = mapSpaceNode.Parent;

            Debug.Assert( parentMapSpaceNode != null, "PartitionSpaceStrategy.DeactivateSpaceNode(...) - parentMapSpaceNode == null error!" );

            ReaderWriterLockSlimEx.EnterWriteLock( m_LockAllSpaceNodes );
            {
                do
                {
                    MapSpaceNode outValue = null;
                    if ( m_DeactivateSpaceNodes.TryGetValue( mapSpaceNode, out outValue ) == false )
                        break;

                    int iGridCellPointX = parentMapSpaceNode.RankIndex.Rank0Index * MAX_NUMBER_OF_CELLS;
                    int iGridCellPointY = parentMapSpaceNode.RankIndex.Rank1Index * MAX_NUMBER_OF_CELLS;

                    MapSpaceNode subSpaceNode1 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode1 != null && this.IsDeadOrDeactivate( subSpaceNode1 ) == false )
                        break;

                    MapSpaceNode subSpaceNode2 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode2 != null && this.IsDeadOrDeactivate( subSpaceNode2 ) == false )
                        break;

                    MapSpaceNode subSpaceNode3 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index - 1, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode3 != null && this.IsDeadOrDeactivate( subSpaceNode3 ) == false )
                        break;

                    MapSpaceNode subSpaceNode4 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode4 != null && this.IsDeadOrDeactivate( subSpaceNode4 ) == false )
                        break;

                    // DeactivateSpaceNode5 == SelfSpaceNode

                    MapSpaceNode subSpaceNode6 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode6 != null && this.IsDeadOrDeactivate( subSpaceNode6 ) == false )
                        break;

                    MapSpaceNode subSpaceNode7 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index - 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                    if ( subSpaceNode7 != null && this.IsDeadOrDeactivate( subSpaceNode7 ) == false )
                        break;

                    MapSpaceNode subSpaceNode8 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode8 != null && this.IsDeadOrDeactivate( subSpaceNode8 ) == false )
                        break;

                    MapSpaceNode subSpaceNode9 = this.GetSubSpaceNode( iGridCellPointX + mapSpaceNode.RankIndex.Rank0Index + 1, iGridCellPointY + mapSpaceNode.RankIndex.Rank1Index + 1, mapSpaceNode.Owner );
                    ;
                    if ( subSpaceNode9 != null && this.IsDeadOrDeactivate( subSpaceNode9 ) == false )
                        break;

                    // All DeadOrDeactivate
                    this.DeadSelfSpaceNode( mapSpaceNode );

                } while ( false );
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockAllSpaceNodes );
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private void CheckDeactivateSpaceNode()
        {
            List<MapSpaceNode> mapSpaceNodeList = new List<MapSpaceNode>( LIST_CAPACITY_SIZE );

            ReaderWriterLockSlimEx.EnterWriteLock( m_LockAllSpaceNodes );
            {
                foreach ( KeyValuePair<MapSpaceNode, MapSpaceNode> keyValuePair in m_DeactivateSpaceNodes )
                    mapSpaceNodeList.Add( keyValuePair.Key );
            }
            ReaderWriterLockSlimEx.ExitWriteLock( m_LockAllSpaceNodes );

            foreach ( MapSpaceNode mapSpaceNode in mapSpaceNodeList )
                this.CheckToDeadSpaceNode( mapSpaceNode );
        }
        #endregion
    }
}
