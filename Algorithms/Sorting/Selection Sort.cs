using System;
using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].LessThan(array[min]))
                    {
                        min = j;
                    }
                }
                Swap(array, i, min);
            }
        }
    }
}
