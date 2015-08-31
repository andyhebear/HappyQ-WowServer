using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 RegionRectTest 的测试类，旨在
    ///包含所有 RegionRectTest 单元测试
    ///</summary>
    [TestClass()]
    public class RegionRectTest
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
        ///Region 的测试
        ///</summary>
        [TestMethod()]
        public void RegionTest()
        {
            Region region = null; // TODO: 初始化为适当的值
            Rectangle3D rectangle3D = new Rectangle3D(); // TODO: 初始化为适当的值
            RegionRect target = new RegionRect( region, rectangle3D ); // TODO: 初始化为适当的值
            Region actual;
            actual = target.Region;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Rect 的测试
        ///</summary>
        [TestMethod()]
        public void RectTest()
        {
            Region region = null; // TODO: 初始化为适当的值
            Rectangle3D rectangle3D = new Rectangle3D(); // TODO: 初始化为适当的值
            RegionRect target = new RegionRect( region, rectangle3D ); // TODO: 初始化为适当的值
            Rectangle3D actual;
            actual = target.Rect;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Region region = null; // TODO: 初始化为适当的值
            Rectangle3D rectangle3D = new Rectangle3D(); // TODO: 初始化为适当的值
            RegionRect target = new RegionRect( region, rectangle3D ); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Region region = null; // TODO: 初始化为适当的值
            Rectangle3D rectangle3D = new Rectangle3D(); // TODO: 初始化为适当的值
            RegionRect target = new RegionRect( region, rectangle3D ); // TODO: 初始化为适当的值
            object xObject = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( xObject );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RegionRect 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionRectConstructorTest()
        {
            Region region = null; // TODO: 初始化为适当的值
            Rectangle3D rectangle3D = new Rectangle3D(); // TODO: 初始化为适当的值
            RegionRect target = new RegionRect( region, rectangle3D );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
