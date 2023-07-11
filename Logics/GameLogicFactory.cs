using MooGameCleanCode2023.Interfaces;

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
