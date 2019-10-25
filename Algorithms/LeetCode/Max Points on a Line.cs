using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 149. Max Points on a Line
     * 
     * Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
     * 
     * Example 1:
     * 
     * Input: [[1,1],[2,2],[3,3]]
     * Output: 3
     * Explanation:
     * ^
     * |
     * |        o
     * |     o
     * |  o  
     * +------------->
     * 0  1  2  3  4
     * 
     * Example 2:
     * 
     * Input: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
     * Output: 4
     * Explanation:
     * ^
     * |
     * |  o
     * |     o        o
     * |        o
     * |  o        o
     * +------------------->
     * 0  1  2  3  4  5  6
     */
    public class MaxPointsOnALine
    {
        public int MaxPoints(int[][] points)
        {
            // A slope and a point determines a line. Given a point points[i], compute the slope of
            // a line containing points[i] and another point: point[j]. Points with the same slope
            // are on the same line.
            // It's worth noting that we can't use a floating point number to represent the slope.
            if (points.Length < 2) return points.Length;

            int result = 0;
            for (int i = 1; i < points.Length; i++)
            {
                var slopeCounter = new Dictionary<Slope, int>();
                int duplicate = 0;
                for (int j = 0; j < i; j++)
                {
                    int[] p1 = points[i];
                    int[] p2 = points[j];
                    if (p1[0] == p2[0] && p1[1] == p2[1])
                    {
                        duplicate++;
                    }
                    else
                    {
                        var slope = new Slope(p1[0] - p2[0], p1[1] - p2[1]);
                        if (slopeCounter.TryGetValue(slope, out var count))
                        {
                            slopeCounter[slope] = count + 1;
                        }
                        else
                        {
                            slopeCounter.Add(slope, 2); // There are two points the first time.
                        }
                    }
                }

                // "duplicate + 1" is because the first point is taken into account.
                int current = slopeCounter.Count == 0 ? duplicate + 1 : (slopeCounter.Max(s => s.Value) + duplicate);
                result = Math.Max(result, current);
            }

            return result;
        }

        internal class Slope
        {
            public int Dx { get; }
            public int Dy { get; }

            public Slope(int dx, int dy)
            {
                int gcd = GetGreatestCommonDivisor(dx, dy);
                Dx = dx / gcd;
                Dy = dy / gcd;
            }

            private int GetGreatestCommonDivisor(int a, int b)
            {
                return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
            }

            public override bool Equals(object obj)
            {
                var slope = obj as Slope;
                return slope != null &&
                       Dx == slope.Dx &&
                       Dy == slope.Dy;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Dx, Dy);
            }
        }
    }
}
