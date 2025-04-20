namespace GameEngine.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        int AP { get; }
        int DP { get; }
        bool IsAlive { get; }
        void Attack(ICharacter character);
        void TakeDamage(int amount);
        void Heal(int amount);
        void changeAttackStrategy(string AttackStrategyName);
    }
}