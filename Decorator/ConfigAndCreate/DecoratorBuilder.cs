using System;
using System.Linq;
using MuNaiYiPattern.Decorator.Classic;

namespace MuNaiYiPattern.Decorator.ConfigAndCreate
{
    /// <summary>
    /// 为目标类型做"装饰"的创建者
    /// </summary>
    public class DecoratorBuilder
    {
        private static readonly DecoratorAssembler assembler = new DecoratorAssembler();

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IText BuildUp(IText target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var types = assembler[target.GetType()];
      
            if (types!=null && types.Any())
            {
                types.ToList().ForEach(x => target = (IText)Activator.CreateInstance(x, target));
            }

            return target;
        }
    }
}
