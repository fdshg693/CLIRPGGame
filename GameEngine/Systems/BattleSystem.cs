using GameEngine.Interfaces;
using GameEngine.Factory;

namespace GameEngine.Systems
{
    public class BattleSystem
    {
        public void Encounter(IPlayer player)
        {
            Random random = new Random();
            var eventType = random.Next(1, 4);
            switch (eventType)
            {
                case 1:
                    player.GainGold(random.Next(10, 20));
                    Shop(player);                    
                    Console.WriteLine($"Status - {player.Name}: {player.HP} HP");
                    break;
                default:
                    Console.WriteLine("You encounter a wild enemy!");
                    Start(player);
                    break;
            }
        }
        public void Start(IPlayer player)
        {
            IEnemy enemy = EnemyFactory.CreateRandomEnemy();
            Console.WriteLine($"A wild {enemy.Name} appears!\n");

            while (player.IsAlive && enemy.IsAlive)
            {
                //Player's turn
                //Choose attack strategy                
                var AttackStrategyArray = new string[] { "Default", "Melee", "Magic" };                
                var StrategyIndex = 0;
                Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");

                while (true)
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        // カーソルを 1 行上に移動（\x1b[1A）して、その行をクリア（\x1b[2K）
                        clearLastOutput();
                        StrategyIndex = (StrategyIndex - 1 + AttackStrategyArray.Length) % AttackStrategyArray.Length;
                        Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        clearLastOutput();
                        StrategyIndex = (StrategyIndex + 1) % AttackStrategyArray.Length;
                        Console.WriteLine($"Selected Attack Strategy: {AttackStrategyArray[StrategyIndex]}");
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        clearLastOutput();
                        break;
                    }
                }
                player.ChangeAttackStrategy(AttackStrategyArray[StrategyIndex]);

                //Damage calculation
                player.Attack(enemy);
                Console.WriteLine($"{player.Name} attacks {enemy.Name} by {AttackStrategyArray[StrategyIndex]}");

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
        public void Shop(IPlayer player)
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
                    player.BuyPotion(10);
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
        public void clearLastOutput()
        {
            Console.Write("\x1b[1A");  // 上へカーソル移動
            Console.Write("\x1b[2K");  // 行全体をクリア
        }
    }
}