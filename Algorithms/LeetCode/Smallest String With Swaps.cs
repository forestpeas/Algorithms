using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1202. Smallest String With Swaps
     * 
     * You are given a string s, and an array of pairs of indices in the string pairs where pairs[i] = [a, b]
     * indicates 2 indices(0-indexed) of the string.
     * You can swap the characters at any pair of indices in the given pairs any number of times.
     * Return the lexicographically smallest string that s can be changed to after using the swaps.
     * 
     * Example 1:
     * 
     * Input: s = "dcab", pairs = [[0,3],[1,2]]
     * Output: "bacd"
     * Explaination: 
     * Swap s[0] and s[3], s = "bcad"
     * Swap s[1] and s[2], s = "bacd"
     * 
     * Example 2:
     * 
     * Input: s = "dcab", pairs = [[0,3],[1,2],[0,2]]
     * Output: "abcd"
     * Explaination: 
     * Swap s[0] and s[3], s = "bcad"
     * Swap s[0] and s[2], s = "acbd"
     * Swap s[1] and s[2], s = "abcd"
     * 
     * Example 3:
     * 
     * Input: s = "cba", pairs = [[0,1],[1,2]]
     * Output: "abc"
     * Explaination: 
     * Swap s[0] and s[1], s = "bca"
     * Swap s[1] and s[2], s = "bac"
     * Swap s[0] and s[1], s = "abc"
     */
    public class Smallest_String_With_Swaps
    {
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            // Think of it as a graph problem. A pair is an edge, a character is a vertex.
            // In each connected component, we can freely rearrange the nodes in this component.
            // So we need to find all connected components and sort each component independently.
            var graph = new Dictionary<int, HashSet<int>>();
            foreach (var pair in pairs)
            {
                if (!graph.ContainsKey(pair[0])) graph.Add(pair[0], new HashSet<int>());
                graph[pair[0]].Add(pair[1]);
                if (!graph.ContainsKey(pair[1])) graph.Add(pair[1], new HashSet<int>());
                graph[pair[1]].Add(pair[0]);
            }

            char[] arr = s.ToCharArray();
            bool[] visited = new bool[s.Length];
            foreach (int v in graph.Keys)
            {
                if (visited[v]) continue;
                var nodes = new List<int>();
                Dfs(v, nodes);
                nodes.Sort();
                var subSeq = new List<char>();
                foreach (int i in nodes) subSeq.Add(s[i]);
                subSeq.Sort();
                int j = 0;
                foreach (int i in nodes) arr[i] = subSeq[j++];
            }
            return new string(arr);

            void Dfs(int v, List<int> nodes)
            {
                if (visited[v]) return;
                visited[v] = true;
                nodes.Add(v);
                foreach (int w in graph[v]) Dfs(w, nodes);
            }
        }
    }
}
