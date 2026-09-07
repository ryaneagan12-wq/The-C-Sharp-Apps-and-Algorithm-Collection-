using System;
using System.Collections.Generic;

namespace Recursive_Arrays
{
    class Recursions
    {
        static List<int> NumberArray = new List<int> {100,85,644,22,15,8,1};
        static void Main(string[] args)
        {
            List<int> Array = RecursiveInsertion(NumberArray, NumberArray.Count);
            Console.WriteLine($"Recursive: {string.Join(", ",Array)}");
            List<int> Sorted2Array = IterativeInsertion(NumberArray, NumberArray.Count);
            Console.WriteLine($"Iterative: {string.Join(", ",Sorted2Array)}");
            int Position = BinarySearch(Sorted2Array,0,NumberArray.Count - 1,644);
            if (Position == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine(Position);
            }
        }
        static List<int> RecursiveInsertion(List<int> IntergerArray, int NumberElements)
        {
            if (NumberElements <= 1)
            {
                return IntergerArray;
            }
            List<int>Results = RecursiveInsertion(IntergerArray, NumberElements - 1);
            int LastItem = IntergerArray[NumberElements - 1];
            int CheckItem = NumberElements - 2;

            bool LoopAgain = true;
            if (CheckItem < 0)
            {
                LoopAgain = false;
            }
            else if (IntergerArray[CheckItem] <= LastItem)
            {
                LoopAgain = false;
            }

            while (LoopAgain)
            {
                IntergerArray[CheckItem + 1] = IntergerArray[CheckItem];
                CheckItem = CheckItem - 1;
                if (CheckItem < 0)
                {
                    LoopAgain = false;
                    IntergerArray[CheckItem + 1] = LastItem;
                }
                else if (IntergerArray[CheckItem] <= LastItem)
                {
                    LoopAgain = false;
                    IntergerArray[CheckItem + 1] = LastItem;
                }
            }
            return IntergerArray;
        }
        static List<int> IterativeInsertion(List<int> IntegerArray, int NumberElements)
        {
            while (NumberElements > 0)
            {
                int LastItem = IntegerArray[NumberElements - 1];
                int CheckItem = NumberElements - 2;
                bool LoopAgain = true;
                if (CheckItem < 0)
                {
                    LoopAgain = false;
                }
                else if (IntegerArray[CheckItem] <= LastItem)
                {
                    LoopAgain = false;
                }
                while (LoopAgain)
                {
                    IntegerArray[CheckItem + 1] = IntegerArray[CheckItem];
                    CheckItem = CheckItem - 1;
                    if (CheckItem < 0)
                    {
                        LoopAgain = false;
                        IntegerArray[CheckItem + 1] = LastItem;
                    }
                    else if (IntegerArray[CheckItem] <= LastItem)
                    {
                        LoopAgain = false;
                        IntegerArray[CheckItem + 1] = LastItem;
                    }
                    NumberElements = NumberElements - 1;
                }
                return IntegerArray;
            }
            return null;
        }
        static int BinarySearch(List<int> IntegerArray, int First, int Last, int ToFind)
        {
            if (First > Last)
            {
                return -1; 
            }

            int Middle = (Last + First) / 2;
            
            if (IntegerArray[Middle] == ToFind)
            {
                return Middle;
            }
            else if (IntegerArray[Middle] > ToFind)
            {
                return BinarySearch(IntegerArray, First, Middle - 1, ToFind);
            }
            else
            {
                return BinarySearch(IntegerArray, Middle + 1, Last, ToFind);
            }
        }

    }
}
