using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 Rectangle2DTest 的测试类，旨在
    ///包含所有 Rectangle2DTest 单元测试
    ///</summary>
    [TestClass()]
    public class Rectangle2DTest
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
        ///Y 的测试
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.Y = expected;
            actual = target.Y;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///X 的测试
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.X = expected;
            actual = target.X;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Width 的测试
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.Width = expected;
            actual = target.Width;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Start 的测试
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            target.Start = expected;
            actual = target.Start;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Height 的测试
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.Height = expected;
            actual = target.Height;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///End 的测试
        ///</summary>
        [TestMethod()]
        public void EndTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            target.End = expected;
            actual = target.End;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetRectangle 的测试
        ///</summary>
        [TestMethod()]
        public void SetRectangleTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float width = 0F; // TODO: 初始化为适当的值
            float height = 0F; // TODO: 初始化为适当的值
            target.SetRectangle( x, y, width, height );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Parse 的测试
        ///</summary>
        [TestMethod()]
        public void ParseTest()
        {
            string value = string.Empty; // TODO: 初始化为适当的值
            Rectangle2D expected = new Rectangle2D(); // TODO: 初始化为适当的值
            Rectangle2D actual;
            actual = Rectangle2D.Parse( value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MakeHold 的测试
        ///</summary>
        [TestMethod()]
        public void MakeHoldTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            Rectangle2D rectangle2D = new Rectangle2D(); // TODO: 初始化为适当的值
            target.MakeHold( rectangle2D );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest1()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            Point2D point2D = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Rectangle2D target = new Rectangle2D(); // TODO: 初始化为适当的值
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Rectangle2D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Rectangle2DConstructorTest1()
        {
            IPoint2D start = null; // TODO: 初始化为适当的值
            IPoint2D end = null; // TODO: 初始化为适当的值
            Rectangle2D target = new Rectangle2D( start, end );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Rectangle2D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Rectangle2DConstructorTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float width = 0F; // TODO: 初始化为适当的值
            float height = 0F; // TODO: 初始化为适当的值
            Rectangle2D target = new Rectangle2D( x, y, width, height );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
