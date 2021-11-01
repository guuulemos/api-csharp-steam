using Steam.Infra.Interfaces.Commands;

namespace Steam.Domain.Commands.Outputs
{
    public class GamesCommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public GamesCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}
