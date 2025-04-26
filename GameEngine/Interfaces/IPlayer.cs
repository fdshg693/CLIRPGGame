namespace GameEngine.Interfaces
{
    public interface IPlayer : ICharacter
    {
        void DefeatEnemy(IEnemy enemy);  
        void GainGold(int amount);
        void BuyPotion(int amount);
        IWeapon Weapon { get; }
        void EquipWeapon(IWeapon weapon);
        void ShowInfo();
        void LevelUp();
    }
}
