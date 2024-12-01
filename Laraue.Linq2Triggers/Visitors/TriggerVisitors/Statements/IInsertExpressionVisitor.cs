﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.Visitors.TriggerVisitors.Statements
{
    /// <summary>
    /// Generates SQL for insert SQL statement.
    /// </summary>
    public interface IInsertExpressionVisitor
    {
        /// <summary>
        /// Generates insert SQL for the passed <see cref="LambdaExpression"/> without "INSERT" keyword,
        /// e.g. (column1, column2) VALUES ("value1", "value2")
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="argumentTypes"></param>
        /// <param name="visitedMembers"></param>
        /// <returns></returns>
        SqlBuilder Visit(LambdaExpression expression, VisitedMembers visitedMembers);
    }
}