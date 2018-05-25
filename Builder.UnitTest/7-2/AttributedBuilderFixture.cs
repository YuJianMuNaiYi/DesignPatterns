using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder.UnitTest
{
    [TestClass]
    public class AttributedBuilderFixture
    {
        public static Action<string, Action<string>> buildPartHandler = (x, y) =>
        {
            Trace.WriteLine("add " + x);
            y(x);
        };

        class Car
        {
            public IList<string> Parts { get; private set; }
            public Car() { Parts=new List<string>();}

            /// <summary>
            /// 为汽车添加轮胎
            /// </summary>
            /// <remarks>
            /// Attributed Builder第二个执行的Step执行4次,即为每辆汽车装配4个轮胎
            /// </remarks>
            [BuildStep(2,4)]
            public void AddWheel()
            {
                buildPartHandler("wheel", Parts.Add);
            }

            /// <summary>
            ///  为汽车装配引擎
            /// </summary>
            /// <remarks>
            /// 没有通过Attributed标识的内容,因此不会被Attributed Builder
            /// 执行
            /// </remarks>
            public void AddEngine()
            {
                buildPartHandler("engine", Parts.Add);
            }

            /// <summary>
            /// 为汽车装配车身
            /// </summary>
            /// <remarks>
            /// Attributed Builder第一个执行的Setp执行1次,
            /// 即为每辆汽车装配增加1个车身
            /// </remarks>
            [BuildStep(1)]
            public void AddBody()
            {
                buildPartHandler("body", Parts.Add);
            }
        }

        [TestMethod]
        public void BuildCarByAttributeDirection()
        {
            Trace.WriteLine("build Car:");
            var car = new Builder<Car>().BuildUp();

            Assert.IsNotNull(car);
            Assert.IsFalse(car.Parts.Contains("engine"));//不会被执行的内容
            Assert.AreEqual("body",car.Parts.ElementAt(0));

            for (int i = 1; i <= 4; i++)
            {
                Assert.AreEqual("wheel",car.Parts.ElementAt(i));
            }
        }
    }
}
