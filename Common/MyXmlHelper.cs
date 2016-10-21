using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WX_TennisAssociation.Common
{
    public class MyXmlHelper
    {
        public static string ObjectToXml(Object obj)
        {
            XmlDocument xmlDoc = new XmlDataDocument();
            //xmlDoc.
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, obj);
                xmlStream.Position = 0;

                xmlDoc.Load(xmlStream);

                string strResult = xmlDoc.InnerXml;
                StringBuilder strBuilder = new StringBuilder(strResult);
                string oldStr = "<?xml version=\"1.0\"?><xml xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
                string newStr = "<xml>";
                strBuilder.Replace(oldStr, newStr);
                string strRe = strBuilder.ToString();
                return strRe;
            }
        }
    }
}