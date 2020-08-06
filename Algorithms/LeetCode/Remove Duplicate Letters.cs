namespace Algorithms.LeetCode
{
    /* 316. Remove Duplicate Letters
     * 
     * Given a string which contains only lowercase letters, remove duplicate letters so that
     * every letter appears once and only once. You must make sure your result is the smallest
     * in lexicographical order among all possible results.
     * 
     * Example 1:
     * 
     * Input: "bcabc"
     * Output: "abc"
     * Example 2:
     * 
     * Input: "cbacdcbc"
     * Output: "acdb"
     */
    public class Remove_Duplicate_Letters
    {
        public string RemoveDuplicateLetters(string s)
        {
            // Same as "1081. Smallest Subsequence of Distinct Characters".
            // Greedy. Count the frequencies of each letter and choose the lexicographical
            // smallest letter when meets a letter whose count is 0.
            if (s.Length == 0) return "";
            int[] counts = new int[256];
            foreach (char c in s)
            {
                counts[c]++;
            }

            int minIdx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < s[minIdx]) minIdx = i;
                if (--counts[s[i]] == 0) break;
            }

            return s[minIdx] + RemoveDuplicateLetters(s.Substring(minIdx + 1).Replace(s[minIdx].ToString(), ""));
        }
    }
}
