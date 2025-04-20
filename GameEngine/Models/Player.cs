using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public int HP { get; private set; }

        private int _maxHP { get; set; }
        public IAttackStrategy _attackStrategy { get; private set; }

        public bool IsAlive => HP > 0;
        public int TotalExperience { get; private set; } = 0;
        public int Level { get; private set; } = 1;

        public Player(string name, int hp, IAttackStrategy attackStrategy)
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
        public void GainExperience(int amount)
        {
            TotalExperience += amount;
            if (TotalExperience >= 100) // Example level up condition
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Level++;
            TotalExperience -= 100; // Reset experience for next level
            HP += 10; // Increase max HP on level up
            _maxHP += 10;
            Console.WriteLine($"{Name} leveled up to level {Level}!");
        }
    }
}