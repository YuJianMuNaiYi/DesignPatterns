namespace AdapterPattern
{
    /// <summary>
    /// 类型转换符实现适配
    ///     这种方式产生的局限性：
    ///         Target3与Adaptee3产生了直接的依赖关系，将本应由独立Adapter类型完成的工作内部化为自己的逻辑。
    ///         转换运算符是static的，子类不能按照继承自动获取这个类型转换的特性。这也就等于提醒我们，如果工程
    ///         中Target3与Adaptee3可以保证1:1，那么无所谓，直接进行类型转换就可以了；如果觉得隐式转换不安全，
    ///         定义为显示的即可.如果Target3本身就是一个 接口或是抽象类，则最好打消这个念头，尽管抽象类也可以转换
    ///         运算符，但任何子类都无法直接通过继承获取隐式或显示的转换能力。
    /// </summary>
    public class Target3
    {
        private int data;

        public Target3(int data)
        {
            this.data = data;
        }

        public int Data
        {
            get { return data; }
        }

        public static implicit operator Target3(Adaptee3 adaptee3)
        {
            return new Target3(adaptee3.Code);
        }
    }
}
