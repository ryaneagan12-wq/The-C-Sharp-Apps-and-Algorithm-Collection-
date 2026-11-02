using System;
using System.IO;

namespace bloom_filter
{
    class Bloomfilter
    {
        bool[] Dict;

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\ryan\\Downloads\\bad.txt");
            foreach (string line in lines)
            {
                Bloomfilter filter = new Bloomfilter(100);
                filter.Add("evil.com");
                filter.Add("bad.net");
                filter.Add("virus.org");
                filter.Add("scam.io");
                Console.WriteLine(filter.Contains("evil.com"));
                Console.WriteLine(filter.Contains("bad.net"));
                Console.WriteLine(filter.Contains("virus.org"));
                Console.WriteLine(filter.Contains("scam.io"));
                Console.WriteLine(filter.Contains("Google.com"));
            }
        } 
        public Bloomfilter(int size)
        {
            Dict = new bool[size];
        }
        public void Add(string item)
        {
            int spot = Math.Abs(item.GetHashCode())% Dict.Length;
            Dict[spot] = true;
        }
        public bool Contains(string item)
        {
            int spot = Math.Abs((int)item.GetHashCode()) % Dict.Length;
            return Dict[spot];
        }

    }
}