﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Guid.NewGuid;

/// <summary>
/// Visitor for <see cref="System.Guid.NewGuid"/> method.
/// </summary>
public abstract class BaseNewGuidVisitor : BaseGuidVisitor
{
    /// <inheritdoc />
    protected override string MethodName => nameof(System.Guid.NewGuid);

    /// <inheritdoc />
    protected BaseNewGuidVisitor(IExpressionVisitorFactory visitorFactory) 
        : base(visitorFactory)
    {
    }

    /// <summary>
    /// Ceil function name in SQL.
    /// </summary>
    protected abstract string NewGuidSql { get; }

    /// <inheritdoc />
    public override SqlBuilder Visit(
        MethodCallExpression expression,
        VisitedMembers visitedMembers)
    {
        return SqlBuilder.FromString(NewGuidSql);
    }
}