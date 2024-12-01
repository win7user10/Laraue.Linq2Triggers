using System;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.NewExpression;

/// <inheritdoc />
public abstract class BaseNewDateTimeExpressionVisitor : BaseNewExpressionVisitor
{
    /// <inheritdoc />
    public BaseNewDateTimeExpressionVisitor(IExpressionVisitorFactory visitorFactory)
        : base(visitorFactory)
    {
    }

    /// <inheritdoc />
    protected override Type ReflectedType => typeof(DateTime);
}