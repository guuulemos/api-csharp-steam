using Flunt.Notifications;
using Steam.Infra.Interfaces.Commands;
using System;

namespace Steam.Domain.Commands.Inputs
{
    public class InserirGamesCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Developer { get; set; }

        public bool ValidarCommand()
        {
            try
            {
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
