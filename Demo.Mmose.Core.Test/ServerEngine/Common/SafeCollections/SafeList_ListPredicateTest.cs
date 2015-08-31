using Demo.Mmose.Core.Common.SafeCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 SafeList_ListPredicateTest 的测试类，旨在
    ///包含所有 SafeList_ListPredicateTest 单元测试
    ///</summary>
    [TestClass()]
    public class SafeList_ListPredicateTest
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
        ///Data 的测试
        ///</summary>
        public void DataTestHelper<ValueT, InternalT>()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            SafeList_Accessor<ValueT>.ListPredicate<InternalT> target = new SafeList_Accessor<ValueT>.ListPredicate<InternalT>( param0 ); // TODO: 初始化为适当的值
            Dictionary<InternalT, InternalT> actual;
            actual = target.Data;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DataTest()
        {
            DataTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///PredicateCallback 的测试
        ///</summary>
        public void PredicateCallbackTestHelper<ValueT, InternalT>()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            SafeList_Accessor<ValueT>.ListPredicate<InternalT> target = new SafeList_Accessor<ValueT>.ListPredicate<InternalT>( param0 ); // TODO: 初始化为适当的值
            InternalT value = default( InternalT ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.PredicateCallback( value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void PredicateCallbackTest()
        {
            PredicateCallbackTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///ListPredicate`1 构造函数 的测试
        ///</summary>
        public void SafeList_ListPredicateConstructorTestHelper<ValueT, InternalT>()
        {
            int iCapacity = 0; // TODO: 初始化为适当的值
            SafeList_Accessor<ValueT>.ListPredicate<InternalT> target = new SafeList_Accessor<ValueT>.ListPredicate<InternalT>( iCapacity );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void SafeList_ListPredicateConstructorTest()
        {
            SafeList_ListPredicateConstructorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }
    }
}
