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
                //お店に遭遇
                case 1:
                    player.GainGold(random.Next(10, 20));
                    ShopSystem.Shop(player);
                    Console.WriteLine($"Status - {player.Name}: {player.HP} HP");
                    RestSystem.UsePotion(player);
                    break;
                //敵に遭遇
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

            //　両者が生きている限り戦闘を続ける
            while (player.IsAlive && enemy.IsAlive)
            {
                // 攻撃方法をプレイヤーが選択
                var attackStrategyName = UserInteraction.SelectAttackStrategy();
                player.ChangeAttackStrategy(attackStrategyName);

                //Damage calculation
                player.Attack(enemy);
                Console.WriteLine($"{player.Name} attacks {enemy.Name} by {attackStrategyName}");
                Console.WriteLine("-------------------------------------------------------------------");

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
                Console.WriteLine($"{enemy.Name} attacks {player.Name} by {enemy._attackStrategy.GetAttackStrategyName()}");
                Console.WriteLine("-------------------------------------------------------------------");

                //Player loses
                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.Name} has fallen...\n");
                    GameRecord.RecordLoss();
                    GameRecord.ShowRecord();
                    break;
                }

                // 状態を表示
                Console.WriteLine($"Status - {player.Name}: {player.HP} HP, {enemy.Name}: {enemy.HP} HP\n");
            }
        }
    }
}