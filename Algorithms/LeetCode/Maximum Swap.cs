namespace Algorithms.LeetCode
{
    /* 670. Maximum Swap
     * 
     * Given a non-negative integer, you could swap two digits at most once to get
     * the maximum valued number. Return the maximum valued number you could get.
     * 
     * Example 1:
     * Input: 2736
     * Output: 7236
     * Explanation: Swap the number 2 and the number 7.
     * 
     * Example 2:
     * Input: 9973
     * Output: 9973
     * Explanation: No swap.
     * 
     * Note:
     * The given number is in the range [0, 10^8]
     */
    public class MaximumSwapSolution
    {
        public int MaximumSwap(int num)
        {
            char[] str = num.ToString().ToCharArray();
            if (str.Length < 2) return num;
            int maxVal = int.MinValue;
            int maxIdx = str.Length - 1;
            int s = str.Length - 1; // The index of the smaller digit to be swapped.
            int l = str.Length - 1; // The index of the larger digit to be swapped.
            for (int i = str.Length - 1; i >= 0; i--)
            {
                int digit = str[i] - '0';
                if (digit > maxVal)
                {
                    maxVal = digit;
                    maxIdx = i;
                }
                else if (digit < maxVal)
                {
                    s = i;
                    l = maxIdx;
                }
            }

            char tmp = str[s];
            str[s] = str[l];
            str[l] = tmp;
            return int.Parse(str);
        }
    }
}
