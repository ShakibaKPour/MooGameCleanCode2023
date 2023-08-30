using System;
using System.Collections.Generic;
using MooGameCleanCode2023.Interfaces;

namespace MooGameCleanCode2023.Logics
{
    public class GameLogic6 : BaseGameLogic, IGameLogic
    {
        private const int goalLength = 6;

        public GameLogic6(IGoalGenerator goalGenerator, IGameResultObserver gameResultObserver) : base(goalGenerator, gameResultObserver, 6)
        {
        }

        public int GoalLength => goalLength;
        public int TotalGuesses => totalGuesses;


        public void PlayGame()
        {
            goal = goalGenerator.GenerateGoal(GoalLength);
            HandleGameFlow();
            gameResultObserver.NotifyGameResult(name, totalGuesses);
        }
    }
}

