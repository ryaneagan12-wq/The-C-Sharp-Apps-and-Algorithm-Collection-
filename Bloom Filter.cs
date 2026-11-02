using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConsoleApp1
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool play = true;
            int attemps = 0;
            int min = 0;
            int max = 100;
            int number = 0;
            int guess = 0;

            while (play)
            {
                guess = 0;
                attemps = 0;
                number = random.Next(min, max + 1);

                while (guess != number)
                {
                    Console.WriteLine("Guess a number between 0-100");
                    guess = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Guess:" + guess);


                    if (guess > number)
                    {
                        Console.WriteLine("Number is too high");
                        
                    }
                    if (guess < number)
                    {
                        Console.WriteLine("Number is too low");
                        
                    }
                    attemps++;

                }
                Console.WriteLine("You Guessed the Number! It was: " + number);
                Console.WriteLine("Number Of Attemps: " + attemps);

            }
        }

    }
}
