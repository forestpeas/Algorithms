using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 60. Permutation Sequence
     * 
     * The set [1,2,3,...,n] contains a total of n! unique permutations.
     * By listing and labeling all of the permutations in order, we get the following sequence for n = 3:
     * 
     * 1."123"
     * 2."132"
     * 3."213"
     * 4."231"
     * 5."312"
     * 6."321"
     * 
     * Given n and k, return the kth permutation sequence.
     * 
     * Note:
     * Given n will be between 1 and 9 inclusive.
     * Given k will be between 1 and n! inclusive.
     * 
     * Example 1:
     * 
     * Input: n = 3, k = 3
     * Output: "213"
     * 
     * Example 2:
     * 
     * Input: n = 4, k = 9
     * Output: "2314"
     */
    public class PermutationSequence
    {
        public string GetPermutation(int n, int k)
        {
            // For example: n = 4:
            // 1234
            // 1243
            // 1324
            // 1342
            // 1423
            // 1432
            // 2134
            // 2143
            // 2314
            // 2341
            // 2413
            // 2431
            // 3124
            // 3142
            // 3214
            // 3241
            // 3412
            // 3421
            // 4123
            // 4132
            // 4213
            // 4231
            // 4312
            // 4321
            // We can notice that the numbers in the first column has a pattern. Each number in [1,2,3,4] repeats 6 times:
            // 111111, 222222, 333333, 444444
            // If k = 16, we can be sure that the first number in the result should be 16/6 + 1 = 3
            // And the second number of the rows with the first column being 3 are:
            // 11, 22, 44
            // This time, k = 16 % 6 = 4, which means we should return the 4th row in the rows with the first column being 3.
            var numsLeft = new List<int>() { -1 };
            int length = 1;
            for (int i = 1; i <= n; i++)
            {
                length = length * i;
                numsLeft.Add(i);
            }

            var result = new StringBuilder(n);
            for (int i = n; i >= 1; i--)
            {
                length = length / i;
                int j = k / length; // The j-th number in numsLeft
                k = k % length;
                if (k == 0)
                {
                    k = length;
                }
                else
                {
                    j++;
                }
                result.Append(numsLeft[j]);
                numsLeft.RemoveAt(j);
            }
            return result.ToString();
        }
    }
}
