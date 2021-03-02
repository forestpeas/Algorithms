using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 729. My Calendar I
     * 
     * https://leetcode.com/problems/my-calendar-i/
     */
    public class MyCalendar
    {
        private readonly List<int[]> calendar = new List<int[]>();

        public bool Book(int start, int end)
        {
            // Or use a TreeMap (Sorted Map).
            foreach (int[] iv in calendar)
            {
                if (iv[0] < end && start < iv[1]) return false;
            }
            calendar.Add(new int[] { start, end });
            return true;
        }
    }
}
