using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLWorker.XmlService
{
    public static class XmlParser
    {
        public static string ExtractXMLValue(XmlNode node, string attribute)
        {
            ArgumentNullException.ThrowIfNull(node);
            ArgumentNullException.ThrowIfNullOrEmpty(attribute);

            var deviceNameNode = node.SelectSingleNode(attribute).InnerXml;

            if (string.IsNullOrEmpty(deviceNameNode))
            {
                return "Значение не указано";
            }

            return deviceNameNode;
        }
    }
}
