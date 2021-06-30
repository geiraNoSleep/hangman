using System;
using System.IO;

namespace hangman
{
    class Program
    {
        static void Run()
        {
            var fileLocation = "../hangman/countries_and_capitals.txt";

            string[] allLines = File.ReadAllLines(fileLocation);
            Random rnd1 = new Random();

            var chosenLine = allLines[rnd1.Next(allLines.Length)];
            Console.WriteLine(chosenLine);

            char[] delimiterChars = { '|' };

            string[] words = chosenLine.Split(delimiterChars);

            string country = words[0].Trim();
            string capital = words[1].Trim();

            Console.WriteLine(country);
            Console.WriteLine(capital);

            char[] guess = new char[capital.Length];
            Console.Write("Please enter your guess: ");

            for (int p = 0; p < capital.Length; p++)
                guess[p] = '_';

            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < capital.Length; j++)
                {
                    if (playerGuess == capital[j])
                        guess[j] = playerGuess;
                }
                Console.WriteLine(guess);
            }
        }

        static void Main()
        {
            Run();

            Console.WriteLine("To try again enter - A, to exit enter - E");
            string decision = Console.ReadLine();

            if (decision == "e" || decision == "E")
            {
                Environment.Exit(0);
            }
            else if (decision == "A" || decision == "a")
            {
                Main();
            }
        }
    }
}
