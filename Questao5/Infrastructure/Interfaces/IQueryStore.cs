namespace Questao5.Infrastructure.Interfaces
{
    public interface IQueryStore<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }

}
