namespace Algorithms.LeetCode
{
    /* 275. H-Index II
     * 
     * Given an array of citations sorted in ascending order (each citation is a non-negative integer) of a
     * researcher, write a function to compute the researcher's h-index.
     * 
     * According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers
     * have at least h citations each, and the other N − h papers have no more than h citations each."
     * 
     * Example:
     * 
     * Input: citations = [0,1,3,5,6]
     * Output: 3 
     * Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had 
     *              received 0, 1, 3, 5, 6 citations respectively. 
     *              Since the researcher has 3 papers with at least 3 citations each and the remaining 
     *              two with no more than 3 citations each, her h-index is 3.
     * Note:
     * 
     * If there are several possible values for h, the maximum one is taken as the h-index.
     * 
     * Follow up:
     * 
     * This is a follow up problem to H-Index, where citations is now guaranteed to be sorted in ascending order.
     * Could you solve it in logarithmic time complexity?
     */
    public class H_Index_II
    {
        public int HIndex(int[] citations)
        {
            // Same idea based on "274. H-Index".
            // We need to find a citations[i] such that citations[0..i - 1] <= h and citations[i..n] >= h,
            // where h is the number of citations[i..n], which is n - i.
            // If we find such a citations[i], we still need to search in the left part for a potentially
            // larger h.
            int lo = 0;
            int hi = citations.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int h = citations.Length - mid;
                if (citations[mid] >= h) hi = mid;
                else lo = mid + 1;
            }

            return citations.Length - lo;
        }
    }
}
