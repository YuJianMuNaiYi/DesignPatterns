using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace FactoryMethod.Exercise
{
    public interface IFactory
    {
        IFactory RegisterType<TTarget, TSource>(); //連貫接口
        IFactory RegisterType<TTarget, TSource>(string name); //連貫接口

        TTarget Create<TTarget>();
        TTarget Create<TTarget>(string name);
    }

    public class Factory : IFactory
    {
        protected TypeRegistry registryType = new TypeRegistry();

        public IFactory RegisterType<TTarget, TSource>()
        {
            registryType.RegisterType(typeof (TTarget), typeof (TSource));
            return this;
        }

        public IFactory RegisterType<TTarget, TSource>(string name)
        {
            registryType.RegisterType(typeof (TTarget), typeof (TSource), name);
            return this;
        }

        public TTarget Create<TTarget>()
        {
            return (TTarget) Activator.CreateInstance(registryType[typeof (TTarget)]);
        }

        public TTarget Create<TTarget>(string name)
        {
            return (TTarget) Activator.CreateInstance(registryType[typeof (TTarget), name]);
        }
    }

    public sealed class TypeRegistry
    {
        private readonly string defaultName = Guid.NewGuid().ToString();

        private readonly IDictionary<Type, IDictionary<string, Type>> registryDictionary =
            new Dictionary<Type, IDictionary<string, Type>>();

        public Type this[Type targetTyep, string name]
        {
            get
            {
                if (targetTyep == null) throw new ArgumentNullException("targetTyep");
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

                if (!registryDictionary.Any())
                    return null;

                return
                    (registryDictionary.Where(x => x.Key == targetTyep)).FirstOrDefault()
                        .Value.FirstOrDefault(x => string.Equals(name, x.Key))
                        .Value;
            }
        }

        public Type this[Type targetType]
        {
            get { return this[targetType, defaultName]; }
        }

        public void RegisterType(Type targetType, Type sourceType)
        {
            RegisterType(targetType, sourceType, defaultName);
        }

        public void RegisterType(Type targetType, Type sourceType, string name)
        {
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));
            if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            IDictionary<string, Type> subDictionary;
            //TryGetValue 获取与指定的键相关联的值。
            //如果实现 System.Collections.Generic.IDictionary<TKey,TValue> 的对象包
            //含具有指定键的元素，则为 true；否则，为 false。
            //如果不包含
            if (!registryDictionary.TryGetValue(targetType, out subDictionary))
            {
                subDictionary = new Dictionary<string, Type>
                {
                    {name, sourceType}
                };

                registryDictionary.Add(targetType, subDictionary);
            }
            else //如果包含
            {
                if (subDictionary.ContainsKey(name))
                    throw new DuplicateKeyException(name); //重複鍵異常

                subDictionary.Add(name, sourceType);
            }
        }
    }
}