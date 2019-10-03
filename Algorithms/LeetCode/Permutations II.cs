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
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            // Similar to "46. Permutations".
            // For example: nums = [1,1,2]
            // When the first "1" is fixed and subResults have been permuted, we come to the second "1".
            // But we can skip this one, because it is completely the same with the first one.
            bool[] chosen = new bool[nums.Length];
            return PermuteUnique();

            IList<IList<int>> PermuteUnique()
            {
                var results = new List<IList<int>>();
                var permuted = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (chosen[i]) continue;
                    if (!permuted.Add(nums[i])) continue;
                    chosen[i] = true;
                    foreach (var subResult in PermuteUnique())
                    {
                        subResult.Add(nums[i]);
                        results.Add(subResult);
                    }
                    chosen[i] = false;
                }

                if (results.Count == 0) results.Add(new List<int>());
                return results;
            }
        }
    }
}
