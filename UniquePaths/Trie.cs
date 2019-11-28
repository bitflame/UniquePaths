using System;
using System.Collections.Generic;
using System.Text;

namespace UniquePaths
{
    public class Trie
    {
        private TrieNode root;
        public Trie ()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (!node.ContainsKey(currentChar))
                {
                    node.Put(currentChar, new TrieNode());
                }
                node = node.Get(currentChar);
            }
            node.SetEnd();
        }
        public bool Search(string word)
        {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (node.ContainsKey(currentChar))
                {
                    node = node.Get(currentChar);
                    if (node.GetIsEnd())
                    {
                        return true;
                    }
                }   else
                {
                    return false;
                }
            }
            return false;
        }
        public bool StartsWith ( string prefix)
        {
            TrieNode node = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char currentChar = prefix[i];
                if (node.ContainsKey(currentChar))
                {
                    node = node.Get(currentChar);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class TrieNode
    {
        private TrieNode[] links;
        private static int R = 26;
        private bool isEnd;
        public TrieNode()
        {
            links = new TrieNode[R];
        }
        public bool ContainsKey ( char c)
        {
            return links[c - 'a'] != null;
        }
        public TrieNode Get (char c)
        {
            return links[c - 'a'];
        }
        public void Put (char c, TrieNode node) 
        {
            links[c - 'a'] = node;
        }
        public void SetEnd()
        {
            isEnd = true;
        }
        public bool GetIsEnd()
        {
            return this.isEnd;
        }
    }
}
