using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public int HP { get; private set; }
        private readonly IAttackStrategy _attackStrategy;

        public bool IsAlive => HP > 0;

        public Character(string name, int hp, IAttackStrategy attackStrategy)
        {
            Name = name;
            HP = hp;
            _attackStrategy = attackStrategy;
        }

        public int Attack() => _attackStrategy.ExecuteAttack();

        public void TakeDamage(int amount)
        {
            HP -= amount;
            if (HP < 0) HP = 0;
        }
    }
}