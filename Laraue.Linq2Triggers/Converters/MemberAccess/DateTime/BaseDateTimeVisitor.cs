using System;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTime
{
    /// <summary>
    /// Base visitor for <see cref="System.Math"/> methods.
    /// </summary>
    public abstract class BaseDateTimeVisitor : BaseMemberAccessVisitor
    {
        /// <inheritdoc />
        protected override Type ReflectedType => typeof(System.DateTime);

        /// <inheritdoc />
        protected BaseDateTimeVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
