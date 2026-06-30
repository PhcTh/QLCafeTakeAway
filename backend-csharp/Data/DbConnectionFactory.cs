using Microsoft.Data.SqlClient;

namespace backend_csharp.Data;

public sealed class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Missing DefaultConnection.");
    }

    public SqlConnection Create()
    {
        return new SqlConnection(_connectionString);
    }

    public SqlConnection CreateMasterConnection()
    {
        var builder = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "master"
        };

        return new SqlConnection(builder.ConnectionString);
    }
}
