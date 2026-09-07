using System;
using System.Collections.Generic;

namespace InsertionBinarySort
{
    class InsertBinar
    {
        static List<int>DataArray = new List<int> {0,3,4,56,67,44,43,32,31,345,45,6,54,1};
        static void Main(string[] args)
        {
            OutputArray(DataArray);
            DataArray = InsertionSort(DataArray);
            OutputArray(DataArray);

            int Location = Search(DataArray,0);
            if (Location == -1)
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                Console.WriteLine($"Data found at,{Location}");
            }
            Location = Search(DataArray,345);
            if (Location == -1)
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                Console.WriteLine($"Data found at,{Location}");
            }
            Location = Search(DataArray,67);
            if (Location == -1)
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                Console.WriteLine($"Data found at,{Location}");
            }
            Location = Search(DataArray,2);
            if (Location == -1)
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                Console.WriteLine($"Data found at,{Location}");
            }
        }
        static List<int> InsertionSort(List<int> DataArray)
        {
            if (DataArray.Count() <= 1)
            {
                return DataArray;
            }
            for (int i = 1; i < DataArray.Count(); i++) 
            {
                int CurrentValue = DataArray[i];
                int y = i - 1;

                while (y >= 0 && CurrentValue < DataArray[y])
                {
                    DataArray[y + 1] = DataArray[y];
                    y = y - 1;
                    DataArray[y + 1] = CurrentValue;
                }
            }
            return DataArray;
        }
        static void OutputArray(List<int>DataArray)
        {
            string Output = "";
            foreach (int Item in DataArray) 
            {
                Output = Output + Item.ToString() + " ";
            }
            Console.WriteLine(Output);
        }
        static int Search(List<int>DataArray, int ItemToFind)
        {
            int Low = 0;
            int High = DataArray.Count() - 1;
            int Middle = 0;
            while (Low <= High)
            {
                Middle = (High + Low)/ 2;
                if (DataArray[Middle] < ItemToFind)
                {
                    Low = Middle + 1;
                }
                else if (DataArray[Middle] > ItemToFind)
                {
                    High = Middle - 1;
                }
                else
                {
                    return Middle;
                }
            }
            return -1;
        }
    }
}