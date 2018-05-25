using System;
using System.Collections.Specialized;
using System.Configuration;

namespace FactoryMethod.Sources.Batch
{
    public class ProductRegistry
    {
        public static string SectionName = "concreteProducts";

        private static readonly NameValueCollection nameValueCollection =
            (NameValueCollection) ConfigurationManager.GetSection(SectionName);

        public Type this[string name]
        {
            get { return Type.GetType(nameValueCollection[name]); }
        }
    }
}