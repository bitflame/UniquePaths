using System;
using System.Collections.Generic;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";
            SuggestedProducts(products, searchWord);
            Console.ReadLine();
            
            products = new string [] { "havana" };
            searchWord = "tatiano";
            SuggestedProducts(products, searchWord);

            products = new string[] { "bags", "bagage", "banner", "box", "cloths" };
            searchWord = "bags";
            SuggestedProducts(products, searchWord);
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
            Stack<string> results = new Stack<string>();
            
            if (products == null || products.Length == 0)
            {
                Console.WriteLine("List of products is empty!");
            }
            Array.Sort(products);
            if (string.IsNullOrEmpty(searchWord))
            {
                Console.WriteLine("SearchWord is empty!");
            }
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
            for (int i = 0; i < searchWord.Length; i++)
            {
                for (int j = 0; j < products.Length; j++)
                {
                    if ((searchWord.Substring(0, i) == products[j].Substring(0, i)) && (!results.Contains(products[j])))
                    {
                        results.Push(products[i]);
                    }
                }
                PrintStack(results);
                results.Clear();
            }
            
        }
        private static void PrintStack(Stack<string> s)
        {
            Console.WriteLine("Called Print Stack after a match: ");
            int i = 2;
            while ( s.Count > 0 && i > 0)
            {
                Console.WriteLine(s.Pop());
                i--;
            }
           
        }
    }
}
