namespace MuNaiYiPattern.Flyweight.Classic
{
    /// <summary>
    /// 包括两个享元类型成员的享元类型
    /// </summary>
    public class Poker
    {
        public SuitBase Suit { get; set; }

        public PointBase Point { get; set; }
    }
}
