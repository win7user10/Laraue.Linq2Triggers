using Laraue.Linq2Triggers.MySql.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.MySql.Tests;

public class MySqlServices
{
    public static IServiceCollection Services = new ServiceCollection()
        .AddMySqlTriggerServices()
        .AddSingleton<IDbSchemaRetriever, FakeDbSchemaRetriever>();
    
    public static IServiceProvider ServiceProvider => Services.BuildServiceProvider();
}