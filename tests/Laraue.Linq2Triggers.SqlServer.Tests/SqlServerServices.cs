using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.SqlServer.Extensions;
using Laraue.Linq2Triggers.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.SqlServer.Tests;

public class SqlServerServices
{
    public static IServiceCollection Services = new ServiceCollection()
        .AddSqlServerServices()
        .AddSingleton<IDbSchemaRetriever, FakeDbSchemaRetriever>();
    
    public static IServiceProvider ServiceProvider => Services.BuildServiceProvider();
}