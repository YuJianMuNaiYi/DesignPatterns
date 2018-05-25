namespace Singleton
{
    /// <summary>
    /// 会导致Singleton变质的情景
    /// </summary>
    public class BaseEntity:System.ICloneable
    {
        public object Clone()//对当前实例进行克隆
        {
            return MemberwiseClone();//例如采用这种方式克隆
        }
    }
}
