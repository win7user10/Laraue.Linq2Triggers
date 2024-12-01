﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Contains
{
    /// <summary>
    /// Visitor for <see cref="System.String.Contains(string)"/> method.
    /// </summary>
    public abstract class BaseStringContainsVisitor : BaseStringVisitor
    {
        protected BaseStringContainsVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override string MethodName => nameof(string.Contains);

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var expressionToFindSql = VisitorFactory.VisitArguments(expression, visitedMembers)[0];
            var expressionToSearchSql = VisitorFactory.Visit(expression.Object, visitedMembers);
            
            return SqlBuilder.FromString(CombineSql(expressionToSearchSql, expressionToFindSql));
        }

        /// <summary>
        /// Build contains SQL expression.
        /// </summary>
        /// <param name="expressionToSearchSql">The search string SQL.</param>
        /// <param name="expressionToFindSql">Where to search the string SQL.</param>
        /// <returns></returns>
        protected abstract string CombineSql(string expressionToSearchSql, string expressionToFindSql);
    }
}