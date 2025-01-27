using System;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public class Map
    {
        private string[,] locations;
        private Dictionary<string, Action<Player>> locationActions;

        public Map()
        {
            locations = new string[3, 3]
            {
                { "", "Asteroid Field", "" },
                { "Space Station", "", "Alien Planet" },
                { "", "Black Hole", "" }
            };

            locationActions = new Dictionary<string, Action<Player>>
            {
                { "Asteroid Field", AsteroidFieldAction },
                { "Space Station", SpaceStationAction },
                { "Alien Planet", AlienPlanetAction },
                { "Black Hole", BlackHoleAction }
            };
        }

        public void DisplayMap()
        {
            Console.Clear();
            Console.WriteLine("Map:");
            for (int y = 0; y < locations.GetLength(0); y++)
            {
                for (int x = 0; x < locations.GetLength(1); x++)
                {
                    Console.Write(locations[y, x].PadRight(15));
                }
                Console.WriteLine();
            }
        }

        public void Navigate(Player player)
        {
            Console.WriteLine($"You are at: {locations[player.Y, player.X]}");
            Console.WriteLine("Use W/A/S/D to move, I to check inventory, Q to quit.");
            Console.Write("Your move: ");

            string input = Console.ReadLine()?.ToUpper();
            switch (input)
            {
                case "W":
                    if (player.Y > 0) player.Y--;
                    break;
                case "A":
                    if (player.X > 0) player.X--;
                    break;
                case "S":
                    if (player.Y < locations.GetLength(0) - 1) player.Y++;
                    break;
                case "D":
                    if (player.X < locations.GetLength(1) - 1) player.X++;
                    break;
                case "I":
                    player.ShowInventory();
                    break;
                case "Q":
                    Console.WriteLine("Exiting the game...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }

            string currentLocation = locations[player.Y, player.X];
            if (locationActions.ContainsKey(currentLocation))
            {
                locationActions[currentLocation](player);
            }
        }

        private void AsteroidFieldAction(Player player)
        {
            Console.WriteLine("You navigate through a dangerous asteroid field and find a piece of alien technology.");
            player.AddToInventory("Alien Technology");
        }

        private void SpaceStationAction(Player player)
        {
            Console.WriteLine("You dock at a space station. A merchant offers you information about a hidden treasure on an alien planet.");
        }

        private void AlienPlanetAction(Player player)
        {
            if (player.Inventory.Contains("Alien Technology"))
            {
                Console.WriteLine("You use the Alien Technology to unlock the secrets of the planet and discover a hidden treasure. You win!");
                player.HasWon = true;
            }
            else
            {
                Console.WriteLine("The planet's secrets are locked. You need Alien Technology to proceed.");
            }
        }

        private void BlackHoleAction(Player player)
        {
            Console.WriteLine("You approach a black hole and find a rare energy crystal.");
            player.AddToInventory("Energy Crystal");
        }
    }
}