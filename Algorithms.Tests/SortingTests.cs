using Algorithms.Sorting;
using System;
using System.Linq;
using Xunit;

namespace Algorithms.Tests
{
    public class SortingTests
    {
        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 })]
        [InlineData(new int[] { 46, 15, 37, 11, 66, 67, 70, 96, 49, 64 })]
        [InlineData(new int[] { 25, 96, 76, 27, 65, 86, 83, 13, 61, 31, 29, 87, 37, 8, 58, 20, 77, 54, 58, 9 })]
        public void TestSortingAlgorithms(int[] array)
        {
            TestSort(SelectionSort.Sort, array);
            TestSort(BubbleSort.Sort, array);
            TestSort(InsertionSort.Sort, array);
            TestSort(ShellSort.Sort, array);
            TestSort(MergeSort.Sort, array);
            TestSort(QuickSort.Sort, array);
            TestSort(QuickSort.SortIterative, array);
            TestSort(HeapSort.Sort, array);
        }

        private void TestSort(Action<int[]> sort, int[] array)
        {
            array = array.ToArray(); // Leave caller's array unchanged.
            int[] arrayCopy = array.ToArray();
            sort(array);
            Array.Sort(arrayCopy);
            Assert.True(Enumerable.SequenceEqual(array, arrayCopy));
        }
    }
}
