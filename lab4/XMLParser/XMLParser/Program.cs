using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Substance;
using ConsoleInterface;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileExtension = ConfigurationManager.AppSettings["fileExtension"];
            String folderPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["testXmlFolderPath"];
            String[] defaultPaths = new String[]
            {
                ConfigurationManager.AppSettings["liteXPath"],
                ConfigurationManager.AppSettings["strongXPath"],
            };
            String folder = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["liteXmlFolderPath"];
            int maxThreads = int.Parse(ConfigurationManager.AppSettings["maxThreads"]);

            XmlConsoleInterface xmlInterface = new XmlConsoleInterface(defaultPaths, folder, maxThreads, fileExtension);
            xmlInterface.StartMenu();
        }
    }
}
