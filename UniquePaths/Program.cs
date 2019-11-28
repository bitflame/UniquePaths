using System;
using System.Collections.Generic;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Some arguments were passed to program");

                foreach (var item in args)
                {
                    Console.WriteLine(item);
                }
            }
            string[] products = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";
            SuggestedProducts(products, searchWord);
            //SuggestedProdTrie(products, searchWord);
            Console.ReadLine();
            products = new string [] { "havana" };
            searchWord = "tatiano";
            SuggestedProducts(products, searchWord);
            //SuggestedProdTrie(products, searchWord);
            Console.ReadLine();
            products = new string[] { "bags", "bagage", "banner", "box", "cloths" };
            searchWord = "bags";
            SuggestedProducts(products, searchWord);
            //SuggestedProdTrie(products, searchWord);
            Console.ReadLine();
        }
        private static void SuggestedProdTrie(string [] prods, string s)
        {
            Trie t = new Trie();
            Queue<string> q = new Queue<string>();
            foreach (var item in prods)
            {
                t.Insert(item);
            }

            //which words in trie start with substrings of s?
            for (int i = 0; i < s.Length; i++)
            {
                if (t.StartsWith(s.Substring(0,i)) && (!q.Contains(s)))
                {
                    q.Enqueue(s);
                }
                if (q.Count > 0)
                {
                    PrintQueue(q);
                    q.Clear();
                } 
            }
        }
        // This method provides a solution to the Unique Paths problem on LeetCode
        private static int UniquePaths(int m, int n)
        {
            if ((m == 0) || (n == 0))
            {
                return 0; 
            }
            int[,] numberOfPaths = new int [m, n];
            for (int i = 0; i < m; i++)
            {
                numberOfPaths [i, 0] = 1;
                

            }
            for (int j = 0; j < n; j++)
            {
                numberOfPaths[0, j] = 1;
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    numberOfPaths[i, j] = numberOfPaths[i, j - 1] + numberOfPaths[i - 1, j];
                }
            }
            return numberOfPaths[m-1,n-1];
        }

        //This method provides a solution to the problem of Unique Paths II on LeetCode 
        private static int UniquPathsII(int [][] obstacleGrid)
        {
            if (obstacleGrid.Length==0 || obstacleGrid==null || obstacleGrid[0].Length==0)
            {
                return 0;
            }
            int height = obstacleGrid.Length;
            int width = obstacleGrid[0].Length;
            int[,] paths = new int[height, width];
            //for the first column
            for (int i = 0; i < height; i++)
            {
                if (obstacleGrid[i][0] != 1)
                {
                    paths[i, 0] = 1;
                }
                else
                {
                    break;
                }
            }
            //for the first row 
            for (int j = 0; j < width; j++)
            {
                if (obstacleGrid[0][j] != 1)
                {
                    paths[0,j] = 1;
                } else
                {
                    break;
                }
            }
            //for non-edge cells 
            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    if (obstacleGrid[i][j] != 1)
                    {
                        paths[i, j] = paths[i - 1, j] + paths[i, j - 1];
                    }
                }
            }
            return paths[height-1, width-1]; 
        }
        //This method provides a solution to the problem of Search Suggestions System problem on LeetCode 
        private static void SuggestedProducts (string[] products, string searchWord)
        {
            Queue<string> results = new Queue<string>();
            
            if (products == null || products.Length == 0)
            {
                Console.WriteLine("List of products is empty!");
            }
            Array.Sort(products);
            if (string.IsNullOrEmpty(searchWord))
            {
                Console.WriteLine("SearchWord is empty!");
            }
            #region
            //for (int i = 0; i < products.Length; i++)
            //{
            //    for (int j = 1; j < searchWord.Length; j++)
            //    {
            //        if ((searchWord.Substring(0, j) == products[i].Substring(0, j))  && (!results.Contains(products[i])))
            //        {
            //            //Console.WriteLine($"Pushing {products[i]} for {searchWord.Substring(0, j)}" );
            //            results.Push(products[i]);
            //            PrintStack(results);
            //        }
            //    }

            //}
            #endregion
            for (int i = 1; i < searchWord.Length; i++)
            {
                for (int j = 0; j < products.Length; j++)
                {
                    if ((searchWord.Substring(0, i) == products[j].Substring(0, i)) && (!results.Contains(products[j])))
                    {
                        results.Enqueue(products[j]);
                        if (results.Count == 3)
                        {
                            PrintQueue(results);
                            results.Clear();
                            continue;
                        } if ( j > 2 && results.Count < 3)
                        {
                          
                            results.Clear();
                        }
                    }
                    else results.Clear();
                }
                PrintQueue(results);
                results.Clear();
            }
        }
        private static void PrintQueue(Queue<string> s)
        {
            Console.WriteLine("Called Print Stack after a match: ");
            int i = 3;
            while ( s.Count > 0 && i > 0)
            {
                Console.WriteLine(s.Dequeue());
                i--;
            }
            s.Clear();
        }
        private static int gcd( int p, int q)
        {
            if (q == 0)
            {
                return q;
            }
            int r = p % q;
            return gcd(q, r);
        }
        private static int Rank (int key , int [] a)
        {
            return Rank(key, a, 0, a.Length - 1);
        }
        private static int Rank ( int key, int [] a, int lo, int hi)
        {
            if (lo > hi) return -1;
            int mid = lo + (hi - lo) / 2;
            if (key < a[mid]) return Rank(key, a, lo, mid - 1);
            else if (key > a[mid]) return Rank(key, a, mid + 1, hi);
            else return mid;
        }
    }
}
