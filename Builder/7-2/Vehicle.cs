using System.Collections.Generic;

namespace Builder
{
    public class Vehicle
    {
        public IEnumerable<string> Wheels { get; set; }
        public IEnumerable<string> Lights { get; set; } 
    }
}
