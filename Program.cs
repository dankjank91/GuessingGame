using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Main
{
    class Program
    {
        private int X { get; set; }
        private int Y { get; set; }
        private char yesNo { get; set; }
        static void Main(string[] args)
        {
            Counter count = new Counter();
            RandomNumberGenerator random = new();
            int x = random.generator();
            bool win = false;
            bool lose = true;
            bool play = false;
            bool reset = false;


            Console.WriteLine("Welcome to the guessing game!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Do you want to play?");
            Console.WriteLine("Enter Y or N");
            char yesNo = char.Parse(Console.ReadLine());
            if (win) { lose = false; } else { lose = true; }
            if (yesNo == 'y') { play = true; Console.Clear(); }
            else if (yesNo == 'n') { play = false; Console.Clear(); }

            while (play)
            {

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("If you can guess what the random number is, you win!");
                    Console.WriteLine("You only get three chances to guess the number before you lose!");
                    Console.WriteLine("Come on now, What is your guess?");
                    Console.WriteLine();
                    Console.WriteLine("Enter a number between 1 and 10 now.");
                    int y = int.Parse(Console.ReadLine());
                    Console.WriteLine("You entered the number {0}.", y);
                    if (y == x)
                    {
                        Console.WriteLine("Match!");
                        Console.WriteLine("You win!");
                        win = true;
                        play = false;
                    }
                    else
                    {

                        Console.WriteLine("No Match, try again!");
                        count.increment();
                        if (count.i == 3) { lose = true; play = false; }
                    }
                } while (!win && !lose);

            }

        }
    }

    class RandomNumberGenerator //generates a random number.
    {
        private Random RANDOM = new ();

        private int I { get; set; }

        public int generator() { I = RANDOM.Next(1,10); return I; }
        
    }
    class Counter //keeps count of things.
    {
        public int i { get; set; }

        public void increment()
        {
          
            i = i + 1;
            Console.WriteLine("number of tries {0}/3", i);
            Console.WriteLine();
            if (i == 3)
            {
                Console.WriteLine("You lose!");
            }
           
        }
    }
}