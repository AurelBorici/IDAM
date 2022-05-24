using System.Data;
using System.Data.SqlClient;

namespace Perstistence.Dapper;

public class DapperConnectionProvider : IDapperConnectionProvider
{
    private readonly string _connectionString;

    public DapperConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetDbConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
