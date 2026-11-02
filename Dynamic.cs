using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    internal class DP
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2]; 
            }
            Console.WriteLine(memo[n]);
        }
    }
}
