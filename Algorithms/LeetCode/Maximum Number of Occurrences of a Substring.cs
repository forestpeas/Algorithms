using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1297. Maximum Number of Occurrences of a Substring
     * 
     * Given a string s, return the maximum number of ocurrences of any substring under the following rules:
     * 
     * The number of unique characters in the substring must be less than or equal to maxLetters.
     * The substring size must be between minSize and maxSize inclusive.
     * 
     * Example 1:
     * 
     * Input: s = "aababcaab", maxLetters = 2, minSize = 3, maxSize = 4
     * Output: 2
     * Explanation: Substring "aab" has 2 ocurrences in the original string.
     * It satisfies the conditions, 2 unique letters and size 3 (between minSize and maxSize).
     * 
     * Example 2:
     * 
     * Input: s = "aaaa", maxLetters = 1, minSize = 3, maxSize = 3
     * Output: 2
     * Explanation: Substring "aaa" occur 2 times in the string. It can overlap.
     * 
     * Example 3:
     * 
     * Input: s = "aabcabcab", maxLetters = 2, minSize = 2, maxSize = 3
     * Output: 3
     * 
     * Example 4:
     * 
     * Input: s = "abcde", maxLetters = 2, minSize = 3, maxSize = 3
     * Output: 0
     */
    public class Maximum_Number_of_Occurrences_of_a_Substring
    {
        public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
        {
            // Brute-force.
            var subStrCounts = new Dictionary<string, int>();
            for (int size = minSize; size <= maxSize; size++)
            {
                int uniqueNum = 0;
                int[] charCounts = new int[256];
                for (int i = 0; i < s.Length; i++)
                {
                    if (++charCounts[s[i]] == 1) uniqueNum++;
                    if (i >= size && --charCounts[s[i - size]] == 0) uniqueNum--;

                    if (uniqueNum > maxLetters || i - size + 1 < 0) continue;
                    string subStr = s.Substring(i - size + 1, size);
                    subStrCounts[subStr] = subStrCounts.GetValueOrDefault(subStr) + 1;
                }
            }

            return subStrCounts.Count == 0 ? 0 : subStrCounts.Values.Max();
        }
    }
}
