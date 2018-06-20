using System.Collections.Generic;
using System.Linq;

namespace MuNaiYiPattern.TemplateMethod
{
    public class GridData:AbstractBase
    {
        public override int Quantity => data.Sum(x => x.Count());
        public override double Total => data.Sum(x => x.Sum());

        private IEnumerable<IEnumerable<double>> data = new[]
        {
            new[]
            {
                1.1, 0, 0
            },
            new[]
            {
                0, 2.2, 0
            },
            new[]
            {
                0, 0, 3.3
            }
        };
    }
}
