using System;
using System.Collections.Generic;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substance;

namespace UnitTestTree
{
    [TestClass]
    public class UnitTestPointTree
    {
        [TestInitialize]
        public void Initialize()
        {
            List<Point> points = new List<Point>{
                new Point(){ X = 6, Y = 5 },
                new Point(){ X = 1, Y = 4 },
                new Point(){ X = 2, Y = 7 },
                new Point(){ X = 6, Y = 6 },
                new Point(){ X = 3, Y = 3 },
            };

            PointComparer pointComparer = new PointComparer();
            PointTree = new Tree<Point>(pointComparer);

            foreach (Point point in points)
            {
                PointTree.Add(point);
            }
        }
        Tree<Point> PointTree { get; set; }

        bool Equals(Point expected, Point actual)
        {
            return expected.X.Equals(actual.X)
                   && expected.Y.Equals(actual.Y);
        }

        [TestMethod]
        public void TestPreorder()
        {
            List<Point> expectedPreorder = new List<Point>{
                new Point(){ X = 6, Y = 5 },
                new Point(){ X = 1, Y = 4 },
                new Point(){ X = 2, Y = 7 },
                new Point(){ X = 3, Y = 3 },
                new Point(){ X = 6, Y = 6 },
            };
            int i = 0;
            foreach (Point point in PointTree.Preorder())
            {
                Assert.AreEqual(Equals(expectedPreorder[i++], point), true);
            }
        }

        [TestMethod]
        public void TestInorder()
        {
            List<Point> expectedInorder = new List<Point>{
                new Point(){ X = 1, Y = 4 },
                new Point(){ X = 3, Y = 3 },
                new Point(){ X = 2, Y = 7 },
                new Point(){ X = 6, Y = 5 },
                new Point(){ X = 6, Y = 6 },
            };
            int i = 0;
            foreach (Point point in PointTree.Inorder())
            {
                Assert.AreEqual(Equals(expectedInorder[i++], point), true);
            }
        }

        [TestMethod]
        public void TestPostorder()
        {
            List<Point> expectedPostorder = new List<Point>{
                new Point(){ X = 3, Y = 3 },
                new Point(){ X = 2, Y = 7 },
                new Point(){ X = 1, Y = 4 },
                new Point(){ X = 6, Y = 6 },
                new Point(){ X = 6, Y = 5 },
            };
            int i = 0;
            foreach (Point point in PointTree.Postorder())
            {
                Assert.AreEqual(Equals(expectedPostorder[i++], point), true);
            }
        }
    }
}
