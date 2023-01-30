namespace Questao2.Filters
{
    abstract class FilterRuleBase : IFilterRule
    {
        public virtual string Team { get; }
        public virtual int Year { get; }

        public virtual string GetFilterUrl()
        {
            return $"https://jsonmock.hackerrank.com/api/football_matches?year={Year}&team1={Team}";
        }
    }
}