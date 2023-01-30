namespace Questao5.Domain.Entities
{
    public class AccountMovement
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public MovementType Type { get; set; }
        public DateTime Date { get; set; }
    }
}