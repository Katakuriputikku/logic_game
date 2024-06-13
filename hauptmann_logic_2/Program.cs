//Logic/MasterMind: Version 1.1
//Project made by Marek Hauptmann

using hauptmann_logic_2;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace hauptmann_logic_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating instances of classes.
            Graphic graphic = new Graphic();
            Menu menu = new Menu();
            Game game = new Game();

            //Setting text color to green.
            Console.ForegroundColor = ConsoleColor.Green;

            //Calling a welcome graphic
            graphic.WelcomeMessage();

            //Main loop of this project. It works until the whole project is closed.
            while (true)
            {
                //Calling a menu graphic.
                graphic.Menu();

                //Menu chosing system.
                string menu_choice = Console.ReadLine();

                //Code bellow works, if the input is "s".
                if (menu_choice == "s" | menu_choice == "start")
                {
                    game = menu.StartChoice(game, graphic);
                }
                //Code bellow works, if the input is "d". Shows the difficulty change options.
                else if (menu_choice == "d" | menu_choice == "difficulty")
                {
                    string difficultyCh = "";
                    bool difficulty_test = false;
                    while (difficulty_test == false)
                    {
                        graphic.ChangeDifficulty();
                        difficultyCh = Console.ReadLine();
                        difficulty_test = menu.DifficultyChoice(difficultyCh, game);
                    }
                    if (difficultyCh == "c" | difficultyCh == "custom" | difficultyCh == "cstm")
                    {
                        menu.CustomMaker(game, graphic);
                    }
                }
                //Code bellow works, if the input is "c". (Fast custom making is a secret feature)
                else if (menu_choice == "c")
                {
                    menu.CustomMaker(game, graphic);
                }
                //Code bellow works, if the input is "r". Shows rules of the game.
                else if (menu_choice == "r" | menu_choice == "rules")
                {
                    graphic.RulesGraphic();
                    string see_more = Console.ReadLine();

                    if (see_more == "yes")
                    {
                        //This code calls a webside.
                        System.Diagnostics.Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://cs.wikipedia.org/wiki/Logik_(hra)#Pravidla_hry",
                            UseShellExecute = true
                        });
                    }
                }
                //Code bellow works, if the input is "e".
                else if (menu_choice == "e" | menu_choice == "exit")
                {
                    menu.ExitChoice(graphic);
                }
                //Extremly secret feature which shows the most important picture on the internet!!! (don't show to anyone)
                else if (menu_choice == "secret")
                {
                    //This code calls a webside.
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://www.reddit.com/media?url=https%3A%2F%2Fi.redd.it%2Fb0rb7xovtgi31.jpg",
                        UseShellExecute = true
                    });
                }
                
                //Code bellow deletes the custom file, if it exists.
                else if(menu_choice == "delete custom")
                {

                    bool file_exists = File.Exists("custom.txt");
                    if (file_exists)
                    {
                        File.Delete("custom.txt");
                        Console.WriteLine("You have successfuly deleted the custom file!");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("File has not been found!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                //Code bellow shows the custom settings player has made.
                else if(menu_choice == "show custom")
                {
                    string[] split_file_text;
                    bool file_exists = File.Exists("custom.txt");
                    if (!file_exists)
                    {
                        Console.WriteLine("File has not been found!");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        string file_text = File.ReadAllText("custom.txt");
                        split_file_text = file_text.Split(", ");
                        Console.Clear();
                        Console.Write("" +
                            "Attempts: " + split_file_text[0] + ".\n" +
                            "Number of collors " + split_file_text[1] +".\n" +
                            "Game difficulty: " + split_file_text[2] +".\n");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                //If input is nonsence, this code runs.
                else
                {
                    Console.WriteLine("I do not understand?!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}