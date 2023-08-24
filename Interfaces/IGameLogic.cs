namespace MooGameCleanCode2023.Interfaces;
public interface IGameLogic
{
    void PlayGame();

    int TotalGuesses {  get; }

    int GoalLength { get; } 

    void RegisterObserver(IGameResultObserver observer);
}
