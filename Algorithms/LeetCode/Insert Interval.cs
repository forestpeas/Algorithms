using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 57. Insert Interval
     * 
     * Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
     * You may assume that the intervals were initially sorted according to their start times.
     * 
     * Example 1:
     * 
     * Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
     * Output: [[1,5],[6,9]]
     * 
     * Example 2:
     * 
     * Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
     * Output: [[1,2],[3,10],[12,16]]
     * Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
     */
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // Had to deal with some special corner cases that are covered in the solution afterwards.
            if (intervals.Length < 1) return new int[][] { newInterval };
            if (intervals[0][0] > newInterval[0])
            {
                if (intervals[0][0] > newInterval[1])
                {
                    var ret = new List<int[]> { newInterval };
                    ret.AddRange(intervals);
                    return ret.ToArray();
                }
                intervals[0][0] = newInterval[0];
            }

            // "BinarySearch" returns an index in "intervals" such that: 
            // intervals[index][0] >= target, and intervals[index + 1][0] < target
            // So "intervals[start]" is the first "candidate" for merging. 
            int start = BinarySearch(intervals, 0, newInterval[0]);
            int end = BinarySearch(intervals, start, newInterval[1]);

            List<int[]> result = new List<int[]>();
            for (int i = 0; i < start; i++)
            {
                result.Add(intervals[i]);
            }

            if (newInterval[0] <= intervals[start][1])
            {
                result.Add(new int[] { intervals[start][0], Math.Max(intervals[end][1], newInterval[1]) });
            }
            else
            {
                result.Add(intervals[start]);
                result.Add(new int[] { newInterval[0], Math.Max(intervals[end][1], newInterval[1]) });
            }

            for (int i = end + 1; i < intervals.Length; i++)
            {
                result.Add(intervals[i]);
            }
            return result.ToArray();
        }

        private int BinarySearch(int[][] intervals, int startFrom, int target)
        {
            int lo = startFrom;
            int hi = intervals.Length - 1;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (intervals[mid][0] > target)
                {
                    hi = mid - 1;
                }
                else if (intervals[mid][0] < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    lo = mid;
                    break;
                }
            }
            if (intervals[lo][0] > target) lo--;
            return lo;
        }
    }
}
