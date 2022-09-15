using Dapper;
using Domain.Interfaces;
using System.Data;

namespace Persistence.Connections;

public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
{
    private readonly IApplicationDbContext _dbContext;

    public ApplicationWriteDbConnection(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Connection.ExecuteAsync(sql, param, transaction);
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return (await _dbContext.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Connection.QuerySingleAsync<T>(sql, param, transaction);
    }
}
