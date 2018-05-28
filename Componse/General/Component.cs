using System.Collections.Generic;

namespace Componse.General
{
    public abstract class Component
    {
        /// <summary>
        /// 保存子节点
        /// </summary>
        protected IList<Component> Children;

        protected string name;

        /// <summary>
        /// Leaf和Composite的共同特征
        /// setter方式注入名称
        /// </summary>
        public virtual string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual void Add(Component child) => Children.Add(child);
        public virtual void Remove(Component child) => Children.Remove(child);

        public virtual Component this[int index] => Children[index];

        /// <summary>
        /// 实现迭代器,并且对容器对象实现隐性递归
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetNameList()
        {
            yield return name;

            if (Children == null || Children.Count <= 0)
            {
                yield break;
            }

            foreach (var child in Children)
            {
                foreach (var item in child.GetNameList())
                {
                    yield return item;
                }
            }
        }
    }
}
