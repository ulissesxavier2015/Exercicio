namespace Questao2.Filters
{
    public class FilterRule : IFilterRule
    {
        private const string BaseUrl = "https://jsonmock.hackerrank.com/api/football_matches";
        public string Team { get; private set; }
        public int Year { get; private set; }

        public FilterRule(string team, int year)
        {
            Team = team;
            Year = year;
        }

        public string GetFilterUrl()
        {
            return $"{BaseUrl}?year={Year}&team1={Team}";
        }
    }
}