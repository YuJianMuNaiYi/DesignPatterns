using System;
using System.Collections.Generic;
using System.Xml;
using Componse.Enumerable;

namespace Componse.Xml
{
    public class Corporate : Composite
    {
        private XmlDocument GetXmlDocument()
        {
            var doc = new XmlDocument();
            doc.LoadXml(Resource.CooporateData);
            return doc;
        }

        public IList<Department> GetDepartments()
        {
            const string xpath = "/corporate/department";
            var list = XmlHelper.GetXmlNodeList(GetXmlDocument(), xpath);
            if (list == null || list.Count == 0)
                return null;

            var departments = new List<Department>();
            foreach (XmlNode node in list)
            {
                if (node.Attributes == null)
                    continue;

                name = node.Attributes["name"].Value;
                departments.Add((Department)ComponentFactory.Create<Department>(name));
            }

            return departments;
        }
    }
}
