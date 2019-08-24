using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 118. Pascal's Triangle
     * 
     * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
     * In Pascal's triangle, each number is the sum of the two numbers directly above it.
     * 
     * Example:
     * 
     * Input: 5
     * Output:
     * [
     *      [1],
     *     [1,1],
     *    [1,2,1],
     *   [1,3,3,1],
     *  [1,4,6,4,1]
     * ]
     */
    public class PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            var prevRow = new int[0];
            for (int i = 0; i < numRows; i++)
            {
                var currRow = new int[prevRow.Length + 1];
                currRow[0] = 1;
                currRow[currRow.Length - 1] = 1;
                for (int j = 1; j < prevRow.Length; j++)
                {
                    currRow[j] = prevRow[j - 1] + prevRow[j];
                }
                result.Add(currRow);
                prevRow = currRow;
            }
            return result;
        }
    }
}
