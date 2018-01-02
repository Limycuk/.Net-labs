using Substance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;

namespace SubstanceProvider
{
    public class XmlProvider
    {
        int MaxThreads { get; set; }
        string Folder { get; set; }
        string Regular { get; set; }
        static string NA { get; } = "N/A";

        Dictionary<string, int> ParseResult { get; set; }
        public XmlProvider (int maxThreads, string folder, string regular)
        {
            MaxThreads = maxThreads;
            Folder = folder;
            Regular = regular;
        }
        public IEnumerable<KeyValuePair<string, int>> Parse(string xPath)
        {
            List<XmlDocument> documents = GetValideXmlDocuments();
            ParseDocuments(documents, xPath);
            return from item in ParseResult orderby item.Value descending select item;
        }

        List<XmlDocument> GetValideXmlDocuments()
        {
            List<XmlDocument> documents = new List<XmlDocument>();

            Parallel.ForEach(Directory.GetFiles(Folder, Regular), new ParallelOptions { MaxDegreeOfParallelism = MaxThreads }, (file) =>
            {
                XmlDocument doc = XML.GetValideDocument(file);
                if (doc != null)
                {
                    lock (documents)
                    {
                        documents.Add(doc);
                    }
                }
            });

            return documents;
        }

        void ParseDocuments(List<XmlDocument> documents, string xPath)
        {
            ParseResult = new Dictionary<string, int>();
            string nodeContent;

            Parallel.ForEach(documents, new ParallelOptions { MaxDegreeOfParallelism = MaxThreads }, (xml) =>
            {
                XmlNode node = XML.GetNodeByXPath(xml, xPath);
                lock (ParseResult)
                {
                    nodeContent = node != null ? node.InnerXml : XmlProvider.NA;
                    if (ParseResult.ContainsKey(nodeContent))
                    {
                        ParseResult[nodeContent]++;
                    } else
                    {
                        ParseResult.Add(nodeContent, 1);
                    }
                }
            });
        }
    }
}
