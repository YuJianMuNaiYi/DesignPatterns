using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.UnitTest
{
   
    [TestClass]
    public class TestPrototype
    {
        private IPrototype samplePrototype;

        [TestInitialize]
        public void Initialize()
        {
            samplePrototype=new ConcretePrototype();
        }

        [TestMethod]
        public void TestMethod()
        {
            var image = samplePrototype.Clone();

            Assert.IsNull(samplePrototype.Name);
            Assert.IsNull(image.Name);//副本与样本当时的内容一致

            samplePrototype.Name = "A";
            Trace.WriteLine("samplePrototype.Name: "+samplePrototype.Name);
            image = samplePrototype.Clone();

            Assert.AreEqual("A",image.Name);
            Trace.WriteLine("image.Name: " + image.Name);//副本与样本当时的内容一致

            Assert.IsInstanceOfType(image,typeof(ConcretePrototype));

            image.Name = "B";//独立修改副本的内容
            Trace.WriteLine("image.Name: " + image.Name);

            //理论上string类型Name是引用类型，但是由于该引用类型的特殊性（无论是实际还是语义），
            //Object.MemberwiseClone方法仍旧为其创建了副本。也就是说，在浅拷贝过程，
            //我们应该将字符串看成是值类型。

            Assert.IsTrue(samplePrototype.Name!=image.Name);//证明副本与样本是两个独立的个体
            Trace.WriteLine(samplePrototype.Name != image.Name);
        }
    }
}
