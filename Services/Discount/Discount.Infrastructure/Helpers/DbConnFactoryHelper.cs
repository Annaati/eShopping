using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Helpers
{
    public class DbConnFactoryHelper
    {
        private readonly string _connString;
        private readonly IConfiguration _config;
        public DbConnFactoryHelper(IConfiguration configu)
        {
            _config = configu;
            _connString = _config.GetConnectionString("PostgresConnStr") ??
                                            throw new ApplicationException("Couldn't establish a connection to the db Server"); ;
        }

        public NpgsqlConnection Create()
        {
            return new NpgsqlConnection(_connString);
        }
    }
}
