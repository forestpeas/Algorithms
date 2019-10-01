using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 315. Count of Smaller Numbers After Self
     * 
     * You are given an integer array nums and you have to return a new counts array. The counts array
     * has the property where counts[i] is the number of smaller elements to the right of nums[i].
     * 
     * Example:
     * 
     * Input: [5,2,6,1]
     * Output: [2,1,1,0] 
     * Explanation:
     * To the right of 5 there are 2 smaller elements (2 and 1).
     * To the right of 2 there is only 1 smaller element (1).
     * To the right of 6 there is 1 smaller element (1).
     * To the right of 1 there is 0 smaller element.
     */
    public class CountOfSmallerNumbersAfterSelf
    {
        public IList<int> CountSmaller(int[] nums)
        {
            // Mergesort solution, similar to "Problem 493. Reverse Pairs". Key idea: Divide and Conquer.
            // The smaller numbers on the right of a number are exactly those that jump from its right
            // to its left during the merging process.
            Element[] array = new Element[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                array[i] = new Element() { index = i, val = nums[i] };
            }

            int[] result = new int[nums.Length];
            MergeSort(array, new Element[nums.Length], 0, nums.Length - 1, result);
            return result;
        }

        private void MergeSort(Element[] array, Element[] aux, int lo, int hi, int[] result)
        {
            if (lo >= hi) return;
            int mid = lo + (hi - lo) / 2;
            MergeSort(array, aux, lo, mid, result);
            MergeSort(array, aux, mid + 1, hi, result);

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = array[k];
            }

            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                // When we need to select aux[i] to the merged array, we add the number of elements
                // in [mid + 1, j - 1] to the corresponding result. The rest is the standard mergesort.
                if (i > mid)
                {
                    array[k] = aux[j++];
                }
                else if (j > hi)
                {
                    result[aux[i].index] += j - (mid + 1);
                    array[k] = aux[i++];
                }
                else if (aux[i].val <= aux[j].val)
                {
                    result[aux[i].index] += j - (mid + 1);
                    array[k] = aux[i++];
                }
                else
                {
                    array[k] = aux[j++];
                }
            }
        }

        private class Element
        {
            public int index;
            public int val;
        }
    }
}
