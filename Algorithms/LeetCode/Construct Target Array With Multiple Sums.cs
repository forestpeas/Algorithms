using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1354. Construct Target Array With Multiple Sums
     * 
     * Given an array of integers target. From a starting array, A consisting of all 1's, you may perform
     * the following procedure :
     * 
     *     let x be the sum of all elements currently in your array.
     *     choose index i, such that 0 <= i < target.size and set the value of A at index i to x.
     *     You may repeat this procedure as many times as needed.
     * 
     * Return True if it is possible to construct the target array from A otherwise return False.
     * 
     * Example 1:
     * 
     * Input: target = [9,3,5]
     * Output: true
     * Explanation: Start with [1, 1, 1] 
     * [1, 1, 1], sum = 3 choose index 1
     * [1, 3, 1], sum = 5 choose index 2
     * [1, 3, 5], sum = 9 choose index 0
     * [9, 3, 5] Done
     * 
     * Example 2:
     * 
     * Input: target = [1,1,1,2]
     * Output: false
     * Explanation: Impossible to create target array from [1,1,1,1].
     * 
     * Example 3:
     * 
     * Input: target = [8,5]
     * Output: true
     * 
     * Constraints:
     * N == target.length
     * 1 <= target.length <= 5 * 10^4
     * 1 <= target[i] <= 10^9
     */
    public class Construct_Target_Array_With_Multiple_Sums
    {
        public bool IsPossible(int[] target)
        {
            // If we reverse the process, then every step is determined: find the current maximum
            // number and the number of its previous step should be (currMax - "sum of all other numbers")
            if (target.Length == 1 && target[0] != 1) return false;
            int sum = 0;
            var pq = new PriorityQueue<int>();
            foreach (int num in target)
            {
                pq.Add(num);
                sum += num;
                if (sum >= 2 * 1000000000) return false; // Avoid overflow.
            }

            while (sum != target.Length)
            {
                int max = pq.DeleteTop();
                if (sum - max == 1) return true; // Handle cases like [1,2].
                int prev = max % (sum - max); // Use mod instead of minus to handle cases like [1,1000000000].
                // Handle cases like [1,1,2] and [1,1,1,2].
                if (prev <= 0 || prev == max) return false;
                pq.Add(prev);
                sum = sum - max + prev;
            }

            return true;
        }
    }
}
