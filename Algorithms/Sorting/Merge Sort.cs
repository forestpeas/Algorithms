namespace Algorithms.Sorting
{
    public class MergeSort
    {
        // Time complexity : O(NlogN).
        // Space complexity : O(N).
        // Stable.
        // Not in place.
        public static void Sort(int[] array)
        {
            int[] aux = new int[array.Length]; // Auxiliary array for merges.
            Sort(0, array.Length - 1);

            // Sort array[lo...hi]
            void Sort(int lo, int hi)
            {
                if (lo >= hi) return;
                int mid = lo + (hi - lo) / 2;
                Sort(lo, mid);
                Sort(mid + 1, hi);
                Merge(array, aux, lo, mid, hi);
            }
        }

        private static void Merge(int[] array, int[] aux, int lo, int mid, int hi)
        {
            // Merge array[lo...mid] with array[mid + 1...hi]
            for (int k = lo; k <= hi; k++) // Copy array[lo..hi] to aux[lo..hi].
            {
                aux[k] = array[k];
            }

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) // Merge aux[lo..hi] back to array[lo..hi].
            {
                if (i > mid) array[k] = aux[j++];
                else if (j > hi) array[k] = aux[i++];
                else if (aux[i] < aux[j]) array[k] = aux[i++];
                else array[k] = aux[j++];
            }
        }
    }
}
