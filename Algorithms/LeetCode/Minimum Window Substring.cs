namespace Algorithms.LeetCode
{
    /* 76. Minimum Window Substring
     * 
     * Given a string S and a string T, find the minimum window in S which will contain all the characters
     * in T in complexity O(n).
     * 
     * Example 1:
     * 
     * Input: S = "ADOBECODEBANC", T = "ABC"
     * Output: "BANC"
     * 
     * Example 2:
     * 
     * Input: S = "aaa", T = "aa"
     * Output: "aa"
     * 
     * Note:
     * If there is no such window in S that covers all characters in T, return the empty string "".
     * If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
     */
    public class MinimumWindowSubstring
    {
        public string MinWindow(string s, string t)
        {
            int[] counts = new int[128];
            foreach (char c in t) counts[c]++;
            int start = 0, length = int.MaxValue; // The final result.
            int num = 0; // The number of characters that t contains, in the sliding window [l,r].      
            for (int l = 0, r = 0; r < s.Length; r++)
            {
                // Notice that if a character appears 3 times in s, and 2 times in t, when it is visited the
                // third time, its count will be negative and won't be taken into account in "num".
                if (counts[s[r]]-- > 0) num++;
                while (num == t.Length) // The current sliding window is a potential answer.
                {
                    if (r - l + 1 < length)
                    {
                        start = l;
                        length = r - l + 1;
                    }
                    // s[l] was decreased once before when it was visited by the right boundary,
                    // so it is now either 0(exists in t), or negative(not exist in t).
                    if (counts[s[l]]++ == 0) num--;
                    l++;
                }
            }
            return length == int.MaxValue ? string.Empty : s.Substring(start, length);
        }
    }
}
