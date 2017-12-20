﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substance
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
