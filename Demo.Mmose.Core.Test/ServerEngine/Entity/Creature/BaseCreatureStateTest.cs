using Demo.Mmose.Core.Entity.Creature;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Suit.Treasure;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseCreatureStateTest 的测试类，旨在
    ///包含所有 BaseCreatureStateTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseCreatureStateTest
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
            BaseCreatureState actual;
            actual = BaseCreatureState.SingletonInstance;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateName 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateNameTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateName = expected;
            actual = target.IsUpdateName;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateLoots 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateLoots = expected;
            actual = target.IsUpdateLoots;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateGoldLoots 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateGoldLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateGoldLoots = expected;
            actual = target.IsUpdateGoldLoots;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsUpdateCreatureTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void IsUpdateCreatureTemplateTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsUpdateCreatureTemplate = expected;
            actual = target.IsUpdateCreatureTemplate;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRevivalCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsRevivalCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRevivalCall = expected;
            actual = target.IsRevivalCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRemovePartyCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsRemovePartyCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRemovePartyCall = expected;
            actual = target.IsRemovePartyCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRemoveItemCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsRemoveItemCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRemoveItemCall = expected;
            actual = target.IsRemoveItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRemoveGroupCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsRemoveGroupCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRemoveGroupCall = expected;
            actual = target.IsRemoveGroupCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsRemoveFriendCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsRemoveFriendCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsRemoveFriendCall = expected;
            actual = target.IsRemoveFriendCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsDeathCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsDeathCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsDeathCall = expected;
            actual = target.IsDeathCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsAddPartyCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsAddPartyCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsAddPartyCall = expected;
            actual = target.IsAddPartyCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsAddItemCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsAddItemCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsAddItemCall = expected;
            actual = target.IsAddItemCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsAddGroupCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsAddGroupCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsAddGroupCall = expected;
            actual = target.IsAddGroupCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsAddFriendCall 的测试
        ///</summary>
        [TestMethod()]
        public void IsAddFriendCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsAddFriendCall = expected;
            actual = target.IsAddFriendCall;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RestoreAll 的测试
        ///</summary>
        [TestMethod()]
        public void RestoreAllTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            target.RestoreAll();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatingName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingNameTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingName( strName, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingLoots 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            OneTreasure[] loots = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingLoots( loots, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingGoldLoots 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingGoldLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            OneTreasure[] goldLoots = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingGoldLoots( goldLoots, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatingCreatureTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatingCreatureTemplateTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreatureTemplate creatureTemplate = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnUpdatingCreatureTemplate( creatureTemplate, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUpdatedName 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedNameTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedName( strName, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedLoots 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            OneTreasure[] loots = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedLoots( loots, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedGoldLoots 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedGoldLootsTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            OneTreasure[] goldLoots = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedGoldLoots( goldLoots, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnUpdatedCreatureTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void OnUpdatedCreatureTemplateTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreatureTemplate creatureTemplate = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnUpdatedCreatureTemplate( creatureTemplate, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRemovingParty 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovingPartyTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureParty = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingParty( creatureParty, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRemovingItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovingItemTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseItem removeItem = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingItem( removeItem, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRemovingGroup 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovingGroupTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureGroup = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingGroup( creatureGroup, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRemovingFriend 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovingFriendTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureFriend = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnRemovingFriend( creatureFriend, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRemovedParty 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovedPartyTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureParty = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnRemovedParty( creatureParty, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRemovedItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovedItemTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseItem removeItem = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnRemovedItem( removeItem, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRemovedGroup 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovedGroupTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureGroup = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnRemovedGroup( creatureGroup, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRemovedFriend 的测试
        ///</summary>
        [TestMethod()]
        public void OnRemovedFriendTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureFriend = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnRemovedFriend( creatureFriend, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLivingCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnLivingCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureRevival = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnLivingCall( creatureRevival, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnLivedCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnLivedCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureRevival = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnLivedCall( creatureRevival, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDieingCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnDieingCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureKiller = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnDieingCall( creatureKiller, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnDiedCall 的测试
        ///</summary>
        [TestMethod()]
        public void OnDiedCallTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureKiller = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnDiedCall( creatureKiller, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAddingParty 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddingPartyTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureParty = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingParty( creatureParty, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAddingItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddingItemTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseItem addItem = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingItem( addItem, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAddingGroup 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddingGroupTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureGroup = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingGroup( creatureGroup, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAddingFriend 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddingFriendTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureFriend = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnAddingFriend( creatureFriend, creature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAddedParty 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddedPartyTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureParty = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnAddedParty( creatureParty, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAddedItem 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddedItemTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseItem addItem = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnAddedItem( addItem, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAddedGroup 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddedGroupTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureGroup = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnAddedGroup( creatureGroup, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnAddedFriend 的测试
        ///</summary>
        [TestMethod()]
        public void OnAddedFriendTest()
        {
            BaseCreatureState target = new BaseCreatureState(); // TODO: 初始化为适当的值
            BaseCreature creatureFriend = null; // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnAddedFriend( creatureFriend, creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///BaseCreatureState 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void BaseCreatureStateConstructorTest()
        {
            BaseCreatureState target = new BaseCreatureState();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
