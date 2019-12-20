using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1276. Number of Burgers with No Waste of Ingredients
     * 
     * Same as the "Chickens and Rabbits" problem.
     * 
     * https://leetcode.com/problems/number-of-burgers-with-no-waste-of-ingredients/
     */
    public class Number_of_Burgers_with_No_Waste_of_Ingredients
    {
        public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            // 4x + 2y = tomatoSlices
            // x + y = cheeseSlices
            // x and y must be non-negative integers.
            if ((tomatoSlices - 2 * cheeseSlices) % 2 != 0) return new int[0];
            if ((4 * cheeseSlices - tomatoSlices) % 2 != 0) return new int[0];
            int x = (tomatoSlices - 2 * cheeseSlices) / 2;
            int y = (4 * cheeseSlices - tomatoSlices) / 2;
            if (x < 0 || y < 0) return new int[0];
            return new int[] { x, y };
        }
    }
}
