namespace Algorithms.LeetCode
{
    /* 204. Count Primes
     * 
     * Count the number of prime numbers less than a non-negative number, n.
     * 
     * Example:
     * 
     * Input: 10
     * Output: 4
     * Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
     */
    public class CountPrimesSolution
    {
        public int CountPrimes(int n)
        {
            // Sieve of Eratosthenes. https://leetcode.com/static/images/solutions/Sieve_of_Eratosthenes_animation.gif
            // The speed of marking is always faster than the traversal with "i".
            // So when we come to nums[i], it is either marked(not a prime), or indeed a prime.
            bool[] nums = new bool[n];
            int count = 0;
            int i = 2;
            for (; i * i < n; i++) // Stop when i > √n, otherwise i * i might overflow in the following iterations.
            {
                if (nums[i] == false) // If this number was not marked, it's a prime number.
                {
                    count++;
                    for (int j = i * i; j < n; j += i)
                    {
                        nums[j] = true; // If it is not a prime number, mark it.
                    }
                }
            }

            for (; i < n; i++)
            {
                if (nums[i] == false) count++;
            }

            return count;
        }
    }
}
