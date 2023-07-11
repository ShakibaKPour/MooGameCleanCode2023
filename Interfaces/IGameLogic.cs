namespace MooGameCleanCode2023.Interfaces;
public interface IGameLogic
{
    void PlayGame();

    int TotalGuesses {  get; }

    void RegisterObserver(IGameResultObserver observer);
}
