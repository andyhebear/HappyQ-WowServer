using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ByteOrderTest 的测试类，旨在
    ///包含所有 ByteOrderTest 单元测试
    ///</summary>
    [TestClass()]
    public class ByteOrderTest
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
        ///OrderToNet 的测试
        ///</summary>
        [TestMethod()]
        public void OrderToNetTest1()
        {
            ushort iHostUShort = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ByteOrder.OrderToNet( iHostUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OrderToNet 的测试
        ///</summary>
        [TestMethod()]
        public void OrderToNetTest()
        {
            ulong iHostULong = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteOrder.OrderToNet( iHostULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OrderToHost 的测试
        ///</summary>
        [TestMethod()]
        public void OrderToHostTest1()
        {
            ushort iNetUShort = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ByteOrder.OrderToHost( iNetUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OrderToHost 的测试
        ///</summary>
        [TestMethod()]
        public void OrderToHostTest()
        {
            ulong iNetULong = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteOrder.OrderToHost( iNetULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetToHost 的测试
        ///</summary>
        [TestMethod()]
        public void NetToHostTest1()
        {
            ushort iNetUShort = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ByteOrder.NetToHost( iNetUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///NetToHost 的测试
        ///</summary>
        [TestMethod()]
        public void NetToHostTest()
        {
            ulong iNetULong = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteOrder.NetToHost( iNetULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HostToNet 的测试
        ///</summary>
        [TestMethod()]
        public void HostToNetTest1()
        {
            ulong iHostULong = 0; // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = ByteOrder.HostToNet( iHostULong );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HostToNet 的测试
        ///</summary>
        [TestMethod()]
        public void HostToNetTest()
        {
            ushort iHostUShort = 0; // TODO: 初始化为适当的值
            ushort expected = 0; // TODO: 初始化为适当的值
            ushort actual;
            actual = ByteOrder.HostToNet( iHostUShort );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
