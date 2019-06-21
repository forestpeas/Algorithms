namespace Algorithms.LeetCode
{
    /* 67. Add Binary
     * 
     * Given two binary strings, return their sum (also a binary string).
     * The input strings are both non-empty and contains only characters 1 or 0.
     * 
     * Example 1:
     * 
     * Input: a = "11", b = "1"
     * Output: "100"
     * 
     * Example 2:
     * 
     * Input: a = "1010", b = "1011"
     * Output: "10101"
     */
    public class AddBinarySolution
    {
        public string AddBinary(string a, string b)
        {
            // Just like adding tow numbers:
            //   101
            // +  11
            // ------
            //  1000
            if (a.Length < b.Length)
            {
                string tmp = a;
                a = b;
                b = tmp;
            }
            char[] sum = new char[a.Length + 1];
            int i = sum.Length - 1;
            int j = a.Length - 1;
            int k = b.Length - 1;
            bool carry = false;
            for (; k >= 0; k--, j--)
            {
                if (b[k] == '0')
                {
                    if (a[j] == '0')
                    {
                        sum[i--] = carry ? '1' : '0';
                        carry = false;
                    }
                    else // a[j] == '1'
                    {
                        sum[i--] = carry ? '0' : '1';
                        // "carry" stays the same.
                    }
                }
                else // b[k] == '1'
                {
                    if (a[j] == '0')
                    {
                        sum[i--] = carry ? '0' : '1';
                        // "carry" stays the same.
                    }
                    else // a[j] == '1'
                    {
                        sum[i--] = carry ? '1' : '0';
                        carry = true;
                    }
                }
            }
            for (; j >= 0; j--)
            {
                if (a[j] == '0')
                {
                    sum[i--] = carry ? '1' : '0';
                    carry = false;
                }
                else // a[j] == '1'
                {
                    sum[i--] = carry ? '0' : '1';
                    // "carry" stays the same.
                }
            }
            if (carry)
            {
                sum[i] = '1';
                return new string(sum);
            }
            else return new string(sum, 1, sum.Length - 1);
        }
    }
}
