using Steam.Domain.Entidades;
using Steam.Domain.QueryResult;
using System.Collections.Generic;

namespace Steam.Domain.Interfaces.Repositories
{
    public interface IGamesRepository
    {
        long Inserir(Games games);
        void Alterar(Games games);
        void Excluir(long id);
        List<GamesQueryResult> Listar();
        GamesQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
