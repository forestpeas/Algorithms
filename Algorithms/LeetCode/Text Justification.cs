using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 68. Text Justification
     * 
     * Given an array of words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.
     * You should pack your words in a greedy approach; that is, pack as many words as you can in each line. 
     * Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.
     * Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, 
     * the empty slots on the left will be assigned more spaces than the slots on the right.
     * For the last line of text, it should be left justified and no extra space is inserted between words.
     * 
     * Note:
     * 
     * A word is defined as a character sequence consisting of non-space characters only.
     * Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
     * The input array words contains at least one word.
     * 
     * Example 1:
     * 
     * Input:
     * words = ["This", "is", "an", "example", "of", "text", "justification."]
     * maxWidth = 16
     * Output:
     * [
     *    "This    is    an",
     *    "example  of text",
     *    "justification.  "
     * ]
     * 
     * Example 2:
     * 
     * Input:
     * words = ["What","must","be","acknowledgment","shall","be"]
     * maxWidth = 16
     * Output:
     * [
     *   "What   must   be",
     *   "acknowledgment  ",
     *   "shall be        "
     * ]
     * Explanation: Note that the last line is "shall be    " instead of "shall     be",
     *              because the last line must be left-justified instead of fully-justified.
     *              Note that the second line is also left-justified becase it contains only one word.
     * 
     * Example 3:
     * 
     * Input:
     * words = ["Science","is","what","we","understand","well","enough","to","explain",
     *          "to","a","computer.","Art","is","everything","else","we","do"]
     * maxWidth = 20
     * Output:
     * [
     *   "Science  is  what we",
     *   "understand      well",
     *   "enough to explain to",
     *   "a  computer.  Art is",
     *   "everything  else  we",
     *   "do                  "
     * ]
     */
    public class TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            // Found a post in Discussion, maybe he is right: 
            // I found this question is only useful to evaluate someone's coding skill and detail-oriented mindset. not that interesting from algorithm perspective.
            var result = new List<string>();
            int widthLeft = maxWidth;
            int start = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                widthLeft = widthLeft - words[i].Length;
                if (1 + words[i + 1].Length > widthLeft)
                {
                    StringBuilder line = new StringBuilder(maxWidth);
                    // "gapNum" is the number of gaps between words.
                    int gapNum = i - start;
                    if (gapNum == 0)
                    {
                        line.Append(words[i]);
                        int n = maxWidth - line.Length;
                        for (int j = 0; j < n; j++)
                        {
                            line.Append(' ');
                        }
                    }
                    else
                    {
                        widthLeft += gapNum; // plus every single space we have taken into account.
                        int spaceNumAtLeast = widthLeft / gapNum;
                        widthLeft = widthLeft - spaceNumAtLeast * gapNum;
                        for (int j = start; j < i; j++)
                        {
                            line.Append(words[j]);
                            for (int k = 0; k < spaceNumAtLeast; k++)
                            {
                                line.Append(' ');
                            }
                            if (widthLeft > 0)
                            {
                                line.Append(' ');
                                widthLeft--;
                            }
                        }
                        line.Append(words[i]);
                    }
                    result.Add(line.ToString());
                    widthLeft = maxWidth;
                    start = i + 1;
                }
                else
                {
                    widthLeft--;
                }
            }
            if (start != words.Length)
            {
                StringBuilder line = new StringBuilder(maxWidth);
                line.Append(words[start]);
                for (int i = start + 1; i < words.Length; i++)
                {
                    line.Append(' ');
                    line.Append(words[i]);
                }
                int n = maxWidth - line.Length;
                for (int i = 0; i < n; i++)
                {
                    line.Append(' ');
                }
                result.Add(line.ToString());
            }
            return result;
        }
    }
}
