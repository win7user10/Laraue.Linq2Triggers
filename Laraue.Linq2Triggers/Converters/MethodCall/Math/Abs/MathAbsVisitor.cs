﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Abs
{
    /// <summary>
    /// Visitor for all Abs methods, such as <see cref="System.Math.Abs(decimal)"/>,
    /// <see cref="System.Math.Abs(sbyte)"/> etc.
    /// </summary>
    public class MathAbsVisitor : BaseMathVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(System.Math.Abs);

        /// <inheritdoc />
        public MathAbsVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(MethodCallExpression expression, VisitedMembers visitedMembers)
        {
            var argument = expression.Arguments[0];
            var sqlBuilder = VisitorFactory.Visit(argument, visitedMembers);
            return SqlBuilder.FromString($"ABS({sqlBuilder})");
        }
    }
}
