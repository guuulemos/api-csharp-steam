using Flunt.Notifications;
using Steam.Infra.Interfaces.Commands;
using System;

namespace Steam.Domain.Entidades
{
    public class InserirLoginCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Login))
                    AddNotification("Login", "Login é um campo obrigatório");

                if (string.IsNullOrWhiteSpace(Password))
                    AddNotification("Password", "Password é um campo obrigatório");

                return Valid;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
