using System;

namespace Algorithms.LeetCode
{
    /* 1362. Closest Divisors
     * 
     * Given an integer num, find the closest two integers in absolute difference whose product equals num + 1 or num + 2.
     * 
     * Return the two integers in any order.
     * 
     * Example 1:
     * 
     * Input: num = 8
     * Output: [3,3]
     * Explanation: For num + 1 = 9, the closest divisors are 3 & 3, for num + 2 = 10, the closest divisors are 2 & 5, hence 3 & 3 is chosen.
     * 
     * Example 2:
     * 
     * Input: num = 123
     * Output: [5,25]
     * 
     * Example 3:
     * 
     * Input: num = 999
     * Output: [40,25]
     */
    public class Closest_Divisors
    {
        public int[] ClosestDivisors(int num)
        {
            // Search the factor from square root to 1.
            int[] res1 = ClosestDivisorsCore(num + 1);
            int[] res2 = ClosestDivisorsCore(num + 2);
            if (Math.Abs(res1[0] - res1[1]) < Math.Abs(res2[0] - res2[1])) return res1;
            return res2;
        }

        public int[] ClosestDivisorsCore(int num)
        {
            int sqr = (int)Math.Sqrt(num);
            while (num % sqr != 0)
            {
                sqr--;
            }

            return new int[] { sqr, num / sqr };
        }
    }
}
