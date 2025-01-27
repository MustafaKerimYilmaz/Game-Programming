using System;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasWon { get; set; }
        public List<string> Inventory { get; private set; }

        public Player()
        {
            Inventory = new List<string>();
            Reset();
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
            HasWon = false;
            Inventory.Clear();
        }

        public void AddToInventory(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item} has been added to your inventory.");
        }

        public void ShowInventory()
        {
            Console.WriteLine("Your Inventory:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine(" - Empty");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($" - {item}");
                }
            }
        }
    }
}
