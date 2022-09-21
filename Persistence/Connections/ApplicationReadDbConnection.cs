using System.Data;
using Dapper;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace Persistence.Connections;

public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
{

   public IDbConnection _connection;
  public ApplicationReadDbConnection(IConfiguration configuration)
  {
     _connection =  new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
  }    
   
    public void Dispose()
    {
        _connection.Dispose();
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return (await _connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await _connection.QuerySingleAsync<T>(sql, param, transaction);
        
    }
}
