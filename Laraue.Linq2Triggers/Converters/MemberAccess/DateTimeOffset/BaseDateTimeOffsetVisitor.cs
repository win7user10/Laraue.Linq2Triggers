using System;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTimeOffset
{
    /// <summary>
    /// Base visitor for <see cref="System.Math"/> methods.
    /// </summary>
    public abstract class BaseDateTimeOffsetVisitor : BaseMemberAccessVisitor
    {
        /// <inheritdoc />
        protected override Type ReflectedType => typeof(System.DateTimeOffset);

        /// <inheritdoc />
        protected BaseDateTimeOffsetVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
