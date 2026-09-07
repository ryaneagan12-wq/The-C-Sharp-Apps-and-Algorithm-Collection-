using System;
namespace TheHUB
{
    class GuessNumApp
    {
        static int Counter = 0;
        static int Attemps = 5;
        static int min = 0;
        static int max = 100;
        static int number = 0;
        public void Run()
        {
            Console.WriteLine("NumberGame2.0 system started!");
            Random random = new Random();
            bool play = true;
            string response;

            while (play)
            {
                number = random.Next(min, max + 1);
                Results();
            }
        }
        static int Guess()
        {
            try
            {
                Console.WriteLine($"You have {Attemps} number of attemp/s left to guess the number.");
                int Guess = Convert.ToInt32(Console.ReadLine());
                Attemps--;
                Counter++;
                return Guess;
            }
            catch (FormatException)
            {
                Console.WriteLine($"You didn't put the corect values in please try again");
                return -1;
            }
        }
        static void Compare(int Var)
        {
            if (Var > number)
            {
                Console.WriteLine("Number is too high");
            }
            else if (Var < number)
            {
                Console.WriteLine("Number is too low");
            }
        }
        static void Results()
        {
            for (int i = 0; i < 5; i++)
            {
                int Variable = Guess();
                Compare(Variable);

                if (Variable == number)
                {
                    Console.WriteLine($"Congrats! You have guessed the number in{Counter},attemps and the number was: {number}");
                    break;
                }
                else if (Attemps == 0 && Counter == 5)
                {
                    Console.WriteLine($"You failed to guess the number in 5 tries ggs bro");

                }

            }

            Console.WriteLine("Do you wish to play the game again? (yes/no)");
            string response = Console.ReadLine();

            if (response == "yes")
            {
                bool play = true;
                Attemps = 5;
                Counter = 0;
            }
            else if (response == "no")
            {
                bool play = false;
                Attemps = 0;
                Counter = 0;
                
            }

        }

    }
}
