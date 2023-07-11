using MooGameCleanCode2023.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameCleanCode2023.Logics
{
    public class GameLogic : IGameLogic, IGameResultObserver
    {
        private const int GoalLength = 4;
        private int totalGuesses;
        private List<IGameResultObserver> observers = new List<IGameResultObserver>();
        private readonly IGoalGenerator goalGenerator;
        private ResultManager resultManager;
        public int TotalGuesses => totalGuesses;

        public GameLogic(IGoalGenerator goalGenerator)
        {
                this.goalGenerator = goalGenerator;
                resultManager = ResultManager.Instance;
        }
        public void RegisterObserver(IGameResultObserver observer)
        {
            observers.Add(observer);
        }
        public void PlayGame()
        {
            string name = GetPlayerName();
            string goal = goalGenerator.GenerateGoal();

            Console.WriteLine("New game:");
            Console.WriteLine("For practice, the number is: " + goal);
            string guess = GetPlayerGuess();

            totalGuesses = 1;
            string bbcc = CheckBC(goal, guess);
            Console.WriteLine(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                totalGuesses++;
                guess = GetPlayerGuess();
                Console.WriteLine(guess);
                bbcc = CheckBC(goal, guess);
                Console.WriteLine(bbcc + "\n");
            }

            NotifyGameResult(name, totalGuesses);
        }

        private string GetPlayerName()
        {
            Console.WriteLine("Enter your user name:");
            return Console.ReadLine();
        }

        private string GetPlayerGuess()
        {
            Console.WriteLine("Enter your guess:");
            return Console.ReadLine();
        }

        private string CheckBC(string goal, string guess)
        {
            int bulls = 0, cows = 0;
            guess = guess.PadRight(GoalLength);


            for (int i = 0; i < GoalLength; i++)
            {
                for (int j = 0; j < GoalLength; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
        public void NotifyGameResult(string playerName, int guesses)
        {
            resultManager.SaveGameResult(playerName, guesses);
        }

        

        
    }
}
