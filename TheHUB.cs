using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHUB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ryan's application system.");
            Console.WriteLine("Loading Files, Please Wait.");

            while (true)
            {
                Console.WriteLine("1. Tuition Management Sorter");
                Console.WriteLine("2. Library Management Sorter");
                Console.WriteLine("3. Guessing Number Game");
                Console.WriteLine("4. Cipher Cracker Game");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose a valid number from 1 - 5 to start using: ");
                string Choosing = Console.ReadLine();

                switch (Choosing)
                {
                    case "1":
                        TuitionCenterApp tuition = new TuitionCenterApp();
                        tuition.Run();
                        break;

                    case "2":
                        LibraryApp library = new LibraryApp();
                        library.Run();
                        break;

                    case "3":
                        GuessNumApp guessGame = new GuessNumApp();
                        guessGame.Run();
                        break;

                    case "4":
                        CipherCrackerApp cipher = new CipherCrackerApp();
                        cipher.Run();
                        break;

                    case "5":
                        Console.WriteLine("Exiting App...");
                        return;

                    default:
                        Console.WriteLine("Invalid,Choice Please try again.");
                        break;
                }
            }
        }
    }
}