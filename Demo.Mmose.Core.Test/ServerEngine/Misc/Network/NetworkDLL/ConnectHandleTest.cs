using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConnectHandleTest 的测试类，旨在
    ///包含所有 ConnectHandleTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConnectHandleTest
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
            ConnectHandleManager expected = ConnectHandleManager.Zero; // TODO: 初始化为适当的值
            ConnectHandleManager actual;
            target.SocketHandlerManager = expected;
            actual = target.SocketHandlerManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServerAddress 的测试
        ///</summary>
        [TestMethod()]
        public void ServerAddressTest()
        {
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
            string actual;
            actual = target.ServerAddress;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemotePort 的测试
        ///</summary>
        [TestMethod()]
        public void RemotePortTest()
        {
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
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
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
            long actual;
            actual = target.FirstTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendTo 的测试
        ///</summary>
        [TestMethod()]
        public void SendToTest()
        {
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
            MessageBlock sendMessageBlock = MessageBlock.Zero; // TODO: 初始化为适当的值
            target.SendTo( sendMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ConnectHandle_ServerAddress 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_ServerAddressTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConnectHandle_Accessor.ConnectHandle_ServerAddress( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_SendTo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_SendToTest()
        {
            IntPtr pSendMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            ConnectHandle_Accessor.ConnectHandle_SendTo( pSendMessageBlock, pClientHandlerAtClient );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ConnectHandle_RemotePort 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_RemotePortTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ConnectHandle_Accessor.ConnectHandle_RemotePort( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_RemoteOnlyIP 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_RemoteOnlyIPTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConnectHandle_Accessor.ConnectHandle_RemoteOnlyIP( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_OnlineTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_OnlineTimeTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_OnlineTime( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_MessageBlockSpacingTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_MessageBlockSpacingTimeTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_MessageBlockSpacingTime( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_MessageBlockNumbers60sec 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_MessageBlockNumbers60secTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_MessageBlockNumbers60sec( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_MessageBlockNumbers 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_MessageBlockNumbersTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_MessageBlockNumbers( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_LastMessageBlockTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_LastMessageBlockTimeTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_LastMessageBlockTime( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_IsOnline 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_IsOnlineTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ConnectHandle_Accessor.ConnectHandle_IsOnline( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_FirstTime 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_FirstTimeTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = ConnectHandle_Accessor.ConnectHandle_FirstTime( pClientHandlerAtClient );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectHandle_CloseSocket 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ConnectHandle_CloseSocketTest()
        {
            IntPtr pClientHandlerAtClient = new IntPtr(); // TODO: 初始化为适当的值
            ConnectHandle_Accessor.ConnectHandle_CloseSocket( pClientHandlerAtClient );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CloseSocket 的测试
        ///</summary>
        [TestMethod()]
        public void CloseSocketTest()
        {
            ConnectHandle target = new ConnectHandle(); // TODO: 初始化为适当的值
            target.CloseSocket();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ConnectHandle 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectHandleConstructorTest()
        {
            ConnectHandle target = new ConnectHandle();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
