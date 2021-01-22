using System;

namespace Algorithms.LeetCode
{
    /* 528. Random Pick with Weight
     * 
     * You are given an array of positive integers w where w[i] describes the weight of ith
     * index (0-indexed).
     * 
     * We need to call the function pickIndex() which randomly returns an integer in the
     * range [0, w.length - 1]. pickIndex() should return the integer proportional to its
     * weight in the w array. For example, for w = [1, 3], the probability of picking the
     * index 0 is 1 / (1 + 3) = 0.25 (i.e 25%) while the probability of picking the index
     * 1 is 3 / (1 + 3) = 0.75 (i.e 75%).
     * 
     * More formally, the probability of picking index i is w[i] / sum(w).
     * 
     * Example 1:
     * 
     * Input
     * ["Solution","pickIndex"]
     * [[[1]],[]]
     * Output
     * [null,0]
     * 
     * Explanation
     * Solution solution = new Solution([1]);
     * solution.pickIndex(); // return 0. Since there is only one single element on the
     * array the only option is to return the first element.
     * 
     * Example 2:
     * 
     * Input
     * ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
     * [[[1,3]],[],[],[],[],[]]
     * Output
     * [null,1,1,1,1,0]
     * 
     * Explanation
     * Solution solution = new Solution([1, 3]);
     * solution.pickIndex(); // return 1. It's returning the second element (index = 1)
     * that has probability of 3/4.
     * solution.pickIndex(); // return 1
     * solution.pickIndex(); // return 1
     * solution.pickIndex(); // return 1
     * solution.pickIndex(); // return 0. It's returning the first element (index = 0) that has probability of 1/4.
     */
    public class Random_Pick_with_Weight
    {
        public class Solution
        {
            private readonly int[] p;
            private readonly int sum;
            private readonly Random random = new Random();

            public Solution(int[] w)
            {
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] += (i == 0) ? 0 : w[i - 1];
                }
                p = w;
                sum = w[w.Length - 1];
            }

            public int PickIndex()
            {
                int idx = Array.BinarySearch(p, random.Next(1, sum + 1));
                if (idx < 0) idx = ~idx;
                return idx;
            }
        }
    }
}
