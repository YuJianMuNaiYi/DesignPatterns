namespace Singleton.Third
{
    /// <summary>
    ///     代码非常简洁、精干，但却是多线程环境下C#实现单件模式非常棒的一个实现方式
    ///     1.由于Instance是类的公共静态成员，因此它会在类第一次被用到的时候构造出来，
    ///     这样就不用把它的构造语句显示的写在静态构造函数中
    ///     2.这里实例构造函数被定义为私有的，所以客户程序及其子类从外部构造新的实例，
    ///     只能通过公共静态成员Instance引用其唯一的实例，符合Singleton的设计意图。
    /// </summary>
    internal sealed class Singleton
    {
        public static readonly Singleton Instance = new Singleton();

        private Singleton()
        {
        }
    }
}