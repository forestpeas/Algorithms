using System.Linq;

namespace Algorithms.LeetCode
{
    /* 567. Permutation in String
     * 
     * Given two strings s1 and s2, write a function to return true if s2 contains the
     * permutation of s1. In other words, one of the first string's permutations is the
     * substring of the second string.
     * 
     * Example 1:
     * 
     * Input: s1 = "ab" s2 = "eidbaooo"
     * Output: True
     * Explanation: s2 contains one permutation of s1 ("ba").
     * 
     * Example 2:
     * 
     * Input:s1= "ab" s2 = "eidboaoo"
     * Output: False
     */
    public class Permutation_in_String
    {
        public bool CheckInclusion(string s1, string s2)
        {
            int[] counts = new int[128];
            foreach (char c in s1)
            {
                counts[c]--;
            }

            for (int l = 0, r = 0; r < s2.Length; r++)
            {
                counts[s2[r]]++;
                if (r - l + 1 > s1.Length)
                {
                    counts[s2[l]]--;
                    l++;
                }
                if (counts.All(count => count == 0)) return true;
            }
            return false;
        }
    }
}
