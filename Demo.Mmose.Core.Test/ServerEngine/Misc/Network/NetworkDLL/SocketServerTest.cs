using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SocketServerTest 的测试类，旨在
    ///包含所有 SocketServerTest 单元测试
    ///</summary>
    [TestClass()]
    public class SocketServerTest
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
        ///ServiceHandleManager 的测试
        ///</summary>
        [TestMethod()]
        public void ServiceHandleManagerTest()
        {
            SocketServer target = new SocketServer(); // TODO: 初始化为适当的值
            ServiceHandleManager actual;
            actual = target.ServiceHandleManager;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsConnected 的测试
        ///</summary>
        [TestMethod()]
        public void IsConnectedTest()
        {
            SocketServer target = new SocketServer(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsConnected;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StopServer 的测试
        ///</summary>
        [TestMethod()]
        public void StopServerTest()
        {
            SocketServer target = new SocketServer(); // TODO: 初始化为适当的值
            target.StopServer();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartServerTest1()
        {
            SocketServer target = new SocketServer(); // TODO: 初始化为适当的值
            int iPort = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartServer( iPort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartServerTest()
        {
            SocketServer target = new SocketServer(); // TODO: 初始化为适当的值
            string strHostNamePort = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartServer( strHostNamePort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketServer_StopServer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketServer_StopServerTest()
        {
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            SocketServer_Accessor.SocketServer_StopServer( pSocketMainServer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SocketServer_IsConnected 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketServer_IsConnectedTest()
        {
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = SocketServer_Accessor.SocketServer_IsConnected( pSocketMainServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketServer_GetServiceHandleManager 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketServer_GetServiceHandleManagerTest()
        {
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtServerExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = SocketServer_Accessor.SocketServer_GetServiceHandleManager( ref pSocketHandlerManagerAtServer, pSocketMainServer );
            Assert.AreEqual( pSocketHandlerManagerAtServerExpected, pSocketHandlerManagerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnProcessMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnProcessMessageBlockTest()
        {
            SocketServer_Accessor target = new SocketServer_Accessor(); // TODO: 初始化为适当的值
            IntPtr pRecvMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pNonceClientHandler = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pAllHandlerManager = new IntPtr(); // TODO: 初始化为适当的值
            target.OnProcessMessageBlock( pRecvMessageBlock, pNonceClientHandler, pAllHandlerManager );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDisconnect 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnDisconnectTest()
        {
            SocketServer_Accessor target = new SocketServer_Accessor(); // TODO: 初始化为适当的值
            IntPtr pNonceClientHandler = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pAllHandlerManager = new IntPtr(); // TODO: 初始化为适当的值
            target.OnDisconnect( pNonceClientHandler, pAllHandlerManager );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAcceptor 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnAcceptorTest()
        {
            // 未找到 OnAcceptor 的专用访问器。请重新生成包含项目或者手动运行 Publicize.exe。
            Assert.Inconclusive( "未找到 OnAcceptor 的专用访问器。请重新生成包含项目或者手动运行 Publicize.exe。" );
        }

        /// <summary>
        ///SocketServer 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SocketServerConstructorTest()
        {
            SocketServer target = new SocketServer();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
