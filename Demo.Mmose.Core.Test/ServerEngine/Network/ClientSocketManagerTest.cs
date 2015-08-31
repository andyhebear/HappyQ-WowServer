using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Net;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ClientSocketManagerTest 的测试类，旨在
    ///包含所有 ClientSocketManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ClientSocketManagerTest
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
        ///RemotePort 的测试
        ///</summary>
        [TestMethod()]
        public void RemotePortTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
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
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            string actual;
            actual = target.RemoteOnlyIP;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReceiveBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void ReceiveBufferTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            ReceiveQueue actual;
            actual = target.ReceiveBuffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnlineTime 的测试
        ///</summary>
        [TestMethod()]
        public void OnlineTimeTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            long actual;
            actual = target.OnlineTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetState 的测试
        ///</summary>
        [TestMethod()]
        public void NetStateTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            NetState expected = null; // TODO: 初始化为适当的值
            NetState actual;
            target.NetState = expected;
            actual = target.NetState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessageBlockSpacingTime 的测试
        ///</summary>
        [TestMethod()]
        public void MessageBlockSpacingTimeTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
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
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
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
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            long actual;
            actual = target.MessageBlockNumbers;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ListenerSocket 的测试
        ///</summary>
        [TestMethod()]
        public void ListenerSocketTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            ServiceHandle actual;
            actual = target.ListenerSocket;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Listener 的测试
        ///</summary>
        [TestMethod()]
        public void ListenerTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            Listener actual;
            actual = target.Listener;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LastMessageBlockTime 的测试
        ///</summary>
        [TestMethod()]
        public void LastMessageBlockTimeTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
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
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
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
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            long actual;
            actual = target.FirstTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnecterSocket 的测试
        ///</summary>
        [TestMethod()]
        public void ConnecterSocketTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            ConnectHandle actual;
            actual = target.ConnecterSocket;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Connecter 的测试
        ///</summary>
        [TestMethod()]
        public void ConnecterTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            Connecter actual;
            actual = target.Connecter;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Address 的测试
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            string actual;
            actual = target.Address;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendTo 的测试
        ///</summary>
        [TestMethod()]
        public void SendToTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            MessageBlock sendMessageBlock = MessageBlock.Zero; // TODO: 初始化为适当的值
            target.SendTo( sendMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ReceiveSignal 的测试
        ///</summary>
        [TestMethod()]
        public void ReceiveSignalTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            target.ReceiveSignal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnListenerProcessMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnListenerProcessMessageBlockTest()
        {
            ClientSocketManager_Accessor target = new ClientSocketManager_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            MessageBlockEventArgs recvMessageBlock = null; // TODO: 初始化为适当的值
            target.OnListenerProcessMessageBlock( sender, recvMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnListenerDisconnect 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnListenerDisconnectTest()
        {
            ClientSocketManager_Accessor target = new ClientSocketManager_Accessor(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs emptyEventArgs = null; // TODO: 初始化为适当的值
            target.OnListenerDisconnect( sender, emptyEventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitClientHandler 的测试
        ///</summary>
        [TestMethod()]
        public void InitClientHandlerTest1()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            Listener listener = null; // TODO: 初始化为适当的值
            ServiceHandle serviceHandle = null; // TODO: 初始化为适当的值
            ReceiveQueue receiveBuffer = null; // TODO: 初始化为适当的值
            target.InitClientHandler( listener, serviceHandle, receiveBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitClientHandler 的测试
        ///</summary>
        [TestMethod()]
        public void InitClientHandlerTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            Connecter connecter = null; // TODO: 初始化为适当的值
            ConnectHandle connectHandle = ConnectHandle.Zero; // TODO: 初始化为适当的值
            ReceiveQueue receiveBuffer = null; // TODO: 初始化为适当的值
            target.InitClientHandler( connecter, connectHandle, receiveBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetNewSendMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        public void GetNewSendMessageBlockTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            MessageBlock expected = MessageBlock.Zero; // TODO: 初始化为适当的值
            MessageBlock actual;
            actual = target.GetNewSendMessageBlock();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Free 的测试
        ///</summary>
        [TestMethod()]
        public void FreeTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            target.Free();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisconnectSignal 的测试
        ///</summary>
        [TestMethod()]
        public void DisconnectSignalTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            target.DisconnectSignal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CloseSocket 的测试
        ///</summary>
        [TestMethod()]
        public void CloseSocketTest()
        {
            ClientSocketManager target = new ClientSocketManager(); // TODO: 初始化为适当的值
            target.CloseSocket();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ClientSocketManager 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ClientSocketManagerConstructorTest()
        {
            ClientSocketManager target = new ClientSocketManager();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
