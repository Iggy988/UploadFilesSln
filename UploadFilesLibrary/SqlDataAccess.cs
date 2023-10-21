using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace UploadFilesLibrary;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<T>> LoadData<T>(string stroredProc, string connectionName, object? parameters)
    {
        string connectionString = _config.GetConnectionString(connectionName) ??
            throw new Exception($"Missing connection string at {connectionName}");

        using var connection = new SqlConnection(connectionString);

        var rows = await connection.QueryAsync<T>(stroredProc, parameters, commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task SaveData(string stroredProc, string connectionName, object parameters)
    {
        string connectionString = _config.GetConnectionString(connectionName) ??
            throw new Exception($"Missing connection string at {connectionName}");

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(stroredProc, parameters, commandType: CommandType.StoredProcedure);
    }
}
