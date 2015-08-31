using Demo.Mmose.Core.World.Zone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Network;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ZonePacketHandlersTest 的测试类，旨在
    ///包含所有 ZonePacketHandlersTest 单元测试
    ///</summary>
    [TestClass()]
    public class ZonePacketHandlersTest
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
        ///Zone_HandlerRemoveCurrentZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerRemoveCurrentZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerRemoveCurrentZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerPongZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerPongZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerPongZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerPingZone 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerPingZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerPingZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerNotifyRemoveZone 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerNotifyRemoveZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerNotifyRemoveZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerNotifyAddZone 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerNotifyAddZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerNotifyAddZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerLoginZoneClusterResult 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerLoginZoneClusterResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerLoginZoneClusterResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerLoginZone 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerLoginZoneTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerLoginZone( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Zone_HandlerAddCurrentZoneResult 的测试
        ///</summary>
        [TestMethod()]
        public void Zone_HandlerAddCurrentZoneResultTest()
        {
            NetState netState = null; // TODO: 初始化为适当的值
            PacketReader packetReader = null; // TODO: 初始化为适当的值
            ZonePacketHandlers.Zone_HandlerAddCurrentZoneResult( netState, packetReader );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ZonePacketHandlers 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ZonePacketHandlersConstructorTest()
        {
            ZonePacketHandlers target = new ZonePacketHandlers();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
