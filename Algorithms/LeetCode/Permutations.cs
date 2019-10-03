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
            // Backtracking.
            // For example: nums = [1,2,3]
            // 1.we have to choose one number from [1,2,3]. We choose 1 and 1 is fixed.
            // 2.we have to choose one number from [2,3]. we choose 2 and [1,2] are fixed.
            // 3.we choose 3 because it is all that it left, so we get a result: [1,2,3].
            // Then we backtrack to the second step and choose 3 so that [1,3] are fixed.
            // ...
            bool[] chosen = new bool[nums.Length];
            return Permute();

            IList<IList<int>> Permute()
            {
                var results = new List<IList<int>>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (chosen[i]) continue;
                    chosen[i] = true;
                    foreach (var subResult in Permute())
                    {
                        subResult.Add(nums[i]); // Adding to tail is equivalent to adding to head.
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
