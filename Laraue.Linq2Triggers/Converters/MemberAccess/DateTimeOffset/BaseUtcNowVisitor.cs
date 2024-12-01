using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTimeOffset
{
    /// <summary>
    /// Visitor for <see cref="System.DateTime.UtcNow"/>,
    /// </summary>
    public abstract class BaseUtcNowVisitor : BaseDateTimeOffsetVisitor
    {
        /// <inheritdoc />
        protected override string PropertyName => nameof(System.DateTimeOffset.UtcNow);

        /// <inheritdoc />
        protected BaseUtcNowVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
