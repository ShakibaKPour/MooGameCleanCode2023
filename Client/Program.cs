namespace MooGameCleanCode2023.Client;

public class Program
{
    private readonly IGameLogic gameLogic;
    private readonly IResultManager resultManager;

    public Program(IGameLogic gameLogic, IResultManager resultManager)
    {
        this.gameLogic = gameLogic;
        this.resultManager = resultManager;
    }

    public void Start()
    {
        bool playOn = true;

        while (playOn)
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
