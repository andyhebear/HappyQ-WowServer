using Demo.Mmose.Core.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Map;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.GameObject;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Character;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MmorpgWorldTest 的测试类，旨在
    ///包含所有 MmorpgWorldTest 单元测试
    ///</summary>
    [TestClass()]
    public class MmorpgWorldTest
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
        ///UpdateWorldSpeed 的测试
        ///</summary>
        public void UpdateWorldSpeedTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            target.UpdateWorldSpeed = expected;
            actual = target.UpdateWorldSpeed;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void UpdateWorldSpeedTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 UpdateWorldSpeedTestHelper<MapT, ItemT, I" +
                    "temTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Ch" +
                    "aracterT>()。" );
        }

        /// <summary>
        ///MapManager 的测试
        ///</summary>
        public void MapManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            MapManager<MapT> expected = null; // TODO: 初始化为适当的值
            MapManager<MapT> actual;
            target.MapManager = expected;
            actual = target.MapManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MapManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 MapManagerTestHelper<MapT, ItemT, ItemTem" +
                    "plateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Characte" +
                    "rT>()。" );
        }

        /// <summary>
        ///ItemTemplateManager 的测试
        ///</summary>
        public void ItemTemplateManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            ItemTemplateManager<ItemTemplateT> expected = null; // TODO: 初始化为适当的值
            ItemTemplateManager<ItemTemplateT> actual;
            target.ItemTemplateManager = expected;
            actual = target.ItemTemplateManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ItemTemplateManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemTemplateManagerTestHelper<MapT, ItemT" +
                    ", ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT," +
                    " CharacterT>()。" );
        }

        /// <summary>
        ///ItemManager 的测试
        ///</summary>
        public void ItemManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            ItemManager<ItemT> expected = null; // TODO: 初始化为适当的值
            ItemManager<ItemT> actual;
            target.ItemManager = expected;
            actual = target.ItemManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void ItemManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 ItemManagerTestHelper<MapT, ItemT, ItemTe" +
                    "mplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Charact" +
                    "erT>()。" );
        }

        /// <summary>
        ///GameObjectTemplateManager 的测试
        ///</summary>
        public void GameObjectTemplateManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            GameObjectTemplateManager<GameObjectTemplateT> expected = null; // TODO: 初始化为适当的值
            GameObjectTemplateManager<GameObjectTemplateT> actual;
            target.GameObjectTemplateManager = expected;
            actual = target.GameObjectTemplateManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GameObjectTemplateManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectTemplateManagerTestHelper<MapT," +
                    " ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemp" +
                    "lateT, CharacterT>()。" );
        }

        /// <summary>
        ///GameObjectManager 的测试
        ///</summary>
        public void GameObjectManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            GameObjectManager<GameObjectT> expected = null; // TODO: 初始化为适当的值
            GameObjectManager<GameObjectT> actual;
            target.GameObjectManager = expected;
            actual = target.GameObjectManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GameObjectManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 GameObjectManagerTestHelper<MapT, ItemT, " +
                    "ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, C" +
                    "haracterT>()。" );
        }

        /// <summary>
        ///CreatureTemplateManager 的测试
        ///</summary>
        public void CreatureTemplateManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            CreatureTemplateManager<CreatureTemplateT> expected = null; // TODO: 初始化为适当的值
            CreatureTemplateManager<CreatureTemplateT> actual;
            target.CreatureTemplateManager = expected;
            actual = target.CreatureTemplateManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CreatureTemplateManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureTemplateManagerTestHelper<MapT, I" +
                    "temT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTempla" +
                    "teT, CharacterT>()。" );
        }

        /// <summary>
        ///CreatureManager 的测试
        ///</summary>
        public void CreatureManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            CreatureManager<CreatureT> expected = null; // TODO: 初始化为适当的值
            CreatureManager<CreatureT> actual;
            target.CreatureManager = expected;
            actual = target.CreatureManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CreatureManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 CreatureManagerTestHelper<MapT, ItemT, It" +
                    "emTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Cha" +
                    "racterT>()。" );
        }

        /// <summary>
        ///CharacterManager 的测试
        ///</summary>
        public void CharacterManagerTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            CharacterManager<CharacterT> expected = null; // TODO: 初始化为适当的值
            CharacterManager<CharacterT> actual;
            target.CharacterManager = expected;
            actual = target.CharacterManager;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CharacterManagerTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 CharacterManagerTestHelper<MapT, ItemT, I" +
                    "temTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Ch" +
                    "aracterT>()。" );
        }

        /// <summary>
        ///StartUpdateWorld 的测试
        ///</summary>
        public void StartUpdateWorldTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            TimeSpan updateWorldSpeed = new TimeSpan(); // TODO: 初始化为适当的值
            target.StartUpdateWorld( updateWorldSpeed );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void StartUpdateWorldTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 StartUpdateWorldTestHelper<MapT, ItemT, I" +
                    "temTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Ch" +
                    "aracterT>()。" );
        }

        /// <summary>
        ///StartSlice 的测试
        ///</summary>
        public void StartSliceTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            BaseWorldEventArgs eventArgs = null; // TODO: 初始化为适当的值
            target.StartSlice( sender, eventArgs );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void StartSliceTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 StartSliceTestHelper<MapT, ItemT, ItemTem" +
                    "plateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Characte" +
                    "rT>()。" );
        }

        /// <summary>
        ///OnUpdateWorld 的测试
        ///</summary>
        public void OnUpdateWorldTestHelper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld_Accessor<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>(); // TODO: 初始化为适当的值
            target.OnUpdateWorld();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnUpdateWorldTest()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 OnUpdateWorldTestHelper<MapT, ItemT, Item" +
                    "TemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, Chara" +
                    "cterT>()。" );
        }

        /// <summary>
        ///MmorpgWorld`8 构造函数 的测试
        ///</summary>
        public void MmorpgWorldConstructorTest1Helper<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>()
            where MapT : BaseMap
            where ItemT : BaseItem
            where ItemTemplateT : BaseItemTemplate
            where GameObjectT : BaseGameObject
            where GameObjectTemplateT : BaseGameObjectTemplate
            where CreatureT : BaseCreature
            where CreatureTemplateT : BaseCreatureTemplate
            where CharacterT : BaseCharacter
        {
            MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT> target = new MmorpgWorld<MapT, ItemT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTemplateT, CharacterT>();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        [TestMethod()]
        public void MmorpgWorldConstructorTest1()
        {
            Assert.Inconclusive( "没有找到能够满足 MapT 的类型约束的相应类型参数。请以适当的类型参数来调用 MmorpgWorldConstructorTest1Helper<MapT, I" +
                    "temT, ItemTemplateT, GameObjectT, GameObjectTemplateT, CreatureT, CreatureTempla" +
                    "teT, CharacterT>()。" );
        }

        /// <summary>
        ///MmorpgWorld 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MmorpgWorldConstructorTest()
        {
            MmorpgWorld target = new MmorpgWorld();
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
