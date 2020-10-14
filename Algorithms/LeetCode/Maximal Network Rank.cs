using System;

namespace Algorithms.LeetCode
{
    /* 1615. Maximal Network Rank
     * 
     * There is an infrastructure of n cities with some number of roads connecting these cities.
     * Each roads[i] = [ai, bi] indicates that there is a bidirectional road between cities ai and bi.
     * 
     * The network rank of two different cities is defined as the total number of directly connected roads
     * to either city. If a road is directly connected to both cities, it is only counted once.
     * 
     * The maximal network rank of the infrastructure is the maximum network rank of all pairs of different
     * cities.
     * 
     * Given the integer n and the array roads, return the maximal network rank of the entire infrastructure. 
     * 
     * Example 1:
     * https://leetcode.com/problems/maximal-network-rank/
     * Input: n = 4, roads = [[0,1],[0,3],[1,2],[1,3]]
     * Output: 4
     * Explanation: The network rank of cities 0 and 1 is 4 as there are 4 roads that are connected to either
     * 0 or 1. The road between 0 and 1 is only counted once.
     */
    public class Maximal_Network_Rank
    {
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            bool[,] connected = new bool[n, n];
            int[] counts = new int[n];
            foreach (int[] road in roads)
            {
                counts[road[0]]++;
                counts[road[1]]++;
                connected[road[0], road[1]] = true;
                connected[road[1], road[0]] = true;
            }
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    res = Math.Max(res, counts[i] + counts[j] - (connected[i, j] ? 1 : 0));
                }
            }
            return res;
        }
    }
}
