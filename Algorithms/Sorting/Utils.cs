using System;

namespace Algorithms.Sorting
{
    internal class Utils
    {
        internal static void Swap<T>(T[] array, int i, int j) where T : IComparable
        {
            T tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
