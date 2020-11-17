namespace Algorithms.LeetCode
{
    /* 477. Total Hamming Distance
     * 
     * The Hamming distance between two integers is the number of positions at which the corresponding
     * bits are different.
     * 
     * Now your job is to find the total Hamming distance between all pairs of the given numbers.
     * 
     * Example:
     * Input: 4, 14, 2
     * 
     * Output: 6
     * 
     * Explanation: In binary representation, the 4 is 0100, 14 is 1110, and 2 is 0010 (just
     * showing the four bits relevant in this case). So the answer will be:
     * HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2 + 2 + 2 = 6.
     */
    public class Total_Hamming_Distance
    {
        public int TotalHammingDistance(int[] nums)
        {
            // mem[i] is the number of ones seen so far in i-th position of an integer.
            int[] mem = new int[32];
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (((nums[i] >> j) & 1) == 1)
                    {
                        res += i - mem[j]; // number of zeroes
                        mem[j]++;
                    }
                    else
                    {
                        res += mem[j];
                    }
                }
            }
            return res;
        }
    }
}
