using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1268. Search Suggestions System
     * 
     * Given an array of strings products and a string searchWord. We want to design a system that suggests
     * at most three product names from products after each character of searchWord is typed. Suggested
     * products should have common prefix with the searchWord. If there are more than three products with
     * a common prefix return the three lexicographically minimums products.
     * 
     * Return list of lists of the suggested products after each character of searchWord is typed. 
     * 
     * Example 1:
     * 
     * Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
     * Output: [
     * ["mobile","moneypot","monitor"],
     * ["mobile","moneypot","monitor"],
     * ["mouse","mousepad"],
     * ["mouse","mousepad"],
     * ["mouse","mousepad"]
     * ]
     * Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"]
     * After typing m and mo all products match and we show user ["mobile","moneypot","monitor"]
     * After typing mou, mous and mouse the system suggests ["mouse","mousepad"]
     * 
     * Example 2:
     * 
     * Input: products = ["havana"], searchWord = "havana"
     * Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
     * 
     * Example 3:
     * 
     * Input: products = ["bags","baggage","banner","box","cloths"], searchWord = "bags"
     * Output: [["baggage","bags","banner"],["baggage","bags","banner"],["baggage","bags"],["bags"]]
     * 
     * Example 4:
     * 
     * Input: products = ["havana"], searchWord = "tatiana"
     * Output: [[],[],[],[],[],[],[]]
     */
    public class Search_Suggestions_System
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            // Sort and binary search. Alternative approach: Trie.
            Array.Sort(products);
            var result = new List<IList<string>>();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                string sub = searchWord.Substring(0, i);
                int idx = Array.BinarySearch(products, sub);
                if (idx < 0) idx = ~idx;
                var suggestions = new List<string>();
                for (int j = idx; j < idx + 3 && j < products.Length; j++)
                {
                    if (products[j].StartsWith(sub)) suggestions.Add(products[j]);
                }
                result.Add(suggestions);
            }
            return result;
        }
    }
}
