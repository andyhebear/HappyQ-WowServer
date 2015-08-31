using Demo.Mmose.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Demo.Mmose.Core.Common.Component;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Map;
using System;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 WorldEntityTest 的测试类，旨在
    ///包含所有 WorldEntityTest 单元测试
    ///</summary>
    [TestClass()]
    public class WorldEntityTest
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
        ///Z 的测试
        ///</summary>
        [TestMethod()]
        public void ZTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.Z = expected;
            actual = target.Z;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Y 的测试
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.Y = expected;
            actual = target.Y;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///X 的测试
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.X = expected;
            actual = target.X;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///World 的测试
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Serial 的测试
        ///</summary>
        [TestMethod()]
        public void SerialTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Serial expected = new Serial(); // TODO: 初始化为适当的值
            Serial actual;
            target.Serial = expected;
            actual = target.Serial;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Saving 的测试
        ///</summary>
        [TestMethod()]
        public void SavingTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Saving;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///O 的测试
        ///</summary>
        [TestMethod()]
        public void OTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.O = expected;
            actual = target.O;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void MapSpaceNodeTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
            target.MapSpaceNode = expected;
            actual = target.MapSpaceNode;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Map 的测试
        ///</summary>
        [TestMethod()]
        public void MapTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            BaseMap expected = null; // TODO: 初始化为适当的值
            BaseMap actual;
            target.Map = expected;
            actual = target.Map;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Location 的测试
        ///</summary>
        [TestMethod()]
        public void LocationTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            target.Location = expected;
            actual = target.Location;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual WorldEntity_Accessor CreateWorldEntity_Accessor()
        {
            // TODO: 实例化相应的具体类。
            WorldEntity_Accessor target = null;
            return target;
        }

        /// <summary>
        ///GameEntityState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GameEntityStateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            WorldEntity_Accessor target = new WorldEntity_Accessor( param0 ); // TODO: 初始化为适当的值
            WorldEntityState expected = null; // TODO: 初始化为适当的值
            WorldEntityState actual;
            target.GameEntityState = expected;
            actual = target.GameEntityState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Deleted 的测试
        ///</summary>
        [TestMethod()]
        public void DeletedTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Deleted;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AI 的测试
        ///</summary>
        [TestMethod()]
        public void AITest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            IArtificialIntelligence expected = null; // TODO: 初始化为适当的值
            IArtificialIntelligence actual;
            target.AI = expected;
            actual = target.AI;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///UpdateSlice 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSliceTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.UpdateSlice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SpaceNodeActivateCallback 的测试
        ///</summary>
        [TestMethod()]
        public void SpaceNodeActivateCallbackTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.SpaceNodeActivateCallback();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetSpaceNodeActivateCallbackTime 的测试
        ///</summary>
        [TestMethod()]
        public void SetSpaceNodeActivateCallbackTimeTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            TimeSpan timeSlice = new TimeSpan(); // TODO: 初始化为适当的值
            target.SetSpaceNodeActivateCallbackTime( timeSlice );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Save 的测试
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.Save();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OutLockProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void OutLockProcessSliceTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.OutLockProcessSlice();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnSpaceNodeDeactivate 的测试
        ///</summary>
        [TestMethod()]
        public void OnSpaceNodeDeactivateTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.OnSpaceNodeDeactivate();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnSpaceNodeActivate 的测试
        ///</summary>
        [TestMethod()]
        public void OnSpaceNodeActivateTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.OnSpaceNodeActivate();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void OnProcessSliceTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            DateTime updateDelta = new DateTime(); // TODO: 初始化为适当的值
            target.OnProcessSlice( updateDelta );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnHandleComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void OnHandleComponentMessageTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.OnHandleComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MoveToWorld 的测试
        ///</summary>
        [TestMethod()]
        public void MoveToWorldTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point3D newLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseMap newMap = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.MoveToWorld( newLocation, newMap );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MoveTo 的测试
        ///</summary>
        [TestMethod()]
        public void MoveToTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point3D newLocation = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.MoveTo( newLocation );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InRange 的测试
        ///</summary>
        [TestMethod()]
        public void InRangeTest4()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            WorldEntity checkEntity = null; // TODO: 初始化为适当的值
            int iInRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InRange( checkEntity, iInRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InRange 的测试
        ///</summary>
        [TestMethod()]
        public void InRangeTest3()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            int iInRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InRange( point3D, iInRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InRange 的测试
        ///</summary>
        [TestMethod()]
        public void InRangeTest2()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            int iInRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InRange( point2D, iInRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InRange 的测试
        ///</summary>
        [TestMethod()]
        public void InRangeTest1()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            int iInRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InRange( point2D, iInRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InRange 的测试
        ///</summary>
        [TestMethod()]
        public void InRangeTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            int iInRange = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InRange( point3D, iInRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InLockProcessSlice 的测试
        ///</summary>
        [TestMethod()]
        public void InLockProcessSliceTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InLockProcessSlice();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPlayersInRange 的测试
        ///</summary>
        public void GetPlayersInRangeTest1Helper<CharacterT>()
            where CharacterT : BaseCharacter
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> actual;
            actual = target.GetPlayersInRange<CharacterT>( iRange );
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> originalInRange = null; // TODO: 初始化为适当的值
            CharacterT[] newInRange = null; // TODO: 初始化为适当的值
            CharacterT[] newInRangeExpected = null; // TODO: 初始化为适当的值
            CharacterT[] outOfRange = null; // TODO: 初始化为适当的值
            CharacterT[] outOfRangeExpected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CharacterT> actual;
            actual = target.GetPlayersInRange<CharacterT>( iRange, originalInRange, out newInRange, out outOfRange );
            Assert.AreEqual( newInRangeExpected, newInRange );
            Assert.AreEqual( outOfRangeExpected, outOfRange );
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
        public void GetItemsInRangeTest1Helper<ItemT>()
            where ItemT : BaseItem
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<ItemT> originalInRange = null; // TODO: 初始化为适当的值
            ItemT[] newInRange = null; // TODO: 初始化为适当的值
            ItemT[] newInRangeExpected = null; // TODO: 初始化为适当的值
            ItemT[] outOfRange = null; // TODO: 初始化为适当的值
            ItemT[] outOfRangeExpected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> actual;
            actual = target.GetItemsInRange<ItemT>( iRange, originalInRange, out newInRange, out outOfRange );
            Assert.AreEqual( newInRangeExpected, newInRange );
            Assert.AreEqual( outOfRangeExpected, outOfRange );
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<ItemT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ItemT> actual;
            actual = target.GetItemsInRange<ItemT>( iRange );
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
        public void GetEntitysInRangeTest1Helper<GameEntityT>()
            where GameEntityT : WorldEntity
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> actual;
            actual = target.GetEntitysInRange<GameEntityT>( iRange );
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> originalInRange = null; // TODO: 初始化为适当的值
            GameEntityT[] newInRange = null; // TODO: 初始化为适当的值
            GameEntityT[] newInRangeExpected = null; // TODO: 初始化为适当的值
            GameEntityT[] outOfRange = null; // TODO: 初始化为适当的值
            GameEntityT[] outOfRangeExpected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<GameEntityT> actual;
            actual = target.GetEntitysInRange<GameEntityT>( iRange, originalInRange, out newInRange, out outOfRange );
            Assert.AreEqual( newInRangeExpected, newInRange );
            Assert.AreEqual( outOfRangeExpected, outOfRange );
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
        ///GetDistanceToSqrt 的测试
        ///</summary>
        [TestMethod()]
        public void GetDistanceToSqrtTest4()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.GetDistanceToSqrt( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetDistanceToSqrt 的测试
        ///</summary>
        [TestMethod()]
        public void GetDistanceToSqrtTest3()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.GetDistanceToSqrt( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetDistanceToSqrt 的测试
        ///</summary>
        [TestMethod()]
        public void GetDistanceToSqrtTest2()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.GetDistanceToSqrt( entity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetDistanceToSqrt 的测试
        ///</summary>
        [TestMethod()]
        public void GetDistanceToSqrtTest1()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.GetDistanceToSqrt( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetDistanceToSqrt 的测试
        ///</summary>
        [TestMethod()]
        public void GetDistanceToSqrtTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.GetDistanceToSqrt( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetCreaturesInRange 的测试
        ///</summary>
        public void GetCreaturesInRangeTest1Helper<CreatureT>()
            where CreatureT : BaseCreature
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> originalInRange = null; // TODO: 初始化为适当的值
            CreatureT[] newInRange = null; // TODO: 初始化为适当的值
            CreatureT[] newInRangeExpected = null; // TODO: 初始化为适当的值
            CreatureT[] outOfRange = null; // TODO: 初始化为适当的值
            CreatureT[] outOfRangeExpected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> actual;
            actual = target.GetCreaturesInRange<CreatureT>( iRange, originalInRange, out newInRange, out outOfRange );
            Assert.AreEqual( newInRangeExpected, newInRange );
            Assert.AreEqual( outOfRangeExpected, outOfRange );
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<CreatureT> actual;
            actual = target.GetCreaturesInRange<CreatureT>( iRange );
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
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
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
        public void GetAllEntitysInRangeTest1()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> originalInRange = null; // TODO: 初始化为适当的值
            WorldEntity[] newInRange = null; // TODO: 初始化为适当的值
            WorldEntity[] newInRangeExpected = null; // TODO: 初始化为适当的值
            WorldEntity[] outOfRange = null; // TODO: 初始化为适当的值
            WorldEntity[] outOfRangeExpected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> expected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> actual;
            actual = target.GetAllEntitysInRange( iRange, originalInRange, out newInRange, out outOfRange );
            Assert.AreEqual( newInRangeExpected, newInRange );
            Assert.AreEqual( outOfRangeExpected, outOfRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetAllEntitysInRange 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllEntitysInRangeTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            int iRange = 0; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> expected = null; // TODO: 初始化为适当的值
            IEnumerable<WorldEntity> actual;
            actual = target.GetAllEntitysInRange( iRange );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Delete 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            target.Delete();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CreateNewInstance 的测试
        ///</summary>
        public void CreateNewInstanceTestHelper<GameEntityT>()
            where GameEntityT : WorldEntity
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            GameEntityT expected = default( GameEntityT ); // TODO: 初始化为适当的值
            GameEntityT actual;
            actual = target.CreateNewInstance<GameEntityT>();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CreateNewInstanceTest()
        {
            Assert.Inconclusive( "没有找到能够满足 GameEntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreateNewInstanceTestHelper<GameEn" +
                    "tityT>()。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual WorldEntity CreateWorldEntity()
        {
            // TODO: 实例化相应的具体类。
            WorldEntity target = null;
            return target;
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            WorldEntity target = CreateWorldEntity(); // TODO: 初始化为适当的值
            WorldEntity other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
