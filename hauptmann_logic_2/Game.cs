using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hauptmann_logic_2
{
    public class Game
    {
        //Class atributes.
        internal string gameDifficulty = "normal";
        internal List<string> color = ["white", "gray", "magenta", "green", "red", "yellow", "black", "blue"];
        internal int attempt = 10;
        internal int numberOfCollors = 5;

        //Game dictionaries.
        Dictionary<string, List<string>> playerAttempts = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> playerHints = new Dictionary<string, List<string>>();
        List<string> gameCombination = new List<string>();
        Graphic gameGraphic = new Graphic();

        internal void Start()
        {
            //Create a game combination.
            GameCombination();

            bool gameOn = true;
            //Main game loop.
            while (gameOn)
            {
                gameGraphic.Game(attempt, numberOfCollors, gameDifficulty);
                int gameAttemptsAll = attempt;
                //This code works as graphic of already tried attempts and hints.
                while (gameAttemptsAll > 0)
                {
                    //Difference is equal to All attempts number - already used attempts. 
                    int difference = gameAttemptsAll - (playerAttempts.Count + 1);
                    if (difference >= 0)
                    {
                        if (gameAttemptsAll < 10)
                        {
                            Console.Write(" "+gameAttemptsAll + ". ");
                        }
                        else
                        {
                            Console.Write(gameAttemptsAll + ". ");
                        }

                        for (int o = 0; o < numberOfCollors; o++)
                        {
                            Console.Write("o");
                        }
                        Console.Write("   ");
                        for (int j = 0; j < numberOfCollors; j++)
                        {
                            Console.Write("█");
                        }
                        Console.Write("\n");
                    }
                    //This code shows already used attempts.
                    else
                    {
                        if(gameAttemptsAll < 10)
                        {
                            Console.Write(" "+gameAttemptsAll + ". ");
                        }
                        else
                        {
                            Console.Write(gameAttemptsAll + ". ");
                        }
                        HintGraphics(gameAttemptsAll);
                        Console.Write("   ");
                        AttemptGraphic(gameAttemptsAll);
                        Console.WriteLine("");

                    }

                    gameAttemptsAll--;
                }
                string[] playerAttempt = [];
                /*
                foreach(string str in gameCombination)
                {
                    Console.Write(str + " ");
                }
                */
                //Main input of the game.
                Console.Write("-> ");
                string gameInput = Console.ReadLine();
                //Code bellow breaks the game if the input is "menu"
                if (gameInput == "menu")
                {
                    gameOn = false;
                    break;
                }

                //This code splits the whole input into separated strings.
                playerAttempt = gameInput.Split(", ");

                bool test = CheckTheInput(playerAttempt, gameInput);

                //If the input is checked, this code runs
                if (test == true)
                {
                    List<string> playerAttemptList = new List<string>(playerAttempt);
                    playerAttempts.Add(playerAttempts.Count.ToString(), playerAttemptList);
                    bool checkDifference = CheckDifferences((playerAttempts.Count - 1).ToString());
                    //If all hints are green, game is finished and the player win.
                    if (checkDifference == true)
                    {
                        gameGraphic.GameWin();
                        Console.ReadLine();
                        gameOn = false;
                        break;
                    }
                    //If there is no more attempts, the player lose.
                    else if (playerAttempts.Count == attempt)
                    {
                        gameGraphic.GameLose();
                        foreach (string str in gameCombination)
                        {
                            Console.Write(str + ", ");
                        }
                        Console.Write("\nPress enter...");
                        Console.ReadLine();
                        gameOn = false;
                        break;
                    }
                }
            }
        }
        //Creates a game combination.
        private void GameCombination()
        {
            Random rand = new Random();  //To work with random options.
            for (int i = 0; i < numberOfCollors; i++)
            {
                int randomValue = rand.Next(0, color.Count);
                gameCombination.Add(color[randomValue]);
            }

        }
        //Creates a hint graphic
        private void HintGraphics(int gameAttemptsAll)
        {
            List<string> values = playerHints[(gameAttemptsAll - 1).ToString()];
            if(gameDifficulty == "easy")
            {
                foreach (string value in values)
                {
                    if (value == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (value == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (value == " ")
                    {
                        Console.Write(" ");
                    }
                }
            }
            else
            {
                foreach (string value in values)
                {
                    if (value == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                foreach (string value in values)
                {
                    if (value == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                foreach (string value in values)
                {
                    if (value == " ")
                    {
                        Console.Write(" ");
                    }
                }
            }
        }
        //Creates a attempts graphic.
        private void AttemptGraphic(int gameAttemptsAll)
        {
            List<string> values = playerAttempts[(gameAttemptsAll - 1).ToString()];
            foreach (string value in values)
            {
                if (value == "white")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "gray")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "green")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "black")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (value == "blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (value == "magenta")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        //Code bellow checks differences between gameCombination and players attempts.
        private bool CheckDifferences(string gameAttempt)
        {
            /* ----------------  Version 1.0  ----------------
             
            List<string> values = playerAttempts[gameAttempt];
            List<string> differences = new List<string>();
            for(int i = 0; i < values.Count; i++)
            {
                if (gameCombination.Contains(values[i]))
                {

                    if (gameCombination[i] == values[i])
                    {
                        differences.Add("black");
                    }
                    else
                    {
                        differences.Add("white");
                    }
                }
                else
                {
                    differences.Add(" ");
                }
            }
            */
            ///*
            List<string> values = playerAttempts[gameAttempt];
            List<string> differences = new List<string>();
            List<string> valueSupport = new List<string>(values);
            List<string> gameSupportString = new List<string>(gameCombination);

            //Loop for every color of the input
            for (int i = 0; i < values.Count; i++)
            {
                //If the color at the current position is same as the gameCombination color at the same position.
                if (valueSupport[i] == gameCombination[i])
                {
                    //Difference is added and both lists at the position lose their value.
                    differences.Add("black");
                    gameSupportString[i] = null;
                    valueSupport[i] = null;
                }
                else
                {
                    //Empty difference is added, because we are going to work with these empty places.
                    differences.Add("");
                }
            }

            //Loop for every color of the input
            for (int i = 0; i < values.Count; i++)
            {
                //This finds not already blacked positions.
                if (valueSupport[i] != null)
                {
                    //This tries to find, if the index is in the code.
                    int index = gameSupportString.IndexOf(valueSupport[i]);
                    //If the color is in the code.
                    if (index != -1)
                    {
                        //Adds white and deletes the color from the code string
                        differences[i] = "white";
                        gameSupportString[index] = null;
                    }
                    else
                    {
                        //If its not in the code, there is empty difference
                        differences[i] = " ";
                    }
                }
            }
            //*/
            //Checks the posibility of your victory.
            bool test = true;
            foreach (string difference in differences)
            {
                if (difference != "black")
                {
                    test = false;
                }
            }
            playerHints.Add(gameAttempt, differences);
            
            return test;
        }

        //This bool method returns, if the input was correct.
        private bool CheckTheInput(string[] playerAttempt, string gameInput)
        {
            if (playerAttempt.Length == numberOfCollors)
            {
                bool test = true;
                foreach(string x in playerAttempt)
                {
                    if (!color.Contains(x))
                    {
                        test = false;
                    }
                }
                if (test == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            else
            {
                return false;
            }
        }
    }
}