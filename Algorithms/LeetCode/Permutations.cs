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
        private readonly HashSet<int> fixedIndexes = new HashSet<int>();

        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == fixedIndexes.Count) return new List<int>[] { new List<int>() };
            var results = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (fixedIndexes.Contains(i)) continue;
                fixedIndexes.Add(i);
                foreach (var subResult in Permute(nums))
                {
                    subResult.Add(nums[i]);
                    results.Add(subResult);
                }
                fixedIndexes.Remove(i);
            }
            return results;
        }
    }
}
