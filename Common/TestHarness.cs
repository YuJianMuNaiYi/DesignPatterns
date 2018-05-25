using System.Linq;
using System.Threading;

namespace Common
{
    public static class TestHarness
    {
        public static void Parallel(params ThreadStart[] actions)
        {
            var threads = actions.Select(x => new Thread(x)).ToArray();
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());
        }
    }
}