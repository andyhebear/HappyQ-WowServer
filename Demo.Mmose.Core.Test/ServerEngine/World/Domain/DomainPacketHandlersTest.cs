using Demo.Mmose.Core.World.DomainWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 DomainPacketHandlersTest 的测试类，旨在
    ///包含所有 DomainPacketHandlersTest 单元测试
    ///</summary>
    [TestClass()]
    public class DomainPacketHandlersTest
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
        ///Domain_HandlerRemoveCurrentZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerRemoveCurrentZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerRemoveCurrentZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerPongZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerPongZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerPongZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerPingDomain 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerPingDomainTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerPingDomain( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerNotifyRemoveZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerNotifyRemoveZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerNotifyRemoveZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerNotifyAddZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerNotifyAddZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerNotifyAddZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerLoginZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerLoginZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerLoginZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerLoginDomain 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerLoginDomainTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerLoginDomain( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Domain_HandlerAddCurrentZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void Domain_HandlerAddCurrentZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            DomainPacketHandlers.Domain_HandlerAddCurrentZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DomainPacketHandlers 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void DomainPacketHandlersConstructorTest()
        {
            DomainPacketHandlers target = new DomainPacketHandlers();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
