using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1408. String Matching in an Array
     * 
     * Given an array of string words. Return all strings in words which is substring of
     * another word in any order. 
     * 
     * String words[i] is substring of words[j], if can be obtained removing some characters
     * to left and/or right side of words[j].
     *  
     * Example 1:
     * 
     * Input: words = ["mass","as","hero","superhero"]
     * Output: ["as","hero"]
     * Explanation: "as" is substring of "mass" and "hero" is substring of "superhero".
     * ["hero","as"] is also a valid answer.
     * 
     * Example 2:
     * 
     * Input: words = ["leetcode","et","code"]
     * Output: ["et","code"]
     * Explanation: "et", "code" are substring of "leetcode".
     * 
     * Example 3:
     * 
     * Input: words = ["blue","green","bu"]
     * Output: []
     * 
     * Constraints:
     * 
     *     1 <= words.length <= 100
     *     1 <= words[i].length <= 30
     *     words[i] contains only lowercase English letters.
     *     It's guaranteed that words[i] will be unique.
     */
    public class String_Matching_in_an_Array
    {
        public IList<string> StringMatching(string[] words)
        {
            var res = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (j == i) continue;
                    if (words[j].Contains(words[i]))
                    {
                        res.Add(words[i]);
                        break;
                    }
                }
            }
            return res;
        }
    }
}
