namespace Singleton.DoubleCheck
{
    public class Singleton
    {
        //volatile 关键字指示一个字段可以由多个同时执行的线程修改。声明为volatile的字段不受编译器优化
        //(假定由单个线程访问)的限制。这样可以确保该字段在任何时间呈现的都是最新的值。
        private static volatile Singleton instance;

        protected Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance != null) //虽然是多线程环境，但没有没有if语句，客户程序每次执行时都要先lock住Singleton类型
                    //但在绝大多数情况下，每次都锁住Singleton类型效率太差，这个lock很可能就成了应用程序的瓶颈。
                    return instance;

                lock (typeof (Singleton))
                {
                    if (instance == null)
                        instance = new Singleton();
                }
                return instance;
            }
        }
    }
}