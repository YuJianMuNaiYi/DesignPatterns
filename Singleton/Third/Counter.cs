namespace Singleton.Third
{
    public class Counter
    {
        public static readonly Counter Instance = new Counter();

        private int value;

        private Counter()
        {
        }

        public int Next
        {
            get { return ++value; }
        }

        public void Reset()
        {
            value = 0;
        }
    }
}