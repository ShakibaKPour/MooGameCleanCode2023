namespace MooGameCleanCode2023.Interfaces;
public interface IGameResultObserver
{
    void NotifyGameResult(string playerName, int guesses);
}