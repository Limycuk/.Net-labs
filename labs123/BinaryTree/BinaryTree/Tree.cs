using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree<T> : IEnumerable<T>
    {
        Comparer<T> Comporator { set; get; }
        private TreeItem<T> BinaryTree { get; set; }
        public Tree(Comparer<T> comparator)
        {
            Comporator = comparator;
        }

        class TreeItem<Z>
        {
            public Z Element { get; set; }
            public TreeItem<Z> LeftChild { get; set; }
            public TreeItem<Z> RightChild { get; set; }
        }

        private bool IsEmpty()
        {
            return BinaryTree == null;
        }

        public void Add(T data)
        {
            if (this.IsEmpty())
            {
                TreeItem<T> node = new TreeItem<T> { Element = data };
                BinaryTree = node;
            }
            else
            {
                Add(BinaryTree, data);
            }
        }
        void Add(TreeItem<T> currentNode, T data)
        {
            int result = Comporator.Compare(currentNode.Element, data);
            if (result > 0 && currentNode.LeftChild == null)
            {
                TreeItem<T> newNode = new TreeItem<T>() { Element = data };
                currentNode.LeftChild = newNode;
            }
            else if (result > 0)
            {
                Add(currentNode.LeftChild, data);
            }
            else if (result < 0 && currentNode.RightChild == null)
            {
                TreeItem<T> newNode = new TreeItem<T>() { Element = data };
                currentNode.RightChild = newNode;
            }
            else if (result < 0)
            {
                Add(currentNode.RightChild, data);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Preorder(BinaryTree)) yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Preorder()
        {
            foreach (T item in Preorder(BinaryTree)) yield return item;
        }

        IEnumerable<T> Preorder(TreeItem<T> node)
        {
            if (node != null)
            {
                yield return node.Element;
                foreach (T item in Preorder(node.LeftChild)) yield return item;
                foreach (T item in Preorder(node.RightChild)) yield return item;
            }
        }

        public IEnumerable Inorder()
        {
            foreach (T item in Inorder(BinaryTree)) yield return item;
        }

        IEnumerable Inorder(TreeItem<T> node)
        {
            if (node != null)
            {
                foreach (T item in Inorder(node.LeftChild)) yield return item;
                yield return node.Element;
                foreach (T item in Inorder(node.RightChild)) yield return item;
            }
        }

        public IEnumerable Postorder()
        {
            foreach (T item in Postorder(BinaryTree)) yield return item;
        }

        IEnumerable Postorder(TreeItem<T> node)
        {
            if (node != null)
            {
                foreach (T item in Postorder(node.LeftChild)) yield return item;
                foreach (T item in Postorder(node.RightChild)) yield return item;
                yield return node.Element;
            }
        }
    }
}
