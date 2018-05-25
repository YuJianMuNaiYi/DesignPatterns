using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using FactoryMethod.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod
{
    public static class Assembler
    {
        private const string SecetionName = "FactoryMethod.Sources";

        //保存抽象類型/實體類型對應關係的字典
        private static readonly Dictionary<Type, Type> Dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            var nameValueCollection = (NameValueCollection) ConfigurationManager.GetSection(SecetionName);
            for (int i = 0; i < nameValueCollection.Count; i++)
            {
                string target = nameValueCollection.GetKey(i);
                string source = nameValueCollection[i];

                if (target != null)
                    Dictionary.Add(Type.GetType(target), Type.GetType(source));
            }
        }

        public static object Create(Type type)
        {
            if (type == null || !Dictionary.ContainsKey(type))
                throw new NullReferenceException("type");

            return Activator.CreateInstance(Dictionary[type]);
        }

        public static T Create<T>()
        {
            return (T) Create(typeof (T));
        }

        public static void Assembly(Client client)
        {
            client.Factory = Create<IFactory>();
        }

        [TestClass]
        public class Client
        {
            public IFactory Factory { get; set; } // setter injection

            public IProduct Product
            {
                get { return Factory.Create(); }
            }

            [TestMethod]
            public void FactoryWithAssembler()
            {
                var client = new Client();
                Assembly(client);
                Assert.IsInstanceOfType(client.Factory, typeof (FactoryA));
                Assert.IsInstanceOfType(client.Product, typeof (ProductA));
            }
        }
    }
}