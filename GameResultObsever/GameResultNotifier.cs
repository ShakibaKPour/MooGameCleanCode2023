using MooGameCleanCode2023.SingletonResultLog;

namespace MooGameCleanCode2023.GameResultObsever;

public class GameResultNotifier : IGameResultObserver
{
    private readonly IResultManager resultManager;
    public GameResultNotifier(IResultManager resultManager)
    {
        this.resultManager = resultManager;
    }

    public void NotifyGameResult(string playerName, int guesses)
    {
        resultManager.SaveGameResult(playerName, guesses);
    }
}
