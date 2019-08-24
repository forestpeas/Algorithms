namespace Algorithms.LeetCode
{
    /* 171. Excel Sheet Column Number
     * 
     * Given a column title as appear in an Excel sheet, return its corresponding column number.
     * 
     * For example:
     * 
     *     A -> 1
     *     B -> 2
     *     C -> 3
     *     ...
     *     Z -> 26
     *     AA -> 27
     *     AB -> 28
     *     ...
     * 
     * Example 1:
     * 
     * Input: "A"
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: "AB"
     * Output: 28
     * 
     * Example 3:
     * 
     * Input: "ZY"
     * Output: 701
     */
    public class ExcelSheetColumnNumber
    {
        public int TitleToNumber(string s)
        {
            // Convert from base-26 to base-10.
            int result = 0;
            int cardinal = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += (s[i] - 'A' + 1) * cardinal;
                cardinal = cardinal * 26;
            }

            return result;
        }
    }
}
