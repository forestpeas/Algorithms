namespace Algorithms.LeetCode
{
    /* 14. Longest Common Prefix
     * 
     * Write a function to find the longest common prefix string amongst an array of strings.
     * If there is no common prefix, return an empty string "".
     * 
     * Example 1:
     * 
     * Input: ["flower","flow","flight"]
     * Output: "fl"
     * 
     * Example 2:
     * 
     * Input: ["dog","racecar","car"]
     * Output: ""
     * Explanation: There is no common prefix among the input strings.
     * 
     * Note:
     * All given inputs are in lowercase letters a-z.
     */
    public class LongestCommonPrefixcs
    {
        public string LongestCommonPrefix(string[] strs)
        {
            // "Vertical scanning": We compare characters from top to bottom on the same column 
            // (same character index of the strings) before moving on to the next column.
            // From "Approach 2: Vertical scanning" of https://leetcode.com/articles/longest-common-prefix/
            if (strs == null || strs.Length == 0) return "";
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }
    }
}
