using Demo.Mmose.Core.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TypeTableTest 的测试类，旨在
    ///包含所有 TypeTableTest 单元测试
    ///</summary>
    [TestClass()]
    public class TypeTableTest
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
        ///Get 的测试
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            TypeTable target = new TypeTable(); // TODO: 初始化为适当的值
            string key = string.Empty; // TODO: 初始化为适当的值
            bool ignoreCase = false; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.Get( key, ignoreCase );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            TypeTable target = new TypeTable(); // TODO: 初始化为适当的值
            string key = string.Empty; // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            target.Add( key, type );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///TypeTable 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TypeTableConstructorTest()
        {
            TypeTable target = new TypeTable();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
