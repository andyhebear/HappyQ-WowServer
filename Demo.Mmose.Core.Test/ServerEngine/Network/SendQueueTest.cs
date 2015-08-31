using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SendQueueTest 的测试类，旨在
    ///包含所有 SendQueueTest 单元测试
    ///</summary>
    [TestClass()]
    public class SendQueueTest
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
        ///WaitSendSize 的测试
        ///</summary>
        [TestMethod()]
        public void WaitSendSizeTest()
        {
            SendQueue target = new SendQueue(); // TODO: 初始化为适当的值
            long actual;
            actual = target.WaitSendSize;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsEmpty 的测试
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest()
        {
            SendQueue target = new SendQueue(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsEmpty;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CoalesceBufferSize 的测试
        ///</summary>
        [TestMethod()]
        public void CoalesceBufferSizeTest()
        {
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            SendQueue.CoalesceBufferSize = expected;
            actual = SendQueue.CoalesceBufferSize;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReleaseBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseBufferTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            SendQueue.ReleaseBuffer( byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Enqueue 的测试
        ///</summary>
        [TestMethod()]
        public void EnqueueTest()
        {
            SendQueue target = new SendQueue(); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long iOffset = 0; // TODO: 初始化为适当的值
            long iLength = 0; // TODO: 初始化为适当的值
            target.Enqueue( byteBuffer, iOffset, iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Dequeue 的测试
        ///</summary>
        [TestMethod()]
        public void DequeueTest()
        {
            SendQueue target = new SendQueue(); // TODO: 初始化为适当的值
            SendBuffer expected = new SendBuffer(); // TODO: 初始化为适当的值
            SendBuffer actual;
            actual = target.Dequeue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            SendQueue target = new SendQueue(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AcquireBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void AcquireBufferTest()
        {
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = SendQueue.AcquireBuffer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SendQueue 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void SendQueueConstructorTest()
        {
            SendQueue target = new SendQueue();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
