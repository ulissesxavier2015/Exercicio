namespace Questao2
{
    using Questao2.Business;
    class Program
    {
        public static void Main()
        {
            var goalCalculator = new GoalCalculatorBuilder()
                .WithYear(2013)
                .WithTeam("Paris Saint-Germain")
                .Build();

            var totalGoals = goalCalculator.GetTotalScoredGoals();

            Console.WriteLine($"Team Paris Saint-Germain scored {totalGoals} goals in 2013");

            goalCalculator = new GoalCalculatorBuilder()
                .WithYear(2014)
                .WithTeam("Chelsea")
                .Build();

            totalGoals = goalCalculator.GetTotalScoredGoals();

            Console.WriteLine($"Team Chelsea scored {totalGoals} goals in 2014");
        }
    }
}