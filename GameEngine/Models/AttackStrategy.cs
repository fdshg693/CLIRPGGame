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
        public int ExecuteAttack() => new Random().Next(8, 10);
        public string GetAttackStrategyName()
        {
            return "Default";
        }
    }
    public class MeleeAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack() => new Random().Next(10, 16);
        public string GetAttackStrategyName()
        {
            return "Melee";
        }
    }

    public class MagicAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack() => new Random().Next(0, 25);

        public string GetAttackStrategyName()
        {
            return "Magic";
        }
    }
}
