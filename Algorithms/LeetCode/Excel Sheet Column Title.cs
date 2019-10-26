namespace Algorithms.LeetCode
{
    /* 168. Excel Sheet Column Title
     * 
     * Given a positive integer, return its corresponding column title as appear in an Excel sheet.
     * 
     * For example:
     * 
     *     1 -> A
     *     2 -> B
     *     3 -> C
     *     ...
     *     26 -> Z
     *     27 -> AA
     *     28 -> AB 
     *     ...
     * 
     * Example 1:
     * 
     * Input: 1
     * Output: "A"
     * 
     * Example 2:
     * 
     * Input: 28
     * Output: "AB"
     * 
     * Example 3:
     * 
     * Input: 701
     * Output: "ZY"
     */
    public class ExcelSheetColumnTitle
    {
        public string ConvertToTitle(int n)
        {
            // Convert from base-10 to base-26.
            var result = string.Empty;
            while (n != 0)
            {
                result = (char)((n - 1) % 26 + 'A') + result;
                n = (n - 1) / 26;
            }

            return result;
        }
    }
}
