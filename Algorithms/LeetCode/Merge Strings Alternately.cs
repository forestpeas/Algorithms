﻿using System.Text;

namespace Algorithms.LeetCode
{
    /* 1768. Merge Strings Alternately
     * 
     * You are given two strings word1 and word2. Merge the strings by adding letters in
     * alternating order, starting with word1. If a string is longer than the other,
     * append the additional letters onto the end of the merged string.
     * 
     * Return the merged string.
     * 
     * Example 1:
     * 
     * Input: word1 = "abc", word2 = "pqr"
     * Output: "apbqcr"
     * Explanation: The merged string will be merged as so:
     * word1:  a   b   c
     * word2:    p   q   r
     * merged: a p b q c r
     * 
     * Example 2:
     * 
     * Input: word1 = "ab", word2 = "pqrs"
     * Output: "apbqrs"
     * Explanation: Notice that as word2 is longer, "rs" is appended to the end.
     * word1:  a   b 
     * word2:    p   q   r   s
     * merged: a p b q   r   s
     * 
     * Example 3:
     * 
     * Input: word1 = "abcd", word2 = "pq"
     * Output: "apbqcd"
     * Explanation: Notice that as word1 is longer, "cd" is appended to the end.
     * word1:  a   b   c   d
     * word2:    p   q 
     * merged: a p b q c   d
     */
    public class Merge_Strings_Alternately
    {
        public string MergeAlternately(string word1, string word2)
        {
            var res = new StringBuilder();
            int i = 0, j = 0;
            while (i < word1.Length || j < word2.Length)
            {
                if (i == word1.Length)
                {
                    res.Append(word2.Substring(j));
                    break;
                }
                else if (j == word2.Length)
                {
                    res.Append(word1.Substring(j));
                    break;
                }
                else
                {
                    res.Append(word1[i++]);
                    res.Append(word2[j++]);
                }
            }
            return res.ToString();
        }
    }
}
