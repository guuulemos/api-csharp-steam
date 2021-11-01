using Steam.Infra.Interfaces.Commands;

namespace Steam.Domain.Commands.Outputs
{
    public class LoginCommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public LoginCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}
