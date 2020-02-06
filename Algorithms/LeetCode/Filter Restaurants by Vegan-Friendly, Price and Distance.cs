using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1333. Filter Restaurants by Vegan-Friendly, Price and Distance
     * 
     * https://leetcode.com/problems/filter-restaurants-by-vegan-friendly-price-and-distance/
     */
    public class Filter_Restaurants_by_Vegan_Friendly__Price_and_Distance
    {
        public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
        {
            return restaurants
                .Where(r => veganFriendly == 0 ? true : r[2] == 1)
                .Where(r => r[3] <= maxPrice && r[4] <= maxDistance)
                .OrderByDescending(r => r[1])
                .ThenByDescending(r => r[0])
                .Select(r => r[0])
                .ToList();
        }
    }
}
