using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 1324. Print Words Vertically
     * 
     * Given a string s. Return all the words vertically in the same order in which they appear in s.
     * Words are returned as a list of strings, complete with spaces when is necessary. (Trailing
     * spaces are not allowed).
     * Each word would be put on only one column and that in one column there will be only one word.
     * 
     * Example 1:
     * 
     * Input: s = "HOW ARE YOU"
     * Output: ["HAY","ORO","WEU"]
     * Explanation: Each word is printed vertically. 
     *  "HAY"
     *  "ORO"
     *  "WEU"
     * 
     * Example 2:
     * 
     * Input: s = "TO BE OR NOT TO BE"
     * Output: ["TBONTB","OEROOE","   T"]
     * Explanation: Trailing spaces is not allowed. 
     * "TBONTB"
     * "OEROOE"
     * "   T"
     * 
     * Example 3:
     * 
     * Input: s = "CONTEST IS COMING"
     * Output: ["CIC","OSO","N M","T I","E N","S G","T"]
     */
    public class Print_Words_Vertically
    {
        public IList<string> PrintVertically(string s)
        {
            var words = s.Split(' ');
            var result = new StringBuilder[words.Max(w => w.Length)];
            for (int i = 0; i < result.Length; i++) result[i] = new StringBuilder();
            foreach (var word in words)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    char c = i < word.Length ? word[i] : ' ';
                    result[i].Append(c);
                }
            }

            return result.Select(sb => sb.ToString().TrimEnd()).ToList();
        }
    }
}
