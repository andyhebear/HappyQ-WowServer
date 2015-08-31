using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 Point2DTest 的测试类，旨在
    ///包含所有 Point2DTest 单元测试
    ///</summary>
    [TestClass()]
    public class Point2DTest
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
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
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
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            float expected = 0F; // TODO: 初始化为适当的值
            float actual;
            target.X = expected;
            actual = target.X;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Parse 的测试
        ///</summary>
        [TestMethod()]
        public void ParseTest()
        {
            string value = string.Empty; // TODO: 初始化为适当的值
            Point2D expected = new Point2D(); // TODO: 初始化为适当的值
            Point2D actual;
            actual = Point2D.Parse( value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare <= yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanOrEqualTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare <= yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare < yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_LessThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_LessThanTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare < yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare != yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Inequality 的测试
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare != yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare >= yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThanOrEqual 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanOrEqualTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare >= yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare > yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_GreaterThan 的测试
        ///</summary>
        [TestMethod()]
        public void op_GreaterThanTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare > yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest1()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            IPoint2D yCompare = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare == yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///op_Equality 的测试
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            Point2D xCompare = new Point2D(); // TODO: 初始化为适当的值
            Point2D yCompare = new Point2D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ( xCompare == yCompare );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Equals 的测试
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Equals( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            Point2D other = new Point2D(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Point2D target = new Point2D(); // TODO: 初始化为适当的值
            object other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Point2D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Point2DConstructorTest1()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            Point2D target = new Point2D( x, y );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Point2D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Point2DConstructorTest()
        {
            IPoint2D point2D = null; // TODO: 初始化为适当的值
            Point2D target = new Point2D( point2D );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
