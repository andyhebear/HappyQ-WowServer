using Demo.Mmose.Core.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common.SafeCollections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BufferPoolTest 的测试类，旨在
    ///包含所有 BufferPoolTest 单元测试
    ///</summary>
    [TestClass()]
    public class BufferPoolTest
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
        ///Pools 的测试
        ///</summary>
        [TestMethod()]
        public void PoolsTest()
        {
            //SafeDictionary<BufferPool, BufferPool> actual;
            //actual = BufferPool.GlobalPools;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReleaseBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseBufferTest()
        {
            string strBufferName = string.Empty; // TODO: 初始化为适当的值
            long iInitialCapacity = 0; // TODO: 初始化为适当的值
            long iBufferSize = 0; // TODO: 初始化为适当的值
            BufferPool target = new BufferPool( strBufferName, iInitialCapacity, iBufferSize ); // TODO: 初始化为适当的值
            byte[] byteBuffer = null; // TODO: 初始化为适当的值
            target.ReleaseBuffer( byteBuffer );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Release 的测试
        ///</summary>
        [TestMethod()]
        public void ReleaseTest()
        {
            string strBufferName = string.Empty; // TODO: 初始化为适当的值
            long iInitialCapacity = 0; // TODO: 初始化为适当的值
            long iBufferSize = 0; // TODO: 初始化为适当的值
            BufferPool target = new BufferPool( strBufferName, iInitialCapacity, iBufferSize ); // TODO: 初始化为适当的值
            //target.Release();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetInfoTest()
        {
            string strBufferName = string.Empty; // TODO: 初始化为适当的值
            long iInitialCapacity = 0; // TODO: 初始化为适当的值
            long iBufferSize = 0; // TODO: 初始化为适当的值
            BufferPool target = new BufferPool( strBufferName, iInitialCapacity, iBufferSize ); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            string strNameExpected = string.Empty; // TODO: 初始化为适当的值
            long iFreeCount = 0; // TODO: 初始化为适当的值
            long iFreeCountExpected = 0; // TODO: 初始化为适当的值
            long iInitialCapacity1 = 0; // TODO: 初始化为适当的值
            long iInitialCapacityExpected = 0; // TODO: 初始化为适当的值
            long iCurrentCapacity = 0; // TODO: 初始化为适当的值
            long iCurrentCapacityExpected = 0; // TODO: 初始化为适当的值
            long iBufferSize1 = 0; // TODO: 初始化为适当的值
            long iBufferSizeExpected = 0; // TODO: 初始化为适当的值
            long iMisses = 0; // TODO: 初始化为适当的值
            long iMissesExpected = 0; // TODO: 初始化为适当的值
            //target.GetInfo( out strName, out iFreeCount, out iInitialCapacity1, out iCurrentCapacity, out iBufferSize1, out iMisses );
            Assert.AreEqual( strNameExpected, strName );
            Assert.AreEqual( iFreeCountExpected, iFreeCount );
            Assert.AreEqual( iInitialCapacityExpected, iInitialCapacity1 );
            Assert.AreEqual( iCurrentCapacityExpected, iCurrentCapacity );
            Assert.AreEqual( iBufferSizeExpected, iBufferSize1 );
            Assert.AreEqual( iMissesExpected, iMisses );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AcquireBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void AcquireBufferTest()
        {
            string strBufferName = string.Empty; // TODO: 初始化为适当的值
            long iInitialCapacity = 0; // TODO: 初始化为适当的值
            long iBufferSize = 0; // TODO: 初始化为适当的值
            BufferPool target = new BufferPool( strBufferName, iInitialCapacity, iBufferSize ); // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.AcquireBuffer();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BufferPool 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BufferPoolConstructorTest()
        {
            string strBufferName = string.Empty; // TODO: 初始化为适当的值
            long iInitialCapacity = 0; // TODO: 初始化为适当的值
            long iBufferSize = 0; // TODO: 初始化为适当的值
            BufferPool target = new BufferPool( strBufferName, iInitialCapacity, iBufferSize );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
