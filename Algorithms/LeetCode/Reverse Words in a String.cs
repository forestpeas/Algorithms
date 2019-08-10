using System;

namespace Algorithms.LeetCode
{
    /* 151. Reverse Words in a String
     * 
     * Given an input string, reverse the string word by word.
     * 
     * Note:
     * A word is defined as a sequence of non-space characters.
     * Input string may contain leading or trailing spaces. However, your reversed string should not contain leading or trailing spaces.
     * You need to reduce multiple spaces between two words to a single space in the reversed string.
     * 
     * Follow up:
     * For C programmers, try to solve it in-place in O(1) extra space.
     * 
     * Example 1:
     * 
     * Input: "the sky is blue"
     * Output: "blue is sky the"
     * 
     * Example 2:
     * 
     * Input: "  hello world!  "
     * Output: "world! hello"
     * Explanation: Your reversed string should not contain leading or trailing spaces.
     * 
     * Example 3:
     * 
     * Input: "a good   example"
     * Output: "example good a"
     * Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
     */
    public class ReverseWordsInAString
    {
        public string ReverseWords(string s)
        {
            // Maybe this problem is for C/C++, so treat "s" as a char array.
            // But I just clean up the extra spaces as follows to keep it simple.
            char[] str = string.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToCharArray();

            // Reverse the whole string.
            Reverse(str, 0, str.Length - 1);

            // Reverse each word.
            int i = 0, j = 0;
            for (; j < str.Length; j++)
            {
                if (str[j] == ' ')
                {
                    Reverse(str, i, j - 1);
                    i = j + 1;
                }
            }
            Reverse(str, i, str.Length - 1);
            return new string(str);
        }

        private void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                char tmp = str[start];
                str[start] = str[end];
                str[end] = tmp;
                start++;
                end--;
            }
        }
    }
}
