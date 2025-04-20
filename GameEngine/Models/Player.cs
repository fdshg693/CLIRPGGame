using GameEngine.Factory;
using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public int HP { get; set; }

        public int BaseHP { get; private set; }
        public int BaseAP { get; private set; } = 10; // Attack Power
        public int BaseDP { get; private set; } = 5; // Defense Power
        public int AP => BaseAP + weapon.AP; // Total Attack Power
        public int DP => BaseDP + weapon.DP; // Total Defense Power
        private int MaxHP => BaseHP + weapon.HP; // Total Health Points
        public IAttackStrategy _attackStrategy { get; private set; }

        public bool IsAlive => HP > 0;
        public int TotalExperience { get; private set; } = 0;
        public int Level { get; private set; } = 1;
        public int TotalGold { get; private set; } = 50;
        public IWeapon weapon { get; private set; } // Player's weapon

        public Player(string name, int hp, IAttackStrategy attackStrategy)
        {
            Name = name;
            HP = hp;
            BaseHP = hp;
            _attackStrategy = attackStrategy;
            weapon = WeaponFactory.CreateWeapon("default");
        }

        public void EquipWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
            Console.WriteLine($"{Name} equipped a {weapon.GetType().Name}!");
        }

        public void Attack(ICharacter character)
        {
            character.TakeDamage(_attackStrategy.ExecuteAttack() + BaseAP);
        }
        public void TakeDamage(int amount)
        {
            int damage = amount - BaseDP;
            HP -= damage;
            if (HP < 0) HP = 0;
        }
        public void Heal(int amount)
        {
            Console.WriteLine($"You heal {amount}");
            HP += amount;
            if (HP > BaseHP) HP = BaseHP;
        }
        public void changeAttackStrategy(string AttackStrategyName)
        {
            _attackStrategy = AttackStrategy.GetAttackStrategy(AttackStrategyName);
        }
        public void DefeatEnemy(IEnemy enemy)
        {
            Console.WriteLine($"You defeated {enemy.Name}!");
            GainExperience(enemy.Experience);
            GainGold(enemy.Gold);
        }
        private void GainExperience(int amount)
        {
            Console.WriteLine($"You gain {amount} experience");
            TotalExperience += amount;
            if (TotalExperience >= 100) // Example level up condition
            {
                LevelUp();
            }
        }
        private void LevelUp()
        {
            Level++;
            TotalExperience -= 100; // Reset experience for next level
            HP += 10; // Increase max HP on level up
            BaseHP += 10;
            Console.WriteLine($"{Name} leveled up to level {Level}!");
        }
        public void GainGold(int amount)
        {
            Console.WriteLine($"You gain {amount} gold");
            TotalGold += amount;
        }
        public void BuyPotion(int amount)
        {
            if(TotalGold >= amount)
            {
                TotalGold -= amount;
                Heal(20); // Example potion effect
                Console.WriteLine($"{Name} bought a potion and healed 20 HP!");
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough gold to buy a potion.");
            }
        }
        //disolay all information about the player
        public void showInfo()
        {
            Console.WriteLine($"Name: {Name} HP: {HP}/{MaxHP} Level: {Level} Total Experience: {TotalExperience} Total Gold: {TotalGold} Weapon: {weapon.Name}");

        }
    }
}