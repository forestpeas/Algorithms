using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 599. Minimum Index Sum of Two Lists
     * 
     * Suppose Andy and Doris want to choose a restaurant for dinner, and they both have
     * a list of favorite restaurants represented by strings.
     * 
     * You need to help them find out their common interest with the least list index sum.
     * If there is a choice tie between answers, output all of them with no order
     * requirement. You could assume there always exists an answer.
     *  
     * 
     * Example 1:
     * 
     * Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["Piatti",
     * "The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"]
     * Output: ["Shogun"]
     * Explanation: The only restaurant they both like is "Shogun".
     * Example 2:
     * 
     * Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["KFC",
     * "Shogun","Burger King"]
     * Output: ["Shogun"]
     * Explanation: The restaurant they both like and have the least index sum is "Shogun"
     * with index sum 1 (0+1).
     */
    public class Minimum_Index_Sum_of_Two_Lists
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var map = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++)
            {
                map.Add(list1[i], i);
            }

            var res = new List<(string name, int sum)>();
            int minSum = int.MaxValue;
            for (int i = 0; i < list2.Length; i++)
            {
                if (map.TryGetValue(list2[i], out int idx))
                {
                    res.Add((list2[i], idx + i));
                    minSum = Math.Min(minSum, idx + i);
                }
            }
            return res.Where(r => r.sum == minSum).Select(r => r.name).ToArray();
        }
    }
}
