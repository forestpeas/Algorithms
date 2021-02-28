using System;

namespace Algorithms.LeetCode
{
    /* 611. Valid Triangle Number
     * 
     * Given an array consists of non-negative integers, your task is to count the number of triplets
     * chosen from the array that can make triangles if we take them as side lengths of a triangle.
     * 
     * Example 1:
     * 
     * Input: [2,2,3,4]
     * Output: 3
     * Explanation:
     * Valid combinations are: 
     * 2,3,4 (using the first 2)
     * 2,3,4 (using the second 2)
     * 2,2,3
     */
    public class Valid_Triangle_Number
    {
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int res = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                int lo = 0, hi = i - 1;
                while (lo < hi)
                {
                    if (nums[lo] + nums[hi] > nums[i])
                    {
                        res += hi - lo;
                        hi--;
                    }
                    else
                    {
                        lo++;
                    }
                }
            }
            return res;
        }

        public int TriangleNumber2(int[] nums)
        {
            // brute-force
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int lo = Math.Abs(nums[i] - nums[j]);
                    int hi = nums[i] + nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[k] > lo && nums[k] < hi)
                        {
                            res++;
                        }
                    }
                }
            }
            return res;
        }
    }
}
