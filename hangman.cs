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

            int lifePoints = 5;
            var controler = true;
            var ifInWord = true;
            string notInWord = "";
            char[] guess = new char[capital.Length];

            for (int p = 0; p < capital.Length; p++)
                guess[p] = '_';

            while (controler)
            {
                Console.WriteLine("You have {0} life points left!", lifePoints);
                Console.WriteLine("Not in word: {0}", notInWord);
                if (lifePoints == 1)
                {
                    Console.WriteLine("Hint: The capital of {0}.", country);
                }
                Console.WriteLine("To guess one letter type in - One, to guess whole word type in - Word");
                string guessType = Console.ReadLine();
                if (guessType == "One")
                {
                    Console.WriteLine("Type in your guess:");
                    char playerGuess = char.Parse(Console.ReadLine());
                    for (int j = 0; j < capital.Length; j++)
                    {
                        if (playerGuess == capital[j])
                        {
                            guess[j] = playerGuess;
                        }
                        else if (playerGuess != capital[j])
                        {
                            ifInWord = false;
                        }
                    }
                    if (ifInWord == false)
                    {
                        lifePoints = lifePoints - 1;
                        notInWord = notInWord + playerGuess + " ";
                    }
                    Console.WriteLine(guess);
                }
                else if (guessType == "Word")
                {
                    Console.WriteLine("Type in your guess:");
                    string playerWordGuess = Console.ReadLine();
                    if (playerWordGuess == capital)
                    {
                        Console.WriteLine("You won!");
                        controler = false;
                    }
                    else if (playerWordGuess != capital)
                    {
                        lifePoints = lifePoints - 2;
                    }
                }

                string finalGuess = new string(guess);

                if (finalGuess == capital)
                {
                    Console.WriteLine("You won!");
                    controler = false;
                }
                else if (lifePoints == 0)
                {
                    Console.WriteLine("You lost! The correct word was {0}", capital);
                    controler = false;
                }
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
