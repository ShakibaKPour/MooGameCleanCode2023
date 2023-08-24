using System;
using System.Collections.Generic;
using MooGameCleanCode2023.Interfaces;

namespace MooGameCleanCode2023.Logics
{
    public class GameLogic6 : BaseGameLogic
    {
        private const int goalLength = 6;

        public GameLogic6(IGoalGenerator goalGenerator) : base(goalGenerator)
        {
        }

        public int GoalLength => goalLength;
        public int TotalGuesses => totalGuesses;


        public void PlayGame()
        {
            goal = goalGenerator.GenerateGoal(goalLength);
            HandleGameFlow();
            NotifyGameResult(name, totalGuesses);
        }
    }
}

