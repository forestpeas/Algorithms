namespace Algorithms.LeetCode
{
    /* 1287. Element Appearing More Than 25% In Sorted Array
     * 
     * Given an integer array sorted in non-decreasing order, there is exactly one integer
     * in the array that occurs more than 25% of the time.
     * 
     * Return that integer.
     * 
     * Example 1:
     * 
     * Input: arr = [1,2,2,6,6,6,6,7,10]
     * Output: 6
     */
    public class Element_Appearing_More_Than_25_Percent_In_Sorted_Array
    {
        public int FindSpecialInteger(int[] arr)
        {
            int n = arr.Length;
            foreach (int i in new int[] { n / 4, n / 2, n * 3 / 4 })
            {
                if (UpperBound(arr, arr[i]) - LowerBound(arr, arr[i]) + 1 > n / 4)
                {
                    return arr[i];
                }
            }
            return -1;
        }

        private int LowerBound(int[] arr, int target)
        {
            int lo = 0;
            int hi = arr.Length;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (arr[mid] >= target) hi = mid;
                else lo = mid + 1;
            }
            return lo;
        }

        private int UpperBound(int[] arr, int target)
        {
            int lo = 0;
            int hi = arr.Length;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (arr[mid] > target) hi = mid;
                else lo = mid;
            }
            return lo;
        }
    }
}
