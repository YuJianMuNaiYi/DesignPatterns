using System.Collections.Generic;

namespace Singleton.First
{
    public class Target
    {
    }

    public class Client
    {
        private static readonly IList<Target> Targets = new List<Target>();
        public Target Target { get; private set; }

        public void SomeMethod()
        {
            if (Targets.Count == 0)
            {
                Target = new Target();
                Targets.Add(Target);
            }
            else
            {
                Target = Targets[0];
            }
        }
    }
}