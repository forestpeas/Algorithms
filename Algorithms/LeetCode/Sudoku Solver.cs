using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 37. Sudoku Solver
     * 
     * Write a program to solve a Sudoku puzzle by filling the empty cells.
     * A sudoku solution must satisfy all of the following rules:
     * Each of the digits 1-9 must occur exactly once in each row.
     * Each of the digits 1-9 must occur exactly once in each column.
     * Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
     * Empty cells are indicated by the character '.'.
     * 
     * Note:
     * The given board contain only digits 1-9 and the character '.'.
     * You may assume that the given Sudoku puzzle will have a single unique solution.
     * The given board size is always 9x9.
    */
    public class SudokuSolver
    {
        public void SolveSudoku(char[][] board)
        {
            // Backtracking
            var rows = new HashSet<char>[9];
            var columns = new HashSet<char>[9];
            var subBoxes = new HashSet<char>[9];
            // The following initialization is similar to "36. Valid Sudoku".
            for (int i = 0; i < 9; i++)
            {
                var row = new HashSet<char>();
                var column = new HashSet<char>();
                var subBox = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        row.Add(board[i][j]);
                    }
                    if (board[j][i] != '.')
                    {
                        column.Add(board[j][i]);
                    }

                    char subBoxValue = board[j / 3 + (i / 3) * 3][j % 3 + (i % 3) * 3];
                    if (subBoxValue != '.')
                    {
                        subBox.Add(subBoxValue);
                    }
                    rows[i] = row;
                    columns[i] = column;
                    subBoxes[i] = subBox;
                }
            }

            // Now the backtracking.
            Solve(0, 0);

            bool Solve(int i, int j)
            {
                for (; i < 9; i++)
                {
                    if (j >= 9) j = 0;
                    for (; j < 9; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            int subBoxIndex = (i / 3) * 3 + (j / 3);
                            for (char c = '1'; c <= '9'; c++)
                            {
                                if ((!rows[i].Contains(c)) && (!columns[j].Contains(c)) && (!subBoxes[subBoxIndex].Contains(c)))
                                {
                                    board[i][j] = c;
                                    rows[i].Add(c);
                                    columns[j].Add(c);
                                    subBoxes[subBoxIndex].Add(c);
                                    if (Solve(i, j + 1))
                                    {
                                        return true;
                                    }
                                    rows[i].Remove(board[i][j]);
                                    columns[j].Remove(board[i][j]);
                                    subBoxes[subBoxIndex].Remove(board[i][j]);
                                }
                            }
                            board[i][j] = '.';
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
