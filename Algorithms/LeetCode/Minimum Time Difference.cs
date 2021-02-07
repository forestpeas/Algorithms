using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 539. Minimum Time Difference
     * 
     * Given a list of 24-hour clock time points in "HH:MM" format, return the
     * minimum minutes difference between any two time-points in the list. 
     * 
     * Example 1:
     * 
     * Input: timePoints = ["23:59","00:00"]
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: timePoints = ["00:00","23:59","00:00"]
     * Output: 0  
     * 
     * Constraints:
     * 2 <= timePoints <= 2 * 104
     * timePoints[i] is in the format "HH:MM".
     */
    public class Minimum_Time_Difference
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            var minutes = timePoints.Select(t =>
                {
                    int hour = int.Parse(t.Split(':')[0]);
                    int minute = int.Parse(t.Split(':')[1]);
                    return hour * 60 + minute;
                })
                .OrderBy(m => m)
                .ToList();

            int res = int.MaxValue;
            for (int i = 1; i < minutes.Count; i++)
            {
                res = Math.Min(res, minutes[i] - minutes[i - 1]);
            }
            return Math.Min(res, minutes[0] + 24 * 60 - minutes[^1]);
        }
    }
}
