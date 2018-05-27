using System.Collections.Generic;

namespace Componse.General
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
            get => this.name;
            set => this.name = value;
        }

        public virtual void Add(Component child) => Children.Add(child);
        public virtual void Remove(Component child) => Children.Remove(child);

        public virtual Component this[int index] => Children[index];

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
