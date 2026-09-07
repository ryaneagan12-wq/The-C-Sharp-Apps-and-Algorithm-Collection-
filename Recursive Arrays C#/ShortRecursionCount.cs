using System;
using System.Collections.Generic;

namespace ShortRecursionCount
{
    class Reacursihion
    {
        static List<int> Numbers = new List<int> {0,5,1,2,5,9,9,6,5,0};
        static void Main(string[] args)
        {
            int AhhRayy = ReacursihveCount(0,Numbers,10);
            Console.WriteLine(AhhRayy);
            string code = "x=0;y=1;x=x+y;y++;";
            List<string>SplitDataArray = SplitData(code);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(SplitDataArray[i]);
            }
        }
        static int ReacursihveCount(int DataToFind, List<int> ArrayCopy, int NumberElements)
        {
            if (NumberElements > 0)
            {
                List<int> Newarray = ArrayCopy.GetRange(1,NumberElements - 1);

                if (ArrayCopy[0] == DataToFind)
                {
                    return 1 + ReacursihveCount(DataToFind,Newarray, NumberElements - 1);
                }
                else
                {
                    return ReacursihveCount(DataToFind,Newarray, NumberElements - 1);
                }

            }
            else
            {
                return 0;
            } 
        }
        static List<string> SplitData(string Datastr)
        {
            List<string>SplitArray = new List<string> { };
            int Count = 0;

            for (int i = 0; i < 4; i++)
            {   
                string TempString = "";
                try
                {
                    char Character = Datastr[Count];
                    while (Character != ';')
                    {
                        TempString = TempString + (Character);
                        Count++;
                        Character = Datastr[Count];
                    }
                    SplitArray.Add(TempString);
                }
                catch (Exception)
                {
                    Console.WriteLine("No more characters");
                }
                Count++;
            }
            return SplitArray; 
        }
    }
}