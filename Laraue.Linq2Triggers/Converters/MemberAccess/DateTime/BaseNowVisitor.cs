using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MemberAccess.DateTime
{
    /// <summary>
    /// Visitor for <see cref="System.DateTime.Now"/>.
    /// </summary>
    public abstract class BaseNowVisitor : BaseDateTimeVisitor
    {
        /// <inheritdoc />
        protected override string PropertyName => nameof(System.DateTime.Now);

        /// <inheritdoc />
        protected BaseNowVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
    }
}
