using MooGameCleanCode2023.GameResultObsever;

namespace MooGameCleanCode2023.Logics;

public static class GameLogicFactory
{
    public static IGameLogic CreateGameLogic()
    {
        IGoalGenerator goalGenerator = new RandomGoalGenerator();
        IGameResultObserver gameResultNotifier = new GameResultNotifier();
        return new BaseGameLogic(goalGenerator, gameResultNotifier);
    }
}
