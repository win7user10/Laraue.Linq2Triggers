﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Ceiling
{
    /// <summary>
    /// Visitor for <see cref="System.Math.Ceiling(decimal)"/> method.
    /// </summary>
    public abstract class BaseMathCeilingVisitor : BaseMathVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(System.Math.Ceiling);

        /// <inheritdoc />
        protected BaseMathCeilingVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }

        /// <summary>
        /// Ceil function name in SQL.
        /// </summary>
        protected abstract string SqlFunctionName { get; }

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var argument = expression.Arguments[0];
            
            var sqlBuilder = VisitorFactory.Visit(argument, visitedMembers);
            
            return SqlBuilder.FromString($"{SqlFunctionName}({sqlBuilder})");
        }
    }
}
