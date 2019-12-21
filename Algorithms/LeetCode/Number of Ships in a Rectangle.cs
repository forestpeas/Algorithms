namespace Algorithms.LeetCode
{
    /* 1274. Number of Ships in a Rectangle
     * 
     * On the sea represented by a cartesian plane, each ship is located at an integer point,
     * and each integer point may contain at most 1 ship.
     * 
     * You have a function Sea.hasShips(topRight, bottomLeft) which takes two points as arguments
     * and returns true if and only if there is at least one ship in the rectangle represented by
     * the two points, including on the boundary.
     * 
     * Given two points, which are the top right and bottom left corners of a rectangle, return the
     * number of ships present in that rectangle.  It is guaranteed that there are at most 10 ships
     * in that rectangle.
     * 
     * Example:
     * Input: 
     * ships = [[1,1],[2,2],[3,3],[5,5]], topRight = [4,4], bottomLeft = [0,0]
     * Output: 3
     * Explanation: From [0,0] to [4,4] we can count 3 ships within the range.
     * 
     * https://leetcode.com/problems/number-of-ships-in-a-rectangle/
     */
    public class Number_of_Ships_in_a_Rectangle
    {
        public int CountShips(Sea sea, int[] topRight, int[] bottomLeft)
        {
            // Divide and Conquer.
            if (!sea.HasShips(topRight, bottomLeft)) return 0;
            if (topRight[0] == bottomLeft[0] && topRight[1] == bottomLeft[1]) return 1;

            if (topRight[0] > bottomLeft[0])
            {
                // Divide into left and right parts.
                int mid = bottomLeft[0] + (topRight[0] - bottomLeft[0]) / 2;
                int left = CountShips(sea, new int[] { mid, topRight[1] }, bottomLeft);
                int right = CountShips(sea, topRight, new int[] { mid + 1, bottomLeft[1] });
                return left + right;
            }
            else
            {
                // Divide into bottom and top parts.
                int mid = bottomLeft[1] + (topRight[1] - bottomLeft[1]) / 2;
                int bottom = CountShips(sea, new int[] { topRight[0], mid }, bottomLeft);
                int top = CountShips(sea, topRight, new int[] { bottomLeft[0], mid + 1 });
                return bottom + top;
            }
        }

        public interface Sea
        {
            bool HasShips(int[] topRight, int[] bottomLeft);
        }
    }
}
