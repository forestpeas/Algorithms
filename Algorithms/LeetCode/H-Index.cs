using System;

namespace Algorithms.LeetCode
{
    /* 274. H-Index
     * 
     * Given an array of citations (each citation is a non-negative integer) of a researcher, write a function
     * to compute the researcher's h-index.
     * 
     * According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers
     * have at least h citations each, and the other N − h papers have no more than h citations each."
     * 
     * Example:
     * 
     * Input: citations = [3,0,6,1,5]
     * Output: 3 
     * Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had 
     *              received 3, 0, 6, 1, 5 citations respectively. 
     *              Since the researcher has 3 papers with at least 3 citations each and the remaining 
     *              two with no more than 3 citations each, her h-index is 3.
     * 
     * Note: If there are several possible values for h, the maximum one is taken as the h-index.
     */
    public class H_Index
    {
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            for (int i = 0; i < citations.Length; i++)
            {
                int h = citations.Length - i; // The number of citations >= citations[i].
                if (citations[i] >= h) return h; // citations[i+1...] >= citations[i].
            }

            return 0;
        }

        public int HIndex2(int[] citations)
        {
            // Counting sort with the same idea.
            int n = citations.Length;
            int[] count = new int[n + 1];
            foreach (int c in citations)
            {
                if (c > n) count[n]++;
                else count[c]++;
            }

            int total = 0;
            for (int h = n; h >= 0; h--)
            {
                total += count[h]; // "total" is the number of citations >= h.
                if (total >= h) return h;
            }

            return 0;
        }
    }
}
