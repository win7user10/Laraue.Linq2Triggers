﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.Converters.MethodCall
{
    /// <summary>
    /// Converter for <see cref="MethodCallExpression"/>.
    /// </summary>
    public interface IMethodCallVisitor
    {
        /// <summary>
        /// Should this converter be used to translate a <see cref="MethodCallExpression"/> to a SQL.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsApplicable(MethodCallExpression expression);

        /// <summary>
        /// Build a SQL for passed <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">Expression to parse.</param>
        /// <param name="visitedMembers">Visited members.</param>
        /// <returns></returns>
        SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers);
    }
}