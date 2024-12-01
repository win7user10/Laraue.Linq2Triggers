using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;

namespace Laraue.Linq2Triggers.Visitors.ExpressionVisitors
{
    /// <inheritdoc />
    public class ParameterExpressionVisitor : BaseExpressionVisitor<ParameterExpression>
    {
        private readonly ISqlGenerator _generator;

        public ParameterExpressionVisitor(ISqlGenerator generator)
        {
            _generator = generator;
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(ParameterExpression expression, VisitedMembers visitedMembers)
        {
            return new SqlBuilder()
                .Append(_generator.GetTableSql(expression.Type));
        }
    }
}