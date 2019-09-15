using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 127. Word Ladder
     * 
     * Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest
     * transformation sequence from beginWord to endWord, such that:
     * Only one letter can be changed at a time.
     * Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
     * 
     * Note:
     * Return 0 if there is no such transformation sequence.
     * All words have the same length.
     * All words contain only lowercase alphabetic characters.
     * You may assume no duplicates in the word list.
     * You may assume beginWord and endWord are non-empty and are not the same.
     * 
     * Example 1:
     * 
     * Input:
     * beginWord = "hit",
     * endWord = "cog",
     * wordList = ["hot","dot","dog","lot","log","cog"]
     * 
     * Output: 5
     * 
     * Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
     * return its length 5.
     * 
     * Example 2:
     * 
     * Input:
     * beginWord = "hit"
     * endWord = "cog"
     * wordList = ["hot","dot","dog","lot","log"]
     * 
     * Output: 0
     * 
     * Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.
     */
    public class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            // BFS. Can also be optimized with Bidirectional Breadth First Search: one forward from
            // the initial state and the other backward from the goal, hoping that the two searches
            // meet in the middle. 
            int result = 1;
            var beginWords = new HashSet<string>() { beginWord };
            while (beginWords.Count != 0)
            {
                var nextLevel = new HashSet<string>();
                foreach (string word in beginWords)
                {
                    foreach (string nextWord in wordList)
                    {
                        if (DiffersOnlyOneLetter(nextWord, word))
                        {
                            if (nextWord == endWord) return result + 1;
                            nextLevel.Add(nextWord);
                        }
                    }
                }

                foreach (string word in nextLevel)
                {
                    wordList.Remove(word);
                }

                result++;
                beginWords = nextLevel;
            }
            return 0;
        }

        private bool DiffersOnlyOneLetter(string word1, string word2)
        {
            int count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i])
                {
                    if (++count > 1) return false;
                }
            }
            return count == 1;
        }
    }
}
