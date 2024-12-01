﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.Extensions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Concat
{
    /// <summary>
    /// Visitor for <see cref="System.String.Concat(string, string)"/> method.
    /// </summary>
    public abstract class BaseStringConcatVisitor : BaseStringVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(string.Concat);
        
        /// <inheritdoc />
        protected BaseStringConcatVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var argumentsSql = VisitorFactory.VisitArguments(expression, visitedMembers);
            
            return Visit(argumentsSql);
        }

        /// <summary>
        /// Build concat expression from passed arguments.
        /// </summary>
        /// <param name="argumentsSql">Concat arguments sql.</param>
        /// <returns></returns>
        protected abstract SqlBuilder Visit(SqlBuilder[] argumentsSql);
    }
}