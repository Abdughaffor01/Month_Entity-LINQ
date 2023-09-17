using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure;
public class DataContext
{
    private readonly IConfiguration _configuration;
    public DataContext(IConfiguration configuration) => _configuration = configuration;
    public IDbConnection CreateConnection() => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
}
