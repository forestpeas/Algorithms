namespace Algorithms.Searching
{
    public class BinarySearch
    {
        /* There are several typical templates for binary search.
         * We need to consider some corner cases: 
         * When array has only one element, make sure we can enter the loop.
         * When lo + 1 = hi - 1, mid = lo + 1 = hi - 1.
         * When lo + 1 = hi, mid = lo.
         */

        public static int Search1(int[] array, int target)
        {
            // Search range is [lo, hi].
            int lo = 0;
            int hi = array.Length - 1;
            while (lo <= hi) // Loop ends when lo - 1 == hi.
            {
                int mid = lo + (hi - lo) / 2;
                if (array[mid] > target)
                {
                    hi = mid - 1;
                }
                else if (array[mid] < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static int Search2(int[] array, int target)
        {
            // Search range is [lo, hi).
            int lo = 0;
            int hi = array.Length;
            while (lo < hi) // Loop ends when lo == hi.
            {
                int mid = lo + (hi - lo) / 2;
                if (array[mid] > target)
                {
                    // When hi has been assigned mid, the search range is still [lo,hi).
                    // Because hi was already checked by mid.
                    hi = mid;
                }
                else if (array[mid] < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
