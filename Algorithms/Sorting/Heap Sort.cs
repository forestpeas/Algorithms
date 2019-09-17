namespace Algorithms.Sorting
{
    public class HeapSort
    {
        // Time complexity : O(NlogN).
        // Space complexity : O(1).
        // Not stable.
        // In place.
        public static void Sort(int[] array)
        {
            int end = array.Length;
            // Construct the heap.
            for (int i = end / 2; i >= 1; i--)
            {
                Sink(array, i, end);
            }

            while (end > 1)
            {
                Swap(array, 1, end--);
                Sink(array, 1, end);
            }
        }

        private static void Sink(int[] array, int k, int end)
        {
            while (2 * k <= end)
            {
                int i = 2 * k;
                int j = 2 * k + 1;
                if (j <= end && Get(array, j) > Get(array, i)) i = j;
                // i now points to the bigger child.
                if (Get(array, i) <= Get(array, k)) break;
                Swap(array, k, i);
                k = i;
            }
        }

        // The numbers below are indexes.
        // array: [0, 1, 2, 3,..., N]
        // heap:  [0, 1, 2, 3,..., N + 1]
        // heap[0] is not used, so map heap[i] to array[i - 1].
        private static int Get(int[] array, int index)
        {
            return array[index - 1];
        }

        private static void Swap(int[] array, int i, int j)
        {
            i--;
            j--;
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
