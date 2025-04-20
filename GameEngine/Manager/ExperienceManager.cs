using GameEngine.Interfaces;

namespace GameEngine.Manager
{
    public class ExperienceManager
    {
        public int TotalExperience { get; private set; } = 0;
        public int Level { get; private set; } = 1;
        /// <summary>
        /// Gain experience points and check for level up.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>LevelUp</returns>
        public int GainExperience(int amount)
        {
            Console.WriteLine($"You gain {amount} experience");
            Console.WriteLine($"Total Experience: {TotalExperience}");
            Console.WriteLine($"Level: {Level}");
            TotalExperience += amount;
            if (TotalExperience >= 100) // Example level up condition
            {
                Level++;
                TotalExperience -= 100;
                Console.WriteLine($"Levele UP to level {Level}!");
                Console.WriteLine($"Total Experience: {TotalExperience}");
                Console.WriteLine($"Level: {Level}");
                return 1;
            }
            return 0;
        }
    }
}
