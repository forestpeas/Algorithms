using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 216. Combination Sum III
     * 
     * Find all possible combinations of k numbers that add up to a number n,
     * given that only numbers from 1 to 9 can be used and each combination
     * should be a unique set of numbers.
     * 
     * Note:
     * 
     * All numbers will be positive integers.
     * The solution set must not contain duplicate combinations.
     * Example 1:
     * 
     * Input: k = 3, n = 7
     * Output: [[1,2,4]]
     * 
     * Example 2:
     * 
     * Input: k = 3, n = 9
     * Output: [[1,2,6], [1,3,5], [2,3,4]]
     */
    public class CombinationSumIII
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            // Backtracking.
            var result = new List<IList<int>>();
            CombinationSum(0, 1, 0, new int[k]);
            return result;

            void CombinationSum(int idx, int start, int sum, int[] nums)
            {
                if (idx == nums.Length - 1)
                {
                    int lastNum = n - sum;
                    if (lastNum >= start && lastNum <= 9)
                    {
                        int[] copy = nums.ToArray();
                        copy[idx] = lastNum;
                        result.Add(copy);
                    }
                    return;
                }

                for (int i = start; i <= 9; i++)
                {
                    if (sum + i >= n) return;
                    nums[idx] = i;
                    CombinationSum(idx + 1, i + 1, sum + i, nums);
                }
            }
        }
    }
}
