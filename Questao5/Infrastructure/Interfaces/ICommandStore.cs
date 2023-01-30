namespace Questao5.Infrastructure.Interfaces
{
    public interface ICommandStore<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }

}
