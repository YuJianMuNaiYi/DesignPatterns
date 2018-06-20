using System.Linq;

namespace MuNaiYiPattern.TemplateMethod
{
    public class ArrayData : AbstractBase
    {
        public override int Quantity => data.Length;
        public override double Total => data.Sum();

        private readonly double[] data = {1.1, 2.2, 3.3};
    }
}
