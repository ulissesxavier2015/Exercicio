using Questao5.Domain.Entities;
namespace Questao5.Application.Commands.Request

{
    public class AccountMovementCommandRequest
    {
        public Guid AccountId { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal Value { get; set; }
        public MovementType Type { get; set; }
    }
}