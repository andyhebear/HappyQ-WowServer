using Demo.Mmose.Core.Common.SafeCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SafeHashSetTest 的测试类，旨在
    ///包含所有 SafeHashSetTest 单元测试
    ///</summary>
    [TestClass()]
    public class SafeHashSetTest
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
        public void CountTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
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
        ///UnionWith 的测试
        ///</summary>
        public void UnionWithTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            target.UnionWith( other );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void UnionWithTest()
        {
            UnionWithTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayAndClear 的测试
        ///</summary>
        public void ToArrayAndClearTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            KeyT[] expected = null; // TODO: 初始化为适当的值
            KeyT[] actual;
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
        public void ToArrayTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            KeyT[] expected = null; // TODO: 初始化为适当的值
            KeyT[] actual;
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
        public void GetEnumeratorTest1Helper<KeyT>()
        {
            IEnumerable target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
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
        ///SymmetricExceptWith 的测试
        ///</summary>
        public void SymmetricExceptWithTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            target.SymmetricExceptWith( other );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void SymmetricExceptWithTest()
        {
            SymmetricExceptWithTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SetEquals 的测试
        ///</summary>
        public void SetEqualsTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SetEquals( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void SetEqualsTest()
        {
            SetEqualsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveAll 的测试
        ///</summary>
        public void RemoveAllTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            Predicate<KeyT> match = null; // TODO: 初始化为适当的值
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
        public void RemoveTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            target.Remove( key );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Overlaps 的测试
        ///</summary>
        public void OverlapsTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Overlaps( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            OverlapsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsSupersetOf 的测试
        ///</summary>
        public void IsSupersetOfTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsSupersetOf( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsSupersetOfTest()
        {
            IsSupersetOfTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsSubsetOf 的测试
        ///</summary>
        public void IsSubsetOfTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsSubsetOf( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsSubsetOfTest()
        {
            IsSubsetOfTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsProperSupersetOf 的测试
        ///</summary>
        public void IsProperSupersetOfTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsProperSupersetOf( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsProperSupersetOfTest()
        {
            IsProperSupersetOfTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IsProperSubsetOf 的测试
        ///</summary>
        public void IsProperSubsetOfTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsProperSubsetOf( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void IsProperSubsetOfTest()
        {
            IsProperSubsetOfTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///IntersectWith 的测试
        ///</summary>
        public void IntersectWithTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            target.IntersectWith( other );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void IntersectWithTest()
        {
            IntersectWithTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///InternalToCached 的测试
        ///</summary>
        public void InternalToCachedTestHelper<KeyT>()
        {
            SafeHashSet_Accessor<KeyT> target = new SafeHashSet_Accessor<KeyT>(); // TODO: 初始化为适当的值
            target.InternalToCached();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InternalToCachedTest()
        {
            InternalToCachedTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerator<KeyT> expected = null; // TODO: 初始化为适当的值
            IEnumerator<KeyT> actual;
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
        ///ExceptWith 的测试
        ///</summary>
        public void ExceptWithTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> other = null; // TODO: 初始化为适当的值
            target.ExceptWith( other );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ExceptWithTest()
        {
            ExceptWithTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        public void ContainsTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( key );
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
        public void ClearTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
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
        public void AddRangeTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> collection = null; // TODO: 初始化为适当的值
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
        public void AddTestHelper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            target.Add( key );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeHashSet`1 构造函数 的测试
        ///</summary>
        public void SafeHashSetConstructorTest1Helper<KeyT>()
        {
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeHashSetConstructorTest1()
        {
            SafeHashSetConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///SafeHashSet`1 构造函数 的测试
        ///</summary>
        public void SafeHashSetConstructorTestHelper<KeyT>()
        {
            IEnumerable<KeyT> collection = null; // TODO: 初始化为适当的值
            SafeHashSet<KeyT> target = new SafeHashSet<KeyT>( collection );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeHashSetConstructorTest()
        {
            SafeHashSetConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
