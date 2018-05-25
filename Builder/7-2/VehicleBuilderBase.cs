namespace Builder
{
    public abstract class VehicleBuilderBase
    {
        public Vehicle Vehicle { get; protected set; }
        //virtual 关键字用于修饰方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
        public virtual void Create() { Vehicle=new Vehicle();}

        public abstract void AddWheels();
        public abstract void AddLights();
    }
}
