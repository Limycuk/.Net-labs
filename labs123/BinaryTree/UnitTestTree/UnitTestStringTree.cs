using System;
using System.Collections.Generic;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTree
{
    [TestClass]
    public class UnitTestStringTree
    {
        [TestInitialize]
        public void Initialize()
        {
            List<string> strings = new List<string> { "d", "a", "f", "b", "c" };
            Substance.StringComparer stringComparer = new Substance.StringComparer();
            StringTree = new Tree<string>(stringComparer);

            foreach (string item in strings)
            {
                StringTree.Add(item);
            }
        }

        Tree<string> StringTree { get; set; }

        [TestMethod]
        public void TestPreorder()
        {
            List<string> expectedPreorder = new List<string> { "d", "a", "b", "c", "f" };
            int i = 0;
            foreach (string item in StringTree.Preorder())
            {
                Assert.AreEqual(expectedPreorder[i++], item);
            }
        }

        [TestMethod]
        public void TestInorder()
        {
            List<string> expectedInorder = new List<string> { "a", "b", "c", "d", "f" };
            int i = 0;
            foreach (string item in StringTree.Inorder())
            {
                Assert.AreEqual(expectedInorder[i++], item);
            }
        }

        [TestMethod]
        public void TestPostorder()
        {
            List<string> expectedPostorder = new List<string> { "c", "b", "a", "f", "d" };
            int i = 0;
            foreach (string item in StringTree.Postorder())
            {
                Assert.AreEqual(expectedPostorder[i++], item);
            }
        }
    }
}
