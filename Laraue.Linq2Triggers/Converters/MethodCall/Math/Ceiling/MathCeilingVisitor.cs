using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Ceiling
{
    /// <inheritdoc />
    public class MathCeilingVisitor : BaseMathCeilingVisitor
    {
        /// <inheritdoc />
        public MathCeilingVisitor(IExpressionVisitorFactory visitorFactory) : base(visitorFactory)
        {
        }

        /// <inheritdoc />
        protected override string SqlFunctionName => "CEILING";
    }
}
