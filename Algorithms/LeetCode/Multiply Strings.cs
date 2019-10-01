namespace Algorithms.LeetCode
{
    /* 43. Multiply Strings
     * 
     * Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
     * 
     * Example 1:
     * 
     * Input: num1 = "2", num2 = "3"
     * Output: "6"
     * 
     * Example 2:
     * 
     * Input: num1 = "123", num2 = "456"
     * Output: "56088"
     * 
     * Note:
     * 
     * 1.The length of both num1 and num2 is < 110.
     * 2.Both num1 and num2 contain only digits 0-9.
     * 3.Both num1 and num2 do not contain any leading zero, except the number 0 itself.
     * 4.You must not use any built-in BigInteger library or convert the inputs to integer directly.
     */
    public class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            /* For example: num1 = "123", num2 = "456"
             *    123
             * ×  456
             * ------
             *    738
             *   615
             *  492
             *  ------
             *  56088
             *  
             *  We can observe that the result digit "0"(in "56088") comes from
             *  2 + 1 + 7, which comes from
             *  4 * 3 + 5 * 2 + 6 * 1
             */
            var result = string.Empty;
            int lastCarry = 0;
            // i is a pointer to chars in num1, j is a pointer to chars in num2.
            for (int j = num2.Length - 1, i; j > -num1.Length; j--)
            {
                int jj = j; // jj is the "real" pointer to chars in num2
                if (j < 0)
                {
                    i = num1.Length - 1 + j;
                    jj = 0;
                }
                else
                {
                    i = num1.Length - 1;
                }
                int carry = 0;
                int resultDigit = 0;
                for (int k = jj; k < num2.Length && i >= 0; k++, i--)
                {
                    int tmp = (num2[k] - '0') * (num1[i] - '0');
                    carry += tmp / 10;
                    tmp = tmp % 10;
                    resultDigit += tmp;
                }
                resultDigit = resultDigit + lastCarry;
                carry += resultDigit / 10;
                result = (resultDigit % 10) + result;
                lastCarry = carry;
            }
            if (lastCarry != 0)
            {
                result = lastCarry + result;
            }
            return result;
        }
    }
}
