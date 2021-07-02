using System;
using System.IO;

namespace ascii
{
    class Generator
    {
        public void welcome()
        {
            Console.Title = "ASCII Art";
            string title = @"
 _                                             
| |                                            
| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| | | | (_| | | | | (_| | | | | | | (_| | | | |
|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    __/ |                      
                   |___/                      ";

            Console.WriteLine(title);
        }

        public void hangman1()
        {
            Console.Title = "ASCII Art";
            string title = @"

            +---+
            |   |
                |
                |
                |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman2()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
                |
                |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman3()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
            |   |
                |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman4()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
           /|   |
                |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman5()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
           /|\  |
                |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman6()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
           /|\  |
           /    |
                |
            =========";

            Console.WriteLine(title);
        }

        public void hangman7()
        {
            Console.Title = "ASCII Art";
            string title = @"
            +---+
            |   |
            O   |
           /|\  |
           / \  |
                |
            =========";

            Console.WriteLine(title);
        }

    }
}