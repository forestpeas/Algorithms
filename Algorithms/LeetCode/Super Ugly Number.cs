using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 313. Super Ugly Number
     * 
     * Write a program to find the nth super ugly number.
     * 
     * Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k.
     * 
     * Example:
     * 
     * Input: n = 12, primes = [2,7,13,19]
     * Output: 32 
     * Explanation: [1,2,4,7,8,13,14,16,19,26,28,32] is the sequence of the first 12 
     *              super ugly numbers given primes = [2,7,13,19] of size 4.
     *              
     * Note:
     * 
     * 1 is a super ugly number for any given primes.
     * The given numbers in primes are in ascending order.
     * 0 < k ≤ 100, 0 < n ≤ 106, 0 < primes[i] < 1000.
     * The nth super ugly number is guaranteed to fit in a 32-bit signed integer.
     */
    public class SuperUglyNumber
    {
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            // A generalization of "Problem 264. Ugly Number II", same idea.
            // Use a priority queue to get the next minimum number.
            int[] mem = new int[n];
            mem[0] = 1;
            int[] p = new int[primes.Length];
            var minPQ = new PriorityQueue<int>(Comparer<int>.Create((x, y) => y - x));
            var set = new HashSet<int>(); // Prevent cases like 6 = 2 * 3 = 3 * 2 from being added to the pq twice.
            foreach (int prime in primes) minPQ.Add(prime);

            for (int i = 1; i < n; i++)
            {
                mem[i] = minPQ.DeleteTop();
                for (int j = 0; j < primes.Length; j++)
                {
                    if (mem[i] == mem[p[j]] * primes[j])
                    {
                        p[j]++;
                        int newNumber = mem[p[j]] * primes[j];
                        if (set.Add(newNumber)) minPQ.Add(newNumber);
                    }
                }
            }

            return mem[n - 1];
        }
    }
}
