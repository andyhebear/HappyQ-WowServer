using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Net;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ListenerTest 的测试类，旨在
    ///包含所有 ListenerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ListenerTest
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
        ///World 的测试
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            BaseWorld expected = null; // TODO: 初始化为适当的值
            BaseWorld actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ListenerSocket 的测试
        ///</summary>
        [TestMethod()]
        public void ListenerSocketTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            SocketServer actual;
            actual = target.ListenerSocket;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartServerTest1()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            int port = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartServer( port );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartServerTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            string strHostNamePort = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartServer( strHostNamePort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Slice 的测试
        ///</summary>
        [TestMethod()]
        public void SliceTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            ClientSocketManager[] expected = null; // TODO: 初始化为适当的值
            ClientSocketManager[] actual;
            actual = target.Slice();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAcceptor 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnAcceptorTest()
        {
            Listener_Accessor target = new Listener_Accessor(); // TODO: 初始化为适当的值
            ServiceHandleSlim nonceClientHandler = ServiceHandleSlim.Zero; // TODO: 初始化为适当的值
            ServiceHandleManager allHandlerManager = ServiceHandleManager.Zero; // TODO: 初始化为适当的值
            ServiceHandle clientHandlerAtServer = null; // TODO: 初始化为适当的值
            ServiceHandle clientHandlerAtServerExpected = null; // TODO: 初始化为适当的值
            target.OnAcceptor( nonceClientHandler, allHandlerManager, out clientHandlerAtServer );
            Assert.AreEqual( clientHandlerAtServerExpected, clientHandlerAtServer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Free 的测试
        ///</summary>
        [TestMethod()]
        public void FreeTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            ReceiveQueue receiveQueue = null; // TODO: 初始化为适当的值
            target.Free( receiveQueue );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            Listener target = new Listener(); // TODO: 初始化为适当的值
            target.Dispose();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Listener 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ListenerConstructorTest()
        {
            Listener target = new Listener();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
