using System;

namespace Algorithms.LeetCode
{
    /* 497. Random Point in Non-overlapping Rectangles
     * 
     * Given a list of non-overlapping axis-aligned rectangles rects, write a function pick which
     * randomly and uniformily picks an integer point in the space covered by the rectangles.
     * 
     * Note:
     * 
     * An integer point is a point that has integer coordinates. 
     * A point on the perimeter of a rectangle is included in the space covered by the rectangles. 
     * ith rectangle = rects[i] = [x1,y1,x2,y2], where [x1, y1] are the integer coordinates of the
     * bottom-left corner, and [x2, y2] are the integer coordinates of the top-right corner.
     * length and width of each rectangle does not exceed 2000.
     * 1 <= rects.length <= 100
     * pick return a point as an array of integer coordinates [p_x, p_y]
     * pick is called at most 10000 times.
     * 
     * Example 1:
     * 
     * Input: 
     * ["Solution","pick","pick","pick"]
     * [[[[1,1,5,5]]],[],[],[]]
     * Output: 
     * [null,[4,1],[4,1],[3,3]]
     * 
     * Example 2:
     * 
     * Input: 
     * ["Solution","pick","pick","pick","pick","pick"]
     * [[[[-2,-2,-1,-1],[1,0,3,0]]],[],[],[],[],[]]
     * Output: 
     * [null,[-1,-2],[2,0],[-2,-1],[3,0],[-2,-2]]
     * Explanation of Input Syntax:
     * 
     * The input is two lists: the subroutines called and their arguments. Solution's constructor
     * has one argument, the array of rectangles rects. pick has no arguments. Arguments are
     * always wrapped with a list, even if there aren't any.
     */
    public class Random_Point_in_Non_overlapping_Rectangles
    {
        public class Solution
        {
            private readonly int[] _pointNo;
            private readonly int _totalPoints = 0;
            private readonly Random _random = new Random();
            private readonly int[][] _rects;

            public Solution(int[][] rects)
            {
                // Give each point a serial number.
                _rects = rects;
                _pointNo = new int[rects.Length];
                for (int i = 0; i < rects.Length; i++)
                {
                    _totalPoints += (rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1] + 1);
                    _pointNo[i] = _totalPoints;
                }
            }

            public int[] Pick()
            {
                // Search the rectangle that this random point belongs to.
                int no = _random.Next(1, _totalPoints + 1);
                int idx = Array.BinarySearch(_pointNo, no);
                if (idx < 0) idx = ~idx;
                int[] rect = _rects[idx];
                return new int[] { _random.Next(rect[0], rect[2] + 1), _random.Next(rect[1], rect[3] + 1) };
            }
        }
    }
}
