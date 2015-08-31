using Demo.Mmose.Core.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 FileLoggerTest 的测试类，旨在
    ///包含所有 FileLoggerTest 单元测试
    ///</summary>
    [TestClass()]
    public class FileLoggerTest
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
        ///LogFileName 的测试
        ///</summary>
        [TestMethod()]
        public void LogFileNameTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            string actual;
            actual = target.LogFileName;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsLogFile 的测试
        ///</summary>
        [TestMethod()]
        public void IsLogFileTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsLogFile = expected;
            actual = target.IsLogFile;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Encoding 的测试
        ///</summary>
        [TestMethod()]
        public void EncodingTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            Encoding actual;
            actual = target.Encoding;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            string strWriteLine = string.Empty; // TODO: 初始化为适当的值
            target.WriteLine( strWriteLine );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest1()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            char charWrite = '\0'; // TODO: 初始化为适当的值
            target.Write( charWrite );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile ); // TODO: 初始化为适当的值
            string strWrite = string.Empty; // TODO: 初始化为适当的值
            target.Write( strWrite );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///FileLogger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void FileLoggerConstructorTest1()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///FileLogger 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void FileLoggerConstructorTest()
        {
            string strFile = string.Empty; // TODO: 初始化为适当的值
            bool bAppend = false; // TODO: 初始化为适当的值
            FileLogger target = new FileLogger( strFile, bAppend );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
