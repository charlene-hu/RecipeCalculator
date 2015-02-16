using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public class Helper
    {
        public static decimal RoundToSevenCent(decimal number)
        {
            if (number == 0)
            {
                return 0;
            }
            var num = number * 100;
            int hund = Math.Abs((int)num / 100);
            int unit = Math.Abs((int)num % 100);
            if (unit % 7 != 0)
            {
                int dig = 7 - unit % 7;
                if (num > 0)
                {
                    unit = unit + dig;
                }
                else
                {
                    unit = unit - unit % 7;
                }
            }
            decimal result = num > 0 ? (decimal)(hund * 100 + unit) / 100 :
               -1 * (decimal)(hund * 100 + unit) / 100;
            return result;
        }
    }
} 