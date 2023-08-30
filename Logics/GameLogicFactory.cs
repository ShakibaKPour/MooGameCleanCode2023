using MooGameCleanCode2023.GameResultObsever;

namespace MooGameCleanCode2023.Logics;

public static class GameLogicFactory
{
    public static IGameLogic CreateGameLogic()
    {
        IGoalGenerator goalGenerator = new RandomGoalGenerator();
        IResultManager resultManagerInstance = ResultManager.Instance;
        IGameResultObserver gameResultNotifier = new GameResultNotifier(resultManagerInstance);
        return new BaseGameLogic(goalGenerator, gameResultNotifier, 4);
    }

    public static IGameLogic CreateGameLogic6()
    {
        IGoalGenerator goalGenerator = new RandomGoalGenerator();
        IResultManager resultManagerInstance = ResultManager.Instance;
        IGameResultObserver gameResultNotifier = new GameResultNotifier(resultManagerInstance);
        return new GameLogic6(goalGenerator, gameResultNotifier);
    }
}
