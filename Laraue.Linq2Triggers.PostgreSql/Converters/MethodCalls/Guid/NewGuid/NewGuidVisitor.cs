using Laraue.Linq2Triggers.Converters.MethodCall.Guid.NewGuid;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.PostgreSql.Converters.MethodCalls.Guid.NewGuid;

/// <inheritdoc />
public class NewGuidVisitor : BaseNewGuidVisitor
{
    public NewGuidVisitor(IExpressionVisitorFactory visitorFactory)
        : base(visitorFactory)
    {
    }

    /// <inheritdoc />
    protected override string NewGuidSql => "gen_random_uuid()";
}