using System.Linq;

namespace Algorithms.LeetCode
{
    /* 435. Non-overlapping Intervals
     * 
     * Given a collection of intervals, find the minimum number of intervals you need to remove to make
     * the rest of the intervals non-overlapping.
     * 
     * Example 1:
     * 
     * Input: [[1,2],[2,3],[3,4],[1,3]]
     * Output: 1
     * Explanation: [1,3] can be removed and the rest of intervals are non-overlapping.
     * 
     * Example 2:
     * 
     * Input: [[1,2],[1,2],[1,2]]
     * Output: 2
     * Explanation: You need to remove two [1,2] to make the rest of intervals non-overlapping.
     * 
     * Example 3:
     * 
     * Input: [[1,2],[2,3]]
     * Output: 0
     * Explanation: You don't need to remove any of the intervals since they're already non-overlapping.
     * 
     * Note:
     * 
     * You may assume the interval's end point is always bigger than its start point.
     * Intervals like [1,2] and [2,3] have borders "touching" but they don't overlap each other.
     */
    public class Non_overlapping_Intervals
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            // Interval Scheduling.
            // Find the maximum number of intervals that are non-overlapping.
            if (intervals.Length == 0) return 0;
            intervals = intervals.OrderBy(i => i[1]).ToArray();
            int r = intervals[0][1];
            int res = 1;
            foreach (int[] interval in intervals)
            {
                if (interval[0] >= r)
                {
                    r = interval[1];
                    res++;
                }
            }
            return intervals.Length - res;
        }

        public int EraseOverlapIntervals2(int[][] intervals)
        {
            // same idea as above
            if (intervals.Length == 0) return 0;
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            int res = 0;
            int[] first = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                int[] second = intervals[i];
                if (second[0] >= first[1])
                {
                    first = second;
                }
                else if (second[1] <= first[1])
                {
                    res++; // Remove first because second is a subset of first.
                    first = second;
                }
                else
                {
                    res++; // Removing second is always better than removing first.
                }
            }
            return res;
        }
    }
}
