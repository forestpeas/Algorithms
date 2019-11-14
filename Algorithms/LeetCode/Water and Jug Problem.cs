using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 365. Water and Jug Problem
     * 
     * You are given two jugs with capacities x and y litres. There is an infinite amount of water
     * supply available. You need to determine whether it is possible to measure exactly z litres
     * using these two jugs.
     * 
     * If z liters of water is measurable, you must have z liters of water contained within one or
     * both buckets by the end.
     * 
     * Operations allowed:
     * Fill any of the jugs completely with water.
     * Empty any of the jugs.
     * Pour water from one jug into another till the other jug is completely full or the first jug
     * itself is empty.
     * 
     * Example 1: (From the famous "Die Hard" example)
     * 
     * Input: x = 3, y = 5, z = 4
     * Output: True
     * 
     * Example 2:
     * 
     * Input: x = 2, y = 6, z = 5
     * Output: False
     */
    public class Water_and_Jug_Problem
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x > y)
            {
                int tmp = x;
                x = y;
                y = tmp;
            }

            // Now x is the smaller one.
            if (x == z || y == z || 0 == z || x + y == z) return true;
            if (x == 0) return false;
            var set = new HashSet<int>(); // The water in x each time.
            int m = x; // Fill x and pour from x to y
            while (true)
            {
                // y contains m waters.
                // Fill x and check if x can all be poured to y.
                if (x + m < y)
                {
                    m = x + m;
                    if (m == z) return true;
                }
                else if (x + m > y)
                {
                    m = x + m - y; // m is the water left in x, then empty y and pour from x to y.
                    if (m == z || m + y == z) return true;
                    if (!set.Add(m)) break; // Check if we've reached this point before.
                }
                else break;
            }

            return false;
        }
    }
}
