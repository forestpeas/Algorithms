using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1345. Jump Game IV
     * 
     * Given an array of integers arr, you are initially positioned at the first index of the array.
     * 
     * In one step you can jump from index i to index:
     * i + 1 where: i + 1 < arr.length.
     * i - 1 where: i - 1 >= 0.
     * j where: arr[i] == arr[j] and i != j.
     * 
     * Return the minimum number of steps to reach the last index of the array.
     * Notice that you can not jump outside of the array at any time.
     * 
     * Example 1:
     * 
     * Input: arr = [100,-23,-23,404,100,23,23,23,3,404]
     * Output: 3
     * Explanation: You need three jumps from index 0 --> 4 --> 3 --> 9. Note that index 9 is the last
     * index of the array.
     * 
     * Example 2:
     * 
     * Input: arr = [7]
     * Output: 0
     * Explanation: Start index is the last index. You don't need to jump.
     * 
     * Example 3:
     * 
     * Input: arr = [7,6,9,6,9,6,9,7]
     * Output: 1
     * Explanation: You can jump directly from index 0 to index 7 which is last index of the array.
     * 
     * Example 4:
     * 
     * Input: arr = [6,1,9]
     * Output: 2
     * 
     * Example 5:
     * 
     * Input: arr = [11,22,7,7,7,7,7,7,7,22,13]
     * Output: 3
     */
    public class Jump_Game_IV
    {
        public int MinJumps(int[] arr)
        {
            if (arr.Length == 1) return 0;

            var map = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i])) map.Add(arr[i], new List<int>());
                map[arr[i]].Add(i);
            }

            bool[] visited = new bool[arr.Length];
            visited[0] = true;
            var queue = new Queue<int>();
            queue.Enqueue(0);
            int result = 0;
            while (queue.Count != 0)
            {
                result++;
                int size = queue.Count;
                while (size-- > 0)
                {
                    int v = queue.Dequeue();
                    foreach (int w in map[arr[v]].Concat(new int[] { v - 1, v + 1 }))
                    {
                        if (w < 0 || w >= arr.Length || visited[w]) continue;
                        visited[w] = true;
                        if (w == arr.Length - 1) return result;
                        queue.Enqueue(w);
                    }

                    map[arr[v]].Clear(); // Avoid visiting the same value again.
                }
            }

            return result; // No solution.
        }
    }
}
