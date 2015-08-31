using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ConsoleProgressBarTest 的测试类，旨在
    ///包含所有 ConsoleProgressBarTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConsoleProgressBarTest
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
        ///StepPos 的测试
        ///</summary>
        [TestMethod()]
        public void StepPosTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            int actual;
            actual = target.StepPos;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MaximumStep 的测试
        ///</summary>
        [TestMethod()]
        public void MaximumStepTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            int actual;
            actual = target.MaximumStep;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IndicatingPos 的测试
        ///</summary>
        [TestMethod()]
        public void IndicatingPosTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            int actual;
            actual = target.IndicatingPos;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IndicatingLength 的测试
        ///</summary>
        [TestMethod()]
        public void IndicatingLengthTest()
        {
            int actual;
            actual = ConsoleProgressBar.IndicatingLength;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Fill 的测试
        ///</summary>
        [TestMethod()]
        public void FillTest()
        {
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            ConsoleProgressBar.Fill = expected;
            actual = ConsoleProgressBar.Fill;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Empty 的测试
        ///</summary>
        [TestMethod()]
        public void EmptyTest()
        {
            char expected = '\0'; // TODO: 初始化为适当的值
            char actual;
            ConsoleProgressBar.Empty = expected;
            actual = ConsoleProgressBar.Empty;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Step 的测试
        ///</summary>
        [TestMethod()]
        public void StepTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            target.Step();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EndStep 的测试
        ///</summary>
        [TestMethod()]
        public void EndStepTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            string strEndString = string.Empty; // TODO: 初始化为适当的值
            target.EndStep( strEndString );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BeginStep 的测试
        ///</summary>
        [TestMethod()]
        public void BeginStepTest()
        {
            ConsoleProgressBar target = new ConsoleProgressBar(); // TODO: 初始化为适当的值
            string strBeginString = string.Empty; // TODO: 初始化为适当的值
            target.BeginStep( strBeginString );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ConsoleProgressBar 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConsoleProgressBarConstructorTest1()
        {
            int iMaximumStep = 0; // TODO: 初始化为适当的值
            ConsoleProgressBar target = new ConsoleProgressBar( iMaximumStep );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///ConsoleProgressBar 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConsoleProgressBarConstructorTest()
        {
            int iMaximumStep = 0; // TODO: 初始化为适当的值
            int iIndicatingLength = 0; // TODO: 初始化为适当的值
            ConsoleProgressBar target = new ConsoleProgressBar( iMaximumStep, iIndicatingLength );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
