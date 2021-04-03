using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 648. Replace Words
     * 
     * In English, we have a concept called root, which can be followed by some other word to form another
     * longer word - let's call this word successor. For example, when the root "an" is followed by the
     * successor word "other", we can form a new word "another".
     * 
     * Given a dictionary consisting of many roots and a sentence consisting of words separated by spaces,
     * replace all the successors in the sentence with the root forming it. If a successor can be replaced
     * by more than one root, replace it with the root that has the shortest length.
     * 
     * Return the sentence after the replacement.
     * 
     * Example 1:
     * 
     * Input: dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by the battery"
     * Output: "the cat was rat by the bat"
     * 
     * Example 2:
     * 
     * Input: dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
     * Output: "a a b c"
     * 
     * Example 3:
     * 
     * Input: dictionary = ["a", "aa", "aaa", "aaaa"], sentence = "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa"
     * Output: "a a a a a a a a bbb baba a"
     * 
     * Example 4:
     * 
     * Input: dictionary = ["catt","cat","bat","rat"], sentence = "the cattle was rattled by the battery"
     * Output: "the cat was rat by the bat"
     * 
     * Example 5:
     * 
     * Input: dictionary = ["ac","ab"], sentence = "it is abnormal that this solution is accepted"
     * Output: "it is ab that this solution is ac"
     */
    public class Replace_Words
    {
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            var trie = new Trie();
            foreach (var root in dictionary)
            {
                trie.Insert(root);
            }
            var res = new List<string>();
            foreach (string word in sentence.Split(' '))
            {
                res.Add(trie.GetRoot(word));
            }
            return string.Join(' ', res);
        }

        // almost the same as "208. Implement Trie (Prefix Tree)"
        public class Trie
        {
            private readonly Node _root = new Node();

            private class Node
            {
                public string Root { get; set; } = null;
                public Node[] Next { get; } = new Node[26];
            }

            public void Insert(string word)
            {
                Insert(_root, word, 0);
            }

            private Node Insert(Node node, string word, int i)
            {
                if (node == null) node = new Node();
                if (i == word.Length)
                {
                    node.Root = word;
                    return node;
                }
                int index = word[i] - 'a';
                node.Next[index] = Insert(node.Next[index], word, i + 1);
                return node;
            }

            public string GetRoot(string word)
            {
                Node node = Search(_root, word, 0);
                return (node != null && node.Root != null) ? node.Root : word;
            }

            private Node Search(Node node, string word, int i)
            {
                if (node == null) return null;
                if (i == word.Length) return node;
                if (node.Root != null) return node;
                return Search(node.Next[word[i] - 'a'], word, i + 1);
            }
        }
    }
}
