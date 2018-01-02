using SubstanceProvider;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleInterface
{
    public class XmlConsoleInterface
    {
        String[] DefaultXpaths { get; set; }
        String SelectedXpath { get; set; }
        Dictionary<string, string> Folders { get; set; }
        XmlProvider Provider { get; set; }
        IEnumerable<KeyValuePair<string, int>> ParseResult { get; set; }

        public XmlConsoleInterface(String[] xpaths, String selectedFolder, int maxThreads, string fileExtension)
        {
            DefaultXpaths = xpaths;
            SelectedXpath = xpaths.Length > 0 ? xpaths[0] : "";

            Provider = new XmlProvider(maxThreads, selectedFolder, fileExtension);
        }
        public void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("Enter 'xpath' for select xPath, current {0}", SelectedXpath);
                Console.WriteLine("Enter 'parse' for parse folder");
                Console.WriteLine("Enter 'show' for show parse result");
                Console.WriteLine("Enter 'exit' for exit from menu");

                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "xpath":
                        SelectXpath();
                        break;
                    case "parse":
                        Parse();
                        break;
                    case "show":
                        Show();
                        break;
                    case "exit":
                        return;
                }
                Console.Clear();
            }
        }

        void SelectXpath()
        {
            int index = 0;
            foreach(String xpath in DefaultXpaths)
            {
                Console.WriteLine("Enter '{0}' for select {1}", index++, xpath);
            }
            Console.WriteLine("Or set own xPath");
            string command = Console.ReadLine();
            if (int.TryParse(command, out int indexElement) && indexElement < DefaultXpaths.Length)
            {
                SelectedXpath = DefaultXpaths[indexElement];
            } else
            {
                SelectedXpath = command;
            }
        }

        void Parse()
        {
            ParseResult = Provider.Parse(SelectedXpath);
        }

        void Show()
        {
            foreach (KeyValuePair<string, int> item in ParseResult)
            {
                Console.WriteLine(item.Key + ", " + item.Value);
            }
            Console.ReadKey();
        }
    }
}
