using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 CanSpawnEventArgsTest 的测试类，旨在
    ///包含所有 CanSpawnEventArgsTest 单元测试
    ///</summary>
    [TestClass()]
    public class CanSpawnEventArgsTest
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
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            CanSpawnEventArgs target = new CanSpawnEventArgs( x, y, z, map ); // TODO: 初始化为适当的值
            float actual;
            actual = target.Z;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Y 的测试
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            CanSpawnEventArgs target = new CanSpawnEventArgs( x, y, z, map ); // TODO: 初始化为适当的值
            float actual;
            actual = target.Y;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///X 的测试
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            CanSpawnEventArgs target = new CanSpawnEventArgs( x, y, z, map ); // TODO: 初始化为适当的值
            float actual;
            actual = target.X;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsCanSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void IsCanSpawnTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            CanSpawnEventArgs target = new CanSpawnEventArgs( x, y, z, map ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsCanSpawn = expected;
            actual = target.IsCanSpawn;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanSpawnEventArgs 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CanSpawnEventArgsConstructorTest()
        {
            float x = 0F; // TODO: 初始化为适当的值
            float y = 0F; // TODO: 初始化为适当的值
            float z = 0F; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            CanSpawnEventArgs target = new CanSpawnEventArgs( x, y, z, map );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
