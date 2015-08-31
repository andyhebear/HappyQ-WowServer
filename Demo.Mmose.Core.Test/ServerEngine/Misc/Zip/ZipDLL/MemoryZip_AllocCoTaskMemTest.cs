using Demo.Mmose.Misc.Zip.Dll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MemoryZip_AllocCoTaskMemTest 的测试类，旨在
    ///包含所有 MemoryZip_AllocCoTaskMemTest 单元测试
    ///</summary>
    [TestClass()]
    public class MemoryZip_AllocCoTaskMemTest
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
        ///BufferSize 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BufferSizeTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem target = new MemoryZip_Accessor.AllocCoTaskMem( param0 ); // TODO: 初始化为适当的值
            int actual;
            actual = target.BufferSize;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BufferPtr 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BufferPtrTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem target = new MemoryZip_Accessor.AllocCoTaskMem( param0 ); // TODO: 初始化为适当的值
            IntPtr actual;
            actual = target.BufferPtr;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AllocCoTaskMem 构造函数 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_AllocCoTaskMemConstructorTest()
        {
            int iBufferSize = 0; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem target = new MemoryZip_Accessor.AllocCoTaskMem( iBufferSize );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
