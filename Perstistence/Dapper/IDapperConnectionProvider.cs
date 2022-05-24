using System.Data;

namespace Perstistence.Dapper;

public interface IDapperConnectionProvider
{
    IDbConnection GetDbConnection();

}
