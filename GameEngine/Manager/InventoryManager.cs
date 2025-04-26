using GameEngine.Interfaces;
using GameEngine.Models;

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
        public void EquipWeapon(IWeapon weapon)
        {
            Weapon = weapon;
            Console.WriteLine($"You equipped a {weapon.Name}");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Total Gold: {TotalGold}");
            Console.WriteLine($"Total Potions: {TotalPotions}");
            Console.WriteLine($"Equipped Weapon: {Weapon.Name}");
        }
    }
}
