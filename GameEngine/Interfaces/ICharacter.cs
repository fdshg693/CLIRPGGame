namespace GameEngine.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        bool IsAlive { get; }
        int Attack();
        void TakeDamage(int amount);
    }
}