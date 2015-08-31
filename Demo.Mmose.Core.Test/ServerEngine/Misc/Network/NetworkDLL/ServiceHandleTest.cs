using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ServiceHandleTest 的测试类，旨在
    ///包含所有 ServiceHandleTest 单元测试
    ///</summary>
    [TestClass()]
    public class ServiceHandleTest
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
        ///Value 的测试
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            target.Handle = expected;
            actual = target.Handle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SocketHandlerManager 的测试
        ///</summary>
        [TestMethod()]
        public void SocketHandlerManagerTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            ServiceHandleManager expected = ServiceHandleManager.Zero; // TODO: 初始化为适当的值
            ServiceHandleManager actual;
            target.SocketHandlerManager = expected;
            actual = target.SocketHandlerManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemotePort 的测试
        ///</summary>
        [TestMethod()]
        public void RemotePortTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            int actual;
            actual = target.RemotePort;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoteOnlyIP 的测试
        ///</summary>
        [TestMethod()]
        public void RemoteOnlyIPTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            string actual;
            actual = target.RemoteOnlyIP;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnlineTime 的测试
        ///</summary>
        [TestMethod()]
        public void OnlineTimeTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.OnlineTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlockSpacingTime 的测试
        ///</summary>
        [TestMethod()]
        public void MessageBlockSpacingTimeTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.MessageBlockSpacingTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlockNumbers60sec 的测试
        ///</summary>
        [TestMethod()]
        public void MessageBlockNumbers60secTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.MessageBlockNumbers60sec;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlockNumbers 的测试
        ///</summary>
        [TestMethod()]
        public void MessageBlockNumbersTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.MessageBlockNumbers;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LastMessageBlockTime 的测试
        ///</summary>
        [TestMethod()]
        public void LastMessageBlockTimeTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.LastMessageBlockTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsOnline 的测试
        ///</summary>
        [TestMethod()]
        public void IsOnlineTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsOnline;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FirstTime 的测试
        ///</summary>
        [TestMethod()]
        public void FirstTimeTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.FirstTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ClientAddress 的测试
        ///</summary>
        [TestMethod()]
        public void ClientAddressTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            string actual;
            actual = target.ClientAddress;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_SendTo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_SendToTest()
        {
            IntPtr pSendMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            ServiceHandle_Accessor.ServiceHandle_SendTo( pSendMessageBlock, pClientHandlerAtServer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ServiceHandle_RemotePort 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_RemotePortTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ServiceHandle_Accessor.ServiceHandle_RemotePort( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_RemoteOnlyIP 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_RemoteOnlyIPTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ServiceHandle_Accessor.ServiceHandle_RemoteOnlyIP( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_OnlineTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_OnlineTimeTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_OnlineTime( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_MessageBlockSpacingTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_MessageBlockSpacingTimeTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_MessageBlockSpacingTime( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_MessageBlockNumbers60sec 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_MessageBlockNumbers60secTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_MessageBlockNumbers60sec( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_MessageBlockNumbers 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_MessageBlockNumbersTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_MessageBlockNumbers( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_LastMessageBlockTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_LastMessageBlockTimeTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_LastMessageBlockTime( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_IsOnline 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_IsOnlineTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ServiceHandle_Accessor.ServiceHandle_IsOnline( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_FirstTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_FirstTimeTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ServiceHandle_Accessor.ServiceHandle_FirstTime( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandle_CloseSocket 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_CloseSocketTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            ServiceHandle_Accessor.ServiceHandle_CloseSocket( pClientHandlerAtServer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ServiceHandle_ClientAddress 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandle_ClientAddressTest()
        {
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ServiceHandle_Accessor.ServiceHandle_ClientAddress( pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendTo 的测试
        ///</summary>
        [TestMethod()]
        public void SendToTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            MessageBlock sendMessageBlock = MessageBlock.Zero; // TODO: 初始化为适当的值
            target.SendTo( sendMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnProcessMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnProcessMessageBlockTest()
        {
            ServiceHandle_Accessor target = new ServiceHandle_Accessor(); // TODO: 初始化为适当的值
            IntPtr pRecvMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            target.OnProcessMessageBlock( pRecvMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDisconnect 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnDisconnectTest()
        {
            ServiceHandle_Accessor target = new ServiceHandle_Accessor(); // TODO: 初始化为适当的值
            target.OnDisconnect();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CloseSocket 的测试
        ///</summary>
        [TestMethod()]
        public void CloseSocketTest()
        {
            ServiceHandle target = new ServiceHandle(); // TODO: 初始化为适当的值
            target.CloseSocket();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ServiceHandle 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ServiceHandleConstructorTest()
        {
            ServiceHandle target = new ServiceHandle();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
