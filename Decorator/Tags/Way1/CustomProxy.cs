using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace MuNaiYiPattern.Decorator.Tags.Way1
{
    /// <inheritdoc cref="RealProxy" />
    /// <summary>
    /// 定义代理类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomProxy<T>:RealProxy,IDisposable where T:MarshalByRefObject
    {
        /// <inheritdoc />
        /// <summary>
        /// 构造过程中把Proxy需要操作的内容与实际目标对象实例attach到一起
        /// </summary>
        /// <param name="target"></param>
        public CustomProxy(T target):base(target.GetType())
        {
            AttachServer(target);
        }

        public static T Create(T target)
        {
            if (target==null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return (T)(new CustomProxy<T>(target).GetTransparentProxy());
        }

        /// <inheritdoc />
        /// <summary>
        /// 实际执行的拦截,并根据装饰属性进行定制处理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            var caller=new MethodCallMessageWrapper((IMethodCallMessage)msg);

            //提取实际宿主对象
            var method = (MethodInfo)caller.MethodBase;
            if (method == null)
            {
                throw new NullReferenceException(nameof(method));
            }

            var target = (T)GetUnwrappedServer();

            var attributes= (DecoratorAttributeBase[])method.GetCustomAttributes(typeof(DecoratorAttributeBase), true);
            if (attributes.Length>0)
            {
                foreach (var attribute in attributes)
                {
                    attribute.Intercept(caller);
                }
            }

            var ret = method.Invoke(target, caller.Args);

            //拦截处理后,继续回到宿主对象的调用过程
            return new ReturnMessage(ret,caller.Args,caller.ArgCount,caller.LogicalCallContext,caller);
        }

        /// <inheritdoc />
        /// <summary>
        /// 析构过程则借助Proxy和目标对象实例的Attach,便于GC回收
        /// </summary>
        public void Dispose()
        {
            DetachServer();
        }
    }
}
