using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public int HP { get; private set; }

        private int _maxHP { get; }
        public IAttackStrategy _attackStrategy { get; private set; }

        public bool IsAlive => HP > 0;

        public Character(string name, int hp, IAttackStrategy attackStrategy)
        {
            Name = name;
            HP = hp;
            _maxHP = hp;
            _attackStrategy = attackStrategy;
        }

        public int Attack() => _attackStrategy.ExecuteAttack();

        public void TakeDamage(int amount)
        {
            HP -= amount;
            if (HP < 0) HP = 0;
        }
        public void Heal(int amount)
        {
            HP += amount;
            if (HP > _maxHP) HP = _maxHP;
        }
        public void changeAttackStrategy(string AttackStrategyName)
        {
            _attackStrategy = AttackStrategy.GetAttackStrategy(AttackStrategyName);
        }
    }
}