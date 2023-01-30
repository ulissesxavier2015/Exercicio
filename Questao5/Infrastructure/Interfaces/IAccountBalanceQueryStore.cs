using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;

namespace Questao5.Infrastructure.Interfaces
{
    public interface IAccountBalanceQueryStore : IQueryStore<AccountBalanceQueryRequest, AccountBalanceQueryResponse>
    {
    }
}

