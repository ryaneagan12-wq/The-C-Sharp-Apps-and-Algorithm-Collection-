using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FormatBubbleDataArray
{
    internal class FormatBubbleData
    {
        static void Main(string[] args)
        {
            List<string> Read = ReadData();
            Console.WriteLine(Read.Count);
            for (int i = 0; i < Read.Count; i++)
            {
                Console.WriteLine(i + ": [" + Read[i] + "]");
            }
            Console.WriteLine(FormatArray(Read));
            List<string> Variable = Bubble(Read);
            Console.WriteLine(FormatArray(Variable));
        }
        static List<string> ReadData()
        {
            List<string> String = new List<string> { };
            string Files = File.ReadAllText("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\FormatBubbleDataArray\\Data.txt");
            string[] Data = Files.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            return Data.ToList();
        }
        static string FormatArray(List<string>DataString)
        {
            string Data2 = " ";
            for (int x = 0; x < 45; x++)
            {
                Data2 = Data2 + DataString[x] + " "; 
            }
            return Data2;
        }
        static int CompareStrings(string VarX, string VarY)
        {
            int Count = 0;
            if (VarX[Count] < VarY[Count])
            {
                return 1;
            }
            else if (VarX[Count] > VarY[Count])
            {
                return 2;
            }
            else
            {
                Count++;
            }
            return 0;
        }
        static List<string> Bubble(List<string> Array)
        {
            int ArrayLength = Array.Count();

            for (int x = 0;x < ArrayLength - 1; x++)
            {
                for (int y = 0; y < ArrayLength - x - 1; y++)
                {
                    int Output = CompareStrings(Array[y], Array[y + 1]);
                    if (Output == 2)
                    {
                        string Temp = Array[y];
                        Array[y] = Array[y + 1];
                        Array[y + 1] = Temp;
                    }
                }
            }
            return Array;
        }
    }
}
