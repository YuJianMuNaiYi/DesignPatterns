using System;
using System.Diagnostics;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.UnitTest.Common
{
    /// <summary>
    /// 简单自定义复制过程
    /// </summary>
    [Serializable]
    class Parent
    {
    }

    [Serializable]
    class Teacher
    {
    }

    [Serializable]
    class Child
    {
        [NonSerialized]
        public Parent[] Parents;
        public Teacher Teacher { get; set; }
    }

    [TestClass]
    public class TestClassInfo
    {
        [TestMethod]
        public void Test()
        {
            var child = new Child
            {
                Teacher = new Teacher(),
                Parents = new Parent[2]
            };
            Trace.WriteLine("child.Parents:"+child.Parents);
            Trace.WriteLine("child.Teacher:"+child.Teacher);

            Assert.IsNotNull(child.Parents);//克隆前不为空
            Assert.IsNotNull(child.Teacher);

            var graph = SerializationHelper.SerializeObjectToString(child);
            var cloneChild = SerializationHelper.DeserializeStringToObject<Child>(graph);

            if (cloneChild.Parents == null)
            {
                Trace.WriteLine("cloneChild.Parents is Null");
            }
            else
            {
                Trace.WriteLine("cloneChild.Parents:" + cloneChild.Parents);
            }
            Trace.WriteLine("cloneChild.Teacher:" + cloneChild.Teacher);
            Assert.IsNull(cloneChild.Parents);//[NonSerialized]标记内容克隆为空
            Assert.IsNotNull(cloneChild.Teacher);//其他内容可以有效深层克隆
            //按理来说,克隆前已经非空的Parents属性深层复制后应该也非空,但测试说明它是空的,
            //说明它的内容并没有被序列化,其原因就是[NonSerialized]发生了作用,影响了序列化的过程.
        }
    }
    class NonSerializedAttributeFixture
    {
    }
}
