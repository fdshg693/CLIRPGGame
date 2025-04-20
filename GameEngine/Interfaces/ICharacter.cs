namespace GameEngine.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        bool IsAlive { get; }
        int Attack();
        void TakeDamage(int amount);
        void Heal(int amount);
        void changeAttackStrategy(string AttackStrategyName);
    }
}