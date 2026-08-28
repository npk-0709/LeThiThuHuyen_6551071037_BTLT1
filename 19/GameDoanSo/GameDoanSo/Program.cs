using System;
using System.Linq;

namespace GuessingGameApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            int[] points = new int[] { 100, 90, 80, 70, 60, 50, 40 };
            int[] history = new int[10];
            int gamesPlayed = 0;
            Random rd = new Random();

            do
            {
                if (gamesPlayed == 10) { Console.WriteLine("Maximum 10 games reached."); break; }
                int target = rd.Next(1, 101);
                int score = 0;

                Console.WriteLine($"\n--- GAME {gamesPlayed + 1} ---");
                Console.WriteLine($"Target number is {target}.");
                for (int i = 0; i < 7; i++)
                {
                    try
                    {
                        Console.Write($"Attempt {i + 1} - Guess a number (1-100): ");
                        int guess = int.Parse(Console.ReadLine());
                        if (guess == target)
                        {
                            Console.WriteLine("Correct!"); score = points[i]; break;
                        }
                        Console.WriteLine(guess > target ? "Higher" : "Lower");
                    }
                    catch (FormatException) { Console.WriteLine("Must enter a number!"); i--; }
                }

                history[gamesPlayed++] = score;
                Console.WriteLine($"Score this game: {score}");

                Console.Write("Play again? (y/n): ");
            } while (Console.ReadLine().ToLower() == "y");

            var playedHistory = history.Take(gamesPlayed);
            Console.WriteLine($"\nTotal games played: {gamesPlayed}");
            Console.WriteLine($"Max Score: {playedHistory.Max()} | Min Score: {playedHistory.Min()} | Average: {playedHistory.Average():F2}");
        }
    }
}