using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 202. Happy Number
     * 
     * Write an algorithm to determine if a number is "happy".
     * 
     * A happy number is a number defined by the following process: Starting with any positive integer,
     * replace the number by the sum of the squares of its digits, and repeat the process until the number
     * equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those
     * numbers for which this process ends in 1 are happy numbers.
     * 
     * Example: 
     * 
     * Input: 19
     * Output: true
     * Explanation: 
     * 12 + 92 = 82
     * 82 + 22 = 68
     * 62 + 82 = 100
     * 12 + 02 + 02 = 1
     */
    public class HappyNumber
    {
        public bool IsHappy(int n)
        {
            var set = new HashSet<int>();
            while (set.Add(n))
            {
                int sum = 0;
                while (n != 0)
                {
                    int digit = n % 10;
                    sum += digit * digit;
                    n = n / 10;
                }

                if (sum == 1) return true;
                n = sum;
            }

            return false;
        }
    }
}
