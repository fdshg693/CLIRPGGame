using GameEngine.Factory;
using GameEngine.Interfaces;

namespace GameEngine.Systems
{
    public class GameSystem
    {
        public void Encounter(IPlayer player)
        {
            Random random = new Random();
            var eventType = random.Next(1, 4);
            switch (eventType)
            {
                case 1:
                    player.GainGold(random.Next(10, 20));
                    ShopSystem.Shop(player);
                    Console.WriteLine($"Status - {player.Name}: {player.HP} HP");
                    RestSystem.UsePotion(player);
                    break;
                default:
                    Console.WriteLine("You encounter a wild enemy!");
                    BattleStart(player);
                    RestSystem.UsePotion(player);
                    break;
            }
        }
        public void BattleStart(IPlayer player)
        {
            IEnemy enemy = EnemyFactory.CreateRandomEnemy();
            Console.WriteLine($"A wild {enemy.Name} appears!\n");

            while (player.IsAlive && enemy.IsAlive)
            {
                var attackStrategyName = UserInteraction.SelectAttackStrategy();
                player.ChangeAttackStrategy(attackStrategyName);

                //Damage calculation
                player.Attack(enemy);
                Console.WriteLine($"{player.Name} attacks {enemy.Name} by {attackStrategyName}");

                //Player wins
                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!\n");
                    GameRecord.RecordWin();
                    GameRecord.ShowRecord();
                    player.DefeatEnemy(enemy);
                    break;
                }

                //Enemy's turn
                enemy.Attack(player);
                Console.WriteLine($"{enemy.Name} attacks {player.Name}");

                //Player loses
                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.Name} has fallen...\n");
                    GameRecord.RecordLoss();
                    GameRecord.ShowRecord();
                    break;
                }

                Console.WriteLine($"Status - {player.Name}: {player.HP} HP, {enemy.Name}: {enemy.HP} HP\n");
            }
        }
    }
}