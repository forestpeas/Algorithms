namespace Algorithms.LeetCode
{
    /* 1232. Check If It Is a Straight Line
     * 
     * You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the
     * coordinate of a point. Check if these points make a straight line in the XY plane.
     */
    public class CheckIfItIsAStraightLine
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            // Similar to "149. Max Points on a Line".
            var slope = new MaxPointsOnALine.Slope(coordinates[0][0] - coordinates[1][0], coordinates[0][1] - coordinates[1][1]);
            for (int i = 2; i < coordinates.Length; i++)
            {
                var s = new MaxPointsOnALine.Slope(coordinates[i][0] - coordinates[1][0], coordinates[i][1] - coordinates[1][1]);
                if (!s.Equals(slope)) return false;
            }
            return true;
        }
    }
}
