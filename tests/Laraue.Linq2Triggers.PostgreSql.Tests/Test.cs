using Laraue.Linq2Triggers.PostgreSql.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.TriggerBuilders;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.PostgreSql.Tests;

public class Test
{
    [Fact]
    public void Test1()
    {
        var trigger = new UpdateTrigger<TestEntity>(TriggerTime.After)
            .Action(action => action
                .Insert(tableRefs
                    => new DestinationEntity
                    {
                        IntValue = tableRefs.New.IntValue + tableRefs.Old.IntValue
                    }));

        var services = new ServiceCollection()
            .AddPostgreSqlTriggerServices()
            .AddSingleton<IDbSchemaRetriever, FakeDbSchemaRetriever>()
            .BuildServiceProvider();
        
        var visitor = services.GetRequiredService<ITriggerVisitor>();

        var sql = visitor.GenerateCreateTriggerSql(trigger);
    }
}