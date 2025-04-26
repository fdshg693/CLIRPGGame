using GameEngine.Interfaces;

namespace GameEngine.Systems
{
    public static class RestSystem
    {
        public static void UsePotion(IPlayer player)
        {
            Console.WriteLine("You can Use Potion!");
            var potionAmount = UserInteraction.ReadPositiveInteger("Enter the amount of Potuion you want to use: ");
            player.UsePotion(potionAmount);
        }
    }
}
