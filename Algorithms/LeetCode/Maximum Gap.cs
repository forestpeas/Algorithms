using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 164. Maximum Gap
     * 
     * Given an unsorted array, find the maximum difference between the successive elements in its sorted form.
     * 
     * Return 0 if the array contains less than 2 elements.
     * 
     * Example 1:
     * 
     * Input: [3,6,9,1]
     * Output: 3
     * Explanation: The sorted form of the array is [1,3,6,9], either
     *              (3,6) or (6,9) has the maximum difference 3.
     * 
     * Example 2:
     * 
     * Input: [10]
     * Output: 0
     * Explanation: The array contains less than 2 elements, therefore return 0.
     * 
     * Note:
     * You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.
     * Try to solve it in linear time/space.
     */
    public class MaximumGapSolution
    {
        public int MaximumGap(int[] nums)
        {
            // Inspired by Approach 2: Radix Sort from https://leetcode.com/articles/maximum-gap/
            // Think of the numbers as strings and do least-significant-digit first (LSD) string sort.
            if (nums.Length < 2) return 0;

            int max = nums.Max();
            int radix = 10; // base 10 system
            int[] aux = new int[nums.Length];

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                int[] count = new int[radix + 1];

                for (int i = 0; i < nums.Length; i++)
                {
                    int digit = (nums[i] / exp) % 10;
                    count[digit + 1]++;
                }

                for (int i = 0; i < radix; i++)
                {
                    count[i + 1] += count[i];
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    int digit = (nums[i] / exp) % 10;
                    aux[count[digit]++] = nums[i];
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = aux[i];
                }
            }

            int maxGap = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
            }
            return maxGap;
        }

        public int MaximumGap2(int[] nums)
        {
            // Inspired by Approach 3: Bucket Sort from https://leetcode.com/articles/maximum-gap/
            // Let b = bucket size, n = nums.Length, max = maximum element, min = minimum element,
            // Our goal is to find an appropriate b such that the two elements that forms the
            // maximum gap are definitely in different buckets. In this way, we can just compare
            // the min element of a bucket to the max element of its previous bucket for each bucket
            // to find out the maximum gap.
            // For example, after being sorted, nums = [0,...,10], n = 6, min = 0, max = 10.
            // Consider how to get the smallest maximum gap, if the elements in the middle can change?
            // We can equally devide the range [min,max]: 
            // [0,2,4,6,8,10], maximum gap = 2
            // If we set b = (max - min) / (n - 1) = 2, we have buckets like:
            // [0,2),[2,4),[4,6),[6,8),[8, 10),[10,10]
            // In this way, no matter how the elements in the middle change, our goal is always guaranteed.
            // For example, nums = [0,2,3,6,8,10]
            //                          ↑ ↑
            //                          maximum gap
            //                          3 falls in [2,4), and 6 falls in [6,8).
            if (nums.Length < 2) return 0;

            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            int bucketSize = (max - min) / (nums.Length - 1); // bucketSize can be smaller than the actual value(which has fractional part).
            if (bucketSize == 0) bucketSize = 1; // One bucket for each element.
            var buckets = new Bucket[(max - min) / bucketSize + 1];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new Bucket();

            foreach (int num in nums)
            {
                int bucketIdx = (num - min) / bucketSize;
                buckets[bucketIdx].used = true;
                buckets[bucketIdx].min = Math.Min(buckets[bucketIdx].min, num);
                buckets[bucketIdx].max = Math.Max(buckets[bucketIdx].max, num);
            }

            int prevBucketMax = min, maxGap = 0; // min must be first bucket's min, so the first time, maxGap remains 0.
            foreach (var bucket in buckets)
            {
                if (!bucket.used) continue;
                maxGap = Math.Max(maxGap, bucket.min - prevBucketMax);
                prevBucketMax = bucket.max;
            }
            return maxGap;
        }

        private class Bucket
        {
            public bool used = false;
            public int min = int.MaxValue;
            public int max = int.MinValue;
        }
    }
}
