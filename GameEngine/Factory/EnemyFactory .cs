using GameEngine.Interfaces;
using GameEngine.Models;

namespace GameEngine.Factory
{
    public static class EnemyFactory
    {
        public static IEnemy CreateGoblin()
            => new Enemy(
                name: "Goblin",
                hp: 30,
                attackStrategy: new MeleeAttackStrategy(),
                experience: 20,
                aP: 5,
                dP: 2
            );
        public static IEnemy CreateSlime()
            => new Enemy(
                name: "Slime",
                hp: 10,
                attackStrategy: new DefaultAttackStrategy(),
                experience: 10,
                aP: 4,
                dP: 1
            );
        public static IEnemy CreateBoss()
            => new Enemy(
                name: "Boss",
                hp: 100,
                attackStrategy: new MagicAttackStrategy(),
                experience: 50,
                aP: 10,
                dP: 5
            );
        public static IEnemy CreateRandomEnemy()
        {
            Random random = new Random();
            int enemyType = random.Next(1, 4);
            return enemyType switch
            {
                1 => CreateGoblin(),
                2 => CreateSlime(),
                3 => CreateBoss(),
                _ => throw new ArgumentOutOfRangeException("Invalid enemy type")
            };
        }
    }

}
