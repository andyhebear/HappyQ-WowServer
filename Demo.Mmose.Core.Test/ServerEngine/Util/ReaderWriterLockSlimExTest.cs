using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 ReaderWriterLockSlimExTest 的测试类，旨在
    ///包含所有 ReaderWriterLockSlimExTest 单元测试
    ///</summary>
    [TestClass()]
    public class ReaderWriterLockSlimExTest
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
        ///TryEnterWriteLock 的测试
        ///</summary>
        [TestMethod()]
        public void TryEnterWriteLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ReaderWriterLockSlimEx.TryEnterWriteLock( readerWriterLockSlim );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///TryEnterUpgradeableReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void TryEnterUpgradeableReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ReaderWriterLockSlimEx.TryEnterUpgradeableReadLock( readerWriterLockSlim );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///TryEnterReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void TryEnterReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = ReaderWriterLockSlimEx.TryEnterReadLock( readerWriterLockSlim );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ExitWriteLock 的测试
        ///</summary>
        [TestMethod()]
        public void ExitWriteLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.ExitWriteLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ExitUpgradeableReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void ExitUpgradeableReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.ExitUpgradeableReadLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ExitReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void ExitReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.ExitReadLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EnterWriteLock 的测试
        ///</summary>
        [TestMethod()]
        public void EnterWriteLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.EnterWriteLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EnterUpgradeableReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void EnterUpgradeableReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.EnterUpgradeableReadLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EnterReadLock 的测试
        ///</summary>
        [TestMethod()]
        public void EnterReadLockTest()
        {
            ReaderWriterLockSlim readerWriterLockSlim = null; // TODO: 初始化为适当的值
            ReaderWriterLockSlimEx.EnterReadLock( readerWriterLockSlim );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
