using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1399. Count Largest Group
     * 
     * Given an integer n. Each number from 1 to n is grouped according to the sum of its digits. 
     * 
     * Return how many groups have the largest size.
     * 
     * Example 1:
     * 
     * Input: n = 13
     * Output: 4
     * Explanation: There are 9 groups in total, they are grouped according sum of its digits of numbers
     * from 1 to 13:
     * [1,10], [2,11], [3,12], [4,13], [5], [6], [7], [8], [9]. There are 4 groups with largest size.
     * 
     * Example 2:
     * 
     * Input: n = 2
     * Output: 2
     * Explanation: There are 2 groups [1], [2] of size 1.
     */
    public class Count_Largest_Group
    {
        public int CountLargestGroup(int n)
        {
            var counts = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                int digitSum = GetDigitSum(i);
                counts[digitSum] = counts.GetValueOrDefault(digitSum) + 1;
            }

            int maxCount = counts.Values.Max();
            return counts.Count(c => c.Value == maxCount);
        }

        private int GetDigitSum(int i)
        {
            return i == 0 ? 0 : (i % 10 + GetDigitSum(i / 10));
        }
    }
}
