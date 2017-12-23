using System;
using System.Collections.Generic;
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

        public void Add(T item)
        {
            SubstanceTree.Add(item);
        }
    }
}
