using System;
using System.Collections.Generic;

namespace LinkList66
{
    class LinkList
    {
        static int FirstNode = -1;
        static int FirstEmpty = 0;
        static List<List<int>> LinkedList = new List<List<int>> { };

        static void Main(string[] args)
        {
            for (int x = 0; x < 19; x++)
            {
                LinkedList.Add(new List<int> { -1,x + 1});
            }
            LinkedList.Add(new List<int> { -1, -1 });
            InsertData();
            Console.WriteLine("Before:");
            OutputLinkedList();
            RemoveData(5);
            Console.WriteLine("After:");
            OutputLinkedList();
        }
        static void InsertData()
        {
            for (int x = 0; x < 5;x++)
            {
                if (FirstEmpty != -1)
                {
                    int num = LinkedList[FirstEmpty][1];
                    Console.WriteLine("Input a positive integer: ");
                    LinkedList[FirstEmpty][0] = Convert.ToInt32(Console.ReadLine());
                    LinkedList[FirstEmpty][1] = FirstNode;
                    FirstNode = FirstEmpty;
                    FirstEmpty = num; 
                }
            }
        }
        static void OutputLinkedList()
        {
            int Var = FirstNode;
            while (Var != -1)
            {
                Console.WriteLine(LinkedList[Var][0]);
                Var = LinkedList[Var][1];
            }
        }
        static void RemoveData(int DataRemove)
        {
            if (LinkedList[FirstNode][0] == DataRemove)
            {
                int NewFirst = LinkedList[FirstNode][1];
                int temp = FirstNode;
                LinkedList[FirstNode][1] = FirstEmpty;
                FirstEmpty = temp;
                FirstNode = NewFirst;
            }
            else
            {
                if (FirstNode != -1)
                {
                    int CurrentPointer = FirstNode;
                    int PreviousNode = -1;
                    while (CurrentPointer != -1 && DataRemove != LinkedList[CurrentPointer][0])
                    {
                        PreviousNode = CurrentPointer;
                        CurrentPointer = LinkedList[CurrentPointer][1];
                    }
                    if (CurrentPointer != -1 && DataRemove == LinkedList[CurrentPointer][0])
                    {
                        LinkedList[PreviousNode][1] = LinkedList[CurrentPointer][1];
                        FirstEmpty = CurrentPointer;
                        Console.WriteLine($"Removing at index {CurrentPointer}");
                    }
                }
            }
        }
    }
}
