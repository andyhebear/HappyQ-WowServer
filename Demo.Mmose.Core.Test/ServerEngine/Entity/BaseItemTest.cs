using Demo.Mmose.Core.Entity.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Creature;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseItemTest 的测试类，旨在
    ///包含所有 BaseItemTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseItemTest
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
        ///SlotId 的测试
        ///</summary>
        [TestMethod()]
        public void SlotIdTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            long expected = 0; // TODO: 初始化为适当的值
            long actual;
            target.SlotId = expected;
            actual = target.SlotId;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Parent 的测试
        ///</summary>
        [TestMethod()]
        public void ParentTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseItem expected = null; // TODO: 初始化为适当的值
            BaseItem actual;
            target.Parent = expected;
            actual = target.Parent;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Owner 的测试
        ///</summary>
        [TestMethod()]
        public void OwnerTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseCreature expected = null; // TODO: 初始化为适当的值
            BaseCreature actual;
            target.Owner = expected;
            actual = target.Owner;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void ItemTemplateTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseItemTemplate expected = null; // TODO: 初始化为适当的值
            BaseItemTemplate actual;
            target.ItemTemplate = expected;
            actual = target.ItemTemplate;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseItemState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseItemStateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseItem_Accessor target = new BaseItem_Accessor( param0 ); // TODO: 初始化为适当的值
            BaseItemState expected = null; // TODO: 初始化为适当的值
            BaseItemState actual;
            target.BaseItemState = expected;
            actual = target.BaseItemState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInChildItems 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInChildItemsTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseItem[] expected = null; // TODO: 初始化为适当的值
            BaseItem[] actual;
            actual = target.ToArrayInChildItems();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoveChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveChildItemTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            long lItemSerial = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveChildItem( lItemSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnParentDeleted 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnParentDeletedTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseItem_Accessor target = new BaseItem_Accessor( param0 ); // TODO: 初始化为适当的值
            BaseItem parentItem = null; // TODO: 初始化为适当的值
            target.OnParentDeleted( parentItem );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///FindChildItemOnSerial 的测试
        ///</summary>
        [TestMethod()]
        public void FindChildItemOnSerialTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            long iItemSerial = 0; // TODO: 初始化为适当的值
            BaseItem expected = null; // TODO: 初始化为适当的值
            BaseItem actual;
            actual = target.FindChildItemOnSerial( iItemSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseItem_Accessor CreateBaseItem_Accessor()
        {
            // TODO: 实例化相应的具体类。
            BaseItem_Accessor target = null;
            return target;
        }

        /// <summary>
        ///DefaultItemInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DefaultItemInitTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseItem_Accessor target = new BaseItem_Accessor( param0 ); // TODO: 初始化为适当的值
            target.DefaultItemInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///CreateNewItemInstance 的测试
        ///</summary>
        [TestMethod()]
        public void CreateNewItemInstanceTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseItem expected = null; // TODO: 初始化为适当的值
            BaseItem actual;
            actual = target.CreateNewItemInstance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            BaseItem other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseItem CreateBaseItem()
        {
            // TODO: 实例化相应的具体类。
            BaseItem target = null;
            return target;
        }

        /// <summary>
        ///AddChildItem 的测试
        ///</summary>
        [TestMethod()]
        public void AddChildItemTest()
        {
            BaseItem target = CreateBaseItem(); // TODO: 初始化为适当的值
            long lItemSerial = 0; // TODO: 初始化为适当的值
            BaseItem addChildItem = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddChildItem( lItemSerial, addChildItem );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
