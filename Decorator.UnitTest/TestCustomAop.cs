using System;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.Decorator.Tags.CustomAop;

namespace MuNaiYiPattern.Decorator.UnitTest
{
    [TestClass]
    public class TestCustomAop
    {
        [TestMethod]
        public void Test()
        {
            var container =
                new UnityContainer().AddNewExtension<Interception>();

            //Unity动态编译并增加装饰类型
            container.RegisterType<IBizObject, BizObject>().Configure<Interception>()
                .SetInterceptorFor<IBizObject>(new InterfaceInterceptor());

            var bizObject = container.Resolve<IBizObject>();

            //  调用装饰后的方法
            Trace.WriteLine("\nInvoke GetValue()\n-----------------");
            Assert.AreEqual<int>(BizObject.Value, bizObject.GetValue());

            //  调用未装饰的方法
            Trace.WriteLine("\nInvoke GetValue()\n-----------------");
            Assert.AreEqual<int>(DateTime.Now.Year, bizObject.GetYear());
        }
    }
}
