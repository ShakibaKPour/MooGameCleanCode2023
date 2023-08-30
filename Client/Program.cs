namespace MooGameCleanCode2023.Client;

public class Program
{
    private IGameLogic gameLogic;
    private IResultManager resultManager;
    bool playOn = true;
    public Program(IGameLogic gameLogic, IResultManager resultManager)
    {
        this.gameLogic = gameLogic;
        this.resultManager = resultManager;
    }

    public void Start()
    {

        while (playOn)
        {
            Console.WriteLine("Select game mode:");
            Console.WriteLine("1. Goal length 4");
            Console.WriteLine("2. Goal length 6");
            Console.WriteLine("0. Exit");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    gameLogic = GameLogicFactory.CreateGameLogic();
                    PlayGame();
                    break;
                case "2":
                    gameLogic = GameLogicFactory.CreateGameLogic6();
                    PlayGame();
                    break;
                case "0":
                    playOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        }

    }
    private void PlayGame()
    {
        gameLogic.PlayGame();
        ShowTopList();

        Console.WriteLine("Correct, it took " + gameLogic.TotalGuesses + " guesses\nContinue?");
        string answer = Console.ReadLine();
        if (answer != null && answer.Length > 0 && answer.Substring(0, 1) == "n")
        {
            playOn = false;
        }
    }

    private void ShowTopList()
    {
        List<PlayerData> results = resultManager.GetPlayerDataList();

        Console.WriteLine("Player   Games Average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine($"{p.Name,-9}{p.NGames,5:D}{p.Average(),9:F2}");
        }
    }

    static void Main(string[] args)
    {
        IGameLogic gameLogic = GameLogicFactory.CreateGameLogic();
        IResultManager resultManager = ResultManager.Instance;
        Program program = new Program(gameLogic, resultManager);
        program.Start();

    }
}
