using System.Data;
using Dapper;
using Questao5.Application.Commands.Request;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Interfaces;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class AccountBalanceQueryStore : IQueryStore<AccountBalanceQueryRequest, AccountBalanceQueryResponse>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AccountBalanceQueryStore(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<AccountBalanceQueryResponse> Execute(AccountBalanceQueryRequest request)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                var balance = await connection.ExecuteScalarAsync<decimal>(
                    "SELECT SUM(valor) FROM movimento WHERE idcontacorrente = @AccountId",
                    new { request.AccountId });

                return new AccountBalanceQueryResponse { Balance = balance };
            }
        }
    }
}
