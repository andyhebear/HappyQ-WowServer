using Demo.Mmose.Core.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    
    
    /// <summary>
    ///这是 MultiDictionaryTest 的测试类，旨在
    ///包含所有 MultiDictionaryTest 单元测试
    ///</summary>
    [TestClass()]
    public class MultiDictionaryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        ///ValueComparer 的测试
        ///</summary>
        public void ValueComparerTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            IEqualityComparer<ValueT> actual;
            actual = target.ValueComparer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ValueComparerTest()
        {
            ValueComparerTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ValueCapacity 的测试
        ///</summary>
        public void ValueCapacityTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            int actual;
            actual = target.ValueCapacity;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ValueCapacityTest()
        {
            ValueCapacityTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///KeyComparer 的测试
        ///</summary>
        public void KeyComparerTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            IEqualityComparer<KeyT> actual;
            actual = target.KeyComparer;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void KeyComparerTest()
        {
            KeyComparerTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///KeyCapacity 的测试
        ///</summary>
        public void KeyCapacityTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            int actual;
            actual = target.KeyCapacity;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void KeyCapacityTest()
        {
            KeyCapacityTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Item 的测试
        ///</summary>
        public void ItemTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ICollection<ValueT> expected = null; // TODO: 初始化为适当的值
            ICollection<ValueT> actual;
            target[key] = expected;
            actual = target[key];
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Count 的测试
        ///</summary>
        public void CountTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            int actual;
            actual = target.Count;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CountTest()
        {
            CountTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///TryEnumerateValuesForKey 的测试
        ///</summary>
        public void TryEnumerateValuesForKeyTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            IEnumerable<ValueT> valuesExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.TryEnumerateValuesForKey( key, out values );
            Assert.AreEqual( valuesExpected, values );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void TryEnumerateValuesForKeyTest()
        {
            TryEnumerateValuesForKeyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            IEnumerable target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
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
            GetEnumeratorTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ReplaceMany 的测试
        ///</summary>
        public void ReplaceManyTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ReplaceMany( key, values );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ReplaceManyTest()
        {
            ReplaceManyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Replace 的测试
        ///</summary>
        public void ReplaceTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ICollection<ValueT>> pair = new KeyValuePair<KeyT, ICollection<ValueT>>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Replace( pair );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ReplaceTest1()
        {
            ReplaceTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Replace 的测试
        ///</summary>
        public void ReplaceTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Replace( key, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ReplaceTest()
        {
            ReplaceTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveMany 的测试
        ///</summary>
        public void RemoveManyTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.RemoveMany( key, values );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveManyTest1()
        {
            RemoveManyTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveMany 的测试
        ///</summary>
        public void RemoveManyTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            IEnumerable<KeyT> keyCollection = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.RemoveMany( keyCollection );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveManyTest()
        {
            RemoveManyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        public void RemoveTest2Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Remove( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveTest2()
        {
            RemoveTest2Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        public void RemoveTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ICollection<ValueT>> pair = new KeyValuePair<KeyT, ICollection<ValueT>>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Remove( pair );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            RemoveTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        public void RemoveTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Remove( key, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            IEnumerator<KeyValuePair<KeyT, ICollection<ValueT>>> expected = null; // TODO: 初始化为适当的值
            IEnumerator<KeyValuePair<KeyT, ICollection<ValueT>>> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///CountValues 的测试
        ///</summary>
        public void CountValuesTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CountValues( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CountValuesTest()
        {
            CountValuesTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ContainsKey 的测试
        ///</summary>
        public void ContainsKeyTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.ContainsKey( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            ContainsKeyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        public void ContainsTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ICollection<ValueT>> pair = new KeyValuePair<KeyT, ICollection<ValueT>>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( pair );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ContainsTest1()
        {
            ContainsTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        public void ContainsTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( key, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ContainsTest()
        {
            ContainsTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ClearValues 的测试
        ///</summary>
        public void ClearValuesTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            target.ClearValues( key );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ClearValuesTest()
        {
            ClearValuesTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///AddMany 的测试
        ///</summary>
        public void AddManyTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            target.AddMany( key, values );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddManyTest()
        {
            AddManyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        public void AddTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            target.Add( key, value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest1()
        {
            AddTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Add 的测试
        ///</summary>
        public void AddTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues ); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ICollection<ValueT>> pair = new KeyValuePair<KeyT, ICollection<ValueT>>(); // TODO: 初始化为适当的值
            target.Add( pair );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///MultiDictionary`2 构造函数 的测试
        ///</summary>
        public void MultiDictionaryConstructorTest3Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            int iKeyCapacity = 0; // TODO: 初始化为适当的值
            int iValueCapacity = 0; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues, iKeyCapacity, iValueCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MultiDictionaryConstructorTest3()
        {
            MultiDictionaryConstructorTest3Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///MultiDictionary`2 构造函数 的测试
        ///</summary>
        public void MultiDictionaryConstructorTest2Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MultiDictionaryConstructorTest2()
        {
            MultiDictionaryConstructorTest2Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///MultiDictionary`2 构造函数 的测试
        ///</summary>
        public void MultiDictionaryConstructorTest1Helper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            int iKeyCapacity = 0; // TODO: 初始化为适当的值
            int iValueCapacity = 0; // TODO: 初始化为适当的值
            IEqualityComparer<KeyT> keyEqualityComparer = null; // TODO: 初始化为适当的值
            IEqualityComparer<ValueT> valueEqualityComparer = null; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues, iKeyCapacity, iValueCapacity, keyEqualityComparer, valueEqualityComparer );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MultiDictionaryConstructorTest1()
        {
            MultiDictionaryConstructorTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///MultiDictionary`2 构造函数 的测试
        ///</summary>
        public void MultiDictionaryConstructorTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            int iKeyCapacity = 0; // TODO: 初始化为适当的值
            int iValueCapacity = 0; // TODO: 初始化为适当的值
            IEqualityComparer<KeyT> keyEqualityComparer = null; // TODO: 初始化为适当的值
            MultiDictionary<KeyT, ValueT> target = new MultiDictionary<KeyT, ValueT>( allowDuplicateValues, iKeyCapacity, iValueCapacity, keyEqualityComparer );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MultiDictionaryConstructorTest()
        {
            MultiDictionaryConstructorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }
    }
}
