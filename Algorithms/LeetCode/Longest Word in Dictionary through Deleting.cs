using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 524. Longest Word in Dictionary through Deleting
     * 
     * Given a string and a string dictionary, find the longest string in the dictionary that
     * can be formed by deleting some characters of the given string. If there are more than
     * one possible results, return the longest word with the smallest lexicographical order.
     * If there is no possible result, return the empty string.
     * 
     * Example 1:
     * Input:
     * s = "abpcplea", d = ["ale","apple","monkey","plea"]
     * 
     * Output: 
     * "apple"
     * 
     * Example 2:
     * 
     * Input:
     * s = "abpcplea", d = ["a","b","c"]
     * 
     * Output: 
     * "a"
     */
    public class Longest_Word_in_Dictionary_through_Deleting
    {
        public string FindLongestWord(string s, IList<string> d)
        {
            // Same as "392. Is Subsequence".
            foreach (string word in d.OrderByDescending(w => w.Length).ThenBy(w => w))
            {
                if (IsSubsequence(word))
                {
                    return word;
                }
            }
            return string.Empty;

            bool IsSubsequence(string word)
            {
                int i = 0;
                foreach (char c in s)
                {
                    if (word[i] == c)
                    {
                        if (++i == word.Length) return true;
                    }
                }

                return false;
            }
        }
    }
}
