﻿namespace MooGameCleanCode2023.Client;

public class Program
{
    private IGameLogic gameLogic;
    private ResultManager resultManager;

    public Program(IGameLogic gameLogic)
    {
        this.gameLogic = gameLogic;
        resultManager = ResultManager.Instance;
    }

    public void Start(IGameLogic gameLogic)
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
        Program program = new Program(gameLogic);
        program.Start(gameLogic);

    }
}