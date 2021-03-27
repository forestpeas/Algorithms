namespace Algorithms.LeetCode
{
    /* 657. Robot Return to Origin
     * 
     * There is a robot starting at position (0, 0), the origin, on a 2D plane. Given a sequence of
     * its moves, judge if this robot ends up at (0, 0) after it completes its moves.
     * 
     * The move sequence is represented by a string, and the character moves[i] represents its ith
     * move. Valid moves are R (right), L (left), U (up), and D (down). If the robot returns to the
     * origin after it finishes all of its moves, return true. Otherwise, return false.
     * 
     * Example 1:
     * 
     * Input: moves = "UD"
     * Output: true
     * Explanation: The robot moves up once, and then down once. All moves have the same magnitude,
     * so it ended up at the origin where it started. Therefore, we return true.
     * 
     * Example 2:
     * 
     * Input: moves = "LL"
     * Output: false
     * Explanation: The robot moves left twice. It ends up two "moves" to the left of the origin.
     * We return false because it is not at the origin at the end of its moves.
     * 
     * Example 3:
     * 
     * Input: moves = "RRDD"
     * Output: false
     * 
     * Example 4:
     * 
     * Input: moves = "LDRRLRUULR"
     * Output: false
     */
    public class Robot_Return_to_Origin
    {
        public bool JudgeCircle(string moves)
        {
            int l = 0, r = 0, u = 0, d = 0;
            foreach (char m in moves)
            {
                if (m == 'L') l++;
                else if (m == 'R') r++;
                else if (m == 'U') u++;
                else d++;
            }
            return l == r && u == d;
        }
    }
}
