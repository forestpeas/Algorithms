using System.Collections.Generic;
using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        // Time complexity : O(NlogN).
        // Space complexity : O(logN).
        // Not stable.
        // In place.
        public static void Sort(int[] array)
        {
            Shuffle(array);
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int lo, int hi)
        {
            if (lo >= hi) return;
            int j = Partition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
        }

        private static int Partition(int[] array, int lo, int hi)
        {
            int v = array[lo]; // partitioning item
            int i = lo + 1, j = hi;
            // Be careful of the edge case where i = j, if array[j] > v, j must still decrease
            // by 1 to ensure that j points to an element smaller than(or equal to) v.
            while (i <= j)
            {
                if (array[i] > v && array[j] < v)
                {
                    Swap(array, i++, j--);
                }
                else if (array[i] <= v)
                {
                    i++;
                }
                else if (array[j] >= v)
                {
                    j--;
                }
            }
            // Now, j points to an element smaller than(or equal to) v. (j might = lo)
            // Swap the partitioning item with array[j], so that a[lo..j-1] <= a[j] <= a[j+1..hi].
            Swap(array, lo, j);
            return j;
        }

        private static void Shuffle(int[] array)
        {
            new LeetCode.ShuffleAnArraySolution.Solution(array).Shuffle();
        }

        // Iterative approach.
        public static void SortIterative(int[] array)
        {
            if (array.Length < 1) return;
            var stack = new Stack<Interval>();
            stack.Push(new Interval() { Lo = 0, Hi = array.Length - 1 });
            while (stack.Count != 0)
            {
                var interval = stack.Pop();
                int j = Partition(array, interval.Lo, interval.Hi);
                if (j - 1 > interval.Lo)
                {
                    stack.Push(new Interval() { Lo = interval.Lo, Hi = j - 1 });
                }
                if (j + 1 < interval.Hi)
                {
                    stack.Push(new Interval() { Lo = j + 1, Hi = interval.Hi });
                }
            }
        }

        private class Interval
        {
            public int Lo { get; set; }
            public int Hi { get; set; }
        }
    }
}
