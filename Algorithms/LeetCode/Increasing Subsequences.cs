using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 491. Increasing Subsequences
     * 
     * Given an integer array, your task is to find all the different possible increasing subsequences
     * of the given array, and the length of an increasing subsequence should be at least 2. 
     * 
     * Example:
     * 
     * Input: [4, 6, 7, 7]
     * Output: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7], [4,7,7]]
     */
    public class Increasing_Subsequences
    {
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            // Result must not contain duplicates.
            var res = new List<IList<int>>();
            Find(0, new List<int>());
            return res;

            void Find(int i, List<int> seq)
            {
                if (i == nums.Length)
                {
                    if (seq.Count > 1) res.Add(seq.ToArray());
                    return;
                }
                if (seq.Count == 0 || nums[i] != seq[^1])
                {
                    Find(i + 1, seq);
                }
                if (seq.Count == 0 || nums[i] >= seq[^1])
                {
                    seq.Add(nums[i]);
                    Find(i + 1, seq);
                    seq.RemoveAt(seq.Count - 1);
                }
            }
        }
    }
}
