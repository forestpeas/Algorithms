using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1222. Queens That Can Attack the King
     * 
     * On an 8x8 chessboard, there can be multiple Black Queens and one White King.
     * Given an array of integer coordinates queens that represents the positions of the Black Queens,
     * and a pair of coordinates king that represent the position of the White King, return the
     * coordinates of all the queens (in any order) that can attack the King.
     * 
     * https://leetcode.com/problems/queens-that-can-attack-the-king/
     */
    public class Queens_That_Can_Attack_the_King
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            char[,] board = new char[8, 8];
            foreach (int[] queen in queens) board[queen[0], queen[1]] = 'Q';

            var result = new List<IList<int>>();
            foreach (int i in new int[] { -1, 0, 1 })
            {
                foreach (int j in new int[] { -1, 0, 1 })
                {
                    foreach (int k in Enumerable.Range(1, 7))
                    {
                        int x = king[0] + i * k;
                        int y = king[1] + j * k;
                        if (x < 0 || x > 7 || y < 0 || y > 7) break;
                        if (board[x, y] == 'Q')
                        {
                            result.Add(new int[] { x, y });
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public IList<IList<int>> QueensAttacktheKing2(int[][] queens, int[] king)
        {
            char[,] board = new char[8, 8];
            foreach (int[] queen in queens) board[queen[0], queen[1]] = 'Q';

            var result = new List<IList<int>>();
            foreach (int[] queen in queens)
            {
                if (IsValid(queen)) result.Add(queen);
            }
            return result;

            bool IsValid(int[] queen)
            {
                if (queen[0] == king[0])
                {
                    for (int i = Math.Min(queen[1], king[1]) + 1; i < Math.Max(queen[1], king[1]); i++)
                    {
                        if (board[queen[0], i] == 'Q') return false;
                    }
                    return true;
                }
                else if (queen[1] == king[1])
                {
                    for (int i = Math.Min(queen[0], king[0]) + 1; i < Math.Max(queen[0], king[0]); i++)
                    {
                        if (board[i, queen[1]] == 'Q') return false;
                    }
                    return true;
                }
                else if (Math.Abs(queen[0] - king[0]) == Math.Abs(queen[1] - king[1]))
                {
                    int signRow = queen[0] - king[0] > 0 ? 1 : -1;
                    int signCol = queen[1] - king[1] > 0 ? 1 : -1;
                    for (int i = 1; i < Math.Abs(queen[0] - king[0]); i++)
                    {
                        if (board[king[0] + signRow * i, king[1] + signCol * i] == 'Q') return false;
                    }
                    return true;
                }

                return false;
            }
        }
    }
}
