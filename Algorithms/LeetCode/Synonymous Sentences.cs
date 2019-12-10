using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1258. Synonymous Sentences
     * 
     * Given a list of pairs of equivalent words synonyms and a sentence text, Return all possible
     * synonymous sentences sorted lexicographically.
     * 
     * Example 1:
     * 
     * Input:
     * synonyms = [["happy","joy"],["sad","sorrow"],["joy","cheerful"]],
     * text = "I am happy today but was sad yesterday"
     * Output:
     * ["I am cheerful today but was sad yesterday",
​​​​​​​     * "I am cheerful today but was sorrow yesterday",
     * "I am happy today but was sad yesterday",
     * "I am happy today but was sorrow yesterday",
     * "I am joy today but was sad yesterday",
     * "I am joy today but was sorrow yesterday"]
     *  
     * Constraints:
     * 0 <= synonyms.length <= 10
     * synonyms[i].length == 2
     * synonyms[0] != synonyms[1]
     * All words consist of at most 10 English letters only.
     * text is a single space separated sentence of at most 10 words.
     */
    public class Synonymous_Sentences
    {
        public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
        {
            // Brute-force.
            var syns = new List<SortedSet<string>>();
            foreach (var synonym in synonyms)
            {
                bool added = false;
                foreach (var set in syns)
                {
                    if (set.Contains(synonym[0]))
                    {
                        set.Add(synonym[1]);
                        added = true;
                        break;
                    }
                    else if (set.Contains(synonym[1]))
                    {
                        set.Add(synonym[0]);
                        added = true;
                        break;
                    }
                }
                if (!added) syns.Add(new SortedSet<string>(synonym, StringComparer.Ordinal));
            }

            var words = text.Split(' ');
            List<List<string>> result = null;
            Generate(0, new List<List<string>>() { new List<string>() });
            return result.Select(x => string.Join(' ', x)).ToArray();

            void Generate(int i, List<List<string>> res)
            {
                if (i >= words.Length)
                {
                    result = res;
                    return;
                }

                SortedSet<string> set = null;
                foreach (var item in syns)
                {
                    if (item.Contains(words[i]))
                    {
                        set = item;
                        break;
                    }
                }

                if (set == null)
                {
                    res.ForEach(x => x.Add(words[i]));
                }
                else
                {
                    var next = new List<List<string>>();
                    foreach (List<string> item in res)
                    {
                        foreach (var word in set)
                        {
                            next.Add(new List<string>(item) { word });
                        }
                    }
                    res = next;
                }

                Generate(i + 1, res);
            }
        }
    }
}
