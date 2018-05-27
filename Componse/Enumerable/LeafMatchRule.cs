namespace Componse.Enumerable
{
    public class LeafMatchRule:IMatchRule
    {
        public bool IsMatch(Component target)
        {
            return target != null && target.GetType().IsAssignableFrom(typeof(Leaf));
        }
    }
}
