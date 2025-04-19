using System;
using GameEngine.Interfaces;
using GameEngine.Factory;

namespace GameEngine.Systems
{
    public class BattleSystem
    {
        public void Start(ICharacter player)
        {
            ICharacter enemy = EnemyFactory.CreateRandomEnemy();
            Console.WriteLine($"A wild {enemy.Name} appears!\n");

            while (player.IsAlive && enemy.IsAlive)
            {
                //Player's turn
                //Choose attack strategy
                Console.WriteLine("Choose Attack Strategy: Melee, Magic");
                var attackStrategy = Console.ReadLine() ?? "";
                player.changeAttackStrategy(attackStrategy);

                //Damage calculation
                int damage = player.Attack();
                Console.WriteLine($"{player.Name} attacks {enemy.Name} for {damage} damage.");
                enemy.TakeDamage(damage);

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!\n");
                    break;
                }

                //Enemy's turn
                int enemyDamage = enemy.Attack();
                Console.WriteLine($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
                player.TakeDamage(enemyDamage);

                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.Name} has fallen...\n");
                    break;
                }

                Console.WriteLine($"Status - {player.Name}: {player.HP} HP, {enemy.Name}: {enemy.HP} HP\n");
            }
        }
        public void Encounter(ICharacter player)
        {
            Random random = new Random();
            var eventType = random.Next(1, 3);
            switch (eventType)
            {
                case 1:
                    Console.WriteLine("You encounter a wild enemy!");
                    Start(player);
                    break;
                case 2:
                    Console.WriteLine("You find a treasure chest!");
                    // Implement treasure logic here
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid event type");
            }
        }
    }
}