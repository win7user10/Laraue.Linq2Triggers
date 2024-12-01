using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.EndsWith
{
    /// <inheritdoc />
    public class StringEndsWithViaDoubleVerticalLineVisitor : BaseStringEndsWithVisitor
    {
        /// <inheritdoc />
        public StringEndsWithViaDoubleVerticalLineVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override string BuildEndSql(string argumentSql)
        {
            return $"('%' || {argumentSql})";
        }
    }
}