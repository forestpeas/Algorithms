using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 415. Add Strings
     * 
     * Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
     * 
     * Note:
     * 
     * The length of both num1 and num2 is < 5100.
     * Both num1 and num2 contains only digits 0-9.
     * Both num1 and num2 does not contain any leading zero.
     * You must not use any built-in BigInteger library or convert the inputs to integer directly.
     */
    public class Add_Strings
    {
        public string AddStrings(string num1, string num2)
        {
            // Almost the same as "2. Add Two Numbers".
            int i = num1.Length - 1, j = num2.Length - 1;
            int carry = 0;
            var res = new Stack<char>();
            while (i >= 0 || j >= 0)
            {
                int x = 0, y = 0;
                if (i >= 0) x = num1[i] - '0';
                if (j >= 0) y = num2[j] - '0';
                int sum = carry + x + y;
                carry = sum / 10;
                res.Push((char)((sum % 10) + '0'));
                i--;
                j--;
            }
            if (carry > 0) res.Push('1');
            return new string(res.ToArray());
        }
    }
}
