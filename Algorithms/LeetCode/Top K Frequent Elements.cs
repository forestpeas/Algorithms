using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 347. Top K Frequent Elements
     * 
     * Given a non-empty array of integers, return the k most frequent elements.
     * 
     * Example 1:
     * 
     * Input: nums = [1,1,1,2,2,3], k = 2
     * Output: [1,2]
     * 
     * Example 2:
     * 
     * Input: nums = [1], k = 1
     * Output: [1]
     * 
     * Note:
     * You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
     * Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
     */
    public class TopKFrequentElements
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var frequencyMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                frequencyMap[num] = frequencyMap.GetValueOrDefault(num, 0) + 1;
            }

            // bucket's index is frequency, e.g. bucket[3] contains the numbers that appear 3 times.
            var bucket = new List<int>[nums.Length + 1];
            foreach (var item in frequencyMap)
            {
                if (bucket[item.Value] == null)
                {
                    bucket[item.Value] = new List<int>();
                }
                bucket[item.Value].Add(item.Key);
            }

            var result = new List<int>(k);
            for (int i = bucket.Length - 1; i >= 0; i--)
            {
                if (bucket[i] != null)
                {
                    foreach (int num in bucket[i])
                    {
                        result.Add(num);
                        if (result.Count == k) return result;
                    }
                }
            }

            return null; // k is invalid.
        }
    }
}
