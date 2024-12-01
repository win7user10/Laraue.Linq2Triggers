using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTimeOffset
{
    /// <summary>
    /// Visitor for <see cref="System.DateTime.Now"/>.
    /// </summary>
    public abstract class BaseNowVisitor : BaseDateTimeOffsetVisitor
    {
        /// <inheritdoc />
        protected override string PropertyName => nameof(System.DateTimeOffset.Now);

        /// <inheritdoc />
        protected BaseNowVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
