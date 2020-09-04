using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 959. Regions Cut By Slashes
     * 
     * In a N x N grid composed of 1 x 1 squares, each 1 x 1 square consists of a /, \, or blank space.
     * These characters divide the square into contiguous regions.
     * 
     * (Note that backslash characters are escaped, so a \ is represented as "\\".)
     * 
     * Return the number of regions.
     * 
     * https://leetcode.com/problems/regions-cut-by-slashes/
     */
    public class Regions_Cut_By_Slashes
    {
        public int RegionsBySlashes(string[] grid)
        {
            // Similar to "200. Number of Islands".
            // Find all connected components, DFS or union-find.
            int n = grid.Length;
            int Convert(int i, int j) => n * i + j;
            var uf = new UnionFind((n + 1) * (n + 1));
            for (int i = 0; i <= n; i++)
            {
                // The borders of the grid belong to the same component.
                uf.Union(0, Convert(0, i));
                uf.Union(0, Convert(n, i));
                uf.Union(0, Convert(i, 0));
                uf.Union(0, Convert(i, n));
            }

            int res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '/')
                    {
                        // Union bottom-left and top-right.
                        if (!uf.Union(Convert(i, j + 1), Convert(i + 1, j))) res++;
                    }
                    else if (grid[i][j] == '\\')
                    {
                        // Union bottom-right and top-left.
                        if (!uf.Union(Convert(i, j), Convert(i + 1, j + 1))) res++;
                    }
                }
            }

            return res + 1;
        }
    }
}
