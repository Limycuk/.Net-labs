using System;
using System.Collections.Generic;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substance;

namespace UnitTestTree
{
    [TestClass]
    public class UnitTestNumberTree
    {
        [TestInitialize]
        public void Initialize()
        {
            List<int> numbers = new List<int> { 6, 9, 5, 8, 2 };
            NumberComparer numberComparer = new NumberComparer();
            NumberTree = new Tree<int>(numberComparer);

            foreach (int number in numbers)
            {
                NumberTree.Add(number);
            }
        }
        Tree<int> NumberTree { get; set; }

        [TestMethod]
        public void TestPreorder()
        {
            List<int> expectedPreorder = new List<int> { 6, 5, 2, 9, 8 };
            int i = 0;
            foreach (int number in NumberTree.Preorder())
            {
                Assert.AreEqual(expectedPreorder[i++], number);
            }
        }

        [TestMethod]
        public void TestInorder()
        {
            List<int> expectedInorder = new List<int> { 2, 5, 6, 8, 9 };
            int i = 0;
            foreach (int number in NumberTree.Inorder())
            {
                Assert.AreEqual(expectedInorder[i++], number);
            }
        }

        [TestMethod]
        public void TestPostorder()
        {
            List<int> expectedPostorder = new List<int> { 2, 5, 8, 9, 6 };
            int i = 0;
            foreach (int number in NumberTree.Postorder())
            {
                Assert.AreEqual(expectedPostorder[i++], number);
            }
        }
    }
}
