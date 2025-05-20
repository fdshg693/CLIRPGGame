using GameEngine.Interfaces;
using GameEngine.Manager;

namespace GameEngine.Models
{
    public class Player : IPlayer
    {
        public string Name { get; }
        private readonly HealthManager _health;
        private readonly InventoryManager _inventory;
        private readonly ExperienceManager _experience;
        private IAttackStrategy _attackStrategy;
        private int BaseAP { get; set; } = 10;

        // ヘルス関係はすべて _health に切り出し
        public int HP => _health.CurrentHP;
        public int MaxHP => _health.MaxHP;
        public int DP => _health.TotalDP;
        public bool IsAlive => _health.IsAlive;

        public int AP => BaseAP + _inventory.Weapon.AP;

        public Player(
            string name,
            int initialHP,
            IAttackStrategy attackStrategy,
            ExperienceManager experienceManager,
            InventoryManager inventoryManager)
        {
            Name = name;
            _attackStrategy = attackStrategy;
            _experience = experienceManager;
            _inventory = inventoryManager;
            _health = new HealthManager(baseHP: initialHP, baseDP: 5, equipProvider: _inventory);
        }

        public void EquipWeapon(IWeapon weapon) => _inventory.EquipWeapon(weapon);

        public void Attack(ICharacter target)
        {
            int damage = _attackStrategy.ExecuteAttack() + AP;
            target.TakeDamage(damage);
        }

        public void TakeDamage(int amount)
        {
            int damage = _health.TakeDamage(amount);
            Console.WriteLine($"{Name} takes {damage} damage! Remaining HP: {HP}");
        }

        public void Heal(int amount)
        {
            Console.WriteLine($"You heal {amount}");
            _health.Heal(amount);
        }

        public void ChangeAttackStrategy(string strategyName)
            => _attackStrategy = AttackStrategy.GetAttackStrategy(strategyName);

        public void DefeatEnemy(IEnemy enemy)
        {
            Console.WriteLine($"You defeated {enemy.Name}!");
            GainGold(enemy.Gold);
            bool leveledUp = _experience.GainExperience(enemy.Experience) == 1;
            if (leveledUp)
            {
                // レベルアップ：HP+10、DP+1、AP+2
                _health.LevelUp(hpIncrease: 10, dpIncrease: 1);
                BaseAP += 2;
            }
        }

        public void GainGold(int amt) => _inventory.GainGold(amt);
        public void BuyPotion(int amt) => _inventory.BuyPotion(amt);
        public void UsePotion(int amt)
        {
            _inventory.UsePotion(amt);
            Heal(10 * amt);
        }

        public int ReturnTotalPotions() => _inventory.ReturnTotalPotions();
        public int ReturnTotalGold() => _inventory.ReturnTotalGold();

        public void ShowInfo()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Name: {Name}  HP: {HP}/{MaxHP}  AP: {AP}  DP: {DP}");
            _inventory.ShowInfo();
            _experience.ShowInfo();
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }

}