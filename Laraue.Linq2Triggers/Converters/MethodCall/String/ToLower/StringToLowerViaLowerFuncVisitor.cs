using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.ToLower
{
    public class StringToLowerViaLowerFuncVisitor : BaseStringVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(string.ToLower);
        
        /// <inheritdoc />
        public StringToLowerViaLowerFuncVisitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var sqlBuilder = VisitorFactory.Visit(expression.Object, visitedMembers);
            
            return SqlBuilder.FromString($"LOWER({sqlBuilder})");
        }
    }
}