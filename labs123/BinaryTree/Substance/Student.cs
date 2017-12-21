using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substance
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public int Mark { get; set; }
    }

    public class StudentComparer : Comparer<Student>
    {
        public override int Compare(Student firstStudent, Student secondStudent)
        {
            int result = 0;

            if (firstStudent.Mark > secondStudent.Mark)
            {
                result = 1;
            }
            else if (firstStudent.Mark < secondStudent.Mark)
            {
                result = -1;
            }

            return result;
        }
    }
}
