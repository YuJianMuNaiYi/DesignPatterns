namespace Builder
{
   public class VehicleMarker
    {
       public VehicleBuilderBase VehicleBuilderBase { get; set; }
       public Vehicle Vehicle { get {return VehicleBuilderBase.Vehicle; } }

       public void Construct()
       {
           VehicleBuilderBase.Create();
           VehicleBuilderBase.AddLights();
           VehicleBuilderBase.AddWheels();
       }
    }
}
