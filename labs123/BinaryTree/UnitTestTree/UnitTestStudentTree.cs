using System;
using System.Collections.Generic;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substance;

namespace UnitTestTree
{
    [TestClass]
    public class UnitTestStudentTree
    {
        [TestInitialize]
        public void Initialize()
        {
            List<Student> students = new List<Student>{
                new Student(){ FirstName="Dima", LastName="Semenov", TestName="Math", Mark=7 },
                new Student(){ FirstName="Sasha", LastName="Smirnov", TestName="Math", Mark=10 },
                new Student(){ FirstName="Gena", LastName="Kidaev", TestName="Math", Mark=5 },
                new Student(){ FirstName="Rita", LastName="Krasina", TestName="Math", Mark=8 },
                new Student(){ FirstName="Dasha", LastName="Lotvin", TestName="Math", Mark=6 },
            };

            StudentComparer studentComparer = new StudentComparer();
            StudentTree = new Tree<Student>(studentComparer);

            foreach (Student student in students)
            {
                StudentTree.Add(student);
            }
        }
        Tree<Student> StudentTree { get; set; }

        bool Equals(Student expected, Student actual)
        {
            return expected.FirstName.Equals(actual.FirstName)
                   && expected.LastName.Equals(actual.LastName)
                   && expected.TestName.Equals(actual.TestName)
                   && expected.Mark.Equals(actual.Mark);
        }

        [TestMethod]
        public void TestPreorder()
        {
            List<Student> expectedPreorder = new List<Student> {
                new Student(){ FirstName="Dima", LastName="Semenov", TestName="Math", Mark=7 },
                new Student(){ FirstName="Gena", LastName="Kidaev", TestName="Math", Mark=5 },
                new Student(){ FirstName="Dasha", LastName="Lotvin", TestName="Math", Mark=6 },
                new Student(){ FirstName="Sasha", LastName="Smirnov", TestName="Math", Mark=10 },
                new Student(){ FirstName="Rita", LastName="Krasina", TestName="Math", Mark=8 },
            };
            int i = 0;
            foreach (Student student in StudentTree.Preorder())
            {
                Assert.AreEqual(Equals(expectedPreorder[i++], student), true);
            }
        }

        [TestMethod]
        public void TestInorder()
        {
            List<Student> expectedInorder = new List<Student>{
                new Student(){ FirstName="Gena", LastName="Kidaev", TestName="Math", Mark=5 },
                new Student(){ FirstName="Dasha", LastName="Lotvin", TestName="Math", Mark=6 },
                new Student(){ FirstName="Dima", LastName="Semenov", TestName="Math", Mark=7 },
                new Student(){ FirstName="Rita", LastName="Krasina", TestName="Math", Mark=8 },
                new Student(){ FirstName="Sasha", LastName="Smirnov", TestName="Math", Mark=10 },
            };
            int i = 0;
            foreach (Student student in StudentTree.Inorder())
            {
                Assert.AreEqual(Equals(expectedInorder[i++], student), true);
            }
        }

        [TestMethod]
        public void TestPostorder()
        {
            List<Student> expectedPostorder = new List<Student>{
                new Student(){ FirstName="Dasha", LastName="Lotvin", TestName="Math", Mark=6 },
                new Student(){ FirstName="Gena", LastName="Kidaev", TestName="Math", Mark=5 },
                new Student(){ FirstName="Rita", LastName="Krasina", TestName="Math", Mark=8 },
                new Student(){ FirstName="Sasha", LastName="Smirnov", TestName="Math", Mark=10 },
                new Student(){ FirstName="Dima", LastName="Semenov", TestName="Math", Mark=7 },
            };
            int i = 0;
            foreach (Student student in StudentTree.Postorder())
            {
                Assert.AreEqual(Equals(expectedPostorder[i++], student), true);
            }
        }
    }
}
