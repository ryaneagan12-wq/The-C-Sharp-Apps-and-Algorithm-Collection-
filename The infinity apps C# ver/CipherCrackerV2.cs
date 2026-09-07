using System;
using System.Collections.Generic;
using System.Linq;

namespace TheHUB
{

    class Cipher
    {
        public List<int> cipher;

        public Cipher()
        {
            this.cipher = new List<int>();
        }
        public void Initialization()
        {
            while (cipher.Distinct().Count() != 4)
            {
                cipher.Clear();
                for (int i = 0; i < 4; i++)
                {
                    Random rand = new Random();
                    int number = rand.Next(0, 10);
                    cipher.Add(number);
                }
            }
        }
        public bool DataInput()
        {
            int Attemps = 0;
            List<int> Array = new List<int>();
            for (int x = 0; x < 4; x++)
            {
                try
                {
                    Console.WriteLine("Guess the 4 numbers in the cipher. (You have 4 attemps and numbers cannot be repeated)");
                    string Enter = Console.ReadLine();
                    Attemps++;
                    while (Enter.Length != 4)
                    {
                        Console.WriteLine("You didn't put enough numbers.");
                        Console.WriteLine("Please Enter 4 numbers again this time.");
                        Enter = Console.ReadLine();
                    }
                    Array.Clear();
                    for (int j = 0; j < Enter.Length; j++)
                    {
                        Array.Add(Convert.ToInt32(Enter[j].ToString()));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input please try to input a valid data.");
                }
                int Bulls = 0;
                int Cows = 0;
                int Wrongs = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (Array[i] == cipher[i])
                    {
                        Bulls++;
                    }
                    else if (cipher.Contains(Array[i]))
                    {
                        Cows++;
                    }
                    else
                    {
                        Wrongs++;
                    }
                }
                if (Bulls == 4)
                {
                    Console.WriteLine($"Yay yoy have guessed the cipher in {Attemps},Attemp/s.");
                    return true;
                }
                else if (Wrongs == 0)
                {
                    Console.WriteLine($"You have {Bulls}, Bull/s that are in their correct positions.");
                    Console.WriteLine($"But you still have {Cows}, Cow/s that are in their wrong position but correct numbers.");
                }
                else
                {
                    Console.WriteLine($"You have {Bulls}, Bull/s that are in their correct positions.");
                    Console.WriteLine($"But you still have {Cows}, Cow/s that are in their wrong postions but correct numbers.");
                }
            }
            return false;
        }
    }
    class CipherCrackerApp
    {
        public void Run()
        {
            Console.WriteLine("Cipher Cracker V2 Has started!");
            Cipher Game = new Cipher();
            Game.Initialization();
            Game.DataInput();
        }
    }
}
