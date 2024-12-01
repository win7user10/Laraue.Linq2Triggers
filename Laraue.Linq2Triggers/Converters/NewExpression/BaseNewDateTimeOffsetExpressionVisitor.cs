using System;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.NewExpression;

/// <inheritdoc />
public abstract class BaseNewDateTimeOffsetExpressionVisitor : BaseNewExpressionVisitor
{
    /// <inheritdoc />
    public BaseNewDateTimeOffsetExpressionVisitor(IExpressionVisitorFactory visitorFactory)
        : base(visitorFactory)
    {
    }

    /// <inheritdoc />
    protected override Type ReflectedType => typeof(DateTimeOffset);
}