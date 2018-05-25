using System;
using System.Collections.Specialized;
using System.Configuration;
using FactoryMethod.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.UnitTest
{
    [TestClass]
    public class Client
    {
        public IFactory Factory { get; set; }//Set注入

        public IProduct Product
        {
            get { return Factory.Create(); }
        }

        #region

        private const string SecetionName = "FactoryMethod.Sources";
        private const string Name = "FactoryMethod.Sources.IFactory,FactoryMethod";

        [TestMethod]
        public void UnitTest()
        {
            string typeName = ((NameValueCollection) ConfigurationManager.GetSection(SecetionName))[Name];
            Assert.IsTrue(typeof (IFactory).IsAssignableFrom(Type.GetType(typeName)));
        }

        #endregion

        //#region
        //[TestMethod]
        //public void FactoryWithAssembler()
        //{
        //    var client = new Client();
        //    Assembler.Assembly(client);
        //    Assert.IsInstanceOfType(client.Factory, typeof(FactoryB));
        //    Assert.IsInstanceOfType(client.Product, typeof(ProductB));
        //}
        //#endregion
    }
}