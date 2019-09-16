namespace Algorithms.LeetCode
{
    /* 190. Reverse Bits
     * 
     * Reverse bits of a given 32 bits unsigned integer.
     * 
     * Example 1:
     * 
     * Input: 00000010100101000001111010011100
     * Output: 00111001011110000010100101000000
     * Explanation: The input binary string 00000010100101000001111010011100 represents
     * the unsigned integer 43261596, so return 964176192 which its binary representation
     * is 00111001011110000010100101000000.
     * 
     * Example 2:
     * 
     * Input: 11111111111111111111111111111101
     * Output: 10111111111111111111111111111111
     * Explanation: The input binary string 11111111111111111111111111111101 represents
     * the unsigned integer 4294967293, so return 3221225471 which its binary representation
     * is 10101111110010110010011101101001.
     * 
     * Follow up:
     * If this function is called many times, how would you optimize it?
     */
    public class ReverseBitsSolution
    {
        public uint ReverseBits(uint n)
        {
            // It's like the following process:
            // abcd efgh
            //    \ /
            //  reverse
            //
            // ef gh   ab cd 
            //  \ /     \ /
            // reverse  reverse
            //
            // g h      e f     c d     a b
            // \/        \/      \/      \/
            // reverse  reverse reverse  reverse
            //
            // hgfedcba(the reverse of abcdefgh)
            n = ((n >> 16) & 0b0000_0000_0000_0000_1111_1111_1111_1111) | ((n << 16) & 0b1111_1111_1111_1111_0000_0000_0000_0000);
            n = ((n >> 8) & 0b0000_0000_1111_1111_0000_0000_1111_1111) | ((n << 8) & 0b1111_1111_0000_0000_1111_1111_0000_0000);
            n = ((n >> 4) & 0b0000_1111_0000_1111_0000_1111_0000_1111) | ((n << 4) & 0b1111_0000_1111_0000_1111_0000_1111_0000);
            n = ((n >> 2) & 0b0011_0011_0011_0011_0011_0011_0011_0011) | ((n << 2) & 0b1100_1100_1100_1100_1100_1100_1100_1100);
            n = ((n >> 1) & 0b0101_0101_0101_0101_0101_0101_0101_0101) | ((n << 1) & 0b1010_1010_1010_1010_1010_1010_1010_1010);
            return n;
        }
    }
}
