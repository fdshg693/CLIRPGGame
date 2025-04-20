namespace GameEngine.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        int BaseHP { get; }
        int BaseAP { get; }
        int BaseDP { get; }
        bool IsAlive { get; }
        void Attack(ICharacter character);
        void TakeDamage(int amount);
        void Heal(int amount);
        void changeAttackStrategy(string AttackStrategyName);
    }
}