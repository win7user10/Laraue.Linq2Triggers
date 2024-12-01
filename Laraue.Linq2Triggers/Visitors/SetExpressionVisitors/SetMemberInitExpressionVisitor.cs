﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Visitors.SetExpressionVisitors
{
    /// <inheritdoc />
    public class SetMemberInitExpressionVisitor : IMemberInfoVisitor<MemberInitExpression>
    {
        private readonly IExpressionVisitorFactory _factory;
        private readonly VisitingInfo _visitingInfo;
    
        /// <summary>
        /// Initializes a new instance of <see cref="SetMemberInitExpressionVisitor"/>.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="visitingInfo"></param>
        public SetMemberInitExpressionVisitor(IExpressionVisitorFactory factory, VisitingInfo visitingInfo)
        {
            _factory = factory;
            _visitingInfo = visitingInfo;
        }

        /// <inheritdoc />
        public Dictionary<MemberInfo, SqlBuilder> Visit(MemberInitExpression expression, VisitedMembers visitedMembers)
        {
            return expression.Bindings.Select(memberBinding =>
            {
                var memberAssignmentExpression = (MemberAssignment)memberBinding;
            
                var sqlExtendedResult = _visitingInfo.ExecuteWithChangingMember(
                    memberAssignmentExpression.Member,
                    () => _factory.Visit(memberAssignmentExpression.Expression, visitedMembers));
            
                return (memberAssignmentExpression.Member, sqlExtendedResult);
            }).ToDictionary(x => x.Member, x => x.sqlExtendedResult);
        }
    }
}