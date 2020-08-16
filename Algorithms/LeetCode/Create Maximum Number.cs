using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 321. Create Maximum Number
     * 
     * Given two arrays of length m and n with digits 0-9 representing two numbers. Create the maximum
     * number of length k <= m + n from digits of the two. The relative order of the digits from the
     * same array must be preserved. Return an array of the k digits.
     * 
     * Note: You should try to optimize your time and space complexity.
     * 
     * Example 1:
     * 
     * Input:
     * nums1 = [3, 4, 6, 5]
     * nums2 = [9, 1, 2, 5, 8, 3]
     * k = 5
     * Output:
     * [9, 8, 6, 5, 3]
     * 
     * Example 2:
     * 
     * Input:
     * nums1 = [6, 7]
     * nums2 = [6, 0, 4]
     * k = 5
     * Output:
     * [6, 7, 6, 0, 4]
     * 
     * Example 3:
     * 
     * Input:
     * nums1 = [3, 9]
     * nums2 = [8, 9]
     * k = 3
     * Output:
     * [9, 8, 9]
     */
    public class Create_Maximum_Number
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            // I tried to solve it by choosing the next maximum digit and add it to the result,
            // but the crux is that if the next maximum digit from nums1 and nums2 are equal,
            // you don't know which one to choose. There are always failed test cases.
            // So below is a solution from: https://leetcode.com/problems/create-maximum-number/discuss/77285/Share-my-greedy-solution
            int m = nums1.Length, n = nums2.Length;
            int[] res = new int[k];
            // Choose a maximum number with 1 digits from nums1 and k-i digits from nums2, then
            // merge them and we have potential result.
            for (int i = Math.Max(0, k - n); i <= k && i <= m; i++)
            {
                int[] candidate = Merge(MaxArray(nums1, i), MaxArray(nums2, k - i));
                if (Greater(candidate, 0, res, 0)) res = candidate;
            }
            return res;
        }

        // Create a maximum number from nums1 and nums2 using all their digits.
        private int[] Merge(int[] nums1, int[] nums2)
        {
            int[] ans = new int[nums1.Length + nums2.Length];
            for (int i = 0, j = 0, r = 0; r < nums1.Length + nums2.Length; r++)
                ans[r] = Greater(nums1, i, nums2, j) ? nums1[i++] : nums2[j++];
            return ans;
        }

        // Whether we can create a greater number from nums1 or nums2.
        public bool Greater(int[] nums1, int i, int[] nums2, int j)
        {
            while (i < nums1.Length && j < nums2.Length && nums1[i] == nums2[j])
            {
                i++;
                j++;
            }
            return j == nums2.Length || (i < nums1.Length && nums1[i] > nums2[j]);
        }

        // Create a maximum number using k digits from a single array.
        private int[] MaxArray(int[] nums, int k)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count + nums.Length - i > k && stack.Count != 0 && stack.Peek() < nums[i])
                {
                    stack.Pop();
                }
                if (stack.Count < k)
                {
                    stack.Push(nums[i]);
                }
            }
            return stack.Reverse().ToArray();
        }
    }
}
