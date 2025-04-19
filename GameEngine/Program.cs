using System;
using GameEngine.Models;
using GameEngine.Systems;
using GameEngine.Interfaces;

namespace CliRpgGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLI RPG Mock ===");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "defaultName";

            ICharacter player = new Character(playerName, 100, new DefaultAttackStrategy());
            ICharacter enemy = new Enemy("Goblin", 50, new DefaultAttackStrategy());

            var battle = new BattleSystem();
            battle.Start(player, enemy);

            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }
    }
}