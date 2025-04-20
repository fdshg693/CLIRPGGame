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
            string? input = Console.ReadLine();
            string playerName = string.IsNullOrWhiteSpace(input)
                ? "defaultName"   
                : input;

            IPlayer player = new Player(playerName, 100, new DefaultAttackStrategy());

            while (true)
            {                
                var battle = new BattleSystem();
                battle.Encounter(player);
                if (!player.IsAlive)
                {
                    break;
                }
                player.showInfo();
                Console.WriteLine("Press Enter to Start Next Game...");
                Console.ReadLine();
            }
            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }
    }
}