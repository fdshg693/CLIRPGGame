using GameEngine.Interfaces;
using GameEngine.Models;
using System.Xml.Linq;

namespace GameEngine.Manager
{
    public class InventoryManager
    {
        public int TotalGold { get; private set; } = 50;
        public IWeapon Weapon { get; private set; } // Player's weapon
        public int TotalPotions { get; private set; } = 0;
        public InventoryManager()
        {
            Weapon = new Weapon(0, 0, 0, "Default");
        }
        public void GainGold(int amount)
        {
            Console.WriteLine($"You gain {amount} gold");
            TotalGold += amount;
        }
        public void BuyPotion(int amount)
        {
            if (TotalGold >= amount * 10)
            {
                TotalGold -= amount * 10;
                TotalPotions += amount;
                Console.WriteLine($"You bought {amount} potions");
            }
            else
            {
                Console.WriteLine("Not enough gold!");

            }
        }
        public void UsePotion(int amount)
        {
            if (TotalPotions >= amount)
            {
                TotalPotions -= amount;
                Console.WriteLine($"You used {amount} potions");
            }
            else
            {
                Console.WriteLine("Not enough potions!");
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Total Gold: {TotalGold}");
            Console.WriteLine($"Total Potions: {TotalPotions}");
        }
    }
}
