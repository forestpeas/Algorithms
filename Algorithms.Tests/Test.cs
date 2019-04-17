using Algorithms.Sorting;
using System;
using System.Linq;
using Xunit;

namespace Algorithms.Tests
{
    public class Test
    {
        [Fact]
        public void TestSort()
        {
            Sort(SelectionSort.Sort);
            Sort(InsertionSort.Sort);
        }

        private void Sort(Action<int[]> sort)
        {
            var random = new Random();
            int[] array = Enumerable.Repeat(0, 100).Select(_ => random.Next()).ToArray();
            int[] arrayCopy = array.ToArray();
            Array.Sort(arrayCopy);
            sort(array);
            Assert.True(Enumerable.SequenceEqual(array, arrayCopy));
        }
    }
}
