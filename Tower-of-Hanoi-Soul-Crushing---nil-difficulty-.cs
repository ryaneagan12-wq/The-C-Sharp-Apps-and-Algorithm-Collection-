using System;


namespace tower_of_hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveDisks(2, "A", "B", "C");
            int[] memo = new int[10];
            Console.WriteLine(memo[5]);
        }
        static void MoveDisks(int disks, string source, string destination, string helper)
        {
            if (disks == 0)
            {
                return;
            }
            MoveDisks(disks - 1, source, helper, destination);
            Console.WriteLine($"Move disk/s {disks} from {source} to {destination}");
            MoveDisks(disks - 1, helper, destination, source);
        }
    }
}
