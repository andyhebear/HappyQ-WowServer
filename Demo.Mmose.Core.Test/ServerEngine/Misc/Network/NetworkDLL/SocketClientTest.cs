using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SocketClientTest 的测试类，旨在
    ///包含所有 SocketClientTest 单元测试
    ///</summary>
    [TestClass()]
    public class SocketClientTest
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
        ///IsConnected 的测试
        ///</summary>
        [TestMethod()]
        public void IsConnectedTest()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsConnected;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandleManager 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectHandleManagerTest()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            ConnectHandleManager actual;
            actual = target.ConnectHandleManager;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StopConnect 的测试
        ///</summary>
        [TestMethod()]
        public void StopConnectTest()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            target.StopConnect();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartConnectServer 的测试
        ///</summary>
        [TestMethod()]
        public void StartConnectServerTest()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            string strHostNamePort = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.StartConnectServer( strHostNamePort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketClient_StopConnect 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketClient_StopConnectTest()
        {
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            SocketClient_Accessor.SocketClient_StopConnect( pSocketMainServer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SocketClient_SendBuffer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketClient_SendBufferTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = SocketClient_Accessor.SocketClient_SendBuffer( pMessageBlock, pSocketMainServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketClient_IsConnected 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketClient_IsConnectedTest()
        {
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = SocketClient_Accessor.SocketClient_IsConnected( pSocketMainServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketClient_GetConnectHandlerManager 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SocketClient_GetConnectHandlerManagerTest()
        {
            IntPtr pSocketHandlerManagerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtClientExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketMainServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = SocketClient_Accessor.SocketClient_GetConnectHandlerManager( ref pSocketHandlerManagerAtClient, pSocketMainServer );
            Assert.AreEqual( pSocketHandlerManagerAtClientExpected, pSocketHandlerManagerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void SendBufferTest1()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            MessageBlock messageBlock = MessageBlock.Zero; // TODO: 初始化为适当的值
            target.SendBuffer( messageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SendBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void SendBufferTest()
        {
            SocketClient target = new SocketClient(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            int iLength = 0; // TODO: 初始化为适当的值
            target.SendBuffer( byteBuffer, iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnProcessMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnProcessMessageBlockTest()
        {
            SocketClient_Accessor target = new SocketClient_Accessor(); // TODO: 初始化为适当的值
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
            SocketClient_Accessor target = new SocketClient_Accessor(); // TODO: 初始化为适当的值
            IntPtr pNonceClientHandler = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pAllHandlerManager = new IntPtr(); // TODO: 初始化为适当的值
            target.OnDisconnect( pNonceClientHandler, pAllHandlerManager );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SocketClient 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SocketClientConstructorTest()
        {
            SocketClient target = new SocketClient();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
