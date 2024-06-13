using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hauptmann_logic_2
{
    internal class Graphic
    {

        //------------------ Menu graphics ------------------//

        internal void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("" +
                "-----------------------\n" +
                "   Logic/Mastermind\n" +
                "      Start – „s“\n" +
                "    Difficulty – „d“\n" +
                "      Rules – „r“\n" +
                "       End – „e“\n" +
                "-----------------------\n" +
                "-> ");
        }
        
        internal void StartChoice(Game game)
        {
            Console.Clear();
            if (game.attempt != 10 | game.numberOfCollors != 5)
            {
                Console.WriteLine("Chosen difficulty is 'Custom'. Are you sure you want to continue?\r\n" +
                "Yes - „y“\r\n" +
                "No - „n“\r\n");
            }
            else
            {
                Console.WriteLine("Chosen difficulty is '" + game.gameDifficulty + "'. Are you sure you want to continue?\r\n" +
                "Yes - „y“\r\n" +
                "No - „n“\r\n");
            }
            Console.Write("-> ");
        }

        internal void ChangeDifficulty()
        {
            Console.Clear();
            Console.Write("-----------------------\r\n" +
                "   Sellect difficulty\r\n " +
                "      easy - „e“\r\n" +
                "      normal - „n“\r\n" +
                "      custom - „c“\r\n" +
                "-----------------------\r\n");
            Console.Write("-> ");
        }

        //------------------ Game graphics ------------------//

        internal void Game(int attempt, int numberOfCollors, string gameDif)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("---Logic/Mastermind---");
            if (attempt != 10 | numberOfCollors != 5)
            {
                Console.WriteLine(" Difficulty: Custom");
            }
            else
            {
                Console.WriteLine(" Difficulty: " + gameDif);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Colors: white, gray, magenta, green, red, yellow, black, blue");
            Console.WriteLine("Input is like: white, gray, magenta... ");
        }

        internal void GameWin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Congratulations! You have won the game!!!\n" +
                "I hope you enjoyed it. You can play again anytime!\n" +
                "Press enter...");
        }

        internal void GameLose()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("I'm so sorry, you have lost the game. But do not worry, you can do better next time!\n" +
                "I believe in you!!\n" +
                "The code was: ");
        }

        //------------------ Game maker ------------------//

        internal void CustomAttempts()
        {
            Console.Clear();
            Console.Write("" +
                "Welcome to Custom Maker!\n\n" +
                "Chose the number of Attempts (max 20)\n");
            Console.Write("-> ");
        }

        internal void CustomLengh()
        {
            Console.Clear();
            Console.Write("" +
                "Welcome to Custom Maker!\n\n" +
                "Chose the lengh of the color code (max 10):\n");
            Console.Write("-> ");
        }

        internal void CustomDifficulty()
        {
            Console.Clear();
            Console.Write("" +
                "Welcome to Custom Maker!\n\n" +
                "Now chose, if you want to have easy or normal difficulty system!\n" +
                "„easy“ or „normal“:\n");
            Console.Write("-> ");
        }

        //A method in Graphic class, which shows introductory sentences
        internal void WelcomeMessage()
        {
            string welcome_message_1 = "Welcome...";
            for (int i = 0; i < welcome_message_1.Length; i++)
            {
                Console.Write(welcome_message_1[i]);
                System.Threading.Thread.Sleep(150); // Sleep for 150 milliseconds
            }
            System.Threading.Thread.Sleep(500);
            string welcome_message_2 = "This project is made by Marek Hauptmann.";
            Console.Clear();
            for (int i = 0; i < welcome_message_2.Length; i++)
            {
                Console.Write(welcome_message_2[i]);
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }

        internal void RulesGraphic()
        {
            Console.Clear();
            Console.Write("There is a combination of multiple colors. You are trying to find out what the combination is.\n" +
                "Hints work differently in each difficulty system:\n" +
                "Easy: If your color on a specific spot is right, the green color is shown in the hint table. If the color is present in the color code, but not on the specific spot, white color is shown.\n\n" +
                "Example:\n" +
                "Code combination is: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nAnd your try is:     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nHint, which is going to appear is: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("o  o");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("o\n\n");
            Console.Write("Normal: The player doesn't know which color is on the right place or which is somewhere in the code. If there is some color in the correct spot, it shows green color on the beginning of the hint line. Same works for colors which are in the color code.\n\n" +
                "Example:\n" +
                "Code combination is: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nAnd your try is:     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nHint, which is going to appear is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("oo\n\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("If you want to see more, write 'yes'.");
            Console.Write("-> ");
        }

        internal void ExitGraphic()
        {
            Console.Clear();
            Console.Write("Thanks for playing!\r\n");
            Console.ReadLine();
        }
    }
}
