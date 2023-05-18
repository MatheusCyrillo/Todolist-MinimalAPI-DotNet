using Dapper;
using Npgsql;
using System.Data;

namespace todolist.Data.Postgresql
{
    public class PostgresqlDataAccess : IPostgresqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public PostgresqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetData<T, U>(string script, U parameters, string connectionId)
        {
            using (var con = new NpgsqlConnection(_configuration.GetConnectionString(connectionId)))
            {
                var result = await con.QueryAsync<T>(script, parameters);
                return result;
            }
        }

        public async Task SetData<U>(string script, U parameters, string connectionId)
        {
            using (var con = new NpgsqlConnection(_configuration.GetConnectionString(connectionId)))
            {
                 await con.ExecuteAsync(script, parameters);
            }
        }
    }
}
