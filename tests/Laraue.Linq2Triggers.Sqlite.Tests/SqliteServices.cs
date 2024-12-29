using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Sqlite.Extensions;
using Laraue.Linq2Triggers.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.Sqlite.Tests;

public class SqliteServices
{
    public static IServiceCollection Services = new ServiceCollection()
        .AddSqliteServices()
        .AddSingleton<IDbSchemaRetriever, FakeDbSchemaRetriever>();
    
    public static IServiceProvider ServiceProvider => Services.BuildServiceProvider();
}