using Demo.Mmose.Core.Entity.Creature;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Entity.Item;
using System;
using Demo.Mmose.Core.Entity.Suit.Treasure;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 BaseCreatureTest 的测试类，旨在
    ///包含所有 BaseCreatureTest 单元测试
    ///</summary>
    [TestClass()]
    public class BaseCreatureTest
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
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Loots 的测试
        ///</summary>
        [TestMethod()]
        public void LootsTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            OneTreasure[] expected = null; // TODO: 初始化为适当的值
            OneTreasure[] actual;
            target.Loots = expected;
            actual = target.Loots;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GoldLoots 的测试
        ///</summary>
        [TestMethod()]
        public void GoldLootsTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            OneTreasure[] expected = null; // TODO: 初始化为适当的值
            OneTreasure[] actual;
            target.GoldLoots = expected;
            actual = target.GoldLoots;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreatureTemplate 的测试
        ///</summary>
        [TestMethod()]
        public void CreatureTemplateTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreatureTemplate expected = null; // TODO: 初始化为适当的值
            BaseCreatureTemplate actual;
            target.CreatureTemplate = expected;
            actual = target.CreatureTemplate;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreationTime 的测试
        ///</summary>
        [TestMethod()]
        public void CreationTimeTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            DateTime actual;
            actual = target.CreationTime;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///BaseCreatureState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void BaseCreatureStateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseCreature_Accessor target = new BaseCreature_Accessor( param0 ); // TODO: 初始化为适当的值
            BaseCreatureState expected = null; // TODO: 初始化为适当的值
            BaseCreatureState actual;
            target.BaseCreatureState = expected;
            actual = target.BaseCreatureState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Alive 的测试
        ///</summary>
        [TestMethod()]
        public void AliveTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Alive;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInParty 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInPartyTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature[] expected = null; // TODO: 初始化为适当的值
            BaseCreature[] actual;
            actual = target.ToArrayInParty();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInItems 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInItemsTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseItem[] expected = null; // TODO: 初始化为适当的值
            BaseItem[] actual;
            actual = target.ToArrayInItems();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInGroup 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInGroupTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature[] expected = null; // TODO: 初始化为适当的值
            BaseCreature[] actual;
            actual = target.ToArrayInGroup();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInFriend 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInFriendTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature[] expected = null; // TODO: 初始化为适当的值
            BaseCreature[] actual;
            actual = target.ToArrayInFriend();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoveParty 的测试
        ///</summary>
        [TestMethod()]
        public void RemovePartyTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveParty( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoveItem 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveItemTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial itemSerial = new Serial(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveItem( itemSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoveGroup 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveGroupTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveGroup( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RemoveFriend 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveFriendTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.RemoveFriend( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Live 的测试
        ///</summary>
        [TestMethod()]
        public void LiveTest1()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature creatureLive = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Live( creatureLive );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Live 的测试
        ///</summary>
        [TestMethod()]
        public void LiveTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Live();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GenerateLoot 的测试
        ///</summary>
        public void GenerateLootTestHelper<ItemT>()
            where ItemT : BaseItem
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            ItemT[] expected = null; // TODO: 初始化为适当的值
            ItemT[] actual;
            actual = target.GenerateLoot<ItemT>();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GenerateLootTest()
        {
            Assert.Inconclusive( "没有找到能够满足 ItemT 的类型约束的相应类型参数。请以适当的类型参数来调用 GenerateLootTestHelper<ItemT>()。" );
        }

        /// <summary>
        ///GenerateGoldLoot 的测试
        ///</summary>
        [TestMethod()]
        public void GenerateGoldLootTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            GoldItem[] expected = null; // TODO: 初始化为适当的值
            GoldItem[] actual;
            actual = target.GenerateGoldLoot();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindPartyOnSerial 的测试
        ///</summary>
        [TestMethod()]
        public void FindPartyOnSerialTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature expected = null; // TODO: 初始化为适当的值
            BaseCreature actual;
            actual = target.FindPartyOnSerial( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindItemOnSerial 的测试
        ///</summary>
        [TestMethod()]
        public void FindItemOnSerialTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial itemSerial = new Serial(); // TODO: 初始化为适当的值
            BaseItem expected = null; // TODO: 初始化为适当的值
            BaseItem actual;
            actual = target.FindItemOnSerial( itemSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindGroupOnSerial 的测试
        ///</summary>
        [TestMethod()]
        public void FindGroupOnSerialTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature expected = null; // TODO: 初始化为适当的值
            BaseCreature actual;
            actual = target.FindGroupOnSerial( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///FindFriendOnSerial 的测试
        ///</summary>
        [TestMethod()]
        public void FindFriendOnSerialTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature expected = null; // TODO: 初始化为适当的值
            BaseCreature actual;
            actual = target.FindFriendOnSerial( creatureSerial );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Die 的测试
        ///</summary>
        [TestMethod()]
        public void DieTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature creatureKiller = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Die( creatureKiller );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseCreature_Accessor CreateBaseCreature_Accessor()
        {
            // TODO: 实例化相应的具体类。
            BaseCreature_Accessor target = null;
            return target;
        }

        /// <summary>
        ///DefaultCreatureInit 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void DefaultCreatureInitTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            BaseCreature_Accessor target = new BaseCreature_Accessor( param0 ); // TODO: 初始化为适当的值
            target.DefaultCreatureInit();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Death 的测试
        ///</summary>
        [TestMethod()]
        public void DeathTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Death();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreateNewCreatureInstance 的测试
        ///</summary>
        [TestMethod()]
        public void CreateNewCreatureInstanceTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature expected = null; // TODO: 初始化为适当的值
            BaseCreature actual;
            actual = target.CreateNewCreatureInstance();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CompareTo 的测试
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            BaseCreature other = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( other );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AddParty 的测试
        ///</summary>
        [TestMethod()]
        public void AddPartyTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature addCreature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddParty( creatureSerial, addCreature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AddItem 的测试
        ///</summary>
        [TestMethod()]
        public void AddItemTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial itemSerial = new Serial(); // TODO: 初始化为适当的值
            BaseItem addItem = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddItem( itemSerial, addItem );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AddGroup 的测试
        ///</summary>
        [TestMethod()]
        public void AddGroupTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature addCreature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddGroup( creatureSerial, addCreature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        internal virtual BaseCreature CreateBaseCreature()
        {
            // TODO: 实例化相应的具体类。
            BaseCreature target = null;
            return target;
        }

        /// <summary>
        ///AddFriend 的测试
        ///</summary>
        [TestMethod()]
        public void AddFriendTest()
        {
            BaseCreature target = CreateBaseCreature(); // TODO: 初始化为适当的值
            Serial creatureSerial = new Serial(); // TODO: 初始化为适当的值
            BaseCreature addCreature = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AddFriend( creatureSerial, addCreature );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }
    }
}
