
using Newtonsoft.Json;
using Dapper;
using Questao5.Application.Commands.Request;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Interfaces;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class AccountMovementCommandStore : ICommandStore<AccountMovementCommandRequest, AccountMovementCommandResponse>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AccountMovementCommandStore(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<AccountMovementCommandResponse> Execute(AccountMovementCommandRequest request)
        {
            try
            {
                var connection = _connectionFactory.GetConnection();
                var idempotencyKey = Guid.NewGuid().ToString();

                //verifica se existe uma chave de idempotência
                var existingMovement = await connection
                    .QueryFirstOrDefaultAsync<AccountMovement>(
                        "SELECT * FROM idempotencia WHERE chave_idempotencia = @idempotencyKey",
                        new { idempotencyKey });

                if (existingMovement != null)
                {
                    return new AccountMovementCommandResponse { Movement = existingMovement };
                }

                var movement = new AccountMovement
                {
                    Id = Guid.NewGuid(),
                    AccountId = request.AccountId,
                    Date = DateTime.Now,
                    Type = request.Type,
                    Value = request.Value
                };

                var rowsAffected = await connection.ExecuteAsync(
                    "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@Id, @AccountId, @Date, @Type, @Value)",
                    movement);

                if (rowsAffected > 0)
                {
                    //grava a chave de idempotência
                    await connection.ExecuteAsync(
                        "INSERT INTO idempotencia (chave_idempotencia, requisicao) VALUES (@idempotencyKey, @requestJson)",
                        new { idempotencyKey, requestJson = JsonConvert.SerializeObject(request) });
                }

                return new AccountMovementCommandResponse { Movement = movement };
            }
            catch (Exception ex)
            {
                return new AccountMovementCommandResponse { ErrorMessage = ex.Message };
            }
        }
    }


}
