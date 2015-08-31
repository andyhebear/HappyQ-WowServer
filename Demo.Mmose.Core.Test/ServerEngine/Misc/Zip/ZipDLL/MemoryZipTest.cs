using Demo.Mmose.Misc.Zip.Dll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MemoryZipTest 的测试类，旨在
    ///包含所有 MemoryZipTest 单元测试
    ///</summary>
    [TestClass()]
    public class MemoryZipTest
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
        ///MemoryCacheSize 的测试
        ///</summary>
        [TestMethod()]
        public void MemoryCacheSizeTest()
        {
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            MemoryZip.MemoryCacheSize = expected;
            actual = MemoryZip.MemoryCacheSize;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ZlibDecompressor 的测试
        ///</summary>
        [TestMethod()]
        public void ZlibDecompressorTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.ZlibDecompressor( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ZlibCompressor 的测试
        ///</summary>
        [TestMethod()]
        public void ZlibCompressorTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.ZlibCompressor( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Release 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ReleaseTest()
        {
            MemoryZip_Accessor.AllocCoTaskMem allocCoTaskMem = null; // TODO: 初始化为适当的值
            MemoryZip_Accessor.Release( allocCoTaskMem );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MemoryZip_ZlibDecompressor 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_ZlibDecompressorTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_ZlibDecompressor( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip_ZlibCompressor 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_ZlibCompressorTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_ZlibCompressor( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip_Inflator 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_InflatorTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_Inflator( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip_Gzip 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_GzipTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_Gzip( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip_Gunzip 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_GunzipTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_Gunzip( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip_Deflator 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MemoryZip_DeflatorTest()
        {
            IntPtr pBufferIn = new IntPtr(); // TODO: 初始化为适当的值
            int BufferInSize = 0; // TODO: 初始化为适当的值
            IntPtr pBufferOut = new IntPtr(); // TODO: 初始化为适当的值
            int pBufferOutSize = 0; // TODO: 初始化为适当的值
            int pBufferOutSizeExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip_Accessor.MemoryZip_Deflator( pBufferIn, BufferInSize, pBufferOut, ref pBufferOutSize );
            Assert.AreEqual( pBufferOutSizeExpected, pBufferOutSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InstanceTest1()
        {
            int iBufferSize = 0; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem expected = null; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem actual;
            actual = MemoryZip_Accessor.Instance( iBufferSize );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Instance 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InstanceTest()
        {
            MemoryZip_Accessor.AllocCoTaskMem expected = null; // TODO: 初始化为适当的值
            MemoryZip_Accessor.AllocCoTaskMem actual;
            actual = MemoryZip_Accessor.Instance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Inflator 的测试
        ///</summary>
        [TestMethod()]
        public void InflatorTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.Inflator( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Gzip 的测试
        ///</summary>
        [TestMethod()]
        public void GzipTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.Gzip( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Gunzip 的测试
        ///</summary>
        [TestMethod()]
        public void GunzipTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.Gunzip( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Free 的测试
        ///</summary>
        [TestMethod()]
        public void FreeTest()
        {
            MemoryZip.Free();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Deflator 的测试
        ///</summary>
        [TestMethod()]
        public void DeflatorTest()
        {
            byte[] pBufferIn = null; // TODO: 初始化为适当的值
            int iOffsetIn = 0; // TODO: 初始化为适当的值
            int iSizeIn = 0; // TODO: 初始化为适当的值
            byte[] pBufferOut = null; // TODO: 初始化为适当的值
            byte[] pBufferOutExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = MemoryZip.Deflator( pBufferIn, iOffsetIn, iSizeIn, out pBufferOut );
            Assert.AreEqual( pBufferOutExpected, pBufferOut );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MemoryZip 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MemoryZipConstructorTest()
        {
            MemoryZip target = new MemoryZip();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
