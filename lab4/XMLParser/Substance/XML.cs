using System;
using System.Xml;

namespace Substance
{
    public class XML
    {
        public static XmlDocument GetValideDocument(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
            }
            catch (Exception e)
            {
                return null;
            }

            if (xDoc.DocumentElement != null)
            {
                return xDoc;
            } else
            {
                return null;
            }
        }

        public static XmlNode GetNodeByXPath(XmlDocument document, string xPath)
        {
            XmlNode root = document.DocumentElement;
            string namesp = root.NamespaceURI;

            if (!string.IsNullOrEmpty(namesp))
            {
                string pref = "a";
                var nsmgr = new XmlNamespaceManager(document.NameTable);
                nsmgr.AddNamespace(pref, namesp);
                return root.SelectSingleNode(pref + ":" + xPath, nsmgr);
            } else
            {
                return root.SelectSingleNode(xPath);
            }
        }
    }
}
