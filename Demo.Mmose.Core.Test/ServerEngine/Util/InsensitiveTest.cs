using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 InsensitiveTest 的测试类，旨在
    ///包含所有 InsensitiveTest 单元测试
    ///</summary>
    [TestClass()]
    public class InsensitiveTest
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
        ///Comparer 的测试
        ///</summary>
        [TestMethod()]
        public void ComparerTest()
        {
            IComparer actual;
            actual = Insensitive.Comparer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StartsWith 的测试
        ///</summary>
        [TestMethod()]
        public void StartsWithTest()
        {
            string strStringA = string.Empty; // TODO: 初始化为适当的值
            string strStringB = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Insensitive.StartsWith( strStringA, strStringB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Equals 的测试
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            string strStringA = string.Empty; // TODO: 初始化为适当的值
            string strStringB = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Insensitive.Equals( strStringA, strStringB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///EndsWith 的测试
        ///</summary>
        [TestMethod()]
        public void EndsWithTest()
        {
            string strStringA = string.Empty; // TODO: 初始化为适当的值
            string strStringB = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Insensitive.EndsWith( strStringA, strStringB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            string strStringA = string.Empty; // TODO: 初始化为适当的值
            string strStringB = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Insensitive.Contains( strStringA, strStringB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Compare 的测试
        ///</summary>
        [TestMethod()]
        public void CompareTest()
        {
            string strStringA = string.Empty; // TODO: 初始化为适当的值
            string strStringB = string.Empty; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = Insensitive.Compare( strStringA, strStringB );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
