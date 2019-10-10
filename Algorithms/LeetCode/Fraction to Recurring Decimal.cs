using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 166. Fraction to Recurring Decimal
     * 
     * Given two integers representing the numerator and denominator of a fraction,
     * return the fraction in string format.
     * 
     * If the fractional part is repeating, enclose the repeating part in parentheses.
     * 
     * Example 1:
     * 
     * Input: numerator = 1, denominator = 2
     * Output: "0.5"
     * 
     * Example 2:
     * 
     * Input: numerator = 2, denominator = 1
     * Output: "2"
     * 
     * Example 3:
     * 
     * Input: numerator = 2, denominator = 3
     * Output: "0.(6)"
     */
    public class FractionToRecurringDecimal
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            // Just like doing division in elementary school.
            // For example, 1 / 333
            // 
            //       0.003
            // 333 / 1.000
            //       -----
            //         999
            //       -----
            //           1 ← the "numerator" becomes 1 again!
            if (numerator == 0) return "0";
            var result = new StringBuilder();
            if ((numerator < 0) ^ (denominator < 0)) result.Append('-');
            long n = Math.Abs((long)numerator);
            long d = Math.Abs((long)denominator);

            // Deal with cases where numerator > denominator.
            result.Append(n / d);
            n = n % d;
            if (n == 0) return result.ToString();
            result.Append('.');

            // map contains visited "numerators" and their corresponding positions in the result string.
            var map = new Dictionary<long, int>();
            while (n != 0)
            {
                if (!map.TryAdd(n, result.Length)) // Found a repeating "numerator"!
                {
                    result.Insert(map[n], '(');
                    result.Append(')');
                    break;
                }
                n = n * 10;
                long digit = n < d ? 0 : n / d;
                result.Append(digit);
                n = n % d;
            }
            return result.ToString();
        }
    }
}
