using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 378. Kth Smallest Element in a Sorted Matrix
     * 
     * Given a n x n matrix where each of the rows and columns are sorted in ascending order, find
     * the kth smallest element in the matrix.
     * 
     * Note that it is the kth smallest element in the sorted order, not the kth distinct element.
     * 
     * Example:
     * 
     * matrix = [
     *    [ 1,  5,  9],
     *    [10, 11, 13],
     *    [12, 13, 15]
     * ],
     * k = 8,
     * 
     * return 13.
     * 
     * Note:
     * You may assume k is always valid, 1 ≤ k ≤ n^2.
     */
    public class KthSmallestElementInASortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            // Assume matrix[i][j] is the (m)th smallest element, matrix[i + 1][j] and matrix[i][j + 1] should be
            // candidates for the (m + 1)th smallest element. So we start from matrix[0][0] and add all the candidates
            // for [1 to k]th smallest element to a priority queue.
            var minPQ = new PriorityQueue<Point>(Comparer<Point>.Create((x, y) => matrix[y.i][y.j] - matrix[x.i][x.j]));
            minPQ.Add(new Point(0, 0));
            while (--k > 0)
            {
                var min = minPQ.DeleteTop();
                // We should somehow avoid visiting an element twice. So we only "move right" when in 0th row.
                // If we come to an element that is not in 0th row, for example matrix[1][0], we don't need to
                // move right to add matrix[1][1] because matrix[0][1] is or was in the priority queue, and because
                // matrix[0][1] is smaller than [1][1], matrix[1][1] either was added or will be added from matrix[0][1].
                if (min.i == 0 && min.j + 1 < matrix.Length) minPQ.Add(new Point(min.i, min.j + 1));
                if (min.i + 1 < matrix.Length) minPQ.Add(new Point(min.i + 1, min.j));
            }
            return matrix[minPQ.PeekTop().i][minPQ.PeekTop().j];
        }

        private class Point
        {
            public readonly int i;
            public readonly int j;

            public Point(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }
    }
}
