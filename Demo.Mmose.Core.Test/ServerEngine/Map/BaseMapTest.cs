using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Component;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Character;
using System;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseMapTest 的测试类，旨在
    ///包含所有 BaseMapTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseMapTest
    {
        private TestContext testContextInstance;
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///World 的测试
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SpaceNodes 的测试
        ///</summary>
        [TestMethod()]
        public void SpaceNodesTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            MapSpaceNode[, ,] actual;
            actual = target.SpaceNodes;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MapRectangle 的测试
        ///</summary>
        [TestMethod()]
        public void MapRectangleTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Rectangle3D expected = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D actual;
            target.MapRectangle = expected;
            actual = target.MapRectangle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MapName 的测试
        ///</summary>
        [TestMethod()]
        public void MapNameTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.MapName = expected;
            actual = target.MapName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MapId 的测试
        ///</summary>
        [TestMethod()]
        public void MapIdTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Serial expected = new Serial(); // TODO: 初始化为适当的值
            Serial actual;
            target.MapId = expected;
            actual = target.MapId;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseMapState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseMapStateTest()
        {
            BaseMap_Accessor target = new BaseMap_Accessor(); // TODO: 初始化为适当的值
            BaseMapState expected = null; // TODO: 初始化为适当的值
            BaseMapState actual;
            target.BaseMapState = expected;
            actual = target.BaseMapState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///UpdateSlice 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSliceTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            target.UpdateSlice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T component = null; // TODO: 初始化为适当的值
            target.RegisterComponent<T>( componentId, component );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RegisterComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RegisterComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///PostComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void PostComponentMessageTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest5()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( x, y, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( point2D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( point2D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersInRange 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersInRangeTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PlayersInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OutLockProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void OutLockProcessSliceTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            target.OutLockProcessSlice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void OnProcessSliceTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            DateTime updateDelta = new DateTime(); // TODO: 初始化为适当的值
            target.OnProcessSlice( updateDelta );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMove 的测试
        ///</summary>
        [TestMethod()]
        public void OnMoveTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMove( oldLocation, character );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMove 的测试
        ///</summary>
        [TestMethod()]
        public void OnMoveTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMove( oldLocation, entity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMove 的测试
        ///</summary>
        [TestMethod()]
        public void OnMoveTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMove( oldLocation, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMove 的测试
        ///</summary>
        [TestMethod()]
        public void OnMoveTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMove( oldLocation, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeave( creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeave( character );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeave( entity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeave( item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnHandleComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void OnHandleComponentMessageTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.OnHandleComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnter( item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnter( creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnter( entity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnter( character );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InLockProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void InLockProcessSliceTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InLockProcessSlice();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InitPartitionSpace 的测试
        ///</summary>
        [TestMethod()]
        public void InitPartitionSpaceTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPartitionSpace partitionSpace = null; // TODO: 初始化为适当的值
            target.InitPartitionSpace( partitionSpace );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest5()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( point2D, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( point2D, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( x, y, z, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( point3D, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( point3D, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNodesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodesInRangeTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float fRange = 0F; // TODO: 初始化为适当的值
            MapSpaceNode[] expected = null; // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.GetSpaceNodesInRange( x, y, fRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest5()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( x, y );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpaceNodeTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            actual = target.GetSpaceNode( x, y, z );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPlayersInRange 的测试
        ///</summary>
        public void GetPlayersInRangeTest2Helper<CharacterT>()
            where CharacterT : BaseCharacter
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> actual;
            actual = target.GetPlayersInRange<CharacterT>( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetPlayersInRangeTest2()
        {
            Assert.Inconclusive( "没有找到能够满足 CharacterT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetPlayersInRangeTest2Helper<Charac" +
                    "terT>()。" );
        }

        /// <summary>
        ///GetPlayersInRange 的测试
        ///</summary>
        public void GetPlayersInRangeTest1Helper<CharacterT>()
            where CharacterT : BaseCharacter
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> actual;
            actual = target.GetPlayersInRange<CharacterT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetPlayersInRangeTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 CharacterT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetPlayersInRangeTest1Helper<Charac" +
                    "terT>()。" );
        }

        /// <summary>
        ///GetPlayersInRange 的测试
        ///</summary>
        public void GetPlayersInRangeTestHelper<CharacterT>()
            where CharacterT : BaseCharacter
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> actual;
            actual = target.GetPlayersInRange<CharacterT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetPlayersInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 CharacterT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetPlayersInRangeTestHelper<Charact" +
                    "erT>()。" );
        }

        /// <summary>
        ///GetItemsInRange 的测试
        ///</summary>
        public void GetItemsInRangeTest2Helper<ItemT>()
            where ItemT : BaseItem
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<ItemT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> actual;
            actual = target.GetItemsInRange<ItemT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetItemsInRangeTest2()
        {
            Assert.Inconclusive( "没有找到能够满足 ItemT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetItemsInRangeTest2Helper<ItemT>()。" );
        }

        /// <summary>
        ///GetItemsInRange 的测试
        ///</summary>
        public void GetItemsInRangeTest1Helper<ItemT>()
            where ItemT : BaseItem
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<ItemT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> actual;
            actual = target.GetItemsInRange<ItemT>( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetItemsInRangeTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 ItemT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetItemsInRangeTest1Helper<ItemT>()。" );
        }

        /// <summary>
        ///GetItemsInRange 的测试
        ///</summary>
        public void GetItemsInRangeTestHelper<ItemT>()
            where ItemT : BaseItem
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<ItemT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> actual;
            actual = target.GetItemsInRange<ItemT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetItemsInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 ItemT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetItemsInRangeTestHelper<ItemT>()。" );
        }

        /// <summary>
        ///GetEntitysInRange 的测试
        ///</summary>
        public void GetEntitysInRangeTest2Helper<GameEntityT>()
            where GameEntityT : WorldEntity
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> actual;
            actual = target.GetEntitysInRange<GameEntityT>( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEntitysInRangeTest2()
        {
            Assert.Inconclusive( "没有找到能够满足 GameEntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetEntitysInRangeTest2Helper<GameE" +
                    "ntityT>()。" );
        }

        /// <summary>
        ///GetEntitysInRange 的测试
        ///</summary>
        public void GetEntitysInRangeTest1Helper<GameEntityT>()
            where GameEntityT : WorldEntity
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> actual;
            actual = target.GetEntitysInRange<GameEntityT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEntitysInRangeTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 GameEntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetEntitysInRangeTest1Helper<GameE" +
                    "ntityT>()。" );
        }

        /// <summary>
        ///GetEntitysInRange 的测试
        ///</summary>
        public void GetEntitysInRangeTestHelper<GameEntityT>()
            where GameEntityT : WorldEntity
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> actual;
            actual = target.GetEntitysInRange<GameEntityT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEntitysInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 GameEntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetEntitysInRangeTestHelper<GameEn" +
                    "tityT>()。" );
        }

        /// <summary>
        ///GetCreaturesInRange 的测试
        ///</summary>
        public void GetCreaturesInRangeTest2Helper<CreatureT>()
            where CreatureT : BaseCreature
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> actual;
            actual = target.GetCreaturesInRange<CreatureT>( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetCreaturesInRangeTest2()
        {
            Assert.Inconclusive( "没有找到能够满足 CreatureT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetCreaturesInRangeTest2Helper<Creat" +
                    "ureT>()。" );
        }

        /// <summary>
        ///GetCreaturesInRange 的测试
        ///</summary>
        public void GetCreaturesInRangeTest1Helper<CreatureT>()
            where CreatureT : BaseCreature
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> actual;
            actual = target.GetCreaturesInRange<CreatureT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetCreaturesInRangeTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 CreatureT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetCreaturesInRangeTest1Helper<Creat" +
                    "ureT>()。" );
        }

        /// <summary>
        ///GetCreaturesInRange 的测试
        ///</summary>
        public void GetCreaturesInRangeTestHelper<CreatureT>()
            where CreatureT : BaseCreature
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> actual;
            actual = target.GetCreaturesInRange<CreatureT>( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetCreaturesInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 CreatureT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetCreaturesInRangeTestHelper<Creatu" +
                    "reT>()。" );
        }

        /// <summary>
        ///GetComponent 的测试
        ///</summary>
        public void GetComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.GetComponent<T>( componentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///GetAllEntitysInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllEntitysInRangeTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> expected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> actual;
            actual = target.GetAllEntitysInRange( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetAllEntitysInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllEntitysInRangeTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> expected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> actual;
            actual = target.GetAllEntitysInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetAllEntitysInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllEntitysInRangeTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> expected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> actual;
            actual = target.GetAllEntitysInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest5()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( x, y, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( point2D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( x, y, z, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( point3D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesInRange 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesInRangeTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CreaturesInRange( point2D, iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            BaseMap otherMap = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( otherMap );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanSpawn( x, y, z );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanSpawn( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanSpawn( point2D, z );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanSpawn( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanSpawn( point2D, z );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest5()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            actual = target.Bound( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest4()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            actual = target.Bound( x, y, z );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest3()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            actual = target.Bound( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest2()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            actual = target.Bound( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest1()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            actual = target.Bound( x, y );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Bound 的测试
        ///</summary>
        [TestMethod()]
        public void BoundTest()
        {
            BaseMap target = new BaseMap(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            actual = target.Bound( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseMap 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseMapConstructorTest1()
        {
            Serial mapId = new Serial(); // TODO: 初始化为适当的值
            Rectangle3D mapRectangle = new Rectangle3D(); // TODO: 初始化为适当的值
            string strMapName = string.Empty; // TODO: 初始化为适当的值
            BaseMap target = new BaseMap( mapId, mapRectangle, strMapName );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///BaseMap 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseMapConstructorTest()
        {
            BaseMap target = new BaseMap();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
