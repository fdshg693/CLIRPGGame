using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IEnemy: ICharacter
    {
        int Experience { get; }
        int Gold { get; }
    }
}
