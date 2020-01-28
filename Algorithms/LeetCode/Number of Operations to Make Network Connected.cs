using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1319. Number of Operations to Make Network Connected
     * 
     * There are n computers numbered from 0 to n-1 connected by ethernet cables connections forming
     * a network where connections[i] = [a, b] represents a connection between computers a and b.
     * Any computer can reach any other computer directly or indirectly through the network.
     * 
     * Given an initial computer network connections. You can extract certain cables between two
     * directly connected computers, and place them between any pair of disconnected computers to make
     * them directly connected. Return the minimum number of times you need to do this in order to make
     * all the computers connected. If it's not possible, return -1. 
     * 
     *  https://leetcode.com/problems/number-of-operations-to-make-network-connected/
     * 
     * Example 1:
     * 
     * Input: n = 4, connections = [[0,1],[0,2],[1,2]]
     * Output: 1
     * Explanation: Remove cable between computer 1 and 2 and place between computers 1 and 3.
     * 
     * Example 2:
     * 
     * Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2],[1,3]]
     * Output: 2
     * 
     * Example 3:
     * 
     * Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2]]
     * Output: -1
     * Explanation: There are not enough cables.
     * 
     * Example 4:
     * 
     * Input: n = 5, connections = [[0,1],[0,2],[3,4],[2,3]]
     * Output: 0
     */
    public class Number_of_Operations_to_Make_Network_Connected
    {
        public int MakeConnected(int n, int[][] connections)
        {
            // Union-find. Find redundant cables(edges) in connected components.
            int[] components = new int[n];
            for (int i = 0; i < n; i++) components[i] = i;
            int cablesNeeded = n - 1; // We need at least n - 1 cables to connect n nodes.
            if (connections.Length < cablesNeeded) return -1;
            foreach (int[] connection in connections)
            {
                int c1 = Find(connection[0]);
                int c2 = Find(connection[1]);
                if (c1 != c2)
                {
                    components[c1] = c2; // Union.
                    cablesNeeded--;
                }
            }
            return cablesNeeded;

            int Find(int i)
            {
                return i == components[i] ? i : Find(components[i]);
            }
        }

        public int MakeConnected2(int n, int[][] connections)
        {
            // DFS. Count the number of connected components.
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (int[] connection in connections)
            {
                graph[connection[0]].Add(connection[1]);
                graph[connection[1]].Add(connection[0]);
            }

            bool[] visited = new bool[n];
            int subnet = 0;
            int redundantCaples = 0;
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    subnet++;
                    Dfs(i);
                }
            }
            redundantCaples = redundantCaples - connections.Length;
            if (subnet - 1 > redundantCaples) return -1;
            return subnet - 1;

            void Dfs(int node)
            {
                visited[node] = true;
                foreach (int neighbor in graph[node])
                {
                    if (visited[neighbor])
                    {
                        redundantCaples++;
                        continue;
                    }
                    Dfs(neighbor);
                }
            }
        }
    }
}
