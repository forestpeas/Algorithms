using System;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 6. ZigZag Conversion
     * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
     * 
     * P   A   H   N
     * A P L S I I G
     * Y   I   R
     * 
     * And then read line by line: "PAHNAPLSIIGYIR"
     * Write the code that will take a string and make this conversion given a number of rows:
     * string convert(string s, int numRows);
     * 
     * Example 1:
     * Input: s = "PAYPALISHIRING", numRows = 3
     * Output: "PAHNAPLSIIGYIR"
     * 
     * Example 2:
     * Input: s = "PAYPALISHIRING", numRows = 4
     * Output: "PINALSIGYAHRPI"
     * Explanation:
     * 
     * P     I    N
     * A   L S  I G
     * Y A   H R
     * P     I
     * 
     */
    public class ZigZagConversion
    {
        public string Convert(string s, int numRows)
        {
            if (s == null || numRows < 1) throw new ArgumentException();
            if (s == "" || numRows == 1) return s;
            int n = s.Length;
            if (n == 1) return s;
            var sb = new StringBuilder(n);
            // It's like periodic function in mathematics.
            for (int i = 0; i < numRows; i++)
            {
                // (2 * numRows - 2) is the period T
                int period = 2 * numRows - 2;
                for (int j = 0; j < n / period + 1; j++)
                {
                    int index = j * period + i;
                    if (index < n) sb.Append(s[index]);
                    if (i != 0 && i != numRows - 1)
                    {
                        // ((j + 1) * period) means the index of the next "wave crest". 
                        index = (j + 1) * period - i;
                        if (index < n) sb.Append(s[index]);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
