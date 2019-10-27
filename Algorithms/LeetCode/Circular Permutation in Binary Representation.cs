using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class Circular_Permutation_in_Binary_Representation
    {
        public IList<int> CircularPermutation(int n, int start)
        {
            // Similar to "89. Gray Code".
            // Flip the lsd, then the second significant digit...
            var result = new List<int>() { start };
            for (int i = 0; i < n; i++)
            {
                int mask = 1 << i;
                if ((start & mask) == mask)
                {
                    for (int j = result.Count - 1; j >= 0; j--)
                    {
                        result.Add(result[j] & ~mask);
                    }
                }
                else
                {
                    for (int j = result.Count - 1; j >= 0; j--)
                    {
                        result.Add(result[j] | mask);
                    }
                }
            }

            return result;
        }
    }
}
