using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Tests.DataAccess;
using Laraue.Linq2Triggers.TriggerBuilders;
using Laraue.Linq2Triggers.TriggerBuilders.Actions;
using Laraue.Linq2Triggers.TriggerBuilders.TableRefs;
using Laraue.Linq2Triggers.Visitors.TriggerVisitors;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Linq2Triggers.Tests.Tests;

public abstract class BaseUnitTests
{
    private readonly IServiceProvider _serviceProvider;

    protected BaseUnitTests(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected void AssertSql(Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> expression, string exceptedSql)
    {
        var sql = GetInsertSql(expression);
        
        Assert.Equal(exceptedSql, sql);
    }

    protected string GetInsertSql(Expression<Func<NewTableRef<SourceEntity>, DestinationEntity>> expression)
    {
        var trigger = new InsertTrigger<SourceEntity>(TriggerTime.After)
            .Action(action => action
                .Insert(expression));

        return GetSingleActionSql(trigger);
    }
    
    protected string GetSingleActionSql<TTriggerEntity, TTriggerEntityRefs>(Trigger<TTriggerEntity, TTriggerEntityRefs> trigger)
        where TTriggerEntity : class
        where TTriggerEntityRefs : ITableRef<TTriggerEntity>
    {
        var visitorFactory = _serviceProvider.GetRequiredService<ITriggerActionVisitorFactory>();
        
        return visitorFactory.Visit(trigger.Actions.Single().ActionExpressions.Single(), new VisitedMembers());
    }
}