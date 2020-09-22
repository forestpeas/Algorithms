using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 442. Find All Duplicates in an Array
     * 
     * Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice
     * and others appear once.
     * 
     * Find all the elements that appear twice in this array.
     * 
     * Could you do it without extra space and in O(n) runtime?
     * 
     * Example:
     * Input:
     * [4,3,2,7,8,2,3,1]
     * 
     * Output:
     * [2,3]
     */
    public class Find_All_Duplicates_in_an_Array
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i] - 1)
                {
                    int num = nums[i];
                    nums[i] = 0; // 0 means "empty slot".
                    while (num != 0 && num != nums[num - 1])
                    {
                        int tmp = nums[num - 1];
                        nums[num - 1] = num;
                        num = tmp;
                    }
                    if (num != 0) res.Add(num);
                }
            }
            return res;
        }

        public IList<int> FindDuplicates2(int[] nums)
        {
            var res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int idx = Math.Abs(nums[i]) - 1;
                if (nums[idx] < 0)
                    res.Add(idx + 1);
                nums[idx] = -nums[idx];
            }
            return res;
        }
    }
}
