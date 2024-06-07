using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.Data;

public class DataContextDapper
{
    private readonly IConfiguration _config;
    
    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }

    private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    
    public int Execute(string sql, object? param = null)
    {
        using var conn = Connection;
        return conn.Execute(sql, param);
    }
    
    public T QuerySingle<T>(string sql, object? param = null)
    {
        using var conn = Connection;
        return conn.QuerySingle<T>(sql, param);
    }
    
    public IEnumerable<T> Query<T>(string sql, object? param = null)
    {
        using var conn = Connection;
        return conn.Query<T>(sql, param);
    }
}