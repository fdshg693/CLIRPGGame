using System;
using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class DefaultAttackStrategy : IAttackStrategy
    {
        private static readonly Random _rnd = new Random();
        public int ExecuteAttack() => _rnd.Next(5, 16);
    }
}