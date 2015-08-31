using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 GoldItemTest 的测试类，旨在
    ///包含所有 GoldItemTest 单元测试
    ///</summary>
    [TestClass()]
    public class GoldItemTest
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
        ///MinGold 的测试
        ///</summary>
        [TestMethod()]
        public void MinGoldTest()
        {
            GoldItem target = new GoldItem(); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            target.MinGold = expected;
            actual = target.MinGold;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MaxGold 的测试
        ///</summary>
        [TestMethod()]
        public void MaxGoldTest()
        {
            GoldItem target = new GoldItem(); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            target.MaxGold = expected;
            actual = target.MaxGold;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GoldMultiplier 的测试
        ///</summary>
        [TestMethod()]
        public void GoldMultiplierTest()
        {
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            GoldItem.GoldMultiplier = expected;
            actual = GoldItem.GoldMultiplier;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Gold 的测试
        ///</summary>
        [TestMethod()]
        public void GoldTest()
        {
            GoldItem target = new GoldItem(); // TODO: 初始化为适当的值
            ulong actual;
            actual = target.Gold;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RandomGoldGenerator 的测试
        ///</summary>
        [TestMethod()]
        public void RandomGoldGeneratorTest()
        {
            GoldItem target = new GoldItem(); // TODO: 初始化为适当的值
            ulong expected = 0; // TODO: 初始化为适当的值
            ulong actual;
            actual = target.RandomGoldGenerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GoldItem 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void GoldItemConstructorTest1()
        {
            GoldItem target = new GoldItem();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///GoldItem 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void GoldItemConstructorTest()
        {
            ulong minGold = 0; // TODO: 初始化为适当的值
            ulong maxGold = 0; // TODO: 初始化为适当的值
            GoldItem target = new GoldItem( minGold, maxGold );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
