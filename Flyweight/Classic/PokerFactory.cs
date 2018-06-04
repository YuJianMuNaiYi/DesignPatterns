using System;
using System.Collections.Generic;

namespace MuNaiYiPattern.Flyweight.Classic
{
    /// <summary>
    /// 享元工厂类型
    /// </summary>
    public class PokerFactory
    {
        private const int MaxPoint = 13;
        private const int MinPoint = 1;

        private static readonly IDictionary<Suit,SuitBase> suitBases=new Dictionary<Suit, SuitBase>
        {
            {Suit.Spade,new SpadeSuit() },
            {Suit.Club,new ClubSuit() },
            {Suit.Diamond,new DiamondSuit() },
            {Suit.Heart,new HeartSuit() }
        };

        private static readonly IDictionary<int,PointBase> pointBases=new Dictionary<int, PointBase>
        {
            {1,new AcePoint() },
            {2,new DeucePoint()},
            {3,new ThreePoint() },
            {4,new FourPoint() },
            {5,new FivePoint() },
            {6,new SixPoint() },
            {7,new SevenPoint() },
            {8,new EightPoint() },
            {9,new NinePoint() },
            {10,new TenPoint() },
            {11,new JackPoint() },
            {12,new QueuePoint() },
            {13,new KingPoint() }
        };

        /// <summary>
        /// 享元类型实例缓存
        /// </summary>
        private static readonly IDictionary<KeyValuePair<int,Suit>,Poker> pokers=new Dictionary<KeyValuePair<int, Suit>, Poker>();

        /// <summary>
        /// 根据享元目标类型特征生成享元类型实例
        /// </summary>
        /// <param name="point">点数</param>
        /// <param name="suit">花色</param>
        /// <returns>扑克牌实例</returns>
        public Poker CreatePoker(int point, Suit suit)
        {
            if (point>MaxPoint || point<MinPoint)
            {
                throw new ArgumentOutOfRangeException(nameof(point));
            }

            var key=new KeyValuePair<int,Suit>(point,suit);
            if (pokers.TryGetValue(key, out var result))
            {
                return result;
            }

            result=new Poker
            {
                Point = pointBases[point],
                Suit = suitBases[suit]
            };
            pokers.Add(key,result);

            return result;
        }
    }
}
