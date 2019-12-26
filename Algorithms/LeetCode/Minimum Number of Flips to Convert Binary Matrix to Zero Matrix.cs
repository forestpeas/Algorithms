using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix
     * 
     * Given a m x n binary matrix mat. In one step, you can choose one cell and flip it and all the four neighbours of it
     * if they exist (Flip is changing 1 to 0 and 0 to 1). A pair of cells are called neighboors if they share one edge.
     * 
     * Return the minimum number of steps required to convert mat to a zero matrix or -1 if you cannot.
     * 
     * Binary matrix is a matrix with all cells equal to 0 or 1 only.
     * 
     * Zero matrix is a matrix with all cells equal to 0.
     * 
     * Example 1:
     * 
     * Input: mat = [[0,0],[0,1]]
     * Output: 3
     * Explanation: One possible solution is to flip (1, 0) then (0, 1) and finally (1, 1) as shown.
     * 
     * Example 2:
     * 
     * Input: mat = [[0]]
     * Output: 0
     * Explanation: Given matrix is a zero matrix. We don't need to change it.
     * 
     * Example 3:
     * 
     * Input: mat = [[1,1,1],[1,0,1],[0,0,0]]
     * Output: 6
     * 
     * Example 4:
     * 
     * Input: mat = [[1,0,0],[1,0,0]]
     * Output: -1
     * Explanation: Given matrix can't be a zero matrix
     */
    public class Minimum_Number_of_Flips_to_Convert_Binary_Matrix_to_Zero_Matrix
    {
        public int MinFlips(int[][] mat)
        {
            // Brute-force BFS. Reverse the process, start from a zero matrix.
            int m = mat.Length;
            int n = mat[0].Length;
            var visitedStates = new List<int[][]>();
            int[][] initialState = new int[m][];
            for (int i = 0; i < m; i++) initialState[i] = new int[n];
            if (Equals(mat, initialState)) return 0;

            int steps = 0;
            var queue = new Queue<int[][]>();
            queue.Enqueue(initialState);
            while (queue.Count != 0)
            {
                int size = queue.Count;
                steps++;
                while (size-- > 0)
                {
                    int[][] state = queue.Dequeue();
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int[][] nextState = Copy(state);
                            Flip(nextState, i, j);
                            Flip(nextState, i + 1, j);
                            Flip(nextState, i - 1, j);
                            Flip(nextState, i, j + 1);
                            Flip(nextState, i, j - 1);

                            if (!Visited(nextState))
                            {
                                if (Equals(mat, nextState)) return steps;
                                queue.Enqueue(nextState);
                                visitedStates.Add(nextState);
                            }
                        }
                    }
                }
            }

            return -1;

            void Flip(int[][] array, int i, int j)
            {
                if (i < 0 || i >= m || j < 0 || j >= n) return;
                array[i][j] = array[i][j] == 0 ? 1 : 0;
            }

            bool Visited(int[][] state)
            {
                foreach (var visited in visitedStates)
                {
                    if (Equals(state, visited)) return true;
                }
                return false;
            }

            int[][] Copy(int[][] array)
            {
                int[][] copy = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    copy[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        copy[i][j] = array[i][j];
                    }
                }
                return copy;
            }

            bool Equals(int[][] array1, int[][] array2)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (array1[i][j] != array2[i][j]) return false;
                    }
                }
                return true;
            }
        }
    }
}
