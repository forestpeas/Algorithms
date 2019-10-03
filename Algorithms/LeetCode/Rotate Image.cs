namespace Algorithms.LeetCode
{
    /* 48. Rotate Image
     * 
     * You are given an n x n 2D matrix representing an image.
     * Rotate the image by 90 degrees (clockwise).
     * 
     * Note:
     * You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
     * DO NOT allocate another 2D matrix and do the rotation.
     * 
     * Example 1:
     * 
     * Given input matrix = 
     * [
     *   [1,2,3],
     *   [4,5,6],
     *   [7,8,9]
     * ],
     * 
     * rotate the input matrix in-place such that it becomes:
     * [
     *   [7,4,1],
     *   [8,5,2],
     *   [9,6,3]
     * ]
     * 
     * Example 2:
     * 
     * Given input matrix =
     * [
     *   [ 5, 1, 9,11],
     *   [ 2, 4, 8,10],
     *   [13, 3, 6, 7],
     *   [15,14,12,16]
     * ], 
     * 
     * rotate the input matrix in-place such that it becomes:
     * [
     *   [15,13, 2, 5],
     *   [14, 3, 4, 1],
     *   [12, 6, 8, 9],
     *   [16, 7,10,11]
     * ]
     */
    public class RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            // For example: 
            // matrix =
            // [
            //   [ 5, 1, 9,11],
            //   [ 2, 4, 8,10],
            //   [13, 3, 6, 7],
            //   [15,14,12,16]
            // ]
            // First we settle the outermost "circle":5,1,9,11,10,7,16,12,14,15,13,2
            // "i" means the circle number.
            // And we replace every element with its corresponding element.
            // For example: 5 with 15, 15 with 16, ...
            //              1 with 13, 13 with 12, ...
            //              ...
            for (int i = 0; i < matrix.Length / 2; i++)
            {
                int maxIndex = matrix.Length - 1 - i;
                for (int j = i; j < maxIndex; j++)
                {
                    // For example, matrix.Length = 4
                    // if j = 0, then complement = 3
                    // if j = 1, then complement = 2
                    // if j = 2, then complement = 1
                    int complement = matrix.Length - 1 - j;
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[complement][i];
                    matrix[complement][i] = matrix[maxIndex][complement];
                    matrix[maxIndex][complement] = matrix[j][maxIndex];
                    matrix[j][maxIndex] = tmp;
                }
            }
        }
    }
}
