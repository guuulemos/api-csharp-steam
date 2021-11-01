using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Steam.Domain.Commands.Inputs;
using Steam.Domain.Interfaces.Handlers;
using Steam.Domain.Interfaces.Repositories;
using Steam.Domain.QueryResult;
using Steam.Infra.Interfaces.Commands;

namespace SteamApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _repository;
        private readonly GamesHandler _handler;

        public GamesController(IGamesRepository repository, GamesHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("api/games")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Inserir([FromBody] InserirGamesCommand command)
        {
            ICommandResult result = _handler.Handle(command);

            return Created("Game", result);
        }

        [HttpGet]
        [Route("api/games/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesQueryResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ICommandResult))]
        public IActionResult Obter(long id)
        {
            ObterGamesCommand command = new ObterGamesCommand();

            command.Id = id;

            ICommandResult result = _handler.Handle(command);

            if (result.Sucess == false)
                return NotFound(result);

            return Ok(_repository.Obter(id));
        }

        [HttpGet]
        [Route("api/games")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        [HttpPut]
        [Route("api/games/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesQueryResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ICommandResult))]
        public IActionResult Alterar(long id, [FromBody] AlterarGamesCommand command)
        {
            command.Id = id;

            ICommandResult result = _handler.Handle(command);

            if (!result.Sucess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ICommandResult))]
        [Route("api/games/{id}")]
        public IActionResult Excluir(long id)
        {
            ExcluirGameCommand command = new ExcluirGameCommand();

            command.Id = id;

            ICommandResult result = _handler.Handle(command);

            if (result.Sucess == false)
                return NotFound(result);

            return Ok(result);
        }
    }
}
