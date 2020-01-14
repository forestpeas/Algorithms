using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1313. Decompress Run-Length Encoded List
     * 
     * We are given a list nums of integers representing a list compressed with run-length encoding.
     * 
     * Consider each adjacent pair of elements [a, b] = [nums[2*i], nums[2*i+1]] (with i >= 0). 
     * For each such pair, there are a elements with value b in the decompressed list.
     * 
     * Return the decompressed list.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3,4]
     * Output: [2,4,4,4]
     */
    public class Decompress_Run_Length_Encoded_List
    {
        public int[] DecompressRLElist(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length / 2; i++)
            {
                for (int j = 0; j < nums[2 * i]; j++)
                {
                    result.Add(nums[2 * i + 1]);
                }
            }
            return result.ToArray();
        }
    }
}
