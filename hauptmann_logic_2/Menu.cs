using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hauptmann_logic_2
{
    internal class Menu
    {
        //This method works as a confirmation whether the player wants to continue to the game.
        internal Game StartChoice(Game game, Graphic graphic)
        {
            //Confirmation bool.
            bool start_the_game_bool = false;
            string start_the_game = "";
            while (start_the_game_bool == false)
            {
                //Calling a graphic method.
                graphic.StartChoice(game);
                start_the_game = Console.ReadLine();

                if (start_the_game == "y" | start_the_game == "n")
                {
                    start_the_game_bool = true;
                }
            }
            //If the player wants to continue, Start method is called.
            if (start_the_game == "y")
            {
                start_the_game_bool = true;
                game.Start();
                return new Game();
            }
            else
            {
                return game;
            }
        }
        //This method changes the game difficulty. It also checks, if the player wants to create a custom difficulty.
        internal bool DifficultyChoice(string difficultyCh, Game game)
        {
            if (difficultyCh == "e" | difficultyCh == "easy" | difficultyCh == "ez")
            {
                game.gameDifficulty = "easy";
                game.attempt = 10;
                game.numberOfCollors = 5;
                return true;
            }
            else if(difficultyCh == "n" | difficultyCh == "normal" | difficultyCh == "nrml")
            {
                game.gameDifficulty = "normal";
                game.attempt = 10;
                game.numberOfCollors = 5;
                return true;
            }
            else if(difficultyCh == "c" | difficultyCh == "custom" | difficultyCh == "cstm")
            {
                return true;
            }
            else
            {
                Console.WriteLine("I do not understand!!!");
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }

        //This method creates a custom difficulty.
        internal void CustomMaker(Game game, Graphic graphic)
        {
            bool file_exists = File.Exists("custom.txt");
            string[] split_file_text;
            bool continue_false = true;
            if (file_exists)
            {
                Console.Clear();
                Console.WriteLine("You have already made a custom difficulty.\n" +
                    "Do you want to create new? ('new')\n" +
                    "Do you want to load the old one? ('old')");
                Console.Write("-> ");
                string continue_making = Console.ReadLine();
                if(continue_making == "new")
                {
                    continue_false = false;
                }
                else if(continue_making == "old")
                {
                    string file_text = File.ReadAllText("custom.txt");
                    split_file_text = file_text.Split(", ");
                    game.attempt = Int32.Parse(split_file_text[0]);
                    game.numberOfCollors = Int32.Parse(split_file_text[1]);
                    game.gameDifficulty = split_file_text[2];
                    Console.Write(split_file_text);
                }
            }
            else
            {
                continue_false = false;
            }

            if (!continue_false)
            {
                bool numberOfAttemptsBool = true;
                int numberOfAttempts = 10;
                int numberOfCollors = 5;

                //Attempt count number making.
                while (numberOfAttemptsBool)
                {
                    graphic.CustomAttempts();
                    string numberOfAttemptsInput = Console.ReadLine();
                    bool testInputAttempts = true;

                    //Try if the input is a number.
                    try
                    {
                        numberOfAttempts = Int32.Parse(numberOfAttemptsInput);
                    }
                    catch (Exception error)
                    {
                        Console.Write("\nOnly numbers!");
                        System.Threading.Thread.Sleep(500);
                        testInputAttempts = false;
                    }

                    //Checks, if the input is a number between 0 and 20.
                    if (testInputAttempts)
                    {
                        if (!(numberOfAttempts > 20) & !(numberOfAttempts < 0))
                        {
                            game.attempt = numberOfAttempts;
                            numberOfAttemptsBool = false;
                        }
                        else
                        {
                            Console.Write("\nThis number is wrong!");
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                }

                //Code lengh making.
                bool codeLenghBool = true;
                while (codeLenghBool)
                {
                    graphic.CustomLengh();
                    string numberOfCollorsInput = Console.ReadLine();
                    bool testInputLengh = true;

                    //Try if the input is a number.
                    try
                    {
                        numberOfCollors = Int32.Parse(numberOfCollorsInput);
                    }
                    catch (Exception e)
                    {
                        Console.Write("\nOnly numbers!");
                        System.Threading.Thread.Sleep(500);
                        testInputLengh = false;
                    }

                    //Checks, if the input is a number between 0 and 10.
                    if (testInputLengh)
                    {
                        if (!(numberOfCollors > 10) & !(numberOfCollors < 0))
                        {
                            game.numberOfCollors = numberOfCollors;
                            codeLenghBool = false;
                        }
                        else
                        {
                            Console.Write("\nThis number is wrong!");
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                }

                //Difficulty system chosing.
                bool difficultyBool = true;
                while (difficultyBool)
                {
                    graphic.CustomDifficulty();
                    string difficultyInput = Console.ReadLine();

                    if (difficultyInput == "easy" ^ difficultyInput == "normal")
                    {
                        game.gameDifficulty = difficultyInput;
                        difficultyBool = false;
                    }
                    else
                    {
                        Console.Write("\nEasy or Normal! Not '" + difficultyInput + "'");
                        System.Threading.Thread.Sleep(500);
                    }
                }

                string all_text = game.attempt.ToString() + ", " + game.numberOfCollors.ToString() + ", " + game.gameDifficulty; 
                
                File.WriteAllText("custom.txt", all_text);
            }
        }

        //This method exit the whole project.
        internal void ExitChoice( Graphic graphic)
        {
            graphic.ExitGraphic();
            Environment.Exit(0);
        }
    }
}
