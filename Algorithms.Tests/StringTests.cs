using Algorithms.Strings;
using Xunit;
using static Algorithms.Strings.KeyIndexedCounting;

namespace Algorithms.Tests
{
    public class StringTests
    {
        [Fact]
        public void TestKeyIndexedCounting()
        {
            var students = new Student[]
            {
                new Student("Anderson", 2),
                new Student("Brown", 3),
                new Student("Davis", 3),
                new Student("Garcia", 4),
                new Student("Harris", 1),
                new Student("Jackson", 3),
                new Student("Jones", 3),
                new Student("Martin", 1),
                new Student("Martinez", 2),
            };

            KeyIndexedCounting.Sort(students);

            Assert.True(students[0].Name == "Harris");
            Assert.True(students[1].Name == "Martin");
            Assert.True(students[2].Name == "Anderson");
            Assert.True(students[3].Name == "Martinez");
            Assert.True(students[4].Name == "Brown");
            Assert.True(students[5].Name == "Davis");
            Assert.True(students[6].Name == "Jackson");
            Assert.True(students[7].Name == "Jones");
            Assert.True(students[8].Name == "Garcia");
        }

        [Fact]
        public void TestLSD()
        {
            string[] input = new string[]
            {
                "4PGC938",
                "2IYE230",
                "3CIO720",
                "1ICK750",
                "1OHV845",
                "4JZY524",
                "1ICK750",
                "3CIO720",
                "1OHV845",
                "1OHV845",
                "2RLA629",
                "2RLA629",
                "3ATW723",
            };

            LSD.Sort(input, 7);

            Assert.True(input[0] == "1ICK750");
            Assert.True(input[1] == "1ICK750");
            Assert.True(input[2] == "1OHV845");
            Assert.True(input[3] == "1OHV845");
            Assert.True(input[4] == "1OHV845");
            Assert.True(input[5] == "2IYE230");
            Assert.True(input[6] == "2RLA629");
            Assert.True(input[7] == "2RLA629");
            Assert.True(input[8] == "3ATW723");
            Assert.True(input[9] == "3CIO720");
            Assert.True(input[10] == "3CIO720");
            Assert.True(input[11] == "4JZY524");
            Assert.True(input[12] == "4PGC938");
        }
    }
}
