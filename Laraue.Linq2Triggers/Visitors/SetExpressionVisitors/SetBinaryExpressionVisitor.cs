﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Visitors.SetExpressionVisitors
{
    public class SetBinaryExpressionVisitor : IMemberInfoVisitor<BinaryExpression>
    {
        private readonly IExpressionVisitorFactory _factory;

        public SetBinaryExpressionVisitor(IExpressionVisitorFactory factory)
        {
            _factory = factory;
        }
    
        public Dictionary<MemberInfo, SqlBuilder> Visit(BinaryExpression expression, VisitedMembers visitedMembers)
        {
            var sqlBuilder = _factory.Visit(expression, visitedMembers);

            var member = expression.Left as MemberExpression;
            member ??= expression.Right as MemberExpression;

            if (member is null)
            {
                throw new NotSupportedException();
            }
        
            return new Dictionary<MemberInfo, SqlBuilder>()
            {
                [member.Member] = sqlBuilder 
            };
        }
    }
}