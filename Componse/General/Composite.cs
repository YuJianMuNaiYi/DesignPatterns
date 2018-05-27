using System.Collections.Generic;

namespace Componse.General
{
    public class Composite:Component
    {
        public Composite() => base.Children = new List<Component>();
    }
}
