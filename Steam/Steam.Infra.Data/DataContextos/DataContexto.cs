using Steam.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Steam.Infra.Data.DataContexts
{
    public class DataContexto : IDisposable
    {
        public SqlConnection sqlConexao { get; set; }

        public DataContexto(AppSettings appSettings)
        {
            try
            {
                sqlConexao = new SqlConnection(appSettings.ConnectionString);
                sqlConexao.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (sqlConexao.State != ConnectionState.Closed)
                    sqlConexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
