using GameEngine.Interfaces;
using GameEngine.Models;

namespace GameEngine.Manager
{
    public class InventoryManager : IEquipmentStatsProvider
    {
        public int TotalGold { get; private set; } = 50;
        public IWeapon Weapon { get; private set; }
        public event Action? EquipmentChanged;
        public int TotalPotions { get; private set; } = 0;
        public InventoryManager()
        {
            Weapon = new Weapon(0, 0, 0, "Default");
        }
        public void EquipWeapon(IWeapon newWeapon)
        {
            Weapon = newWeapon;
            EquipmentChanged?.Invoke();
            Console.WriteLine($"You equipped a {newWeapon.Name}");
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
            Console.WriteLine($"Equipped Weapon: {Weapon.Name}");
        }
    }
}
