using BinaryTree;
using Substance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 6, 9, 5, 8, 2 };
            NumberComparer numberComparer = new NumberComparer();
            Tree<int> numberTree = new Tree<int>(numberComparer);
            foreach(int item in numbers)
            {
                numberTree.Add(item);
            }
            foreach(int t in numberTree)
            {
                Console.WriteLine(t);
            }
            Console.ReadKey();
        }
    }
}
