using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 447. Number of Boomerangs
     * 
     * Given n points in the plane that are all pairwise distinct, a "boomerang" is a tuple of
     * points (i, j, k) such that the distance between i and j equals the distance between i and k
     * (the order of the tuple matters).
     * 
     * Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of
     * points are all in the range [-10000, 10000] (inclusive).
     * 
     * Example:
     * 
     * Input:
     * [[0,0],[1,0],[2,0]]
     * 
     * Output:
     * 2
     * 
     * Explanation:
     * The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
     */
    public class Number_of_Boomerangs
    {
        public int NumberOfBoomerangs(int[][] points)
        {
            int res = 0;
            foreach (var p1 in points)
            {
                // (i, j, k), where i is p1.
                var distCount = new Dictionary<long, int>();
                foreach (var p2 in points)
                {
                    long d = GetDistance(p1, p2);
                    distCount[d] = distCount.GetValueOrDefault(d) + 1;
                }
                foreach (int count in distCount.Values)
                {
                    res += count * (count - 1); // P(count, 2)
                }
            }
            return res;
        }

        private long GetDistance(int[] p1, int[] p2)
        {
            long dx = p1[0] - p2[0];
            long dy = p1[1] - p2[1];
            return dx * dx + dy * dy;
        }
    }
}
