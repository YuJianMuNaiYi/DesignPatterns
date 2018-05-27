using System.Collections.Generic;
using Componse.Enumerable;
using NUnit.Framework;

namespace Componse.UnitTest
{
    [TestFixture]
    public class TestEnumerate
    {
        [TestFixture]
        public class TestComponse
        {
            [Test(Description = "测试组合模式---迭代器")]
            public void Test()
            {
                var component = ComponentFactory.Create<Composite>("composite");

                var factory = new ComponentFactory();
                factory.Create<Leaf>(component, "主席");
                factory.Create<Leaf>(component, "副主席");


                var sales = factory.Create<Composite>(component, "sales");
                factory.Create<Leaf>(sales, "joe");
                factory.Create<Leaf>(sales, "bob");

                var market = factory.Create<Composite>(component, "market");
                factory.Create<Leaf>(market, "judi");

                var branch = factory.Create<Composite>(component, "branch");
                factory.Create<Leaf>(branch, "manager");
                factory.Create<Leaf>(branch, "peter");

                var matchSet = component.Enumerate(new LeafMatchRule());

                var leaves = new List<Component>(matchSet);

                Assert.AreEqual(7,leaves.Count);

                var another=new List<Component>(component.Enumerate());
                Assert.AreEqual(11,another.Count);

            }
        }
    }
}
