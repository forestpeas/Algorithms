using System;
using static Algorithms.Sorting.Utils;


namespace Algorithms.Sorting
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0 && array[j].LessThan(array[j - 1]); j--)
                {
                    Swap(array, j, j - 1);
                }
            }
        }
    }
}
