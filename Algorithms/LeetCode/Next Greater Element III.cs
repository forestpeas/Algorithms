using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 556. Next Greater Element III
     * 
     * Given a positive integer n, find the smallest integer which has exactly the same digits
     * existing in the integer n and is greater in value than n. If no such positive integer
     * exists, return -1.
     * 
     * Note that the returned integer should fit in 32-bit integer, if there is a valid answer
     * but it does not fit in 32-bit integer, return -1. 
     * 
     * Example 1:
     * 
     * Input: n = 12
     * Output: 21
     * 
     * Example 2:
     * 
     * Input: n = 21
     * Output: -1
     */
    public class Next_Greater_Element_III
    {
        public int NextGreaterElement(int n)
        {
            // same as "31. Next Permutation"
            char[] digits = n.ToString().ToCharArray();
            long res = long.MaxValue;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (digits[j] < digits[i])
                    {
                        res = Math.Min(res, Swap(i, j));
                        break;
                    }
                }
            }
            return res <= int.MaxValue ? (int)res : -1;

            long Swap(int i, int j)
            {
                var copy = digits.ToArray();
                copy[i] = digits[j];
                copy[j] = digits[i];
                Array.Sort(copy, j + 1, digits.Length - j - 1); // or reverse them since they are in descending order
                return long.TryParse(copy, out long num) ? num : long.MaxValue;
            }
        }
    }
}
