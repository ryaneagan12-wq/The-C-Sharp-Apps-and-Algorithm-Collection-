using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool play = true; 
            int num_1 = 0;
            int num_2 = 0;
            string equation;
            string response;

            while (play)
            {
                try
                {

                    Console.WriteLine("Enter the first number: ");
                    num_1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the second first: ");
                    num_2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Do you wish to add, subtract, divide or multiply the numbers?");
                    equation = Console.ReadLine();

                    if (equation == "Add" || equation == "add")
                    {
                        int total = num_1 + num_2;
                        Console.WriteLine($"The number is: {total}");
                    }
                    else if (equation == "Subtract" || equation == "subtract")
                    {
                        int total = num_1 - num_2;
                        Console.WriteLine($"The number is: {total}");
                    }
                    else if (equation == "Multiply" || equation == "multiply")
                    {
                        int total = num_1 * num_2;
                        Console.WriteLine($"The number is: {total}");

                    }
                    else if (equation == "Divide" || equation == "divide")
                    {
                        decimal total = (decimal) num_1 / (decimal) num_2;
                        Math.Round(total, 3);
                        Console.WriteLine($"The number is: {total}");

                    }
                }
                catch (Exception)
                {
                    if (num_2 == 0)
                    {
                        Console.WriteLine("Number cannot be divide by 0, please try entering another number.");
                    }
                }
                Console.WriteLine("Do you wish to play the game again? (yes/no)");
                response = Console.ReadLine();

                if (response == "yes")
                {
                    play = true;
                }
                else
                {
                    play = false;
                }

            }

        }
    }
}