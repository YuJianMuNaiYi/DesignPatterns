using System;

namespace Builder
{
    /// <summary>
    /// 指导每个具体类型BuildPart过程目标方法和执行情况的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public sealed class BuildStepAttribute:Attribute
    {
        #region 私有标量
        
        private readonly int sequence;
        private readonly int times;
        
        #endregion

        #region 属性
        /// <summary>
        /// 执行的顺序
        /// </summary>
        public int Sequence { get { return sequence; } }

        /// <summary>
        /// 执行的次数
        /// </summary>
        public int Times { get { return times; } }

        #endregion

        #region 构造函数
        public BuildStepAttribute(int sequence,int times)
        {
            if(sequence<=0||times<=0)
                throw new ArgumentOutOfRangeException(sequence<=0?"sequence":"times");

            this.sequence = sequence;
            this.times = times;
        }

        public BuildStepAttribute(int sequence):this(sequence,1)
        {
        }
        #endregion
    }
}
