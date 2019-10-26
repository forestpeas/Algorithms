using System;

namespace Algorithms.LeetCode
{
    /* 318. Maximum Product of Word Lengths
     * 
     * Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the
     * two words do not share common letters. You may assume that each word will contain only lower case
     * letters. If no such two words exist, return 0.
     * 
     * Example 1:
     * 
     * Input: ["abcw","baz","foo","bar","xtfn","abcdef"]
     * Output: 16 
     * Explanation: The two words can be "abcw", "xtfn".
     * 
     * Example 2:
     * 
     * Input: ["a","ab","abc","d","cd","bcd","abcd"]
     * Output: 4 
     * Explanation: The two words can be "ab", "cd".
     * 
     * Example 3:
     * 
     * Input: ["a","aa","aaa","aaaa"]
     * Output: 0 
     * Explanation: No such pair of words.
     */
    public class MaximumProductOfWordLengths
    {
        public int MaxProduct(string[] words)
        {
            // Inspired by discuss section.
            // Every word can be represented as a integer, with every letter corresponding to a bit.
            int[] masks = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                foreach (char c in words[i])
                {
                    masks[i] |= 1 << (c - 'a');
                }
            }

            int result = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // If there are no common letter between words[i] and words[j].
                    if ((masks[i] & masks[j]) == 0) result = Math.Max(result, words[i].Length * words[j].Length);
                }
            }
            return result;
        }
    }
}
