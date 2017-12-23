using System;
using System.Collections.Generic;
using System.Text;

namespace Comparer
{
    public class StringComparer : Comparer<string>
    {
        public override int Compare(string firstString, string secondString)
        {
            int result = 0;

            if (String.Compare(firstString, secondString) > 0)
            {
                result = 1;
            }
            else if (String.Compare(firstString, secondString) < 0)
            {
                result = -1;
            }

            return result;
        }
    }
}
