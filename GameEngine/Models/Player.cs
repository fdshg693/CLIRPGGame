using GameEngine.Factory;
using GameEngine.Interfaces;
using GameEngine.Manager;

namespace GameEngine.Models
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public int HP { get; private set; }

        public int BaseHP { get; private set; }
        public int BaseAP { get; private set; } = 10; // Attack Power
        public int BaseDP { get; private set; } = 5; // Defense Power
        private int MaxHP => BaseHP + Weapon.HP; // Total Health Points
        public int AP => BaseAP + Weapon.AP; // Total Attack Power
        public int DP => BaseDP + Weapon.DP; // Total Defense Power        
        public bool IsAlive => HP > 0;
        public IAttackStrategy _AttackStrategy { get; private set; }

        public InventoryManager inventoryManager { get; private set; }
        public IWeapon Weapon { get; private set; } // Player's weapon
        public ExperienceManager experienceManager { get; private set; } // Experience manager for the player

        public Player(string name, int hp, IAttackStrategy attackStrategy, ExperienceManager experienceManager, InventoryManager inventoryManager)
        {
            this.experienceManager = experienceManager;
            this.inventoryManager = inventoryManager;
            Name = name;
            HP = hp;
            BaseHP = hp;
            _AttackStrategy = attackStrategy;
            Weapon = WeaponFactory.CreateWeapon("default");
        }

        public void EquipWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
            Console.WriteLine($"{Name} equipped a {weapon.GetType().Name}!");
        }

        public void Attack(ICharacter character)
        {
            character.TakeDamage(_AttackStrategy.ExecuteAttack() + AP);
        }
        public void TakeDamage(int amount)
        {
            int damage = amount - DP;
            HP -= damage;
            if (HP < 0) HP = 0;
        }
        public void Heal(int amount)
        {
            Console.WriteLine($"You heal {amount}");
            HP += amount;
            if (HP > MaxHP) HP = MaxHP;
        }
        public void ChangeAttackStrategy(string AttackStrategyName)
        {
            _AttackStrategy = AttackStrategy.GetAttackStrategy(AttackStrategyName);
        }
        public void DefeatEnemy(IEnemy enemy)
        {
            Console.WriteLine($"You defeated {enemy.Name}!");
            GainGold(enemy.Gold);
            bool isLevelUp = experienceManager.GainExperience(enemy.Experience) == 1;
            if (isLevelUp)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            HP += 10; // Example level up effect
            BaseHP += 10; // Increase base HP
            BaseAP += 2; // Increase base attack power
            BaseDP += 1; // Increase base defense power
        }
        public void GainGold(int amount)
        {
            inventoryManager.GainGold(amount);
        }
        public void BuyPotion(int amount)
        {
            inventoryManager.BuyPotion(amount);
        }
        public void UsePotion(int amount)
        {
            inventoryManager.UsePotion(amount);
        }
        //disolay all information about the player
        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name} HP: {HP}/{MaxHP} Weapon: {Weapon.Name}");
            inventoryManager.ShowInfo();

        }
    }
}