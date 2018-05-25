namespace Singleton.Second
{
    /// <summary>
    /// 1.这个Singleton仅有一个公共的类属性方法------Instance,区别于一般情况,Singleton类的构造函数被定义为protected,
    /// 也就是说客户程序不可以直接实例化Singleton类,而静态属性Instance就是客户程序获得类型实例的唯一入口。
    /// 2.
    /// </summary>
    public class Singleton
    {
        private static Singleton instance; //唯一的实例

        protected Singleton() //封闭客户程序的直接实例化
        {
        }

        public static Singleton Instance
        {
            get { return instance ?? (instance = new Singleton()); }
        }
    }

}