using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ServiceHandleManagerTest 的测试类，旨在
    ///包含所有 ServiceHandleManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ServiceHandleManagerTest
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
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            target.Handle = expected;
            actual = target.Handle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnlineClientCount 的测试
        ///</summary>
        [TestMethod()]
        public void OnlineClientCountTest()
        {
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            int actual;
            actual = target.OnlineClientCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Item 的测试
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            string strIndex = string.Empty; // TODO: 初始化为适当的值
            ServiceHandleSlim actual;
            actual = target[strIndex];
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ClientCount 的测试
        ///</summary>
        [TestMethod()]
        public void ClientCountTest()
        {
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            int actual;
            actual = target.ClientCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager_TotalClients 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandleManager_TotalClientsTest()
        {
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ServiceHandleManager_Accessor.ServiceHandleManager_TotalClients( pSocketHandlerManagerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager_SendToAll 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandleManager_SendToAllTest()
        {
            IntPtr pMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ServiceHandleManager_Accessor.ServiceHandleManager_SendToAll( pMessageBlock, pSocketHandlerManagerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager_OnlineClients 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandleManager_OnlineClientsTest()
        {
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ServiceHandleManager_Accessor.ServiceHandleManager_OnlineClients( pSocketHandlerManagerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager_GetNewSendMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandleManager_GetNewSendMessageBlockTest()
        {
            IntPtr pNewSendMessageBlock = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pNewSendMessageBlockExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ServiceHandleManager_Accessor.ServiceHandleManager_GetNewSendMessageBlock( ref pNewSendMessageBlock, pSocketHandlerManagerAtServer );
            Assert.AreEqual( pNewSendMessageBlockExpected, pNewSendMessageBlock );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager_GetClientHandle 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ServiceHandleManager_GetClientHandleTest()
        {
            string strIndex = string.Empty; // TODO: 初始化为适当的值
            IntPtr pClientHandlerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pClientHandlerAtServerExpected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr pSocketHandlerManagerAtServer = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ServiceHandleManager_Accessor.ServiceHandleManager_GetClientHandle( strIndex, ref pClientHandlerAtServer, pSocketHandlerManagerAtServer );
            Assert.AreEqual( pClientHandlerAtServerExpected, pClientHandlerAtServer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendToAll 的测试
        ///</summary>
        [TestMethod()]
        public void SendToAllTest()
        {
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            MessageBlock sendMessageBlock = MessageBlock.Zero; // TODO: 初始化为适当的值
            target.SendToAll( sendMessageBlock );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetNewSendMessageBlock 的测试
        ///</summary>
        [TestMethod()]
        public void GetNewSendMessageBlockTest()
        {
            ServiceHandleManager target = new ServiceHandleManager(); // TODO: 初始化为适当的值
            MessageBlock expected = MessageBlock.Zero; // TODO: 初始化为适当的值
            MessageBlock actual;
            actual = target.GetNewSendMessageBlock();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ServiceHandleManager 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ServiceHandleManagerConstructorTest()
        {
            ServiceHandleManager target = new ServiceHandleManager();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
