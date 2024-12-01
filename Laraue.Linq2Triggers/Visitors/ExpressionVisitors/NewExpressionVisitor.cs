﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Laraue.Linq2Triggers.Converters.NewExpression;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.Visitors.ExpressionVisitors
{
    /// <inheritdoc />
    public class NewExpressionVisitor : BaseExpressionVisitor<NewExpression>
    {
        private readonly INewExpressionVisitor[] _visitors;

        /// <inheritdoc />
        public NewExpressionVisitor(IEnumerable<INewExpressionVisitor> newExpressionVisitors)
        {
            _visitors = newExpressionVisitors.Reverse().ToArray();
        }
        
        /// <inheritdoc />
        public override SqlBuilder Visit(NewExpression expression, VisitedMembers visitedMembers)
        {
            var visitor = GetVisitor(expression);
        
            return visitor.Visit(expression, visitedMembers);
        }
    
        private INewExpressionVisitor GetVisitor(NewExpression expression)
        {
            foreach (var converter in _visitors)
            {
                if (converter.IsApplicable(expression))
                {
                    return converter;
                }
            }
        
            throw new NotSupportedException($"new {expression.Type}() translation is not supported");
        }
    }
}