using MooGameCleanCode2023.Interfaces;

namespace MooGameCleanCode2023.Logics
{

    public class RandomGoalGenerator : IGoalGenerator
    {
        private const int GoalLength = 4;
        private readonly Random randomGenerator = new Random();
        public string GenerateGoal()
        {
            string goal = "";
            HashSet<int> digits = new HashSet<int>();

            while (digits.Count < GoalLength)
            {
                int random = randomGenerator.Next(10);
                digits.Add(random);
            }

            foreach (int digit in digits)
            {
                goal += digit.ToString();
            }

            return goal;
        }
    }
}