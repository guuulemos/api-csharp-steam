using Flunt.Notifications;
using Steam.Infra.Interfaces.Commands;
using System;
using System.Text.Json.Serialization;

namespace Steam.Domain.Commands.Inputs
{
    public class ObterGamesCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

                return Valid;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
