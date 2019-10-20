using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 394. Decode String
     * 
     * Given an encoded string, return its decoded string.
     * 
     * The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets
     * is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
     * 
     * You may assume that the input string is always valid; No extra white spaces, square brackets
     * are well-formed, etc.
     * 
     * Furthermore, you may assume that the original data does not contain any digits and that digits
     * are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].
     * 
     * Examples:
     * 
     * s = "3[a]2[bc]", return "aaabcbc".
     * s = "3[a2[c]]", return "accaccacc".
     * s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
     */
    public class DecodeStringSolution
    {
        public string DecodeString(string s)
        {
            var stackNum = new Stack<int>();
            var stackStr = new Stack<StringBuilder>();
            int k = 0;
            var curr = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    k = k * 10 + c - '0';
                }
                else if (c == '[')
                {
                    stackNum.Push(k);
                    stackStr.Push(curr);
                    k = 0;
                    curr = new StringBuilder();
                }
                else if (c == ']')
                {
                    k = stackNum.Pop();
                    var last = stackStr.Pop();
                    while (k-- > 0) last.Append(curr);
                    k = 0;
                    curr = last;
                }
                else
                {
                    curr.Append(c);
                }
            }

            return curr.ToString();
        }
    }
}
