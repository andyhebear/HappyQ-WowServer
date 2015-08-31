using Demo.Mmose.Core.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MultiTextWriterTest 的测试类，旨在
    ///包含所有 MultiTextWriterTest 单元测试
    ///</summary>
    [TestClass()]
    public class MultiTextWriterTest
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
        ///Encoding 的测试
        ///</summary>
        [TestMethod()]
        public void EncodingTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            Encoding actual;
            actual = target.Encoding;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest1()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            string strLine = string.Empty; // TODO: 初始化为适当的值
            target.WriteLine( strLine );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            string strLine = string.Empty; // TODO: 初始化为适当的值
            object[] args = null; // TODO: 初始化为适当的值
            target.WriteLine( strLine, args );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Write 的测试
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            char charWrite = '\0'; // TODO: 初始化为适当的值
            target.Write( charWrite );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            TextWriter textWriter = null; // TODO: 初始化为适当的值
            target.Remove( textWriter );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray ); // TODO: 初始化为适当的值
            TextWriter textWriter = null; // TODO: 初始化为适当的值
            target.Add( textWriter );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MultiTextWriter 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MultiTextWriterConstructorTest()
        {
            TextWriter[] streamsArray = null; // TODO: 初始化为适当的值
            MultiTextWriter target = new MultiTextWriter( streamsArray );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
