using Demo.Mmose.Core.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Common;
using Demo.Mmose.Core.Common.Component;
using Demo.Mmose.Core.Entity;
using Demo.Mmose.Core.Entity.Item;
using Demo.Mmose.Core.Entity.Character;
using Demo.Mmose.Core.Entity.Creature;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 MapSpaceNodeTest 的测试类，旨在
    ///包含所有 MapSpaceNodeTest 单元测试
    ///</summary>
    [TestClass()]
    public class MapSpaceNodeTest
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
        ///SpaceNodeState 的测试
        ///</summary>
        [TestMethod()]
        public void SpaceNodeStateTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            SpaceNodeState actual;
            actual = target.SpaceNodeState;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SpaceNodes 的测试
        ///</summary>
        [TestMethod()]
        public void SpaceNodesTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            MapSpaceNode[, ,] actual;
            actual = target.SpaceNodes;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SpaceNodeRectangle 的测试
        ///</summary>
        [TestMethod()]
        public void SpaceNodeRectangleTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            Rectangle3D expected = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D actual;
            target.SpaceNodeRectangle = expected;
            actual = target.SpaceNodeRectangle;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///RankIndex 的测试
        ///</summary>
        [TestMethod()]
        public void RankIndexTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            RankIndex expected = new RankIndex(); // TODO: 初始化为适当的值
            RankIndex actual;
            target.RankIndex = expected;
            actual = target.RankIndex;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///PlayersCount 的测试
        ///</summary>
        [TestMethod()]
        public void PlayersCountTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            long actual;
            actual = target.PlayersCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Parent 的测试
        ///</summary>
        [TestMethod()]
        public void ParentTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            MapSpaceNode expected = null; // TODO: 初始化为适当的值
            MapSpaceNode actual;
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
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseMap expected = null; // TODO: 初始化为适当的值
            BaseMap actual;
            target.Owner = expected;
            actual = target.Owner;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///MapSpaceNodeState 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void MapSpaceNodeStateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            MapSpaceNode_Accessor target = new MapSpaceNode_Accessor( param0 ); // TODO: 初始化为适当的值
            MapSpaceNodeState expected = null; // TODO: 初始化为适当的值
            MapSpaceNodeState actual;
            target.MapSpaceNodeState = expected;
            actual = target.MapSpaceNodeState;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///LayerIndex 的测试
        ///</summary>
        [TestMethod()]
        public void LayerIndexTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            uint actual;
            actual = target.LayerIndex;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ItemsCount 的测试
        ///</summary>
        [TestMethod()]
        public void ItemsCountTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            long actual;
            actual = target.ItemsCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsLeaf 的测试
        ///</summary>
        [TestMethod()]
        public void IsLeafTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsLeaf = expected;
            actual = target.IsLeaf;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///EntitysCount 的测试
        ///</summary>
        [TestMethod()]
        public void EntitysCountTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            long actual;
            actual = target.EntitysCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CreaturesCount 的测试
        ///</summary>
        [TestMethod()]
        public void CreaturesCountTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            long actual;
            actual = target.CreaturesCount;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInPlayers 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInPlayersTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCharacter[] expected = null; // TODO: 初始化为适当的值
            BaseCharacter[] actual;
            actual = target.ToArrayInPlayers();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInItems 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInItemsTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseItem[] expected = null; // TODO: 初始化为适当的值
            BaseItem[] actual;
            actual = target.ToArrayInItems();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInEntitys 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInEntitysTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            WorldEntity[] expected = null; // TODO: 初始化为适当的值
            WorldEntity[] actual;
            actual = target.ToArrayInEntitys();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ToArrayInCreatures 的测试
        ///</summary>
        [TestMethod()]
        public void ToArrayInCreaturesTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCreature[] expected = null; // TODO: 初始化为适当的值
            BaseCreature[] actual;
            actual = target.ToArrayInCreatures();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SubScribeComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SubScribeComponentMessageTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.SubScribeComponentMessage( componentId, componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///RegisterComponent 的测试
        ///</summary>
        public void RegisterComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T component = null; // TODO: 初始化为适当的值
            target.RegisterComponent<T>( componentId, component );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        [TestMethod()]
        public void RegisterComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 RegisterComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///ProcessPartitionSpace 的测试
        ///</summary>
        [TestMethod()]
        public void ProcessPartitionSpaceTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            IPartitionSpaceNode partitionSpaceInterface = null; // TODO: 初始化为适当的值
            target.ProcessPartitionSpace( partitionSpaceInterface );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///PostComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void PostComponentMessageTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.PostComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest3()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnLeave( item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest2()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnLeave( creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest1()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            target.OnLeave( character );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLeave 的测试
        ///</summary>
        [TestMethod()]
        public void OnLeaveTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            target.OnLeave( entity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnHandleComponentMessage 的测试
        ///</summary>
        [TestMethod()]
        public void OnHandleComponentMessageTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            ComponentMessage componentMessage = new ComponentMessage(); // TODO: 初始化为适当的值
            target.OnHandleComponentMessage( componentMessage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest3()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCreature creature = null; // TODO: 初始化为适当的值
            target.OnEnter( creature );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest2()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseCharacter character = null; // TODO: 初始化为适当的值
            target.OnEnter( character );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest1()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            target.OnEnter( item );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            WorldEntity entity = null; // TODO: 初始化为适当的值
            target.OnEnter( entity );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDeactivate 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnDeactivateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            MapSpaceNode_Accessor target = new MapSpaceNode_Accessor( param0 ); // TODO: 初始化为适当的值
            target.OnDeactivate();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnActivate 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void OnActivateTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            MapSpaceNode_Accessor target = new MapSpaceNode_Accessor( param0 ); // TODO: 初始化为适当的值
            target.OnActivate();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///GetComponent 的测试
        ///</summary>
        public void GetComponentTestHelper<T>()
            where T : class, IComponent
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner ); // TODO: 初始化为适当的值
            ComponentId componentId = new ComponentId(); // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.GetComponent<T>( componentId );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        [TestMethod()]
        public void GetComponentTest()
        {
            Assert.Inconclusive( "没有找到能够满足 T 的类型约束的相应类型参数。请以适当的类型参数来调用 GetComponentTestHelper<T>()。" );
        }

        /// <summary>
        ///MapSpaceNode 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MapSpaceNodeConstructorTest1()
        {
            Rectangle3D partitionSpaceRectangle = new Rectangle3D(); // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( partitionSpaceRectangle );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///MapSpaceNode 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void MapSpaceNodeConstructorTest()
        {
            BaseMap owner = null; // TODO: 初始化为适当的值
            MapSpaceNode target = new MapSpaceNode( owner );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
