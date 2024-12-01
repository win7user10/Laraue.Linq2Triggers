﻿using System.Collections.Generic;
using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Trim
{
    /// <summary>
    /// Visitor for <see cref="System.String.Trim()"/> method.
    /// </summary>
    public abstract class BaseStringTrimVisitor : BaseStringVisitor
    {
        /// <summary>
        /// Sequence of SQL functions which should be applied to execute string trim.
        /// </summary>
        protected abstract IEnumerable<string> SqlTrimFunctionsNamesToApply { get; }
        
        /// <inheritdoc />
        protected override string MethodName => nameof(string.Trim);

        /// <inheritdoc />
        protected BaseStringTrimVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var expressionSqlBuilder = VisitorFactory.Visit(expression.Object, visitedMembers);
            
            var sqlBuilder = new SqlBuilder();

            foreach (var trimFunctionName in SqlTrimFunctionsNamesToApply)
            {
                sqlBuilder.Append(trimFunctionName).Append('(');
            }

            sqlBuilder.Append(expressionSqlBuilder);

            foreach (var _ in SqlTrimFunctionsNamesToApply)
            {
                sqlBuilder.Append(')');
            }

            return sqlBuilder;
        }
    }
}