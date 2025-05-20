using GameEngine.Interfaces;
using GameEngine.Manager;
using GameEngine.Models;
using GameEngine.Systems;

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

            IPlayer player = new Player(playerName, 100, new DefaultAttackStrategy(), new ExperienceManager(), new InventoryManager());
            var battle = new GameSystem();

            while (true)
            {
                //イベントを発生させる
                battle.Encounter(player);
                if (!player.IsAlive)
                {
                    break;
                }
                //プレイヤーが生きている場合、情報を表示する
                player.ShowInfo();
            }
            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }
    }
}