using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 480. Sliding Window Median
     * 
     * Median is the middle value in an ordered integer list. If the size of the list is even,
     * there is no middle value. So the median is the mean of the two middle value.
     * 
     * Examples:
     * [2,3,4] , the median is 3
     * 
     * [2,3], the median is (2 + 3) / 2 = 2.5
     * 
     * Given an array nums, there is a sliding window of size k which is moving from the very
     * left of the array to the very right. You can only see the k numbers in the window. Each
     * time the sliding window moves right by one position. Your job is to output the median
     * array for each window in the original array.
     * 
     * For example,
     * Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.
     * 
     * Window position                Median
     * ---------------               -----
     * [1  3  -1] -3  5  3  6  7       1
     *  1 [3  -1  -3] 5  3  6  7       -1
     *  1  3 [-1  -3  5] 3  6  7       -1
     *  1  3  -1 [-3  5  3] 6  7       3
     *  1  3  -1  -3 [5  3  6] 7       5
     *  1  3  -1  -3  5 [3  6  7]      6
     *  
     * Therefore, return the median sliding window as [1,-1,-1,3,5,6].
     */
    public class Sliding_Window_Median
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            // Similar to "295. Find Median from Data Stream".
            var small = new SortedSet<int>(Comparer<int>.Create((x, y) => nums[x] == nums[y] ? x.CompareTo(y) : nums[x].CompareTo(nums[y])));
            var large = new SortedSet<int>(Comparer<int>.Create((x, y) => nums[x] == nums[y] ? x.CompareTo(y) : nums[x].CompareTo(nums[y])));
            double[] result = new double[nums.Length - k + 1];
            int start = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                small.Add(i);
                int max = small.Max;
                small.Remove(max);
                large.Add(max);
                if (small.Count < large.Count)
                {
                    int min = large.Min;
                    large.Remove(min);
                    small.Add(min);
                }
                if (small.Count + large.Count == k)
                {
                    if (small.Count == large.Count)
                    {
                        result[start] = ((double)nums[small.Max] + nums[large.Min]) / 2;
                    }
                    else
                    {
                        result[start] = nums[small.Max];
                    }
                    if (!small.Remove(start))
                    {
                        large.Remove(start);
                    }
                    start++;
                }
            }
            return result;
        }
    }
}
