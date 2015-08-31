using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TileTest 的测试类，旨在
    ///包含所有 TileTest 单元测试
    ///</summary>
    [TestClass()]
    public class TileTest
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
        ///Z 的测试
        ///</summary>
        [TestMethod()]
        public void ZTest()
        {
            Tile target = new Tile(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.Z = expected;
            actual = target.Z;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Ignored 的测试
        ///</summary>
        [TestMethod()]
        public void IgnoredTest()
        {
            Tile target = new Tile(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Ignored;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ID 的测试
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            Tile target = new Tile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.ID;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Height 的测试
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            Tile target = new Tile(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Height;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Set 的测试
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            Tile target = new Tile(); // TODO: 初始化为适当的值
            short id = 0; // TODO: 初始化为适当的值
            sbyte z = 0; // TODO: 初始化为适当的值
            target.Set( id, z );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Tile 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TileConstructorTest()
        {
            short id = 0; // TODO: 初始化为适当的值
            sbyte z = 0; // TODO: 初始化为适当的值
            Tile target = new Tile( id, z );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
