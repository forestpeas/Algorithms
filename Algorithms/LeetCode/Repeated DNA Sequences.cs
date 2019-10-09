using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 187. Repeated DNA Sequences
     * 
     * All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG".
     * When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.
     * Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.
     * 
     * Example:
     * 
     * Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
     * 
     * Output: ["AAAAACCCCC", "CCCCCAAAAA"]
     */
    public class RepeatedDnaSequences
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length <= 10) return new string[0];

            var result = new HashSet<string>();
            var set = new HashSet<string>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string sequence = s.Substring(i, 10);
                if (!set.Add(sequence))
                {
                    result.Add(sequence);
                }
            }

            return result.ToArray();
        }
    }
}
