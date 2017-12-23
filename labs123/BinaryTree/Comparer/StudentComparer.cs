using System;
using System.Collections.Generic;
using System.Text;
using Substance;

namespace Comparer
{
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
