using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1203. Sort Items by Groups Respecting Dependencies
     * 
     * There are n items each belonging to zero or one of m groups where group[i] is the group that the i-th item
     * belongs to and it's equal to -1 if the i-th item belongs to no group. The items and the groups are zero indexed.
     * A group can have no item belonging to it.
     * 
     * Return a sorted list of the items such that:
     * The items that belong to the same group are next to each other in the sorted list.
     * There are some relations between these items where beforeItems[i] is a list containing all the items that should
     * come before the i-th item in the sorted array (to the left of the i-th item).
     * 
     * Return any solution if there is more than one solution and return an empty list if there is no solution.
     * 
     * Example 1:
     * https://leetcode.com/problems/sort-items-by-groups-respecting-dependencies/
     * Input: n = 8, m = 2, group = [-1,-1,1,0,0,1,0,-1], beforeItems = [[],[6],[5],[6],[3,6],[],[],[]]
     * Output: [6,3,4,1,5,2,0,7]
     */
    public class Sort_Items_by_Groups_Respecting_Dependencies
    {
        public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            // First topological sort by groups, then topological sort by items within each group independently.
            var groupGraph = new Dictionary<int, HashSet<int>>();
            var itemGraphs = new List<Dictionary<int, HashSet<int>>>();
            for (int i = 0; i < m; i++)
            {
                groupGraph.Add(i, new HashSet<int>());
                itemGraphs.Add(new Dictionary<int, HashSet<int>>());
            }

            for (int i = 0; i < n; i++)
            {
                if (group[i] == -1)
                {
                    group[i] = groupGraph.Count;
                    groupGraph.Add(group[i], new HashSet<int>());
                    itemGraphs.Add(new Dictionary<int, HashSet<int>>() { { i, new HashSet<int>() } });
                }
                else
                {
                    var itemGraph = itemGraphs[group[i]];
                    if (!itemGraph.ContainsKey(i)) itemGraph.Add(i, new HashSet<int>());
                }

                foreach (int j in beforeItems[i])
                {
                    if (group[j] == -1)
                    {
                        group[j] = groupGraph.Count;
                        groupGraph.Add(group[j], new HashSet<int>());
                        itemGraphs.Add(new Dictionary<int, HashSet<int>>() { { j, new HashSet<int>() } });
                    }

                    if (group[j] != group[i])
                    {
                        groupGraph[group[j]].Add(group[i]);
                    }
                    else
                    {
                        var itemGraph = itemGraphs[group[i]];
                        if (!itemGraph.ContainsKey(j)) itemGraph.Add(j, new HashSet<int>());
                        itemGraph[j].Add(i);
                    }
                }
            }

            var topologicalGroups = TopologicalSort(groupGraph);
            if (topologicalGroups == null) return new int[0];
            var result = new List<int>();
            foreach (int groupId in topologicalGroups)
            {
                // Extend each group id to the items in this group.
                var topologicalItems = TopologicalSort(itemGraphs[groupId]);
                if (topologicalItems == null) return new int[0];
                result.AddRange(topologicalItems);
            }

            return result.ToArray();
        }

        // Returns null if cycle is detected.
        private IEnumerable<int> TopologicalSort(Dictionary<int, HashSet<int>> graph)
        {
            var marked = new HashSet<int>(); // vertices visited
            var onStack = new HashSet<int>(); // vertices on recursive call stack
            var topologicalOrder = new Stack<int>();
            foreach (int v in graph.Keys)
            {
                if (!marked.Contains(v))
                {
                    if (Dfs(v)) return null;
                }
            }
            return topologicalOrder;

            bool Dfs(int v)
            {
                onStack.Add(v);
                marked.Add(v);
                foreach (int w in graph[v])
                {
                    if (!marked.Contains(w))
                    {
                        if (Dfs(w)) return true;
                    }
                    else if (onStack.Contains(w))
                    {
                        return true;
                    }
                }
                onStack.Remove(v);
                topologicalOrder.Push(v);
                return false;
            }
        }
    }
}
