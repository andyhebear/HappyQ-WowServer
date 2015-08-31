using Demo.Mmose.Core.Common.SafeCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SafeMultiDictionaryTest 的测试类，旨在
    ///包含所有 SafeMultiDictionaryTest 单元测试
    ///</summary>
    [TestClass()]
    public class SafeMultiDictionaryTest
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
        ///Keys 的测试
        ///</summary>
        public void KeysTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> actual;
            actual = target.Keys;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void KeysTest()
        {
            KeysTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Item 的测试
        ///</summary>
        public void ItemTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ValueT> actual;
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
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
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
        ///TryGetValues 的测试
        ///</summary>
        public void TryGetValuesTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            IEnumerable<ValueT> valuesExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.TryGetValues( key, out values );
            Assert.AreEqual( valuesExpected, values );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void TryGetValuesTest()
        {
            TryGetValuesTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayValuesByKeyAndClear 的测试
        ///</summary>
        public void ToArrayValuesByKeyAndClearTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT[] expected = null; // TODO: 初始化为适当的值
            ValueT[] actual;
            actual = target.ToArrayValuesByKeyAndClear( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayValuesByKeyAndClearTest()
        {
            ToArrayValuesByKeyAndClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayValuesByKey 的测试
        ///</summary>
        public void ToArrayValuesByKeyTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT[] expected = null; // TODO: 初始化为适当的值
            ValueT[] actual;
            actual = target.ToArrayValuesByKey( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayValuesByKeyTest()
        {
            ToArrayValuesByKeyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayKeysAndClear 的测试
        ///</summary>
        public void ToArrayKeysAndClearTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT[] expected = null; // TODO: 初始化为适当的值
            KeyT[] actual;
            actual = target.ToArrayKeysAndClear();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayKeysAndClearTest()
        {
            ToArrayKeysAndClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayKeys 的测试
        ///</summary>
        public void ToArrayKeysTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT[] expected = null; // TODO: 初始化为适当的值
            KeyT[] actual;
            actual = target.ToArrayKeys();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayKeysTest()
        {
            ToArrayKeysTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArrayAndClear 的测试
        ///</summary>
        public void ToArrayAndClearTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT[]>[] expected = null; // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT[]>[] actual;
            actual = target.ToArrayAndClear();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayAndClearTest()
        {
            ToArrayAndClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ToArray 的测试
        ///</summary>
        public void ToArrayTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT[]>[] expected = null; // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT[]>[] actual;
            actual = target.ToArray();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            ToArrayTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTest1Helper<KeyT, ValueT>()
        {
            IEnumerable target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
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
        ///RemoveMany 的测试
        ///</summary>
        public void RemoveManyTest1Helper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            IEnumerable<KeyT> key = null; // TODO: 初始化为适当的值
            target.RemoveMany( key );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
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
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> values = null; // TODO: 初始化为适当的值
            target.RemoveMany( key, values );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RemoveManyTest()
        {
            RemoveManyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///RemoveAll 的测试
        ///</summary>
        public void RemoveAllTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            Predicate<KeyT, ValueT> match = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.RemoveAll( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveAllTest()
        {
            RemoveAllTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Remove 的测试
        ///</summary>
        public void RemoveTest1Helper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Remove( key, value );
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
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Remove( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///InternalToArray 的测试
        ///</summary>
        public void InternalToArrayTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary_Accessor<KeyT, ValueT> target = new SafeMultiDictionary_Accessor<KeyT, ValueT>(); // TODO: 初始化为适当的值
            target.InternalToArray();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void InternalToArrayTest()
        {
            InternalToArrayTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///GetValues 的测试
        ///</summary>
        public void GetValuesTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            IEnumerable<ValueT> expected = null; // TODO: 初始化为适当的值
            IEnumerable<ValueT> actual;
            actual = target.GetValues( key );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetValuesTest()
        {
            GetValuesTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///GetEnumerator 的测试
        ///</summary>
        public void GetEnumeratorTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            IEnumerator<KeyValuePair<KeyT, IEnumerable<ValueT>>> expected = null; // TODO: 初始化为适当的值
            IEnumerator<KeyValuePair<KeyT, IEnumerable<ValueT>>> actual;
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
        ///ForEach 的测试
        ///</summary>
        public void ForEachTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            Action<KeyT, ValueT> action = null; // TODO: 初始化为适当的值
            target.ForEach( action );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void ForEachTest()
        {
            ForEachTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///FindAll 的测试
        ///</summary>
        public void FindAllTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            Predicate<KeyT, ValueT> match = null; // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT>[] expected = null; // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT>[] actual;
            actual = target.FindAll( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindAllTest()
        {
            FindAllTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Find 的测试
        ///</summary>
        public void FindTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            Predicate<KeyT, ValueT> match = null; // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT> findKeyValuePair = new KeyValuePair<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyValuePair<KeyT, ValueT> findKeyValuePairExpected = new KeyValuePair<KeyT, ValueT>(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Find( match, out findKeyValuePair );
            Assert.AreEqual( findKeyValuePairExpected, findKeyValuePair );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void FindTest()
        {
            FindTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Exists 的测试
        ///</summary>
        public void ExistsTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            Predicate<KeyT, ValueT> match = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Exists( match );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ExistsTest()
        {
            ExistsTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ContainsKey 的测试
        ///</summary>
        public void ContainsKeyTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
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
        public void ContainsTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
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
        ///Clear 的测试
        ///</summary>
        public void ClearTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary_Accessor<KeyT, ValueT> target = new SafeMultiDictionary_Accessor<KeyT, ValueT>(); // TODO: 初始化为适当的值
            target.Clear();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///AddMany 的测试
        ///</summary>
        public void AddManyTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
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
        public void AddTestHelper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>(); // TODO: 初始化为适当的值
            KeyT key = default( KeyT ); // TODO: 初始化为适当的值
            ValueT value = default( ValueT ); // TODO: 初始化为适当的值
            target.Add( key, value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///SafeMultiDictionary`2 构造函数 的测试
        ///</summary>
        public void SafeMultiDictionaryConstructorTest1Helper<KeyT, ValueT>()
        {
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeMultiDictionaryConstructorTest1()
        {
            SafeMultiDictionaryConstructorTest1Helper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///SafeMultiDictionary`2 构造函数 的测试
        ///</summary>
        public void SafeMultiDictionaryConstructorTestHelper<KeyT, ValueT>()
        {
            bool allowDuplicateValues = false; // TODO: 初始化为适当的值
            SafeMultiDictionary<KeyT, ValueT> target = new SafeMultiDictionary<KeyT, ValueT>( allowDuplicateValues );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void SafeMultiDictionaryConstructorTest()
        {
            SafeMultiDictionaryConstructorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }
    }
}
