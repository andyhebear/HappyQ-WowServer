using Demo.Mmose.Core.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using Demo.Mmose.Core.Common;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ScriptAssemblyInfoTest 的测试类，旨在
    ///包含所有 ScriptAssemblyInfoTest 单元测试
    ///</summary>
    [TestClass()]
    public class ScriptAssemblyInfoTest
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
        ///Version 的测试
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            VersionInfo actual;
            actual = target.Version;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ScriptName 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptNameTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string actual;
            actual = target.ScriptName;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ScriptAssembly 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptAssemblyTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly[] actual;
            actual = target.ScriptAssembly;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SetVersion 的测试
        ///</summary>
        [TestMethod()]
        public void SetVersionTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            VersionInfo versionInfo = null; // TODO: 初始化为适当的值
            target.SetVersion( versionInfo );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetScriptName 的测试
        ///</summary>
        [TestMethod()]
        public void SetScriptNameTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string scriptName = string.Empty; // TODO: 初始化为适当的值
            target.SetScriptName( scriptName );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetTypeCache 的测试
        ///</summary>
        [TestMethod()]
        public void GetTypeCacheTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly assembly = null; // TODO: 初始化为适当的值
            TypeCache expected = null; // TODO: 初始化为适当的值
            TypeCache actual;
            actual = target.GetTypeCache( assembly );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetScriptFiles 的测试
        ///</summary>
        [TestMethod()]
        public void GetScriptFilesTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly assembly = null; // TODO: 初始化为适当的值
            string[] expected = null; // TODO: 初始化为适当的值
            string[] actual;
            actual = target.GetScriptFiles( assembly );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly assembly = null; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetHashCode( assembly );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindTypeByName 的测试
        ///</summary>
        [TestMethod()]
        public void FindTypeByNameTest1()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.FindTypeByName( strName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindTypeByName 的测试
        ///</summary>
        [TestMethod()]
        public void FindTypeByNameTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            bool bIgnoreCase = false; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.FindTypeByName( strName, bIgnoreCase );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindTypeByFullName 的测试
        ///</summary>
        [TestMethod()]
        public void FindTypeByFullNameTest1()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string strFullName = string.Empty; // TODO: 初始化为适当的值
            bool bIgnoreCase = false; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.FindTypeByFullName( strFullName, bIgnoreCase );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindTypeByFullName 的测试
        ///</summary>
        [TestMethod()]
        public void FindTypeByFullNameTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            string strFullName = string.Empty; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.FindTypeByFullName( strFullName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AddScriptFiles 的测试
        ///</summary>
        [TestMethod()]
        public void AddScriptFilesTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly assembly = null; // TODO: 初始化为适当的值
            string[] scriptFiles = null; // TODO: 初始化为适当的值
            target.AddScriptFiles( assembly, scriptFiles );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddScriptAssembly 的测试
        ///</summary>
        [TestMethod()]
        public void AddScriptAssemblyTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly scriptAssembly = null; // TODO: 初始化为适当的值
            target.AddScriptAssembly( scriptAssembly );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddHashCode 的测试
        ///</summary>
        [TestMethod()]
        public void AddHashCodeTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo(); // TODO: 初始化为适当的值
            Assembly assembly = null; // TODO: 初始化为适当的值
            byte[] byteHashCode = null; // TODO: 初始化为适当的值
            target.AddHashCode( assembly, byteHashCode );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ScriptAssemblyInfo 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptAssemblyInfoConstructorTest()
        {
            ScriptAssemblyInfo target = new ScriptAssemblyInfo();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
