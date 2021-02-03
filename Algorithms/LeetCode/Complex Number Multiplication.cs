using System.Text.RegularExpressions;

namespace Algorithms.LeetCode
{
    /* 537. Complex Number Multiplication
     * 
     * Given two strings representing two complex numbers.
     * 
     * You need to return a string representing their multiplication. Note i^2 = -1 according to
     * the definition.
     * 
     * Example 1:
     * Input: "1+1i", "1+1i"
     * Output: "0+2i"
     * Explanation: (1 + i) * (1 + i) = 1 + i2 + 2 * i = 2i, and you need convert it to the form
     * of 0+2i.
     * 
     * Example 2:
     * Input: "1+-1i", "1+-1i"
     * Output: "0+-2i"
     * Explanation: (1 - i) * (1 - i) = 1 + i2 - 2 * i = -2i, and you need convert it to the form
     * of 0+-2i.
     * 
     * Note:
     * 
     * The input strings will not have extra blank.
     * The input strings will be given in the form of a+bi, where the integer a and b will both
     * belong to the range of [-100, 100]. And the output should be also in this form.
     */
    public class Complex_Number_Multiplication
    {
        public string ComplexNumberMultiply(string a, string b)
        {
            string p = @"(-?\d+)\+(-?\d+)i";
            var groups = Regex.Match(a, p).Groups;
            int x1 = int.Parse(groups[1].Value);
            int y1 = int.Parse(groups[2].Value);
            groups = Regex.Match(b, p).Groups;
            int x2 = int.Parse(groups[1].Value);
            int y2 = int.Parse(groups[2].Value);
            return $"{x1 * x2 - y1 * y2}+{x1 * y2 + x2 * y1}i";
        }
    }
}
