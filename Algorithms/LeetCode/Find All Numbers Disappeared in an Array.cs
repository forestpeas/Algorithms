using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 448. Find All Numbers Disappeared in an Array
     * 
     * Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array).
     * 
     * Find all the elements of [1, n] inclusive that do not appear in this array.
     * 
     * Could you do it without extra space and in O(n) runtime? You may assume the returned list does
     * not count as extra space.
     * 
     * Example:
     * 
     * Input:
     * [4,3,2,7,8,2,3,1]
     * 
     * Output:
     * [5,6]
     */
    public class FindAllNumbersDisappearedInAnArray
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            // Put num[i] in nums[num[i] - 1]. Similar to "41. First Missing Positive".
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i] - 1)
                {
                    int num = nums[i];
                    while (nums[num - 1] != num)
                    {
                        int next = nums[num - 1];
                        nums[num - 1] = num;
                        num = next;
                    }
                }
            }

            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i] - 1)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }
    }
}
