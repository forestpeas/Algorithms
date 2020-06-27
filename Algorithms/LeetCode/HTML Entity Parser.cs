using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 1410. HTML Entity Parser
     * 
     * HTML entity parser is the parser that takes HTML code as input and replace all the entities
     * of the special characters by the characters itself.
     * 
     * The special characters and their entities for HTML are:
     * 
     * Quotation Mark: the entity is &quot; and symbol character is ".
     * Single Quote Mark: the entity is &apos; and symbol character is '.
     * Ampersand: the entity is &amp; and symbol character is &.
     * Greater Than Sign: the entity is &gt; and symbol character is >.
     * Less Than Sign: the entity is &lt; and symbol character is <.
     * Slash: the entity is &frasl; and symbol character is /.
     * Given the input text string to the HTML parser, you have to implement the entity parser.
     * 
     * Return the text after replacing the entities by the special characters.
     * 
     * Example 1:
     * 
     * Input: text = "&amp; is an HTML entity but &ambassador; is not."
     * Output: "& is an HTML entity but &ambassador; is not."
     * Explanation: The parser will replace the &amp; entity by &
     * 
     * Example 2:
     * 
     * Input: text = "and I quote: &quot;...&quot;"
     * Output: "and I quote: \"...\""
     * 
     * Example 3:
     * 
     * Input: text = "Stay home! Practice on Leetcode :)"
     * Output: "Stay home! Practice on Leetcode :)"
     * 
     * Example 4:
     * 
     * Input: text = "x &gt; y &amp;&amp; x &lt; y is always false"
     * Output: "x > y && x < y is always false"
     * 
     * Example 5:
     * 
     * Input: text = "leetcode.com&frasl;problemset&frasl;all"
     * Output: "leetcode.com/problemset/all"
     */
    public class HTML_Entity_Parser
    {
        public string EntityParser(string text)
        {
            var map = new Dictionary<string, char>()
            {
                ["&quot;"] = '"',
                ["&apos;"] = '\'',
                ["&amp;"] = '&',
                ["&gt;"] = '>',
                ["&lt;"] = '<',
                ["&frasl;"] = '/'
            };
            var res = new StringBuilder();
            for (int i = 0; i < text.Length;)
            {
                if (text[i] != '&')
                {
                    res.Append(text[i]);
                    i++;
                }
                else
                {
                    string tmp = text.Substring(i, Math.Min(7, text.Length - i));
                    bool found = false;
                    foreach (var item in map)
                    {
                        if (tmp.StartsWith(item.Key))
                        {
                            res.Append(item.Value);
                            i += item.Key.Length;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        res.Append('&');
                        i++;
                    }
                }
            }
            return res.ToString();
        }
    }
}
