using System;
using GameEngine.Interfaces;

namespace GameEngine.Systems
{
    public class BattleSystem
    {
        public void Start(ICharacter player, ICharacter enemy)
        {
            Console.WriteLine($"A wild {enemy.Name} appears!\n");

            while (player.IsAlive && enemy.IsAlive)
            {
                // ÉvÉåÉCÉÑÅ[ÇÃçUåÇ
                int damage = player.Attack();
                Console.WriteLine($"{player.Name} attacks {enemy.Name} for {damage} damage.");
                enemy.TakeDamage(damage);

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!\n");
                    break;
                }

                // ìGÇÃçUåÇ
                int enemyDamage = enemy.Attack();
                Console.WriteLine($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
                player.TakeDamage(enemyDamage);

                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.Name} has fallen...\n");
                    break;
                }

                Console.WriteLine($"Status - {player.Name}: {player.HP} HP, {enemy.Name}: {enemy.HP} HP\n");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}