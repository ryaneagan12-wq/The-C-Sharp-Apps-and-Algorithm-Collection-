using System;
using System.Collections.Generic;

namespace Binary_Search_solo
{
    class SearchingBinary
    {
        static List<List<int>> ArrayNodes = new List<List<int>> {};
        static void Main(string[] args)
        {
            int RootPointer = 0;
            for (int i = 0; i < 20; i++)
            {
                ArrayNodes.Add(new List<int> { -1, -1, -1 });
                ArrayNodes = new List<List<int>>{ new List<int> { 1, 20, 5 }, new List<int> { 2, 15, -1 }, new List<int> { -1, 3, 3 }, new List<int> { -1, 9, 4 }, new List<int> { -1, 10, -1 }, new List<int> { -1, 58, -1 } };
                int FreeNodes = 6;
                RootPointer = 0;
            }
            int Search = SearchValue(0, 15);
            if (Search == -1)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine($"Found at,{Search.ToString()}");
            }
            PostOrder(ArrayNodes[RootPointer]);
        }
        static int SearchValue(int Root, int ValueToFind)
        {
            if (Root == -1)
            {
                return -1;
            }
            else if (ArrayNodes[Root][1] == ValueToFind)
            {
                return Root;
            }
            else if (ArrayNodes[Root][1] == -1)
            {
                return -1;
            }
            if (ArrayNodes[Root][1] > ValueToFind)
            {
                return SearchValue(ArrayNodes[Root][0], ValueToFind);
            }
            else if (ArrayNodes[Root][1] < ValueToFind)
            {
                return SearchValue(ArrayNodes[Root][2], ValueToFind);
            }
            return 1;
        }
        static void PostOrder(List<int>RootNode)
        {
            if (RootNode[0] != -1)
            {
                PostOrder(ArrayNodes[RootNode[0]]);
            }
            if (RootNode[2] != -1)
            {
                PostOrder(ArrayNodes[RootNode[2]]);
            }
            Console.WriteLine(RootNode[1].ToString());
        }
    }
}
