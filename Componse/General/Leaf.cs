using System;

namespace Componse.General
{
    public class Leaf:Component
    {
        /// <summary>
        /// 明确声明不支持此类操作
        /// </summary>
        /// <param name="child"></param>
        public override void Add(Component child)=>throw new NotSupportedException();

        /// <summary>
        /// 明确声明不支持此类操作
        /// </summary>
        /// <param name="child"></param>
        public override void Remove(Component child)=>throw new NotSupportedException();

        /// <summary>
        /// 明确声明不支持此类操作
        /// </summary>
        /// <param name="index"></param>
        public override Component this[int index]=>throw new NotSupportedException();

    }
}
