using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketHeadInfoEventArgsTest 的测试类，旨在
    ///包含所有 PacketHeadInfoEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketHeadInfoEventArgsTest
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
        ///PacketHead 的测试
        ///</summary>
        public void PacketHeadTestHelper<PacketHeadT>()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketHeadInfoEventArgs<PacketHeadT> target = new PacketHeadInfoEventArgs<PacketHeadT>( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            PacketHeadT expected = default( PacketHeadT ); // TODO: 初始化为适当的值
            PacketHeadT actual;
            target.PacketHead = expected;
            actual = target.PacketHead;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void PacketHeadTest()
        {
            PacketHeadTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///HeadIndex 的测试
        ///</summary>
        public void HeadIndexTestHelper<PacketHeadT>()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketHeadInfoEventArgs<PacketHeadT> target = new PacketHeadInfoEventArgs<PacketHeadT>( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            long actual;
            actual = target.HeadIndex;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void HeadIndexTest()
        {
            HeadIndexTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///BufferSize 的测试
        ///</summary>
        public void BufferSizeTestHelper<PacketHeadT>()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketHeadInfoEventArgs<PacketHeadT> target = new PacketHeadInfoEventArgs<PacketHeadT>( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            long actual;
            actual = target.BufferSize;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void BufferSizeTest()
        {
            BufferSizeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Buffer 的测试
        ///</summary>
        public void BufferTestHelper<PacketHeadT>()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketHeadInfoEventArgs<PacketHeadT> target = new PacketHeadInfoEventArgs<PacketHeadT>( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.Buffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void BufferTest()
        {
            BufferTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///PacketHeadInfoEventArgs`1 构造函数 的测试
        ///</summary>
        public void PacketHeadInfoEventArgsConstructorTestHelper<PacketHeadT>()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketHeadInfoEventArgs<PacketHeadT> target = new PacketHeadInfoEventArgs<PacketHeadT>( byteBuffer, bufferSize, iHeadIndex );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void PacketHeadInfoEventArgsConstructorTest()
        {
            PacketHeadInfoEventArgsConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
