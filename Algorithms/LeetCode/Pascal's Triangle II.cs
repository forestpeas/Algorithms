using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 119. Pascal's Triangle II
     * 
     * Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
     * Note that the row index starts from 0.
     * 
     * Example:
     * 
     * Input: 3
     * Output: [1,3,3,1]
     * 
     * Follow up:
     * Could you optimize your algorithm to use only O(k) extra space?
     */
    public class PascalsTriangleII
    {
        public IList<int> GetRow(int rowIndex)
        {
            // Example:
            // [0,0,0,0,1]
            // [0,0,0,1,1]
            // [0,0,1,2,1]
            // [0,1,3,3,1]
            // [1,4,6,4,1]
            var row = new int[rowIndex + 1];
            for (int i = 1; i <= row.Length; i++)
            {
                int start = row.Length - i;
                row[start] = 1;
                for (int j = start + 1; j < row.Length - 1; j++)
                {
                    row[j] = row[j] + row[j + 1];
                }
            }
            return row;
        }
    }
}
