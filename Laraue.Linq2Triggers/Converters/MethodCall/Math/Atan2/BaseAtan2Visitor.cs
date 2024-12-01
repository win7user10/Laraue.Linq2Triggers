﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Atan2
{
    /// <summary>
    /// Visitor for <see cref="System.Math.Atan2"/> method.
    /// </summary>
    public abstract class BaseAtan2Visitor : BaseMathVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(System.Math.Atan2);
        
        /// <inheritdoc />
        protected BaseAtan2Visitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }

        /// <summary>
        /// The function used in SQL to generate Atan2 expression.
        /// </summary>
        protected abstract string SqlFunctionName { get; }

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var argumentsSql = VisitorFactory.VisitArguments(expression, visitedMembers);
            
            return SqlBuilder.FromString($"{SqlFunctionName}({argumentsSql[0]}, {argumentsSql[1]})");
        }
    }
}