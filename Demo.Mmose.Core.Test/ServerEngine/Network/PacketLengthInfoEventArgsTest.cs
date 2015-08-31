using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketLengthInfoEventArgsTest 的测试类，旨在
    ///包含所有 PacketLengthInfoEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketLengthInfoEventArgsTest
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
        ///PacketLength 的测试
        ///</summary>
        [TestMethod()]
        public void PacketLengthTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketLengthInfoEventArgs target = new PacketLengthInfoEventArgs( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.PacketLength = expected;
            actual = target.PacketLength;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HeadIndex 的测试
        ///</summary>
        [TestMethod()]
        public void HeadIndexTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketLengthInfoEventArgs target = new PacketLengthInfoEventArgs( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            long actual;
            actual = target.HeadIndex;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BufferSize 的测试
        ///</summary>
        [TestMethod()]
        public void BufferSizeTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketLengthInfoEventArgs target = new PacketLengthInfoEventArgs( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            long actual;
            actual = target.BufferSize;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Buffer 的测试
        ///</summary>
        [TestMethod()]
        public void BufferTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketLengthInfoEventArgs target = new PacketLengthInfoEventArgs( byteBuffer, bufferSize, iHeadIndex ); // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.Buffer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PacketLengthInfoEventArgs 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void PacketLengthInfoEventArgsConstructorTest()
        {
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            long bufferSize = 0; // TODO: 初始化为适当的值
            long iHeadIndex = 0; // TODO: 初始化为适当的值
            PacketLengthInfoEventArgs target = new PacketLengthInfoEventArgs( byteBuffer, bufferSize, iHeadIndex );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
