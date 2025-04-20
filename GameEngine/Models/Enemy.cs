using GameEngine.Models;
using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Enemy : IEnemy
    {
        public string Name { get; private set; }
        public int HP { get; private set; }

        private int _maxHP { get; }
        public int AP { get; private set; }
        public int DP { get; private set; }
        public IAttackStrategy _attackStrategy { get; private set; }

        public bool IsAlive => HP > 0;
        public int Experience { get; private set; } = 0;
        public int Gold { get; private set; } = 0;

        public Enemy(string name, int hp, IAttackStrategy attackStrategy, int experience, int aP, int dP)
        {
            Name = name;
            HP = hp;
            _maxHP = hp;
            _attackStrategy = attackStrategy;
            Experience = experience;
            Gold = (experience / 2) + new Random().Next(1, 10);
            AP = aP;
            DP = dP;
        }
        public void Attack(ICharacter character)
        {
            character.TakeDamage(_attackStrategy.ExecuteAttack() + AP);
        }
        public void TakeDamage(int amount)
        {
            int damage = amount - DP;
            HP -= damage;
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