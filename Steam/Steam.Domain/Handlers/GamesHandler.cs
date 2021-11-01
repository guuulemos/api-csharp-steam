using Flunt.Notifications;
using Steam.Domain.Commands.Inputs;
using Steam.Domain.Commands.Outputs;
using Steam.Domain.Entidades;
using Steam.Domain.Interfaces.Repositories;
using Steam.Infra.Interfaces.Commands;
using System;
using System.Net;

namespace Steam.Domain.Interfaces.Handlers
{
    public class GamesHandler : ICommandHandler<InserirGamesCommand>, ICommandHandler<AlterarGamesCommand>, ICommandHandler<ExcluirGameCommand>, ICommandHandler<ObterGamesCommand>
    {

        private readonly IGamesRepository _repository;

        public GamesHandler(IGamesRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(InserirGamesCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new GamesCommandResult(false, "Por favor, corrija as informações abaixo", command.Notifications);

                long id = 0;
                string nome = command.Nome;
                string developer = command.Developer;

                Games games = new Games(id, nome, developer);

                id = _repository.Inserir(games);

                return new GamesCommandResult(true, "Game adicionado com sucesso!", new
                {
                    Nome = games.Nome,
                    Developer = games.Developer
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(AlterarGamesCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new GamesCommandResult(false, "Por favor, corrija as informações abaixo", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new GamesCommandResult(false, "Id", new Notification("Id", "Este id não está cadastrado!"));

                long id = command.Id;
                string nome = command.Nome;
                string developer = command.Developer;

                Games games = new Games(id, nome, developer);

                _repository.Alterar(games);

                return new GamesCommandResult(true, "Game alterado com sucesso!", new
                {
                    Id = games.Id,
                    Nome = games.Nome,
                    Developer = games.Developer
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(ExcluirGameCommand command)
        {
            if (!command.ValidarCommand())
                return new GamesCommandResult(false, "Por favor, corrija as informações abaixo", command.Notifications);

            if (!_repository.CheckId(command.Id))
                return new GamesCommandResult(false, "Id", new Notification("Id", "Este id não está cadastrado!"));

            _repository.Excluir(command.Id);

            return new GamesCommandResult(true, "Game excluído com sucesso!", new { Id = command.Id});
        }

        public ICommandResult Handle(ObterGamesCommand command)
        {
            if (!command.ValidarCommand())
                return new GamesCommandResult(false, "Por favor, corrija as informações abaixo", command.Notifications);

            if (!_repository.CheckId(command.Id))
                return new GamesCommandResult(false, "Id", new Notification("Id", "Este id não está cadastrado!"));

            long id = command.Id;

            _repository.Obter(id);

            return new GamesCommandResult(true, "Game encontrado com sucesso!", new
            {
                Id = command.Id,
            });
        }
    }
}
