using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder.UnitTest
{
    [TestClass]
  public  class FirstUnitTest
    {
        [TestMethod]
        public void BuildUp()
        {
            var vehicleMarker = new VehicleMarker {VehicleBuilderBase = new CarBuilder()};
            vehicleMarker.Construct();

            Assert.AreEqual(4,vehicleMarker.Vehicle.Wheels.Count());
            Assert.AreEqual(4,vehicleMarker.Vehicle.Lights.Count());

            vehicleMarker.VehicleBuilderBase=new BicycleBuilder();
            vehicleMarker.Construct();
            
            Assert.AreEqual(2,vehicleMarker.Vehicle.Wheels.Count());
            Assert.IsNull(vehicleMarker.Vehicle.Lights);
        }
    }
}
