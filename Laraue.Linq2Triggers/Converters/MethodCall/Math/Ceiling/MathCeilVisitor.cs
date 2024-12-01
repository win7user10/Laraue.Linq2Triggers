using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Ceiling
{
    /// <inheritdoc />
    public class MathCeilVisitor : BaseMathCeilingVisitor
    {
        /// <inheritdoc />
        public MathCeilVisitor(IExpressionVisitorFactory visitorFactory) : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        protected override string SqlFunctionName => "CEIL";
    }
}
