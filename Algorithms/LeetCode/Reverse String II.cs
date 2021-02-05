using System;

namespace Algorithms.LeetCode
{
    /* 541. Reverse String II
     * 
     * Given a string and an integer k, you need to reverse the first k characters
     * for every 2k characters counting from the start of the string. If there are
     * less than k characters left, reverse all of them. If there are less than 2k
     * but greater than or equal to k characters, then reverse the first k characters
     * and left the other as original.
     * 
     * Example:
     * Input: s = "abcdefg", k = 2
     * Output: "bacdfeg"
     */
    public class Reverse_String_II
    {
        public string ReverseStr(string s, int k)
        {
            char[] str = s.ToCharArray();
            for (int i = 0; i < s.Length; i += 2 * k)
            {
                Reverse(str, i, Math.Min(i + k - 1, s.Length - 1));
            }
            return new string(str);
        }

        private void Reverse(char[] s, int start, int end)
        {
            while (start < end)
            {
                char tmp = s[start];
                s[start] = s[end];
                s[end] = tmp;
                start++;
                end--;
            }
        }
    }
}
