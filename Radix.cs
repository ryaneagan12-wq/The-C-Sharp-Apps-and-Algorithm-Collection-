using System;
using System.Collections.Generic;

namespace Radix_Sort
{
    internal class Radix
    {
        static void Main(string[] args)
        {
            int[] numbers = { 802, 2, 24, 45, 66, 170, 75, 90 };

            int max = numbers[0];
            int Count = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            int temp = max;

            while (temp > 0)
            {
                temp = temp / 10;
                Count = Count + 1;
            }
            List<int>[] buckets = new List<int>[10];

            for (int i = 0; i < 10; i++)
            {
                buckets[i] = new List<int>() ;
            }
            int place = 1;
            for (int pass = 0; pass < Count; pass++)
            {
                for (int x = 0; x < 10; x++)
                {
                    buckets[x] = new List<int>();
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    int digit = (numbers[i] / place) % 10;
                    buckets[digit].Add(numbers[i]);
                }
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    foreach (int num in buckets[i])
                    {
                        numbers[index] = num ;
                        index += 1;
                    }
                }
                place = place * 10;
            }
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
