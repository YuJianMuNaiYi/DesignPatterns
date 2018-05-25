using System.Collections.Generic;

namespace Builder
{
    public class BicycleBuilder : VehicleBuilderBase
    {
        public override void AddWheels()
        {
            Vehicle.Wheels = new List<string> { "front", "back" };
        }

        public override void AddLights()
        {
            Vehicle.Lights = null;
        }
    }
}
