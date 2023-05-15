using System.Data.SqlClient;

namespace ALMIS.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=(local); Database=ALMIS; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
