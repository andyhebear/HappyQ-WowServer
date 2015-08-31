using Demo.Mmose.Core.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 WorldIdTest 的测试类，旨在
    ///包含所有 WorldIdTest 单元测试
    ///</summary>
    [TestClass()]
    public class WorldIdTest
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
        ///NetAddress 的测试
        ///</summary>
        [TestMethod()]
        public void NetAddressTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            IPEndPoint actual;
            actual = target.NetAddress;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ID 的测试
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ID = expected;
            actual = target.ID;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetAddress 的测试
        ///</summary>
        [TestMethod()]
        public void SetAddressTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            string strAddress = string.Empty; // TODO: 初始化为适当的值
            int iPort = 0; // TODO: 初始化为适当的值
            target.SetAddress( strAddress, iPort );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            WorldId other = null; // TODO: 初始化为适当的值
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
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID ); // TODO: 初始化为适当的值
            object obj = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( obj );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WorldId 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void WorldIdConstructorTest1()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///WorldId 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void WorldIdConstructorTest()
        {
            string strID = string.Empty; // TODO: 初始化为适当的值
            string strAddress = string.Empty; // TODO: 初始化为适当的值
            int iPort = 0; // TODO: 初始化为适当的值
            WorldId target = new WorldId( strID, strAddress, iPort );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
