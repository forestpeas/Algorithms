using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class BubbleSort
    {
        // Time complexity : O(N^2).
        // Space complexity : O(1).
        // Stable.
        // In place.
        public static void Sort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                bool swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        Swap(array, j + 1, j);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }
    }
}
