namespace Builder
{
    public interface IBuilder<T> where T:class ,new ()
    {
        T BuildUp();
    }

    public class Builder<T> : IBuilder<T> where T : class, new()
    {
        public virtual T BuildUp()
        {
            var steps = new BuilderStepDiscovery().DiscoveryBuildSteps(typeof (T));
            if(steps==null)return new T();//如果没有BuildPart步骤,退化为工厂模式
            var target = new T();
            foreach (var buildStep in steps)
            {
                for (int i = 0; i < buildStep.Times; i++)
                {
                    buildStep.MethodInfo.Invoke(target, null);
                }
            }
            return target;
        }
    }
}
