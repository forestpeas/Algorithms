namespace Algorithms.LeetCode
{
    /* 137. Single Number II
     * 
     * Given a non-empty array of integers, every element appears three times except for one,
     * which appears exactly once. Find that single one.
     * 
     * Note:
     * Your algorithm should have a linear runtime complexity. Could you implement it without
     * using extra memory?
     * 
     * Example 1:
     * 
     * Input: [2,2,3,2]
     * Output: 3
     * 
     * Example 2:
     * 
     * Input: [0,1,0,1,0,1,99]
     * Output: 99
     */
    public class SingleNumberII
    {
        public int SingleNumber(int[] nums)
        {
            /* Truth table:
             * 
             * +============+=====+============+
             * |       input      |   output   |
             * ++=====+=====+=====+=====+=====++
             * ||  a  |  b  | num |  a' |  b' ||
             * ++-----+-----+-----+-----+-----++
             * ||  0  |  0  |  0  |  0  |  0  ||
             * ++-----+-----+-----+-----+-----++
             * ||  0  |  1  |  0  |  0  |  1  ||
             * ++-----+-----+-----+-----+-----++
             * ||  1  |  0  |  0  |  1  |  0  ||
             * ++-----+-----+-----+-----+-----++
             * ||  0  |  0  |  1  |  0  |  1  ||
             * ++-----+-----+-----+-----+-----++
             * ||  0  |  1  |  1  |  1  |  0  ||
             * ++-----+-----+-----+-----+-----++
             * ||  1  |  0  |  1  |  0  |  0  ||
             * ++===========+=====+===========++
             * 
             * When num = 0, a and b remain unchanged.
             * When num = 1, a and b's state transition is: 00->01->10->00->...
             * Initially a and b are 0.
             * In the end, ab will be in state: 01 (or 00 when num = 0),
             * and b = num = 1, so b records the number that appears only once.
             * I guess how we can get the formula:
             * b = (b ^ num) & ~a;
             * a = (a ^ num) & ~b;
             * from the truth table is a matter of luck, unless we are the master
             * of designing digital circuits.
             */
            int a = 0, b = 0;
            foreach (int num in nums)
            {
                b = (b ^ num) & ~a;
                a = (a ^ num) & ~b;
            }
            return b;
        }
    }
}
