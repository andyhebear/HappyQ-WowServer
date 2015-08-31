using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 PacketTest 的测试类，旨在
    ///包含所有 PacketTest 单元测试
    ///</summary>
    [TestClass()]
    public class PacketTest
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
        ///WriterStream 的测试
        ///</summary>
        [TestMethod()]
        public void WriterStreamTest()
        {
            Packet target = CreatePacket(); // TODO: 初始化为适当的值
            PacketWriter actual;
            actual = target.WriterStream;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PacketID 的测试
        ///</summary>
        [TestMethod()]
        public void PacketIDTest()
        {
            Packet target = CreatePacket(); // TODO: 初始化为适当的值
            long actual;
            actual = target.PacketID;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Release 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseTest()
        {
            Packet target = CreatePacket(); // TODO: 初始化为适当的值
            target.Release();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Rebulid 的测试
        ///</summary>
        [TestMethod()]
        public void RebulidTest()
        {
            Packet target = CreatePacket(); // TODO: 初始化为适当的值
            int iLength = 0; // TODO: 初始化为适当的值
            target.Rebulid( iLength );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        internal virtual Packet CreatePacket()
        {
            // TODO: 实例化相应的具体类。
            Packet target = null;
            return target;
        }

        /// <summary>
        ///AcquireBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void AcquireBufferTest()
        {
            Packet target = CreatePacket(); // TODO: 初始化为适当的值
            PacketBuffer expected = new PacketBuffer(); // TODO: 初始化为适当的值
            PacketBuffer actual;
            actual = target.AcquireBuffer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
