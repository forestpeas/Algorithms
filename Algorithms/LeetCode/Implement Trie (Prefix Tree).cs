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
        private class Node
        {
            public bool IsEnd { get; set; } = false;
            public Node[] Next { get; } = new Node[256];
        }

        private readonly Node _root = new Node();

        public void Insert(string word)
        {
            Node node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.Next[word[i]] == null)
                {
                    node.Next[word[i]] = new Node();
                }
                node = node.Next[word[i]];
            }
            node.IsEnd = true;
        }

        private Node SearchPrefix(string word)
        {
            Node node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                node = node.Next[word[i]];
                if (node == null)
                {
                    return null;
                }
            }
            return node;
        }

        public bool Search(string word)
        {
            var node = SearchPrefix(word);
            return node != null && node.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            var node = SearchPrefix(prefix);
            return node != null;
        }
    }

    // recursive implementation
    public class Trie2
    {
        private class Node
        {
            public bool IsEnd { get; set; } = false;
            public Node[] Next { get; } = new Node[256];
        }

        private readonly Node _root = new Node();

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

        public bool Search(string word)
        {
            Node node = SearchPrefix(_root, word, 0);
            return node != null && node.IsEnd;
        }

        private Node SearchPrefix(Node node, string word, int i)
        {
            if (node == null) return null;
            if (i == word.Length) return node;
            return SearchPrefix(node.Next[word[i] - 'a'], word, i + 1);
        }

        public bool StartsWith(string prefix)
        {
            Node node = SearchPrefix(_root, prefix, 0);
            return node != null;
        }
    }
}
