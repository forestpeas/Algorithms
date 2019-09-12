using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class ShellSort
    {
        // Time complexity : less than O(n^2).
        // Space complexity : O(1).
        // Not stable.
        // In place.
        public static void Sort(int[] array)
        {
            int h = 1;
            while (h < array.Length / 3) h = 3 * h + 1; // 1, 4, 13, 40, 121, 364, 1093, ...
            while (h >= 1)
            {
                // h-sort the array.
                for (int i = h; i < array.Length; i++)
                {
                    // Insert a[i] among a[i-h], a[i-2*h], a[i-3*h]...
                    for (int j = i; j >= h && array[j] < array[j - h]; j -= h)
                    {
                        Swap(array, j, j - h);
                    }
                }
                h = h / 3;
            }
        }
    }
}
