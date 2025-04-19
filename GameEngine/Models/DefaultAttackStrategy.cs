using System;
using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public static class AttackStrategy
    {
        public static IAttackStrategy GetAttackStrategy(string attackType)
        {
            return attackType switch
            {
                "Melee" => new MeleeAttackStrategy(),
                "Magic" => new MagicAttackStrategy(),
                _ => new DefaultAttackStrategy()
            };
        }
    }
    public class DefaultAttackStrategy : IAttackStrategy
    {
        private static readonly Random _rnd = new Random();
        public int ExecuteAttack() => _rnd.Next(5, 16);
        
    }
    public class MeleeAttackStrategy : IAttackStrategy
    {
        private static readonly Random _rnd = new Random();
        public int ExecuteAttack() => _rnd.Next(12, 13);
    }

    public class MagicAttackStrategy : IAttackStrategy
    {
        private static readonly Random _rnd = new Random();
        public int ExecuteAttack() => _rnd.Next(0, 30);
    }
}