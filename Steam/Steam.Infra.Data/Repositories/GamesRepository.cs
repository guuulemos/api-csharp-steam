using Dapper;
using Steam.Domain.Entidades;
using Steam.Domain.Interfaces.Repositories;
using Steam.Domain.QueryResult;
using Steam.Infra.Data.DataContexts;
using Steam.Infra.Data.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Steam.Infra.Data.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContexto _dataContext;

        public GamesRepository(DataContexto dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Games games)
        {
            try
            {
                _parameters.Add("Nome", games.Nome, DbType.String);
                _parameters.Add("Developer", games.Developer, DbType.String);

                return _dataContext.sqlConexao.ExecuteScalar<long>(GamesQueries.Inserir, _parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Alterar(Games games)
        {
            try
            {
                _parameters.Add("Id", games.Id, DbType.Int64);
                _parameters.Add("Nome", games.Nome, DbType.String);
                _parameters.Add("Developer", games.Developer, DbType.String);

                _dataContext.sqlConexao.Execute(GamesQueries.Alterar, _parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GamesQueryResult> Listar()
        {
            try
            {
                return _dataContext.sqlConexao.Query<GamesQueryResult>(GamesQueries.Listar).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GamesQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.sqlConexao.Query<GamesQueryResult>(GamesQueries.Obter, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                _dataContext.sqlConexao.Execute(GamesQueries.Excluir, _parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContext.sqlConexao.Query<bool>(GamesQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
