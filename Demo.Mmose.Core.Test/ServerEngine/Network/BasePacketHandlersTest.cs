using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BasePacketHandlersTest 的测试类，旨在
    ///包含所有 BasePacketHandlersTest 单元测试
    ///</summary>
    [TestClass()]
    public class BasePacketHandlersTest
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
        ///RemoveHandler 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveHandlerTest()
        {
            BasePacketHandlers target = new BasePacketHandlers(); // TODO: 初始化为适当的值
            long iPacketID = 0; // TODO: 初始化为适当的值
            target.RemoveHandler( iPacketID );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Register 的测试
        ///</summary>
        [TestMethod()]
        public void RegisterTest()
        {
            BasePacketHandlers target = new BasePacketHandlers(); // TODO: 初始化为适当的值
            long iPacketID = 0; // TODO: 初始化为适当的值
            long iLength = 0; // TODO: 初始化为适当的值
            bool bInGame = false; // TODO: 初始化为适当的值
            PacketReceiveCallback onPacketReceive = null; // TODO: 初始化为适当的值
            target.Register( iPacketID, iLength, bInGame, onPacketReceive );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetHandler 的测试
        ///</summary>
        [TestMethod()]
        public void GetHandlerTest()
        {
            BasePacketHandlers target = new BasePacketHandlers(); // TODO: 初始化为适当的值
            long iPacketID = 0; // TODO: 初始化为适当的值
            PacketHandler expected = null; // TODO: 初始化为适当的值
            PacketHandler actual;
            actual = target.GetHandler( iPacketID );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BasePacketHandlers 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BasePacketHandlersConstructorTest()
        {
            BasePacketHandlers target = new BasePacketHandlers();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
