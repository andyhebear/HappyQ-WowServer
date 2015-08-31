using Demo.Mmose.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ProcessMessageBlockPoolTest 的测试类，旨在
    ///包含所有 ProcessMessageBlockPoolTest 单元测试
    ///</summary>
    [TestClass()]
    public class ProcessMessageBlockPoolTest
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
        ///ReleasePoolContent 的测试
        ///</summary>
        public void ReleasePoolContentTestHelper<T>()
            where T : new()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            int iInitialCapacity = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T> target = new ProcessMessageBlockPool<T>( strName, iInitialCapacity ); // TODO: 初始化为适当的值
            T TContent = new T(); // TODO: 初始化为适当的值
            target.ReleasePoolContent( TContent );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ReleasePoolContentTest()
        {
            ReleasePoolContentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetInfo 的测试
        ///</summary>
        public void GetInfoTestHelper<T>()
            where T : new()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            int iInitialCapacity = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T> target = new ProcessMessageBlockPool<T>( strName, iInitialCapacity ); // TODO: 初始化为适当的值
            string strName1 = string.Empty; // TODO: 初始化为适当的值
            string strNameExpected = string.Empty; // TODO: 初始化为适当的值
            int iFreeCount = 0; // TODO: 初始化为适当的值
            int iFreeCountExpected = 0; // TODO: 初始化为适当的值
            int iInitialCapacity1 = 0; // TODO: 初始化为适当的值
            int iInitialCapacityExpected = 0; // TODO: 初始化为适当的值
            int iCurrentCapacity = 0; // TODO: 初始化为适当的值
            int iCurrentCapacityExpected = 0; // TODO: 初始化为适当的值
            int iMisses = 0; // TODO: 初始化为适当的值
            int iMissesExpected = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T>.PoolInfo poolInfo = target.GetPoolInfo();
            Assert.AreEqual( strNameExpected, strName1 );
            Assert.AreEqual( iFreeCountExpected, iFreeCount );
            Assert.AreEqual( iInitialCapacityExpected, iInitialCapacity1 );
            Assert.AreEqual( iCurrentCapacityExpected, iCurrentCapacity );
            Assert.AreEqual( iMissesExpected, iMisses );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            GetInfoTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Free 的测试
        ///</summary>
        public void FreeTestHelper<T>()
            where T : new()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            int iInitialCapacity = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T> target = new ProcessMessageBlockPool<T>( strName, iInitialCapacity ); // TODO: 初始化为适当的值
            target.Free();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void FreeTest()
        {
            FreeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///AcquirePoolContent 的测试
        ///</summary>
        public void AcquirePoolContentTestHelper<T>()
            where T : new()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            int iInitialCapacity = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T> target = new ProcessMessageBlockPool<T>( strName, iInitialCapacity ); // TODO: 初始化为适当的值
            T expected = new T(); // TODO: 初始化为适当的值
            T actual;
            actual = target.AcquirePoolContent();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AcquirePoolContentTest()
        {
            AcquirePoolContentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ProcessMessageBlockPool`1 构造函数 的测试
        ///</summary>
        public void ProcessMessageBlockPoolConstructorTestHelper<T>()
            where T : new()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            int iInitialCapacity = 0; // TODO: 初始化为适当的值
            ProcessMessageBlockPool<T> target = new ProcessMessageBlockPool<T>( strName, iInitialCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void ProcessMessageBlockPoolConstructorTest()
        {
            ProcessMessageBlockPoolConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
