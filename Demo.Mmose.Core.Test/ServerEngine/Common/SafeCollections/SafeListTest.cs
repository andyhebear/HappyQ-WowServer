using Demo.Mmose.Core.Common.SafeCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SafeListTest 的测试类，旨在
    ///包含所有 SafeListTest 单元测试
    ///</summary>
    [TestClass()]
    public class SafeListTest
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
        ///Item 的测试
        ///</summary>
        public void ItemTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            int iIndex = 0; // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            target[iIndex] = expected;
            actual = target[iIndex];
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Count 的测试
        ///</summary>
        public void CountTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
        ///Capacity 的测试
        ///</summary>
        public void CapacityTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.Capacity = expected;
            actual = target.Capacity;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CapacityTest()
        {
            CapacityTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayAndClear 的测试
        ///</summary>
        public void ToArrayAndClearTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
            IEnumerable target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
        ///RemoveRange 的测试
        ///</summary>
        public void RemoveRangeTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            int iIndex = 0; // TODO: 初始化为适当的值
            int iCount = 0; // TODO: 初始化为适当的值
            target.RemoveRange( iIndex, iCount );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveRangeTest()
        {
            RemoveRangeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveAt 的测试
        ///</summary>
        public void RemoveAtTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            int iIndex = 0; // TODO: 初始化为适当的值
            target.RemoveAt( iIndex );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            RemoveAtTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveAll 的测试
        ///</summary>
        public void RemoveAllTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Predicate<ValueT> match = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.RemoveAll( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveAllTest()
        {
            RemoveAllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        public void RemoveTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            target.Remove( value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
        ///ForEach 的测试
        ///</summary>
        public void ForEachTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Action<ValueT> action = null; // TODO: 初始化为适当的值
            target.ForEach( action );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ForEachTest()
        {
            ForEachTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///FindLast 的测试
        ///</summary>
        public void FindLastTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Predicate<ValueT> match = null; // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            actual = target.FindLast( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindLastTest()
        {
            FindLastTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///FindAll 的测试
        ///</summary>
        public void FindAllTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Predicate<ValueT> match = null; // TODO: 初始化为适当的值
            SafeList<ValueT> expected = null; // TODO: 初始化为适当的值
            SafeList<ValueT> actual;
            actual = target.FindAll( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindAllTest()
        {
            FindAllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Find 的测试
        ///</summary>
        public void FindTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Predicate<ValueT> match = null; // TODO: 初始化为适当的值
            ValueT expected = default( ValueT ); // TODO: 初始化为适当的值
            ValueT actual;
            actual = target.Find( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindTest()
        {
            FindTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Exists 的测试
        ///</summary>
        public void ExistsTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Predicate<ValueT> match = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Exists( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ExistsTest()
        {
            ExistsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///CopyTo 的测试
        ///</summary>
        public void CopyToTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
        ///ConvertAll 的测试
        ///</summary>
        public void ConvertAllTestHelper<ValueT, TOutput>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            Converter<ValueT, TOutput> converter = null; // TODO: 初始化为适当的值
            SafeList<TOutput> expected = null; // TODO: 初始化为适当的值
            SafeList<TOutput> actual;
            actual = target.ConvertAll<TOutput>( converter );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ConvertAllTest()
        {
            ConvertAllTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        public void ContainsTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
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
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///AddRange 的测试
        ///</summary>
        public void AddRangeTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            IEnumerable<ValueT> collection = null; // TODO: 初始化为适当的值
            target.AddRange( collection );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            AddRangeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        public void AddTestHelper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>(); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            target.Add( value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeList`1 构造函数 的测试
        ///</summary>
        public void SafeListConstructorTest2Helper<ValueT>()
        {
            SafeList<ValueT> target = new SafeList<ValueT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeListConstructorTest2()
        {
            SafeListConstructorTest2Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeList`1 构造函数 的测试
        ///</summary>
        public void SafeListConstructorTest1Helper<ValueT>()
        {
            IEnumerable<ValueT> collection = null; // TODO: 初始化为适当的值
            SafeList<ValueT> target = new SafeList<ValueT>( collection );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeListConstructorTest1()
        {
            SafeListConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeList`1 构造函数 的测试
        ///</summary>
        public void SafeListConstructorTestHelper<ValueT>()
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            SafeList<ValueT> target = new SafeList<ValueT>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeListConstructorTest()
        {
            SafeListConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
