using GameEngine.Factory;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Systems
{
    public static class ShopSystem
    {
        public static void Shop(IPlayer player)
        {
            Console.WriteLine("Welcome to the shop!");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Buy Weapon");
            Console.WriteLine("3. Exit Shop");
            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.D1)
                {
                    Console.Write("How many?");
                    try
                    {
                        int? input = int.Parse(Console.ReadLine() ?? "0");
                        player.BuyPotion(input ?? 0);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        int? input = int.Parse(Console.ReadLine() ?? "0");
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Choose Weapon");
                    Console.WriteLine("1. SWORD");
                    Console.WriteLine("2. AXE");
                    Console.WriteLine("3. BOW");
                    keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        player.EquipWeapon(WeaponFactory.CreateWeapon("SWORD"));
                    }
                    else if (keyInfo.Key == ConsoleKey.D2)
                    {
                        player.EquipWeapon(WeaponFactory.CreateWeapon("AXE"));
                    }
                    else if (keyInfo.Key == ConsoleKey.D3)
                    {
                        player.EquipWeapon(WeaponFactory.CreateWeapon("BOW"));
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.D3)
                {
                    break;
                }
            }
        }
        public static void clearLastOutput()
        {
            Console.Write("\x1b[1A");  // 上へカーソル移動
            Console.Write("\x1b[2K");  // 行全体をクリア
        }
    }
}
