﻿namespace Algorithms.LeetCode
{
    /* 8. String to Integer (atoi)
     * 
     * Implement atoi which converts a string to an integer.
     * The function first discards as many whitespace characters as necessary until the first non-whitespace 
     * character is found. Then, starting from this character, takes an optional initial plus or minus sign 
     * followed by as many numerical digits as possible, and interprets them as a numerical value.
     * 
     * The string can contain additional characters after those that form the integral number, which are ignored
     * and have no effect on the behavior of this function.
     * 
     * If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such
     * sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
     * 
     * If no valid conversion could be performed, a zero value is returned.
     * 
     * Note:
     *     Only the space character ' ' is considered as whitespace character.
     *     Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.
     * 
     * Example 1:
     * 
     * Input: "42"
     * Output: 42
     * 
     * Example 2:
     * 
     * Input: "   -42"
     * Output: -42
     * Explanation: The first non-whitespace character is '-', which is the minus sign.
     *              Then take as many numerical digits as possible, which gets 42.
     * 
     * Example 3:
     * 
     * Input: "4193 with words"
     * Output: 4193
     * Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.
     * 
     * Example 4:
     * 
     * Input: "words and 987"
     * Output: 0
     * Explanation: The first non-whitespace character is 'w', which is not a numerical 
     *              digit or a +/- sign. Therefore no valid conversion could be performed.
     * 
     * Example 5:
     * 
     * Input: "-91283472332"
     * Output: -2147483648
     * Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.Thefore INT_MIN (−231) is returned.
     */
    public class StringToInteger
    {
        // Your runtime beats 100.00 % of csharp submissions.
        // Your memory usage beats 82.52 % of csharp submissions.
        public int MyAtoi(string str)
        {
            if (str == null) return 0;

            int i = 0;
            for (; i < str.Length; i++)
            {
                if (!char.IsWhiteSpace(str[i]))
                {
                    break;
                }
            }

            if (i == str.Length) return 0;

            bool positive = true;
            if (str[i] == '-')
            {
                positive = false;
                i++;
            }
            else if (str[i] == '+')
            {
                i++;
            }

            int ret = 0;
            for (; i < str.Length; i++)
            {
                char character = str[i];
                if (!char.IsDigit(character)) break;
                int digit = character - '0';
                if (positive)
                {
                    // 7 is because int.MaxValue(2147483647)'s least significant digit
                    // is 7, and result * 10 is at most 2147483640. Similar logic can
                    // be applied when result is negative.
                    if (ret > int.MaxValue / 10 || (ret == int.MaxValue / 10 && digit > 7))
                    {
                        return int.MaxValue;
                    }
                    ret = ret * 10 + digit;
                }
                else
                {
                    if (ret < int.MinValue / 10 || (ret == int.MinValue / 10 && digit > 8))
                    {
                        return int.MinValue;
                    }
                    ret = ret * 10 - digit;
                }
            }

            return ret;
        }
    }
}
