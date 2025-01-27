using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextAdventureGame
{
    public class Game
    {
        private Map map;
        private Player player;
        private bool isRunning;

        public void Start()
        {
            isRunning = true;
            map = new Map();
            player = new Player();

            while (isRunning)
            {
                ShowMenu();
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Space Exploration Adventure!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        private void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Starting a new game...");
            player.Reset();
            map = new Map();
            map.DisplayMap();

            while (!player.HasWon && isRunning)
            {
                map.Navigate(player);
            }

            if (player.HasWon)
            {
                Console.WriteLine("Congratulations! You completed the game!");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("Space Exploration Adventure");
            Console.WriteLine("Developed by YourName");
            Console.WriteLine("Special thanks to DGD203 Class");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
