using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ReceiveQueueTest 的测试类，旨在
    ///包含所有 ReceiveQueueTest 单元测试
    ///</summary>
    [TestClass()]
    public class ReceiveQueueTest
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
        ///Length 的测试
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            long actual;
            actual = target.Length;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetCapacity 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SetCapacityTest()
        {
            ReceiveQueue_Accessor target = new ReceiveQueue_Accessor(); // TODO: 初始化为适当的值
            long iCapacity = 0; // TODO: 初始化为适当的值
            target.SetCapacity( iCapacity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OutProcessReceive 的测试
        ///</summary>
        [TestMethod()]
        public void OutProcessReceiveTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            target.OutProcessReceive();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InProcessReceive 的测试
        ///</summary>
        [TestMethod()]
        public void InProcessReceiveTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.InProcessReceive();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketLength 的测试
        ///</summary>
        [TestMethod()]
        public void GetPacketLengthTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.GetPacketLength();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketID 的测试
        ///</summary>
        [TestMethod()]
        public void GetPacketIDTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.GetPacketID();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPacketHead 的测试
        ///</summary>
        public void GetPacketHeadTestHelper<PacketHeadT>()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            EventHandler<PacketHeadInfoEventArgs<PacketHeadT>> eventHandler = null; // TODO: 初始化为适当的值
            PacketHeadT expected = default( PacketHeadT ); // TODO: 初始化为适当的值
            PacketHeadT actual;
            actual = target.GetPacketHead<PacketHeadT>( eventHandler );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetPacketHeadTest()
        {
            GetPacketHeadTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Enqueue 的测试
        ///</summary>
        [TestMethod()]
        public void EnqueueTest1()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            IntPtr byteBuffer = new IntPtr(); // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            target.Enqueue( byteBuffer, iOffset, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Enqueue 的测试
        ///</summary>
        [TestMethod()]
        public void EnqueueTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            target.Enqueue( byteBuffer, iOffset, iSize );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dequeue 的测试
        ///</summary>
        [TestMethod()]
        public void DequeueTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            byte[] byteBufferExpected = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iSize = 0; // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            actual = target.Dequeue( ref byteBuffer, iOffset, iSize );
            Assert.AreEqual( byteBufferExpected, byteBuffer );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            ReceiveQueue target = new ReceiveQueue(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ReceiveQueue 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ReceiveQueueConstructorTest()
        {
            ReceiveQueue target = new ReceiveQueue();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
