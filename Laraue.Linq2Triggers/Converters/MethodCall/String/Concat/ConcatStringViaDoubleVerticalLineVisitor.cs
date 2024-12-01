using System.Linq;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.Concat
{
    /// <inheritdoc />
    public class ConcatStringViaDoubleVerticalLineVisitor : BaseStringConcatVisitor
    {
        /// <inheritdoc />
        public ConcatStringViaDoubleVerticalLineVisitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        protected override SqlBuilder Visit(SqlBuilder[] argumentsSql)
        {
            return new SqlBuilder()
                .AppendJoin(" || ", argumentsSql.Select(x => x.ToString()));
        }
    }
}