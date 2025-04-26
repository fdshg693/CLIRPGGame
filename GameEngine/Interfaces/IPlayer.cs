namespace GameEngine.Interfaces
{
    public interface IPlayer : ICharacter
    {
        void DefeatEnemy(IEnemy enemy);
        void GainGold(int amount);
        void BuyPotion(int amount);
        void EquipWeapon(IWeapon weapon);
        void ShowInfo();
        void LevelUp();
        void UsePotion(int amount);
    }
}
