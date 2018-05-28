using System.Collections.Generic;

namespace Componse.Enumerable
{
    public abstract class Component
    {
        protected IList<Component> Children;

        protected string name;

        /// <summary>
        /// Leaf和Composite的共同特征
        /// </summary>
        public virtual string Name
        {
            get => name;
            set => name = value;
        }

        public virtual void Add(Component child) => Children.Add(child);
        public virtual void Remove(Component child) => Children.Remove(child);

        public virtual Component this[int index] => Children[index];

        public virtual IEnumerable<Component> Enumerate(IMatchRule rule)
        {
            //短路方式,力求减少遍历代价
            if (rule==null || rule.IsMatch(this))
            {
                yield return this;
            }

            if (Children == null || Children.Count <= 0)
            {
                yield break;
            }

            foreach (var child in Children)
            {
                foreach (var iteComponent in child.Enumerate(rule))
                {
                    if (rule==null || rule.IsMatch(iteComponent))
                    {
                        yield return iteComponent;
                    }
                }
            }

        }

        public virtual IEnumerable<Component> Enumerate() => Enumerate(null);
    }
}
