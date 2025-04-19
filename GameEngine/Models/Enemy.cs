using GameEngine.Models;
using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class Enemy : Character
    {
        public Enemy(string name, int hp, IAttackStrategy attackStrategy)
            : base(name, hp, attackStrategy) { }
    }
}