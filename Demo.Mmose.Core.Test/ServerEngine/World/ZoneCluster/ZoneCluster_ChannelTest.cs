using Demo.Mmose.Core.World.ZoneClusterWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.World;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ZoneCluster_ChannelTest 的测试类，旨在
    ///包含所有 ZoneCluster_ChannelTest 单元测试
    ///</summary>
    [TestClass()]
    public class ZoneCluster_ChannelTest
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
        ///remove 的测试
        ///</summary>
        public void removeTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster<WorldT>.Channel target = new ZoneCluster<WorldT>.Channel(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.remove( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void removeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 removeTestHelper<WorldT>()。" );
        }

        /// <summary>
        ///Broadcast 的测试
        ///</summary>
        public void BroadcastTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster<WorldT>.Channel target = new ZoneCluster<WorldT>.Channel(); // TODO: 初始化为适当的值
            target.Broadcast();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void BroadcastTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 BroadcastTestHelper<WorldT>()。" );
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        public void AddTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster<WorldT>.Channel target = new ZoneCluster<WorldT>.Channel(); // TODO: 初始化为适当的值
            NetState netState = null; // TODO: 初始化为适当的值
            target.Add( netState );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 AddTestHelper<WorldT>()。" );
        }

        /// <summary>
        ///Channel 构造函数 的测试
        ///</summary>
        public void ZoneCluster_ChannelConstructorTestHelper<WorldT>()
            where WorldT : BaseWorld, new()
        {
            ZoneCluster<WorldT>.Channel target = new ZoneCluster<WorldT>.Channel();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ZoneCluster_ChannelConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 WorldT 的类型约束的相应类型参数。请以适当的类型参数来调用 ZoneCluster_ChannelConstructorTestHelpe" +
                    "r<WorldT>()。" );
        }
    }
}
