﻿using System.Linq.Expressions;
using Laraue.Linq2Triggers.Converters.MemberAccess.DateTime;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.SqlServer.Converters.MemberAccess.DateTime
{
    /// <inheritdoc />
    public class UtcNowVisitor : BaseUtcNowVisitor
    {
        /// <inheritdoc />
        public UtcNowVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(MemberExpression expression)
        {
            return SqlBuilder.FromString("SYSUTCDATETIME()");
        }
    }
}
