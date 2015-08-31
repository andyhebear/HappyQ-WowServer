using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 LOGsTest 的测试类，旨在
    ///包含所有 LOGsTest 单元测试
    ///</summary>
    [TestClass()]
    public class LOGsTest
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
        ///WriteLineLogFile 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineLogFileTest1()
        {
            string strFileName = string.Empty; // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            LOGs.WriteLineLogFile( strFileName, strFormat );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLineLogFile 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineLogFileTest()
        {
            string strFileName = string.Empty; // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            object[] arg = null; // TODO: 初始化为适当的值
            LOGs.WriteLineLogFile( strFileName, strFormat, arg );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest1()
        {
            LogMessageType messageFlag = new LogMessageType(); // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            object[] arg = null; // TODO: 初始化为适当的值
            LOGs.WriteLine( messageFlag, strFormat, arg );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest()
        {
            LogMessageType messageFlag = new LogMessageType(); // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            LOGs.WriteLine( messageFlag, strFormat );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StringFilter 的测试
        ///</summary>
        [TestMethod()]
        public void StringFilterTest1()
        {
            char charFormat = '\0'; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = LOGs.StringFilter( charFormat );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///StringFilter 的测试
        ///</summary>
        [TestMethod()]
        public void StringFilterTest()
        {
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = LOGs.StringFilter( strFormat );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InternalWriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void InternalWriteLineTest1()
        {
            LogMessageType messageFlag = new LogMessageType(); // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            object[] arg = null; // TODO: 初始化为适当的值
            LOGs.InternalWriteLine( messageFlag, strFormat, arg );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InternalWriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void InternalWriteLineTest()
        {
            LogMessageType messageFlag = new LogMessageType(); // TODO: 初始化为适当的值
            string strFormat = string.Empty; // TODO: 初始化为适当的值
            LOGs.InternalWriteLine( messageFlag, strFormat );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///LOGs 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void LOGsConstructorTest()
        {
            LOGs target = new LOGs();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
