using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IPlayer : ICharacter
    {
        int TotalExperience { get; }
        int Level { get; }
        int TotalGold { get; }
        void GainExperience(int amount);
        void LevelUp();        
        void GainGold(int amount);
        void BuyPotion(int amount);
    }
}
