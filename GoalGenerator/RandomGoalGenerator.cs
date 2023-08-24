namespace MooGameCleanCode2023.GoalGenerator
{

    public class RandomGoalGenerator : IGoalGenerator
    {
        private readonly Random randomGenerator = new Random();
        public string GenerateGoal(int goalLength)
        {
            string goal = "";
            HashSet<int> digits = new HashSet<int>();

            while (digits.Count < goalLength)
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