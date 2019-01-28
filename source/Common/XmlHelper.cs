using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Common
{
    public class XmlHelper
    {
        public static string GetValue(string XmlFilePath,string KeyPath,string Key)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(XmlFilePath);
            XmlNode xmlnode = xmldoc.SelectNodes(KeyPath+"/"+Key).Item(0);
            return xmlnode.InnerText;
        }




    }
}
