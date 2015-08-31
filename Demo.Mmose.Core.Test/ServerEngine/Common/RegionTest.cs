using Demo.Mmose.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Mmose.Core.Map;
using System.Xml;
using Demo.Mmose.Core.Entity.Creature;
using Demo.Mmose.Core.Entity.Item;
using System.Collections.Generic;
using System;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 RegionTest 的测试类，旨在
    ///包含所有 RegionTest 单元测试
    ///</summary>
    [TestClass()]
    public class RegionTest
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
        ///StaffLogoutDelay 的测试
        ///</summary>
        [TestMethod()]
        public void StaffLogoutDelayTest()
        {
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            Region.StaffLogoutDelay = expected;
            actual = Region.StaffLogoutDelay;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Sectors 的测试
        ///</summary>
        [TestMethod()]
        public void SectorsTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            MapSpaceNode[] actual;
            actual = target.Sectors;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Registered 的测试
        ///</summary>
        [TestMethod()]
        public void RegisteredTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Registered;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Regions 的测试
        ///</summary>
        [TestMethod()]
        public void RegionsTest()
        {
            List<Region> actual;
            actual = Region.Regions;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Priority 的测试
        ///</summary>
        [TestMethod()]
        public void PriorityTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            long actual;
            actual = target.Priority;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Parent 的测试
        ///</summary>
        [TestMethod()]
        public void ParentTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region actual;
            actual = target.Parent;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            string actual;
            actual = target.Name;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Map 的测试
        ///</summary>
        [TestMethod()]
        public void MapTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseMap actual;
            actual = target.Map;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GoLocation 的测试
        ///</summary>
        [TestMethod()]
        public void GoLocationTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Point3D expected = new Point3D(); // TODO: 初始化为适当的值
            Point3D actual;
            target.GoLocation = expected;
            actual = target.GoLocation;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Dynamic 的测试
        ///</summary>
        [TestMethod()]
        public void DynamicTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            bool actual;
            actual = target.Dynamic;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DefaultRegionType 的测试
        ///</summary>
        [TestMethod()]
        public void DefaultRegionTypeTest()
        {
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            Region.DefaultRegionType = expected;
            actual = Region.DefaultRegionType;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///DefaultLogoutDelay 的测试
        ///</summary>
        [TestMethod()]
        public void DefaultLogoutDelayTest()
        {
            TimeSpan expected = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan actual;
            Region.DefaultLogoutDelay = expected;
            actual = Region.DefaultLogoutDelay;
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Children 的测试
        ///</summary>
        [TestMethod()]
        public void ChildrenTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            List<Region> actual;
            actual = target.Children;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ChildLevel 的测试
        ///</summary>
        [TestMethod()]
        public void ChildLevelTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            long actual;
            actual = target.ChildLevel;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Area 的测试
        ///</summary>
        [TestMethod()]
        public void AreaTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Rectangle3D[] actual;
            actual = target.Area;
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Unregister 的测试
        ///</summary>
        [TestMethod()]
        public void UnregisterTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            target.Unregister();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ToString 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.ToString();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///System.IComparable.CompareTo 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void CompareToTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            IComparable target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            object obj = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.CompareTo( obj );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///SpellDamageScalar 的测试
        ///</summary>
        [TestMethod()]
        public void SpellDamageScalarTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature caster = null; // TODO: 初始化为适当的值
            BaseCreature target1 = null; // TODO: 初始化为适当的值
            double damage = 0F; // TODO: 初始化为适当的值
            double damageExpected = 0F; // TODO: 初始化为适当的值
            target.SpellDamageScalar( caster, target1, ref damage );
            Assert.AreEqual( damageExpected, damage );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///SendInaccessibleMessage 的测试
        ///</summary>
        [TestMethod()]
        public void SendInaccessibleMessageTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseCreature from = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.SendInaccessibleMessage( item, from );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Register 的测试
        ///</summary>
        [TestMethod()]
        public void RegisterTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            target.Register();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///ReadType 的测试
        ///</summary>
        [TestMethod()]
        public void ReadTypeTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            Type value = null; // TODO: 初始化为适当的值
            Type valueExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadType( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadType 的测试
        ///</summary>
        [TestMethod()]
        public void ReadTypeTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            Type value = null; // TODO: 初始化为适当的值
            Type valueExpected = null; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadType( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadTimeSpan 的测试
        ///</summary>
        [TestMethod()]
        public void ReadTimeSpanTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            TimeSpan value = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan valueExpected = new TimeSpan(); // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadTimeSpan( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadTimeSpan 的测试
        ///</summary>
        [TestMethod()]
        public void ReadTimeSpanTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            TimeSpan value = new TimeSpan(); // TODO: 初始化为适当的值
            TimeSpan valueExpected = new TimeSpan(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadTimeSpan( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            string value = string.Empty; // TODO: 初始化为适当的值
            string valueExpected = string.Empty; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadString( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadString 的测试
        ///</summary>
        [TestMethod()]
        public void ReadStringTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            string value = string.Empty; // TODO: 初始化为适当的值
            string valueExpected = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadString( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadRectangle3D 的测试
        ///</summary>
        [TestMethod()]
        public void ReadRectangle3DTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            long defaultMinZ = 0; // TODO: 初始化为适当的值
            long defaultMaxZ = 0; // TODO: 初始化为适当的值
            Rectangle3D value = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D valueExpected = new Rectangle3D(); // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadRectangle3D( xml, defaultMinZ, defaultMaxZ, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadRectangle3D 的测试
        ///</summary>
        [TestMethod()]
        public void ReadRectangle3DTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            long defaultMinZ = 0; // TODO: 初始化为适当的值
            long defaultMaxZ = 0; // TODO: 初始化为适当的值
            Rectangle3D value = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D valueExpected = new Rectangle3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadRectangle3D( xml, defaultMinZ, defaultMaxZ, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadPoint3D 的测试
        ///</summary>
        [TestMethod()]
        public void ReadPoint3DTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Point3D value = new Point3D(); // TODO: 初始化为适当的值
            Point3D valueExpected = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadPoint3D( xml, map, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadPoint3D 的测试
        ///</summary>
        [TestMethod()]
        public void ReadPoint3DTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Point3D value = new Point3D(); // TODO: 初始化为适当的值
            Point3D valueExpected = new Point3D(); // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadPoint3D( xml, map, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadMap 的测试
        ///</summary>
        [TestMethod()]
        public void ReadMapTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            BaseMap value = null; // TODO: 初始化为适当的值
            BaseMap valueExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadMap( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadMap 的测试
        ///</summary>
        [TestMethod()]
        public void ReadMapTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            BaseMap value = null; // TODO: 初始化为适当的值
            BaseMap valueExpected = null; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadMap( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ReadInt32Test1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            long value = 0; // TODO: 初始化为适当的值
            long valueExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadInt32( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ReadInt32Test()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            long value = 0; // TODO: 初始化为适当的值
            long valueExpected = 0; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadInt32( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadEnum 的测试
        ///</summary>
        [TestMethod()]
        public void ReadEnumTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            object value = null; // TODO: 初始化为适当的值
            object valueExpected = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadEnum( xml, attribute, type, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadEnum 的测试
        ///</summary>
        [TestMethod()]
        public void ReadEnumTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            object value = null; // TODO: 初始化为适当的值
            object valueExpected = null; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadEnum( xml, attribute, type, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadDateTime 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDateTimeTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            DateTime value = new DateTime(); // TODO: 初始化为适当的值
            DateTime valueExpected = new DateTime(); // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadDateTime( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadDateTime 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDateTimeTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            DateTime value = new DateTime(); // TODO: 初始化为适当的值
            DateTime valueExpected = new DateTime(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadDateTime( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadBoolean 的测试
        ///</summary>
        [TestMethod()]
        public void ReadBooleanTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            bool value = false; // TODO: 初始化为适当的值
            bool valueExpected = false; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadBoolean( xml, attribute, ref value, mandatory );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ReadBoolean 的测试
        ///</summary>
        [TestMethod()]
        public void ReadBooleanTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            bool value = false; // TODO: 初始化为适当的值
            bool valueExpected = false; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = Region.ReadBoolean( xml, attribute, ref value );
            Assert.AreEqual( valueExpected, value );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnUnregister 的测试
        ///</summary>
        [TestMethod()]
        public void OnUnregisterTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            target.OnUnregister();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnSpellCast 的测试
        ///</summary>
        [TestMethod()]
        public void OnSpellCastTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            ISpell s = null; // TODO: 初始化为适当的值
            target.OnSpellCast( m, s );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnSkillUse 的测试
        ///</summary>
        [TestMethod()]
        public void OnSkillUseTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            int Skill = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnSkillUse( m, Skill );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnSingleClick 的测试
        ///</summary>
        [TestMethod()]
        public void OnSingleClickTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            object o = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnSingleClick( m, o );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnResurrect 的测试
        ///</summary>
        [TestMethod()]
        public void OnResurrectTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnResurrect( m );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnRegister 的测试
        ///</summary>
        [TestMethod()]
        public void OnRegisterTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            target.OnRegister();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnRegionChange 的测试
        ///</summary>
        [TestMethod()]
        public void OnRegionChangeTest()
        {
            BaseCreature m = null; // TODO: 初始化为适当的值
            Region oldRegion = null; // TODO: 初始化为适当的值
            Region newRegion = null; // TODO: 初始化为适当的值
            Region.OnRegionChange( m, oldRegion, newRegion );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnLocationChanged 的测试
        ///</summary>
        [TestMethod()]
        public void OnLocationChangedTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            Point3D oldLocation = new Point3D(); // TODO: 初始化为适当的值
            target.OnLocationChanged( m, oldLocation );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnHeal 的测试
        ///</summary>
        [TestMethod()]
        public void OnHealTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            int Heal = 0; // TODO: 初始化为适当的值
            int HealExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnHeal( m, ref Heal );
            Assert.AreEqual( HealExpected, Heal );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnGotHarmful 的测试
        ///</summary>
        [TestMethod()]
        public void OnGotHarmfulTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature harmer = null; // TODO: 初始化为适当的值
            BaseCreature harmed = null; // TODO: 初始化为适当的值
            target.OnGotHarmful( harmer, harmed );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnGotBeneficialAction 的测试
        ///</summary>
        [TestMethod()]
        public void OnGotBeneficialActionTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature helper = null; // TODO: 初始化为适当的值
            BaseCreature target1 = null; // TODO: 初始化为适当的值
            target.OnGotBeneficialAction( helper, target1 );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnExit 的测试
        ///</summary>
        [TestMethod()]
        public void OnExitTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature baseMobile = null; // TODO: 初始化为适当的值
            target.OnExit( baseMobile );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnEnter 的测试
        ///</summary>
        [TestMethod()]
        public void OnEnterTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature baseMobile = null; // TODO: 初始化为适当的值
            target.OnEnter( baseMobile );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDoubleClick 的测试
        ///</summary>
        [TestMethod()]
        public void OnDoubleClickTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            object o = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnDoubleClick( m, o );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnDidHarmful 的测试
        ///</summary>
        [TestMethod()]
        public void OnDidHarmfulTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature harmer = null; // TODO: 初始化为适当的值
            BaseCreature harmed = null; // TODO: 初始化为适当的值
            target.OnDidHarmful( harmer, harmed );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnDecay 的测试
        ///</summary>
        [TestMethod()]
        public void OnDecayTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnDecay( item );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnDeath 的测试
        ///</summary>
        [TestMethod()]
        public void OnDeathTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnDeath( m );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnDamage 的测试
        ///</summary>
        [TestMethod()]
        public void OnDamageTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            int Damage = 0; // TODO: 初始化为适当的值
            int DamageExpected = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnDamage( m, ref Damage );
            Assert.AreEqual( DamageExpected, Damage );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnCriminalAction 的测试
        ///</summary>
        [TestMethod()]
        public void OnCriminalActionTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            bool message = false; // TODO: 初始化为适当的值
            target.OnCriminalAction( m, message );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnCombatantChange 的测试
        ///</summary>
        [TestMethod()]
        public void OnCombatantChangeTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            BaseCreature Old = null; // TODO: 初始化为适当的值
            BaseCreature New = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnCombatantChange( m, Old, New );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnChildRemoved 的测试
        ///</summary>
        [TestMethod()]
        public void OnChildRemovedTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region childRegion = null; // TODO: 初始化为适当的值
            target.OnChildRemoved( childRegion );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnChildAdded 的测试
        ///</summary>
        [TestMethod()]
        public void OnChildAddedTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region childRegion = null; // TODO: 初始化为适当的值
            target.OnChildAdded( childRegion );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnBeneficialAction 的测试
        ///</summary>
        [TestMethod()]
        public void OnBeneficialActionTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature helper = null; // TODO: 初始化为适当的值
            BaseCreature target1 = null; // TODO: 初始化为适当的值
            target.OnBeneficialAction( helper, target1 );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///OnBeginSpellCast 的测试
        ///</summary>
        [TestMethod()]
        public void OnBeginSpellCastTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            ISpell s = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.OnBeginSpellCast( m, s );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///OnAggressed 的测试
        ///</summary>
        [TestMethod()]
        public void OnAggressedTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature aggressor = null; // TODO: 初始化为适当的值
            BaseCreature aggressed = null; // TODO: 初始化为适当的值
            bool criminal = false; // TODO: 初始化为适当的值
            target.OnAggressed( aggressor, aggressed, criminal );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///MakeGuard 的测试
        ///</summary>
        [TestMethod()]
        public void MakeGuardTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature focusMobile = null; // TODO: 初始化为适当的值
            target.MakeGuard( focusMobile );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///LoadRegions 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void LoadRegionsTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region_Accessor parent = null; // TODO: 初始化为适当的值
            Region_Accessor.LoadRegions( xml, map, parent );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///Load 的测试
        ///</summary>
        [TestMethod()]
        public void LoadTest()
        {
            Region.Load();
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///IsPartOf 的测试
        ///</summary>
        [TestMethod()]
        public void IsPartOfTest2()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            string regionName = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsPartOf( regionName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsPartOf 的测试
        ///</summary>
        [TestMethod()]
        public void IsPartOfTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region region = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsPartOf( region );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsPartOf 的测试
        ///</summary>
        [TestMethod()]
        public void IsPartOfTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Type regionType = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsPartOf( regionType );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///IsChildOf 的测试
        ///</summary>
        [TestMethod()]
        public void IsChildOfTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region region = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsChildOf( region );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetResource 的测试
        ///</summary>
        [TestMethod()]
        public void GetResourceTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            Type expected = null; // TODO: 初始化为适当的值
            Type actual;
            actual = target.GetResource( type );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetRegion 的测试
        ///</summary>
        [TestMethod()]
        public void GetRegionTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Type regionType = null; // TODO: 初始化为适当的值
            Region expected = null; // TODO: 初始化为适当的值
            Region actual;
            actual = target.GetRegion( regionType );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetRegion 的测试
        ///</summary>
        [TestMethod()]
        public void GetRegionTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            string regionName = string.Empty; // TODO: 初始化为适当的值
            Region expected = null; // TODO: 初始化为适当的值
            Region actual;
            actual = target.GetRegion( regionName );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPlayers 的测试
        ///</summary>
        [TestMethod()]
        public void GetPlayersTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            List<BaseCreature> expected = null; // TODO: 初始化为适当的值
            List<BaseCreature> actual;
            actual = target.GetPlayers();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPlayerCount 的测试
        ///</summary>
        [TestMethod()]
        public void GetPlayerCountTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetPlayerCount();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetMobiles 的测试
        ///</summary>
        [TestMethod()]
        public void GetMobilesTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            List<BaseCreature> expected = null; // TODO: 初始化为适当的值
            List<BaseCreature> actual;
            actual = target.GetMobiles();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetMobileCount 的测试
        ///</summary>
        [TestMethod()]
        public void GetMobileCountTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetMobileCount();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetAttribute 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void GetAttributeTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            string attribute = string.Empty; // TODO: 初始化为适当的值
            bool mandatory = false; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Region_Accessor.GetAttribute( xml, attribute, mandatory );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertTo3D 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertTo3DTest1()
        {
            Rectangle2D rectangle2D = new Rectangle2D(); // TODO: 初始化为适当的值
            Rectangle3D expected = new Rectangle3D(); // TODO: 初始化为适当的值
            Rectangle3D actual;
            actual = Region.ConvertTo3D( rectangle2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///ConvertTo3D 的测试
        ///</summary>
        [TestMethod()]
        public void ConvertTo3DTest()
        {
            Rectangle2D[] rectangle2D = null; // TODO: 初始化为适当的值
            Rectangle3D[] expected = null; // TODO: 初始化为适当的值
            Rectangle3D[] actual;
            actual = Region.ConvertTo3D( rectangle2D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Contains 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Point3D point3D = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.Contains( point3D );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CheckAccessibility 的测试
        ///</summary>
        [TestMethod()]
        public void CheckAccessibilityTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseItem item = null; // TODO: 初始化为适当的值
            BaseCreature from = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CheckAccessibility( item, from );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///CanUseStuckMenu 的测试
        ///</summary>
        [TestMethod()]
        public void CanUseStuckMenuTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature baseMobile = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.CanUseStuckMenu( baseMobile );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AlterLightLevel 的测试
        ///</summary>
        [TestMethod()]
        public void AlterLightLevelTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature m = null; // TODO: 初始化为适当的值
            int global = 0; // TODO: 初始化为适当的值
            int globalExpected = 0; // TODO: 初始化为适当的值
            int personal = 0; // TODO: 初始化为适当的值
            int personalExpected = 0; // TODO: 初始化为适当的值
            target.AlterLightLevel( m, ref global, ref personal );
            Assert.AreEqual( globalExpected, global );
            Assert.AreEqual( personalExpected, personal );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///AllowSpawn 的测试
        ///</summary>
        [TestMethod()]
        public void AllowSpawnTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AllowSpawn();
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AllowHousing 的测试
        ///</summary>
        [TestMethod()]
        public void AllowHousingTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature from = null; // TODO: 初始化为适当的值
            Point3D p = new Point3D(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AllowHousing( from, p );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AllowHarmful 的测试
        ///</summary>
        [TestMethod()]
        public void AllowHarmfulTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature from = null; // TODO: 初始化为适当的值
            BaseCreature target1 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AllowHarmful( from, target1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AllowBeneficial 的测试
        ///</summary>
        [TestMethod()]
        public void AllowBeneficialTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            BaseCreature from = null; // TODO: 初始化为适当的值
            BaseCreature target1 = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AllowBeneficial( from, target1 );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///AcceptsSpawnsFrom 的测试
        ///</summary>
        [TestMethod()]
        public void AcceptsSpawnsFromTest()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent ); // TODO: 初始化为适当的值
            Region region = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.AcceptsSpawnsFrom( region );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///Region 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionConstructorTest4()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseMap baseMap = null; // TODO: 初始化为适当的值
            int iPriority = 0; // TODO: 初始化为适当的值
            Rectangle3D[] area = null; // TODO: 初始化为适当的值
            Region target = new Region( strName, baseMap, iPriority, area );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Region 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionConstructorTest3()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseMap baseMap = null; // TODO: 初始化为适当的值
            int iPriority = 0; // TODO: 初始化为适当的值
            Rectangle2D[] area = null; // TODO: 初始化为适当的值
            Region target = new Region( strName, baseMap, iPriority, area );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Region 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionConstructorTest2()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseMap baseMap = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Rectangle2D[] area = null; // TODO: 初始化为适当的值
            Region target = new Region( strName, baseMap, parent, area );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Region 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionConstructorTest1()
        {
            XmlElement xml = null; // TODO: 初始化为适当的值
            BaseMap map = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Region target = new Region( xml, map, parent );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }

        /// <summary>
        ///Region 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void RegionConstructorTest()
        {
            string strName = string.Empty; // TODO: 初始化为适当的值
            BaseMap baseMap = null; // TODO: 初始化为适当的值
            Region parent = null; // TODO: 初始化为适当的值
            Rectangle3D[] area = null; // TODO: 初始化为适当的值
            Region target = new Region( strName, baseMap, parent, area );
            Assert.Inconclusive( "TODO: 实现用来验证目标的代码" );
        }
    }
}
