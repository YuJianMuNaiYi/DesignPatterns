using System.Diagnostics;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Customerized;

namespace Prototype.UnitTest.Common
{
    [TestClass]
    public class TestUserInfo2
    {
        [TestMethod]
        public void Test()
        {
            var userInfo2 = new UserInfo2
            {
                Name = "Joe",
                Age = 28,
                Education = new[] { "A", "B", "C", "D", "E" }
            };

            var graph = SerializationHelper.SerializeObjectToString(userInfo2);
            var cloneUserInfo2 = SerializationHelper.DeserializeStringToObject<UserInfo2>(graph);

            Trace.WriteLine("cloneUserInfo2.Education:"+cloneUserInfo2.Education.Count());
            Assert.AreEqual(3, cloneUserInfo2.Education.Count());//仅序列化前三项

            foreach (var s in cloneUserInfo2.Education)
            {
                Trace.WriteLine(s);
            }
            CollectionAssert.AreEqual(new[] { "A", "B", "C" }, cloneUserInfo2.Education);


            Trace.WriteLine("userInfo2.Name:"+userInfo2.Name);
            Trace.WriteLine("cloneUserInfo2.Name:"+cloneUserInfo2.Name);
            Assert.AreEqual(userInfo2.Name,cloneUserInfo2.Name);//Name被序列化

            Trace.WriteLine("userInfo2.Age:"+userInfo2.Age);
            Trace.WriteLine("cloneUserInfo2.Age:"+cloneUserInfo2.Age);
            Assert.AreNotEqual(userInfo2.Age,cloneUserInfo2.Age);//Age没有被序列化

        }
    }
}
