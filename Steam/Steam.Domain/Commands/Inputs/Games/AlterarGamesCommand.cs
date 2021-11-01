using Flunt.Notifications;
using Steam.Infra.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Steam.Domain.Commands.Inputs
{
    public class AlterarGamesCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Developer { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

                if (string.IsNullOrWhiteSpace(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Developer))
                    AddNotification("Developer", "Developer é um campo obrigatório");
                else if (Developer.Length > 50)
                    AddNotification("Developer", "Nome maior que 50 caracteres");

                return Valid;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
