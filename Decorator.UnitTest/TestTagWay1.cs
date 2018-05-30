using System;
using MuNaiYiPattern.Decorator.Tags.Way1;
using NUnit.Framework;

namespace MuNaiYiPattern.Decorator.UnitTest
{
    [TestFixture]
    public class TestTagWay1
    {
        [Test]
        public void Test()
        {
            var uesr = CustomProxy<User>.Create(new User());
            uesr.SetUserInfo("joe","manager");//成功

            try
            {
                uesr.SetUserInfo(20,"manager");
            }
            catch (Exception exception)
            {
                //因第一个参数类型异常被拦截后抛出异常
                //Assert.IsInstanceOf(exception, typeof(ArgumentException));
            }

            try
            {
                uesr.SetUserInfo("", "manager");
            }
            catch (Exception exception)
            {
                //因name为空被拦截后抛出异常
                //Assert.IsInstanceOf(e,typeof(ArgumentException));
            }
        }
    }
}
