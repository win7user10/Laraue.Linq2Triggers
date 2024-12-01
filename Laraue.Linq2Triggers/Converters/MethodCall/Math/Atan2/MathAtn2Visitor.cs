using Laraue.Linq2Triggers.Visitors.ExpressionVisitors;

namespace Laraue.Linq2Triggers.Converters.MethodCall.Math.Atan2
{
    /// <inheritdoc />
    public class MathAtn2Visitor : BaseAtan2Visitor
    {
        /// <inheritdoc />
        protected override string SqlFunctionName => "ATN2";
        
        /// <inheritdoc />
        public MathAtn2Visitor(IExpressionVisitorFactory visitorFactory)
            : base(visitorFactory)
        {
        }
    }
}
