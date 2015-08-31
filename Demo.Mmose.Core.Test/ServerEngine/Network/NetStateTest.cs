using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common.Component;
using System;
using System.Net;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.World;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 NetStateTest 的测试类，旨在
    ///包含所有 NetStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class NetStateTest
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
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            BaseWorld actual;
            actual = target.World;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WaitSendSize 的测试
        ///</summary>
        [TestMethod()]
        public void WaitSendSizeTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            long actual;
            actual = target.WaitSendSize;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Version 的测试
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            VersionInfo expected = null; // TODO: 初始化为适当的值
            VersionInfo actual;
            target.Version = expected;
            actual = target.Version;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendQueue 的测试
        ///</summary>
        [TestMethod()]
        public void SendQueueTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            SendQueue actual;
            actual = target.SendQueue;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendMaxSize1Sec 的测试
        ///</summary>
        [TestMethod()]
        public void SendMaxSize1SecTest()
        {
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            NetState.SendMaxSize1Sec = expected;
            actual = NetState.SendMaxSize1Sec;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Running 的测试
        ///</summary>
        [TestMethod()]
        public void RunningTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Running;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReceiveBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void ReceiveBufferTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ReceiveQueue actual;
            actual = target.ReceiveBuffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Player 的测试
        ///</summary>
        [TestMethod()]
        public void PlayerTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            BaseCharacter expected = null; // TODO: 初始化为适当的值
            BaseCharacter actual;
            target.Player = expected;
            actual = target.Player;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PacketEncoder 的测试
        ///</summary>
        [TestMethod()]
        public void PacketEncoderTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            IPacketEncoder expected = null; // TODO: 初始化为适当的值
            IPacketEncoder actual;
            target.PacketEncoder = expected;
            actual = target.PacketEncoder;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetSocket 的测试
        ///</summary>
        [TestMethod()]
        public void NetSocketTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ClientSocketManager actual;
            actual = target.NetSocket;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetAddress 的测试
        ///</summary>
        [TestMethod()]
        public void NetAddressTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            IPEndPoint actual;
            actual = target.NetAddress;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MessagePump 的测试
        ///</summary>
        [TestMethod()]
        public void MessagePumpTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            MessagePump actual;
            actual = target.MessagePump;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsCheckActivity 的测试
        ///</summary>
        [TestMethod()]
        public void IsCheckActivityTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsCheckActivity = expected;
            actual = target.IsCheckActivity;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectedOn 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectedOnTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            DateTime actual;
            actual = target.ConnectedOn;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConnectedFor 的测试
        ///</summary>
        [TestMethod()]
        public void ConnectedForTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            TimeSpan actual;
            actual = target.ConnectedFor;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BlockSend 的测试
        ///</summary>
        [TestMethod()]
        public void BlockSendTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.BlockSend = expected;
            actual = target.BlockSend;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Start 的测试
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.Start();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Send 的测试
        ///</summary>
        [TestMethod()]
        public void SendTest1()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            SendPriority sendPriority = new SendPriority(); // TODO: 初始化为适当的值
            Packet packet = null; // TODO: 初始化为适当的值
            target.Send( sendPriority, packet );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Send 的测试
        ///</summary>
        [TestMethod()]
        public void SendTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            Packet packet = null; // TODO: 初始化为适当的值
            target.Send( packet );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T component = null; // TODO: 初始化为适当的值
            target.RegisterComponent<T>( componentId, component );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RegisterComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RegisterComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///PostComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void PostComponentMessageTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OutProcessQueue 的测试
        ///</summary>
        [TestMethod()]
        public void OutProcessQueueTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.OutProcessQueue();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OutFlushQueue 的测试
        ///</summary>
        [TestMethod()]
        public void OutFlushQueueTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.OutFlushQueue();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnReceive 的测试
        ///</summary>
        [TestMethod()]
        public void OnReceiveTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.OnReceive();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnHandleComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void OnHandleComponentMessageTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.OnHandleComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDisconnect 的测试
        ///</summary>
        [TestMethod()]
        public void OnDisconnectTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.OnDisconnect();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///JoinWorld 的测试
        ///</summary>
        [TestMethod()]
        public void JoinWorldTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.JoinWorld();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InternalSend 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InternalSendTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            NetState_Accessor target = new NetState_Accessor( param0 ); // TODO: 初始化为适当的值
            Packet packet = null; // TODO: 初始化为适当的值
            target.InternalSend( packet );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InsideDispose 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InsideDisposeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            NetState_Accessor target = new NetState_Accessor( param0 ); // TODO: 初始化为适当的值
            target.InsideDispose();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InProcessQueue 的测试
        ///</summary>
        [TestMethod()]
        public void InProcessQueueTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InProcessQueue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InFlushQueue 的测试
        ///</summary>
        [TestMethod()]
        public void InFlushQueueTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InFlushQueue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetComponent 的测试
        ///</summary>
        public void GetComponentTestHelper<T>()
            where T : class, IComponent
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.GetComponent<T>( componentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///Flush 的测试
        ///</summary>
        [TestMethod()]
        public void FlushTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Flush();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ExitWorld 的测试
        ///</summary>
        [TestMethod()]
        public void ExitWorldTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.ExitWorld();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest2()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool bFlush = false; // TODO: 初始化为适当的值
            long iSeconds = 0; // TODO: 初始化为适当的值
            target.Dispose( bFlush, iSeconds );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest1()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            target.Dispose();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dispose 的测试
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool bFlush = false; // TODO: 初始化为适当的值
            target.Dispose( bFlush );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CheckAlive 的测试
        ///</summary>
        [TestMethod()]
        public void CheckAliveTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CheckAlive();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void NetStateConstructorTest()
        {
            ClientSocketManager clientSocket = null; // TODO: 初始化为适当的值
            MessagePump messagePump = null; // TODO: 初始化为适当的值
            NetState target = new NetState( clientSocket, messagePump );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
