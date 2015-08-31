using Demo.Mmose.Core.Common.SafeCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SafeStackTest 的测试类，旨在
    ///包含所有 SafeStackTest 单元测试
    ///</summary>
    [TestClass()]
    public class SafeStackTest
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
        ///Count 的测试
        ///</summary>
        public void CountTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
            int actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CountTest()
        {
            CountTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayAndClear 的测试
        ///</summary>
        public void ToArrayAndClearTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
            IEnumerable target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
        ///Push 的测试
        ///</summary>
        public void PushTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            target.Push( value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void PushTest()
        {
            PushTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Pop 的测试
        ///</summary>
        public void PopTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            actual = target.Pop();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void PopTest()
        {
            PopTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Peek 的测试
        ///</summary>
        public void PeekTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
        ///CopyTo 的测试
        ///</summary>
        public void CopyToTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
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
            SafeStack<ValueT> target = new SafeStack<ValueT>(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeStack`1 构造函数 的测试
        ///</summary>
        public void SafeStackConstructorTestHelper<ValueT>()
        {
            SafeStack<ValueT> target = new SafeStack<ValueT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeStackConstructorTest()
        {
            SafeStackConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
