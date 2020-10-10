namespace Algorithms.LeetCode
{
    /* 461. Hamming Distance
     * 
     * The Hamming distance between two integers is the number of positions at which the
     * corresponding bits are different.
     * 
     * Given two integers x and y, calculate the Hamming distance.
     * 
     * Note:
     * 0 ≤ x, y < 2^31.
     * 
     * Example:
     * 
     * Input: x = 1, y = 4
     * 
     * Output: 2
     * 
     * Explanation:
     * 1   (0 0 0 1)
     * 4   (0 1 0 0)
     *        ↑   ↑
     * 
     * The above arrows point to positions where the corresponding bits are different.
     */
    public class Hamming_Distance
    {
        public int HammingDistance(int x, int y)
        {
            // See "191. Number of 1 Bits".
            int xor = x ^ y;
            int res = 0;
            while (xor != 0)
            {
                res++;
                xor &= xor - 1;
            }
            return res;
        }
    }
}
