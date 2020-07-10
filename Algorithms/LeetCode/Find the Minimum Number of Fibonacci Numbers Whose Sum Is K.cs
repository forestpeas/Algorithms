namespace Algorithms.LeetCode
{
    /* 1414. Find the Minimum Number of Fibonacci Numbers Whose Sum Is K
     * 
     * Given the number k, return the minimum number of Fibonacci numbers whose sum is equal to k, whether
     * a Fibonacci number could be used multiple times.
     * 
     * The Fibonacci numbers are defined as:
     * 
     * F1 = 1
     * F2 = 1
     * Fn = Fn-1 + Fn-2 , for n > 2.
     * It is guaranteed that for the given constraints we can always find such fibonacci numbers that sum k.
     * 
     * Example 1:
     * 
     * Input: k = 7
     * Output: 2 
     * Explanation: The Fibonacci numbers are: 1, 1, 2, 3, 5, 8, 13, ... 
     * For k = 7 we can use 2 + 5 = 7.
     * 
     * Example 2:
     * 
     * Input: k = 10
     * Output: 2 
     * Explanation: For k = 10 we can use 2 + 8 = 10.
     * 
     * Example 3:
     * 
     * Input: k = 19
     * Output: 3 
     * Explanation: For k = 19 we can use 1 + 5 + 13 = 19.
     */
    public class Find_the_Minimum_Number_of_Fibonacci_Numbers_Whose_Sum_Is_K
    {
        public int FindMinFibonacciNumbers(int k)
        {
            // Find the greatest Fibonacci number which is just less than or equal to k.
            // The difficulty lies in how to prove this greedy approach.
            // Reference: https://leetcode.com/problems/find-the-minimum-number-of-fibonacci-numbers-whose-sum-is-k/discuss/585632/Easy-Prove
            if (k < 2) return k;
            int n1 = 1, n2 = 1;
            while (n1 + n2 <= k)
            {
                int num = n1 + n2;
                n1 = n2;
                n2 = num;
            }
            return 1 + FindMinFibonacciNumbers(k - n2);
        }
    }
}
