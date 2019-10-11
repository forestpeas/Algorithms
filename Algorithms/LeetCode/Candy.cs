using System.Linq;

namespace Algorithms.LeetCode
{
    /* 135. Candy
     * 
     * There are N children standing in a line. Each child is assigned a rating value.
     * 
     * You are giving candies to these children subjected to the following requirements:
     * Each child must have at least one candy.
     * Children with a higher rating get more candies than their neighbors.
     * 
     * What is the minimum candies you must give?
     * 
     * Example 1:
     * 
     * Input: [1,0,2]
     * Output: 5
     * Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
     * 
     * Example 2:
     * 
     * Input: [1,2,2]
     * Output: 4
     * Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
     *              The third child gets 1 candy because it satisfies the above two conditions.
     */
    public class CandySolution
    {
        public int Candy(int[] ratings)
        {
            // There is another solution based on bottoms and peaks:
            // we can draw the rating points on a graph, all the bottom points should be given 1 candy,
            // and from bottom to peak is an increasing range starting from 1.
            // Refer to this picture: https://leetcode.com/articles/Figures/135_Candy_Constant_Space.PNG

            int[] candies = new int[ratings.Length]; // Represents the distributed candies.
            System.Array.Fill(candies, 1);

            // From left to right, make sure each element is bigger than its previous element.
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            // From right tot left, make sure each element is bigger than its next element.
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1])
                {
                    candies[i] = candies[i + 1] + 1;
                }
            }

            return candies.Sum();
        }
    }
}
