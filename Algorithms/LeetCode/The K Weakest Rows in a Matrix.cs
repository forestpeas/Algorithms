using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1337. The K Weakest Rows in a Matrix
     * 
     * Given a m * n matrix mat of ones (representing soldiers) and zeros (representing civilians),
     * return the indexes of the k weakest rows in the matrix ordered from the weakest to the strongest.
     * 
     * A row i is weaker than row j, if the number of soldiers in row i is less than the number of
     * soldiers in row j, or they have the same number of soldiers but i is less than j. Soldiers are
     * always stand in the frontier of a row, that is, always ones may appear first and then zeros.
     * 
     * Example 1:
     * 
     * Input: mat = 
     * [[1,1,0,0,0],
     *  [1,1,1,1,0],
     *  [1,0,0,0,0],
     *  [1,1,0,0,0],
     *  [1,1,1,1,1]], 
     * k = 3
     * Output: [2,0,3]
     * Explanation: 
     * The number of soldiers for each row is: 
     * row 0 -> 2 
     * row 1 -> 4 
     * row 2 -> 1 
     * row 3 -> 2 
     * row 4 -> 5 
     * Rows ordered from the weakest to the strongest are [2,0,3,1,4]
     */
    public class The_K_Weakest_Rows_in_a_Matrix
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            Row[] rows = new Row[mat.Length];
            for (int i = 0; i < mat.Length; i++)
            {
                rows[i] = new Row() { idx = i };
                // Or we can binary search to find "soldiers".
                foreach (int j in mat[i])
                {
                    if (j == 1) rows[i].soldiers++;
                    else break;
                }
            }

            return rows.OrderBy(r => r.soldiers).ThenBy(r => r.idx).Select(r => r.idx).Take(k).ToArray();
        }

        private class Row
        {
            public int idx;
            public int soldiers;
        }
    }
}
