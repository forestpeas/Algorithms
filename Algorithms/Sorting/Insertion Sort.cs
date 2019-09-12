using static Algorithms.Sorting.Utils;


namespace Algorithms.Sorting
{
    public class InsertionSort
    {
        // Time complexity : O(n^2).
        // Space complexity : O(1).
        // Stable.
        // In place.
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0 && array[j] < array[j - 1]; j--)
                {
                    Swap(array, j, j - 1);
                }
            }
        }
    }
}
