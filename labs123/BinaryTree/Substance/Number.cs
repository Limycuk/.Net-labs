using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substance
{
    public class NumberComparer : Comparer<int>
    {
        public override int Compare(int firstNumber, int secondNumber)
        {
            int result = 0;

            if (firstNumber > secondNumber)
            {
                result = 1;
            }
            else if (firstNumber < secondNumber)
            {
                result = -1;
            }

            return result;
        }
    }
}
