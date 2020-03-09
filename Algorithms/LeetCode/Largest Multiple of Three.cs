using System.Text;

namespace Algorithms.LeetCode
{
    /* 1363. Largest Multiple of Three
     * 
     * Given an integer array of digits, return the largest multiple of three that can be formed
     * by concatenating some of the given digits in any order.
     * 
     * Since the answer may not fit in an integer data type, return the answer as a string.
     * If there is no answer return an empty string.
     */
    public class Largest_Multiple_of_Three
    {
        public string LargestMultipleOfThree(int[] digits)
        {
            // "a multiple of three" is equivalent to "the sum of each digit is a multiple of three".
            // Our goal is to maximize the number of digits, so we can choose all digits and then
            // try to remove one or two digits.
            int[] counts = new int[10];
            int sum = 0;
            foreach (int digit in digits)
            {
                counts[digit]++;
                sum += digit;
            }

            if (sum % 3 == 1)
            {
                // Such as [2,2,3].
                if (!RemoveOneDigit(counts, 1))
                {
                    RemoveOneDigit(counts, 2);
                    RemoveOneDigit(counts, 2);
                }
            }
            else if (sum % 3 == 2)
            {
                if (!RemoveOneDigit(counts, 2))
                {
                    RemoveOneDigit(counts, 1);
                    RemoveOneDigit(counts, 1);
                }
            }

            var result = new StringBuilder();
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    result.Append(i);
                }
            }
            if (result.Length > 0 && result[0] == '0') return "0";
            return result.ToString();
        }

        private bool RemoveOneDigit(int[] counts, int mod)
        {
            // Remove one of [1,4,7] or one of [2,5,8].
            for (int i = mod; i <= 9; i += 3)
            {
                if (counts[i] != 0)
                {
                    counts[i]--;
                    return true;
                }
            }
            return false;
        }
    }
}
