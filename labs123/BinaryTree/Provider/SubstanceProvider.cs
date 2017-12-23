using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryTree;

namespace Provider
{
    public class SubstanceProvider<T>
    {
        public SubstanceProvider(Comparer<T> comparer)
        {
            SubstanceTree = new Tree<T>(comparer);
        }

        Tree<T> SubstanceTree { get; set; }
        public String SortField { private get; set; } = "FirstName";
        public String SortType { private get; set; } = "ASC";
        public List<Func<T, bool>> Filters = new List<Func<T, bool>>();
        public void Add(T item)
        {
            SubstanceTree.Add(item);
        }

        public void Save(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            foreach(T item in SubstanceTree)
            {
                bf.Serialize(stream, item);
            }
            stream.Close();
        }

        public void Load(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            while (stream.Position < stream.Length)
            {
                SubstanceTree.Add((T)bf.Deserialize(stream));
            }
            stream.Close();
        }

        public IEnumerable<T> Show()
        {
            IEnumerable<T> query = SubstanceTree;
            foreach (Func<T, bool> filter in Filters)
            {
                query = query.Where(filter);
            }

            if (SortType == "ASC")
            {
                query = query.OrderBy(item => item.GetType().GetProperty(SortField).GetValue(item, null));
            }
            else
            {
                query = query.OrderByDescending(item => item.GetType().GetProperty(SortField).GetValue(item, null));
            }
            return query;
            return SubstanceTree;
        }
    }
}
