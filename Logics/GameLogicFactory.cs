using MooGameCleanCode2023.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameCleanCode2023.Logics
{
    public static class GameLogicFactory
    {
        public static IGameLogic CreateGameLogic()
        {
            IGoalGenerator goalGenerator = new RandomGoalGenerator();
            return new GameLogic(goalGenerator);
        }
    }
}
