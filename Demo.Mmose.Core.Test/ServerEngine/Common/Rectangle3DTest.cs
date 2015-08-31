using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 Rectangle3DTest 的测试类，旨在
    ///包含所有 Rectangle3DTest 单元测试
    ///</summary>
    [TestClass()]
    public class Rectangle3DTest
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
        ///Width 的测试
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            float actual;
            actual = target.Width;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Start 的测试
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
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
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            float actual;
            actual = target.Height;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///End 的测试
        ///</summary>
        [TestMethod()]
        public void EndTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            target.End = expected;
            actual = target.End;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Depth 的测试
        ///</summary>
        [TestMethod()]
        public void DepthTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            float actual;
            actual = target.Depth;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
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
            Rectangle3D expected = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D actual;
            actual = Rectangle3D.Parse( value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest1()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            IPoint3D point3D = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Rectangle3D target = new Rectangle3D(); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Rectangle3D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Rectangle3DConstructorTest1()
        {
            Point3D start = new Point3D(); // TODO: 初始化为适当的值
            Point3D end = new Point3D(); // TODO: 初始化为适当的值
            Rectangle3D target = new Rectangle3D( start, end );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Rectangle3D 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Rectangle3DConstructorTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            float width = 0F; // TODO: 初始化为适当的值
            float height = 0F; // TODO: 初始化为适当的值
            float depth = 0F; // TODO: 初始化为适当的值
            Rectangle3D target = new Rectangle3D( x, y, z, width, height, depth );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
