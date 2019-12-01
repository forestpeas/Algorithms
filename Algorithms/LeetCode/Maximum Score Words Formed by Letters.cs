using System;

namespace Algorithms.LeetCode
{
    /* 1255. Maximum Score Words Formed by Letters
     * 
     * Given a list of words, list of  single letters (might be repeating) and score of every character.
     * 
     * Return the maximum score of any valid set of words formed by using the given letters (words[i] cannot
     * be used two or more times).
     * 
     * It is not necessary to use all characters in letters and each letter can only be used once. Score of
     * letters 'a', 'b', 'c', ... ,'z' is given by score[0], score[1], ... , score[25] respectively.
     * 
     * Example 1:
     * 
     * Input: words = ["dog","cat","dad","good"], letters = ["a","a","c","d","d","d","g","o","o"],
     * score = [1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0]
     * Output: 23
     * Explanation:
     * Score  a=1, c=9, d=5, g=3, o=2
     * Given letters, we can form the words "dad" (5+1+5) and "good" (3+2+2+5) with a score of 23.
     * Words "dad" and "dog" only get a score of 21.
     * 
     * Example 2:
     * 
     * Input: words = ["xxxz","ax","bx","cx"], letters = ["z","a","b","c","x","x","x"],
     * score = [4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,10]
     * Output: 27
     * Explanation:
     * Score  a=4, b=4, c=4, x=5, z=10
     * Given letters, we can form the words "ax" (4+5), "bx" (4+5) and "cx" (4+5) with a score of 27.
     * Word "xxxz" only get a score of 25.
     * 
     * Example 3:
     * 
     * Input: words = ["leetcode"], letters = ["l","e","t","c","o","d"],
     * score = [0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0]
     * Output: 0
     * Explanation:
     * Letter "e" can only be used once.
     */
    public class Maximum_Score_Words_Formed_by_Letters
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            // Try all possible sets of words.
            // For each word[i], we can pick this word or not. If we pick it,
            // we may get a high score but will have less available letters
            // for other words; if we don't pick it, we may have more available
            // letters for other words but at the cost of not including the
            // score of this word. Somewhat similar to the bit-manipulation
            // solution of "78. Subsets" and the knapsack problem.
            int[] letterCount = new int[26];
            foreach (char l in letters) letterCount[l - 'a']++;

            int result = 0;
            Backtrack(0, 0);
            return result;

            void Backtrack(int i, int currScore)
            {
                if (i >= words.Length) return;
                string w = words[i];
                int nextScore = currScore;
                int j = 0;
                for (; j < w.Length; j++)
                {
                    if (letterCount[w[j] - 'a']-- == 0) break;
                    nextScore += score[w[j] - 'a'];
                }
                if (j == w.Length)
                {
                    result = Math.Max(result, nextScore);
                    Backtrack(i + 1, nextScore);
                    j--;
                }
                for (; j >= 0; j--)
                {
                    letterCount[w[j] - 'a']++;
                }
                Backtrack(i + 1, currScore);
            }
        }
    }
}
