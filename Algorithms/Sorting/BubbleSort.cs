using System;
using static Algorithms.Sorting.Utils;

namespace Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                bool swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[j + 1].LessThan(array[j]))
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
