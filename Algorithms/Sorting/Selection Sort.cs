using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class SelectionSort
    {
        // Time complexity : O(n^2).
        // Space complexity : O(1).
        // Not stable.
        // In place.
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                Swap(array, i, min);
            }
        }
    }
}
