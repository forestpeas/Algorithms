namespace Algorithms.LeetCode
{
    /* 208. Implement Trie (Prefix Tree)
     * 
     * Implement a trie with insert, search, and startsWith methods.
     * 
     * Example:
     * 
     * Trie trie = new Trie();
     * 
     * trie.insert("apple");
     * trie.search("apple");   // returns true
     * trie.search("app");     // returns false
     * trie.startsWith("app"); // returns true
     * trie.insert("app");   
     * trie.search("app");     // returns true
     * 
     * Note:
     * You may assume that all inputs are consist of lowercase letters a-z.
     * All inputs are guaranteed to be non-empty strings.
     */
    public class Trie
    {
        private readonly Node _root = new Node();

        private class Node
        {
            public bool IsEnd { get; set; } = false;
            public Node[] Next { get; } = new Node[26];
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Insert(_root, word, 0);
        }

        private Node Insert(Node node, string word, int i)
        {
            if (node == null) node = new Node();
            if (i == word.Length)
            {
                node.IsEnd = true;
                return node;
            }
            int index = word[i] - 'a';
            node.Next[index] = Insert(node.Next[index], word, i + 1);
            return node;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Node node = Search(_root, word, 0);
            return node != null && node.IsEnd;
        }

        private Node Search(Node node, string word, int i)
        {
            if (node == null) return null;
            if (i == word.Length) return node;
            return Search(node.Next[word[i] - 'a'], word, i + 1);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Node node = Search(_root, prefix, 0);
            return node != null;
        }
    }
}
