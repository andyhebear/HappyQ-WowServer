using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Creature;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseItemStateTest 的测试类，旨在
    ///包含所有 BaseItemStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseItemStateTest
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
        ///SingletonInstance 的测试
        ///</summary>
        [TestMethod()]
        public void SingletonInstanceTest()
        {
            BaseItemState actual;
            actual = BaseItemState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateRemoveChildItemCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateRemoveChildItemCallTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateRemoveChildItemCall = expected;
            actual = target.IsUpdateRemoveChildItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateParent 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateParentTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateParent = expected;
            actual = target.IsUpdateParent;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateOwner 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateOwnerTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateOwner = expected;
            actual = target.IsUpdateOwner;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateName 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateNameTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateName = expected;
            actual = target.IsUpdateName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateItemTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateItemTemplateTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateItemTemplate = expected;
            actual = target.IsUpdateItemTemplate;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateAddChildItemCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateAddChildItemCallTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateAddChildItemCall = expected;
            actual = target.IsUpdateAddChildItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingParent 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingParentTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem parentItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingParent( parentItem, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingOwner 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingOwnerTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseCreature ownerCreature = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingOwner( ownerCreature, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingNameTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseItem baseItem = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingName( strName, baseItem );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingItemTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingItemTemplateTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItemTemplate itemTemplate = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingItemTemplate( itemTemplate, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatedParent 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedParentTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem parentItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnUpdatedParent( parentItem, item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedOwner 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedOwnerTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseCreature ownerCreature = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnUpdatedOwner( ownerCreature, item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedNameTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseItem baseItem = null; // TODO: 初始化为适当的值
            target.OnUpdatedName( strName, baseItem );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedItemTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedItemTemplateTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItemTemplate itemTemplate = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnUpdatedItemTemplate( itemTemplate, item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRemovingChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovingChildItemTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem removeChildItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingChildItem( removeChildItem, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRemovedChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovedChildItemTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem removeChildItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnRemovedChildItem( removeChildItem, item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAddingChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddingChildItemTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem addChildItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingChildItem( addChildItem, item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAddedChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddedChildItemTest()
        {
            BaseItemState target = new BaseItemState(); // TODO: 初始化为适当的值
            BaseItem addChildItem = null; // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnAddedChildItem( addChildItem, item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseItemState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseItemStateConstructorTest()
        {
            BaseItemState target = new BaseItemState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
