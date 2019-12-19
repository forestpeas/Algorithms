namespace Algorithms.LeetCode
{
    /* 1275. Find Winner on a Tic Tac Toe Game
     * 
     * Tic-tac-toe is played by two players A and B on a 3 x 3 grid.
     * 
     * https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game/
     */
    public class Find_Winner_on_a_Tic_Tac_Toe_Game
    {
        public string Tictactoe(int[][] moves)
        {
            char[,] grid = new char[3, 3];
            bool A = true;
            foreach (var move in moves)
            {
                grid[move[0], move[1]] = A ? 'X' : 'O';
                A = !A;
            }

            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] != '\0' && grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                {
                    return grid[i, 0] == 'X' ? "A" : "B";
                }

                if (grid[0, i] != '\0' && grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                {
                    return grid[0, i] == 'X' ? "A" : "B";
                }
            }

            if (grid[1, 1] != '\0' && grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
            {
                return grid[1, 1] == 'X' ? "A" : "B";
            }

            if (grid[1, 1] != '\0' && grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
            {
                return grid[1, 1] == 'X' ? "A" : "B";
            }

            if (moves.Length == 9) return "Draw";
            return "Pending";
        }
    }
}
