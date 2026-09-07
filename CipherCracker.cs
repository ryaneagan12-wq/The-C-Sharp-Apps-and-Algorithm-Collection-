using System;
using System.Collections.Generic;
using System.Linq;

namespace CipherCracker
{
    class cipher
    {
        private int attempts;
        private List<int> Cipher;

        public cipher()
        {
            this.attempts = 0;
            this.Cipher = new List<int>();
        }

        public void Initialize()
        {
            while (Cipher.Distinct().Count() != 4)
            {
                Cipher.Clear();
                for (int i = 0; i < 4; i++)
                {
                    Random rand = new Random();
                    int number = rand.Next(0, 10);
                    Cipher.Add(number);
                }
            }
        }
        public void DataInput()
        {
            bool Flag = false;
            List<int> Array = new List<int>();
            while (Flag != true)
            {
                try
                {
                    Console.WriteLine("Guess the 4 numbers in the cipher.(You have 4 attemps and numbers cannot be repeated)");
                    string Enter = Console.ReadLine();
                    if (Enter.Length == 4)
                    {
                        for (int x = 0; x < Enter.Length; x++)
                        {
                            Array.Add(Convert.ToInt32(Enter[x].ToString()));
                            Flag = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try to input no more or less than only 4 numbers.");
                        Console.WriteLine("Input the 4 numbers once again:");
                        int Enter2 = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input please try to input a valid data.");
                }
            }
            this.attempts++;

            int Bulls = 0;
            int Cows = 0;
            int Wrongs = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Array[i] == Cipher[i])
                {
                    Bulls++;
                }
                else if (Cipher.Contains(Array[i]))
                {
                    Cows++;
                }
                else
                {
                    Wrongs++;
                }
            }
            Results(Bulls, Cows, Wrongs, Array);
        }
        public void Results(int Bulls, int Cows, int Wrongs, List<int> Array)
        {
            if (Bulls == 4)
            {
                Console.WriteLine($"You have guessed the cipher in {this.attempts}, attemp/s!");
                return;
            }
            else if (Wrongs == 0)
            {
                Console.WriteLine($"You have {Bulls.ToString()} Bull/s that are in their correct positions, but you still have {Cows.ToString()} Cow/s that are in their wrong position but correct numbers.");
                Console.WriteLine($"But you still have {Cows.ToString()},Cow/s that are in their wrong position but correct numbers.");
            }
            else
            {
                Console.WriteLine($"You have {Bulls.ToString()},Bull/s that are in their correct positions.");
                Console.WriteLine($"But you still have {Cows.ToString()},Cow/s that are in their wrong position but correct numbers and {Wrongs.ToString()}, numbers that are completly wrong.");
            }
            return;
        }
        static void Main(string[] args)
        {
            cipher what = new cipher();
            what.Initialize();
            while (true)
            {
                what.DataInput();
                if (what.attempts >= 4)
                {
                    break;
                }
            }
        }
    }
}