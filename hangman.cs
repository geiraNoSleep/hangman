using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ascii;

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

            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

            Generator ASCII = new Generator();
            ASCII.welcome();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int hangmanCount = 1;
            int lifePoints = 6;
            var controler = true;
            var isNotInWord = false;
            var guessControler = false;
            var isInWord = false;
            var guessCount = 0;
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
                    isInWord = false;
                    isNotInWord = false;
                    Console.WriteLine("Type in your guess:");
                    char playerGuess = char.Parse(Console.ReadLine());
                    for (int j = 0; j < capital.Length; j++)
                    {
                        if (playerGuess == capital[j])
                        {
                            guess[j] = playerGuess;
                            guessControler = true;
                            isInWord = true;
                        }
                        else if (playerGuess != capital[j])
                        {
                            isNotInWord = true;
                            guessControler = true;
                        }
                    }
                    if (isNotInWord == true && isInWord == false)
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
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00} minutes {1:00} seconds and {2:00} milliseconds", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        guessCount = guessCount + 1;
                        Console.WriteLine("You won!");
                        Console.WriteLine("You guessed capital after {0} guesses and it took you {1}.", guessCount, elapsedTime);
                        Console.WriteLine("What's your name?");
                        string name = Console.ReadLine();
                        string data = name + " | " + date + " | " + elapsedTime + " | " + guessCount + " | " + capital;
                        using StreamWriter file = new("highscores.txt", append: true);
                        file.WriteLineAsync(data);
                        controler = false;
                    }
                    else if (playerWordGuess != capital)
                    {
                        lifePoints = lifePoints - 2;
                        guessControler = true;
                    }
                }

                if (guessControler == true)
                {
                    guessCount = guessCount + 1;
                }

                string finalGuess = new string(guess);

                if (finalGuess == capital)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00} minutes {1:00} seconds and {2:00} milliseconds", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("You won!");
                    Console.WriteLine("You guessed capital after {0} guesses and it took you {1}.", guessCount, elapsedTime);
                    Console.WriteLine("What's your name?");
                    string name = Console.ReadLine();
                    string data = name + " | " + date + " | " + elapsedTime + " | " + guessCount + " | " + capital;
                    using StreamWriter file = new("highscores.txt", append: true);
                    file.WriteLineAsync(data);
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
