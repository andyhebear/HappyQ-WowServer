using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MapManagerTest 的测试类，旨在
    ///包含所有 MapManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class MapManagerTest
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
        ///MapCount 的测试
        ///</summary>
        public void MapCountTestHelper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>(); // TODO: 初始化为适当的值
            int actual;
            actual = target.MapCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void MapCountTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 MapCountTestHelper<MapT>()。" );
        }

        /// <summary>
        ///ToArrayInMaps 的测试
        ///</summary>
        public void ToArrayInMapsTestHelper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>(); // TODO: 初始化为适当的值
            MapT[] expected = null; // TODO: 初始化为适当的值
            MapT[] actual;
            actual = target.ToArrayInMaps();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayInMapsTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 ToArrayInMapsTestHelper<MapT>()。" );
        }

        /// <summary>
        ///RemoveMap 的测试
        ///</summary>
        public void RemoveMapTestHelper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>(); // TODO: 初始化为适当的值
            Serial mapId = new Serial(); // TODO: 初始化为适当的值
            target.RemoveMap( mapId );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveMapTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 RemoveMapTestHelper<MapT>()。" );
        }

        /// <summary>
        ///GetMap 的测试
        ///</summary>
        public void GetMapTestHelper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>(); // TODO: 初始化为适当的值
            Serial mapId = new Serial(); // TODO: 初始化为适当的值
            MapT expected = default( MapT ); // TODO: 初始化为适当的值
            MapT actual;
            actual = target.GetMap( mapId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetMapTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 GetMapTestHelper<MapT>()。" );
        }

        /// <summary>
        ///AddMap 的测试
        ///</summary>
        public void AddMapTestHelper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>(); // TODO: 初始化为适当的值
            Serial mapId = new Serial(); // TODO: 初始化为适当的值
            MapT addMap = default( MapT ); // TODO: 初始化为适当的值
            target.AddMap( mapId, addMap );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddMapTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 AddMapTestHelper<MapT>()。" );
        }

        /// <summary>
        ///MapManager`1 构造函数 的测试
        ///</summary>
        public void MapManagerConstructorTest1Helper<MapT>()
            where MapT : BaseMap
        {
            MapManager<MapT> target = new MapManager<MapT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MapManagerConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 MapManagerConstructorTest1Helper<MapT>()。" +
                    "" );
        }

        /// <summary>
        ///MapManager`1 构造函数 的测试
        ///</summary>
        public void MapManagerConstructorTestHelper<MapT>()
            where MapT : BaseMap
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            MapManager<MapT> target = new MapManager<MapT>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MapManagerConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 MapManagerConstructorTestHelper<MapT>()。" );
        }
    }
}
