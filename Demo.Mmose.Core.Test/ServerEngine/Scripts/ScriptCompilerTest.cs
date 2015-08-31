using Demo.Mmose.Core.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom.Compiler;
using Demo.Mmose.Core.Common;
using System.Collections.Generic;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ScriptCompilerTest 的测试类，旨在
    ///包含所有 ScriptCompilerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ScriptCompilerTest
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
        ///ScriptAssemblyInfos 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptAssemblyInfosTest()
        {
            ScriptAssemblyInfo[] actual;
            actual = ScriptCompiler.ScriptAssemblyInfos;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AdditionalReferences 的测试
        ///</summary>
        [TestMethod()]
        public void AdditionalReferencesTest()
        {
            string[] actual;
            actual = ScriptCompiler.AdditionalReferences;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetUnusedPath 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetUnusedPathTest()
        {
            string strDirectory = string.Empty; // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ScriptCompiler_Accessor.GetUnusedPath( strDirectory, strName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetScripts 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetScriptsTest1()
        {
            string strScriptDirectory = string.Empty; // TODO: 初始化为适当的值
            string strFilter = string.Empty; // TODO: 初始化为适当的值
            string[] expected = null; // TODO: 初始化为适当的值
            string[] actual;
            actual = ScriptCompiler_Accessor.GetScripts( strScriptDirectory, strFilter );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetScripts 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetScriptsTest()
        {
            List<string> listString = null; // TODO: 初始化为适当的值
            List<string> listStringExpected = null; // TODO: 初始化为适当的值
            string strPath = string.Empty; // TODO: 初始化为适当的值
            string strFilter = string.Empty; // TODO: 初始化为适当的值
            ScriptCompiler_Accessor.GetScripts( ref listString, strPath, strFilter );
            Assert.AreEqual( listStringExpected, listString );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetScriptAssemblyInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetScriptAssemblyInfoTest1()
        {
            string strScriptName = string.Empty; // TODO: 初始化为适当的值
            VersionInfo scriptVersion = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo expected = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo actual;
            actual = ScriptCompiler.GetScriptAssemblyInfo( strScriptName, scriptVersion );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetScriptAssemblyInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetScriptAssemblyInfoTest()
        {
            string strScriptName = string.Empty; // TODO: 初始化为适当的值
            ScriptAssemblyInfo[] expected = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo[] actual;
            actual = ScriptCompiler.GetScriptAssemblyInfo( strScriptName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetReferenceAssemblies 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetReferenceAssembliesTest()
        {
            string strDirectory = string.Empty; // TODO: 初始化为适当的值
            string[] expected = null; // TODO: 初始化为适当的值
            string[] actual;
            actual = ScriptCompiler_Accessor.GetReferenceAssemblies( strDirectory );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetLastNewScriptAssemblyInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetLastNewScriptAssemblyInfoTest()
        {
            string strScriptName = string.Empty; // TODO: 初始化为适当的值
            ScriptAssemblyInfo expected = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo actual;
            actual = ScriptCompiler.GetLastNewScriptAssemblyInfo( strScriptName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetHashCode 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetHashCodeTest()
        {
            string strCompiledFile = string.Empty; // TODO: 初始化为适当的值
            string[] strScriptFiles = null; // TODO: 初始化为适当的值
            bool bDebug = false; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = ScriptCompiler_Accessor.GetHashCode( strCompiledFile, strScriptFiles, bDebug );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetDefines 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetDefinesTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ScriptCompiler_Accessor.GetDefines();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///EnsureDirectory 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void EnsureDirectoryTest()
        {
            string strDirectory = string.Empty; // TODO: 初始化为适当的值
            ScriptCompiler_Accessor.EnsureDirectory( strDirectory );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Display 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayTest()
        {
            string strScriptDirectory = string.Empty; // TODO: 初始化为适当的值
            CompilerResults compilerResults = null; // TODO: 初始化为适当的值
            ScriptCompiler_Accessor.Display( strScriptDirectory, compilerResults );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DeleteFiles 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DeleteFilesTest()
        {
            string strDirectory = string.Empty; // TODO: 初始化为适当的值
            string strMask = string.Empty; // TODO: 初始化为适当的值
            ScriptCompiler_Accessor.DeleteFiles( strDirectory, strMask );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CompileVBScripts 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CompileVBScriptsTest()
        {
            bool bDebug = false; // TODO: 初始化为适当的值
            bool bCache = false; // TODO: 初始化为适当的值
            string strAssemblyDirectory = string.Empty; // TODO: 初始化为适当的值
            string strScriptDirectory = string.Empty; // TODO: 初始化为适当的值
            ScriptAssemblyInfo scriptAssemblyInfo = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo scriptAssemblyInfoExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ScriptCompiler_Accessor.CompileVBScripts( bDebug, bCache, strAssemblyDirectory, strScriptDirectory, ref scriptAssemblyInfo );
            Assert.AreEqual( scriptAssemblyInfoExpected, scriptAssemblyInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompileCSScripts 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CompileCSScriptsTest()
        {
            bool bDebug = false; // TODO: 初始化为适当的值
            bool bCache = false; // TODO: 初始化为适当的值
            string strAssemblyDirectory = string.Empty; // TODO: 初始化为适当的值
            string strScriptDirectory = string.Empty; // TODO: 初始化为适当的值
            ScriptAssemblyInfo scriptAssemblyInfo = null; // TODO: 初始化为适当的值
            ScriptAssemblyInfo scriptAssemblyInfoExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ScriptCompiler_Accessor.CompileCSScripts( bDebug, bCache, strAssemblyDirectory, strScriptDirectory, ref scriptAssemblyInfo );
            Assert.AreEqual( scriptAssemblyInfoExpected, scriptAssemblyInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Compile 的测试
        ///</summary>
        [TestMethod()]
        public void CompileTest()
        {
            bool bDebug = false; // TODO: 初始化为适当的值
            bool bCache = false; // TODO: 初始化为适当的值
            string strAssemblyDirectory = string.Empty; // TODO: 初始化为适当的值
            string strScriptDirectory = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ScriptCompiler.Compile( bDebug, bCache, strAssemblyDirectory, strScriptDirectory );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ScriptCompiler 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ScriptCompilerConstructorTest()
        {
            ScriptCompiler target = new ScriptCompiler();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
