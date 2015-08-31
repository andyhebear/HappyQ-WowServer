using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseMapStateTest 的测试类，旨在
    ///包含所有 BaseMapStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseMapStateTest
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
            BaseMapState actual;
            actual = BaseMapState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMoving 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMoving( oldLocation, character, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMoving 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMoving( oldLocation, creature, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMoving 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMoving( oldLocation, item, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMoving 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovingTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnMoving( oldLocation, worldEntity, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnMoved 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnMoved( oldLocation, worldEntity, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMoved 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnMoved( oldLocation, item, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMoved 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnMoved( oldLocation, creature, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnMoved 的测试
        ///</summary>
        [TestMethod()]
        public void OnMovedTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnMoved( oldLocation, character, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavingMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeavingMap( character, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeavingMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeavingMap( item, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeavingMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeavingMap( creature, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeavingMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLeavingMap( worldEntity, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeavedMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnLeavedMap( worldEntity, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnLeavedMap( item, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnLeavedMap( creature, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnLeavedMap( character, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteringMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnteringMap( creature, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnteringMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnteringMap( item, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnteringMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnteringMap( character, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnteringMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnEnteringMap( worldEntity, map );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnEnteredMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapTest3()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnEnteredMap( creature, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapTest2()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnEnteredMap( worldEntity, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapTest1()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnEnteredMap( character, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMap 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapTest()
        {
            BaseMapState target = new BaseMapState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            target.OnEnteredMap( item, map );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseMapState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseMapStateConstructorTest()
        {
            BaseMapState target = new BaseMapState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
