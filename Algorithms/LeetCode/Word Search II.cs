using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 212. Word Search II
     * 
     * Given a 2D board and a list of words from the dictionary, find all words in the board.
     * 
     * Each word must be constructed from letters of sequentially adjacent cell, where "adjacent"
     * cells are those horizontally or vertically neighboring. The same letter cell may not be
     * used more than once in a word.
     * 
     * Example:
     * 
     * Input: 
     * board = [
     *   ['o','a','a','n'],
     *   ['e','t','a','e'],
     *   ['i','h','k','r'],
     *   ['i','f','l','v']
     * ]
     * words = ["oath","pea","eat","rain"]
     * 
     * Output: ["eat","oath"]
     * 
     * Note:
     * All inputs are consist of lowercase letters a-z.
     * The values of words are distinct.
     */
    public class WordSearchII
    {
        private class Node
        {
            public string Word { get; set; } = null;
            public Node[] Next { get; } = new Node[26];
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            // Inspired by https://leetcode.com/problems/word-search-ii/discuss/59780/Java-15ms-Easiest-Solution-(100.00)
            // First we build a trie from the given words. Then everything goes the same as "79. Word Search",
            // except that we can stop going deeper if the current path does not match any word's prefix.
            var result = new List<string>();
            Node root = BuildTrie(words);
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Dfs(i, j, root);
                }
            }
            return result;

            void Dfs(int i, int j, Node node)
            {
                char c = board[i][j];
                if (c == '#') return;
                node = node.Next[c - 'a'];
                if (node == null) return; // The current path does not match any word's prefix, so return immediately.
                if (node.Word != null)
                {
                    result.Add(node.Word);
                    node.Word = null; // There can be more than one path that leads to the same word.
                }

                board[i][j] = '#';
                if (i > 0) Dfs(i - 1, j, node);
                if (j > 0) Dfs(i, j - 1, node);
                if (i < board.Length - 1) Dfs(i + 1, j, node);
                if (j < board[0].Length - 1) Dfs(i, j + 1, node);
                board[i][j] = c;
            }
        }

        private Node BuildTrie(string[] words)
        {
            Node root = new Node();
            foreach (string word in words)
            {
                Node node = root;
                foreach (char c in word)
                {
                    int i = c - 'a';
                    if (node.Next[i] == null) node.Next[i] = new Node();
                    node = node.Next[i];
                }
                node.Word = word;
            }
            return root;
        }
    }
}
