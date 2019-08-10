namespace Algorithms.LeetCode
{
    /* 96. Unique Binary Search Trees
     * 
     * Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?
     * 
     * Example:
     * 
     * Input: 3
     * Output: 5
     * Explanation:
     * Given n = 3, there are a total of 5 unique BST's:
     * 
     *    1         3     3      2      1
     *     \       /     /      / \      \
     *      3     2     1      1   3      2
     *     /     /       \                 \
     *    2     1         2                 3
     */
    public class UniqueBinarySearchTrees
    {
        // Inspired by https://leetcode.com/problems/unique-binary-search-trees/discuss/31666/DP-Solution-in-6-lines-with-explanation.-F(i-n)-G(i-1)-*-G(n-i)
        // Basically the idea is the same as "Problem 95. Unique Binary Search Trees II".
        // G[n] is the result of NumTrees(n).
        // Also note that, for example, the result of [1,2,3] is apparently the same as [5,6,7].
        public int NumTrees(int n)
        {
            int[] G = new int[n + 1];
            G[0] = G[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    G[i] += G[j - 1] * G[i - j];
                }
            }

            return G[n];
        }

        // Using Catalan Number Formula:
        // C(2n,n)/(n+1)
        public int NumTreesCatalanNumber(int n)
        {
            long ans = 1;
            for (int i = n + 1; i <= 2 * n; i++)
            {
                ans = ans * i / (i - n);
            }
            return (int)(ans / (n + 1));
        }
    }
}
