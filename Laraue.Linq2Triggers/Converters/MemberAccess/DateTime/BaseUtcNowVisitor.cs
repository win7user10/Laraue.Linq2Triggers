using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTime
{
    /// <summary>
    /// Visitor for <see cref="System.DateTime.UtcNow"/>,
    /// </summary>
    public abstract class BaseUtcNowVisitor : BaseDateTimeVisitor
    {
        /// <inheritdoc />
        protected override string PropertyName => nameof(System.DateTime.UtcNow);

        /// <inheritdoc />
        protected BaseUtcNowVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
