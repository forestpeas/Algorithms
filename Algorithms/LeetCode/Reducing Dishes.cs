﻿using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1402. Reducing Dishes
     * 
     * A chef has collected data on the satisfaction level of his n dishes. Chef can cook any
     * dish in 1 unit of time.
     * 
     * Like-time coefficient of a dish is defined as the time taken to cook that dish including
     * previous dishes multiplied by its satisfaction level  i.e.  time[i]*satisfaction[i]
     * 
     * Return the maximum sum of Like-time coefficient that the chef can obtain after dishes
     * preparation.
     * 
     * Dishes can be prepared in any order and the chef can discard some dishes to get this
     * maximum value.
     * 
     * Example 1:
     * 
     * Input: satisfaction = [-1,-8,0,5,-9]
     * Output: 14
     * Explanation: After Removing the second and last dish, the maximum total Like-time coefficient
     * will be equal to (-1*1 + 0*2 + 5*3 = 14). Each dish is prepared in one unit of time.
     * 
     * Example 2:
     * 
     * Input: satisfaction = [4,3,2]
     * Output: 20
     * Explanation: Dishes can be prepared in any order, (2*1 + 3*2 + 4*3 = 20)
     * 
     * Example 3:
     * 
     * Input: satisfaction = [-1,-4,-5]
     * Output: 0
     * Explanation: People don't like the dishes. No dish is prepared.
     * 
     * Example 4:
     * 
     * Input: satisfaction = [-2,5,-1,0,3,-3]
     * Output: 35
     */
    public class Reducing_Dishes
    {
        public int MaxSatisfaction(int[] nums)
        {
            // Greedy. For example, nums = [-9,-8,-1,0,5].
            // First, 0*1 + 5*2 = 10 is the largest result we can get.
            // Then, if we append a number to the left, all the coefficient is increased by 1,
            // so the result is increased by (0+5). If we want this increase to beat the
            // decrease introduced by the appended number, we have to make sure (0+5) > 1.
            int sumUnit = 0, res = 0, i = 1;
            foreach (int num in nums.Where(n => n >= 0).OrderBy(n => n))
            {
                sumUnit += num;
                res += num * i;
                i++;
            }
            int[] negs = nums.Where(n => n < 0).OrderByDescending(n => n).ToArray();
            foreach (int neg in negs)
            {
                if (sumUnit + neg > 0)
                {
                    sumUnit = sumUnit + neg;
                    res += sumUnit;
                }
                else break;
            }
            return res;
        }
    }
}