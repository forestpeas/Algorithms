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
            var random = new Random();
            int[] array = Enumerable.Repeat(0, 100).Select(_ => random.Next()).ToArray();
            int[] arrayCopy = array.ToArray();
            Array.Sort(arrayCopy);
            SelectionSort.Sort(array);
            Assert.True(Enumerable.SequenceEqual(array, arrayCopy));
        }
    }
}
