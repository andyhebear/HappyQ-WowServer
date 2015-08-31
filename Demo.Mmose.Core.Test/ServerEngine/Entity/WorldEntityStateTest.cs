using Demo.Mmose.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Map;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 WorldEntityStateTest 的测试类，旨在
    ///包含所有 WorldEntityStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class WorldEntityStateTest
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
        ///SingletonInstance 的测试
        ///</summary>
        [TestMethod()]
        public void SingletonInstanceTest()
        {
            WorldEntityState actual;
            actual = WorldEntityState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateZ 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateZTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateZ = expected;
            actual = target.IsUpdateZ;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateY 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateYTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateY = expected;
            actual = target.IsUpdateY;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateX 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateXTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateX = expected;
            actual = target.IsUpdateX;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateSerial 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateSerialTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateSerial = expected;
            actual = target.IsUpdateSerial;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateOrientation 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateOrientationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateOrientation = expected;
            actual = target.IsUpdateOrientation;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateMapSpaceNodeTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateMapSpaceNode = expected;
            actual = target.IsUpdateMapSpaceNode;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateMap 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateMapTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateMap = expected;
            actual = target.IsUpdateMap;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateLocation 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateLocationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateLocation = expected;
            actual = target.IsUpdateLocation;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateAI 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateAITest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateAI = expected;
            actual = target.IsUpdateAI;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsMoveToWorldCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsMoveToWorldCallTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsMoveToWorldCall = expected;
            actual = target.IsMoveToWorldCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsMoveToCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsMoveToCallTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsMoveToCall = expected;
            actual = target.IsMoveToCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingZ 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingZTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingZ( z, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingY 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingYTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingY( y, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingX 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingXTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingX( x, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingSerial 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingSerialTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingSerial( serial, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingOrientation 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingOrientationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float orientation = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingOrientation( orientation, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingMapSpaceNodeTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatingMapSpaceNode( mapSpaceNode, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingMapTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatingMap( map, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingLocation 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingLocationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingLocation( point3D, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingAI 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingAITest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            IArtificialIntelligence artificialIntelligence = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatingAI( artificialIntelligence, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedZ 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedZTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedZ( z, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedY 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedYTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedY( y, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedX 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedXTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedX( x, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedSerial 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedSerialTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Serial serial = new Serial(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedSerial( serial, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedOrientation 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedOrientationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            float orientation = 0F; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedOrientation( orientation, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedMapSpaceNodeTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedMapSpaceNode( mapSpaceNode, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedMapTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedMap( map, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedLocation 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedLocationTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedLocation( point3D, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedAI 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedAITest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            IArtificialIntelligence artificialIntelligence = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnUpdatedAI( artificialIntelligence, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMovingToWorld 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingToWorldTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D newLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseMap newMap = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMovingToWorld( newLocation, newMap, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMovingTo 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingToTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D location = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMovingTo( location, gameEntity );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMovedToWorld 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedToWorldTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseMap oldMap = null; // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnMovedToWorld( oldLocation, oldMap, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMovedTo 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedToTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            Point3D location = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnMovedTo( location, gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDeletingCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnDeletingCallTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnDeletingCall( gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDeletedCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnDeletedCallTest()
        {
            WorldEntityState target = new WorldEntityState(); // TODO: 初始化为适当的值
            WorldEntity gameEntity = null; // TODO: 初始化为适当的值
            target.OnDeletedCall( gameEntity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WorldEntityState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void WorldEntityStateConstructorTest()
        {
            WorldEntityState target = new WorldEntityState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
