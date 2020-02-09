using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1338. Reduce Array Size to The Half
     * 
     * Given an array arr.  You can choose a set of integers and remove all the occurrences of these integers
     * in the array.
     * 
     * Return the minimum size of the set so that at least half of the integers of the array are removed.
     * 
     * Example 1:
     * 
     * Input: arr = [3,3,3,3,5,5,5,2,2,7]
     * Output: 2
     * Explanation: Choosing {3,7} will make the new array [5,5,5,2,2] which has size 5 (i.e equal to half of
     * the size of the old array).
     * Possible sets of size 2 are {3,5},{3,2},{5,2}.
     * Choosing set {2,7} is not possible as it will make the new array [3,3,3,3,5,5,5] which has size greater
     * than half of the size of the old array.
     * 
     * Example 2:
     * 
     * Input: arr = [7,7,7,7,7,7]
     * Output: 1
     * Explanation: The only possible set you can choose is {7}. This will make the new array empty.
     * 
     * Example 3:
     * 
     * Input: arr = [1,9]
     * Output: 1
     * 
     * Example 4:
     * 
     * Input: arr = [1000,1000,3,7]
     * Output: 1
     * 
     * Example 5:
     * 
     * Input: arr = [1,2,3,4,5,6,7,8,9,10]
     * Output: 5
     */
    public class Reduce_Array_Size_to_The_Half
    {
        public int MinSetSize(int[] arr)
        {
            // Sort and use the number with greater frequency first.
            var counts = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                counts[num] = counts.GetValueOrDefault(num) + 1;
            }

            int n = 0;
            int result = 0;
            foreach (var item in counts.Select(i => new Item(i.Key, i.Value)).OrderByDescending(i => i.count))
            {
                n += item.count;
                result++;
                if (n >= arr.Length / 2) break;
            }

            return result;
        }

        private class Item
        {
            public readonly int val;
            public readonly int count;
            public Item(int val, int count)
            {
                this.val = val;
                this.count = count;
            }
        }
    }
}
