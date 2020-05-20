namespace Algorithms.LeetCode
{
    /* 1390. Four Divisors
     * 
     * Given an integer array nums, return the sum of divisors of the integers in that array that
     * have exactly four divisors.
     * 
     * If there is no such integer in the array, return 0.
     * 
     * Example 1:
     * 
     * Input: nums = [21,4,7]
     * Output: 32
     * Explanation:
     * 21 has 4 divisors: 1, 3, 7, 21
     * 4 has 3 divisors: 1, 2, 4
     * 7 has 2 divisors: 1, 7
     * The answer is the sum of divisors of 21 only.
     */
    public class Four_Divisors
    {
        public int SumFourDivisors(int[] nums)
        {
            // Just count the divisors of each number.
            int res = 0;
            foreach (int num in nums)
            {
                int count = 0; // The number of divisors except 1 and num.
                int d = 0;
                for (int i = 2; i * i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        if (++count > 1) break;
                        d = i;
                    }
                }

                if (count == 1 && d != num / d) // numbers like 4 or 9 has only 3 divisors.
                {
                    res += 1 + num + d + num / d;
                }
            }

            return res;
        }
    }
}
