using Demo.Mmose.Core.World.ZoneClusterWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ZoneClusterPacketHandlersTest 的测试类，旨在
    ///包含所有 ZoneClusterPacketHandlersTest 单元测试
    ///</summary>
    [TestClass()]
    public class ZoneClusterPacketHandlersTest
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
        ///ZoneCluster_HandlerZonePingZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerZonePingZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerZonePingZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerRemoveCurrentZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerRemoveCurrentZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerRemoveCurrentZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerRemoveCurrentZone 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerRemoveCurrentZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerRemoveCurrentZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerPongZone 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerPongZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerPongZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerPongDomain 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerPongDomainTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerPongDomain( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerNotifyRemoveZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerNotifyRemoveZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyRemoveZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerNotifyRemoveZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerNotifyRemoveZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyRemoveZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerNotifyAddZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerNotifyAddZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyAddZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerNotifyAddZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerNotifyAddZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerNotifyAddZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerLoginZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerLoginZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerLoginZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerLoginZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerLoginZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerLoginZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerLoginDomainResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerLoginDomainResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerLoginDomainResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerDomainPingZoneCluster 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerDomainPingZoneClusterTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerDomainPingZoneCluster( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerAddCurrentZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerAddCurrentZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerAddCurrentZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneCluster_HandlerAddCurrentZone 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneCluster_HandlerAddCurrentZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZoneClusterPacketHandlers.ZoneCluster_HandlerAddCurrentZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZoneClusterPacketHandlers 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ZoneClusterPacketHandlersConstructorTest()
        {
            ZoneClusterPacketHandlers target = new ZoneClusterPacketHandlers();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
