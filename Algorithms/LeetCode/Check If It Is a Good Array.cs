namespace Algorithms.LeetCode
{
    /* 1250. Check If It Is a Good Array
     * 
     * Given an array nums of positive integers. Your task is to select some subset of nums,
     * multiply each element by an integer and add all these numbers. The array is said to be
     * good if you can obtain a sum of 1 from the array by any possible subset and multiplicand.
     * 
     * Return True if the array is good otherwise return False.
     * 
     * Example 1:
     * 
     * Input: nums = [12,5,7,23]
     * Output: true
     * Explanation: Pick numbers 5 and 7.
     * 5*3 + 7*(-2) = 1
     * 
     * Example 2:
     * 
     * Input: nums = [29,6,10]
     * Output: true
     * Explanation: Pick numbers 29, 6 and 10.
     * 29*1 + 6*(-3) + 10*(-1) = 1
     * 
     * Example 3:
     * 
     * Input: nums = [3,6]
     * Output: false
     */
    public class Check_If_It_Is_a_Good_Array
    {
        public bool IsGoodArray(int[] nums)
        {
            // Bézout's identity: If gcd(a,b)=d, then there exist integers x and y such that ax+by=d.
            // Let a=nums[0], b=nums[1], then d=ax+by.
            // Let a=d, b=nums[2], then we have another d.
            // If d != 1, then gcd(nums[0],nums[2]) and gcd(nums[1],nums[2]) must also != 1.
            // So we cover all possibilities.
            int gcd = nums[0];
            foreach (int num in nums)
            {
                gcd = Gcd(gcd, num);
                if (gcd == 1) return true;
            }
            return gcd == 1;
        }

        private int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
    }
}
