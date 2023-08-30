namespace MooGameCleanCode2023.Logics;

public class BaseGameLogic : IGameLogic
{
    protected int goalLength;
    protected string? goal;
    protected string? name;
    protected int totalGuesses;
    protected List<IGameResultObserver> observers = new List<IGameResultObserver>();
    protected readonly IGoalGenerator goalGenerator;
    protected IGameResultObserver gameResultObserver;
    public int TotalGuesses => totalGuesses;
    public int GoalLength => goalLength;
     
    public BaseGameLogic(IGoalGenerator goalGenerator, IGameResultObserver gameResultObserver, int goalLength)
    {
            this.goalGenerator = goalGenerator;
            this.gameResultObserver = gameResultObserver;
            this.goalLength = goalLength;
    }

    public void RegisterObserver(IGameResultObserver observer)
    {
        observers.Add(observer);
    }
    public void PlayGame()
    {
        goal = goalGenerator.GenerateGoal(GoalLength);
        HandleGameFlow();
        gameResultObserver.NotifyGameResult(name, totalGuesses);
    }

    protected void HandleGameFlow()
    {
        name = GetPlayerName();
        Console.WriteLine("New game:");
        Console.WriteLine("For practice, the number is: " + goal);
        string guess = GetPlayerGuess();

        totalGuesses = 1;
        string bbcc = CheckBC(goal, guess);
        Console.WriteLine(bbcc + "\n");

        while (bbcc.Contains('C') || bbcc.Length <= goalLength)
        {
            totalGuesses++;
            guess = GetPlayerGuess();
            Console.WriteLine(guess);
            bbcc = CheckBC(goal, guess);
            Console.WriteLine(bbcc + "\n");
        }

    }

    protected string GetPlayerName()
    {
        Console.WriteLine("Enter your user name:");
        string? name = Console.ReadLine();
        while (name?.Length == 0)
        {
            Console.WriteLine("Your name must be at least 1 character long. Try again:");
            name = Console.ReadLine();
        }
        return name;
    }

    protected string GetPlayerGuess()
    {
        Console.WriteLine("Enter your guess:");
        string? guess = Console.ReadLine();

        while (guess?.Length != GoalLength || guess.Any(c => !char.IsDigit(c)))
        {
            Console.WriteLine("Your guess must be digits and " + GoalLength + " long. Try again:");
            guess = Console.ReadLine();
        }

        return guess;
    }

    public string CheckBC(string goal, string guess)
    {
        string bulls = "", cows = "";
        guess = guess.PadRight(GoalLength);


        for (int i = 0; i < GoalLength; i++)
        {
            for (int j = 0; j < GoalLength; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls+="B";
                    }
                    else
                    {
                        cows += "C";
                    }
                }
            }
        }
        return bulls + "," + cows;
    }
}
