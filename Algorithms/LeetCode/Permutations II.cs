using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 47. Permutations II
     * 
     * Given a collection of numbers that might contain duplicates, return all possible unique permutations.
     * 
     * Example:
     * 
     * Input: [1,1,2]
     * Output:
     * [
     *   [1,1,2],
     *   [1,2,1],
     *   [2,1,1]
     * ]
     */
    public class PermutationsII
    {
        private readonly HashSet<int> fixedIndexes = new HashSet<int>();

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            // Similar to "46. Permutations".
            // For example: nums = [1,1,2]
            // When the first "1" is fixed and subResults are permuted, we come to the second "1".
            // But we can skip this one, because it is completely the same with the first one.
            if (nums.Length == fixedIndexes.Count) return new List<int>[] { new List<int>() };
            var results = new List<IList<int>>();
            var permuted = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (fixedIndexes.Contains(i)) continue;
                if (!permuted.Add(nums[i])) continue;
                fixedIndexes.Add(i);
                foreach (var subResult in PermuteUnique(nums))
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
