using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MapSpaceNodeStateTest 的测试类，旨在
    ///包含所有 MapSpaceNodeStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class MapSpaceNodeStateTest
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
            MapSpaceNodeState actual;
            actual = MapSpaceNodeState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLeavingMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapSpaceNodeTest3()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavingMapSpaceNode( character, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavingMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapSpaceNodeTest2()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavingMapSpaceNode( creature, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavingMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapSpaceNodeTest1()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavingMapSpaceNode( worldEntity, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavingMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavingMapSpaceNodeTest()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavingMapSpaceNode( item, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapSpaceNodeTest3()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavedMapSpaceNode( creature, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapSpaceNodeTest2()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavedMapSpaceNode( character, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapSpaceNodeTest1()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavedMapSpaceNode( worldEntity, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeavedMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeavedMapSpaceNodeTest()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnLeavedMapSpaceNode( item, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteringMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapSpaceNodeTest3()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteringMapSpaceNode( item, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteringMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapSpaceNodeTest2()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteringMapSpaceNode( worldEntity, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteringMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapSpaceNodeTest1()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteringMapSpaceNode( character, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteringMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteringMapSpaceNodeTest()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteringMapSpaceNode( creature, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapSpaceNodeTest3()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            WorldEntity worldEntity = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteredMapSpaceNode( worldEntity, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapSpaceNodeTest2()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteredMapSpaceNode( character, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapSpaceNodeTest1()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteredMapSpaceNode( creature, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnteredMapSpaceNode 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnteredMapSpaceNodeTest()
        {
            MapSpaceNodeState target = new MapSpaceNodeState(); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            MapSpaceNode mapSpaceNode = null; // TODO: 初始化为适当的值
            target.OnEnteredMapSpaceNode( item, mapSpaceNode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MapSpaceNodeState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MapSpaceNodeStateConstructorTest()
        {
            MapSpaceNodeState target = new MapSpaceNodeState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
