using Demo.Mmose.Core.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.World;
using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 OneServerTest 的测试类，旨在
    ///包含所有 OneServerTest 单元测试
    ///</summary>
    [TestClass()]
    public class OneServerTest
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
        ///World 的测试
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            BaseWorld[] actual;
            actual = OneServer.World;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Version 的测试
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            Version actual;
            actual = OneServer.Version;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Thread 的测试
        ///</summary>
        [TestMethod()]
        public void ThreadTest()
        {
            Thread actual;
            actual = OneServer.Thread;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Service 的测试
        ///</summary>
        [TestMethod()]
        public void ServiceTest()
        {
            bool actual;
            actual = OneServer.Service;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Profiling 的测试
        ///</summary>
        [TestMethod()]
        public void ProfilingTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            OneServer.Profiling = expected;
            actual = OneServer.Profiling;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ProfileTime 的测试
        ///</summary>
        [TestMethod()]
        public void ProfileTimeTest()
        {
            TimeSpan actual;
            actual = OneServer.ProfileTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ProcessorCount 的测试
        ///</summary>
        [TestMethod()]
        public void ProcessorCountTest()
        {
            int actual;
            actual = OneServer.ProcessorCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Process 的测试
        ///</summary>
        [TestMethod()]
        public void ProcessTest()
        {
            Process actual;
            actual = OneServer.Process;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MultiProcessor 的测试
        ///</summary>
        [TestMethod()]
        public void MultiProcessorTest()
        {
            bool actual;
            actual = OneServer.MultiProcessor;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MultiConsoleOut 的测试
        ///</summary>
        [TestMethod()]
        public void MultiConsoleOutTest()
        {
            MultiTextWriter actual;
            actual = OneServer.MultiConsoleOut;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///HaltOnWarning 的测试
        ///</summary>
        [TestMethod()]
        public void HaltOnWarningTest()
        {
            bool actual;
            actual = OneServer.HaltOnWarning;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ExePath 的测试
        ///</summary>
        [TestMethod()]
        public void ExePathTest()
        {
            string actual;
            actual = OneServer.ExePath;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Debug 的测试
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            bool actual;
            actual = OneServer.Debug;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Closing 的测试
        ///</summary>
        [TestMethod()]
        public void ClosingTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            OneServer.Closing = expected;
            actual = OneServer.Closing;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Cache 的测试
        ///</summary>
        [TestMethod()]
        public void CacheTest()
        {
            bool actual;
            actual = OneServer.Cache;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void BaseDirectoryTest()
        {
            string actual;
            actual = OneServer.BaseDirectory;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Assembly 的测试
        ///</summary>
        [TestMethod()]
        public void AssemblyTest()
        {
            Assembly actual;
            actual = OneServer.Assembly;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Arguments 的测试
        ///</summary>
        [TestMethod()]
        public void ArgumentsTest()
        {
            string actual;
            actual = OneServer.Arguments;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///WaitAllRegisterThreadExit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void WaitAllRegisterThreadExitTest()
        {
            OneServer_Accessor.WaitAllRegisterThreadExit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///UnhandledException 的测试
        ///</summary>
        [TestMethod()]
        public void UnhandledExceptionTest()
        {
            object sender = null; // TODO: 初始化为适当的值
            UnhandledExceptionEventArgs eventArgs = null; // TODO: 初始化为适当的值
            OneServer.UnhandledException( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///StartServerCommandlinesDisposal 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void StartServerCommandlinesDisposalTest()
        {
            OneServer_Accessor.StartServerCommandlinesDisposal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SetAllWorldSignal 的测试
        ///</summary>
        [TestMethod()]
        public void SetAllWorldSignalTest()
        {
            OneServer.SetAllWorldSignal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RunServer 的测试
        ///</summary>
        [TestMethod()]
        public void RunServerTest()
        {
            string[] args = null; // TODO: 初始化为适当的值
            BaseWorld world = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = OneServer.RunServer( args, world );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestartProgram 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RestartProgramTest()
        {
            OneServer_Accessor.RestartProgram();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RemoveWorld 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveWorldTest()
        {
            BaseWorld world = null; // TODO: 初始化为适当的值
            OneServer.RemoveWorld( world );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RemoveSystemCloseMenu 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RemoveSystemCloseMenuTest()
        {
            OneServer_Accessor.RemoveSystemCloseMenu();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RemoveMenu 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void RemoveMenuTest()
        {
            IntPtr hMenu = new IntPtr(); // TODO: 初始化为适当的值
            int iPos = 0; // TODO: 初始化为适当的值
            int iFlags = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = OneServer_Accessor.RemoveMenu( hMenu, iPos, iFlags );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InsideRunServer 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InsideRunServerTest()
        {
            string[] args = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = OneServer_Accessor.InsideRunServer( args );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InitServerWorld 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerWorldTest()
        {
            OneServer_Accessor.InitServerWorld();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitServerScriptCompiler 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerScriptCompilerTest()
        {
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = OneServer_Accessor.InitServerScriptCompiler();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///InitServerMainInfo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerMainInfoTest()
        {
            OneServer_Accessor.InitServerMainInfo();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitServerIsRun 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerIsRunTest()
        {
            OneServer_Accessor.InitServerIsRun();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitServerExceptionDisposal 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerExceptionDisposalTest()
        {
            OneServer_Accessor.InitServerExceptionDisposal();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitServerArgumentsDisposal 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitServerArgumentsDisposalTest()
        {
            string[] args = null; // TODO: 初始化为适当的值
            OneServer_Accessor.InitServerArgumentsDisposal( args );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///InitLanguage 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InitLanguageTest()
        {
            string[] args = null; // TODO: 初始化为适当的值
            OneServer_Accessor.InitLanguage( args );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetSystemMenu 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetSystemMenuTest()
        {
            IntPtr hWnd = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr bRevert = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = OneServer_Accessor.GetSystemMenu( hWnd, bRevert );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetConsoleWindow 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetConsoleWindowTest()
        {
            IntPtr expected = new IntPtr(); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = OneServer_Accessor.GetConsoleWindow();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ExitProgram 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ExitProgramTest()
        {
            OneServer_Accessor.ExitProgram();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EndRegisterThread 的测试
        ///</summary>
        [TestMethod()]
        public void EndRegisterThreadTest()
        {
            OneServer.EndRegisterThread();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DrawMenuBar 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DrawMenuBarTest()
        {
            IntPtr hWnd = new IntPtr(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = OneServer_Accessor.DrawMenuBar( hWnd );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DisplayServerMainInfo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayServerMainInfoTest()
        {
            OneServer_Accessor.DisplayServerMainInfo();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisplayAscii4 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayAscii4Test()
        {
            OneServer_Accessor.DisplayAscii4();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisplayAscii3 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayAscii3Test()
        {
            OneServer_Accessor.DisplayAscii3();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisplayAscii2 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayAscii2Test()
        {
            OneServer_Accessor.DisplayAscii2();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisplayAscii1 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayAscii1Test()
        {
            OneServer_Accessor.DisplayAscii1();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///DisplayAscii0 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DisplayAscii0Test()
        {
            OneServer_Accessor.DisplayAscii0();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CurrentDomain_UnhandledException 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CurrentDomain_UnhandledExceptionTest()
        {
            object sender = null; // TODO: 初始化为适当的值
            UnhandledExceptionEventArgs eventArgs = null; // TODO: 初始化为适当的值
            OneServer_Accessor.CurrentDomain_UnhandledException( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CurrentDomain_ProcessExit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CurrentDomain_ProcessExitTest()
        {
            object sender = null; // TODO: 初始化为适当的值
            EventArgs eventArgs = null; // TODO: 初始化为适当的值
            OneServer_Accessor.CurrentDomain_ProcessExit( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Console_CancelKeyPress 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void Console_CancelKeyPressTest()
        {
            object sender = null; // TODO: 初始化为适当的值
            ConsoleCancelEventArgs eventArgs = null; // TODO: 初始化为适当的值
            OneServer_Accessor.Console_CancelKeyPress( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BeginRegisterThread 的测试
        ///</summary>
        [TestMethod()]
        public void BeginRegisterThreadTest()
        {
            OneServer.BeginRegisterThread();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AddWorld 的测试
        ///</summary>
        [TestMethod()]
        public void AddWorldTest()
        {
            BaseWorld world = null; // TODO: 初始化为适当的值
            OneServer.AddWorld( world );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
