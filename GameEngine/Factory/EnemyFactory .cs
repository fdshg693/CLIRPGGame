﻿using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Factory
{
    public static class EnemyFactory
    {
        public static Enemy CreateGoblin()
            => new Enemy(
                name: "Goblin",
                hp: 50,
                attackStrategy: new MeleeAttackStrategy()
            );

        public static Enemy CreateSlime()
            => new Enemy(
                name: "Slime",
                hp: 30,
                attackStrategy: new MagicAttackStrategy()
            );
        public static Enemy CreateRandomEnemy()
        {
            Random random = new Random();
            int enemyType = random.Next(1, 3); // 1 for Goblin, 2 for Slime
            return enemyType switch
            {
                1 => CreateGoblin(),
                2 => CreateSlime(),
                _ => throw new ArgumentOutOfRangeException("Invalid enemy type")
            };
        }
    }

}
