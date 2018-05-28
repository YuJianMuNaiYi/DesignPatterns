using System.Xml;

namespace Componse.Xml
{
    public static class XmlHelper
    {
        public static XmlNode GetXmlNode(XmlDocument document, string xpath) => document.SelectSingleNode(xpath);
        public static XmlNodeList GetXmlNodeList(XmlDocument document, string xpath) => document.SelectNodes(xpath);
    }
}
