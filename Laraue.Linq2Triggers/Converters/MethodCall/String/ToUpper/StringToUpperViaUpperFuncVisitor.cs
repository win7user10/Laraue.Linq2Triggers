using System.Linq.Expressions;
using Laraue.Linq2Triggers.SqlGeneration;
using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.String.ToUpper
{
    public class StringToUpperViaUpperFuncVisitor : BaseStringVisitor
    {
        /// <inheritdoc />
        protected override string MethodName => nameof(string.ToUpper);

        /// <inheritdoc />
        public StringToUpperViaUpperFuncVisitor(IExpressionVisitorFactory visitorFactory) 
            : base(visitorFactory)
        {
        }
        
        /// <inheritdoc />
        public override SqlBuilder Visit(
            MethodCallExpression expression,
            VisitedMembers visitedMembers)
        {
            var sqlBuilder = VisitorFactory.Visit(expression.Object, visitedMembers);
            
            return SqlBuilder.FromString($"UPPER({sqlBuilder})");
        }
    }
}