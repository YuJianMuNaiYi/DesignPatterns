namespace MuNaiYiPattern.Decorator.Tags.CustomAop
{
    /// <summary>
    /// 待装饰的目标类型接口
    /// </summary>
    public interface IBizObject
    {
        /// <summary>
        /// 待装饰的内容只要定义在接口即可,不用逐个定义在每个实体类上
        /// </summary>
        /// <returns></returns>
        [Log]
        [Security]
        int GetValue();
        int GetYear();
    }
}
