using System.Collections.Generic;

namespace Componse.Enumerable
{
    public class Composite:Component
    {
        public Composite() => base.Children = new List<Component>();

    }
}
