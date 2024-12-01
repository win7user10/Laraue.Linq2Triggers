using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Contains
{
    /// <inheritdoc />
    public class StringContainsViaInstrFuncVisitor : BaseStringContainsVisitor
    {
        /// <inheritdoc />
        public StringContainsViaInstrFuncVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override string CombineSql(string expressionToSearchSql, string expressionToFindSql)
        {
            return $"INSTR({expressionToSearchSql}, {expressionToFindSql}) > 0";
        }
    }
}