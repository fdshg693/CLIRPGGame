namespace GameEngine.Interfaces
{
    public interface IPlayer : ICharacter
    {
        int TotalExperience { get; }
        int Level { get; }
        int TotalGold { get; }
        void DefeatEnemy(IEnemy enemy);  
        void GainGold(int amount);
        void BuyPotion(int amount);
        IWeapon weapon { get; }
        void EquipWeapon(IWeapon weapon);
        void showInfo();
    }
}
