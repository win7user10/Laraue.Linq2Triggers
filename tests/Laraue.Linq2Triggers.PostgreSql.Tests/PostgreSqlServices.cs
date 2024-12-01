using Laraue.Linq2Triggers.PostgreSql.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.PostgreSql.Tests;

public class PostgreSqlServices
{
    public static IServiceCollection Services = new ServiceCollection()
        .AddPostgreSqlTriggerServices()
        .AddSingleton<IDbSchemaRetriever, FakeDbSchemaRetriever>();
    
    public static IServiceProvider ServiceProvider => Services.BuildServiceProvider();
}