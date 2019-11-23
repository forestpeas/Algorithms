namespace Algorithms.LeetCode
{
    /* 304. Range Sum Query 2D - Immutable
     * 
     * Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left
     * corner (row1, col1) and lower right corner (row2, col2).
     * 
     * https://leetcode.com/problems/range-sum-query-2d-immutable/
     */
    public class NumMatrix
    {
        // Simply convert to sub-problems of "303. Range Sum Query - Immutable".
        // There is another smart solution from Approach #4 of https://leetcode.com/articles/range-sum-query-2d-immutable/
        // Sum(ABCD)=Sum(OD)−Sum(OB)−Sum(OC)+Sum(OA), O is at matrix[0,0].

        private readonly NumArray[] _numArrays;

        public NumMatrix(int[][] matrix)
        {
            _numArrays = new NumArray[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                _numArrays[i] = new NumArray(matrix[i]);
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int result = 0;
            for (int i = row1; i <= row2; i++)
            {
                result += _numArrays[i].SumRange(col1, col2);
            }
            return result;
        }
    }
}
