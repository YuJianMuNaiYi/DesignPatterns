using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Builder
{
    public class BuildStep
    {
        public MethodInfo MethodInfo { get; set; }
        public int Sequence { get; set; }
        public int Times { get; set; }
    }
    public class BuilderStepDiscovery
    {
        /// <summary>
        /// 缓冲已经解析过的类型信息
        /// </summary>
        static readonly IDictionary<Type, IEnumerable<BuildStep>> Cache = 
            new Dictionary<Type, IEnumerable<BuildStep>>();

        /// <summary>
        ///登记那些已经认定没有BuildStep属性的类型
        /// </summary>
        static readonly IList<Type> ErrorCache = new List<Type>();

        /// <summary>
        /// 借助反射获得类型T所需执行BuildPart()的自动发现机制
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<BuildStep> DiscoveryBuildSteps(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (ErrorCache.Contains(type)) return null;
            if (Cache.ContainsKey(type)) return Cache[type];
            
            var aType = typeof(BuildStepAttribute);

            var methods = from item in
                (from method in type.GetMethods()
                    where method.IsDefined(aType, false)
                    select new
                    {
                        M = method,
                        A = (BuildStepAttribute) method.GetCustomAttributes(aType, false).First()
                    })
                orderby item.A.Sequence
                select new BuildStep
                {
                    MethodInfo = item.M,
                    Times = item.A.Times,
                    Sequence = item.A.Sequence
                };

            if (!methods.Any())
            {
                ErrorCache.Add(type);
                return null;
            }
            Cache.Add(type,methods);
            return methods;
        }
    }
}
