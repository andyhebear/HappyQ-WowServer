using Demo.Mmose.Core.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 TypeCacheTest 的测试类，旨在
    ///包含所有 TypeCacheTest 单元测试
    ///</summary>
    [TestClass()]
    public class TypeCacheTest
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
        ///Types 的测试
        ///</summary>
        [TestMethod()]
        public void TypesTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly ); // TODO: 初始化为适当的值
            Type[] actual;
            actual = target.Types;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Names 的测试
        ///</summary>
        [TestMethod()]
        public void NamesTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly ); // TODO: 初始化为适当的值
            TypeTable actual;
            actual = target.Names;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FullNames 的测试
        ///</summary>
        [TestMethod()]
        public void FullNamesTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly ); // TODO: 初始化为适当的值
            TypeTable actual;
            actual = target.FullNames;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetTypeByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetTypeByNameTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly ); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            bool ignoreCase = false; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.GetTypeByName( strName, ignoreCase );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetTypeByFullName 的测试
        ///</summary>
        [TestMethod()]
        public void GetTypeByFullNameTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly ); // TODO: 初始化为适当的值
            string strFullName = string.Empty; // TODO: 初始化为适当的值
            bool ignoreCase = false; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.GetTypeByFullName( strFullName, ignoreCase );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///TypeCache 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void TypeCacheConstructorTest()
        {
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache target = new TypeCache( assembly );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
