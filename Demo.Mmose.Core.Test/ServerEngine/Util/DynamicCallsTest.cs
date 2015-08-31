using Demo.Mmose.Core.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.Emit;
using System;
using System.Reflection;

namespace Demo.Mmose.Core.Test
{
    /// <summary>
    ///这是 DynamicCallsTest 的测试类，旨在
    ///包含所有 DynamicCallsTest 单元测试
    ///</summary>
    [TestClass()]
    public class DynamicCallsTest
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
        ///GetPropertySetter 的测试
        ///</summary>
        [TestMethod()]
        public void GetPropertySetterTest()
        {
            PropertyInfo propInfo = null; // TODO: 初始化为适当的值
            FastPropertySetHandler expected = null; // TODO: 初始化为适当的值
            FastPropertySetHandler actual;
            actual = DynamicCalls.GetPropertySetter( propInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetPropertyGetter 的测试
        ///</summary>
        [TestMethod()]
        public void GetPropertyGetterTest()
        {
            PropertyInfo propInfo = null; // TODO: 初始化为适当的值
            FastPropertyGetHandler expected = null; // TODO: 初始化为适当的值
            FastPropertyGetHandler actual;
            actual = DynamicCalls.GetPropertyGetter( propInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetMethodInvoker 的测试
        ///</summary>
        [TestMethod()]
        public void GetMethodInvokerTest()
        {
            MethodInfo methodInfo = null; // TODO: 初始化为适当的值
            FastInvokeHandler expected = null; // TODO: 初始化为适当的值
            FastInvokeHandler actual;
            actual = DynamicCalls.GetMethodInvoker( methodInfo );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///GetInstanceCreator 的测试
        ///</summary>
        [TestMethod()]
        public void GetInstanceCreatorTest()
        {
            Type type = null; // TODO: 初始化为适当的值
            FastCreateInstanceHandler expected = null; // TODO: 初始化为适当的值
            FastCreateInstanceHandler actual;
            actual = DynamicCalls.GetInstanceCreator( type );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "验证此测试方法的正确性。" );
        }

        /// <summary>
        ///EmitFastInt 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void EmitFastIntTest()
        {
            ILGenerator ilGenerator = null; // TODO: 初始化为适当的值
            int value = 0; // TODO: 初始化为适当的值
            DynamicCalls_Accessor.EmitFastInt( ilGenerator, value );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EmitCastToReference 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void EmitCastToReferenceTest()
        {
            ILGenerator ilGenerator = null; // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            DynamicCalls_Accessor.EmitCastToReference( ilGenerator, type );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }

        /// <summary>
        ///EmitBoxIfNeeded 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem( "Demo.Mmose.Core.dll" )]
        public void EmitBoxIfNeededTest()
        {
            ILGenerator ilGenerator = null; // TODO: 初始化为适当的值
            Type type = null; // TODO: 初始化为适当的值
            DynamicCalls_Accessor.EmitBoxIfNeeded( ilGenerator, type );
            Assert.Inconclusive( "无法验证不返回值的方法。" );
        }
    }
}
