using FactoryMethod.Exercise;
using FactoryMethod.Sources.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.UnitTest.Exercise
{
    [TestClass]
    public class FactoryFixture
    {
        [TestMethod]
        public void CreateInstance()
        {
            IFactory factory = new Factory().RegisterType<IFruit, Apple>().
                RegisterType<IFruit, Orange>("o").RegisterType<IVehicle, Bicycle>()
                .RegisterType<IVehicle, Bicycle>("a")
                .RegisterType<IVehicle, Train>("b").RegisterType<IVehicle, Car>("c");

            Assert.IsInstanceOfType(factory.Create<IFruit>(), typeof (Apple));
            Assert.IsInstanceOfType(factory.Create<IFruit>("o"), typeof (Orange));

            Assert.IsInstanceOfType(factory.Create<IVehicle>(), typeof (Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("a"), typeof (Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("b"), typeof (Train));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("c"), typeof (Car));
        }
    }
}