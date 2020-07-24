namespace Algorithms.LeetCode
{
    /* 273. Integer to English Words
     * 
     * Convert a non-negative integer to its english words representation. Given input is guaranteed to be less
     * than 2^31 - 1.
     * 
     * Example 1:
     * 
     * Input: 123
     * Output: "One Hundred Twenty Three"
     * 
     * Example 2:
     * 
     * Input: 12345
     * Output: "Twelve Thousand Three Hundred Forty Five"
     * 
     * Example 3:
     * 
     * Input: 1234567
     * Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
     * 
     * Example 4:
     * 
     * Input: 1234567891
     * Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
     */
    public class Integer_to_English_Words
    {
        private readonly string[] LESS_THAN_20 = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] TENS = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private readonly string[] THOUSANDS = { "", "Thousand", "Million", "Billion" };

        public string NumberToWords(int num)
        {
            // Inspired by https://leetcode.com/problems/integer-to-english-words/discuss/70625/My-clean-Java-solution-very-easy-to-understand
            // Group the digits by 3 digits from right to left.
            if (num == 0) return "Zero";
            string res = "";
            for (int i = 0; num > 0; i++)
            {
                if (num % 1000 != 0)
                {
                    res = Helper(num % 1000) + THOUSANDS[i] + " " + res;
                }
                num /= 1000;
            }
            return res.Trim();
        }

        private string Helper(int num)
        {
            if (num == 0)
            {
                return "";
            }
            else if (num < 20)
            {
                return LESS_THAN_20[num] + " ";
            }
            else if (num < 100)
            {
                return TENS[num / 10] + " " + Helper(num % 10);
            }
            else
            {
                return LESS_THAN_20[num / 100] + " Hundred " + Helper(num % 100);
            }
        }
    }
}
