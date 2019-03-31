using System;

namespace Algorithms.Sorting
{
    internal static class Utils
    {
        internal static void Swap<T>(T[] array, int i, int j) where T : IComparable
        {
            T tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        internal static bool LessThan<T>(this T x, T y) where T : IComparable
        {
            return x.CompareTo(y) < 0;
        }
    }
}
