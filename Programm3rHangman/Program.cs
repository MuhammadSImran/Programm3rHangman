using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Programm3rHangman
{
    class Program
    {
        //Created by TheProgramm3r
        int a = 0;//Counter Variable
        int letterscorrect = 0; //Amount of Letters that are guessed correct.
        char[] correctguessed = new char[26]; //correct guessed letters.
        char[] wrongguessed = new char[26]; //wrong guessed letters.
        char[] previousguesses = new char[26];//previous guessed letters.

        //Game Categories
        string[] colours = { "black", "brown", "blue", "white", "green", "red", "pink", "purple" };
        string[] names = { "tim", "bill", "george", "joe", "harry", "sally", "ahmed" };
        string[] movies = { "avengers", "batman", "joker", "kung fu panda", "frozen" };
        string[] superheros = { "spiderman", "batman", "ironman", "superman", "the flash" };

        string s = "abcdefghijklmnopqrstuvwxyz "; //entire alphabet and a space.
        string category = ""; //category choice.
        string mysteryword = ""; //mystery randomly genrated word.
        bool correctguess = false; //boolean if the guess is correct.
        char[] guess = new char[26]; //array for the characters of the guesses
        int counter = 11;

        static void Main(string[] args)
        {
            Program Hangman = new Program();//creates a program
            Console.Title = ("Hangman V1"); //names the program
            //All methods for program.
            Hangman.StartHangman();
            Hangman.GuessHangmanWord();
            Hangman.RestartHangman();
            Console.ReadLine();
        }

        //Beginning of Hangman
        void StartHangman()
        {


            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("                                              Welcome to ImranGames Hangman!");
            Console.WriteLine("                                                            _______ ");
            Console.WriteLine("                                                           |/      | ");
            Console.WriteLine("                                                           |      (_)");
            Console.WriteLine("                                                           |      /l\\ ");
            Console.WriteLine("                                                           |       l ");
            Console.WriteLine("                                                           |      /l\\  ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                         __|___      ");
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("                                                        Instructions ");
            Console.WriteLine("                                Enter the name of the category or number of the category.");
            Console.WriteLine("                               Wait for the program to generate and randomly choose a word.");
            Console.WriteLine("                         Once you are brought to the hangman screen with a '___' word, guess a letter.");
            Console.WriteLine("                        Everytime you guess a letter wrong, it will take away the amount of guess you get.");
            Console.WriteLine("                  You get 11 guesses in total. You can also enter a space by pressing the spacebar and pressing enter.");
            Console.WriteLine("                Once the game is over, it will bring you to a win or lose screen and restart the game after 10 seconds.");
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                            What category would you like to choose? Pick one below!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                      1. Colours                       ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                      2.  Names                        ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                      3.  Movies                       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                      4.  Superheros                     ");
            Console.ForegroundColor = ConsoleColor.White;
        choice:
            category = Convert.ToString(Console.ReadLine().ToLowerInvariant());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Beep(1000, 100);
            if (category == "colours" || category == "colors" || category == "1")
            {
                Console.WriteLine("                                      The category you chose is Colours!         ");
                Console.WriteLine("                                      Randomizing words and generating word...   ");
                Random generator = new Random();
                int index = generator.Next(0, 8);//length of array
                mysteryword = colours[index];
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            }
            if (category == "names" || category == "name" || category == "2")
            {
                Console.WriteLine("                                      The category you chose is Names!           ");
                Console.WriteLine("                                      Randomizing words and generating word...   ");
                Random generator = new Random();
                int index = generator.Next(0, 7);//length of array
                mysteryword = names[index];
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            }
            if (category == "movies" || category == "movie" || category == "3")
            {
                Console.WriteLine("                                      The category you chose is Movies!          ");
                Console.WriteLine("                                      Randomizing words and generating word...   ");
                Random generator = new Random();
                int index = generator.Next(0, 5);//length of array
                mysteryword = (movies[index]);
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            }
            if (category == "superheros" || category == "superhero" || category == "4")
            {
                Console.WriteLine("                                     The category you chose is Superheros!       ");
                Console.WriteLine("                                      Randomizing words and generating word...   ");
                Random generator = new Random();
                int index = generator.Next(0, 5);//length of array
                mysteryword = (superheros[index]);
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
            }
            else if (category != "colours" && category != "colour" && category != "movies" && category != "movie" && category != "names" && category != "name" && category != "superhero" && category != "superheros" && category != "1" && category != "2" && category != "3" && category != "4")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(category + " is a invalid choice, please pick a valid category!");
                Console.ForegroundColor = ConsoleColor.White;
                goto choice;

            }
        }


        //method to guess the word.
        void GuessHangmanWord()
        {

            for (int i = 0; i < mysteryword.Length; i++)
            {
                guess[i] = '_';
            }
            Console.WriteLine("                                                           Hangman");
            Console.WriteLine("                                                            _______ ");
            Console.WriteLine("                                                           |/        ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                           |         ");
            Console.WriteLine("                                                         __|___      ");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - guess.Length + 25) / 2, Console.CursorTop); //sets the guess letters to the middle of the screen.
            Console.WriteLine(guess);
            while (!correctguess && counter > 0)
            {
                Console.WriteLine();
                Console.WriteLine("                  Guess a letter/Guess a space by pressing spacebar and enter!     ");
            charr:
                char playerGuess = 'a';
                try
                {
                    playerGuess = char.Parse(Console.ReadLine().ToLowerInvariant());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The inputed value must be 1 character! Try again");
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto charr;
                }
                if (s.Contains(playerGuess))
                {
                    if (correctguessed.Contains(playerGuess))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                       You have already entered " + playerGuess + ", it was correct! Try another letter.", playerGuess);
                        Console.ForegroundColor = ConsoleColor.Green;
                        continue;
                    }
                    else if (wrongguessed.Contains(playerGuess))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                       You have already entered " + playerGuess + ", it was wrong! Try another letter.", playerGuess);
                        Console.ForegroundColor = ConsoleColor.Green;
                        continue;
                    }
                    a++;
                    if (mysteryword.Contains(playerGuess))
                    {
                        correctguessed[a] = playerGuess;
                        previousguesses[a] = playerGuess;
                        for (int i = 0; i < mysteryword.Length; i++)
                        {
                            if (mysteryword[i] == playerGuess)
                            {
                                guess[i] = playerGuess;
                                letterscorrect++;
                            }
                        }
                        if (letterscorrect == mysteryword.Length)
                        {
                            correctguess = true;
                        }
                    }
                    else
                    {
                        previousguesses[a] = playerGuess;
                        Console.ForegroundColor = ConsoleColor.Red;
                        wrongguessed[a] = playerGuess;
                        Console.WriteLine("                                            Nope there is no " + playerGuess + "'s in the word.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        counter--;
                    }
                    Console.WriteLine("                                                  You have " + counter + " guesses left!");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    if (counter == 11)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/        ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 10)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 9)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (  ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 8)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_ ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 7)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 6)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |       l ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 5)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 4)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l\\ ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 3)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l\\ ");
                        Console.WriteLine("                                                           |       l ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 2)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l\\ ");
                        Console.WriteLine("                                                           |       l ");
                        Console.WriteLine("                                                           |       l  ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 1)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l\\ ");
                        Console.WriteLine("                                                           |       l ");
                        Console.WriteLine("                                                           |      /l  ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                    }
                    if (counter == 0)
                    {
                        Console.WriteLine("                                                            Hangman");
                        Console.WriteLine("                                                            _______ ");
                        Console.WriteLine("                                                           |/      | ");
                        Console.WriteLine("                                                           |      (_)");
                        Console.WriteLine("                                                           |      /l\\ ");
                        Console.WriteLine("                                                           |       l ");
                        Console.WriteLine("                                                           |      /l\\  ");
                        Console.WriteLine("                                                           |         ");
                        Console.WriteLine("                                                         __|___      ");
                        Console.WriteLine("Previous Guesses:");
                        Console.WriteLine(previousguesses);
                        Console.WriteLine("Created by Muhammad and Ahmed");
                        Console.WriteLine("                                                         GAME OVER!      ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.SetCursorPosition((Console.WindowWidth - guess.Length + 25) / 2, Console.CursorTop);
                    Console.WriteLine(guess);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerGuess + " is not a valid input, please input a alphabetic letter.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto charr;
                }
            }
            if (correctguess == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("            _    _                                                                          ");
                Console.WriteLine("           | |  | |                                                                         ");
                Console.WriteLine("           | |__| | __ _ _ __   __ _ _ __ ___   __ _ _ __                                   ");
                Console.WriteLine("           |  __  |/ _` | '_ \\ / _` | '_ ` _ \\ / _` | '_ \\                                  ");
                Console.WriteLine("           | |  | | (_| | | | | (_| | | | | | | (_| | | | |                                 ");
                Console.WriteLine("           |_|  |_|\\__,_|_| |_|\\__, |_| |_| |_|\\__,_|_| |_|                                 ");
                Console.WriteLine("    __      ___      _         __/ |       _____                   _                        ");
                Console.WriteLine("     \\ \\    / (_)    | |       |___/       |  __ \\                 | |                      ");
                Console.WriteLine("      \\ \\  / / _  ___| |_ ___  _ __ _   _  | |__) |___  _   _  __ _| | ___                  ");
                Console.WriteLine("       \\ \\/ / | |/ __| __/ _ \\| '__| | | | |  _  // _ \\| | | |/ _` | |/ _ \\                 ");
                Console.WriteLine("        \\  /  | | (__| || (_) | |  | |_| | | | \\ \\ (_) | |_| | (_| | |  __/                 ");
                Console.WriteLine("         \\/   |_|\\___|\\__\\___/|_|   \\__, | |_|  \\_\\___/ \\__, |\\__,_|_|\\___|                 ");
                Console.WriteLine("                                     __/ |               __/ |                              ");
                Console.WriteLine("                                    |___/               |___/                               ");

                Console.WriteLine("Created by TheProgramm3r");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("                                You lost! The word was " + mysteryword + " maybe next time...");
                Console.WriteLine("Created by TheProgramm3r");
            }
        }

        void RestartHangman()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("                                           Game will reset in 10 seconds!");
            System.Threading.Thread.Sleep(10000);
            StartHangman();
        }
    }
}

