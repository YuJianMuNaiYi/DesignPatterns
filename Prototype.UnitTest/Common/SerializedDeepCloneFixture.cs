using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.UnitTest.Common
{
    [TestClass]
    public class SerializedDeepCloneFixture
    {
        /// <summary>
        /// 测试用的可序列化类型
        /// </summary>
        [Serializable]
        class UserInfo
        {
            public string Name { get; set; }
            public readonly List<string> EducationList = new List<string>();

            /// <summary>
            /// 得到浅拷贝对象
            /// </summary>
            /// <returns></returns>
            public UserInfo GetShallowCopy()
            {
                return (UserInfo)this.MemberwiseClone();
            }

            /// <summary>
            /// 得到深拷贝对象
            /// </summary>
            /// <returns></returns>
            public UserInfo GetDeepCopy()
            {
                var graph = SerializationHelper.SerializeObjectToString(this);
                return SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            }
        }

        /// <summary>
        /// 验证对可序列化类型进行浅表复制
        /// </summary>
        [TestMethod]
        public void ShallowCopyTest()
        {
            var userInfo = new UserInfo
            {
                Name = "joe",
            };
            userInfo.EducationList.Add("小学");
            userInfo.EducationList.Add("初中");

            var userInfo2 = userInfo.GetShallowCopy();

            //验证可以完成某种程度的复制
            Assert.AreEqual(userInfo.Name, userInfo2.Name);
            Trace.WriteLine("userInfo.Name:" + userInfo.Name);
            Trace.WriteLine("userInfo2.Name:" + userInfo2.Name);

            Assert.AreEqual(userInfo.EducationList[0], userInfo2.EducationList[0]);
            Trace.WriteLine("userInfo.EducationList[0]=" + userInfo.EducationList[0]);
            Trace.WriteLine("userInfo2.EducationList[0]=" + userInfo2.EducationList[0]);

            // 验证Shallow Copy方式下，没有对引用类型作出处理

            userInfo2.EducationList[0] = "中专";
            Trace.WriteLine(userInfo.EducationList[0] == userInfo2.EducationList[0]);
            Trace.WriteLine("userInfo.EducationList[1]:" + userInfo.EducationList[0]);
            Trace.WriteLine("userInfo2.educationList[1]:" + userInfo2.EducationList[0]);
            //测试不通过,因为浅拷贝时,引用类型只是拷贝的引用地址,所以当副本被修改时,相应的样本也跟着发生变化
            Assert.AreNotEqual(userInfo.EducationList[0], userInfo2.EducationList[0]);

        }

        [TestMethod]
        public void DeepCopyTest()
        {
            var userInfo = new UserInfo
            {
                Name = "joe",
            };
            userInfo.EducationList.Add("小学");
            userInfo.EducationList.Add("初中");

            var userInfo2 = userInfo.GetDeepCopy();

            // 验证可以完成某种程度的复制
            Assert.AreEqual(userInfo.Name, userInfo2.Name);
            Trace.WriteLine("userInfo.Name:" + userInfo.Name);
            Trace.WriteLine("userInfo2.Name:" + userInfo2.Name);

            Assert.AreEqual(userInfo.EducationList[0], userInfo2.EducationList[0]);
            Trace.WriteLine("userInfo.EducationList[0]=" + userInfo.EducationList[0]);
            Trace.WriteLine("userInfo2.EducationList[0]=" + userInfo2.EducationList[0]);

            // 验证Deep Copy方式下，可以对引用类型作出处理
            Trace.WriteLine("验证Deep Copy方式下，可以对引用类型作出处理");
            userInfo2.EducationList[0] = "幼儿园";
            Trace.WriteLine("userInfo.EducationList[0]=" + userInfo.EducationList[0]);
            Trace.WriteLine("userInfo2.EducationList[0]=" + userInfo2.EducationList[0]);

            //此处测试不通过,因为深拷贝时,并没有引用样本的地址,而是在内存开辟了对应的空间,来存放副本
            //因此,当修改副本时,样本并不会跟着发生变化,此时它们是两个独立的实例
            Assert.AreEqual(userInfo.EducationList[0], userInfo2.EducationList[0]);

        }

        //[TestMethod]
        //[ExpectedException(typeof(SerializationException))]
        //public void CanNotSerialization()
        //{
        //    //执行到这句时报错,提示Outer未被标记为可序列化
        //    var graph = SerializationHelper.SerializeObjectToString(new Client());
        //}
    }

    //class Inner{}

    //class Middle{Inner sub = new Inner();}

    //class Outer{Middle sub = new Middle();}

    //[Serializable]
    //class Client
    //{
    //    Outer outer = new Outer();//非Serializable引用对象
    //}
}
