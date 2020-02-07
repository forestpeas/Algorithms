using System;

namespace Algorithms.LeetCode
{
    /* 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance
     * 
     * https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
     */
    public class Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance
    {
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            // Floyd–Warshall algorithm.
            int[,] dist = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) dist[i, j] = 0;
                    else dist[i, j] = 10001; // 1 <= weighti, distanceThreshold <= 10^4, code is shorter without int.MaxValue
                }
            }

            foreach (int[] e in edges)
            {
                dist[e[0], e[1]] = dist[e[1], e[0]] = e[2];
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }

            int result = 0, min = n;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++) if (dist[i, j] <= distanceThreshold) count++;
                if (count <= min)
                {
                    min = count;
                    result = i;
                }
            }

            return result;
        }
    }
}
