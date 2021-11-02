using System;

namespace Ernest.Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var keepPlaying = true;
            CrabsSection game = new CrabsSection();
            Console.WriteLine("######### WELCOME TO CRAB SECTION GAME #########");

            while (keepPlaying)
            {
                Console.WriteLine("Press any key to roll dice");
                Console.ReadLine();
                var (endGame, message, value) = game.Play();
                Console.WriteLine($"You played {value}");
                Console.WriteLine(message);
                keepPlaying = !endGame;
            }

            Console.WriteLine("Game Ended!");
            Console.ReadLine();
        }
    }
}
