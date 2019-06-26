using System;

namespace Algorithms.LeetCode
{
    /* 72. Edit Distance
     * 
     * Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.
     * You have the following 3 operations permitted on a word:
     * Insert a character
     * Delete a character
     * Replace a character
     * 
     * Example 1:
     * 
     * Input: word1 = "horse", word2 = "ros"
     * Output: 3
     * Explanation: 
     * horse -> rorse (replace 'h' with 'r')
     * rorse -> rose (remove 'r')
     * rose -> ros (remove 'e')
     * 
     * Example 2:
     * 
     * Input: word1 = "intention", word2 = "execution"
     * Output: 5
     * Explanation: 
     * intention -> inention (remove 't')
     * inention -> enention (replace 'i' with 'e')
     * enention -> exention (replace 'n' with 'x')
     * exention -> exection (replace 'n' with 'c')
     * exection -> execution (insert 'u')
     */
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            // DP solution. Somewhat similar to "Problem 64. Minimum Path Sum" and "Problem 63. Unique Paths II".
            // mem[i, j] means the answer to word1[0...i - 1] and word2[0...j - 1].
            // mem[i, j] is the minimum of these three cases:
            // Delete a character: mem[i - 1, j] + 1
            // Insert a character: mem[i, j - 1] + 1
            // Replace a character: mem[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1)
            // We can optimize mem to a one-dimensional array.
            int[] mem = new int[word1.Length + 1];
            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = i;
            }
            for (int j = 0; j < word2.Length; j++)
            {
                int first = j + 1;
                int second = first;
                for (int i = 0; i < word1.Length; i++)
                {
                    second = Math.Min(Math.Min(first + 1, mem[i + 1] + 1), mem[i] + (word1[i] == word2[j] ? 0 : 1));
                    mem[i] = first;
                    first = second;
                }
                mem[mem.Length - 1] = second;
            }
            return mem[mem.Length - 1];
        }
    }
}
