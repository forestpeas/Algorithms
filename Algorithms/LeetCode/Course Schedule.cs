using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 207. Course Schedule
     * 
     * There are a total of n courses you have to take, labeled from 0 to n-1.
     * 
     * Some courses may have prerequisites, for example to take course 0 you have to first take course 1,
     * which is expressed as a pair: [0,1]
     * 
     * Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
     * 
     * Example 1:
     * 
     * Input: 2, [[1,0]] 
     * Output: true
     * Explanation: There are a total of 2 courses to take. 
     *              To take course 1 you should have finished course 0. So it is possible.
     *              
     * Example 2:
     * 
     * Input: 2, [[1,0],[0,1]]
     * Output: false
     * Explanation: There are a total of 2 courses to take. 
     *              To take course 1 you should have finished course 0, and to take course 0 you should
     *              also have finished course 1. So it is impossible.
     *              
     * Note:
     * You may assume that there are no duplicate edges in the input prerequisites.
     */
    public class CourseSchedule
    {
        // This problem is equivalent to finding if a cycle exists in a directed graph.
        internal class Digraph
        {
            private readonly List<int>[] _adjacents; // contains indexes of adjacent vertices

            public Digraph(int numCourses, int[][] prerequisites)
            {
                _adjacents = new List<int>[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    _adjacents[i] = new List<int>();
                }
                foreach (int[] prerequisite in prerequisites)
                {
                    _adjacents[prerequisite[1]].Add(prerequisite[0]);
                }
            }

            public IEnumerable<int> AdjacentsOf(int v) => _adjacents[v];
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var digraph = new Digraph(numCourses, prerequisites);
            var marked = new bool[numCourses]; // vertices visited
            var onStack = new bool[numCourses]; // vertices on recursive call stack
            for (int v = 0; v < numCourses; v++)
            {
                if (!marked[v])
                {
                    if (Dfs(v)) return false;
                }
            }
            return true;

            // Returns true if a cycle is detected. 
            bool Dfs(int v)
            {
                onStack[v] = true;
                marked[v] = true;
                foreach (int w in digraph.AdjacentsOf(v))
                {
                    if (!marked[w])
                    {
                        if (Dfs(w)) return true;
                    }
                    else if (onStack[w])
                    {
                        return true;
                    }
                }
                onStack[v] = false;
                return false;
            }
        }
    }
}
