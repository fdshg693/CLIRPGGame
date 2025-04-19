using System;
using GameEngine.Models;
using GameEngine.Systems;
using GameEngine.Interfaces;
using GameEngine.Factory;

namespace CliRpgGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLI RPG Mock ===");
            Console.Write("Enter your name: ");
            string? input = Console.ReadLine();
            string playerName = string.IsNullOrWhiteSpace(input)
                ? "defaultName"   
                : input;

            ICharacter player = new Character(playerName, 100, new DefaultAttackStrategy());

            while (true)
            {                
                var battle = new BattleSystem();
                battle.Encounter(player);
                if (!player.IsAlive)
                {
                    break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
                       
            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }
    }
}