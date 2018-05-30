using System;
using System.Collections.Generic;
using MuNaiYiPattern.Decorator.Classic;

namespace MuNaiYiPattern.Decorator.ConfigAndCreate
{
    /// <summary>
    /// 装饰类型的装配器
    /// </summary>
    public class DecoratorAssembler
    {
        /// <summary>
        /// 登记装饰不同类型需要使用的一组Conctete Decorator类型
        /// </summary>
        private static readonly Dictionary<Type, IEnumerable<Type>> dictionary = new Dictionary<Type, IEnumerable<Type>>();

        /// <summary>
        /// 实际项目中这个加载过程可由配置完成
        /// </summary>
        static DecoratorAssembler()
        {
            //配置相关的装饰类型
            var types = new List<Type>
            {
                typeof(BoldDecorator),typeof(ColorDecorator)
            };

            dictionary.Add(typeof(TextObject),types);
        }

        /// <summary>
        /// 按照需要构造的客户类型选择相应的Decorator列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Type> this[Type type]
        {
            get
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }

                return dictionary.TryGetValue(type, out var result) ? result : null;
            }
        }
        
    }
}
