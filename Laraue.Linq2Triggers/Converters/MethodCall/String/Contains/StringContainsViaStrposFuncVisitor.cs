using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Contains
{
    /// <inheritdoc />
    public class StringContainsViaStrposFuncVisitor : BaseStringContainsVisitor
    {
        /// <inheritdoc />
        public StringContainsViaStrposFuncVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override string CombineSql(string expressionToSearchSql, string expressionToFindSql)
        {
            return $"STRPOS({expressionToSearchSql}, {expressionToFindSql}) > 0";
        }
    }
}