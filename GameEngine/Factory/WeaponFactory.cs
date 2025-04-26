using GameEngine.Interfaces;
using GameEngine.Models;

namespace GameEngine.Factory
{
    public static class WeaponFactory
    {
        public static IWeapon CreateWeapon(string weaponType)
        {
            switch (weaponType.ToLower())
            {
                case "sword":
                    return new Weapon(100, 20, 5, "sword");
                case "axe":
                    return new Weapon(80, 25, 3, "axe");
                case "bow":
                    return new Weapon(60, 15, 2, "bow");
                case "default":
                default:
                    return new Weapon(0, 0, 0, "Default");
            }
        }
    }
}
