namespace Algorithms.LeetCode
{
    /* 211. Add and Search Word - Data structure design
     * 
     * Design a data structure that supports the following two operations:
     * void addWord(word)
     * bool search(word)
     * 
     * search(word) can search a literal word or a regular expression string containing only letters a-z or '.'.
     * A '.' means it can represent any one letter.
     * 
     * Example:
     * 
     * addWord("bad")
     * addWord("dad")
     * addWord("mad")
     * search("pad") -> false
     * search("bad") -> true
     * search(".ad") -> true
     * search("b..") -> true
     * 
     * Note:
     * You may assume that all words are consist of lowercase letters a-z.
     */
    public class WordDictionary
    {
        private readonly Node _root = new Node();

        private class Node
        {
            public bool IsEnd { get; set; } = false;
            public Node[] Next { get; } = new Node[26];
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            Node node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                if (node.Next[index] == null) node.Next[index] = new Node();
                node = node.Next[index];
            }
            node.IsEnd = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Search(_root, word, 0);
        }

        private bool Search(Node node, string word, int i)
        {
            if (node == null) return false;
            if (i == word.Length)
            {
                if (node.IsEnd) return true;
                return false;
            }

            if (word[i] != '.')
            {
                return Search(node.Next[word[i] - 'a'], word, i + 1);
            }
            else
            {
                foreach (Node next in node.Next)
                {
                    if (next == null) continue;
                    if (Search(next, word, i + 1)) return true;
                }
                return false;
            }
        }
    }
}
