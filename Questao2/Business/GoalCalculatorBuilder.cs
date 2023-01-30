namespace Questao2.Business
{
    using Questao2.Filters;

    class GoalCalculatorBuilder
    {
        public string Team { get; private set; }
        public int Year { get; private set; }

        public GoalCalculatorBuilder WithTeam(string team)
        {
            Team = team;
            return this;
        }

        public GoalCalculatorBuilder WithYear(int year)
        {
            Year = year;
            return this;
        }

        public GoalCalculator Build()
        {
            return new GoalCalculator(new FilterRule(Team, Year));
        }
    }
}