using Demo.Mmose.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Character;
using System.Collections.Generic;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 VisibleRangeTest 的测试类，旨在
    ///包含所有 VisibleRangeTest 单元测试
    ///</summary>
    [TestClass()]
    public class VisibleRangeTest
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
        ///Range 的测试
        ///</summary>
        public void RangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.Range = expected;
            actual = target.Range;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void RangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 RangeTestHelper<EntityT, ItemT, Creatu" +
                    "reT, CharacterT>()。" );
        }

        /// <summary>
        ///ItemOutOfRange 的测试
        ///</summary>
        public void ItemOutOfRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            ItemT[] expected = null; // TODO: 初始化为适当的值
            ItemT[] actual;
            target.ItemOutOfRange = expected;
            actual = target.ItemOutOfRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ItemOutOfRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemOutOfRangeTestHelper<EntityT, Item" +
                    "T, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///ItemOriginalInRange 的测试
        ///</summary>
        public void ItemOriginalInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            ItemT[] expected = null; // TODO: 初始化为适当的值
            ItemT[] actual;
            target.ItemOriginalInRange = expected;
            actual = target.ItemOriginalInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ItemOriginalInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemOriginalInRangeTestHelper<EntityT," +
                    " ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///ItemInRange 的测试
        ///</summary>
        public void ItemInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            ItemT[] expected = null; // TODO: 初始化为适当的值
            ItemT[] actual;
            target.ItemInRange = expected;
            actual = target.ItemInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void ItemInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemInRangeTestHelper<EntityT, ItemT, " +
                    "CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///EntityOutOfRange 的测试
        ///</summary>
        public void EntityOutOfRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            EntityT[] expected = null; // TODO: 初始化为适当的值
            EntityT[] actual;
            target.EntityOutOfRange = expected;
            actual = target.EntityOutOfRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void EntityOutOfRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 EntityOutOfRangeTestHelper<EntityT, It" +
                    "emT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///EntityOriginalInRange 的测试
        ///</summary>
        public void EntityOriginalInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            EntityT[] expected = null; // TODO: 初始化为适当的值
            EntityT[] actual;
            target.EntityOriginalInRange = expected;
            actual = target.EntityOriginalInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void EntityOriginalInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 EntityOriginalInRangeTestHelper<Entity" +
                    "T, ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///EntityInRange 的测试
        ///</summary>
        public void EntityInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            EntityT[] expected = null; // TODO: 初始化为适当的值
            EntityT[] actual;
            target.EntityInRange = expected;
            actual = target.EntityInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void EntityInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 EntityInRangeTestHelper<EntityT, ItemT" +
                    ", CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CreatureOutOfRange 的测试
        ///</summary>
        public void CreatureOutOfRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CreatureT[] expected = null; // TODO: 初始化为适当的值
            CreatureT[] actual;
            target.CreatureOutOfRange = expected;
            actual = target.CreatureOutOfRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CreatureOutOfRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureOutOfRangeTestHelper<EntityT, " +
                    "ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CreatureOriginalInRange 的测试
        ///</summary>
        public void CreatureOriginalInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CreatureT[] expected = null; // TODO: 初始化为适当的值
            CreatureT[] actual;
            target.CreatureOriginalInRange = expected;
            actual = target.CreatureOriginalInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CreatureOriginalInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureOriginalInRangeTestHelper<Enti" +
                    "tyT, ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CreatureInRange 的测试
        ///</summary>
        public void CreatureInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CreatureT[] expected = null; // TODO: 初始化为适当的值
            CreatureT[] actual;
            target.CreatureInRange = expected;
            actual = target.CreatureInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CreatureInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureInRangeTestHelper<EntityT, Ite" +
                    "mT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CharacterOutOfRange 的测试
        ///</summary>
        public void CharacterOutOfRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CharacterT[] expected = null; // TODO: 初始化为适当的值
            CharacterT[] actual;
            target.CharacterOutOfRange = expected;
            actual = target.CharacterOutOfRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CharacterOutOfRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CharacterOutOfRangeTestHelper<EntityT," +
                    " ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CharacterOriginalInRange 的测试
        ///</summary>
        public void CharacterOriginalInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CharacterT[] expected = null; // TODO: 初始化为适当的值
            CharacterT[] actual;
            target.CharacterOriginalInRange = expected;
            actual = target.CharacterOriginalInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CharacterOriginalInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CharacterOriginalInRangeTestHelper<Ent" +
                    "ityT, ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///CharacterInRange 的测试
        ///</summary>
        public void CharacterInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            CharacterT[] expected = null; // TODO: 初始化为适当的值
            CharacterT[] actual;
            target.CharacterInRange = expected;
            actual = target.CharacterInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void CharacterInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 CharacterInRangeTestHelper<EntityT, It" +
                    "emT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///AllEntityOutOfRange 的测试
        ///</summary>
        public void AllEntityOutOfRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            WorldEntity[] expected = null; // TODO: 初始化为适当的值
            WorldEntity[] actual;
            target.AllEntityOutOfRange = expected;
            actual = target.AllEntityOutOfRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AllEntityOutOfRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 AllEntityOutOfRangeTestHelper<EntityT," +
                    " ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///AllEntityOriginalInRange 的测试
        ///</summary>
        public void AllEntityOriginalInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            WorldEntity[] expected = null; // TODO: 初始化为适当的值
            WorldEntity[] actual;
            target.AllEntityOriginalInRange = expected;
            actual = target.AllEntityOriginalInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AllEntityOriginalInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 AllEntityOriginalInRangeTestHelper<Ent" +
                    "ityT, ItemT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///AllEntityInRange 的测试
        ///</summary>
        public void AllEntityInRangeTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>(); // TODO: 初始化为适当的值
            WorldEntity[] expected = null; // TODO: 初始化为适当的值
            WorldEntity[] actual;
            target.AllEntityInRange = expected;
            actual = target.AllEntityInRange;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void AllEntityInRangeTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 AllEntityInRangeTestHelper<EntityT, It" +
                    "emT, CreatureT, CharacterT>()。" );
        }

        /// <summary>
        ///EnumerableToArray 的测试
        ///</summary>
        public void EnumerableToArrayTestHelper<EntityT, ItemT, CreatureT, CharacterT, T>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            IEnumerable<T> enumerable = null; // TODO: 初始化为适当的值
            T[] expected = null; // TODO: 初始化为适当的值
            T[] actual;
            actual = VisibleRange<EntityT, ItemT, CreatureT, CharacterT>.EnumerableToArray<T>( enumerable );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void EnumerableToArrayTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 EnumerableToArrayTestHelper<EntityT, I" +
                    "temT, CreatureT, CharacterT, T>()。" );
        }

        /// <summary>
        ///VisibleRange`4 构造函数 的测试
        ///</summary>
        public void VisibleRangeConstructorTestHelper<EntityT, ItemT, CreatureT, CharacterT>()
            where EntityT : WorldEntity
            where ItemT : BaseItem
            where CreatureT : BaseCreature
            where CharacterT : BaseCharacter
        {
            VisibleRange<EntityT, ItemT, CreatureT, CharacterT> target = new VisibleRange<EntityT, ItemT, CreatureT, CharacterT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void VisibleRangeConstructorTest()
        {
            Assert.Inconclusive( "没有找到能够满足 EntityT 的类型约束的相应类型参数。请以适当的类型参数来调用 VisibleRangeConstructorTestHelper<Enti" +
                    "tyT, ItemT, CreatureT, CharacterT>()。" );
        }
    }
}
