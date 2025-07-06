using Microsoft.Data.SqlClient;
using System.Data;

namespace ConcessionnaireAPI.Data
{
    public class ApiDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ApiConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
