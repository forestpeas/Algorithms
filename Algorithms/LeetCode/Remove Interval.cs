using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1272. Remove Interval
     * 
     * Given a sorted list of disjoint intervals, each interval intervals[i] = [a, b] represents
     * the set of real numbers x such that a <= x < b.
     * 
     * We remove the intersections between any interval in intervals and the interval toBeRemoved.
     * 
     * Return a sorted list of intervals after all such removals.
     * 
     * Example 1:
     * 
     * Input: intervals = [[0,2],[3,4],[5,7]], toBeRemoved = [1,6]
     * Output: [[0,1],[6,7]]
     * 
     * Example 2:
     * 
     * Input: intervals = [[0,5]], toBeRemoved = [2,3]
     * Output: [[0,2],[3,5]]
     */
    public class Remove_Interval
    {
        public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            // Draw diagrams and consider all possible cases.
            var result = new List<IList<int>>();
            foreach (var interval in intervals)
            {
                if (interval[1] <= toBeRemoved[0] || interval[0] >= toBeRemoved[1])
                {
                    result.Add(interval);
                }
                else
                {
                    if (interval[0] < toBeRemoved[0])
                    {
                        result.Add(new int[] { interval[0], toBeRemoved[0] });
                    }
                    if (interval[1] > toBeRemoved[1])
                    {
                        result.Add(new int[] { toBeRemoved[1], interval[1] });
                    }
                }
            }

            return result;
        }
    }
}
