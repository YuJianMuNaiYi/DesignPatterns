using System.Collections.Generic;

namespace Builder
{
   public class CarBuilder:VehicleBuilderBase
    {
       public override void AddWheels()
       {
           Vehicle.Wheels = new List<string> { "front", "front", "back", "back" };
       }

       public override void AddLights()
       {
           Vehicle.Lights = new List<string> { "front", "front", "back", "back" };
       }
    }
}
