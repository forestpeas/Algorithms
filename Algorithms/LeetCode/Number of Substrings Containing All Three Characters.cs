namespace Algorithms.LeetCode
{
    /* 1358. Number of Substrings Containing All Three Characters
     * 
     * Given a string s consisting only of characters a, b and c.
     * 
     * Return the number of substrings containing at least one occurrence of all these
     * characters a, b and c.
     * 
     * Example 1:
     * 
     * Input: s = "abcabc"
     * Output: 10
     * Explanation: The substrings containing at least one occurrence of the characters
     * a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab", "bcabc", "cab",
     * "cabc" and "abc" (again). 
     * 
     * Example 2:
     * 
     * Input: s = "aaacb"
     * Output: 3
     * Explanation: The substrings containing at least one occurrence of the characters
     * a, b and c are "aaacb", "aacb" and "acb". 
     * 
     * Example 3:
     * 
     * Input: s = "abc"
     * Output: 1
     */
    public class Number_of_Substrings_Containing_All_Three_Characters
    {
        public int NumberOfSubstrings(string s)
        {
            // Similar to "992. Subarrays with K Different Integers".
            // In each iteration, the right bound of the sliding window is the current character,
            // and the range of the left bound is from index 0 to a certain largest possible index.
            int[] count = new int[128];
            int unique = 0; // The number of unique characters.
            int result = 0;
            for (int l = 0, r = 0; r < s.Length; r++)
            {
                if (++count[s[r]] == 1) unique++;
                if (unique != 3) continue;
                while (count[s[l]] > 1)
                {
                    --count[s[l++]];
                }
                result += l + 1;
            }
            return result;
        }
    }
}
