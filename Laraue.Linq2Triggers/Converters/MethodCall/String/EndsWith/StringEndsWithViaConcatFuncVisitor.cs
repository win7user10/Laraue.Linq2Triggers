using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.EndsWith
{
    /// <inheritdoc />
    public class StringEndsWithViaConcatFuncVisitor : BaseStringEndsWithVisitor
    {
        /// <inheritdoc />
        public StringEndsWithViaConcatFuncVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override string BuildEndSql(string argumentSql)
        {
            return $"CONCAT('%', {argumentSql})";
        }
    }
}