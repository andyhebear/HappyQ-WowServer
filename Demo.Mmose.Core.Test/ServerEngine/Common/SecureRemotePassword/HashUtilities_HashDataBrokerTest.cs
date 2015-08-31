using Demo.Mmose.Core.Common.Srp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 HashUtilities_HashDataBrokerTest 的测试类，旨在
    ///包含所有 HashUtilities_HashDataBrokerTest 单元测试
    ///</summary>
    [TestClass()]
    public class HashUtilities_HashDataBrokerTest
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
        ///RawData 的测试
        ///</summary>
        [TestMethod()]
        public void RawDataTest()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker target = new HashUtilities.HashDataBroker( data ); // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.RawData;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Length 的测试
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker target = new HashUtilities.HashDataBroker( data ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Length;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest3()
        {
            string str = string.Empty; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker expected = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker actual;
            actual = str;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest2()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker expected = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker actual;
            actual = data;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            uint integer = 0; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker expected = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker actual;
            actual = integer;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Implicit 的测试
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            BigInteger integer = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker expected = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker actual;
            actual = integer;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HashDataBroker 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void HashUtilities_HashDataBrokerConstructorTest()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            HashUtilities.HashDataBroker target = new HashUtilities.HashDataBroker( data );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
