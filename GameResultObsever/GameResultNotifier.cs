﻿namespace MooGameCleanCode2023.GameResultObsever;

public class GameResultNotifier : IGameResultObserver
{
    private readonly ResultManager resultManager;
    public GameResultNotifier()
    {
        resultManager = ResultManager.Instance;
    }

    public void NotifyGameResult(string playerName, int guesses)
    {
        resultManager.SaveGameResult(playerName, guesses);
    }
}
