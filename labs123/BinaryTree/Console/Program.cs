using ConsoleSubstanceInterface;
using System;
using System.Configuration;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            String defaultFilePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\file.bin";
            ConsoleStudentInterface studentInterface = new ConsoleStudentInterface(defaultFilePath);
            studentInterface.StartMenu();
        }
    }
}
