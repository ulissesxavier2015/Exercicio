namespace Questao5.Application.Commands.Responses
{
    public class AccountMovementCommandResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object Movement { get; internal set; }
    }

}
