namespace Algorithms.LeetCode
{
    /* 1823. Find the Winner of the Circular Game
     *  
     * https://leetcode.com/problems/find-the-winner-of-the-circular-game/
     */
    public class Find_the_Winner_of_the_Circular_Game
    {
        public int FindTheWinner(int n, int m)
        {
            // Josephus Problem
            return F(n) + 1;

            int F(int n)
            {
                if (n == 1) return 0;
                return (F(n - 1) + m) % n;
            }
        }
    }
}
