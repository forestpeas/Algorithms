namespace Algorithms.LeetCode
{
    /* 74. Search a 2D Matrix
     * 
     * Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
     * Integers in each row are sorted from left to right.
     * The first integer of each row is greater than the last integer of the previous row.
     * 
     * Example 1:
     * 
     * Input:
     * matrix = [
     *   [1,   3,  5,  7],
     *   [10, 11, 16, 20],
     *   [23, 30, 34, 50]
     * ]
     * target = 3
     * Output: true
     * 
     * Example 2:
     * 
     * Input:
     * matrix = [
     *   [1,   3,  5,  7],
     *   [10, 11, 16, 20],
     *   [23, 30, 34, 50]
     * ]
     * target = 13
     * Output: false
     */
    public class Search2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            // Just like binary search from a one-dimensional sorted array.
            // We only need to map the index of the one-dimensional array to the two-dimensional array.
            // Somewhat similar to "Problem 33. Search in Rotated Sorted Array".
            if (matrix.Length < 1) return false;
            int lo = 0;
            int hi = matrix.Length * matrix[0].Length - 1; // might overflow
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                int midValue = matrix[mid / matrix[0].Length][mid % matrix[0].Length];
                if (midValue > target)
                {
                    hi = mid - 1;
                }
                else if (midValue < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
