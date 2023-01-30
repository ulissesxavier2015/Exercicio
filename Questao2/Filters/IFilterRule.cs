namespace Questao2.Filters
{
    public interface IFilterRule
    {
        string Team { get; }
        int Year { get; }
        string GetFilterUrl();
    }
}