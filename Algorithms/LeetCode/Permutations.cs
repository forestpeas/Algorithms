using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 46. Permutations
     * 
     * Given a collection of distinct integers, return all possible permutations.
     * 
     * Example:
     * 
     * Input: [1,2,3]
     * Output:
     * [
     *   [1,2,3],
     *   [1,3,2],
     *   [2,1,3],
     *   [2,3,1],
     *   [3,1,2],
     *   [3,2,1]
     * ]
     */
    public class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == 1) return new List<int>[] { new List<int>() { nums[0] } };
            var results = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int[] subNums = new int[nums.Length - 1];
                for (int j = 0, k = 0; j < nums.Length; j++)
                {
                    if (j != i)
                    {
                        subNums[k] = nums[j];
                        k++;
                    }
                }
                foreach (var subResult in Permute(subNums))
                {
                    subResult.Add(nums[i]);
                    results.Add(subResult);
                }
            }
            return results;
        }
    }
}
