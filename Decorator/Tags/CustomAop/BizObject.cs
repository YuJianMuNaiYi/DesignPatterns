using System;

namespace MuNaiYiPattern.Decorator.Tags.CustomAop
{
    public class BizObject:IBizObject
    {
        public static readonly  int Value=new Random().Next();

        /// <summary>
        /// 接口中已经被标注为需要装饰的方法
        /// </summary>
        /// <returns></returns>
        public int GetValue() => Value;

        /// <summary>
        /// 接口中声明为无须装饰的方法
        /// </summary>
        /// <returns></returns>
        public int GetYear() => DateTime.Now.Year;
    }
}
