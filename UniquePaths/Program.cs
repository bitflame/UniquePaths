using System;
using System.Collections.Generic;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] products = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";
            SuggestedProducts(products, searchWord);
            
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
        private static string[] SuggestedProducts (string[] products, string searchWord)
        {
            Stack<string> results = new Stack<string>();
            if (products == null || products.Length == 0)
            {
                return null;
            }
            Array.Sort(products);
            if (string.IsNullOrEmpty(searchWord))
            {
                return results.ToArray();
            }

            if (results.Count == 3)
            {
                return results.ToArray();
            }
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = 0; j < searchWord.Length; j++)
                {
                    if (searchWord.Substring(i, j - i) == products[i].Substring(i, j - i))
                    {
                        results.Push(products[i]);
                    }
                    else
                        results.Clear();
                }
            }
                
            return results.ToArray();
        }
        private static Stack<string> ReturnFirstThree(string [] s)
        {
            Stack<string> temp = new Stack<string>();
            for (int i = 0; i < 2; i++)
            {
                temp.Push(s[i]);
            }
            return temp;
        }
    }
}
