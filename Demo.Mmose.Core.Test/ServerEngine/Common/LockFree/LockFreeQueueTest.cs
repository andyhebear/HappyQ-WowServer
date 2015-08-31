using Demo.Mmose.Core.Common.LockFree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 LockFreeQueueTest 的测试类，旨在
    ///包含所有 LockFreeQueueTest 单元测试
    ///</summary>
    [TestClass()]
    public class LockFreeQueueTest
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
        ///TryDequeue 的测试
        ///</summary>
        public void TryDequeueTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT outItemT = default( ValueT ); // TODO: 初始化为适当的值
            ValueT outItemTExpected = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.TryDequeue( out outItemT );
            Assert.AreEqual( outItemTExpected, outItemT );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void TryDequeueTest()
        {
            TryDequeueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayAndClear 的测试
        ///</summary>
        public void ToArrayAndClearTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT[] expected = null; // TODO: 初始化为适当的值
            ValueT[] actual;
            actual = target.ToArrayAndClear();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayAndClearTest()
        {
            ToArrayAndClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToArray 的测试
        ///</summary>
        public void ToArrayTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT[] expected = null; // TODO: 初始化为适当的值
            ValueT[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            ToArrayTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTest1Helper<ValueT>()
        {
            IEnumerable target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            IEnumerator expected = null; // TODO: 初始化为适当的值
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetEnumeratorTest1()
        {
            GetEnumeratorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Peek 的测试
        ///</summary>
        public void PeekTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            actual = target.Peek();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void PeekTest()
        {
            PeekTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            IEnumerator<ValueT> expected = null; // TODO: 初始化为适当的值
            IEnumerator<ValueT> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Enqueue 的测试
        ///</summary>
        public void EnqueueTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT itemT = default( ValueT ); // TODO: 初始化为适当的值
            target.Enqueue( itemT );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            EnqueueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Dequeue 的测试
        ///</summary>
        public void DequeueTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            actual = target.Dequeue();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void DequeueTest()
        {
            DequeueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///CopyTo 的测试
        ///</summary>
        public void CopyToTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT[] arrayT = null; // TODO: 初始化为适当的值
            int iArrayIndex = 0; // TODO: 初始化为适当的值
            target.CopyTo( arrayT, iArrayIndex );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void CopyToTest()
        {
            CopyToTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        public void ContainsTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ContainsTest()
        {
            ContainsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///LockFreeQueue`1 构造函数 的测试
        ///</summary>
        public void LockFreeQueueConstructorTestHelper<ValueT>()
        {
            LockFreeQueue<ValueT> target = new LockFreeQueue<ValueT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void LockFreeQueueConstructorTest()
        {
            LockFreeQueueConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
